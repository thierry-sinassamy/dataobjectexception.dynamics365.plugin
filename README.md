# dataobjectexception.dynamics365.plugin : aggregation and pipelines in D365

## Context and problem

In a CRM pipeline, all business rules are encapsulated in the same process, executing all business rules whareas we do not need.
The CRM Plugin pipeline should implement a strategy by separting the executing of the business rules from their execution rule. So, a rule validation would clarify when the business rule has to be executed.

## Solution

Regarding the problem, implementing design patterns regarding the CRM pipeline would be helpful.
Using Rule Pattern, Factory Pattern, Singleton Pattern, Dependency Injection help to separate the execution rules in CRM pipeline related to an entity from the rules validation.

![Dynamics365CodeArchitectureAndConcept](https://github.com/thierry-sinassamy/objectexception.dynamics365.plugin/blob/master/Dynamics365CodeArchitectureAndConcept.png)

## Issues and considerations


## When to use this pattern
