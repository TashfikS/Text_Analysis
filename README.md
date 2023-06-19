# Text Analytics Service

The Text Analytics Service is a RESTful API that analyzes text input and provides various analytics based on the input string. The service is implemented using ASP.NET Core 6.

## API Endpoints

### Text Analysis

- **Endpoint:** `POST /analyze`
- **Description:** Analyzes the input text and returns various analytics.
- **Request Body:**
  - `text` (string): The text input to be analyzed.
- **Response:**
  - `charCount` (number): The number of characters in the text (excluding spaces).
  - `wordCount` (number): The number of words in the text.
  - `sentenceCount` (number): The number of sentences in the text.
  - `mostFrequentWord` (object): An object containing the most frequent word and its frequency.
    - `word` (string): The most frequent word.
    - `frequency` (number): The frequency of the most frequent word.
  - `longestWord` (object): An object containing the longest word and its length.
    - `word` (string): The longest word.
    - `length` (number): The length of the longest word.
- **Example:**
  - Request Body:
    ```json
    {
      "text": "The quick brown fox jumps over the lazy dog. The dog was not amused."
    }
    ```
  - Response Body:
    ```json
    {
      "charCount": 54,
      "wordCount": 13,
      "sentenceCount": 2,
      "mostFrequentWord": {
        "word": "the",
        "frequency": 3
      },
      "longestWord": {
        "word": "amused",
        "length": 6
      }
    }
    ```

## Additional Requirements

The Text Analytics Service meets the following additional requirements:

- **Data Validation:** The service ensures that the input data is a valid string. If the `text` field is missing or empty, a `400 Bad Request` response is returned.
- **Error Handling:** The service handles errors gracefully and returns appropriate HTTP status codes and error messages.
- **Testing:** Unit tests have been written to ensure the service functions as expected. The tests cover scenarios such as valid input, missing input, and verifying the calculated analytics and error responses.
- **Documentation:** This README file serves as documentation, providing clear instructions on how to set up, run, and use the Text Analytics Service.

## Setup and Run

To set up and run the Text Analytics Service, follow these steps:

1. Clone the repository or download the source code.

2. Open the project in your preferred IDE (e.g., Visual Studio).

3. Build the solution to restore NuGet packages.

4. Run the project.

5. The service will start running and listening for requests on the specified port.

## Testing

The service can be tested using tools like Postman or by running the provided unit tests.

To run the unit tests:

1. Open the test project in your preferred IDE.

2. Build the solution to restore NuGet packages (if not already done).

3. Run the unit tests.

4. The tests will be executed, and the results will be displayed.

Please feel free to modify or enhance the content as needed to meet your specific requirements.
