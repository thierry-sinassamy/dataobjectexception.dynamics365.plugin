using dataobjectexception.dynamics365.cqrs.registration.Result;

namespace dataobjectexception.dynamics365.cqrs.registration.Inversion
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        ResultValidation Handle(TCommand command);
    }
}
