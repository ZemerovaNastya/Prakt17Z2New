using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Prakt17Z2New
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во элементов массива:");
            try
            {
                int N = Convert.ToInt32(Console.ReadLine());
                if (N <= 0)
                {
                    Console.WriteLine("кол-во элементов должно быть больше 0");
                }
                else
                {
                    string[] mas = new string[N];
                    string str = "";
                    bool flag = true;
                    List<string> list = new List<string>();
                    for (int i = 0; i < mas.Length; i++)
                    {
                        Console.WriteLine($"Введите {i + 1} строку");
                        mas[i] = Console.ReadLine();
                        if (mas[i] == "" || mas[i] == " ")
                        {
                            Console.WriteLine("Пустая строка!");
                            flag = false;
                            break;
                        }
                        str = mas[i];
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("Дальнейшее задание не может быть выполнено!");
                    }
                    else
                    {
                        Console.WriteLine("---Задание А---");

                        int s = 1;
                        var count = 0;
                        var kol = 0;
                        foreach (string st in mas)
                        {
                            int[] mas2 = st.Where(Char.IsDigit).Select(x => int.Parse(x.ToString())).ToArray();
                            count = st.Where(Char.IsDigit).Select(x => int.Parse(x.ToString())).Count();
                            kol += count;
                            Console.WriteLine($"Строка {s}: " + string.Join(" ", mas2));
                            s++;
                        }
                        Console.WriteLine("Кол-во чисел в массиве: " + kol);

                        Console.WriteLine("---Задание Б---");

                        IEnumerable<string> str2 = mas.TakeWhile(x => String.Compare("/", x, true) != 0);
                        foreach (var item in str2)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("---Задание В---");

                        IEnumerable<string> str3 = mas.SkipWhile(x => String.Compare("/", x, true) != 0);
                        int l = 0;
                        string[] mas3 = new string[str3.Count()];
                        foreach (var item in str3)
                        {
                            string s1 = item;
                            if (s1 != s1.ToUpper())
                            {
                                mas3[l] = s1.ToUpper();
                                l++;
                                Console.WriteLine(s1.ToUpper());
                            }
                            else if (s1 != s1.ToLower())
                            {
                                mas3[l] = s1.ToLower();
                                l++;
                                Console.WriteLine(s1.ToLower());
                            }
                        }
                        StreamWriter sw = new StreamWriter("file1.txt");
                        for (int i = 0; i < mas3.Length; i++)
                        {
                            sw.WriteLine(mas3[i] + " ");
                        }
                        sw.Close();
                    }
                }
            }
            catch { Console.WriteLine("Неправильный тип данных!"); }
        }
    }
}
