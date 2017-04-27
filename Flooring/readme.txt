FlooringCompany

Project @ software guild

A console application built in C#. It function as an order tracking system. User has the ability to do basic CRUD operation:

Create Order
View List of Order
Update exisiting Order
Delete Order
Project Highlight:

Unit Testing: Each layer (exclude UI) are tested. Test tool used : Nunit.
N-Tier: Proper separation of responsibility. Data, Model, Business Logic, UI
Dependency injection: Interface was used to switch between Mock Repo (static memory) and Production Repo (File Read). Ninject was used.
