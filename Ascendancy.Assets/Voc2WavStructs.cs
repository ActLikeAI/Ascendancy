// Copyright (c) 2019 Attila Cséki.
// Licensed under the MIT license. See LICENCE file in the project root for full license information.

namespace Ascendancy.Assets
{
    public class WavRiffChunk
    {
        public char[] ID;
        public uint TotalSize; //file size - 8
        public char[] Type;

        public WavRiffChunk()
        {
            ID = new char[] { 'R', 'I', 'F', 'F' };
            Type = new char[] { 'W', 'A', 'V', 'E' };
        }
    }


    public class WavFormatChunk
    {
        public char[] ID;
        public uint Size;
        public ushort Codec;
        public ushort ChannelCount;
        public uint SampleRate;
        public uint BytesPerSecond;
        public ushort BytesPerSample;
        public ushort BitsPerSample;

        public WavFormatChunk()
        {
            ID = new char[] { 'f', 'm', 't', ' ' };
            Size = 0x10;
            Codec = 0x01;
        }
    }


    public class WavDataChunk
    {
        public char[] ID;
        public uint Size;

        public WavDataChunk()
        {
            ID = new char[] { 'd', 'a', 't', 'a' };
        }
    }


    public enum VocBlockType
    {
        Terminator = 0,
        SoundData = 1,
        SoundDataContinuation = 2,
        Silence = 3,
        Marker = 4,
        Text = 5,
        StartRepetition = 6,
        EndRepetition = 7,
        ExtraInfo = 8,
        SoundData2 = 9
    }
}