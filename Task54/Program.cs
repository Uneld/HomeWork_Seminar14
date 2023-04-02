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

void SwapElement(int e1, int e2)
{
    int temp = e1;
    e1 = e2;
    e2 = temp;
}

//Вариант 1
void ReleaseMatrix1(int[,] matrix)
{
    int numColumns = matrix.GetLength(1);
    int[] tempArray = new int[numColumns];

    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        for (int columns = 0; columns < numColumns; columns++)
        {
            tempArray[columns] = matrix[rows, columns];
        }
        Array.Sort(tempArray);
        Array.Reverse(tempArray);
        for (int columns = 0; columns < numColumns; columns++)
        {
            matrix[rows, columns] = tempArray[columns];
        }
    }
}

//Вариант 2
void ReleaseMatrix2(int[,] matrix)
{
    int numColumns = matrix.GetLength(1);
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        for (int i = 1; i < numColumns; i++)
        {
            for (int j = 0; j < numColumns - i; j++)
            {
                if (matrix[rows, j] < matrix[rows, j + 1])
                {
                    SwapElement(matrix[rows, j], matrix[rows, j + 1]);
                }
            }
        }
    }
}

System.Console.Clear();
int[,] matrix = CreateUserMatrix();
FillMatrix(matrix, 1, 10);
PrintMatrix(matrix);
System.Console.WriteLine("Вариант 1");
ReleaseMatrix1(matrix);
PrintMatrix(matrix);
System.Console.WriteLine();
System.Console.WriteLine("Вариант 2");
ReleaseMatrix2(matrix);
PrintMatrix(matrix);