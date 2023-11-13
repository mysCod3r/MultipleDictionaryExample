namespace MyDictionary.Core
{
    internal class DictionaryRepository
    {
        public DictionaryRepository()
        {
            dictionaries = new List<Dictionary>();
        }

        private List<Dictionary> dictionaries { get; set; }
        public Dictionary? currentDictionary { get; private set; }

        public bool addDictionary(Dictionary dictionary)
        {
            if (dictionaries.Contains(dictionary)) return false;
            dictionaries.Add(dictionary);
            return true;
        }
        public int dictionariesCount() => dictionaries.Count;
        public bool removeDictionary(Dictionary dictionary) => dictionaries.Remove(dictionary);
        public void setCurrentDictionary(Dictionary? dictionary) => currentDictionary = dictionary;

        public void listAll()
        {
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine("[{0}]: " + dictionaries[i].name, i + 1);
            }
        }

        public Dictionary getDictioanaryByIndex(int index)
        {
            return dictionaries[index];
        }
    }
}
