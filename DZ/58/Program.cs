using System;
using static System.Console;

// Функция для заполнения двумерного массива случайными числами в диапазоне от 0 до 10
int[,] GetArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = new Random().Next(0, 11);
            Write($"{array[i, j]} ");
        }
        WriteLine();
    }

    return array;
}

// Функция для умножения двух матриц
int[,] MatrMultiply(int[,] array, int[,] array2)
{
    // Получаем размеры матриц
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int rows2 = array2.GetLength(0);
    int columns2 = array2.GetLength(1);

    // Проверяем, можно ли умножить матрицы
    if (columns != rows2)
    {
        WriteLine("Умножение невозможно");
        return new int[rows, columns2];
    }

    // Инициализируем переменные
    int temp = 0;
    int[,] array_multiply = new int[rows, columns2];

    // Транспонируем вторую матрицу
    int[,] transposedArray = new int[array2.GetLength(1), array2.GetLength(0)];
    for (int i = 0; i < array2.GetLength(1); i++)
    {
        for (int j = 0; j < array2.GetLength(0); j++)
        {
            transposedArray[i, j] = array2[j, i];
        }
    }

    // Вычисляем произведение матриц
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns2; j++)
        {
            temp = 0;
            for (int k = 0; k < columns; k++)
            {
                temp = temp + array[i, k] * transposedArray[j, k];
            }
            array_multiply[i, j] = temp;
        }
    }

    // Выводим результат умножения на экран
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns2; j++)
        {
            Write($"{array_multiply[i, j]} ");
        }
        WriteLine();
    }

    return array_multiply;
}

// Очищаем консоль и запрашиваем у пользователя размеры матриц
Clear();
Write("Введите количество строк и столбцов первой матрицы: ");
int rows = int.Parse(ReadLine());
int columns = int.Parse(ReadLine());
Write("Введите количество строк и столбцов второй матрицы: ");
int rows2 = int.Parse(ReadLine());
int columns2 = int.Parse(ReadLine());

// Создаем первую матрицу и выводим ее на экран
int[,] array = GetArray(rows, columns);
WriteLine();

// Создаем вторую матрицу и выводим ее на экран
int[,] array2 = GetArray(rows2, columns2);
WriteLine();

// Умножаем две матрицы и выводим результат на экран
int[,] array_multiply = MatrMultiply(array, array2);