int[] SingleLineInput(int reqSizeArray)
{
    int[] array;
    System.Console.WriteLine("Enter single line array with a \"space\"");
    do
    {
        array = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
        if (array.Length != reqSizeArray)
        {
            System.Console.WriteLine("Wrong enter, please try again");
        }
    } while (array.Length != reqSizeArray);
    return array;
}

void PrintMatrix(int[,] matrix)
{
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        for (int columns = 0; columns < matrix.GetLength(1); columns++)
        {
            System.Console.Write($"{matrix[rows, columns]} \t");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

void FillMatrix(int[,] matrix, int min, int max)
{
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        for (int columns = 0; columns < matrix.GetLength(1); columns++)
        {
            matrix[rows, columns] = new Random().Next(min, max + 1);
        }
    }
}

int[,] CreateUserMatrix()
{
    System.Console.WriteLine("Enter size matrix");
    int[] size = SingleLineInput(2);
    return new int[size[0], size[1]];
}

void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(", ", array)}]");
}

int FindMinPosArray(int[] array)
{
    int min = array[0], minPos = 0; ;
    for (int i = 1; i < array.Length; i++)
    {
        if (min > array[i])
        {
            min = array[i];
            minPos = i;
        }
    }
    return minPos;
}

bool CheckSizeMaxtrix(int[,] matrix)
{
    return matrix.GetLength(0) == matrix.GetLength(1);
}

int[] ReleaseMatrix(int[,] matrix)
{
    int numRows = matrix.GetLength(0);
    int numColumns = matrix.GetLength(1);
    int[] rowsSum = new int[numRows];
    int[] resultArray = new int[numColumns];

    for (int rows = 0; rows < numRows; rows++)
    {
        for (int columns = 0; columns < numColumns; columns++)
        {
            rowsSum[rows] += matrix[rows, columns];
        }
    }
    System.Console.Write("All rows sum: ");
    PrintArray(rowsSum);

    int minSumRowsPos = FindMinPosArray(rowsSum);
    for (int i = 0; i < numColumns; i++)
    {
        resultArray[i] = matrix[minSumRowsPos, i];
    }
    return resultArray;
}

System.Console.Clear();
int[,] matrix = CreateUserMatrix();
if (CheckSizeMaxtrix(matrix))
{
    System.Console.WriteLine("Matrix is square");
}
else
{
    FillMatrix(matrix, 1, 10);
    PrintMatrix(matrix);
    int[] rowSmallestSum = ReleaseMatrix(matrix);
    System.Console.Write("Row with the smallest sum: ");
    PrintArray(rowSmallestSum);
}
