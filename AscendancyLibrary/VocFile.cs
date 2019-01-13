// Copyright (c) 2019 Attila Cséki.
// Licensed under the MIT license. See LICENCE file in the project root for full license information.

using System;
using System.IO;

namespace Ascendancy.Assets
{
    public class VocFile : SoundFile
    {
        private VocFile(CobArchive parent, string fileName)
            : base(parent, fileName)
        {
            MemoryStream stream = new MemoryStream(this.content);
            BinaryReader reader = new BinaryReader(stream);

            //It should be "Creative Voice File"
            string ident = new string(reader.ReadChars(19));

            if (ident != "Creative Voice File")
                throw new Exception("This is not a valid Voc file. Try to load it as RAW file :)");

            //End of file (???)
            reader.ReadByte();

            //Main header size
            int mainHeaderSize = reader.ReadInt16();

            //Version 
            int minor = reader.ReadByte();
            int major = reader.ReadByte();
            //Validity check;
            int val = reader.ReadInt16();

            //block type
            VocBlockType type;
            uint size = 0, sampleRate = 0;
            byte frequencyDivisor = 0, bitsPerSample = 0, channelCount = 0;
            ushort codec = 0, wavCodec = 0, bytesPerSample = 0;
            
            byte[] data = null;

            while (stream.Position < stream.Length && (type = (VocBlockType)reader.ReadByte()) != VocBlockType.Terminator)
            {
                switch (type)
                {
                    case VocBlockType.Terminator:
                        break;
                    case VocBlockType.SoundData:
                        size = reader.ReadUInt16();
                        frequencyDivisor = reader.ReadByte();
                        codec = reader.ReadByte();

                        data = reader.ReadBytes((int)size - 2);

                        sampleRate =(uint)(1000000 / (256 - frequencyDivisor));
                        wavCodec = 1;
                        channelCount = 1;
                        bitsPerSample = 8;
                        bytesPerSample = 1;

                        break;
                    case VocBlockType.SoundData2:
                        
                        size = (uint)(reader.ReadByte() | reader.ReadByte() << 8 | reader.ReadByte() << 16);

                        sampleRate = reader.ReadUInt32();
                        bitsPerSample = reader.ReadByte();
                        channelCount = reader.ReadByte();
                        codec = reader.ReadUInt16();
                        reader.ReadUInt32();
                        data = reader.ReadBytes((int)size - 12);

                        wavCodec = 1;
                        bytesPerSample = 1;

                        break;
                    default:
                        throw new Exception("Unsupported VOC type.");
                }
            }
            reader.Close();
            stream.Close();

            //Writing the wav stream
            WavRiffChunk riff = new WavRiffChunk();

            riff.TotalSize = (uint)(12 + 24 + 8 + data.Length - 8);
            wavBuffer = new byte[riff.TotalSize + 8];

            MemoryStream wavStream = new MemoryStream(wavBuffer);
            BinaryWriter writer = new BinaryWriter(wavStream);

            writer.Write(riff.ID);
            writer.Write(riff.TotalSize);
            writer.Write(riff.Type);

            WavFormatChunk format = new WavFormatChunk();

            format.Codec = wavCodec;
            format.ChannelCount = channelCount;
            format.SampleRate = sampleRate;
            format.BytesPerSecond = sampleRate;
            format.BytesPerSample = bytesPerSample;
            format.BitsPerSample = bitsPerSample;

            writer.Write(format.ID);
            writer.Write(format.Size);
            writer.Write(format.Codec);
            writer.Write(format.ChannelCount);
            writer.Write(format.SampleRate);
            writer.Write(format.BytesPerSecond);
            writer.Write(format.BytesPerSample);
            writer.Write(format.BitsPerSample);

            WavDataChunk dataChunk = new WavDataChunk();
            dataChunk.Size = (uint)data.Length;

            writer.Write(dataChunk.ID);
            writer.Write(dataChunk.Size);
            writer.Write(data);

            writer.Close();
            wavStream.Close();
        }


        public new static VocFile Load(CobArchive parent, string fileName)
        {
            return new VocFile(parent, fileName);
        }
    }
}
