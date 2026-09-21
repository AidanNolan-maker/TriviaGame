using TriviaGame.Data;
using TriviaGame.ViewModels;

namespace TriviaGame.Views;

public partial class QuizPage : ContentPage
{
    public QuizPage(TriviaDatabase database)
    {
        InitializeComponent();

        BindingContext = new QuizViewModel(database);
    }
}