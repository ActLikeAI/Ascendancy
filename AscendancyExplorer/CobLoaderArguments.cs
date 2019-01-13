// Copyright (c) 2019 Attila Cséki.
// Licensed under the MIT license. See LICENCE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace TheYawningDragon.AscendancyExplorer
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
