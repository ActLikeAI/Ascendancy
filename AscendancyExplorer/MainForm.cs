using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using Ascendancy.Assets;

namespace Ascendancy.Explorer
{
    public partial class MainForm : Form
    {
        private Properties.Settings settings = new Properties.Settings();
        private List<CobArchive> ascendCobs = new List<CobArchive>();

        private ShpFile currentShp;
        private int currentShpIndex;
        private SoundPlayer soundPlayer;
        private int currentFlcFrame;
        private List<Bitmap> currentFlc;
        
        public MainForm()
        {
            InitializeComponent();

            soundPlayer = new SoundPlayer();

            if (settings.AscendancyPath != "")
            {
                if (CobArchiveExists(settings.AscendancyPath))
                {
                    OpenCobs();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           

        }

        private void setDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Select directory

            treeView.Nodes.Clear();

            while (true)
            {
                folderBrowserDialog.Description = "Select Ascendancy game folder.";
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                    if (CobArchiveExists(folderBrowserDialog.SelectedPath))
                    {
                        settings.AscendancyPath = folderBrowserDialog.SelectedPath;
                        settings.Save();
                        break;
                    }
                    else
                    {
                        DialogResult resultMSG = MessageBox.Show("One or more Ascendancy archive files are missing in the selected folder. Do you want to select another folder?", "Archive files opening error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultMSG == DialogResult.No)
                            break;
                    }
                else
                    return;
            }

            OpenCobs();
        }

        private void OpenCobs()
        {
            DirectoryInfo ascendDir = new DirectoryInfo(settings.AscendancyPath);
            FileInfo[] files = ascendDir.GetFiles();

            TreeNode rootNode, subdirNode, fileNode, currentNode;
            CobArchive cobArchive;

            foreach (FileInfo file in files)
            {
                if (file.Extension.ToLowerInvariant() == ".cob")
                {
                    cobArchive = new CobArchive(file.FullName);
                    ascendCobs.Add(cobArchive);

                    rootNode = new TreeNode(file.Name);
                    rootNode.ImageKey = "Folder";
                    rootNode.SelectedImageKey = "Folder";

                    foreach(string cobFile in cobArchive.Files)
                    {
                        currentNode = rootNode;
                        
                        string cobDir = Path.GetDirectoryName(cobFile);
                        if (cobDir != "")
                        {
                            string[] dirs = cobDir.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);

                            
                            foreach (string dir in dirs)
                            {
                                bool found = false;

                                foreach (TreeNode node in currentNode.Nodes)
                                    if (node.Text == dir)
                                    {
                                        currentNode = node;
                                        found = true;
                                        break;
                                    }
                                if (!found)
                                {
                                    subdirNode = new TreeNode(dir);
                                    subdirNode.ImageKey = "Folder";
                                    subdirNode.SelectedImageKey = "Folder";

                                    currentNode.Nodes.Insert(0, subdirNode);
                                    currentNode = subdirNode;
                                }

                            }

                            
                        }

                        fileNode = new TreeNode(Path.GetFileName(cobFile));

                        switch (Path.GetExtension(cobFile).ToLowerInvariant())
                        { 
                            case ".tmp" :
                            case ".gif" :
                            case ".shp" :
                                fileNode.ImageKey = "Picture";
                                fileNode.SelectedImageKey = "Picture";
                                break;

                            case ".voc":
                            case ".raw":
                                fileNode.ImageKey = "Music";
                                fileNode.SelectedImageKey = "Music";
                                break;
                            case ".flc" :
                                fileNode.ImageKey = "Movie";
                                fileNode.SelectedImageKey = "Movie";
                                break;
                            default:
                                fileNode.ImageKey = "File";
                                fileNode.SelectedImageKey = "File";
                                break;
                        }
                        
                        currentNode.Nodes.Add(fileNode);
                    }

                    treeView.Nodes.Add(rootNode);
                }
            }
        }

        private bool CobArchiveExists(string rootPath)
        {
            DirectoryInfo ascendPath = new DirectoryInfo(rootPath);
            FileInfo[] files = ascendPath.GetFiles();
            
            foreach (FileInfo file in files)
            {
                if (file.Extension.ToLowerInvariant() == ".cob")
                    return true;
            }

            return false;
        }

        public CobArchive FindArchive(string archiveName)
        {
            foreach (CobArchive archive in ascendCobs)
            {
                if (archive.ArchiveName == archiveName)
                    return archive;
            }
        
            return null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageKey != "Folder")
            {
                TreeNode currentNode = e.Node;
                string fileName = "";
                string archiveName = "";
                if (currentNode.Parent.Parent == null)
                {
                    fileName = currentNode.Text;
                }
                else
                {
                    while (currentNode.Parent.Parent != null)
                    {
                        fileName = currentNode.Parent.Text + "\\" + currentNode.Text;
                        currentNode = currentNode.Parent;
                    }
                }

                archiveName = Path.Combine(settings.AscendancyPath, currentNode.Parent.Text);

                CobArchive archive = FindArchive(archiveName);;

                //Clean up
                flcTimer.Enabled = false;
                currentFlcFrame = 0;
                soundPlayer.Stop();
                soundPlayer.Stream = null;
                currentShp = null;
                currentFlc = null;
                miscBox.Text = "";

                switch (Path.GetExtension(e.Node.Text).ToLowerInvariant())
                { 
                    case ".flc" :
                        gifPanel.Visible = false;
                        musicPanel.Visible = false;
                        picturePanel.Visible = false;
                        miscPanel.Visible = false;
                        fontPanel.Visible = false;
                        textPanel.Visible = false;

                        videoPanel.Dock = DockStyle.Fill;
                        videoPanel.Visible = true;

                        flcBox.Visible = false;
                        loadingLabel.Top = (videoToolStripContainer.Height - loadingLabel.Height) / 2;
                        loadingLabel.Left = (videoToolStripContainer.Width - loadingLabel.Width) / 2;
                        loadingLabel.Visible = true;

                        this.Refresh();
                       
                        FlcFile flcFile = archive.Load<FlcFile>(fileName);

                        loadingLabel.Visible = false;
                        flcBox.Visible = true;

                        this.Refresh();
                        flcTimer.Interval = flcFile.Speed;
                        currentFlc = flcFile.Bitmaps;
                        currentFlcFrame = 0;

                        flcBox.Image = currentFlc[currentFlcFrame];
                                               
                        break;

                    case ".voc" :
                        

                        gifPanel.Visible = false;
                        videoPanel.Visible = false;
                        picturePanel.Visible = false;
                        miscPanel.Visible = false;
                        fontPanel.Visible = false;
                        textPanel.Visible = false;

                        musicPanel.Dock = DockStyle.Fill;
                        musicPanel.Visible = true;
                        
                        try 
                        {
                            VocFile vocFile = archive.Load<VocFile>(fileName);
                            soundPlayer.Stream = new MemoryStream(vocFile.WavBuffer);
                        }
                        catch (Exception)
                        {
                            RawFile rawVocFile = archive.Load<RawFile>(fileName);
                            soundPlayer.Stream = new MemoryStream(rawVocFile.WavBuffer);
                        }

                        trackLabel.Text = "Track: " + Path.GetFileName(fileName);

                        break;
                    case ".raw" :
                        gifPanel.Visible = false;
                        videoPanel.Visible = false;
                        picturePanel.Visible = false;
                        miscPanel.Visible = false;
                        fontPanel.Visible = false;
                        textPanel.Visible = false;

                        musicPanel.Dock = DockStyle.Fill;
                        musicPanel.Visible = true;

                        RawFile rawFile = archive.Load<RawFile>(fileName);

                        soundPlayer.Stream = new MemoryStream(rawFile.WavBuffer);

                        trackLabel.Text = "Track: " + Path.GetFileName(fileName);

                        break;

                    case ".gif" :
                        musicPanel.Visible = false;
                        videoPanel.Visible = false;
                        picturePanel.Visible = false;
                        miscPanel.Visible = false;
                        fontPanel.Visible = false;
                        textPanel.Visible = false;

                        gifPanel.Dock = DockStyle.Fill;
                        gifPanel.Visible = true; ;

                        GifFile gifFile = archive.Load<GifFile>(fileName);

                        gifBox.Image = gifFile.Bitmap;

                        break;
                    case ".tmp" :
                    case ".shp" :
                        musicPanel.Visible = false;
                        videoPanel.Visible = false;
                        gifPanel.Visible = false;
                        miscPanel.Visible = false;
                        fontPanel.Visible = false;
                        textPanel.Visible = false;
                    
                        picturePanel.Dock = DockStyle.Fill;
                        picturePanel.Visible = true;

                        ShpFile shpFile = null;

                        try
                        {
                            shpFile = archive.Load<ShpFile>(fileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Load Error");
                            return;
                        }
                        currentShp = shpFile;
                        currentShpIndex = 0;

                        pictureToolStripLabel.Text = string.Format("{0}  /  {1}", currentShpIndex +1, currentShp.ImageCount);
                        shpBox.Image = currentShp[currentShpIndex];

                        break;
                    default:

                        musicPanel.Visible = false;
                        videoPanel.Visible = false;
                        gifPanel.Visible = false;
                        picturePanel.Visible = false;
                        fontPanel.Visible = false;
                        textPanel.Visible = false;

                        miscPanel.Dock = DockStyle.Fill;
                        miscPanel.Visible = true;

                        CobFile miscFile = archive.Load<CobFile>(fileName);

                        ASCIIEncoding encoding = new ASCIIEncoding();

                        miscBox.Text = encoding.GetString(miscFile.Content);

                        break;
                }
            }
           
                
        }

        private void firstPictureToolStripButton_Click(object sender, EventArgs e)
        {

            currentShpIndex = 0;
            pictureToolStripLabel.Text = string.Format("{0}  /  {1}", currentShpIndex + 1, currentShp.ImageCount);
            shpBox.Image = currentShp[currentShpIndex];

        }

        private void lastPictureToolStripButton_Click(object sender, EventArgs e)
        {
            currentShpIndex = currentShp.ImageCount - 1;
            pictureToolStripLabel.Text = string.Format("{0}  /  {1}", currentShpIndex + 1, currentShp.ImageCount);
            shpBox.Image = currentShp[currentShpIndex];
        }

        private void prevPictureToolStripButton_Click(object sender, EventArgs e)
        {
            currentShpIndex--;
            if (currentShpIndex < 0)
                currentShpIndex = currentShp.ImageCount - 1;

            pictureToolStripLabel.Text = string.Format("{0}  /  {1}", currentShpIndex + 1, currentShp.ImageCount);
            shpBox.Image = currentShp[currentShpIndex];
        }

        private void nextPictureToolStripButton_Click(object sender, EventArgs e)
        {
            currentShpIndex++;
            if (currentShpIndex == currentShp.ImageCount)
                currentShpIndex = 0;
            pictureToolStripLabel.Text = string.Format("{0}  /  {1}", currentShpIndex + 1, currentShp.ImageCount);
            shpBox.Image = currentShp[currentShpIndex];
        }

        private void playMusicToolStripButton_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();
        }

        private void stopMusicToolStripButton_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
        }

        private void playVideoToolStripButton_Click(object sender, EventArgs e)
        {
            currentFlcFrame = 0;
            flcTimer.Enabled = true;
            
        }

        private void stopVideoToolStripButton_Click(object sender, EventArgs e)
        {
            flcTimer.Enabled = false;
            
            currentFlcFrame = 0;
            flcBox.Image = currentFlc[currentFlcFrame];
            
            
            
        }

        private void flcTimer_Tick(object sender, EventArgs e)
        {
            flcBox.Image = currentFlc[currentFlcFrame];
            currentFlcFrame++;
            if (currentFlcFrame == currentFlc.Count)
                flcTimer.Enabled = false;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message;

            message = "Ascendancy Explorer 1.0\n";
            message += "Copyright © Infinite Reflections 2009\n\n";
            message += "http://attila.infinitereflections.rs";
            
            
            MessageBox.Show(message, "About Ascendancy Explorer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            DialogResult result = exportBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                exportWorker.RunWorkerAsync();
            }   
         
        }

        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = exportBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                convertWorker.RunWorkerAsync();
            }   
        }

        private void exportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            
            foreach (CobArchive archive in ascendCobs)
            {
                foreach (string fileName in archive.Files)
                {
                    CobFile file = archive.Load<CobFile>(fileName);
                    file.Save(exportBrowserDialog.SelectedPath);

                    worker.ReportProgress(0, "Exporting:  " + fileName);
                }
            }

            e.Result = "ok";
        }

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressLabel.Text = "";
        }

        private void exportWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressLabel.Text = e.UserState.ToString();
        }

        private void convertWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            foreach (CobArchive archive in ascendCobs)
            {
                foreach (string fileName in archive.Files)
                {
                    switch(Path.GetExtension(fileName).ToLowerInvariant())
                    {
                        case ".tmp":
                        case ".shp":
                            ShpFile shp = archive.Load<ShpFile>(fileName);
                            shp.Save(exportBrowserDialog.SelectedPath);

                            for (int i = 0; i < shp.ImageCount; i++)
                                shp[i].Save(Path.Combine(exportBrowserDialog.SelectedPath, string.Format("{0}-{1:0000}.png", fileName, i)), System.Drawing.Imaging.ImageFormat.Png);
                            
                            break;

                        case ".raw" :
                        case ".voc" :

                            SoundFile voc;

                            try
                            {
                                voc = archive.Load<VocFile>(fileName);
                            }
                            catch (Exception)
                            {
                                voc = archive.Load<RawFile>(fileName);
                            }
                            voc.Save(exportBrowserDialog.SelectedPath);

                            FileStream stream = new FileStream(Path.Combine(exportBrowserDialog.SelectedPath, string.Format("{0}.wav", fileName)),FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(stream);

                                writer.Write(voc.WavBuffer);

                            writer.Close();
                            stream.Close();

                            break;
                        case ".flc" :
                            FlcFile flc = archive.Load<FlcFile>(fileName);
                            flc.Save(exportBrowserDialog.SelectedPath);

                            for (int i = 0; i < flc.Bitmaps.Count; i++)
                                flc.Bitmaps[i].Save(Path.Combine(exportBrowserDialog.SelectedPath, string.Format("{0}-{1:0000}.png", fileName, i)), System.Drawing.Imaging.ImageFormat.Png);
                            break;

                        default:
                            CobFile file = archive.Load<CobFile>(fileName);
                            file.Save(exportBrowserDialog.SelectedPath);
                            break;
                    }
                    worker.ReportProgress(0, "Exporting:  " + fileName);
                }
            }

            e.Result = "ok";
        }

        private void convertWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressLabel.Text = e.UserState.ToString();
        }

        private void convertWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressLabel.Text = "";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (exportWorker.IsBusy || convertWorker.IsBusy)
            {
                MessageBox.Show("Please, wait for the export command to finish.");
                e.Cancel = true;
            }        
        }

    }
}
