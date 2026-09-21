using TriviaGame.Data;
using TriviaGame.Models;

namespace TriviaGame.Services;

public class QuizService {
    private readonly TriviaDatabase _database;

    public QuizService(TriviaDatabase database) {
        _database = database;
    }

    public async Task<List<Question>> GetQuestionsAsync(int amount) {
        List<Question> questions = await _database.GetQuestionsAsync();

        return questions
            .OrderBy(_ => Random.Shared.Next())
            .Take(amount)
            .ToList();
    }
}