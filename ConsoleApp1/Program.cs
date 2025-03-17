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

        abstract class Counter
        {
            public int[,] tarifdata;
            protected int Number_of_tarif;
            public string datatime;
            public int Serialnumber;
            public int Adress;
            public string Password;

            protected Counter(int serialnumber, int adress, string password, int number_of_tarif) {
                this.Number_of_tarif = number_of_tarif;
                this.Serialnumber = serialnumber;
                this.Adress = adress;
                this.Password = password;
                this.tarifdata = new int[this.Number_of_tarif, 2];
            }
        
            public void Autorisation()
            {
                Thread.Sleep(3000);
                Console.Write("Введите адресс: ");
                if (Console.ReadLine() == this.Adress.ToString())
                {
                    Console.WriteLine("Адрес совпадает!");
                    Console.Write("Введите пароль: ");
                    if (Console.ReadLine() == this.Password.ToString())
                    {
                        Console.WriteLine("И пароль совпадает!");
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("Ошибка авторизации: неверный пароль.");
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("Ошибка авторизации: неверный адрес.");
                }
                
            }
            public string ReadTime()
            {
                DateTime now = DateTime.Now;
                string formated_now = now.ToString("dd.MM.yyyy HH:mm:ss");
                Console.WriteLine($"Считанное время с ПК: ({formated_now})");
                return formated_now;
            } 

            public void BookTime()
            {
                datatime = ReadTime();
            }

            public void BookTarifProgramm()
            {
                for (int i = 0; i < this.Number_of_tarif; i++)
                {
                    this.tarifdata[i, 0] = i+1;
                    Console.WriteLine($"Введите время начала тарифа под номером ({i+1})");
                    this.tarifdata[i, 1] = int.Parse(Console.ReadLine());

                }
                for (int i = 0; i < this.Number_of_tarif; i++)
                    Console.WriteLine($"Тариф {this.tarifdata[i, 0]} начинается в {this.tarifdata[i, 1]}");


            }

        }
        class CE207 : Counter
        {
            
            public CE207(int serialnumber, int adress, string password) : base(serialnumber, adress, password, 4) { }
           
        }

        class CE208 : Counter
        {
            public CE208(int serialnumber, int adress, string password) : base(serialnumber, adress, password, 8) { }
 
        }


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
