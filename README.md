# Differences between dotnet isolated and in-process Azure functions when it comes to dependency injection

* Default DI resolver doesn't require all depdencies to be registered in .net **in-process** and if its not registered it injects a null
* Default DI resolver requires all dependencies to be registered in **isolated**, if a dependency is not registered then instantiation fails!!
