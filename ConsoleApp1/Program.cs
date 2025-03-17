using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            CE208 counter = new CE208(123, 16, "1234567812345678");
            try
            {
                counter.Autorisation();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            counter.BookTime();
            counter.BookTarifProgramm();
            Console.ReadLine();
        }
    }
}
