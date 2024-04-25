using System.Diagnostics;
using System.Linq;
using System.Windows.Media.Media3D;

namespace WordCounterWPF.Models;

public class TextInterpreter {

    public static int GetTotalLength(string text) {
        return text.Length;
    }

    public static int GetWordCount(string text) {
        string trimmedText = text.Trim();
        return trimmedText.Length == 0 ? 0 : trimmedText.Split(' ', '\t', '\n').Length;
    }

    public static int GetCharCount(string text) {
        int count = 0;
        foreach (char c in text) {
            if (!char.IsWhiteSpace(c)) count++;
        }
        return count;
    }

    public static int GetSpacesCount(string text) {
        return GetTotalLength(text) - GetTotalLength(text.Replace(" ", ""));
    }

    public static int GetSentencesCount(string text) {
        int count = 0;
        foreach (char c in text) {
            if (c == '.' || c == '!' || c == '?') count++;
        }
        return count;
    }

    /// <summary>
    /// Counts the occurrences of paragraphs within a string.
    /// </summary>
    /// <remarks>All newlines are converted into a Unix Line Feed (LF).</remarks>
    /// <returns>The integer count of occurrences.</returns>
    public static int GetParagraphCount(string text) {
        if (string.IsNullOrEmpty(text)) {
            return 0;
        }

        string converted = text
            .Replace("\r\n", "\n") // Convert: Carriage Return Line Feed (CRLF) -> Unix Line Feed (LF)
            .Replace("\r", "\n");  // Convert: Carriage Return (CR) -> Unix Line Feed (LF)

        int count = 0;
        var lines = converted.Trim().Split("\n", StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines) {
            if (!string.IsNullOrEmpty(line)) {          // Check for consecutive empty newlines
                if (!string.IsNullOrWhiteSpace(line)) { // Check for lines with only whitespace
                    count++;                            // Increment counter
                }
            }
        }

        return count;
    }

    public static int GetPageCount(string text) {
        int avgWordsInPage = 400;
        return GetWordCount(text) / avgWordsInPage;
    }

    // TODO: Create additional parse methods
}
