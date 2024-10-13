using System;

namespace Core.Entities;

public class Question
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
}
