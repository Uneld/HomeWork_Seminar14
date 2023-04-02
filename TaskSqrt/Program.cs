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

int EnterNumber()
{
    System.Console.WriteLine("Please enter nuber");
    int[] size = SingleLineInput(1);
    return size[0];
}
int count = 0;
int SqrtUser(int number)
{
    if (number == 1)
    {
        return 1;
    }
    else
    {
        for (int i = 1; i <= number; i++)
        {
            count++;
            int pow = i * i;
            if (pow > number)
            {
                return i - 1;
            }
        }
        return 0;
    }
}

int number = EnterNumber();
System.Console.WriteLine($"User sqrt = {SqrtUser(number)}");