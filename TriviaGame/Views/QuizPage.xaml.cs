using TriviaGame.ViewModels;

namespace TriviaGame.Views;

public partial class QuizPage : ContentPage
{
    public QuizPage()
    {
        InitializeComponent();

        BindingContext = new QuizViewModel();
    }
}