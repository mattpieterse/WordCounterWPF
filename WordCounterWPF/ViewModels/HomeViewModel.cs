using System.Collections.ObjectModel;
using WordCounterWPF.Models;

namespace WordCounterWPF.ViewModels;

public class HomeViewModel {

    public ObservableCollection<TextDataObject> DataObjects { get; }

    public HomeViewModel() {
        DataObjects = TextDataController.GetDataObjects();
    }
}
