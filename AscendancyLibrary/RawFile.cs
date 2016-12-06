using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TheYawningDragon.Ascendancy.Library
{
    public class RawFile : SoundFile
    {
        private RawFile(CobArchive parent, string fileName)
            : base(parent, fileName)
        {
            WavRiffChunk riff = new WavRiffChunk();

            riff.TotalSize = (uint)(12 + 24 + 8 + content.Length - 8);
            wavBuffer = new byte[riff.TotalSize + 8];          

            MemoryStream wavStream = new MemoryStream(wavBuffer);
            BinaryWriter writer = new BinaryWriter(wavStream);

            writer.Write(riff.ID);
            writer.Write(riff.TotalSize);
            writer.Write(riff.Type);

            WavFormatChunk format = new WavFormatChunk();

            format.Codec = 1;
            format.ChannelCount = 1;
            format.SampleRate = 22050;
            format.BytesPerSecond = 22050;
            format.BytesPerSample = 1;
            format.BitsPerSample = 8;

            writer.Write(format.ID);
            writer.Write(format.Size);
            writer.Write(format.Codec);
            writer.Write(format.ChannelCount);
            writer.Write(format.SampleRate);
            writer.Write(format.BytesPerSecond);
            writer.Write(format.BytesPerSample);
            writer.Write(format.BitsPerSample);

            WavDataChunk data = new WavDataChunk();
            data.Size = (uint)content.Length;

            writer.Write(data.ID);
            writer.Write(data.Size);
            writer.Write(content);

            writer.Close();
            wavStream.Close();
       
            
        }

        public new static RawFile Load(CobArchive parent, string fileName)
        {
            return new RawFile(parent, fileName);
        }
    }
}
