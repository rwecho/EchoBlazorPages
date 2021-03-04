using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Echo.Blog.Layouts;
using Echo.Blog.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Echo.Blog.Features.Home
{
    public partial class Home
    {
        [Inject] private ILogger<Home> Logger { get; set; } = null!;

        [Inject] private ArticlesService ArticlesService { get; set; } = null!;

        [Inject] private LayoutManager LayoutManager { get; set; } = null!;

        private  IReadOnlyList<Article>? Articles { get; set; }
        protected override async  Task OnInitializedAsync()
        {
            this.Articles = await this.ArticlesService.GetArticles();
        }
    }
}
