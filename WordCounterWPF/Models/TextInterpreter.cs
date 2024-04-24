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
        if (string.IsNullOrEmpty(text)) {
            return 0;
        }

        int count = 0;
        bool isInsideParagraph = false;
        for (int i = 0; i < text.Length; i++) {
            char c = text[i];

            // Check for non-white character
            if (!char.IsWhiteSpace(c) && (i != text.Length - 1)) {
                // Check if still inside of a paragraph
                if (!isInsideParagraph) {
                    isInsideParagraph = true;
                    count++;
                }
            }
            else { // End of paragraph with consecutive empty lines
                isInsideParagraph = false;
            }
        }

        // Check if this is the final paragraph
        if (isInsideParagraph) {
            count++;
        }

        return count;
    }

    public static int GetPageCount(string text) {
        int avgWordsInPage = 400;
        return GetWordCount(text) / avgWordsInPage;
    }

    // TODO: Create additional parse methods
}
