using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string path = @Console.ReadLine();   // путь к файлу // блакнотик лежить в файле проги () //C:\Users\User\source\repos\Task4\Task4\note.txt пример пути
            //string path = @"C:\Users\User\source\repos\Task4\Task4\note.txt";   // пример


            string text = "12 5 6 33"; // строка для записи // 

            // запись в файл
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                //Console.WriteLine("Текст записан в файл");
                
            }

            // чтение из файла
            using (FileStream fstream = File.OpenRead(path))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine($"Текст из файла: {textFromFile}");
                

                string[] str = textFromFile.Split();
                string new_int = "";
                int[] arr = new int[str.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Convert.ToInt32( str[i]);
                    new_int += arr[i].ToString();
                }

                int[] mass = new int[arr.Length]; 

                for (int i = 0; i < arr.Length; i++)
                {
                    mass[i] = Program.counting(i, arr);
                    //Console.WriteLine(mass[i]);
                }
                Console.WriteLine("Ответ: " + mass.Min());
                Console.ReadKey();


            }
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate)) // Раскаментить если нужно удалить данные из файла или наоборот закаментить ести нужно оставить их в файле 
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                fstream.SetLength(0);
            }
        }
        public static int counting(int k, int[] arr)
        {
            int path1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[k] - arr[i] < 0)
                {
                    path1 += ((-1) * (arr[k] - arr[i]));
                }
                else
                {
                    path1 += arr[k] - arr[i];
                }
            }
            return path1;
        }
    }
}
