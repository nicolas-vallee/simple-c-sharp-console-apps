class GuessTheNumber
{
  static void Main()
  {
    int target = GenerateTarget();
    int userGuess = -1;

    Console.WriteLine("Guess a number between 0 and 100:");

    do
    {
      string? userInput = Console.ReadLine();
      if (int.TryParse(userInput, out userGuess))
      {
        if (userGuess < target)
        {
          Console.WriteLine($"The mystery number is greater than {userGuess}. Try again:");
        }
        else if (userGuess > target)
        {
          Console.WriteLine($"The mystery number is less than {userGuess}. Try again:");
        }
      }
      else
      {
        Console.WriteLine("Enter a valid whole number:");
      }
    } while (userGuess != target);

    Console.WriteLine($"Congratulations! You found the mystery number of {target}.");
  }

  static int GenerateTarget()
  {
    Random random = new Random();
    return random.Next(0, 101); // 0 to 100 inclusive
  }
}


