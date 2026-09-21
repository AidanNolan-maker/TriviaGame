using Microsoft.EntityFrameworkCore;
using TriviaGame.Data;

namespace TriviaGame;

public partial class App : Application {
    private readonly TriviaDbContext _dbContext;

    public App(TriviaDbContext dbContext) {
        InitializeComponent();

        _dbContext = dbContext;
    }

    protected override Window CreateWindow(IActivationState? activationState) {
        _dbContext.Database.EnsureCreated();

        TriviaDatabase database = new(_dbContext);
        database.SeedQuestionsAsync().GetAwaiter().GetResult();

        return new Window(new AppShell());
    }
}