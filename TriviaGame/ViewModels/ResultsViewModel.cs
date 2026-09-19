using TriviaGame.Models;

namespace TriviaGame.ViewModels;

public class ResultsViewModel {
    public QuizResult Result { get; }

    public string ScoreText =>
        $"{Result.Score} / {Result.TotalQuestions}";

    public string PercentageText =>
        $"{Result.Percentage:0}%";

    public ResultsViewModel(QuizResult result) {
        Result = result;
    }
}