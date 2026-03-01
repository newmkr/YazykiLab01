
namespace lab01;

public class Vectors
{
    public static ArrayVector SumSt(ArrayVector a, ArrayVector b)
    {
        if (a.Length != b.Length) throw new ArgumentException("Невозможно сложить векторы разных размерностей");
        ArrayVector result = a.Clone();
        for (int index = 0; index < result.Length; index++)
        {
            result[index] += b[index];
        }
        return result;
    }

    public static int ScalarSt(ArrayVector a, ArrayVector b)
    {
        if (a.Length != b.Length) throw new ArgumentException("Невозможно вычислить скалярное произведение векторов разных размерностей");
        int result = 0;
        for (int index = 0; index < a.Length; index++)
        {
            result += a[index] * b[index];
        }
        return result;
    }

    public static ArrayVector MultNumberSt(ArrayVector av, int k)
    {
        ArrayVector result = av.Clone();
        for (int index = 0; index < result.Length; index++)
        {
            result[index] *= k;
        }
        return result;
    }

    public static double GetNormSt(ArrayVector av)
    {
        return av.GetNorm();
    }
}
