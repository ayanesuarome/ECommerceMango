using Microsoft.AspNetCore.Components;
using ECommerce.Mango.BlazorUI.Interfaces;
using ECommerce.Mango.BlazorUI.Models.Coupons;

namespace ECommerce.Mango.BlazorUI.Pages.Coupons;

public partial class Index
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private ICouponService CouponService { get; set; } = null!;

    private List<CouponVM> Coupons { get; set; } = null!;

    public string? Message { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Coupons = await CouponService.GetCouponListAsync();
    }
}
