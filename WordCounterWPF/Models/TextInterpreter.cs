using System.Diagnostics;
using System.Linq;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WordCounterWPF.Models;

/// <summary>
/// Class containing methods to parse data points from strings.
/// </summary>
/// <remarks>LINQ methods may be less efficient.</remarks>
public class TextInterpreter {

    public static int GetTotalLength(string text) {
        return text.Length;
    }

    /// <summary>
    /// Counts the number of words in a string.
    /// </summary>
    /// <remarks>Considers any sequence of non-whitespace and non-null characters as a word.</remarks>
    /// <returns>The integer count of words.</returns>
    public static int GetWordCount(string text) {
        return text.Trim().Split(null) // Split string by any whitespace character
            .Count(word => !string.IsNullOrWhiteSpace(word)); // Count non-whitespace-only strings
    }

    public static int GetCharCount(string text) {
        int count = 0;
        foreach (char c in text) {
            if (!char.IsWhiteSpace(c)) count++;
        }
        return count;
    }

    public static int GetCharCountLINQ(string text) {
        return text.Count(c => !char.IsWhiteSpace(c));
    }

    public static int GetLettersCount(string text) {
        int count = 0;
        foreach (char c in text) {
            if (char.IsLetter(c)) count++;
        }
        return count;
    }

    public static int GetLettersCountLINQ(string text) {
        return text.Count(c => char.IsLetter(c));
    }

    public static int GetLettersUpperCaseCount(string text) {
        int count = 0;
        foreach (char c in text) {
            if (char.IsUpper(c)) count++;
        }
        return count;
    }

    public static int GetLettersUpperCaseCountLINQ(string text) {
        return text.Count(c => char.IsUpper(c));
    }

    public static int GetLettersLowerCaseCount(string text) {
        int count = 0;
        foreach (char c in text) {
            if (char.IsLower(c)) count++;
        }
        return count;
    }

    public static int GetLettersLowerCaseCountLINQ(string text) {
        return text.Count(c => char.IsLower(c));
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
