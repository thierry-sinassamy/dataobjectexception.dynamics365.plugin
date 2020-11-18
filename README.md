# dataobjectexception.dynamics365.plugin : aggregation and pipelines in D365

##Context and problem


##Solution

Design pattern regarding the pipelines of dynamics 365 Plugins
- Using Dependency Injection with IServiceContainer
- Using Rule Pattern to handle the instanciation and the execution of the D365 pipeline
- Using Rule Pattern and Factory Pattern to handle the instanciation and the execution of the D365 processes or actions (related to the rules)
- Using Repository Pattern to inject the Dynamics 365 context (CRM services, CRM plugin execution context...)
- Using Singleton Pattern to handle one instance of the container

![Dynamics365CodeArchitectureAndConcept](https://github.com/thierry-sinassamy/objectexception.dynamics365.plugin/blob/master/Dynamics365CodeArchitectureAndConcept.png)

##Issues and considerations


##When to use this pattern
