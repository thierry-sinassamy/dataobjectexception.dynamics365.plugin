using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;

namespace dataobjectexception.dynamics365.plugin.Process.Account
{
    public interface IProcessRuleDisplayAccountBusinessRule1 : IDynamics365Process<Dataobjectexception.Plugins.Models.Account>
    {
        IDynamics365Repository<Dataobjectexception.Plugins.Models.Account> AccountRepository { get; set; }
    }
}
