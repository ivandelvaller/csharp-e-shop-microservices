namespace Catalog.API.Models;

public class BaseModel
{
    public string CreatedAt { get; set; }

    public string UpdatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public bool Active { get; set; } = false;
}