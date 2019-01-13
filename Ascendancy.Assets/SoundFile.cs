namespace Ascendancy.Assets
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
