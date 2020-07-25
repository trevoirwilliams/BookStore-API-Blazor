using Blazored.LocalStorage;
using BookStore_UI.WASM.Contracts;
using BookStore_UI.WASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStore_UI.WASM.Service
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public AuthorRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
