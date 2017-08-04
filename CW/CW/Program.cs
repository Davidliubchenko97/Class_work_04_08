using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_work_04_08
{
    abstract class class1
    {
        public string NameFile;
        public string Extension;
        public string Size;
        public void txtFile(string NameFile, string Extension, string Size)
        {
            this.NameFile = NameFile;
            this.Extension = Extension;
            this.Size = Size;
        }
    }
    class TxtFile : class1
    {

        public string Content;
        public void txtFile(string Content)
        {

            this.Content = Content;
        }
    }
    class MoviesFile : class1
    {

        public string Resolution;
        public string Length;
        public void moviesFile(string Resolution, string Length)
        {

            this.Resolution = Resolution;
            this.Length = Length;
        }
    }
    class ImageFile : class1
    {

        public string Resolution;
        public void moviesFile(string Resolution)
        {

            this.Resolution = Resolution;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String text = "Text: file.txt(6B); Some string content Image: img.bmp(19MB); 1920х1080 Text:data.txt(12B); Another string Text:data1.txt(7B); Yet another string Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";
            int howMuchTextFiles = 0, howMuchMovieFiles = 0, howMuchImageFiles = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 't' && text[i + 1] == 'x' && text[i + 2] == 't')
                {
                    howMuchTextFiles++;
                }
                else if (text[i] == 'b' && text[i + 1] == 'm' && text[i + 2] == 'p')
                {
                    howMuchMovieFiles++;
                }
                else if (text[i] == 'm' && text[i + 1] == 'k' && text[i + 2] == 'v')
                {
                    howMuchImageFiles++;
                }
                else if (i == text.Length - 3)
                    break;
            }

            TxtFile[] txtFiles = new TxtFile[howMuchTextFiles];
            MoviesFile[] moviesFiles = new MoviesFile[howMuchMovieFiles];
            ImageFile[] imageFiles = new ImageFile[howMuchImageFiles];
            for (int i = 0, T = 0, M = 0, I = 0; i < text.Length && T < howMuchTextFiles && M < howMuchMovieFiles; i++)
            {
                if (text[i] == 'x' && text[i + 1] == 't' && text[i + 2] == ':')
                {
                    txtFiles[T] = new TxtFile();
                    txtFiles[T].Extension = "txt";
                    for (int j = i + 3; j < text.Length; j++)
                    {
                        if (text[j] != '(')
                        {
                            txtFiles[T].NameFile += text[j];
                        }
                        else
                        {
                            i = j;
                            break;
                        }
                    }
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        if (text[j] != ')')
                        {
                            txtFiles[T].Size += text[j];
                        }
                        else
                        {
                            i = j;
                            break;
                        }
                    }
                    for (int j = i + 2; j < text.Length - 1; j++)
                    {
                        if (j == text.Length - 2)
                            break;
                        if (text[j + 1] != 'T' && text[j + 2] != 'e' || text[j + 1] != 'M' && text[j + 2] != 'o' || text[j + 1] != 'I' && text[j + 2] != 'm')
                        {
                            txtFiles[T].Content += text[j];
                        }
                        else
                        {
                            i = j;
                            break;
                        }
                    }
                    T++;
                }



                if (i == text.Length - 1)
                    break;
            }
            for (int i = 0; i < howMuchTextFiles; i++)
            {
                Console.WriteLine(txtFiles[i].NameFile);
                Console.WriteLine($"        Extension:   { txtFiles[i].Extension}");
                Console.WriteLine($"        Size:        { txtFiles[i].Size}");
                Console.WriteLine($"        Content:     {txtFiles[i].Content}");
                Console.WriteLine();
                Console.WriteLine();
            }


        }
    }
}
/*
 Text:file.txt(6B);Some string content Image:img.bmp(19MB);1920x1080 Text:data.txt(12B);Another string Text:data1.txt(7B);Yet another string Movie:logan.2017.mkv(19GB);1920x1080;2h12m
*/
