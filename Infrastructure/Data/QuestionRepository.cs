using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class QuestionRepository(ForumContext context) : IQuestionRepository
{
    public void AddQuestion(Question question)
    {
        context.Add(question);
    }

    public void DeleteQuestion(Question question)
    {
        context.Questions.Remove(question);
    }

    public async Task<Question?> GetQuestionByIdAsync(int id)
    {
        return await context.Questions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Question>> GetQuestionsAsync()
    {
        return await context.Questions.ToListAsync();
    }

    public bool QuestionExists(int id)
    {
        return context.Questions.Any(x => x.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateQuestion(Question question)
    {
        context.Questions.Entry(question).State = EntityState.Modified;
    }
}
