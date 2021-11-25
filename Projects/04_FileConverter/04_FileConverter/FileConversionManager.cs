using System;

namespace _04_FileConverter
{
    public static class FileConversionManager
    {
        public static object Convert(object input, string inputFileFormat, string outputFileFormat)
        {
            if (((string)input).IndexOf("png") != -1 && inputFileFormat == "png" && outputFileFormat == "jpg")
            {
                var png2Jpeg = new Png2Jpeg() { InputFileFormat = "png", OutputFileFormat = "jpg" };
                return png2Jpeg.Convert(input);
            }
            else if (((string)input).IndexOf("jpg") != -1 && inputFileFormat == "jpg" && outputFileFormat == "bmp")
            {
                var jpeg2Bmp = new Jpg2Bmp() { InputFileFormat = "jpg", OutputFileFormat = "bmp" };
                return jpeg2Bmp.Convert(input);
            }
            else
            {
                throw new Exception("Input file's format is not look as correct format");
            }
        }
    };
}
