using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace TheYawningDragon.Ascendancy.Library
{
    public class ShpFile : CobFile
    {
        
        private int imageCount;
        /// <summary>
        /// Number of images stored in .shp file
        /// </summary>
        public int ImageCount
        { get { return imageCount; } }

        private int[] imageOffsets;
        private int[] paletteOffsets;

        private Bitmap[] bitmaps;
        /// <summary>
        /// Retrives the bitmat at a given index.
        /// </summary>
        /// <param name="index">Index of the bitmap.</param>
        /// <returns>The bitmat at given index.</returns>
        public Bitmap this[int index]
        { get { return bitmaps[index]; } }

        private ShpFile(CobArchive parent, string fileName)
            : base (parent, fileName)
        {
            CobArchive ascend01 = new CobArchive(Path.Combine( Path.GetDirectoryName(parent.ArchiveName),  "Ascend01.cob"));
            PalFile palette = ascend01.Load<PalFile>("data\\game.pal");
            
            //int count;
            int width, height, xCenter, yCenter, xStart, yStart, xEnd, yEnd, x, y;

            MemoryStream stream = new MemoryStream(this.content);
            BinaryReader reader = new BinaryReader(stream);


            reader.ReadInt32();
            imageCount = reader.ReadInt32();

            imageOffsets = new int[imageCount + 1];
            paletteOffsets = new int[imageCount];
            for (int i = 0; i < imageCount; i++)
            {
                imageOffsets[i] = reader.ReadInt32();
                paletteOffsets[i] = reader.ReadInt32();
            }
            imageOffsets[imageCount] = (int)stream.Length;

            bitmaps = new Bitmap[imageCount];

            for (int n = 0; n < imageCount; n++)
            {
                stream.Seek(imageOffsets[n], SeekOrigin.Begin);

                height = reader.ReadInt16() + 1;
                width = reader.ReadInt16() + 1;
                yCenter = reader.ReadInt16();
                xCenter = reader.ReadInt16();
                xStart = reader.ReadInt32() + xCenter;
                yStart = reader.ReadInt32() + yCenter;
                xEnd = reader.ReadInt32() + xCenter;
                yEnd = reader.ReadInt32() + yCenter;

                if (xStart < -xCenter)
                    xStart = 0;
                if (xEnd > width)
                    xEnd = width - 1 - xCenter;
                if (yStart < -yCenter)
                    yStart = 0;
                if (yEnd > height)
                    yEnd = height - 1 - yCenter;



                bitmaps[n] = new Bitmap(width, height);
                for (int i = 0; i < bitmaps[n].Width; i++)
                    for (int j = 0; j < bitmaps[n].Height; j++)
                        bitmaps[n].SetPixel(i, j, Color.Transparent);

            
                x = xStart;
                y = yStart;

                byte value, colorIndex, pixelCount;

                while (y <= yEnd)
                {
                    value = reader.ReadByte();

                    if (value == 0)
                    {
                        while (x <= xEnd)
                        {
                            bitmaps[n].SetPixel(x, y, Color.Transparent);
                            x++;
                        }
                        x = xStart;
                        y++;
                    }
                    else
                        if (value == 1)
                        {
                            pixelCount = reader.ReadByte();
                            for (byte i = 0; i < pixelCount; i++)
                            {
                                bitmaps[n].SetPixel(x, y, Color.Transparent);
                                x++;
                            }
                        }
                        else
                            if ((value & 1) == 0)
                            {
                                colorIndex = reader.ReadByte();
                                pixelCount = (byte)(value >> 1);
                                for (byte i = 0; i < pixelCount; i++)
                                {
                                    //Console.WriteLine("{0}   {1}   {2}", n, x, y);
                                    bitmaps[n].SetPixel(x, y, palette[colorIndex]);
                                    x++;
                                }
                            }
                            else
                            {
                                pixelCount = (byte)(value >> 1);
                                for (byte i = 0; i < pixelCount; i++)
                                {
                                    colorIndex = reader.ReadByte();
                                    bitmaps[n].SetPixel(x, y, palette[colorIndex]);
                                    x++;
                                }
                            }
                }

                if (stream.Position != this.imageOffsets[n + 1])
                {
                    reader.ReadBytes(this.imageOffsets[n + 1] - (int)stream.Position);
                }

            }

            reader.Close();
            stream.Close();
        
        }

        public new static ShpFile Load(CobArchive parent, string fileName)
        {
            return new ShpFile(parent, fileName);
        }

        public IEnumerator<Bitmap> GetEnumerator()
        {
            for (int i = 0; i < imageCount; i++) 
                yield return bitmaps[i];
        }

    }
}
