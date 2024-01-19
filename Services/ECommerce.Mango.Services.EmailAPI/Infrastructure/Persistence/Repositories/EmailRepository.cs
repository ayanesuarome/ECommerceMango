using ECommerce.Mango.Services.EmailAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.EmailAPI.Core.Domain.Interfaces;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence.Services;

public class EmailRepository(IDbContextFactory<EmailDbContext> factory) : IEmailRepository
{
    private readonly IDbContextFactory<EmailDbContext> _factory = factory;

    public async Task InsertEmailAsync(EmailLogger email)
    {
        try
        {
            using EmailDbContext dbContext = _factory.CreateDbContext();
            email.Id = Guid.NewGuid();
            email.Uid = email.Id.ToString();
            dbContext.Add(email);
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<EmailLogger> LoadEmailAsync(string uid)
    {
        using EmailDbContext dbContext = factory.CreateDbContext();
        return await dbContext.EmailLoggers
                .WithPartitionKey(uid)
                .SingleOrDefaultAsync(d => d.Uid == uid);
    }
}
