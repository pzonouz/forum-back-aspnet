using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // TODO: Implement Repository Pattern
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionsController(IQuestionRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetQuestions()
        {
            var users = await repo.GetQuestionsAsync();
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
            var question = await repo.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult> AddQuestion([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            repo.AddQuestion(question);
            if (await repo.SaveChangesAsync())
            {

                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateQuestion(int id, [FromBody] Question question)
        {
            question.Id = id;
            repo.UpdateQuestion(question);
            if (await repo.SaveChangesAsync())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            var question = await repo.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            repo.DeleteQuestion(question);
            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
