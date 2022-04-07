Usage: 
> clone to Visual Studio
 
Run this command in Package Manager Console:

> Update-Database

(Microsoft.EntityFrameworkCore.Sqlite and Microsoft.EntityFrameworkCore.Tools might have to be installed if that doesn't work)

Now it should be runnable 


Design:

For simplicity, I copied a CRUD template from the internet. Doors are represented as rows, with controls as checkboxes, configuration (add, delete) as buttons. The name can be changed in an input field.

Questions to the customer: Would you like different views for configuration, control? Is it possible to lock an open door or open a locked door? 

If I had 2 more hours: I would replace polling with real time updates with SignalR. Make the application look more like doors (e.g. style the checkboxes as door icons with animations).

