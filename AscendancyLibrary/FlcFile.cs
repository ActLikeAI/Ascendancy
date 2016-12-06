using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace ActLikeAI.Ascendancy.Library
{
    public class FlcFile : CobFile
    {
        public List<Bitmap> Bitmaps;
        public int Speed;

        private FlcFile(CobArchive parent, string fileName)
            : base(parent, fileName)
        {
            Bitmaps = new List<Bitmap>();           
            
            MemoryStream stream = new MemoryStream(this.content);
            BinaryReader reader = new BinaryReader(stream);

            FlcHeader header;

            header.FileSize = reader.ReadUInt32();
            header.Type = reader.ReadUInt16();

            header.FrameCount = reader.ReadUInt16();
            header.Width = reader.ReadUInt16();
            header.Height = reader.ReadUInt16();
            header.Depth = reader.ReadUInt16();

            header.Flags = reader.ReadUInt16();
            header.Speed = reader.ReadUInt32();
            header.Reserved1 = reader.ReadUInt16();

            header.Created = reader.ReadUInt32();
            header.Creator = reader.ReadUInt32();
            header.Updated = reader.ReadUInt32();
            header.Updater = reader.ReadUInt32();
            header.Aspect_dx = reader.ReadUInt16();
            header.Aspect_dy = reader.ReadUInt16();

            header.ExtFlags = reader.ReadUInt16();
            header.KeyFrames = reader.ReadUInt16();
            header.TotalFrames = reader.ReadUInt16();
            header.ReqMemory = reader.ReadUInt32();
            header.MaxRegions = reader.ReadUInt16();
            header.TransparentCount = reader.ReadUInt16();

            header.Reserved2 = reader.ReadBytes(24);
            header.Frame1Offset = reader.ReadUInt32();
            header.Frame2Offset = reader.ReadUInt32();

            header.Reserved3 = reader.ReadBytes(40);

            
            int chunkNumber = 0;
            Color[] pallete = new Color[256];

            while (stream.Position < stream.Length)
            {
                FlcChunkHeader chunkHeader;
                FlcChunkHeader subChunkHeader;
                chunkHeader.Size = reader.ReadUInt32();
                chunkHeader.Type = reader.ReadUInt16();

                switch (chunkHeader.Type)
                { 
                    case 0xF100:

                        byte[] discard = reader.ReadBytes((int)chunkHeader.Size - 6);
                        break;

                    case 0xF1FA:
                        FlcFrameHeader frame;

                        frame.SubChunkCount = reader.ReadUInt16();
                        frame.Delay = reader.ReadUInt16();
                        frame.Reserved = reader.ReadUInt16();
                        frame.Width = reader.ReadUInt16();
                        frame.Height = reader.ReadUInt16();

                        int bytesRead;
                        ushort packetCount;
                        short value;
                        ushort currentX, currentY, colorIndex;
                        Bitmap bitmap;
                        
                        for (int i = 0; i < frame.SubChunkCount; i++)
                        {
                            subChunkHeader.Size = reader.ReadUInt32();
                            subChunkHeader.Type = reader.ReadUInt16();

                            
                            switch (subChunkHeader.Type)
                            { 
                                case 4:
                                    int currentColor = 0;
                                    ushort skipCount, copyCount;
                                    bytesRead = 8;

                                    packetCount = reader.ReadUInt16();
                               
                                    for (int j = 0; j < packetCount; j++)
                                    {
                                        skipCount = reader.ReadByte();
                                        currentColor += skipCount; 

                                        copyCount = reader.ReadByte();
                                        if (copyCount == 0)
                                            copyCount = 256;

                                        for (int k = 0; k < copyCount; k++)
                                        {
                                            pallete[currentColor] = Color.FromArgb(reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
                                            currentColor++;
                                        }

                                        bytesRead += (2 + 3 * copyCount);
                                    }

                                    if (subChunkHeader.Size != bytesRead)
                                        reader.ReadBytes((int)(subChunkHeader.Size - bytesRead));

                                    break;
                                
                                case 7:
                                    bitmap = new Bitmap(Bitmaps[Bitmaps.Count - 1]);
                                    uint lineCount, opCode, opCodePart;


                                    lineCount = reader.ReadUInt16();
                                    bytesRead = 8;

                                    currentY = 0;
                                    for (int j = 0; j < lineCount; j++)
                                    {
                                        do
                                        {
                                            opCode = reader.ReadUInt16();
                                            opCodePart = opCode >> 14;
                                            bytesRead += 2;

                                            switch (opCodePart)
                                            { 
                                                case 0:
                                                    currentX = 0;
                                                    for (int k = 0; k < opCode; k++)
                                                    {
                                                        skipCount = reader.ReadByte();
                                                        currentX += skipCount;
                                                        bytesRead++;

                                                        value = reader.ReadSByte();
                                                        bytesRead++;

                                                        if (value > 0)
                                                        {
                                                            for (int l = 0; l < value; l++)
                                                            {
                                                                colorIndex = reader.ReadUInt16();

                                                                bitmap.SetPixel(currentX, currentY, pallete[colorIndex & 0xff]);
                                                                currentX++;

                                                                bitmap.SetPixel(currentX, currentY, pallete[colorIndex >> 8]);
                                                                currentX++;
                                                            }
                                                            bytesRead += 2*value;

                                                        }
                                                        else
                                                        {
                                                            value *= -1; 
                                                            colorIndex = reader.ReadUInt16();
                                                            bytesRead += 2;

                                                            for (int l = 0; l < value; l++)
                                                            {
                                                                bitmap.SetPixel(currentX, currentY, pallete[colorIndex & 0xff]);
                                                                currentX++;

                                                                bitmap.SetPixel(currentX, currentY, pallete[colorIndex >> 8]);
                                                                currentX++;
                                                            }
                                                        }

                                                    }

                                                    break;
                                                case 3:

                                                    currentY += (ushort)(-opCode); 
                                                    break;

                                                default:
                                                    throw new Exception("Unsupported opCode.");
                                            }



                                        } while (opCodePart != 0);
                                        currentY++;
                                    }

                                    Bitmaps.Add(bitmap);

                                    if (subChunkHeader.Size != bytesRead)
                                        reader.ReadBytes((int)(subChunkHeader.Size - bytesRead));
                                    
                                    
                                    
                                    break;

                                case 15:
                                    bitmap = new Bitmap(header.Width, header.Height);
                                    bytesRead = 6;
                                    
                                    for (int j = 0; j < bitmap.Height; j++)
                                    {
                                        currentX = 0;
                                        packetCount = reader.ReadByte();
                                        bytesRead++;

                                        for (int k = 0; k < packetCount; k++)
                                        {
                                            value = reader.ReadSByte();
                                            bytesRead++;

                                            if (value < 0)
                                            {
                                                value *= -1;
                                                for (int l = 0; l < value; l++)
                                                {
                                                    colorIndex = reader.ReadByte();
                                                    bitmap.SetPixel(currentX, j, pallete[colorIndex]);
                                                    currentX++;
                                                }
                                                bytesRead += value;
                                            }
                                            else
                                            {
                                                colorIndex = reader.ReadByte();
                                                bytesRead++;

                                                for (int l = 0; l < value; l++)
                                                {
                                                    bitmap.SetPixel(currentX, j, pallete[colorIndex]);
                                                    currentX++;
                                                }
                                            }
                                        
                                        }
                                    }

                                    Bitmaps.Add(bitmap);

                                    if (subChunkHeader.Size != bytesRead)
                                        reader.ReadBytes((int)(subChunkHeader.Size - bytesRead));

                                    break;

                                case 18:
                                    reader.ReadBytes((int)subChunkHeader.Size - 6);

                                    break;

                                default:
                                    throw new Exception("Unsupported FLC subchunk type.");
                            }

                        }


                            break;
                    default:
                        throw new Exception("Unsupported FLC chunk type.");

                
                }


                chunkNumber++;
                
              
            
            }



            reader.Close();
            stream.Close();

            Speed = (int)header.Speed;
        }

        public new static FlcFile Load(CobArchive parent, string fileName)
        {
            return new FlcFile(parent, fileName);
        }
    }
}
