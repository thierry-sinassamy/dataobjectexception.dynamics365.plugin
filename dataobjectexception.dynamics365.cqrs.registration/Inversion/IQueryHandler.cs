namespace dataobjectexception.dynamics365.cqrs.registration.Inversion
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
