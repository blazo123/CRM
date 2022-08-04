using Microsoft.AspNetCore.Components;

namespace CRM.Helpers
{
    public class ConfirmBase : ComponentBase
    {
        public bool ShowConfirmation { get; set; }

        public void Show() 
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }

    }
}
