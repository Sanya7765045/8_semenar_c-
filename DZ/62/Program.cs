using System;
using static System.Console;

class Program
{
    // Функция для создания двумерного массива и заполнения его случайными числами
    static int[,] GetArray(int rows, int columns)
    {
        int[,] array = new int[rows, columns];
        Random random = new Random();

        // Проходим по каждой ячейке массива и заполняем ее случайным числом в диапазоне от 10 до 99
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[i, j] = random.Next(10, 100);
                Write($"{array[i, j]} ");
            }
            WriteLine();
        }

        return array;
    }

    // Функция для преобразования массива в спиральную форму
    static int[,] SpiralFormating(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int[] tempArray = new int[rows * cols]; // Временный одномерный массив для сортировки
        int[,] result = new int[rows, cols]; // Массив в спиральной форме
        int index = 0;

        // Преобразуем двумерный массив в одномерный массив
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                tempArray[index++] = array[i, j];
            }
        }

        Array.Sort(tempArray); // Сортируем значения в одномерном массиве
        int left = 0, right = cols - 1, top = 0, bottom = rows - 1;
        int num = 0; // Начальное значение для заполнения матрицы в спиральной форме

        // Заполняем матрицу в спиральной форме
        while (num < rows * cols)
        {
            // Движение вправо
            for (int i = left; i <= right; i++)
            {
                result[top, i] = tempArray[num++];
            }
            top++;

            // Движение вниз
            for (int i = top; i <= bottom; i++)
            {
                result[i, right] = tempArray[num++];
            }
            right--;

            // Движение влево
            for (int i = right; i >= left; i--)
            {
                result[bottom, i] = tempArray[num++];
            }
            bottom--;

            // Движение вверх
            for (int i = bottom; i >= top; i--)
            {
                result[i, left] = tempArray[num++];
            }
            left++;
        }

        WriteLine("Матрица в спиральной форме:");
        int maxLength = (rows * cols).ToString().Length; // Определяем максимальную длину числа для форматирования вывода

        // Печатаем и возвращаем новую матрицу
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Write($"{result[i, j]:D2} ".PadLeft(maxLength + 1)); // Форматированный вывод чисел с выравниванием
            }
            WriteLine();
        }

        return result;
    }

    static void Main()
    {
        Clear(); // Очищаем консоль
        int rows = 4, cols = 4;
        int[,] array = GetArray(rows, cols); // Создаем массив и заполняем его случайными числами
        WriteLine(); // Печатаем пустую строку для удобочитаемости вывода
        SpiralFormating(array); // Преобразуем массив в спиральную форму и выводим результат
    }
}
