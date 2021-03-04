using System.Threading.Tasks;
using Bogus;

namespace Echo.Blog.Features.About
{
    public partial class About
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
