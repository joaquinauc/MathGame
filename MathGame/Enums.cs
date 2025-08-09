namespace MathGame;

// This class contains the enumeration types used in the math game, such as mathematical operations and game states.

internal class Enums
{
    internal enum MathOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        RandomGame,
    }

    internal enum GameState
    {
        StartGame,
        Score,
    }

    internal enum GameDifficulty
    {
        Easy,
        Medium,
        Hard,
    }
}
