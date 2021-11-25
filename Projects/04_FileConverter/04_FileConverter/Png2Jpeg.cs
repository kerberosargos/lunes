using System;

namespace _04_FileConverter
{
    public class Jpg2Bmp : IFileConverter
    {
        public string InputFileFormat { get; set; } 

        public string OutputFileFormat { get; set; }

        public object Convert(object input)
        {

            if (InputFileFormat == "jpg" && OutputFileFormat == "bmp")
            {
                return input;
            }
            else
            {
                throw new SystemException($"Input file format must be jpg and output file format must be bmp");

            }

        }
    }
}
