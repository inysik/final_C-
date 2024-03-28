using System;

namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            // Решение задачи 64
            int numN = 5;
            Console.WriteLine(EvenNumbers(numN));

            // Решение задачи 66
            int numM = 1, numN2 = 15;
            Console.WriteLine(SumNaturalNumbers(numM, numN2));

            // Решение задачи 68
            int numM2 = 2, numN3 = 3;
            Console.WriteLine(Ackermann(numM2, numN3));
        }

        // Решение задачи 64
        static string EvenNumbers(int N)
        {
            if (N <= 0)
            {
                return "";
            }
            else
            {
                if (N % 2 == 0)
                {
                    return N + (N == 2 ? "" : ", ") + EvenNumbers(N - 2);
                }
                else
                {
                    return EvenNumbers(N - 1);
                }
            }
        }

        // Решение задачи 66
        static int SumNaturalNumbers(int M, int N)
        {
            if (M > N)
            {
                return 0;
            }
            else
            {
                return M + SumNaturalNumbers(M + 1, N);
            }
        }

        // Решение задачи 68
        static int Ackermann(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if (m > 0 && n == 0)
            {
                return Ackermann(m - 1, 1);
            }
            else
            {
                return Ackermann(m - 1, Ackermann(m, n - 1));
            }
        }
    }
}


// Задача 54: Упорядочивание элементов каждой строки по убыванию
// csharp
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[,] array = {
            { 1, 4, 7, 2 },
            { 5, 9, 2, 3 },
            { 8, 4, 2, 4 }
        };

        OrderRowsDescending(array);
    }

    static void OrderRowsDescending(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            var row = array.Cast<int>().Skip(i * array.GetLength(1)).Take(array.GetLength(1)).OrderByDescending(x => x).ToArray();
            Console.WriteLine(string.Join(" ", row));
        }
    }
}
// Задача 56: Поиск строки с наименьшей суммой элементов
// csharp
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[,] array = {
            { 1, 4, 7, 2 },
            { 5, 9, 2, 3 },
            { 8, 4, 2, 4 },
            { 5, 2, 6, 7 }
        };

        FindRowWithMinSum(array);
    }

    static void FindRowWithMinSum(int[,] array)
    {
        int minSum = int.MaxValue;
        int minRow = -1;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            int sum = array.Cast<int>().Skip(i * array.GetLength(1)).Take(array.GetLength(1)).Sum();
            if (sum < minSum)
            {
                minSum = sum;
                minRow = i;
            }
        }

        Console.WriteLine($"Строка с наименьшей суммой элементов: {minRow + 1}");
    }
}



// Задача 58: Нахождение произведения двух матриц

using System;

class Program
{
    static void Main()
    {
        int[,] matrix1 = {
            { 2, 4 },
            { 3, 2 }
        };

        int[,] matrix2 = {
            { 3, 4 },
            { 3, 3 }
        };

        MultiplyMatrices(matrix1, matrix2);
    }

    static void MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        // Вывод результирующей матрицы
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

// Задача 60: Формирование трехмерного массива и вывод с индексами

using System;

class Program
{
    static void Main()
    {
        int[,,] array = {
            { { 66, 25 }, { 34, 41 } },
            { { 27, 90 }, { 26, 55 } }
        };

        Print3DArrayWithIndices(array);
    }

    static void Print3DArrayWithIndices(int[,,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
                }
                Console.WriteLine();
            }
        }
    }
}
// Задача 62: Заполнение массива спирально

using System;

class Program
{
    static void Main()
    {
        int n = 4;
        int[,] spiralArray = FillSpiralArray(n);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{spiralArray[i, j]:D2} ");
            }
            Console.WriteLine();
        }
    }

    static int[,] FillSpiralArray(int n)
    {
        int[,] spiral = new int[n, n];
        int value = 1;
        int minRow = 0, minCol = 0, maxRow = n - 1, maxCol = n - 1;

        while (value <= n * n)
        {
            for (int i = minCol; i <= maxCol; i++)
            {
                spiral[minRow, i] = value++;
            }
            minRow++;

            for (int i = minRow; i <= maxRow; i++)
            {
                spiral[i, maxCol] = value++;
            }
            maxCol--;

            for (int i = maxCol; i >= minCol; i--)
            {
                spiral[maxRow, i] = value++;
            }
            maxRow--;

            for (int i = maxRow; i >= minRow; i--)
            {
                spiral[i, minCol] = value++;
            }
            minCol++;
        }

        return spiral;
    }
}