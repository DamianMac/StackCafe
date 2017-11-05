namespace StackCafe.Catalog
{
    public interface IRequestHandler<in TRequest>
    {
        object Handle(TRequest command);
    }
}
