using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FileConverter
{
    public class Png2Jpeg : IFileConverter
    {
        public string InputFileFormat { get; set; }

        public string OutputFileFormat { get; set; }

        public object Convert(object input)
        {

            if (InputFileFormat == "png" && OutputFileFormat == "jpg")
            {
                return input;
            }
            else
            {
                throw new SystemException($"Input file format must be png and output file format must be jpg");

            }

        }
    }
}
