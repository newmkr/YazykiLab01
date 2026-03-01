
using System.Net.WebSockets;

namespace lab01;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Лабораторная работа №1. Выполнил студент группы 6104-020302D Круглов Данил.");
        Console.WriteLine("Вектор А будет использоваться для всех операций с векторами.\nВведите координаты вектора А - целые числа через пробел (например: (-1 67 420 -1337))");
        ArrayVector a = ReadArrayVector();
        Console.WriteLine("Вектор B будет использоваться для всех операций с векторами, требующих два вектора.\nВведите координаты вектора B - целые числа через пробел (например: (-1 67 420 -1337))");
        ArrayVector b = ReadArrayVector();
        Console.WriteLine("Число K будет использоваться для всех операций, требующих целое число.\nВведите К - целое число");
        int k = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine("Произошла ошибка неверной операции: " + e.Message);
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
            Console.WriteLine("Произошла ошибка неверной операции: " + e.Message);
        }
        Console.WriteLine("Метод MultChet (A):");
        Console.WriteLine(a.MultChet());
        Console.WriteLine("Метод MultNechet (A):");
        Console.WriteLine(a.MultNechet());
        ArrayVector prev_a = a.Clone();
        Console.WriteLine("Вызван метод SortUp, затем Print (A):");
        a.SortUp();
        a.Print();
        Console.WriteLine("Вызван метод SortDown, затем Print (A):");
        a.SortDown();
        a.Print();
        Console.WriteLine("(A Приведён в прежний вид)");
        a = prev_a;
        Console.WriteLine("\nПроверка разработанных членов класса Vectors:");
        Console.WriteLine("Метод SumSt (A, B):");
        Vectors.SumSt(a, b).Print();
        Console.WriteLine("Метод ScalarSt (A, B):");
        Console.WriteLine(Vectors.ScalarSt(a, b));
        Console.WriteLine("Метод MultNumberSt (A, K):");
        Vectors.MultNumberSt(a, k).Print();
        Console.WriteLine("Метод GetNormSt (A):");
        Console.WriteLine(Vectors.GetNormSt(a));


    }

    private static ArrayVector ReadArrayVector()
    {
        // Подход с флажком success привёл к жалующемуся компилятору, поэтому через цикл с return точкой выхода
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] coordinates_string = input.Split(" ");
                int[] coordinates = new int[coordinates_string.Length];
                for (int index = 0; index < coordinates.Length; index++)
                {
                    coordinates[index] = Convert.ToInt32(coordinates_string[index]);
                }
                ArrayVector result = new ArrayVector(coordinates);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка, попробуйте снова: " + e.Message);
            }
        }
    }
}