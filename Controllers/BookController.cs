using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")] 

        public async Task<IActionResult> GetAllBooksAsync()
        {
            var records = await _bookRepository.GetAllBooksAsync();
            return Ok(records);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllBookBYIDAsync([FromRoute] int Id)
        {
            var book = await _bookRepository.GetBooKById(Id); 
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewBooks([FromBody] BookModel model)
        {
            var Id = await _bookRepository.AddBooKs(model);

            return Ok(Id);
              //  CreatedAtAction(nameof(GetAllBookBYIDAsync), new { id = Id, controller = "Books" },Id);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBookDetailsAsync( [FromRoute] int Id, [FromBody] BookModel model)
        {
             await _bookRepository.UpdateBooKDetailsAsync(Id, model);

            return Ok(Id);
            //  CreatedAtAction(nameof(GetAllBookBYIDAsync), new { id = Id, controller = "Books" },Id);
        }


        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateBookPatchAsync([FromRoute] int Id, [FromBody] JsonPatchDocument model)
        {
            await _bookRepository.UpdateBooKPatchAsync(Id, model);

            return Ok(Id);
            //  CreatedAtAction(nameof(GetAllBookBYIDAsync), new { id = Id, controller = "Books" },Id);
        }

        //[HttpDelete("{Id}")]
        //public async Task<int> DeleteBookAsync([FromRoute] int Id)
        //{
        //  var delete =  await _bookRepository.DeleteBookAsync(Id);

        //    return delete;
        //    //  CreatedAtAction(nameof(GetAllBookBYIDAsync), new { id = Id, controller = "Books" },Id);
        //}

        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> DeleteBookById([FromRoute] int Id)
        //{
        //     await _bookRepository.DeleteBookById(Id);

        //    return Ok();
        //    //  CreatedAtAction(nameof(GetAllBookBYIDAsync), new { id = Id, controller = "Books" },Id);
        //}
    }
}
