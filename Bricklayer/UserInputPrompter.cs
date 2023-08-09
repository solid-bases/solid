namespace Bricklayer;

internal static class UserInputPrompter
{
    public static string? AskAndVerifyValidInputs(Dictionary<string, string> allowedInputs)
    {
        var input = "\0";
        do
        {
            Console.Write(Environment.NewLine);
            if (input != "\0")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Not valid input, please type one of the following values: {string.Join(", ", allowedInputs.Keys)}.");
                Console.ResetColor();
            }
            Console.Write($"Do you want an {JoinQuestions(allowedInputs)} output? ");
            input = Console.ReadLine();
        } while (IsNotValidInput(input));

        string JoinQuestions(Dictionary<string, string> questions) => string.Join(", ", questions.Select(GetQuestionTextFromValuePair));
        string GetQuestionTextFromValuePair(KeyValuePair<string, string> pair) => $"{pair.Value} ({pair.Key})";

        bool IsNotValidInput(string? input)
        {
            return string.IsNullOrWhiteSpace(input) || !allowedInputs.Any(i => IsEqualsIc(input, i.Key));
        }

        return input;
    }

    public static bool IsEqualsIc(string input, string value) => string.Equals(input, value, StringComparison.OrdinalIgnoreCase);
}
