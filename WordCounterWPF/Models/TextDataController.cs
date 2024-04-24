using System.Collections.ObjectModel;

namespace WordCounterWPF.Models;

public class TextDataController {

    private static ObservableCollection<TextDataObject> _Database = new ObservableCollection<TextDataObject>();

    // -- Static Methods

    /// <summary>
    /// Gets private collection of data objects.
    /// </summary>
    public static ObservableCollection<TextDataObject> GetDataObjects() {
        return _Database;
    } 

    /// <summary>
    /// Adds a new data object to the private collection.
    /// </summary>
    public static void AddDataObject(TextDataObject textDataObject) {
        _Database.Add(textDataObject);
    }

    /// <summary>
    /// Clear all objects within the collection.
    /// </summary>
    public static void Clear() {
        _Database.Clear();
    }
}
