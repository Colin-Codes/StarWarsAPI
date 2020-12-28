# Star Wars API
See the challenge folder for details and initial data

## Building the API
I have used the following tutorials to quickly build out MVC and Entity Framework functionality, upon which to construct the API. 
https://docs.microsoft.com/en-us/dotnet/api/system.net.http.json.httpcontentjsonextensions?view=net-5.0
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-5.0

The first step was to construct the api in such a way that I could import the data easily with post requests, without having to significantly amend the original data. All that is required is to use square brackets '[]' at the start and end, so that the api can de-serialize as a list.

## Assumptions
My comments below look beyond the scope of a code assignment and address how I would face the problem in a production environment
That the format of the data is to be used going forward, the system should be able to handle data input and output in this format

## Achievements
The abstraction of all controllers into the APIController class makes the code much more easily maintainable, new classes can easily be added simply by inheriting from it. The child classes can then be easily extended to allow for any reqired customisation.

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

Additionally, data objects often need to created and then updated, as the many-many mappings cannot be stored until the object exists in the database. This could be simply (albeit inefficiently) resolved by incorporating an update routine after the object is initially added. 