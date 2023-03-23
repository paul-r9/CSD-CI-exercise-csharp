# r9-isbn-ci-csharp

[![Build Status](https://dev.azure.com/paul0287/CSD-CI-exercise-csharp/_apis/build/status/paul-r9.CSD-CI-exercise-csharp?branchName=trunk)](https://dev.azure.com/paul0287/CSD-CI-exercise-csharp/_build/latest?definitionId=6&branchName=trunk)

[Azure DevOps Project page](https://dev.azure.com/paul0287/CSD-CI-exercise-csharp)



- Some tests against ISBN10 are in place to verify Azure DevOps build

**Project Files**

- BookInfoProvider
  - Defines the Provider interface
  - Has the data object BookInfoProvider
  - Has an in-memory test double, ISBNService, that ISBNFinder can be tested against
  
- ISBN
  - ISBNFinder - the System Under test
  
- ISBN.tests
  - xUnit tests for the ISBNFinder class
  
 **TODO** 
  
  - [x] Fix the failing test

**Breakout 2**
  - [ ] Improve the ISBN10Tests
  -  [ ] Validate ISBN10 checksum before lookup

**Breakout 1**
  - [ ] Create an ISBN13Test file
  - [ ] Deal with hyphens
  - [ ] Deal with spaces
  - [ ] Ensure exactly 13 digits
  - [ ] Lookup a valid 13 digit code and return BookInfo
  - [ ] Return Null Object for invalid ISBN
  - [ ] Validate the checksum is correct before lookup
  
   
- [ ] Add code coverage metrics to CI build
  - See the following links
  - [Review Code Coverage Results](https://docs.microsoft.com/en-us/azure/devops/pipelines/test/review-code-coverage-results?view=azure-devops)
  - [Publish Code Coverage Results](https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/test/publish-code-coverage-results?view=azure-devops)

 
