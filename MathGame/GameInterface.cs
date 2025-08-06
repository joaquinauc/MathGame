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

                gameFunctionality.PlayGame(operationChoice);

            }
            else
            {
                gameFunctionality.ShowScore();
            }
        }
    }
}
