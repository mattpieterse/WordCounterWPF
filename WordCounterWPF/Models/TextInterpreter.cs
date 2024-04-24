using System.Diagnostics;

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

    public static int GetParagraphCount(string text) {
        int count = 0;
        foreach (char c in text) {
            if (c == '\n' || c == '\r') count++;
        }
        return count;
    }

    // TODO: Create additional parse methods
}
