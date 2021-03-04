using System;
using Microsoft.AspNetCore.Components;

namespace Echo.Blog.Layouts
{
    public partial class MainLayout
    {
        [Inject] public LayoutManager LayoutManager { get; set; } = null!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.LayoutManager.StateShouldChange += this.LayoutManagerOnStateShouldChange;
        }

        private async void LayoutManagerOnStateShouldChange(object? sender, EventArgs e)
        {
            await this.InvokeAsync(this.StateHasChanged);
        }
    }
}
