using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace ActLikeAI.Ascendancy.Library
{
    public class GifFile : CobFile
    {
        private Bitmap bitmap;
        /// <summary>
        /// 
        /// </summary>
        public Bitmap Bitmap
        { get { return bitmap; } }

        private GifFile(CobArchive parent, string fileName)
            : base(parent, fileName)
        {
            MemoryStream stream = new MemoryStream(content);
            bitmap = new Bitmap(stream);
        }

        public new static GifFile Load(CobArchive parent, string fileName)
        {
            return new GifFile(parent, fileName);
        }

    }
}
