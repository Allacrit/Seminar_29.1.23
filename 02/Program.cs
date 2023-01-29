Console.Clear();
Console.WriteLine("2. Задать двумерный массив следующим правилом: Amn = m+n");

Console.Write("Введите число m: ");
int m = int.Parse(Console.ReadLine());

Console.Write("Введите число n: ");
int n = int.Parse(Console.ReadLine());

int[,] tstArr = new int[m, n];
Console.WriteLine($"Создан массив {m}x{n}.");
Console.WriteLine("Введите диапазон генерации чисел для заполнения:");

FillArray(tstArr);

PrintArray(tstArr);

void FillArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i, j] = i + j;
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