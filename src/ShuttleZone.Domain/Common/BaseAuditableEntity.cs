namespace ShuttleZone.Domain.Common;

public class BaseAuditableEntity<T> : BaseEntity<T> where T : notnull
{
    public DateTime Created { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
