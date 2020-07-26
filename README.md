# r9-isbn-ci-dotnet

[![Build Status](https://dev.azure.com/paul0287/CSD-CI-exercise-csharp/_apis/build/status/paul-r9.CSD-CI-exercise-csharp?branchName=trunk)](https://dev.azure.com/paul0287/CSD-CI-exercise-csharp/_build/latest?definitionId=6&branchName=trunk)

[Azure DevOps Project page](https://dev.azure.com/paul0287/CSD-CI-exercise-csharp)



- Some tests against ISBN10 in place to verify azure devops build

- BookInfoProvider
  - Defines the Provider interface
  - Has the data object BookInfoProvider
  - Has an in-memory test double, ISBNService, that ISBNFinder can be tested against
  
- ISBN
  - ISBNFinder - the System Under test
  
- ISBN.tests
  - xUnit tests for the ISBNFinder class
  
- Add code coverage metrics to CI build
  - See the following links
  - (https://docs.microsoft.com/en-us/azure/devops/pipelines/test/review-code-coverage-results?view=azure-devops)
  - (https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/test/publish-code-coverage-results?view=azure-devops)

 
