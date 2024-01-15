using Blazored.LocalStorage;
using ECommerce.Mango.BlazorUI.Services.Coupons;
using System.Net;
using System.Net.Http.Headers;

namespace ECommerce.Mango.BlazorUI.Services.Base;

public abstract class BaseHttpService(ILocalStorageService localStorage)
{
    protected readonly ILocalStorageService _localStorage = localStorage;

    protected const string StorageKey = "token";

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
    {
        return exception.StatusCode switch
        {
            ((int)HttpStatusCode.BadRequest) =>
                new Response<Guid>()
                {
                    Message = "Invalid data was submitted.",
                    ValidationErrors = exception.Response,
                    Success = false
                },
            ((int)HttpStatusCode.NotFound) =>
                new Response<Guid>()
                {
                    Message = "The record was not found.",
                    Success = false
                },
            _ =>
                new Response<Guid>()
                {
                    Message = "Something went wrong, please try again later.",
                    Success = false
                }
        };
    }

    protected async Task AddBearerToken(IClient client)
    {
        bool isTokenInLocalStorage = await _localStorage.ContainKeyAsync(StorageKey);

        if (isTokenInLocalStorage)
        {
            string token = await _localStorage.GetItemAsync<string>(StorageKey);
            client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
