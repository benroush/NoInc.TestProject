# NoInc.TestProject

## Overview
The NoInc.TestProject is intended to showcase my development capabilities. Following the back-end track for the project, I built out a REST API in .NET 5 (Core).

There are two options to test out the functionality of the NoInc.TestProject. The Azure hosted solution (Production) or compiling the solution in Visual Studio (Local).
[Here is a link](https://app.getpostman.com/join-team?invite_code=911a6fbefc98a883cf8be262cba46b4a) to the Postman team that you can join. In this Postman team, there 
is a collection of calls for the GET, POST, and DELETE for Interests and Skills. You'll find that [the data requested](https://github.com/benroush/FE-React-Evaluation/blob/master/src/dummy-data.js)
in this project has already been pre-populated. You can toggle the Postman environment to change where you would like to run the calls against (Production or Local). 

## Credentials
In any case, you will need credentials to access these endpoints as they are protected behind Basic Auth. These credentials are stored in the Postman collection but I have also shared them here.

Username = testuser  
Password = noinc

## Production
You can access the NoInc.TestProject swagger documention in production [here](https://noinctestproject.azurewebsites.net/swagger). If you want the API URI, that is https://noincapi.azure-api.net/

You can also use the aforementioned Postman to collection to access. CORS policy is set to allow any origin, so, you could also wire a front end to this if desired.

## Local
In order to run this project locally, you will need to [install Visual Studio 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16).
Then you will want to follow the below steps 
- Clone [the repository](https://github.com/benroush/NoInc.TestProject) to your local machine
- Unzip the folder and note it's destination
- In Visual Studio click File -> Open -> Project/Solution -> navigate to your unzipped repository and select NoInc.TestProject.sln.
- In Visual Studio press F5 to begin debugging, you should be presented with a local version of the Swagger page

You can now use the Swagger page, Postman, or any local application to connect the NoInc.TestProject API on http://localhost:3000
