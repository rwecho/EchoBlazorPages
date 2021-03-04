using System;
using System.Threading.Tasks;
using Bogus;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Echo.Blog.Services
{
    public class AuthorService
    {
        private IMemoryCache MemoryCache { get; }
        private ILogger<AuthorService> Logger { get; }
        private Faker Faker { get; } = new();

        public AuthorService(
            IMemoryCache memoryCache,
            ILogger<AuthorService> logger)
        {
            this.MemoryCache = memoryCache;
            this.Logger = logger;
        }

        public Task<Author> GetAuthorAsync()
        {
            return this.MemoryCache.GetOrCreateAsync(nameof(this.GetAuthorAsync), e =>
            {
                e.SetOptions(new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });
                var author = new Author
                {
                    Avatar = this.Faker.Person.Avatar,
                    FullName = this.Faker.Person.FullName,
                    Introduction = this.Faker.Lorem.Paragraphs()
                };

                return Task.FromResult(author);
            });
        }
    }


    public class Author
    {
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string? Introduction { get; set; }
    }
}
