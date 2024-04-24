using System.Collections.ObjectModel;
using WordCounterWPF.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WordCounterWPF.ViewModels;

public class HomeViewModel {

    public ObservableCollection<TextDataObject> DataObjects { get; set; }

    public HomeViewModel() {
        DataObjects = TextDataController.GetDataObjects();
    }

    public void UpdateObjectsDatabase(string text) {
        TextDataController.Clear();
        ObservableCollection<TextDataObject> StagingDB = [
            new TextDataObject("Length", TextInterpreter.GetTotalLength(text)),
            new TextDataObject("Word Count", TextInterpreter.GetWordCount(text)),
            new TextDataObject("Character Count", TextInterpreter.GetCharCount(text)),
            new TextDataObject("Pages", TextInterpreter.GetPageCount(text)),
            new TextDataObject("Sentences", TextInterpreter.GetSentencesCount(text)),
            new TextDataObject("Spaces", TextInterpreter.GetSpacesCount(text)),
            new TextDataObject("Paragraphs", TextInterpreter.GetParagraphCount(text)),
        ];

        foreach (TextDataObject DataObject in StagingDB) {
            TextDataController.AddDataObject(DataObject);
        }

        DataObjects = TextDataController.GetDataObjects();
    }
}
