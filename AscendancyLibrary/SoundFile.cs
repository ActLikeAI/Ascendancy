using System;
using System.Collections.Generic;
using System.Text;

namespace ActLikeAI.Ascendancy.Library
{
    public class SoundFile : CobFile
    {
        protected byte[] wavBuffer;
        public byte[] WavBuffer
        { get { return wavBuffer; } }

        protected SoundFile(CobArchive parent, string fileName)
            : base(parent, fileName)
        {}

    }
}
