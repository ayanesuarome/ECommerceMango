using System.Net.Http;

namespace ECommerce.Mango.BlazorUI.Services.Coupons;

public partial class CouponClient : ICouponClient
{
    public HttpClient HttpClient => _httpClient;

    public CouponClient()
    {
        _httpClient = new HttpClient();
    }
}
