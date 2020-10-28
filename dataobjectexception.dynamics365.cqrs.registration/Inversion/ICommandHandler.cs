namespace dataobjectexception.dynamics365.cqrs.registration.Inversion
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
