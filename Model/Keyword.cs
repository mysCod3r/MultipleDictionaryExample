namespace MyDictionary.Model
{
    public class Keyword : IEquatable<Keyword>
    {
        public Keyword(string word, string mean, KeywordCategory category)
        {
            this.word = word;
            this.mean = mean;
            this.category = category;
        }

        public string word { get; set; }
        public string mean { get; set; }
        public KeywordCategory category { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Keyword objAsKeyword) return false;
            else return Equals(objAsKeyword);
        }
        public override int GetHashCode() => 0;

        public bool Equals(Keyword? other)
        {
            if (other == null) return false;
            bool isEqual = word.Equals(other.word) || mean.Equals(other.mean);
            return isEqual;
        }
    }
}
