namespace WordCounterWPF.Models;

public class TextDataObject {

    public string? Codepoint { get; }
    public int Count { get; }

    public TextDataObject(string? codepoint, int count) {
        Codepoint = codepoint;
        Count = count;
    }
}
