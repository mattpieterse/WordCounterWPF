using System.Diagnostics;
using System.Windows.Controls;
using WordCounterWPF.ViewModels;

namespace WordCounterWPF.Views; 

public partial class HomeView : UserControl {

    private readonly HomeViewModel _viewModel;

    public HomeView() {
        InitializeComponent();

        _viewModel = new HomeViewModel();
        DataContext = _viewModel;
    }

    // Event Handlers

    private void TextInput_OnTextChanged(object sender, TextChangedEventArgs e) {
        Debug.WriteLine($"🔔 TextChanged :: <{e}>");
        _viewModel.UpdateObjectsDatabase(TextInput.Text);
    }
}
