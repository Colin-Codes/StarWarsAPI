# Star Wars API
C#, MVC, Entity Framework: Build an API according to specified challenge rules to handle Star Wars data

## Quickstart
See the challenge folder for details and initial data
The challenge folder also contains an export of my Postman collection that I used to import all the data and test the API. Once imported, the 'Challenges' folder contains the requests against each Challenge, with examples.

## Building the API
I have used the following tutorials to quickly build out MVC and Entity Framework functionality, upon which to construct the API. 
https://docs.microsoft.com/en-us/dotnet/api/system.net.http.json.httpcontentjsonextensions?view=net-5.0
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-5.0

The first step was to construct the api in such a way that I could import the data easily with post requests, without having to significantly amend the original data. All that was required ultimately was to use square brackets '[]' at the start and end, so that the api can de-serialize as a list.

## Assumptions
My comments below look beyond the scope of a code assignment and address how I would face the problem in a production environment
The format of the provided data is to be used going forward, the system should be able to handle data input and output in this format
Attributes of species such as hair colour do not need to be curated - new instances can be added simply by updating a species with a new instance of these attributes

## Achievements
The abstraction of all controllers into the APIController class makes the code much more easily maintainable, new classes can easily be added simply by inheriting from it. The child classes can then be easily extended by overriding methods to allow for any reqired customisation.
In the process of completing this challenge, I actually learned Entity Framework from scratch. This included some significant gotchas, for instance mapping objects do not load with their parent objects

## Future developments
The use of IStarWarsJSONConverter<Model> objects adds a layer of complexity and maintenance to the project that could be eliminated if the data were stored and transferred in a format more compatible with many-to-many mappings required to store the links between the objects. For instance, in the original data the list of filmIds is just that, a list of numbers representing the IDs of films. However, in order to make this compatible with the underlying models, this simple list must be converted to a list of objects like this (in this instance, FilmCharacter):

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

However, if this were a vendor API, it is unlikely that this could be changed. In this scenario, it would be worth researching an alternative compatible method of storing many-to-many mappings. Alternatively, we could accept that the classes implementing IStarWarsJSONConverter<Model> perform a useful function and would be a valuable platform to add validation of data imports.

Additionally, data objects often need to created and then updated, as the many-many mappings cannot be stored until the object exists in the database. This could be simply (albeit inefficiently) resolved by incorporating an update routine after the object is initially added. However, this doesn't prevent the scenario that the target object to join onto may not yet exist. Perhaps this could be resolved by removing some foreign key constraints, however this could introduce bugs further down the line if joined objects do not exist.

The ToModel method of the IStarWarsJSONConverter<Model> classes could be DRY-er.

There is very little validation present, apart from that present for challenge 2. For instance, objects can be added with fields missing, which means the object cannot then be retrieved.

## Feedback
Challenges 3 - 5 would have made more sense to focus on other entities, as there are only 6 films in the data - other entities may better be able to demonstrate filtering and paging.
