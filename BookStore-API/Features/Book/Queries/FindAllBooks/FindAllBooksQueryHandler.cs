using AutoMapper;
using BookStore_API.Contracts;
using MediatR;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore_API.Features.Book.Queries.FindAllBooks
{
    public class FindAllBooksQueryHandler : IRequestHandler<FindAllBooksQueryRequest, IList<FindAllBooksQueryResponse>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public FindAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper, ILoggerService logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IList<FindAllBooksQueryResponse>> Handle(FindAllBooksQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"{request.Location}: Attempted Call");
            var books = await _bookRepository.FindAll();
            var booksModel = _mapper.Map<IList<FindAllBooksQueryResponse>>(books);
            _logger.LogInfo($"{request.Location}: Successful");
            return booksModel;
        }
    }
}
