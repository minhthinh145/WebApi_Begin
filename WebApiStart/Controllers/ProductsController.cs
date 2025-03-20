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
    }
}
