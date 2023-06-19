public class TextAnalysisResult
{
    public string Text { get; set; }
    public int CharCount { get; set; }
    public int WordCount { get; set; }
    public int SentenceCount { get; set; }
    public WordFrequency MostFrequentWord { get; set; }
    public LongestWord LongestWord { get; set; }
}

public class WordFrequency
{
    public string Word { get; set; }
    public int Frequency { get; set; }
}

public class LongestWord
{
    public string Word { get; set; }
    public int Length { get; set; }
}
