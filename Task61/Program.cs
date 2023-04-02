const int widthCellPascal = 7;
const int widthCellSerpinsky = 3;

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

int EnterUserRows()
{
    System.Console.WriteLine("Please enter nubers of rows");
    int[] size = SingleLineInput(1);
    return size[0];
}

void PrintTrianglePasal(int[,] matrix)
{
    int consoleWidth = matrix.GetLength(0) * widthCellPascal;
    int x;
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        x = (consoleWidth / 2) - (widthCellPascal * rows / 2);
        System.Console.SetCursorPosition(x, rows);
        for (int columns = 0; columns < matrix.GetLength(1); columns++)
        {
            if (matrix[rows, columns] > 0)
            {
                System.Console.Write($"{matrix[rows, columns],widthCellPascal}");
            }
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

void PrintFractalSerpinsky(int[,] matrix)
{
    int consoleWidth = matrix.GetLength(0) * widthCellSerpinsky;
    int x;
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        x = (consoleWidth / 2) - (widthCellSerpinsky * rows / 2);
        System.Console.SetCursorPosition(x, rows);
        for (int columns = 0; columns < matrix.GetLength(1); columns++)
        {
            if (matrix[rows, columns] > 0)
            {
                System.Console.Write((matrix[rows, columns] % 2) != 0 ? " * " : "   ");
            }
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

int[,] CalculationTrianglePasal(int numRows)
{
    int[,] resultMatrix = new int[numRows, numRows];
    for (int rows = 0; rows < numRows; rows++)
    {
        resultMatrix[rows, 0] = 1;
        if (rows > 0)
        {
            for (int columns = 1; columns < numRows; columns++)
            {
                if (rows == columns)
                {
                    resultMatrix[rows, columns] = 1;
                    break;
                }
                resultMatrix[rows, columns] = resultMatrix[rows - 1, columns] + resultMatrix[rows - 1, columns - 1];
            }
        }
    }
    return resultMatrix;
}

//16
System.Console.Clear();
int[,] trianglePascal = CalculationTrianglePasal(EnterUserRows());
System.Console.Clear();
PrintTrianglePasal(trianglePascal);
System.Console.WriteLine("Please enter any key");
System.Console.ReadKey();
System.Console.Clear();
PrintFractalSerpinsky(trianglePascal);