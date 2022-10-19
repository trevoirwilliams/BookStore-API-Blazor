using MediatR;
using System.Collections.Generic;

namespace BookStore_API.Features.Book.Queries.FindAllBooks
{
    public class FindAllBooksQueryRequest:IRequest<IList<FindAllBooksQueryResponse>>
    {

    }
}
