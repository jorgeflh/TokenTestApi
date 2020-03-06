# TokenTestApi

TokenTestApi is a test project that gets some customer data and generate a token based on them.

## Installation

This project uses .Net Core 3.0. If you don't have it, install from this link [dotnet](https://dotnet.microsoft.com/download)

Clone the project to your computer, go to TokenTestApi directory and enter:

```bash
dotnet run
```
This project could be use on Linux using Docker. For more details go to this link [docker](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-3.0)

## Usage

Open your browser and enter the address http://localhost:5000/swagger

On Swagger page you have two endpoints available.

You can use POST /api/Token/create to create a token passing a Card Number and a CVV number to it.

Then, use the registration date returned on the response and try to validate it on the endpoint POST /api/Token/validatetoken

## License
This project is licensed under the [MIT](LICENSE).
