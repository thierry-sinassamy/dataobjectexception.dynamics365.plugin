# dataobjectexception.dynamics365.plugin : aggregation and pipelines in D365

## Context and problem

In a CRM pipeline, all business rules are encapsulated in the same process, executing all business rules whareas we do not need.<br/>
The CRM Plugin pipeline should implement a strategy by separting the executing of the business rules from their execution rule. So, a rule validation would clarify when the business rule has to be executed.

## Solution

Regarding the problem, implementing design patterns regarding the CRM pipeline would be helpful.<br/>
Using Rule Pattern, Factory Pattern, Singleton Pattern, Dependency Injection help to separate the execution rules in CRM pipeline related to an entity from the rules of validation related to the same entity as well.<br/>
Moreover, all rules of validation could be aggregated regarding one process related to one entity, trigerring the business rule if needed.  

![Dynamics365CodeArchitectureAndConcept](https://github.com/thierry-sinassamy/objectexception.dynamics365.plugin/blob/master/Dynamics365CodeArchitectureAndConcept.png)

## Issues and considerations

Some challenges of implementing this separation include : <br/>
<br/>
-- Lifecycle of the objects : avoid stackoverflow, memory handling,...<br/>
-- Complexity : initialization of plugins will increase if we increase the number of entities,...<br/>
-- Performance : do not increase the initial performance of the plugins, not made for bulk operations,...<br/>

## When to use this pattern

Use this pattern to:<br/>
-- isolate the execution (process) from the execution rules or validation rules <br/>
-- to tag the execution rules with the messagename (i.e. Creation,...), with the pipeline stage (i.e PreOperation,...)<br/>

This pattern may not be suitable:<br/>
-- for small projects, for lesser degree of complexity<br/>
