namespace ECommerce.Mango.Services.CouponAPI.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public String? CreatedBy { get; set; }
    public DateTime DateModified { get; set; }
    public String? ModifiedBy { get; set; }
}
