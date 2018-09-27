# Setup

1. Make sure you have [.net core installed](https://www.microsoft.com/net/core) (it's open source and available on all major platforms)
2. Open the solution in either [Visual Studio](https://www.visualstudio.com/) or in [VS Code](https://code.visualstudio.com/)
3. Build the solution. It should auto-restore any nuget dependencies and successfully build.

## The Situation

A client has given us a file containing property data. We need to get this data into our system so we can begin collecting delinquent taxes for the client. The file is from a 1988 vintage IBM AS/400 which means it's a fixed column width text file with fields padded with trailing spaces for data shorter than the allotted width. The file consists of the following columns:

```
AccountNumber     9 characters
Address1          100 characters
Address2          100 characters
```

Each line in the file represents a delinquent property, with an account number and two address lines. Typically `address1` contains a street address such as _935 Gravier St_ and `address2` contains an apartment or suite number, if applicable, such as _Ste 1700_.

### Tasks

> Answer each of the questions in the pull request when you submit your solution.

1.	Parse the data. Parse each line into a new instance of the `Property` object. Put each instance you create into a list of properties (`List<Property>`) or an array (`Property[]`).

	**How many properties are in the file?**

2.	The implementation of `Property.IsApartment` is not complete. Right now it always returns `true`, but it should only return `true` if `Address2` contains text, which indicates an apartment or suite number is present. Modify `IsApartment` so that it returns `true` when there is a non-empty `string` in `Address2`, otherwise return `false`.

	**How many properties are apartments?**

3.	Implement `Property.District`. The first character of the account number is the district that the property is located in. Replace the implementation of `Property.District` with a new one that returns the first character of the account number.

	**How many properties are in the third district?**

4.	Implement `Property.IsOnStreet()`. Delete the `NotImplementedException` that is thrown and provide an implementation for this method that returns `true` if the street name is found in `Address1`. The method should do a case insensitive comparison. For example, if the `Property.Address1` is _935 GRAVIER ST_ then `Property.IsOnStreet("Gravier")` should return `true`. The method should also trim leading and trailing spaces from the `streetName` parameter. The method should throw an exception if `streetName` is `null` or empty.

	**How many properties are on Tchoupitoulas Street?**

### Testing

There is a test project called `Interview.Tests` in the solution with a single empty `PropertyTests` file. The project is using [xunit.net](https://xunit.github.io/) to run tests. You should be able to run the tests from Visual Studio or Visual Studio Code. Implement the following in the `PropertyTests.cs` file.

1. Add test cases to assert the logic is correct for `Property.IsApartment`.

2. Add test cases to assert the logic is correct for `Property.IsOnStreet()`.
