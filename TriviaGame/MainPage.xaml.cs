using TriviaGame.ViewModels;

namespace TriviaGame;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();

        BindingContext = new MainViewModel();
    }
}