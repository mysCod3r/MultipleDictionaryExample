using MyDictionary.Model;

namespace MyDictionary.Utility
{
    public sealed class Helper
    {
        private static readonly Helper instance = new Helper();
        static Helper() { }
        private Helper() { }
        public static Helper Instance => instance;

        public int inputNumber(bool withCancel = false)
        {
            if (withCancel) Console.WriteLine("[-1] to cancel");
            string? input = Console.ReadLine();
            int number;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("You should be enter a integer value.");
                return inputNumber(withCancel);
            }
            return number;
        }
        public string inputString(string hintText, bool withCancel = false)
        {
            Console.Write(hintText + (withCancel ? " // ['q' to cancel]" : ""));
            string input = Console.ReadLine() ?? "";
            if (input == "")
            {
                Console.WriteLine("Cannot be empty...");
                return inputString(hintText, withCancel);
            }
            else return input;
        }

        public void printKeywords(List<DictionaryKeywordItem>? items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("This list is empty.");
                return;
            }
            foreach (DictionaryKeywordItem item in items) _printKeywordWithSeperator(item);

        }

        private void _printKeywordWithSeperator(DictionaryKeywordItem item)
        {
            string seperator = new string('-', 20);
            Console.WriteLine(item.mainLanguage + ": " + item.keyword.word);
            Console.WriteLine(item.targetLanguage + ": " + item.keyword.mean);
            Console.WriteLine("Category: " + item.keyword.category);
            Console.WriteLine(seperator);
        }
    }
}
