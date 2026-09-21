namespace TriviaGame.Models;

public class Question {
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string CorrectAnswer { get; set; } = string.Empty;
    
    public string IncorrectAnswer1 { get; set; } = string.Empty;
    
    public string IncorrectAnswer2 { get; set; } = string.Empty;
    
    public string IncorrectAnswer3 { get; set; } = string.Empty;
}