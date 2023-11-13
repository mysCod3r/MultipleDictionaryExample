namespace MyDictionary.Model
{
    public class DictionaryKeywordItem
    {
        public DictionaryKeywordItem(Languages mainLanguage, Languages targetLanguage, Keyword keyword)
        {
            this.mainLanguage = mainLanguage;
            this.targetLanguage = targetLanguage;
            this.keyword = keyword;
        }

        public Languages mainLanguage { get; private set; }
        public Languages targetLanguage { get; private set; }
        public Keyword keyword { get; private set; }
    }
}
