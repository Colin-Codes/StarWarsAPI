# Star Wars API
C#, MVC, Entity Framework: Build an API according to specified challenge rules to handle Star Wars data

## Overview
See the challenge folder for details and initial data. Otherwise I have made use of the MVC and Entity Framework tooling to construct the API.

The challenge folder also contains an export of my Postman collection that I used to import all the data and test the API. Once imported, the 'Challenges' folder contains the requests against each Challenge, with examples.

If you don't have access to Postman, search the .json file for '"name": "Challenges"'. The each child of this node relates to a challenge objective, with examples satisfying the requirements listed in the 'response' element.

Most of the functionality of the code exists in the 'controllers' folder.

## Building the API
I have used the following tutorials to quickly build out MVC and Entity Framework functionality. 

https://docs.microsoft.com/en-us/dotnet/api/system.net.http.json.httpcontentjsonextensions?view=net-5.0

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-5.0

The first step was to build out the api in such a way that I could import the data easily with post requests, without having to significantly amend the original data. While it was easy to build out CRUD methods in the abstract APIController class, the format would need to be adapted when submittng and requesting data to and from the API. I achieved this using IStarWarsJSONConverter<Model> objects (FilmJSONConverter, CharacterJSONConverter etc.). Conversion to a model format is via the ToModel() method, and back into JSON via the constructor, by passing in a model.

## Assumptions
My comments below look beyond the scope of a code assignment and address how I would face the problem in a production environment

The format of the provided data is to be used going forward, the system should be able to handle data input and output in this format

Attributes of species such as hair colour do not need to be curated - new instances can be added simply by updating a species with a new instance of these attributes

## Achievements
The abstraction of all controllers into the APIController class makes the code much more easily maintainable - all CRUD functionality related to JSON objects is handled there, making it very easy to add new kinds of models (for instance, if we needed to start curating hairColor). The child classes can then be easily extended by adding or overriding methods or classes to allow for any reqired customisation (for example the ChallengeOutput class and List method of the FilmController class).

This was supported by the use of interfaces IStarWarsModel (IModel was taken) and IStarWarsJSONConverter, to enable the use of dependency injection (for instance in GetJSON) and generics (Model, JsonConverter).

In the process of completing this challenge, I actually learned Entity Framework from scratch. I had to overcome some subtle challenges, for instance I discovered that mapping objects (FilmCharacter, etc) do not automatically load with their parent objects.

Handling null data values proved easier than expected, Entity Framework interprets the ? mark after the type to allow null values on the DB side.

## Future developments
* The use of IStarWarsJSONConverter<Model> objects adds a layer of complexity and maintenance to the project that could be eliminated if the data were stored and transferred in a format more compatible with many-to-many mappings required to store the links between the objects. For instance, in the original data the list of filmIds is just that, a list of numbers representing the IDs of films. However, in order to make this compatible with the underlying models, this simple list must be converted to a list of objects like this (in this instance, FilmCharacter):

    "filmIds": [
                {
                "FilmId": 1,
                "CharacterId": 1
                },
                {
                "FilmId": 2,
                "CharacterId": 1
                },
            ],

However, if this were a vendor API, it is unlikely that this could be changed. In this scenario, it would be worth researching an alternative compatible method of storing many-to-many mappings. Alternatively, we could accept that the classes implementing IStarWarsJSONConverter<Model> perform a useful function and could be a valuable platform to add validation of data imports.

* Additionally, data objects often need to created and then updated, as the many-many mappings cannot be stored until the object exists in the database. This could be simply (albeit inefficiently) resolved by incorporating an update routine after the object is initially added. However, this doesn't prevent the scenario that the target object to join onto may not yet exist. Perhaps this could be resolved by removing some foreign key constraints, however this could introduce bugs further down the line if joined objects do not exist.

* The ToModel method of the IStarWarsJSONConverter<Model> classes could be DRY-er.

* There is very little validation present, apart from that present for challenge 2. For instance, objects can be added with fields missing, which means the object cannot then be retrieved.

* This project is currently small enough that manual testing using a service like Postman is sufficient. However, if I were to continue to maintain it I would begin to implement some unit tests.

* Validation (for the challenge at least) and mapping objects are implemented/linked in the IStarWarsJSONConverter<Model> classes. However, this would make more sense to occur at the Model level. That way, if the project were extended with alternative entry points in future, duplication of this code would not be required.

## Feedback
Challenges 3 - 5 would have made more sense to focus on other entities, as there are only 6 films in the data - other entities may better be able to demonstrate filtering and paging.
