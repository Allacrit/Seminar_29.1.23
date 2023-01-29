Console.Clear();
Console.WriteLine("В матрице чисел найти сумму элементов главной диагонали");

Console.Write("Введите число m: ");
int m = int.Parse(Console.ReadLine());

Console.Write("Введите число n: ");
int n = int.Parse(Console.ReadLine());

int[,] tstArray = new int[m, n];

Console.WriteLine($"Создан массив {m}x{n}.");
Console.WriteLine("Введите диапазон генерации чисел для заполнения:");

Console.Write("От: ");
int min = int.Parse(Console.ReadLine());

Console.Write("до: ");
int max = int.Parse(Console.ReadLine());
CreateArray(tstArray, min, max);
Console.WriteLine($"Массив заполнен рандомными числами от {min} до {max}:");
PrintArray(tstArray);
SumDiagonals(tstArray);



void CreateArray(int[,] createArray, int minVal, int maxVal)
{
    for (int j = 0; j <= createArray.GetUpperBound(1); j++)
        for (int i = 0; i <= createArray.GetUpperBound(0); i++)
            createArray[i, j] = new Random().Next(minVal, maxVal);
}

void PrintArray(int[,] arr)
{
    int stringLength = FindMaxVarLengthInArr(arr) + 1;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            PrintVarToLength(arr[i, j], stringLength);
        Console.WriteLine();
    }
    Console.WriteLine();
}

int FindMaxVarLengthInArr(int[,] arr)
{
    int maxLen = arr[0, 0].ToString().Length;
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            int curLen = arr[i, j].ToString().Length;
            if (maxLen < curLen) maxLen = curLen;
        }
    return maxLen;
}

void PrintVarToLength(int var, int length)
{
    int spacesLength = length - var.ToString().Length;
    for (int i = 0; i < spacesLength; i++) Console.Write(" ");
    Console.Write(var);
}

void SumDiagonals(int[,] array)
{
    int sum = 0;
    if (array.GetUpperBound(0) < array.GetUpperBound(1))
        for (int i = 0; i <= array.GetUpperBound(0); i++)
            sum += array[i, i];
    else
        for (int i = 0; i <= array.GetUpperBound(1); i++)
            sum += array[i, i];

    Console.WriteLine($"Сумма элементов главной диагонали равна {sum}.");
}