using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Microsoft.Extensions.Logging;

namespace Echo.Blog.Services
{
    public class ArticlesService
    {
        private Faker Faker { get; }
        private ILogger<ArticlesService> Logger { get; }

        public ArticlesService(
            Faker faker,
            ILogger<ArticlesService> logger)
        {
            this.Faker = faker;
            this.Logger = logger;
        }

        public async Task<IReadOnlyList<Article>> GetArticles()
        {
           var articles = new Faker<Article>()
                .RuleFor(o=>o.Id, f=> Guid.NewGuid())
                .RuleFor(o=>o.Title, f=> f.Lorem.Sentence())
                .RuleFor(o=>o.Content, f=> f.Lorem.Paragraphs(10))
                .RuleFor(o=>o.CreationTime, f=> f.Date.Past())
                .Generate( 50);
           return articles.ToArray();
        }
     }

    public class Article
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] Tags { get; set; }


    }
}
