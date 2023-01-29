Console.Clear();
Console.WriteLine("3. В двумерном массиве заменить элементы, у которых оба индекса чётные на их квадраты");

Console.Write("Введите число m: ");
int m = int.Parse(Console.ReadLine());

Console.Write("Введите число n: ");
int n = int.Parse(Console.ReadLine());

int[,] tstArr = new int[m, n];
Console.WriteLine($"Создан массив {m}x{n}.");
Console.WriteLine("Введите диапазон генерации чисел для заполнения:");

Console.Write("От: ");
int min = int.Parse(Console.ReadLine());

Console.Write("до: ");
int max = int.Parse(Console.ReadLine());

FillRandomArray(tstArr, min, max + 1);
Console.WriteLine($"Массив заполнен рандомными числами от {min} до {max}:");

int[,] actualResult = GetArrSqrElementWithEvenIndex(tstArr);
PrintArray(tstArr, preStr: "Массив: ");
PrintArray(actualResult, preStr: "После замены: ");

void FillRandomArray(int[,] arr, int minVal, int maxVal)
{
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i, j] = new Random().Next(minVal, maxVal);
}

int[,] GetArrSqrElementWithEvenIndex(int[,] arr)
{
    int[,] resultArr = new int[arr.GetLength(0), arr.GetLength(1)];
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            if (i % 2 == 0 && j % 2 == 0) resultArr[i, j] = arr[i, j] * arr[i, j];
            else resultArr[i, j] = arr[i, j];
    return resultArr;
}

void PrintArray(int[,] arr, string preStr = "")
{
    int elementLength = FindMaxElementLengthInArr(arr) + 1;
    Console.WriteLine(preStr);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            PrintNumberToGivenLength(arr[i, j], elementLength);
        Console.WriteLine();
    }
    Console.WriteLine();
}

int FindMaxElementLengthInArr(int[,] arr)
{
    int maxLength = arr[0, 0].ToString().Length;
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            int elementLength = arr[i, j].ToString().Length;
            if (maxLength < elementLength) maxLength = elementLength;
        }
    return maxLength;
}

void PrintNumberToGivenLength(int number, int givenLength)
{
    int spacesLength = givenLength - number.ToString().Length;
    for (int i = 0; i < spacesLength; i++) Console.Write(" ");
    Console.Write(number);
}