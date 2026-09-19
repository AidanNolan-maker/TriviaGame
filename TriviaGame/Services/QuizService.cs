using TriviaGame.Models;

namespace TriviaGame.Services;

public class QuizService {
    private readonly List<Question> _questions = [
        new Question {
            Id = 1,
            Text = "Which planet is known as the Red Planet?",
            Category = "Science",
            Difficulty = "Easy",
            CorrectAnswer = "Mars",
            IncorrectAnswers = [
                "Venus",
                "Jupiter",
                "Mercury"
            ]
        },

        new Question {
            Id = 2,
            Text = "What is the largest ocean on Earth?",
            Category = "Geography",
            Difficulty = "Easy",
            CorrectAnswer = "Pacific Ocean",
            IncorrectAnswers = [
                "Atlantic Ocean",
                "Indian Ocean",
                "Arctic Ocean"
            ]
        },

        new Question {
            Id = 3,
            Text = "Which language is primarily used to build applications with .NET MAUI?",
            Category = "Technology",
            Difficulty = "Easy",
            CorrectAnswer = "C#",
            IncorrectAnswers = [
                "Java",
                "Python",
                "Ruby"
            ]
        },

        new Question {
            Id = 4,
            Text = "Who painted the Mona Lisa?",
            Category = "Art",
            Difficulty = "Easy",
            CorrectAnswer = "Leonardo da Vinci",
            IncorrectAnswers = [
                "Vincent van Gogh",
                "Pablo Picasso",
                "Claude Monet"
            ]
        },

        new Question {
            Id = 5,
            Text = "How many players are on the field for one NFL team at a time?",
            Category = "Sports",
            Difficulty = "Easy",
            CorrectAnswer = "11",
            IncorrectAnswers = [
                "9",
                "10",
                "12"
            ]
        }
    ];

    public List<Question> GetQuestions(int amount) {
        return _questions
            .OrderBy(_ => Random.Shared.Next())
            .Take(amount)
            .ToList();
    }
}
