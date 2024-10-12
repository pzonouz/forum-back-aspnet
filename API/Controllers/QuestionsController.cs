using System.IO.Compression;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API
{
    // TODO: Implement Repository Pattern
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionsController(ForumContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetQuestions()
        {
            var users = await context.Questions.ToListAsync();
            if (users == null)
            {
                return NoContent();

            }
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await context.Questions.FirstOrDefaultAsync(x => x.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuestion([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            await context.Questions.AddAsync(question);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult> EditQuestion(int id, [FromBody] Question question)
        {
            question.Id = id;
            context.Questions.Entry(question).State = EntityState.Modified;
            if (await context.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            var question = await context.Questions.FirstOrDefaultAsync(x => x.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            context.Questions.Remove(question);
            if (await context.SaveChangesAsync() > 0)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
