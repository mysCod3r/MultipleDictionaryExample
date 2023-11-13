using MyDictionary.Model;

namespace MyDictionary.Utility
{
    public sealed class Helper
    {
        private static readonly Helper instance = new Helper();
        static Helper() { }
        private Helper() { }
        public static Helper Instance => instance;
        string _seperator = new string('-', 20);

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
            for (int i = 0; i < items.Count; i++)
            {
                DictionaryKeywordItem item = items[i];
                Console.WriteLine($"------{i}------");
                _printKeywordWithSeperator(item);
            }
        }

        public void printKeywordsStepByStep(List<DictionaryKeywordItem>? items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("This list is empty.");
                return;
            }
            foreach (DictionaryKeywordItem item in items)
            {
                _printKeywordWithSeperator(item);
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
            Console.WriteLine(_seperator);
        }

        private void _printKeywordWithSeperator(DictionaryKeywordItem item)
        {
            Console.WriteLine(item.mainLanguage + ": " + item.keyword.word);
            Console.WriteLine(item.targetLanguage + ": " + item.keyword.mean);
            Console.WriteLine("Category: " + item.keyword.category);
            Console.WriteLine(_seperator);
        }
    }
}
