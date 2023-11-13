using MyDictionary.Core;
using MyDictionary.Model;

namespace MyDictionary.Utility
{
    internal class DummyDatas
    {
        public DummyDatas(DictionaryRepository repository)
        {
            this.repository = repository;
        }
        public DictionaryRepository repository { get; private set; }

        public void init()
        {
            Dictionary tr_en = new Dictionary("Sample Turkish & English", Languages.Turkish, Languages.English);
            tr_en.add(new Keyword("selam", "hi", KeywordCategory.Verb));
            tr_en.add(new Keyword("harika", "great", KeywordCategory.Verb));
            tr_en.add(new Keyword("kötü", "bad", KeywordCategory.Verb));
            repository.addDictionary(tr_en);

            Dictionary tr_gr = new Dictionary("Sample Turkish & German", Languages.Turkish, Languages.German);
            tr_gr.add(new Keyword("selam", "hi", KeywordCategory.Verb));
            tr_gr.add(new Keyword("harika", "wunderbar", KeywordCategory.Verb));
            tr_gr.add(new Keyword("kötü", "schlecht", KeywordCategory.Verb));
            repository.addDictionary(tr_gr);
        }



    }
}
