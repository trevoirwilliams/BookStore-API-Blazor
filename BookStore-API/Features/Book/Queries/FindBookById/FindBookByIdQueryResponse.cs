using BookStore_API.DTOs;

namespace BookStore_API.Features.Book.Queries.FindBookById
{
    public class FindBookByIdQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public string File { get; set; }
        public int? AuthorId { get; set; }
        public virtual AuthorDTO Author { get; set; }
    }

    public class FindBookByIdQueryResponseMessage: FindBookByIdQueryResponse
    {
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
