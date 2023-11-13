namespace MyDictionary.Model
{
    public enum KeywordCategory
    {
        Noun = 0,
        Adjective = 1,
        Verb = 2,
        Adverb = 3,
    }

    public static class KeywordCategoryExtensions
    {
        public static bool checkValidKeywordCategory(int userInput)
        {
            return Enum.IsDefined(typeof(KeywordCategory), userInput);
        }
        public static void writeAllKeywordCategories()
        {
            foreach (KeywordCategory keywordCategory in Enum.GetValues(typeof(KeywordCategory)))
            {
                Console.WriteLine($"[{(int)keywordCategory}] - {keywordCategory}");
            }
        }
    }
}

