namespace MathGame;

// This class contains the core functionality of the math game, including playing the game and showing the score.

internal class GameFunctionality
{
    string? OperationSymbol;
    bool GameWon;
    int First_Number;
    int Second_Number;
    int UserAnswer;

    internal void PlayGame(Enums.MathOperation mathOperation, Enums.GameDifficulty gameDifficulty)
    {
        GameWon = false;

        int max_range = gameDifficulty switch
        {
            Enums.GameDifficulty.Easy => 11,
            Enums.GameDifficulty.Medium => 51,
            Enums.GameDifficulty.Hard => 101,
            _ => throw new NotImplementedException()
        };

        (First_Number, Second_Number) = Helpers.GenerateNumber(first_num_max_range: max_range, second_num_max_range: max_range);

        while (First_Number % Second_Number != 0 && mathOperation == Enums.MathOperation.Division)
        {
            (First_Number, Second_Number) = Helpers.GenerateNumber(first_num_max_range: max_range, second_num_max_range: max_range);
        }

        OperationSymbol = mathOperation switch
        {
            Enums.MathOperation.Addition => "+",
            Enums.MathOperation.Subtraction => "-",
            Enums.MathOperation.Multiplication => "*",
            Enums.MathOperation.Division => "/",
            _ => throw new NotImplementedException()
        };

        UserAnswer = Helpers.AskForAnswer((First_Number, Second_Number), OperationSymbol);
        
        int correctAnswer = mathOperation switch
        {
            Enums.MathOperation.Addition => First_Number + Second_Number,
            Enums.MathOperation.Subtraction => First_Number - Second_Number,
            Enums.MathOperation.Multiplication => First_Number  * Second_Number,
            Enums.MathOperation.Division => Second_Number != 0 ? First_Number / Second_Number : throw new DivideByZeroException("Cannot divide by zero"),
            _ => throw new NotImplementedException()
        };

        if (Helpers.ValidateAnswer(UserAnswer, correctAnswer))
        {
            GameWon = true;
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Incorrect! The correct answer was {correctAnswer}.");
        }

        Helpers.AddToHistory(this);

        Console.ReadLine();
    }

    internal void ShowScore()
    {
        int gamesPlayed = 0;
        int score = 0;
        string veredict = "You lost the game!";

        // Implement the logic to show the score
        foreach (var game in Helpers.ScoreList)
        {
            if (game.GameWon)
            {
                score++;
                veredict = "You won the game!";
            }

            gamesPlayed++;
            
            Console.WriteLine($"Operation: {game.First_Number} {game.OperationSymbol} {game.Second_Number} = {game.UserAnswer}");
            Console.WriteLine($"Result: {veredict} | Score: {score}/{gamesPlayed}\n");
        }

        Console.ReadLine();
    }
}
