using bookstore.Entities;

namespace bookstore.DTO.Requests;

public class RequestCreateBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Amount { get; set; }

}
