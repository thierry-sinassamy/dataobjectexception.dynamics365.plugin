using dataobjectexception.dynamics365.crud.registration.Result;
using Microsoft.Xrm.Sdk.Client;

namespace dataobjectexception.dynamics365.crud.registration.Inversion
{
    public interface IRule
    {
        ResultValidation RuleProcessingObject(OrganizationServiceProxy Service, int Parameter);
    }
}
