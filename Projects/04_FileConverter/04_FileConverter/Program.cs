namespace _04_FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            FileConversionManager.Convert("foo.png", "png", "jpg");
            FileConversionManager.Convert("foo.jpg", "jpg", "bmp");
            FileConversionManager.Convert("foo.bmp", "bmp", "png");
        }
        
    }
}
