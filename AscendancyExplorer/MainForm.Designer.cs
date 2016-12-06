namespace TheYawningDragon.AscendancyExplorer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDirectoryToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeViewIcons = new System.Windows.Forms.ImageList(this.components);
            this.fontPanel = new System.Windows.Forms.Panel();
            this.miscPanel = new System.Windows.Forms.Panel();
            this.miscBox = new System.Windows.Forms.TextBox();
            this.textPanel = new System.Windows.Forms.Panel();
            this.gifPanel = new System.Windows.Forms.Panel();
            this.gifBox = new System.Windows.Forms.PictureBox();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.pictureToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.shpBox = new System.Windows.Forms.PictureBox();
            this.loadingPictureLabel = new System.Windows.Forms.Label();
            this.pictureToolStrip = new System.Windows.Forms.ToolStrip();
            this.firstPictureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.prevPictureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pictureToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.nextPictureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lastPictureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.musicPanel = new System.Windows.Forms.Panel();
            this.musicToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.trackLabel = new System.Windows.Forms.Label();
            this.musicToolStrip = new System.Windows.Forms.ToolStrip();
            this.playMusicToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopMusicToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.videoToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.flcBox = new System.Windows.Forms.PictureBox();
            this.videoToolStrip = new System.Windows.Forms.ToolStrip();
            this.playVideoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopVideoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.flcTimer = new System.Windows.Forms.Timer(this.components);
            this.exportBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.exportWorker = new System.ComponentModel.BackgroundWorker();
            this.convertWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.miscPanel.SuspendLayout();
            this.gifPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifBox)).BeginInit();
            this.picturePanel.SuspendLayout();
            this.pictureToolStripContainer.ContentPanel.SuspendLayout();
            this.pictureToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.pictureToolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shpBox)).BeginInit();
            this.pictureToolStrip.SuspendLayout();
            this.musicPanel.SuspendLayout();
            this.musicToolStripContainer.ContentPanel.SuspendLayout();
            this.musicToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.musicToolStripContainer.SuspendLayout();
            this.musicToolStrip.SuspendLayout();
            this.videoPanel.SuspendLayout();
            this.videoToolStripContainer.ContentPanel.SuspendLayout();
            this.videoToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.videoToolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flcBox)).BeginInit();
            this.videoToolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(896, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDirectoryToolStripItem,
            this.toolStripSeparator1,
            this.extractToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // setDirectoryToolStripItem
            // 
            this.setDirectoryToolStripItem.Name = "setDirectoryToolStripItem";
            this.setDirectoryToolStripItem.Size = new System.Drawing.Size(193, 22);
            this.setDirectoryToolStripItem.Text = "&Set Directory...";
            this.setDirectoryToolStripItem.Click += new System.EventHandler(this.setDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.extractToolStripMenuItem.Text = "&Extract All...";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.convertToolStripMenuItem.Text = "Extract && &Convert All...";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.fontPanel);
            this.splitContainer.Panel2.Controls.Add(this.miscPanel);
            this.splitContainer.Panel2.Controls.Add(this.textPanel);
            this.splitContainer.Panel2.Controls.Add(this.gifPanel);
            this.splitContainer.Panel2.Controls.Add(this.picturePanel);
            this.splitContainer.Panel2.Controls.Add(this.musicPanel);
            this.splitContainer.Panel2.Controls.Add(this.videoPanel);
            this.splitContainer.Size = new System.Drawing.Size(896, 585);
            this.splitContainer.SplitterDistance = 191;
            this.splitContainer.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeViewIcons;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(191, 585);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // treeViewIcons
            // 
            this.treeViewIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewIcons.ImageStream")));
            this.treeViewIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewIcons.Images.SetKeyName(0, "Folder");
            this.treeViewIcons.Images.SetKeyName(1, "File");
            this.treeViewIcons.Images.SetKeyName(2, "Picture");
            this.treeViewIcons.Images.SetKeyName(3, "Movie");
            this.treeViewIcons.Images.SetKeyName(4, "Music");
            // 
            // fontPanel
            // 
            this.fontPanel.Location = new System.Drawing.Point(408, 428);
            this.fontPanel.Name = "fontPanel";
            this.fontPanel.Size = new System.Drawing.Size(200, 68);
            this.fontPanel.TabIndex = 6;
            // 
            // miscPanel
            // 
            this.miscPanel.Controls.Add(this.miscBox);
            this.miscPanel.Location = new System.Drawing.Point(25, 25);
            this.miscPanel.Name = "miscPanel";
            this.miscPanel.Size = new System.Drawing.Size(124, 120);
            this.miscPanel.TabIndex = 5;
            this.miscPanel.Visible = false;
            // 
            // miscBox
            // 
            this.miscBox.BackColor = System.Drawing.SystemColors.Window;
            this.miscBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscBox.Location = new System.Drawing.Point(0, 0);
            this.miscBox.Multiline = true;
            this.miscBox.Name = "miscBox";
            this.miscBox.ReadOnly = true;
            this.miscBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.miscBox.Size = new System.Drawing.Size(124, 120);
            this.miscBox.TabIndex = 0;
            // 
            // textPanel
            // 
            this.textPanel.Location = new System.Drawing.Point(419, 59);
            this.textPanel.Name = "textPanel";
            this.textPanel.Size = new System.Drawing.Size(155, 153);
            this.textPanel.TabIndex = 4;
            // 
            // gifPanel
            // 
            this.gifPanel.Controls.Add(this.gifBox);
            this.gifPanel.Location = new System.Drawing.Point(46, 322);
            this.gifPanel.Name = "gifPanel";
            this.gifPanel.Size = new System.Drawing.Size(192, 132);
            this.gifPanel.TabIndex = 3;
            // 
            // gifBox
            // 
            this.gifBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gifBox.Location = new System.Drawing.Point(0, 0);
            this.gifBox.Name = "gifBox";
            this.gifBox.Size = new System.Drawing.Size(192, 132);
            this.gifBox.TabIndex = 0;
            this.gifBox.TabStop = false;
            // 
            // picturePanel
            // 
            this.picturePanel.Controls.Add(this.pictureToolStripContainer);
            this.picturePanel.Location = new System.Drawing.Point(274, 274);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(285, 138);
            this.picturePanel.TabIndex = 1;
            this.picturePanel.Visible = false;
            // 
            // pictureToolStripContainer
            // 
            // 
            // pictureToolStripContainer.ContentPanel
            // 
            this.pictureToolStripContainer.ContentPanel.Controls.Add(this.shpBox);
            this.pictureToolStripContainer.ContentPanel.Controls.Add(this.loadingPictureLabel);
            this.pictureToolStripContainer.ContentPanel.Size = new System.Drawing.Size(285, 113);
            this.pictureToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.pictureToolStripContainer.Name = "pictureToolStripContainer";
            this.pictureToolStripContainer.Size = new System.Drawing.Size(285, 138);
            this.pictureToolStripContainer.TabIndex = 1;
            this.pictureToolStripContainer.Text = "toolStripContainer1";
            // 
            // pictureToolStripContainer.TopToolStripPanel
            // 
            this.pictureToolStripContainer.TopToolStripPanel.Controls.Add(this.pictureToolStrip);
            // 
            // shpBox
            // 
            this.shpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shpBox.Location = new System.Drawing.Point(0, 0);
            this.shpBox.Name = "shpBox";
            this.shpBox.Size = new System.Drawing.Size(285, 113);
            this.shpBox.TabIndex = 1;
            this.shpBox.TabStop = false;
            // 
            // loadingPictureLabel
            // 
            this.loadingPictureLabel.AutoSize = true;
            this.loadingPictureLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingPictureLabel.Location = new System.Drawing.Point(52, 35);
            this.loadingPictureLabel.Name = "loadingPictureLabel";
            this.loadingPictureLabel.Size = new System.Drawing.Size(180, 42);
            this.loadingPictureLabel.TabIndex = 0;
            this.loadingPictureLabel.Text = "Loading...";
            this.loadingPictureLabel.Visible = false;
            // 
            // pictureToolStrip
            // 
            this.pictureToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.pictureToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstPictureToolStripButton,
            this.prevPictureToolStripButton,
            this.pictureToolStripLabel,
            this.nextPictureToolStripButton,
            this.lastPictureToolStripButton});
            this.pictureToolStrip.Location = new System.Drawing.Point(3, 0);
            this.pictureToolStrip.Name = "pictureToolStrip";
            this.pictureToolStrip.Size = new System.Drawing.Size(190, 25);
            this.pictureToolStrip.TabIndex = 0;
            // 
            // firstPictureToolStripButton
            // 
            this.firstPictureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstPictureToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_start_blue;
            this.firstPictureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.firstPictureToolStripButton.Name = "firstPictureToolStripButton";
            this.firstPictureToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.firstPictureToolStripButton.Text = "First";
            this.firstPictureToolStripButton.Click += new System.EventHandler(this.firstPictureToolStripButton_Click);
            // 
            // prevPictureToolStripButton
            // 
            this.prevPictureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevPictureToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_prev_blue;
            this.prevPictureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevPictureToolStripButton.Name = "prevPictureToolStripButton";
            this.prevPictureToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.prevPictureToolStripButton.Text = "Previous";
            this.prevPictureToolStripButton.Click += new System.EventHandler(this.prevPictureToolStripButton_Click);
            // 
            // pictureToolStripLabel
            // 
            this.pictureToolStripLabel.AutoSize = false;
            this.pictureToolStripLabel.Name = "pictureToolStripLabel";
            this.pictureToolStripLabel.Size = new System.Drawing.Size(86, 22);
            this.pictureToolStripLabel.Text = "toolStripLabel1";
            // 
            // nextPictureToolStripButton
            // 
            this.nextPictureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextPictureToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_play_blue;
            this.nextPictureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextPictureToolStripButton.Name = "nextPictureToolStripButton";
            this.nextPictureToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nextPictureToolStripButton.Text = "Next";
            this.nextPictureToolStripButton.Click += new System.EventHandler(this.nextPictureToolStripButton_Click);
            // 
            // lastPictureToolStripButton
            // 
            this.lastPictureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastPictureToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_end_blue;
            this.lastPictureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastPictureToolStripButton.Name = "lastPictureToolStripButton";
            this.lastPictureToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.lastPictureToolStripButton.Text = "Last";
            this.lastPictureToolStripButton.Click += new System.EventHandler(this.lastPictureToolStripButton_Click);
            // 
            // musicPanel
            // 
            this.musicPanel.Controls.Add(this.musicToolStripContainer);
            this.musicPanel.Location = new System.Drawing.Point(39, 164);
            this.musicPanel.Name = "musicPanel";
            this.musicPanel.Size = new System.Drawing.Size(200, 100);
            this.musicPanel.TabIndex = 0;
            this.musicPanel.Visible = false;
            // 
            // musicToolStripContainer
            // 
            // 
            // musicToolStripContainer.ContentPanel
            // 
            this.musicToolStripContainer.ContentPanel.Controls.Add(this.trackLabel);
            this.musicToolStripContainer.ContentPanel.Size = new System.Drawing.Size(200, 75);
            this.musicToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.musicToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.musicToolStripContainer.Name = "musicToolStripContainer";
            this.musicToolStripContainer.Size = new System.Drawing.Size(200, 100);
            this.musicToolStripContainer.TabIndex = 0;
            this.musicToolStripContainer.Text = "toolStripContainer1";
            // 
            // musicToolStripContainer.TopToolStripPanel
            // 
            this.musicToolStripContainer.TopToolStripPanel.Controls.Add(this.musicToolStrip);
            // 
            // trackLabel
            // 
            this.trackLabel.AutoSize = true;
            this.trackLabel.Location = new System.Drawing.Point(16, 7);
            this.trackLabel.Name = "trackLabel";
            this.trackLabel.Size = new System.Drawing.Size(35, 13);
            this.trackLabel.TabIndex = 0;
            this.trackLabel.Text = "label1";
            // 
            // musicToolStrip
            // 
            this.musicToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.musicToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playMusicToolStripButton,
            this.stopMusicToolStripButton});
            this.musicToolStrip.Location = new System.Drawing.Point(3, 0);
            this.musicToolStrip.Name = "musicToolStrip";
            this.musicToolStrip.Size = new System.Drawing.Size(58, 25);
            this.musicToolStrip.TabIndex = 0;
            // 
            // playMusicToolStripButton
            // 
            this.playMusicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playMusicToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_play_blue;
            this.playMusicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playMusicToolStripButton.Name = "playMusicToolStripButton";
            this.playMusicToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.playMusicToolStripButton.Text = "Play";
            this.playMusicToolStripButton.Click += new System.EventHandler(this.playMusicToolStripButton_Click);
            // 
            // stopMusicToolStripButton
            // 
            this.stopMusicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopMusicToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_stop_blue;
            this.stopMusicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopMusicToolStripButton.Name = "stopMusicToolStripButton";
            this.stopMusicToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopMusicToolStripButton.Text = "Stop";
            this.stopMusicToolStripButton.Click += new System.EventHandler(this.stopMusicToolStripButton_Click);
            // 
            // videoPanel
            // 
            this.videoPanel.Controls.Add(this.videoToolStripContainer);
            this.videoPanel.Location = new System.Drawing.Point(169, 58);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(200, 100);
            this.videoPanel.TabIndex = 2;
            this.videoPanel.Visible = false;
            // 
            // videoToolStripContainer
            // 
            // 
            // videoToolStripContainer.ContentPanel
            // 
            this.videoToolStripContainer.ContentPanel.Controls.Add(this.loadingLabel);
            this.videoToolStripContainer.ContentPanel.Controls.Add(this.flcBox);
            this.videoToolStripContainer.ContentPanel.Size = new System.Drawing.Size(200, 75);
            this.videoToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.videoToolStripContainer.Name = "videoToolStripContainer";
            this.videoToolStripContainer.Size = new System.Drawing.Size(200, 100);
            this.videoToolStripContainer.TabIndex = 0;
            this.videoToolStripContainer.Text = "toolStripContainer1";
            // 
            // videoToolStripContainer.TopToolStripPanel
            // 
            this.videoToolStripContainer.TopToolStripPanel.Controls.Add(this.videoToolStrip);
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Location = new System.Drawing.Point(0, 0);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(180, 42);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "Loading...";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingLabel.Visible = false;
            // 
            // flcBox
            // 
            this.flcBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flcBox.Location = new System.Drawing.Point(0, 0);
            this.flcBox.Name = "flcBox";
            this.flcBox.Size = new System.Drawing.Size(200, 75);
            this.flcBox.TabIndex = 0;
            this.flcBox.TabStop = false;
            // 
            // videoToolStrip
            // 
            this.videoToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.videoToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playVideoToolStripButton,
            this.stopVideoToolStripButton});
            this.videoToolStrip.Location = new System.Drawing.Point(3, 0);
            this.videoToolStrip.Name = "videoToolStrip";
            this.videoToolStrip.Size = new System.Drawing.Size(58, 25);
            this.videoToolStrip.TabIndex = 0;
            // 
            // playVideoToolStripButton
            // 
            this.playVideoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playVideoToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_play_blue;
            this.playVideoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playVideoToolStripButton.Name = "playVideoToolStripButton";
            this.playVideoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.playVideoToolStripButton.Text = "Play";
            this.playVideoToolStripButton.Click += new System.EventHandler(this.playVideoToolStripButton_Click);
            // 
            // stopVideoToolStripButton
            // 
            this.stopVideoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopVideoToolStripButton.Image = global::TheYawningDragon.AscendancyExplorer.Properties.Resources.control_stop_blue;
            this.stopVideoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopVideoToolStripButton.Name = "stopVideoToolStripButton";
            this.stopVideoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopVideoToolStripButton.Text = "Stop";
            this.stopVideoToolStripButton.Click += new System.EventHandler(this.stopVideoToolStripButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // flcTimer
            // 
            this.flcTimer.Tick += new System.EventHandler(this.flcTimer_Tick);
            // 
            // exportBrowserDialog
            // 
            this.exportBrowserDialog.Description = "Select output directory.";
            // 
            // exportWorker
            // 
            this.exportWorker.WorkerReportsProgress = true;
            this.exportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exportWorker_DoWork);
            this.exportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exportWorker_RunWorkerCompleted);
            this.exportWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.exportWorker_ProgressChanged);
            // 
            // convertWorker
            // 
            this.convertWorker.WorkerReportsProgress = true;
            this.convertWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.convertWorker_DoWork);
            this.convertWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.convertWorker_RunWorkerCompleted);
            this.convertWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.convertWorker_ProgressChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 612);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(896, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // progressLabel
            // 
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 634);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Ascendancy Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.miscPanel.ResumeLayout(false);
            this.miscPanel.PerformLayout();
            this.gifPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gifBox)).EndInit();
            this.picturePanel.ResumeLayout(false);
            this.pictureToolStripContainer.ContentPanel.ResumeLayout(false);
            this.pictureToolStripContainer.ContentPanel.PerformLayout();
            this.pictureToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.pictureToolStripContainer.TopToolStripPanel.PerformLayout();
            this.pictureToolStripContainer.ResumeLayout(false);
            this.pictureToolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shpBox)).EndInit();
            this.pictureToolStrip.ResumeLayout(false);
            this.pictureToolStrip.PerformLayout();
            this.musicPanel.ResumeLayout(false);
            this.musicToolStripContainer.ContentPanel.ResumeLayout(false);
            this.musicToolStripContainer.ContentPanel.PerformLayout();
            this.musicToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.musicToolStripContainer.TopToolStripPanel.PerformLayout();
            this.musicToolStripContainer.ResumeLayout(false);
            this.musicToolStripContainer.PerformLayout();
            this.musicToolStrip.ResumeLayout(false);
            this.musicToolStrip.PerformLayout();
            this.videoPanel.ResumeLayout(false);
            this.videoToolStripContainer.ContentPanel.ResumeLayout(false);
            this.videoToolStripContainer.ContentPanel.PerformLayout();
            this.videoToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.videoToolStripContainer.TopToolStripPanel.PerformLayout();
            this.videoToolStripContainer.ResumeLayout(false);
            this.videoToolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flcBox)).EndInit();
            this.videoToolStrip.ResumeLayout(false);
            this.videoToolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ImageList treeViewIcons;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.ToolStripContainer pictureToolStripContainer;
        private System.Windows.Forms.ToolStrip pictureToolStrip;
        private System.Windows.Forms.Panel musicPanel;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.ToolStripContainer musicToolStripContainer;
        private System.Windows.Forms.ToolStrip musicToolStrip;
        private System.Windows.Forms.ToolStripContainer videoToolStripContainer;
        private System.Windows.Forms.Panel gifPanel;
        private System.Windows.Forms.ToolStrip videoToolStrip;
        private System.Windows.Forms.ToolStripButton playVideoToolStripButton;
        private System.Windows.Forms.ToolStripButton playMusicToolStripButton;
        private System.Windows.Forms.ToolStripButton stopMusicToolStripButton;
        private System.Windows.Forms.ToolStripButton stopVideoToolStripButton;
        private System.Windows.Forms.ToolStripButton firstPictureToolStripButton;
        private System.Windows.Forms.ToolStripButton prevPictureToolStripButton;
        private System.Windows.Forms.ToolStripLabel pictureToolStripLabel;
        private System.Windows.Forms.ToolStripButton nextPictureToolStripButton;
        private System.Windows.Forms.ToolStripButton lastPictureToolStripButton;
        private System.Windows.Forms.Label loadingPictureLabel;
        private System.Windows.Forms.PictureBox shpBox;
        private System.Windows.Forms.PictureBox gifBox;
        private System.Windows.Forms.Panel miscPanel;
        private System.Windows.Forms.Panel textPanel;
        private System.Windows.Forms.Panel fontPanel;
        private System.Windows.Forms.PictureBox flcBox;
        private System.Windows.Forms.Timer flcTimer;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Label trackLabel;
        private System.Windows.Forms.TextBox miscBox;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDirectoryToolStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog exportBrowserDialog;
        private System.ComponentModel.BackgroundWorker exportWorker;
        private System.ComponentModel.BackgroundWorker convertWorker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel progressLabel;
    }
}

