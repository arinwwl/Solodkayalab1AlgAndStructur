using System;
using System.Collections.Generic;

class Program
{
    // Сравнение строк по первым l элементам
    static bool CompareRows(int[] row1, int[] row2, int l)
    {
        for (int i = 0; i < l; i++)
        {
            if (row1[i] < row2[i]) return true;
            if (row1[i] > row2[i]) return false;
        }
        return false;
    }

    // Слияние двух матриц
    static List<int[]> MergeMatrices(List<int[]> A, List<int[]> B, int l)
    {
        int i = 0, j = 0;
        List<int[]> C = new List<int[]>();

        while (i < A.Count && j < B.Count)
        {
            if (CompareRows(A[i], B[j], l))
            {
                C.Add(A[i++]);
            }
            else
            {
                C.Add(B[j++]);
            }
        }

        while (i < A.Count) C.Add(A[i++]);
        while (j < B.Count) C.Add(B[j++]);

        return C;
    }

    // Чтение матрицы с клавиатуры
    static List<int[]> ReadMatrix(string name, int rows, int columns)
    {
        Console.WriteLine($"\nВведите матрицу {name}:");
        List<int[]> matrix = new List<int[]>();

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Строка {i + 1}: ");
            string[] parts = Console.ReadLine().Split(' ');
            int[] row = new int[columns];

            for (int j = 0; j < columns; j++)
            {
                row[j] = int.Parse(parts[j]);
            }

            matrix.Add(row);
        }

        return matrix;
    }

    // Печать матрицы
    static void PrintMatrix(List<int[]> matrix, string name)
    {
        Console.WriteLine($"\nМатрица {name}:");
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    static void Main()
    {
        Console.Write("Введите количество строк матрицы A (m): ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Введите количество строк матрицы B (k): ");
        int k = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите количество первых элементов (l), по которым сортированы строки: ");
        int l = int.Parse(Console.ReadLine());

        var A = ReadMatrix("A", m, n);
        var B = ReadMatrix("B", k, n);

        var C = MergeMatrices(A, B, l);

        PrintMatrix(C, "C (Результат слияния)");
    }
}