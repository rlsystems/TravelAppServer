namespace ServerApp.Domain.Contracts;

public interface IIdentityTenant
{
    public string Tenant { get; set; }
}