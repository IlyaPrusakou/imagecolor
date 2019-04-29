using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
 

namespace ConsoleApplication1
{
    abstract class Printer
    {
        public string Rgb { get; set; }
        public Printer()
        {

        }
        public abstract void Print(string str, ConsoleColor col);
        public void SetColor(string rgb)
        {
            Rgb = rgb;
        }
    }

    class ConsolePrinter : Printer
    {
        ConsoleColor color { get; set; }
        public ConsolePrinter(ConsoleColor col)

        {
            color = col;
        }
        public override void Print(string str, ConsoleColor col)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(str);

        }
    }

    class FilePrinter : Printer
    {
        string Path { get; set; }
        public FilePrinter(string filename)
        {
            Path = filename;
        }
        public override void Print(string path, ConsoleColor col)
        {
            Console.WriteLine("fileprint");
        }
    }
    class ImagePrinter : Printer
    {
        public override void Print(string str, ConsoleColor col)
        {
            Image bitmap = new Bitmap(); 
        }
    }


    class Program
    {
        public static Printer PrintFabric(string str)
        {
            switch (str)
            {
                case "a":
                    return new ConsolePrinter(ConsoleColor.Blue);
                    break;
                case "s":
                    return new ImagePrinter();
                    break;
                case "d":

                    return new FilePrinter("file txt");
                    break;

            }
            throw new ApplicationException();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("input string");
                string d = Console.ReadLine();
                Console.WriteLine("type of print");
                string strres = Console.ReadLine();
                var Print = PrintFabric("a");
            }






            Console.ReadLine();
        }
    }
}
