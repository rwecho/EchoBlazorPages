using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Echo.Blog.Features.Home
{
    public partial class Home: IDisposable
    {
        [Inject] private ILogger<Home> Logger { get; set; } = null!;

        private string? Message { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.OnAfterRender)}");

            base.OnAfterRender(firstRender);
            Thread.Sleep(100);

            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.OnAfterRender)}");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.Logger.LogInformation($"{this.GetHashCode()} Entering first {nameof(this.OnAfterRenderAsync)}");
                await Task.Delay(100).ConfigureAwait(false);
                this.Logger.LogInformation($"{this.GetHashCode()} Exiting first {nameof(this.OnAfterRenderAsync)}");
            }
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.OnAfterRenderAsync)}");
            await Task.Delay(100).ConfigureAwait(false);
            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.OnAfterRenderAsync)}");
        }

        protected override void OnInitialized()
        {
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.OnInitialized)}");
            base.OnInitialized();
            Thread.Sleep(100);
            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.OnInitialized)}");

        }

        protected override async Task OnInitializedAsync()
        {
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.OnInitializedAsync)}");
            await Task.Delay(100).ConfigureAwait(false);
            // this.Message = "Hello world";
            var a = this.Message;

            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.OnInitializedAsync)}");
        }

        protected override void OnParametersSet()
        {
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.OnParametersSet)}");
            base.OnParametersSet();
            var a = this.Message;
            Thread.Sleep(100);
            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.OnParametersSet)}");
        }

        protected override async Task OnParametersSetAsync()
        {
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.OnParametersSetAsync)}");
            await Task.Delay(100).ConfigureAwait(false);
            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.OnParametersSetAsync)}");
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.SetParametersAsync)}");
            await base.SetParametersAsync(parameters);
            await Task.Delay(100);

            this.Message = "123";
            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.SetParametersAsync)}");
        }

        public void Dispose()
        {
            this.Logger.LogInformation($"{this.GetHashCode()} Entering {nameof(this.Dispose)}");
            Thread.Sleep(100);
            this.Logger.LogInformation($"{this.GetHashCode()} Exiting {nameof(this.Dispose)}");

            this.Logger.LogInformation("========================Disposed=======================");
        }
    }
}
