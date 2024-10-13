using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ForumContext(DbContextOptions<ForumContext> options) : DbContext(options)
{
    public DbSet<Question> Questions { get; set; }

}
