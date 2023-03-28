using AutoMapper;
using BookStore_API.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore_API.Features.Book.Queries.FindBookById
{
    public class FindBookByIdQueryHandler : IRequestHandler<FindBookByIdQueryRequest, FindBookByIdQueryResponse>
    {

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public FindBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper, ILoggerService logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FindBookByIdQueryResponse> Handle(FindBookByIdQueryRequest request, CancellationToken cancellationToken)
        {

            _logger.LogInfo($"{request.Location}: Attempted Call for id: {request.Id}");
            var book = await _bookRepository.FindById(request.Id);

            if(book is null)
            {
                _logger.LogWarn($"{request.Location}: Failed to retrieve record with id: {request.Id}");
                return new FindBookByIdQueryResponseMessage { ResponseMessage = "Not Found", StatusCode = StatusCodes.Status404NotFound };

            }
            _logger.LogInfo($"{request.Location}: Successfully got record with id: {request.Id}");
            return _mapper.Map<FindBookByIdQueryResponse>(book);
        }
    }
}
