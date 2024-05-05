namespace Domain.Entities.Base;

public class BaseEntity<TID>
{
    public TID ID { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}