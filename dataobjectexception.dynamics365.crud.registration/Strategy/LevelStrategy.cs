using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Level;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;

namespace dataobjectexception.dynamics365.crud.registration.Strategy
{
    public class LevelStrategy
    {
        private GradationStrategy gradationStrategy;

        public Root<PluginAssembly> InstanciateStrategy(Arguments arguments)
        {
            if (arguments.Equals(""))
            {
                gradationStrategy = new LevelPluginAssembly();                
            }
            else if (arguments.Equals(""))
            {
                gradationStrategy = new LevelPluginType();                
            }
            else if (arguments.Equals(""))
            {
                gradationStrategy = new LevelPluginStep();               
            }
            else
            {
                gradationStrategy = new LevelPluginTypeStepImage();               
            }
            return gradationStrategy.Level(null); //todo
        }
    }
}
