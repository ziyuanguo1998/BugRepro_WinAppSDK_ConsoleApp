using Microsoft.Windows.AI.Generative;

namespace ConsoleApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Thinking!");

            string prompt = GetPrompt(args);
            string reply = await TestPrompt(prompt);

            Console.WriteLine(reply);
        }

        private static async Task<string> TestPrompt(string prompt)
        {
            if (!LanguageModel.IsAvailable())
            {
                var op = await LanguageModel.MakeAvailableAsync();
            }

            var languageModel = await LanguageModel.CreateAsync();
            var result = await languageModel.GenerateResponseAsync(prompt);

            return result.Response;
        }

        private static string GetPrompt(string[] args)
        {
            string prompt = string.Empty;
            if (args.Length > 0)
            {
                prompt = args[0];
            }

            if (string.IsNullOrWhiteSpace(prompt))
            {
                prompt = "Provide the molecular formula for glucose.";
            }

            return prompt;
        }
    }
}
