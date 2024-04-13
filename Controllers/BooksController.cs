using bookstore.DTO.Requests;
using bookstore.Entities;
using bookstore.Repositories;
using bookstore.Utils;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : BookstoreBaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Book>))]
    public IActionResult GetAll()
    {
        var bookRepository = BooksRepository.Instance;
        var books = bookRepository.GetAll();
        return Ok(books);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] string id)
    {
        var bookRepository = BooksRepository.Instance;
        var book = bookRepository.GetById(id);
        if (book is null)
            return NotFound();
        return Ok(book);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestCreateBookJson request)
    {
        if (request is null)
            return BadRequest();
        var gender = GenderUtils.GetEnumByName(request.Gender);
        if (gender is null)
            return BadRequest();
        var bookRepository = BooksRepository.Instance;
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Gender = (Gender) gender,
            Price = request.Price,
            Amount = request.Amount
        };
        bookRepository.Create(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] string id)
    {
        var bookRepository = BooksRepository.Instance;
        bookRepository.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] string id, [FromBody] RequestCreateBookJson request)
    {
        if (request is null)
            return BadRequest();
        var gender = GenderUtils.GetEnumByName(request.Gender);
        if (gender is null)
            return BadRequest();
        var bookRepository = BooksRepository.Instance;
        var book = bookRepository.GetById(id);
        if (book is null)
            return NotFound();
        
        book = new Book 
        {
            Title = request.Title,
            Author = request.Author,
            Gender = (Gender)gender,
            Price = request.Price,
            Amount = request.Amount
        };
        bookRepository.Update(book);
        return NoContent();
    }
}
