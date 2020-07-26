# r9-isbn-ci-dotnet

- Some tests against ISBN10 in place to verify azure devops build

- BookInfoProvider
  - Defines the Provider interface
  - Has the data object BookInfoProvider
  - Has an in-memory test double, ISBNService, that ISBNFinder can be tested against
  
- ISBN
  - ISBNFinder - the System Under test
  
- ISBN.tests
  - xUnit tests for the ISBNFinder class
