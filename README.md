# CSharpSampleSolution
#### Intro
Sample C# Solution made with .NET Core and Standard. Why .NET Core?
- It's multi-platform: runs on Windows, Linux and MAC OS
- Could be self-hosted - you can start project directly from DLL file, without using any webserver - IIS or IISExpress. This is really good for integration tests.

What this solution do? Nothing much - Add, Subtract, Multiply and Divide two numbers :D.
And, also, calculates Factorial.

Purpose of this sample is to show:
- How to test your code with:
  - Unit tests (NUnit) for common business logic
  - Integration test (NUnit + RestSharp) for WebAPI
  - E2E (UI) tests for Web UI project
- How to set-up code analyzers - FxCop and StyleCop
- Reuse common library dll in other projects
- Work with AJAX forms in .NET Core web project
- Create and use Web API
- and more to be updated...

#### Details about Solution
Uses following frameworks, so make sure you have installed these SDKs:
- .NET Standard 2.0
  - Common
  - Common.Business
  - Tests.NUnit.Addons
- .NET Core 2.1. SDK 2.1.505 or newer will be good enough: https://dotnet.microsoft.com/download/dotnet-core/2.1
  - Web.API
  - Web.UI
  - Tests.*

Uses *FxCop v.2.6.3* which is intended for use with *Visual Studio **2017 v15.5 or later***.  
This Solution was made using *VS 2017 Community v15.9.5*
