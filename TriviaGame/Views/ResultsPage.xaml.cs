using TriviaGame.Models;
using TriviaGame.ViewModels;

namespace TriviaGame.Views;

public partial class ResultsPage : ContentPage, IQueryAttributable {
    public ResultsPage() {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        if (query.TryGetValue("Result", out object? value)
            && value is QuizResult result) {
            BindingContext = new ResultsViewModel(result);
        }
    }

    private async void PlayAgain_Clicked(object sender, EventArgs e) {
        await Shell.Current.Navigation.PopToRootAsync();

        await Shell.Current.GoToAsync(nameof(QuizPage));
    }

    private async void BackToHome_Clicked(object sender, EventArgs e) {
        await Shell.Current.Navigation.PopToRootAsync();
    }
}