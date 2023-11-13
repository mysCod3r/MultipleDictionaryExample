namespace MyDictionary.Model
{
    public enum Languages
    {
        Turkish = 0,
        English = 1,
        German = 2,
    }

    public static class LanguagesExtensions
    {
        public static bool checkValidKeywordType(int userInput)
        {
            return Enum.IsDefined(typeof(Languages), userInput);
        }
        public static void writeAllLanguages()
        {
            foreach (Languages language in Enum.GetValues(typeof(Languages)))
            {
                Console.WriteLine($"[{(int)language}] - {language}");
            }
        }
    }
}
