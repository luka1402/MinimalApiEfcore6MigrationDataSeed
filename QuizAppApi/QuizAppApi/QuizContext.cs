using Microsoft.EntityFrameworkCore;

namespace QuizAppApi;

    public class QuizContext : DbContext
    {

    public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

    public DbSet<Quiz> Quizs { get; set; }
            public DbSet<Categorie> Categories { get; set; }
            public DbSet<Countrie> Countries { get; set; }

        
}
