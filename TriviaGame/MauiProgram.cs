using Microsoft.EntityFrameworkCore;
using TriviaGame.Data;
using Microsoft.Extensions.Logging;

namespace TriviaGame
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            string databasePath = Path.Combine(
                FileSystem.AppDataDirectory,
                "trivia.db3");

            builder.Services.AddDbContext<TriviaDbContext>(options =>
                options.UseSqlite($"Data Source={databasePath}"));

            builder.Services.AddScoped<TriviaDatabase>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
