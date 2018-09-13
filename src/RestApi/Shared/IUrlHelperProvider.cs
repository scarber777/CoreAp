using Microsoft.AspNetCore.Mvc;

namespace RestApi.Shared
{
    public interface IUrlHelperProvider
    {
        IUrlHelper Url { get; }
    }
}