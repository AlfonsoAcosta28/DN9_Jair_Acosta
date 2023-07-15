using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webcores.Example.Client.Areas.Identity.Data;

namespace Webcores.Example.Client.Data;

public class WebcoresExampleClientContext : IdentityDbContext<WebcoresExampleClientUser>
{
    public WebcoresExampleClientContext(DbContextOptions<WebcoresExampleClientContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
