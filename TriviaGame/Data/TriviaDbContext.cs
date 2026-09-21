using Microsoft.EntityFrameworkCore;
using TriviaGame.Models;

namespace TriviaGame.Data;

public class TriviaDbContext : DbContext {
    public DbSet<Question> Questions => Set<Question>();

    public TriviaDbContext(DbContextOptions<TriviaDbContext> options)
        : base(options) {
    }
}