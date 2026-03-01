
namespace lab01;

public class Program
{
    public static void Main()
    {
        int menuOption = 1;
        while (menuOption != 2)
        {
            ArrayVector a, b;
            int k;
            Console.WriteLine("Лабораторная работа №1. Выполнил студент группы 6104-020302D Круглов Данил.");
            Console.WriteLine("Вектор А будет использоваться для всех операций с векторами.\nВведите координаты вектора А - целые числа через пробел (например: (-1 67 420 -1337))");
            a = ReadArrayVector();
            Console.WriteLine("Вектор B будет использоваться для всех операций с векторами, требующих два вектора.\nВведите координаты вектора B - целые числа через пробел (например: (-1 67 420 -1337))");
            b = ReadArrayVector();
            Console.WriteLine("Число K будет использоваться для всех операций, требующих целое число.\nВведите К - целое число");
            k = ReadInt();
            Console.WriteLine("\nПроверка разработанных членов класса ArrayVector:");
            Console.WriteLine("Метод Print - с использованием метода ToString - с использованием индексатора");
            Console.WriteLine("A:");
            a.Print();
            Console.WriteLine("B:");
            b.Print();
            Console.WriteLine("Метод GetNorm (A):");
            Console.WriteLine(a.GetNorm());
            Console.WriteLine("Метод SumPositivesFromChetIndex (A):");
            try
            {
                (int result, bool foundAnyElements) = a.SumPositivesFromChetIndex();
                Console.WriteLine(result);
                if (!foundAnyElements) Console.WriteLine("(!)Не было найдено подходящих элементов для сложения, возвращен ноль");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Произошла ошибка - неверная операция: " + e.Message);
            }
            Console.WriteLine("Метод SumLessFromNechetIndex - с использованием вспомогательного метода GetAverageAbsoluteCoordinate (A):");
            try
            {
                (int result, bool foundAnyElements) = a.SumLessFromNechetIndex();
                Console.WriteLine(result);
                if (!foundAnyElements) Console.WriteLine("(!)Не было найдено подходящих элементов для сложения, возвращен ноль");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Произошла ошибка - неверная операция: " + e.Message);
            }
            Console.WriteLine("Метод MultChet (A):");
            try
            {
                Console.WriteLine(a.MultChet());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Произошла ошибка - неверная операция: " + e.Message);
            }
            Console.WriteLine("Метод MultNechet (A):");
            try
            {
                Console.WriteLine(a.MultNechet());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Произошла ошибка - неверная операция: " + e.Message);
            }
            ArrayVector prev_a = a.Clone();
            Console.WriteLine("Вызван метод SortUp, затем Print (A):");
            a.SortUp();
            a.Print();
            Console.WriteLine("Вызван метод SortDown, затем Print (A):");
            a.SortDown();
            a.Print();
            Console.WriteLine("(A будет приведён в прежний вид)");
            a = prev_a.Clone();
            Console.WriteLine("\nПроверка разработанных членов класса Vectors:");
            Console.WriteLine("Метод SumSt (A, B):");
            try
            {
                Vectors.SumSt(a, b).Print();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Произошла ошибка аргумента: " + e.Message);
            }
            Console.WriteLine("Метод ScalarSt (A, B):");
            try
            {
                Console.WriteLine(Vectors.ScalarSt(a, b));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Произошла ошибка аргумента: " + e.Message);
            }
            Console.WriteLine("Метод MultNumberSt (A, K):");
            Vectors.MultNumberSt(a, k).Print();
            Console.WriteLine("(A будет приведён в прежний вид)");
            a = prev_a.Clone();
            Console.WriteLine("Метод GetNormSt (A):");
            Console.WriteLine(Vectors.GetNormSt(a));
            Console.WriteLine("Демонстрация завершена. Выберите опцию:\n1 - Начать заново\n2 - Завершить работу");
            menuOption = GetOption(1, 2);
        }
    }

    private static ArrayVector ReadArrayVector()
    {
        // Подход с флажком success привёл к жалующемуся компилятору, поэтому через цикл с return точкой выхода
        while (true)
        {
            try
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ввод не модет быть пустым. Попробуйте снова");
                }
                else
                {
                    string[] coordinates_string = input.Trim().Split(" ");
                    int[] coordinates = new int[coordinates_string.Length];
                    for (int index = 0; index < coordinates.Length; index++)
                    {
                        coordinates[index] = Convert.ToInt32(coordinates_string[index]);
                    }
                    ArrayVector result = new ArrayVector(coordinates);
                    return result;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Произошла ошибка аргумента, попробуйте снова: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Произошла ошибка формата, попробуйте снова: " + e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Число выходит за допустимый диапазон, попробуйте снова: " + e.Message);
            }
        }
    }

    private static int ReadInt()
    {
        while (true)
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Произошла ошибка формата, попробуйте снова: " + e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Число выходит за допустимый диапазон, попробуйте снова: " + e.Message);
            }
        }
    }

    private static int GetOption(int lowerBound, int upperBound)
    {
        while (true)
        {
            int option = ReadInt();
            if (option < lowerBound || option > upperBound)
            {
                Console.WriteLine("Введите число между " + lowerBound.ToString() + " и " + upperBound.ToString());
            }
            else
            {
                return option;
            }
        }
    }
}