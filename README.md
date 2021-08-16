Rocket_Elevators_REST_API
Repository for our REST API (week 8)

Versions
Microsoft.NET.Sdk.Web 5.0 Microsoft.EntityFrameworkCore 3.1.10 Microsoft.EntityFrameworkCore.Design 3.1.10 Microsoft.EntityFrameworkCore.Tools 3.1.10 Microsoft.EntityFrameworkCore.Tools.DotNet 2.0.3 Microsoft.VisualStudio.Web.CodeGeneration.Design 5.0.2 MySql.Data.EntityFrameworkCore 8.0.20 Swashbuckle.AspNetCore 5.6.3

Examples of queries for our REST API
https://rocketrestapi.azurewebsites.net/api/Batteries/1?status=Inactive -This PUT request will change the status of battery "1" to "Inactive". -If testing in Postman app the key would be "status" and the value "Inactive" -If using the browser, this would be correct syntax /{id}?{key}={value} where in the example id=1, key=status, value=Inactive.

https://rocketrestapi.azurewebsites.net/api/Batteries/1/status -This GET request will retrieve the status of battery "1".

https://rocketrestapi.azurewebsites.net/api/Batteries/1 -This GET request will retrieve all the info of battery "1".

https://rocketrestapi.azurewebsites.net/api/Columns/1/status -This GET request will retrieve the status of column "1".

https://rocketrestapi.azurewebsites.net/api/Columns/1?status=Inactive -This PUT request will change the status of column "1" to "Inactive". -If testing in Postman app the key would be "status" and the value "Inactive" -If using the browser, this would be correct syntax /{id}?{key}={value} where in the example id=1, key=status, value=Inactive.

https://rocketrestapi.azurewebsites.net/api/Elevators/1/status -This GET request will retrieve the status of elevator "1".

https://rocketrestapi.azurewebsites.net/api/Elevators/1?status=Intervention -This PUT request will change the status of elevator "1" to "Inactive". -If testing in Postman app the key would be "status" and the value "Intervention" -If using the browser, this would be correct syntax /{id}?{key}={value} where in the example id=1, key=status, value=Intervention.

https://rocketrestapi.azurewebsites.net/api/Elevators/NotActive -This GET request will retrieve all the elevators not in operation.

https://rocketrestapi.azurewebsites.net/api/Buildings/InterventionBuildings -This GET request will retrieve all the buildings with interventions.

https://rocketrestapi.azurewebsites.net/api/Leads/RecentLeads -This GET request will retrieve all the leads created in the last 30 days who have not yet become customers.
