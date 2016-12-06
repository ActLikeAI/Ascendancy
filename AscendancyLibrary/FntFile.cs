using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace TheYawningDragon.Ascendancy.Library
{
    public class FntFile : CobFile
    {
        private int characterCount;
        /// <summary>
        /// Number of images stored in .shp file
        /// </summary>
        public int CharacterCount
        { get { return characterCount; } }

        private int[] offsets;
        
        private Bitmap[] bitmaps;
        /// <summary>
        /// Retrives the bitmat at a given index.
        /// </summary>
        /// <param name="index">Index of the bitmap.</param>
        /// <returns>The bitmat at given index.</returns>
        public Bitmap this[int index]
        { get { return bitmaps[index]; } }


        private FntFile(CobArchive archive, string fileName)
            : base(archive, fileName)
        {
            CobArchive ascend01 = new CobArchive("Ascend01.cob");
            PalFile palette = ascend01.Load<PalFile>("data\\game.pal");

            int height, transparentColor;

            MemoryStream stream = new MemoryStream(this.content);
            BinaryReader reader = new BinaryReader(stream);

            reader.ReadInt32(); //veryfication

            characterCount = reader.ReadInt32();
            height = reader.ReadInt32();
            transparentColor = reader.ReadInt32();

            offsets = new int[characterCount + 1];

            for (int i = 0; i < characterCount; i++)
                offsets[i] = reader.ReadInt32();
            offsets[characterCount] = content.Length;


            int width, color;
            bitmaps = new Bitmap[characterCount];

            for (int n = 0; n < characterCount; n++)
            {
                width = reader.ReadInt32();

                if (width == 0)
                    continue;

                bitmaps[n] = new Bitmap(width, height);
                for (int i = 0; i < bitmaps[n].Height; i++)
                    for (int j = 0; j < bitmaps[n].Width; j++)
                    {
                        color = reader.ReadByte();
                        if (color == transparentColor)
                            bitmaps[n].SetPixel(j, i, Color.Transparent);
                        else
                            bitmaps[n].SetPixel(j, i, palette[color]);
                    }
            }

                reader.Close();
            stream.Close();
        }

        public new static FntFile Load(CobArchive parent, string fileName)
        {
            return new FntFile(parent, fileName);
        }

        public IEnumerator<Bitmap> GetEnumerator()
        {
            for (int i = 0; i < characterCount; i++)
                yield return bitmaps[i];
        }
    }
}
