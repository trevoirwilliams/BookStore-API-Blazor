using AutoMapper;
using BookStore_API.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore_API.Features.Book.Queries.FindAllBooks
{
    public class FindAllBooksQueryHandler : IRequestHandler<FindAllBooksQueryRequest, IList<FindAllBooksQueryResponse>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public FindAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IList<FindAllBooksQueryResponse>> Handle(FindAllBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.FindAll();
            var booksModel = _mapper.Map<IList<FindAllBooksQueryResponse>>(books);
            return booksModel;
        }
    }
}
