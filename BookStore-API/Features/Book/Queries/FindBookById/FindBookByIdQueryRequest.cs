using MediatR;

namespace BookStore_API.Features.Book.Queries.FindBookById
{
    public class FindBookByIdQueryRequest:IRequest<FindBookByIdQueryResponse>
    {
        public FindBookByIdQueryRequest(int id, string location)
        {
            Id = id;
            Location = location;
        }
        public int Id { get; set; }
        public string Location { get; set; }
    }
}
