using Spectre.Console;

namespace MathGame;

// This class contains helper methods for generating random numbers, validating user input, and managing game history.
internal static class Helpers
{
    private static readonly Random _random = new();

    internal static List<GameFunctionality> ScoreList { get; private set; } = new List<GameFunctionality>();

    internal static (int, int) GenerateNumber(int first_num_max_range, int second_num_max_range)
    {
        return (_random.Next(1, first_num_max_range), _random.Next(1, second_num_max_range));
    }

    internal static int AskForAnswer((int a, int b) numbers, string operationSymbol)
    {
        while (true)
        {
            Console.Write($"Please answer the next operation: {numbers.a} {operationSymbol} {numbers.b} = ");
            string? userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int answer))
                return answer;

            Console.WriteLine("Input is not a valid integer. Try again.");
            Console.ReadLine();
            Console.Clear();
        }
    }

    internal static bool ValidateAnswer(int userAnswer, int correctAnswer)
    {
        return userAnswer == correctAnswer;
    }

    internal static void AddToHistory(GameFunctionality gameFunctionality)
    {
        ScoreList.Add(gameFunctionality);
    }

    internal static RandomEnum GetRandomEnumValue<RandomEnum>() where RandomEnum : struct, Enum 
        // struct ensures that the type is a value type and Enum ensures it is an enumeration.
    {
        var values = Enum.GetValues<RandomEnum>();
        return values[_random.Next(values.Length)];
    }

}
