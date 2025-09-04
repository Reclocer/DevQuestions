using DevQuections.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestion.Infrastructure.PostgresSql;

public class QuestionsDbContext: DbContext
{
    public DbSet<Question> Questions { get; set; }
}