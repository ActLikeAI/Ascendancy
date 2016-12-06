using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ActLikeAI.Ascendancy.Library
{
    public class CobFile
    {
        protected CobArchive parent;
        protected int offset;

        protected string fileName;
        /// <summary>
        /// File name of the resource.
        /// </summary>
        public string FileName
        { get { return fileName; } }

        protected byte[] content;
        /// <summary>
        /// Content of the file
        /// </summary>
        public byte[] Content
        { get { return content; } }

        protected int length;
        /// <summary>
        /// Size of the file.
        /// </summary>
        public int Size
        { get { return length; } }

        public CobFile(CobArchive parent, string fileName)
        {
            int index = -1;

            for (int i = 0; i < parent.FileCount; i++)
                if (parent.Files[i].ToLowerInvariant() == fileName.ToLowerInvariant())
                {
                    index = i;
                    break;
                }


            if (index < 0)
                throw new ArgumentException("Requested file doesn't exist");

            this.parent = parent;
            this.fileName = parent.Files[index];
            this.offset = parent.Offsets[index];
            this.length = parent.Lengths[index];

            FileStream file = new FileStream(parent.ArchiveName, FileMode.Open);
            BinaryReader reader = new BinaryReader(file);

            file.Seek(offset, SeekOrigin.Begin);
            content = reader.ReadBytes(length);

            reader.Close();
            file.Close();

        }

        public void Save(string outDirectory)
        {
            //Check whether file name contains sub-dirs?
            string directory = Path.GetDirectoryName(fileName);

            Directory.SetCurrentDirectory(outDirectory);

            if (directory != "")
            {
                string[] dirs = directory.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);


                foreach (string dir in dirs)
                {
                    Directory.CreateDirectory(dir);
                    Directory.SetCurrentDirectory(dir);
                }

                Directory.SetCurrentDirectory(outDirectory);
            }

            FileStream file = new FileStream(Path.Combine(outDirectory, fileName), FileMode.Create);
            BinaryWriter writer = new BinaryWriter(file);

            writer.Write(content);

            writer.Close();
            file.Close();        
        }

        public void Save()
        { this.Save(Directory.GetCurrentDirectory()); }
        
        public static CobFile Load(CobArchive parent, string fileName)
        {
            return new CobFile(parent, fileName);
        }

    }
}
