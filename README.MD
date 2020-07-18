# Solution by Marco de Freitas

## Development notes

Despite not developing in React for 2 years now I have decided to use this approach after analyzing both dotnet core templates, react and reactredux.
Although I believe with Redux I would achieve better separation of concerns, because it uses TypeScript it would turn out to be an impediment.
By using React alone I could achieve a workable version despite not being able to extract some logic from the components because they are state dependent. Extracting the ClientApp to its own project turned out for the worst so it is left inside the Api project. Last but not least I'm a C# Windows user and I developed the code on VS Code + Visual Studio for Mac since my Mac doesn't have Windows. I still think Visual Studio on Windows gives us the best tooling experience and I wasn't wrong, this took me a while to adapt and deliver a workable version.

### Client App

UI is not my strongest skill, as descrived above, I haven't practiced React in 2 years so I've made what I thought would be a working version of the FE with minimum effort besides the effort of re-learning React again. It should have a better UI, it is not exactly how I wanted it to be but it is how I could create using my own skills.

### API

The API is very simple, one endpoint to get addresses that validates post codes using a NuGet package. Validation of the query parameters is done by usage of [ApiController] attribute, it simplifies code, the controller only validates the post code and requests the service to fulfill the request. No validation was added to house number since we can request addresses with post code alone to give us more results.

### Unit tests

After analyzing the code I've identified 2 possible SUTs: the distance calculator and the web service HTTP client. The value of adding tests to these 2 would be low, in my opion, so I've left tests out.
The possible tests that would turn out to have value would be integration tests but that would require a little extra work to mock the HTTP client requests to not hit the working web service.
On the Client App I didn't perform any unit tests because the component contains code that should be extracted into its own files and I wasn't able to achieve it.