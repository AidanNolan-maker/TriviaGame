using Microsoft.EntityFrameworkCore;
using TriviaGame.Models;

namespace TriviaGame.Data;

public class TriviaDatabase {
    private readonly TriviaDbContext _context;

    public TriviaDatabase(TriviaDbContext context) {
        _context = context;
    }

    public async Task<List<Question>> GetQuestionsAsync() {
        return await _context.Questions.ToListAsync();
    }

    public async Task AddQuestionAsync(Question question) {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
    }

    public async Task SeedQuestionsAsync() {
        if (await _context.Questions.AnyAsync()) {
            return;
        }

        List<Question> questions = [
            new Question {
                Id = 1,
                Text = "Which planet is known as the Red Planet?",
                Category = "Science",
                Difficulty = "Easy",
                CorrectAnswer = "Mars",
                IncorrectAnswer1 = "Venus",
                IncorrectAnswer2 = "Jupiter",
                IncorrectAnswer3 = "Mercury"
            },

            new Question {
                Id = 2,
                Text = "What is the largest ocean on Earth?",
                Category = "Geography",
                Difficulty = "Easy",
                CorrectAnswer = "Pacific Ocean",
                IncorrectAnswer1 = "Atlantic Ocean",
                IncorrectAnswer2 = "Indian Ocean",
                IncorrectAnswer3 = "Arctic Ocean"
            },

            new Question {
                Id = 3,
                Text = "What is the primary programming language used by .NET MAUI?",
                Category = "Programming",
                Difficulty = "Easy",
                CorrectAnswer = "C#",
                IncorrectAnswer1 = "Java",
                IncorrectAnswer2 = "Python",
                IncorrectAnswer3 = "Ruby"
            },

            new Question {
                Id = 4,
                Text = "Who painted the Mona Lisa?",
                Category = "Art",
                Difficulty = "Easy",
                CorrectAnswer = "Leonardo da Vinci",
                IncorrectAnswer1 = "Vincent van Gogh",
                IncorrectAnswer2 = "Pablo Picasso",
                IncorrectAnswer3 = "Claude Monet"
            },

            new Question {
                Id = 5,
                Text = "How many players from one NFL team are on the field at one time?",
                Category = "Sports",
                Difficulty = "Easy",
                CorrectAnswer = "11",
                IncorrectAnswer1 = "9",
                IncorrectAnswer2 = "10",
                IncorrectAnswer3 = "12"
            }
        ];

        await _context.Questions.AddRangeAsync(questions);
        await _context.SaveChangesAsync();
    }
}
