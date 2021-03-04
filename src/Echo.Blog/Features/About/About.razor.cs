using System.Threading.Tasks;
using Echo.Blog.Layouts;
using Echo.Blog.Services;
using Microsoft.AspNetCore.Components;

namespace Echo.Blog.Features.About
{
    public partial class About
    {
        private Author? Author { get; set; }

        [Inject] private AuthorService AuthorService { get; set; } = null!;
        [Inject] public LayoutManager LayoutManager { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);
            var author = await this.AuthorService.GetAuthorAsync();
            this.Author = author;
        }
    }
}
