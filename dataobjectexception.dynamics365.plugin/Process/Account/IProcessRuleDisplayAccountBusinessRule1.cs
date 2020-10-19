using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;

namespace dataobjectexception.dynamics365.plugin.Process.Account
{
    public interface IProcessRuleDisplayAccountBusinessRule1 : IDynamics365Process<dataobjectexception.dynamics365.Entities.Account>
    {
        IDynamics365Repository<dataobjectexception.dynamics365.Entities.Account> AccountRepository { get; set; }
    }
}
