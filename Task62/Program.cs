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

int[,] CreateUserMatrix()
{
    System.Console.WriteLine("Enter size matrix");
    int[] size = SingleLineInput(2);
    return new int[size[0], size[1]];
}

void PrintMatrix(int[,] matrix)
{

    for (int columns = 0; columns < matrix.GetLength(1); columns++)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            System.Console.Write($"{matrix[rows, columns]} \t");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

bool CheckSizeMaxtrix(int[,] matrix)
{
    return matrix.GetLength(1) > 1 && matrix.GetLength(0) > 1;
}

void FillMatrixZero(int[,] matrix)
{
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        for (int columns = 0; columns < matrix.GetLength(1); columns++)
        {
            matrix[rows, columns] = 0;
        }
    }
}

void FillCurlMatrix(int[,] matrix)
{
    FillMatrixZero(matrix);

    int count = 1;
    int x = 0, y = 0;
    while (count <= matrix.GetLength(0) * matrix.GetLength(1))
    {
        for (int i = x; i < matrix.GetLength(0); i++)
        {
            x = i;
            if (matrix[x, y] != 0)
            {
                x--;
                break;
            }
            matrix[x, y] = count++;
        }
        y++;

        for (int i = y; i < matrix.GetLength(1); i++)
        {
            y = i;
            if (matrix[x, y] != 0)
            {
                y--;
                break;
            }
            matrix[x, y] = count++;
        }
        x--;

        for (int i = x; i >= 0; i--)
        {
            x = i;
            if (matrix[x, y] != 0)
            {
                x++;
                break;
            }
            matrix[x, y] = count++;
        }
        y--;

        for (int i = y; i >= 0; i--)
        {
            y = i;
            if (matrix[x, y] != 0)
            {
                y++;
                break;
            }
            matrix[x, y] = count++;
        }
        x++;
    }
}

System.Console.Clear();
int[,] matrix = CreateUserMatrix();

if (CheckSizeMaxtrix(matrix))
{
    FillCurlMatrix(matrix);
    PrintMatrix(matrix);
}
else
{
    System.Console.WriteLine("Enter matrix is small");
}




