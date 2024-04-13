using bookstore.Entities;
using Microsoft.OpenApi.Services;

namespace bookstore.Repositories;

public class BooksRepository
{
    public static BooksRepository Instance { get; } = new BooksRepository();
    private readonly List<Book> _books =
    [
        new Book { Id = Guid.NewGuid().ToString(), Title = "The Hobbit", Author = "Tolkien", Gender = Gender.Fantasy, Price = 49.99m, Amount = 10 },
        new Book { Id = Guid.NewGuid().ToString(), Title = "Lord of the rings: The fellowship of ring", Author = "Tolkien", Gender = Gender.Fantasy, Price = 39.99m, Amount = 19},
        new Book { Id = Guid.NewGuid().ToString(), Title = "Lord of the rings: Two towers", Author = "Tolkien", Gender = Gender.Fantasy, Price = 59.99m, Amount = 16},
        new Book { Id = Guid.NewGuid().ToString(), Title = "Lord of the rings: The return of the king", Author = "Tolkien", Gender = Gender.Fantasy, Price = 99.99m, Amount = 13},
    ];

    private BooksRepository() { }

    public List<Book> GetAll()
    {
        return _books;
    }

    public Book? GetById(string id)
    {
        return _books.Find(book => book.Id == id);
    }

    public void Create(Book book)
    {
        book.Id = Guid.NewGuid().ToString();
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var index = _books.FindIndex(b => b.Id.Equals(book.Id));
        _books[index] = book;
    }

    public void Delete(string id)
    {
        var book = _books.Find(b => b.Id.Equals(id));
        if (book is not null)
            _books.Remove(book);
    }
}
