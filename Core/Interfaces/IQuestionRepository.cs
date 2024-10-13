using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IQuestionRepository
{
    Task<List<Question>> GetQuestionsAsync();
    Task<Question?> GetQuestionByIdAsync(int id);
    void AddQuestion(Question question);
    void UpdateQuestion(Question question);
    void DeleteQuestion(Question question);
    Task<bool> SaveChangesAsync();
    bool QuestionExists(int id);
}
