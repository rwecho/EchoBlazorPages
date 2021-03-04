using System.Threading.Tasks;
using Bogus;

namespace Echo.Blog.Features.Aticles
{
    public partial class Articles
    {
        private Faker Faker { get; } = new();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                return;
            }

        }
    }
}
