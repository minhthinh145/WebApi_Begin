using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebApiStart.Data;
using WebApiStart.Models;
using WebApiStart.Repositories;

namespace WebApiStart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookRepository _bookrepo;

        public ProductsController(IBookRepository repo) 
        {
            _bookrepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks() 
        {
            try
            {
                return Ok(await _bookrepo.GetAllBooksAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
           var book = await _bookrepo.GetBookAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var _newBookId = await _bookrepo.AddBookAsync(model);
                var book = await _bookrepo.GetBookAsync(_newBookId);
                return book == null ? NotFound() : Ok(book);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookModel model) 
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _bookrepo.UpdateBookAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id) 
        {
            await _bookrepo.DeleteBookAsync(id);
            return Ok(); 
        }
    }
}
