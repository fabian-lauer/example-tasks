# Idea
The general approach is to use Visual Studio Code and create a webapi by using the template from dotnet.

`dotnet new webapi -o CSRestApiAnalyzeProductJson`

And now step by step :-)

1. Create data models for the JSON Input, so we can import to an objects structure that can be used e.g. by LINQ
2. Create a service to read the product json and a test controller - best with api-versioning (https://code-maze.com/aspnetcore-api-versioning/ + https://referbruv.com/blog/posts/integrating-aspnet-core-api-versions-with-swagger-ui)
3. Created a universal response object, so the single product-data is wrapped by a class having a datatype attribute. This makes it reusable e.g. for the respond all route
4. Extend product data model with some regex parsing to get the needed info in separate attributes for later usage (filtering)
5. Implement filtering and business logic


# Feedback / Notes
- Data structure in product.json not "atomic" - should be checked
- Further questions for proper implementation
    - expected load for testing - also caching
    - align on response dataformat and status-codes


