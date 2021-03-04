using System;
using Blazorise;

namespace Echo.Blog.Layouts
{
    public class LayoutManager
    {
        public bool PageLoading { get; private set; }

        public void ShowPageLoading()
        {
            this.PageLoading = true;
            this.StateShouldChange?.Invoke(this, EventArgs.Empty);
        }


        public event EventHandler? StateShouldChange;

        public void HidePageLoading()
        {
            this.PageLoading = false;
            this.StateShouldChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
