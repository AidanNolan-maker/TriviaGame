using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TriviaGame.Models;
using TriviaGame.Services;
using TriviaGame.Views;

namespace TriviaGame.ViewModels;

public class QuizViewModel : INotifyPropertyChanged
{
    private readonly QuizService _quizService;

    private List<Question> _questions = [];

    private int _currentQuestionIndex;

    private string _currentQuestionText = string.Empty;

    private string _answer1 = string.Empty;
    private string _answer2 = string.Empty;
    private string _answer3 = string.Empty;
    private string _answer4 = string.Empty;

    private int _score;

    private string _feedback = string.Empty;

    private bool _isAnswering;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string CurrentQuestionText
    {
        get => _currentQuestionText;
        private set
        {
            _currentQuestionText = value;
            OnPropertyChanged();
        }
    }

    public string Answer1
    {
        get => _answer1;
        private set
        {
            _answer1 = value;
            OnPropertyChanged();
        }
    }

    public string Answer2
    {
        get => _answer2;
        private set
        {
            _answer2 = value;
            OnPropertyChanged();
        }
    }

    public string Answer3
    {
        get => _answer3;
        private set
        {
            _answer3 = value;
            OnPropertyChanged();
        }
    }

    public string Answer4
    {
        get => _answer4;
        private set
        {
            _answer4 = value;
            OnPropertyChanged();
        }
    }

    public int CurrentQuestionNumber =>
        _currentQuestionIndex + 1;

    public int TotalQuestions =>
        _questions.Count;

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            OnPropertyChanged();
        }
    }

    public string Feedback
    {
        get => _feedback;
        private set
        {
            _feedback = value;
            OnPropertyChanged();
        }
    }

    public bool IsAnswering
    {
        get => _isAnswering;
        private set
        {
            _isAnswering = value;
            OnPropertyChanged();

            ((Command<string>)AnswerCommand).ChangeCanExecute();
        }
    }

    public ICommand AnswerCommand { get; }

    public QuizViewModel()
    {
        _quizService = new QuizService();

        AnswerCommand = new Command<string>(
            async answer => await SubmitAnswerAsync(answer),
            answer => IsAnswering);

        StartQuiz();
    }

    private void StartQuiz()
    {
        _questions = _quizService.GetQuestions(5);

        _currentQuestionIndex = 0;
        Score = 0;

        LoadCurrentQuestion();
    }

    private void LoadCurrentQuestion()
    {
        Question question = _questions[_currentQuestionIndex];

        CurrentQuestionText = question.Text;

        List<string> answers =
        [
            question.CorrectAnswer,
            .. question.IncorrectAnswers
        ];

        answers = answers
            .OrderBy(_ => Random.Shared.Next())
            .ToList();

        Answer1 = answers[0];
        Answer2 = answers[1];
        Answer3 = answers[2];
        Answer4 = answers[3];

        Feedback = string.Empty;

        OnPropertyChanged(nameof(CurrentQuestionNumber));

        IsAnswering = true;
    }

    private async Task SubmitAnswerAsync(string answer)
    {
        if (!IsAnswering)
        {
            return;
        }

        Question question = _questions[_currentQuestionIndex];

        IsAnswering = false;

        if (answer == question.CorrectAnswer)
        {
            Score++;
            Feedback = "Correct!";
        }
        else
        {
            Feedback = "Incorrect!";
        }

        await Task.Delay(1000);

        if (_currentQuestionIndex < _questions.Count - 1)
        {
            _currentQuestionIndex++;

            LoadCurrentQuestion();
        }
        else
        {
            QuizResult result = new() {
                Score = Score,
                TotalQuestions = TotalQuestions
            };

            await Shell.Current.GoToAsync(
                nameof(ResultsPage),
                new Dictionary<string, object>
                {
                    ["Result"] = result
                });
        }
    }

    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}