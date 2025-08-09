using Spectre.Console;
using static MathGame.Enums;

namespace MathGame;

// This class serves as the main interface for the game, allowing users to select actions and play the game.

internal static class GameInterface
{
    internal static void MainMenu()
    {
        while (true)
        {
            GameFunctionality gameFunctionality = new();

            Console.Clear();
            
            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<GameState>()
                    .Title("Select which action you wish to do:")
                    .AddChoices(Enum.GetValues<GameState>()));

            if (actionChoice == GameState.StartGame)
            {
                var operationChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MathOperation>()
                    .Title("Select a math operation:")
                    .AddChoices(Enum.GetValues<MathOperation>()));

                if (operationChoice != MathOperation.RandomGame)
                {
                    var difficultyChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<GameDifficulty>()
                    .Title("Select a math operation:")
                    .AddChoices(Enum.GetValues<GameDifficulty>()));
                    gameFunctionality.PlayGame(operationChoice, difficultyChoice);
                }
                else
                {
                    gameFunctionality.PlayGame(operationChoice);
                }

            }
            else
            {
                gameFunctionality.ShowScore();
            }
        }
    }
}
