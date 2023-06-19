using Microsoft.AspNetCore.Mvc;
using Text_Analysis.Controllers;
using Text_Analysis.Models;
using Xunit;

namespace Text_Analysis.Tests
{
    public class TextAnalysisControllerTests
    {
        [Fact]
        public void AnalyzeText_ValidRequest_ReturnsOkObjectResult()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = "This is a sample text." };

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void AnalyzeText_NullRequest_ReturnsBadRequest()
        {
            // Arrange
            var controller = new TextAnalysisController();

            // Act
            var actionResult = controller.AnalyzeText(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void AnalyzeText_EmptyText_ReturnsBadRequest()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = string.Empty };

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void AnalyzeText_WhitespaceText_ReturnsBadRequest()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = "   " };

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void AnalyzeText_SingleCharacter_ReturnsOkObjectResult()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = "X" };

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void AnalyzeText_MultipleSentences_ReturnsOkObjectResult()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = "This is the first sentence. This is the second sentence." };

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void AnalyzeText_TextWithNoSpaces_ReturnsOkObjectResult()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = "Nospacesinthetext" };

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            var result = Assert.IsType<OkObjectResult>(actionResult.Result);
            var textAnalysisResult = Assert.IsType<TextAnalysisResult>(result.Value);
            Assert.Equal(16, textAnalysisResult.CharCount);
            Assert.Equal(0, textAnalysisResult.WordCount);
            Assert.Equal(1, textAnalysisResult.SentenceCount);
            Assert.Equal("Nospacesinthetext", textAnalysisResult.LongestWord.Word);
            Assert.Equal(17, textAnalysisResult.LongestWord.Length);
        }

        [Fact]
        public void AnalyzeText_TextWithNumbers_ReturnsOkObjectResult()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = "The number is 12345." };

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            var result = Assert.IsType<OkObjectResult>(actionResult.Result);
            var textAnalysisResult = Assert.IsType<TextAnalysisResult>(result.Value);
            Assert.Equal(16, textAnalysisResult.CharCount);
            Assert.Equal(3, textAnalysisResult.WordCount);
            Assert.Equal(1, textAnalysisResult.SentenceCount);
            Assert.Equal("number", textAnalysisResult.LongestWord.Word);
            Assert.Equal(6, textAnalysisResult.LongestWord.Length);
        }

        [Fact]
        public void AnalyzeText_GivenText()
        {
            // Arrange
            var controller = new TextAnalysisController();
            var request = new TextAnalysisRequest { Text = "The quick brown fox jumps over the lazy dog. The dog was not amused."};

            // Act
            var actionResult = controller.AnalyzeText(request);

            // Assert
            var result = Assert.IsType<OkObjectResult>(actionResult.Result);
            var textAnalysisResult = Assert.IsType<TextAnalysisResult>(result.Value);
            Assert.Equal(54, textAnalysisResult.CharCount);
            Assert.Equal(13, textAnalysisResult.WordCount);
            Assert.Equal(2, textAnalysisResult.SentenceCount);
            Assert.Equal("The", textAnalysisResult.MostFrequentWord.Word);
            Assert.Equal(3, textAnalysisResult.MostFrequentWord.Frequency);
            Assert.Equal("amused", textAnalysisResult.LongestWord.Word);
            Assert.Equal(6, textAnalysisResult.LongestWord.Length);
        }


    }
}
