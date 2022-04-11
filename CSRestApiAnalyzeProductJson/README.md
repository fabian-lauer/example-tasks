# Intro
This is a task I had to do for a job interview.

# Task/Exercise
Create a simple C#/.NET Restful API service, that
- reads from any URL with JSON-Data a list of product data. The URL to read from is given below and contains mostly beers.
- has three different routes and questions to analyse the JSON-Data given.
   - Most expensive and cheapest beer per litre.
   - Which beers cost exactly €17.99? Order the result by price per litre (cheapest first).
   - Which one product comes in the most bottles?
   - It also has one route to get the answer to all routes or questions at once.
- Any result or output should be in JSON, too.

A route may look like this: /api/mostBottles?url=http://urlto/productData.json
However the structure and naming of the routes is up to you and also part of your task.

You may use any tools that you like to accomplish this task, including build/dependency management, IDE/editor, libraries, etc.
We should be able to build and run your project without needing to make any changes to it in a recent version of a typical developer’s environment.

The file for the JSON-Data is the following [ProductData.json](Docs/ProductData.json)

# Solution
The general coding solution is in this folder.
Additional thoughts and how I proceeded can be found in the file [SOLUTIONDETAILS.md](Docs/SOLUTIONDETAILS.md)

# Add-On
For a leading role this task had some additional questions.
They are handled in the file [LEADERQUESTIONS.md](Docs/LEADERQUESTIONS.md)