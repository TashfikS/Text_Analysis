using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Text_Analysis.Models;

namespace Text_Analysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextAnalysisController : ControllerBase
    {
        [HttpPost]
        [Route("analyze")]
        public ActionResult<TextAnalysisResult> AnalyzeText([FromBody] TextAnalysisRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Text))
            {
                return BadRequest("Invalid input. Please provide a non-empty text.");
            }

            string input = request.Text;

            int charCount = input.Replace(" ", "").Length;

            int wordCount = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            int sentenceCount = input.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;

            string[] words = Regex.Split(input, @"\W+");

            var wordFrequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var word in words)
            {
                if (wordFrequencies.ContainsKey(word))
                    wordFrequencies[word]++;
                else
                    wordFrequencies[word] = 1;
            }

            var mostFrequentWord = wordFrequencies.OrderByDescending(w => w.Value).FirstOrDefault();

            var longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault();

            var result = new TextAnalysisResult
            {
                Text = input,
                CharCount = charCount - 1,
                WordCount = wordCount - 1,
                SentenceCount = sentenceCount,
                MostFrequentWord = new WordFrequency
                {
                    Word = mostFrequentWord.Key,
                    Frequency = mostFrequentWord.Value
                },
                LongestWord = new LongestWord
                {
                    Word = longestWord,
                    Length = longestWord.Length
                }
            };

            return Ok(result);
        }
    }
}
