using MyDictionary.Model;

namespace MyDictionary.Core
{
    internal class Dictionary
    {
        public Dictionary(string name, Languages mainLanguage, Languages targetLanguage)
        {
            this.name = name;
            this.mainLanguage = mainLanguage;
            this.targetLanguage = targetLanguage;
        }
        public string name { get; private set; }
        private Languages mainLanguage { get; set; }
        private Languages targetLanguage { get; set; }

        private List<Keyword> keywords = new List<Keyword>();

        public bool add(Keyword keyword)
        {
            if (keywords.Contains(keyword)) return false;
            keywords.Add(keyword);
            return true;
        }
        public bool remove(int index) => keywords.Remove(keywords[index]);
        public void clear() => keywords.Clear();
        public List<DictionaryKeywordItem> getAllKeyword()
        {
            return keywords.Select(keyword => new DictionaryKeywordItem(mainLanguage, targetLanguage, keyword)).ToList();
        }
        public List<DictionaryKeywordItem> getAllKeywordRandom()
        {
            List<Keyword> randomized = new List<Keyword>(keywords);
            return keywords.Select(keyword => new DictionaryKeywordItem(mainLanguage, targetLanguage, keyword)).ToList();
        }
        public List<DictionaryKeywordItem> getKeywordByCategory(KeywordCategory category)
        {
            List<Keyword> keywords = this.keywords.Where(e => e.category == category).ToList();
            return keywords.Select(keyword => new DictionaryKeywordItem(mainLanguage, targetLanguage, keyword)).ToList();
        }

        public bool checkContainsWord(String word)
        {
            Keyword? result = keywords.FirstOrDefault(e => e?.word == word, null);
            return result != null;
        }
    }
}
