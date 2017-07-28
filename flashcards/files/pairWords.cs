namespace Flashcards.files
{
    public class pairWords
    {
       public string word1 { get; set; }
       public string word2 { get; set; }
        public pairWords(string str1, string str2)
        {
            word1 = str1;
            word2 = str2;
        }

        public string getPairTogetherString()
        {
            return word1 + "@" + word2;
        }
    }
}
