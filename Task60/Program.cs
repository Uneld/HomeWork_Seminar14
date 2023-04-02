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

int[,,] CreateUserMatrix3D()
{
    System.Console.WriteLine("Enter size 3D matrix");
    int[] size = SingleLineInput(3);
    return new int[size[0], size[1], size[2]];
}

void FillMatrix3D(int[,,] matrix3D)
{
    int count = 10;

    for (int z = 0; z < matrix3D.GetLength(2); z++)
    {
        for (int y = 0; y < matrix3D.GetLength(1); y++)
        {
            for (int x = 0; x < matrix3D.GetLength(0); x++)
            {
                if (count <= 99)
                {
                    matrix3D[x, y, z] = count++;
                }
                else
                {
                    if (count == 100)
                    {
                        System.Console.WriteLine($"End number in position = [{x};{y};{z}]");
                        System.Console.WriteLine();
                        count++;
                    }
                    matrix3D[x, y, z] = new Random().Next(10, 100);
                }
            }
        }
    }
}

void PrintMatrix3D(int[,,] matrix3D)
{

    for (int z = 0; z < matrix3D.GetLength(2); z++)
    {
        System.Console.WriteLine($"Z coordinate = {z}");
        for (int y = 0; y < matrix3D.GetLength(1); y++)
        {
            for (int x = 0; x < matrix3D.GetLength(0); x++)
            {
                System.Console.Write($"Value = {matrix3D[x, y, z]}. Position = [{x};{y};{z}] \t");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

System.Console.Clear();
int[,,] matrix3D = CreateUserMatrix3D();
FillMatrix3D(matrix3D);
PrintMatrix3D(matrix3D);