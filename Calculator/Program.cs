class Calculator
{
  private static readonly Dictionary<char, Func<int, int, double>> Operations = new Dictionary<char, Func<int, int, double>>
  {
    {'+', (a, b) => a + b},
    {'-', (a, b) => a - b},
    {'*', (a, b) => a * b},
    {'/', (a, b) => (double)a / b},
    {'%', (a, b) => a % b}
  };

  static void Main()
  {
    char operation = GetOperation();
    int firstOperand = GetOperand("first");
    int secondOperand = GetOperand("second");

    try
    {
      double result = Calculate(operation, firstOperand, secondOperand);
      Console.WriteLine($"{firstOperand} {operation} {secondOperand} = {result}");
    }
    catch (DivideByZeroException)
    {
      Console.WriteLine("Error: Division by zero is not allowed.");
    }
  }

  static char GetOperation()
  {
    while (true)
    {
      Console.WriteLine("Enter an operation sign (+, -, *, /, %):");
      var input = Console.ReadLine();
      if (input?.Length == 1 && Operations.ContainsKey(input[0]))
      {
        return input[0];
      }
      Console.WriteLine("Invalid operation. Please try again.");
    }
  }

  static int GetOperand(string ordinal)
  {
    while (true)
    {
      Console.WriteLine($"Enter the {ordinal} operand as an integer:");
      if (int.TryParse(Console.ReadLine(), out int operand))
      {
        return operand;
      }
      Console.WriteLine("Invalid operand! Please enter a whole number.");
    }
  }

  static double Calculate(char operation, int a, int b)
  {
    if (operation == '/' && b == 0)
    {
      throw new DivideByZeroException();
    }
    return Operations[operation](a, b);
  }
}