using System;
using System.Collections.Generic;
using System.Text;

namespace ActLikeAI.AscendancyExplorer
{
    public class CobLoaderArguments
    {
        public string FileName
        { get; set; }
        public string ArchiveName
        { get; set; }

        public CobLoaderArguments(string archiveName, string fileName)
        {
            this.FileName = fileName;
            this.ArchiveName = archiveName;
        }

    }
}
