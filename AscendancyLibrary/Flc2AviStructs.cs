public struct FlcHeader
{
    public uint FileSize;
    public ushort Type;

    public ushort FrameCount;
    public ushort Width;
    public ushort Height;
    public ushort Depth;
    
    public ushort Flags;
    public uint Speed;
    public ushort Reserved1;

    public uint Created;
    public uint Creator;
    public uint Updated;
    public uint Updater;
    public ushort Aspect_dx;
    public ushort Aspect_dy;

    public ushort ExtFlags;
    public ushort KeyFrames;
    public ushort TotalFrames;
    public uint ReqMemory;
    public ushort MaxRegions;
    public ushort TransparentCount;

    public byte[] Reserved2;
    public uint Frame1Offset;
    public uint Frame2Offset;
    public byte[] Reserved3;
}

public struct FlcChunkHeader
{
    public uint Size;
    public ushort Type;
}

public struct FlcFrameHeader
{ 
    public ushort SubChunkCount;
    public ushort Delay;
    public ushort Reserved;
    public ushort Width;
    public ushort Height;
}
