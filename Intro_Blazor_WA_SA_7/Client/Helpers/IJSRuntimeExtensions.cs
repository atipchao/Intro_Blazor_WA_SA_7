using Microsoft.JSInterop;

namespace Intro_Blazor_WA_SA_7.Client.Helpers
{
    public static class IJSRuntimeExtensions
    {
        public static ValueTask SaveAs(this IJSRuntime js, string fileName, byte[] content)
        {
            return js.InvokeVoidAsync("saveFileAs", fileName, Convert.ToBase64String(content));
        }
    }
}
