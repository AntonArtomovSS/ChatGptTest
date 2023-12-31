# REST Countries API Integration

The RestCountriesIntegration application serves as an interface to an extensive dataset of country information. Designed as a .NET Web API, its primary purpose is to allow users to query detailed information about countries from an external source, which in this case is the renowned REST Countries API.

The application stands as an intermediary, fetching, processing, and presenting data in a structured manner, while also offering users the flexibility to filter, sort, and paginate the results. This design ensures the application's versatility, making it an invaluable tool for tasks ranging from research to application development that requires comprehensive country-related data. The API's richness in offering detailed country data positions it as a go-to source for obtaining well-structured and filtered information about countries globally.

## How to Run Locally

To run the RestCountriesIntegration application locally, follow the steps below:

1. Ensure you have the .NET SDK installed. You can download it from the official .NET website.
2. An appropriate IDE, preferably Visual Studio or Visual Studio Code, for development and debugging.
3. Clone the Repository: If the project is in a version control system, clone it to your local machine. For example, using Git:

`git clone httpss://github.com/AntonArtomovSS/ChatGptTest.git`

4. Navigate to the Project Folder:

`cd [path-to-project-folder]`

5. Restore NuGet Packages. This will ensure that all the necessary packages and dependencies are installed:

`dotnet restore`

6. Check if the application builds successfully. If not, you should investigate the build errors:

`dotnet build`

7. Run the Application:

`dotnet run`

Once the application is running, you can access it via a web browser or a tool like Postman at: https://localhost:7046/countries. Adjust the port if you've set up a different one in your configurations.

Also don't forget that the application communicates with the RestCountries API. Ensure you have internet connectivity.

Once you've completed these steps, you should have the application running and can start interacting with the provided endpoints.

## Endpoint Usage Examples

1. Fetch All Countries:

`curl -Uri "https://localhost:7046/countries" -UseBasicParsing`

2. Filter by Country Name:

`curl -Uri "https://localhost:7046/countries?nameFilter=Canada" -UseBasicParsing`

3. Filter by Population in Millions:

`curl -Uri "https://localhost:7046/countries?minPopulationInMillionsFilter=4" -UseBasicParsing`

4. Sort Countries by Name (Ascending):

`curl -Uri "https://localhost:7046/countries?sortingDirection=ascend" -UseBasicParsing`

5. Sort Countries by Name (Descending):

`curl -Uri "https://localhost:7046/countries?sortingDirection=descend" -UseBasicParsing`

6. Limit Results with Page Size:

`curl -Uri "https://localhost:7046/countries?pageSize=10" -UseBasicParsing`

7. Filter by Country Name and Population:

`curl -Uri "https://localhost:7046/countries?nameFilter=United&minPopulationInMillionsFilter=10" -UseBasicParsing`

8. Combine All Filters:

`curl -Uri "https://localhost:7046/countries?nameFilter=United&minPopulationInMillionsFilter=20&sortingDirection=descend&pageSize=5" -UseBasicParsing`

9. Fetch First 20 Countries Sorted by Name in Descending Order:

`curl -Uri "https://localhost:7046/countries?sortingDirection=descend&pageSize=20" -UseBasicParsing`

10. Fetch Countries Starting with 'A' in Ascending Order:

`curl -Uri "https://localhost:7046/countries?nameFilter=A&sortingDirection=ascend" -UseBasicParsing`

These examples show the flexibility and capabilities of the endpoint to fetch, filter, sort, and paginate country data.