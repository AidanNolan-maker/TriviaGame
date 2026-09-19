namespace TriviaGame.Models;

public class QuizResult {
    public int Score { get; set; }

    public int TotalQuestions { get; set; }

    public double Percentage =>
        TotalQuestions == 0
            ? 0
            : (double)Score / TotalQuestions * 100;
}