using System.Windows.Input;

namespace TriviaGame.ViewModels;

public class MainViewModel {
    public ICommand StartQuizCommand { get; }

    public ICommand ViewHistoryCommand { get; }

    public MainViewModel() {
        StartQuizCommand = new Command(StartQuiz);
        ViewHistoryCommand = new Command(ViewHistory);
    }

    private async void StartQuiz() {
        await Shell.Current.GoToAsync("QuizPage");
    }

    private async void ViewHistory() {
        await Shell.Current.GoToAsync("HistoryPage");
    }
}