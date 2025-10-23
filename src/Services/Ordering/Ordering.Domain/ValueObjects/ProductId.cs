namespace Ordering.Domain.ValueObjects;

public record ProductId(Guid Value)
{
    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("Product Id cannot be empty");

        return new ProductId(value);
    }
}