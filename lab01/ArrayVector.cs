
using System.Text; // Stringbuilder

namespace lab01;

public class ArrayVector
{
	private int[] coordinates;

	public int Length
	{
		get
		{
			return coordinates.Length;
		}
	}

	public ArrayVector(int length)
	{
		if (length < 1) throw new ArgumentException("Размерность вектора должна быть натуральным числом");
		coordinates = new int[length];
	}

	public ArrayVector() : this(5) { } // No parameters, size 5

	public ArrayVector(int[] values)
	{
		if (values.Length < 1) throw new ArgumentException("Размерность вектора должна быть натуральным числом");
		coordinates = (int[])values.Clone();
	}

	public int this[int index] // System.IndexOutOfRangeException is possible
	{
		get
		{
			return coordinates[index];
		}
		set
		{
			coordinates[index] = value;
		}
	}

	/*
		public int GetElement(int index)
		{
			return this[index];
		}

		public void SetElement(int index, int value)
		{
			this[index] = value;
		}
	*/

	public double GetNorm()
	{
		if (coordinates.Length == 0)
		{
			throw new InvalidOperationException("Нельзя вычислить нормаль вектора с нулём измерений");
		}
		int squareSum = 0;
		foreach (int coordinate in coordinates)
		{
			squareSum += coordinate * coordinate;
		}
		return Math.Sqrt(squareSum);
	}

	public (int result, bool foundAnyElements) SumPositivesFromChetIndex() // Спасибо Тамаре за введение в кортежи
	{
		if (coordinates.Length == 0)
		{
			throw new InvalidOperationException("Невозможно сложить элементы вектора с нулём измерений");
		}
		int sum = 0;
		bool foundAnyElements = false;
		for (int index = 1; index < coordinates.Length; index += 2) //Indeces must be 1-based for the end user, therefore the index = 1 starting point.
		{
			int value = coordinates[index];
			if (value > 0)
			{
				sum += value;
				foundAnyElements = true;
			}
		}
		return (sum, foundAnyElements);
	}

	public (int result, bool foundAnyElements) SumLessFromNechetIndex()
	{
		if (coordinates.Length == 0)
		{
			throw new InvalidOperationException("Невозможно сложить элементы вектора с нулём измерений");
		}
		int sum = 0;
		bool foundAnyElements = false;
		double upperBound = GetAverageAbsoluteCoordinate();
		for (int index = 0; index < coordinates.Length; index += 2) //Indeces must be 1-based for the end user, therefore the index = 1 starting point.
		{
			int value = coordinates[index];
			if (value < upperBound)
			{
				sum += value;
				foundAnyElements = true;
			}
		}
		return (sum, foundAnyElements);
	}

	private double GetAverageAbsoluteCoordinate()
	{
		if (coordinates.Length == 0) throw new DivideByZeroException("Невозможно вычислеть среднее значение для вектора с нулём измерений");
		int sum = 0;
		foreach (int coordinate in coordinates)
		{
			sum += Math.Abs(coordinate);
		}
		return (double)sum / coordinates.Length;
	}

	public int MultChet()
	{
		if (coordinates.Length < 2)
		{
			throw new InvalidOperationException("Недостаточно измерений для выполнения операции перемножения четных элементов");
		}
		int product = 1;
		foreach (int coordinate in coordinates)
		{
			if (coordinate % 2 == 0)
			{
				product *= coordinate;
			}
		}
		return product;
	}

	public int MultNechet()
	{
		if (coordinates.Length == 0)
		{
			throw new InvalidOperationException("Невозможно перемножить элементы вектора с нулём измерений");
		}
		int product = 1;
		foreach (int coordinate in coordinates)
		{
			if (coordinate % 2 != 0 && coordinate % 3 != 0)
			{
				product *= coordinate;
			}
		}
		return product;
	}

	public void SortUp()
	{
		Array.Sort(coordinates);
	}

	public void SortDown()
	{
		SortUp();
		Array.Reverse(coordinates);
	}

	public ArrayVector Clone()
	{
		return new ArrayVector(coordinates);
	}

	public override string ToString()
	{
		if (Length == 0)
		{
			return "[Вектор с нулём измерений]";
		}
		StringBuilder result = new StringBuilder("");
		for (int index = 0; index < Length; index++)
		{
			result.Append(index + 1);
			result.Append(": ");
			result.Append(this[index]);
			result.Append("; ");
		}
		return result.ToString();
	}

	public void Print()
	{
		Console.WriteLine(ToString());
	}

}
