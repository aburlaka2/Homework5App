using System;

namespace Homework5App
{
    class Program
    {
        static void Main()
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Эта программа сортирует массивы");
                int size = ArraySize();
                int[] array = new int[size];
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = rnd.Next(0, 99);
                }
                Console.WriteLine("Исходный массив");
                WriteArray(size, array);
                int choice = Choice();
                Console.Clear();
                if (choice == 1)
                {
                    BubbleSort(size, array);
                }
                else if (choice == 2)
                {
                    int first = 0;
                    int last = size - 1;
                    QuickSort(first, last, array);
                    WriteArray(size, array);
                }
                else if (choice == 3)
                {
                    InsertionSort(size, array);
                }
                else if (choice == 4)
                {
                    ShakerSort(size, array);
                }
                repeat = Repeat();
                Console.Clear();
            }
            
        }

        static int ArraySize()
        {
            bool result = false;
            int size=0;
            while (result == false)
            {
                Console.WriteLine("Ввведите размер одномерного массива. Программа сама заполнит его случайными значениями в диапазоне от 0 до 99");
                result = int.TryParse(Console.ReadLine(), out size);
                if (result == false)
                {
                    Console.WriteLine("Вы ввели не число или число с плаващей точкой");
                    continue;
                }
                else if (size < 1 || size > 100)
                {
                    Console.WriteLine("Нужно ввести число в интервале от 1 до 100");
                }
            }
            return size;
        }
        static int Choice()
        {
            bool result2 = false;
            int choice = 0;
            while (result2==false)
            {
                Console.WriteLine("Выберите способ, которым хотите отсортировать массив по размеру");
                Console.WriteLine("");
                Console.WriteLine("1 - 'пузырьковая' сортировка");
                Console.WriteLine("");
                Console.WriteLine("2 - 'быстрая' сорировка");
                Console.WriteLine("");
                Console.WriteLine("3 - сорировка 'вставками'");
                Console.WriteLine("");
                Console.WriteLine("4 - сорировка перемешиванием");
                result2 = int.TryParse(Console.ReadLine(), out choice);
                if (result2)
                {
                    if (choice < 1 || choice > 4)
                    {
                        Console.WriteLine("Нужно ввести число от 1 до 4");
                        result2 = false;
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число или число с плаващей точкой");
                    continue;
                }
            }
            return choice;
        }
        static void WriteArray(int size, int[] array)
        {
            for (int i=0; size > i; i++)
            {
                Console.Write("{0}\t", array[i]);
            }
            Console.WriteLine("");
        }
        static void BubbleSort(int size, int[] array)
        {
            bool check = true;
            while (check)
            {
                int temp;
                check = false;
                for(int i=0; size - 1 > i; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        check = true;
                    }
                }
            }
            WriteArray(size, array);
        }
        static Array QuickSort(int first, int last, int[] array)
        {
            int pivot = array[(last - first) / 2 + first];
            int temp;
            int i = first;
            int j = last;
            while (i <= j)
            {
                while (array[i] < pivot && i<= last) i++;
                while (array[j] > pivot && j >= first) j--;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i;
                    --j;
                }
                if (j > first) QuickSort(first, j, array);
                if (i<last) QuickSort(i, last, array);
            }
            return array;
        }
        static void InsertionSort(int size, int[] array)
        {
            for(int i=0; size>i; i++)
            {
                int key = array[i];
                int j = i;
                int count = 0;
                while ((j > 0) && (array[j - 1] > key))
                {
                    count++;
                    Console.WriteLine(count);
                    int temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                    j--;
                }

                array[j] = key;
            }
            WriteArray(size, array);
        }

        static void ShakerSort(int size, int[] array)
        {
            bool check = true;
            while (check)
            {
                int temp;
                check = false;
                for (int i = 0; size-i > i; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        check = true;
                    }
                }
                for (int i = size-1; size - i < i; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        temp = array[i-1];
                        array[i-1] = array[i];
                        array[i] = temp;
                        check = true;
                    }
                }
            }
            WriteArray(size, array);
        }
        static bool Repeat()
        {
            bool repeat;
            bool repeat2;
            do
            {
                Console.WriteLine("Хотите ли продолжить работу с программой? д/н");
                string repeatchar = Console.ReadLine();
                if (repeatchar == "д")
                {
                    repeat = true;
                    repeat2 = false;
                }
                else if (repeatchar == "н")
                {
                    repeat = false;
                    repeat2 = false;
                }
                else
                {
                    Console.WriteLine("Ответьте 'д' или 'н'");
                    repeat = true;
                    repeat2 = true;
                }
            }
            while (repeat2);
            return repeat;

        }
    }
}
