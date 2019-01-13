using System;
using System.Drawing;

namespace Ascendancy.Assets
{
    public class PalFile : CobFile
    {
        private Color[] palette;
        public Color this[int index]
        { get { return palette[index]; } }


        private PalFile(CobArchive parent, string fileName)
            : base (parent, fileName)
        {
             palette = new Color[content.Length / 3];
            
            for (int i = 0; i < palette.Length; i++)
                palette[i] = Color.FromArgb(content[3 * i] * 4, content[3 * i + 1] * 4, content[3 * i + 2] * 4);
        }


        public Bitmap GetBitmap()
        {
            Bitmap bmp = new Bitmap((int)Math.Sqrt(palette.Length), (int)Math.Sqrt(palette.Length));
            for (int i = 0; i < palette.Length; i++)
                bmp.SetPixel(i / bmp.Width, i %bmp.Width, palette[i]);

            return bmp;
        }


        public new static PalFile Load(CobArchive parent, string fileName)
        {
            return new PalFile(parent, fileName);
        }
    }
}
