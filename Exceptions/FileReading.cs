using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exceptions
{
    internal class FileReading
    {


        public void FileRead(string path)
        {
            try
            {
                string readText = File.ReadAllText(path);
                Console.WriteLine(readText);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"{e.ToString()}\nFile not found ,create a new empty file");
                string[] text = { string.Empty };
                File.WriteAllLines(path, text, Encoding.UTF8);
            }
            catch (ArgumentNullException e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }
            catch (PathTooLongException e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }
            catch (DirectoryNotFoundException e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }
            catch (UnauthorizedAccessException e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }
            catch (ArgumentOutOfRangeException e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }
            catch (NotSupportedException e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }
            catch (IOException e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }
            catch (Exception e) { Console.WriteLine("Erro occured while reading the file" + e.ToString()); }






        }




    }
}
