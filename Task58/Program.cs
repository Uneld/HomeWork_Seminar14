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
    int[] size = SingleLineInput(2);
    return new int[size[0], size[1]];
}


bool CheckMultiplyMatrix(int[,] matrixA, int[,] matrixB)
{
    return matrixA.GetLength(1) != matrixB.GetLength(0);
}

int[,] ReleaseMatrix(int[,] matrixA, int[,] matrixB)
{
    int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

    for (int rowsA = 0; rowsA < matrixA.GetLength(0); rowsA++)
    {
        for (int columnsB = 0; columnsB < matrixB.GetLength(1); columnsB++)
        {
            for (int columnsA = 0; columnsA < matrixA.GetLength(1); columnsA++)
            {
                matrixC[rowsA, columnsB] += matrixA[rowsA, columnsA] * matrixB[columnsA, columnsB];
            }
        }
    }

    return matrixC;
}
System.Console.Clear();
System.Console.WriteLine("Please enter size MatrixA");
int[,] matrixA = CreateUserMatrix();
System.Console.WriteLine("Please enter size MatrixB");
int[,] matrixB = CreateUserMatrix();

if (CheckMultiplyMatrix(matrixA, matrixB))
{
    System.Console.WriteLine("Multiplication is not possible!");
}
else
{
    FillMatrix(matrixA, 1, 10);
    FillMatrix(matrixB, 1, 10);
    PrintMatrix(matrixA);
    PrintMatrix(matrixB);
    int[,] matrixC = ReleaseMatrix(matrixA, matrixB);
    PrintMatrix(matrixC);
}


