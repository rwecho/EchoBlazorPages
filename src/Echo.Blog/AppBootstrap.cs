using Echo.Blog.Layouts;
using Echo.Blog.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Echo.Blog
{
    public class AppBootstrap
    {
        public void Configure(IServiceCollection services)
        {
            services.AddTransient<AuthorService>();
            services.AddScoped<LayoutManager>();
        }
    }
}
