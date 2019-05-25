using System;

namespace try_02_SpartaPaint
{
    // information about the type, size, and layout of a file
    // https://msdn.microsoft.com/en-us/library/dd183374(v=vs.85).aspx
    public class BitmapFileHeader
    {
        public Byte bfType1;
        public Byte bfType2;
        public UInt32 bfSize;
        public UInt16 bfReserved1;
        public UInt16 bfReserved2;
        public UInt32 bfOffBits;
    }

    // information about the dimensions and color format
    // https://msdn.microsoft.com/en-us/library/dd183376(v=vs.85).aspx
    public class BitmapInfoHeader
    {
        public UInt32 biSize;
        public Int32 biWidth;
        public Int32 biHeight;
        public UInt16 biPlanes;
        public UInt16 biBitCount;
        public UInt32 biCompression;
        public UInt32 biSizeImage;
        public Int32 biXPelsPerMeter;
        public Int32 biYPelsPerMeter;
        public UInt32 biClrUsed;
        public UInt32 biClrImportant;
    }

    // relative intensities of red, green, and blue
    // https://msdn.microsoft.com/en-us/library/dd162939(v=vs.85).aspx
    public class RGBTriple
    {
        public Byte rgbtBlue;
        public Byte rgbtGreen;
        public Byte rgbtRed;

        public static int Size { get { return 3; } }
    }

    public class BitMap
    {
        public BitmapFileHeader bf;
        public BitmapInfoHeader bi;
        public RGBTriple[] pixelmap;
    }
}
