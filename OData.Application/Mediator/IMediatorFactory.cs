namespace OData.Application.Mediator;

public interface IMediatorFactory
{
    IMediatorScope CreateScope();
}