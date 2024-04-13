namespace bookstore.Entities;

public class Book
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }

}
