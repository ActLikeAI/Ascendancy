// Copyright (c) 2019 Attila Cséki.
// Licensed under the MIT license. See LICENCE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace TheYawningDragon.Ascendancy.Library
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
