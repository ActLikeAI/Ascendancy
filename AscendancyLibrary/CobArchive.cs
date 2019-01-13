using System;
using System.IO;
using System.Reflection;

namespace Ascendancy.Assets
{
    public class CobArchive
    {
        private string archiveName;
        /// <summary>
        /// File name.
        /// </summary>
        public string ArchiveName
        { get { return archiveName; } }
        

        private int fileCount;
        /// <summary>
        /// Number of files stored in the archive
        /// </summary>
        public int FileCount
        { get { return fileCount; } }


        private string[] files;
        /// <summary>
        /// List of file names contained in the archive.
        /// </summary>
        public string[] Files
        { get { return files; } }


        private int[] offsets;
        /// <summary>
        /// List of the offsets of individual files.
        /// </summary>
        public int[] Offsets
        { get { return offsets; } }


        private int[] lengths;
        /// <summary>
        /// List of the file lengths. 
        /// </summary>
        public int[] Lengths
        { get { return lengths; } }


        public CobArchive(string fileName)
        {
            this.archiveName = fileName;

            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists)
                throw new ArgumentException(String.Format("{0} doesn't exist", fileName));

            FileStream file = new FileStream(fileName, FileMode.Open);
            BinaryReader reader = new BinaryReader(file);

            fileCount = reader.ReadInt32();
            
            files = new string[fileCount];
            
            for (int i = 0; i < fileCount; i++)
                files[i] = new string(reader.ReadChars(50)).Trim('\0');

            offsets = new int[fileCount + 1];
            for (int i = 0; i < fileCount; i++)
                offsets[i] = reader.ReadInt32();
            offsets[fileCount] = (int)file.Length;

            lengths = new int[fileCount];
            for (int i = 0; i < fileCount; i++)
                lengths[i] = offsets[i + 1] - offsets[i];

            reader.Close();
            file.Close();
        }


        public T Load<T>(string fileName) where T : CobFile
        {
            int index = -1;

            for (int i = 0; i < fileCount; i++)
                if (files[i].ToLowerInvariant() == fileName.ToLowerInvariant())
                {
                    index = i;
                    break;
                }
            

            if (index < 0)
                throw new ArgumentException("Requested file doesn't exist");

            Type typeInfo = typeof(T);
            MethodInfo loadMethod = typeInfo.GetMethod("Load");
            return (T)loadMethod.Invoke(null, new object[] {this, fileName});
        }


        public static CobArchive Load(string fileName) 
        {
            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists)
                throw new ArgumentException(String.Format("{0} doesn't exist", fileName));
                        
            FileStream file = new FileStream (fileName, FileMode.Open);
            BinaryReader reader = new BinaryReader(file);

            int fileCount;
            string[] fileNames;
            int[] offsets;
            byte[][] files; 

            fileCount = reader.ReadInt32();

            fileNames = (string[])Array.CreateInstance(typeof(string), fileCount);
            for (int i = 0; i < fileCount; i++)
                fileNames[i] = (new string(reader.ReadChars(50))).Trim('\0');

            offsets = (int[])Array.CreateInstance(typeof(int), fileCount + 1);
            for (int i = 0; i < fileCount; i++)
                offsets[i] = reader.ReadInt32();
            offsets[fileCount] = (int)file.Length;

            FileStream outFile;
            BinaryWriter writter;

            files = (byte[][])Array.CreateInstance(typeof(byte[]), fileCount);
            for (int i = 0; i < fileCount; i++)
            {
                files[i] = reader.ReadBytes(offsets[i + 1] - offsets[i]);
                outFile = new FileStream(fileNames[i], FileMode.Create);
                writter = new BinaryWriter(outFile);

                writter.Write(files[i]);

                writter.Close();
                outFile.Close();
            }

            reader.Close();
            file.Close();
            return null; 
        }
    }
}
