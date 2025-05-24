# Vilas Utils

`Vilas Utils` is a .NET utility library that provides a collection of methods for validating and processing text data. This includes validators for CPF numbers, emails, strong passwords, and a method for securely encrypting passwords.

## Installation

You can install the `Vilas.Utils.Text` package via NuGet:

```bash
Install-Package Vilas.Utils.Text
```
## Features

### Text Utilities  
- **CPF Validator**: Validates CPF numbers based on the Brazilian CPF format.  
- **Email Validator**: Verifies if an email address is in a valid format.  
- **Password Strength Validator**: Ensures that a password meets common security standards.  
- **Password Encryption**: Provides a method to securely encrypt passwords.  

### Data Utilities  
- **SQL CRUD Operations**: Simplifies database interactions with methods for:  
  - **Insert**  
  - **Update**  
  - **Select**  
  - **Delete**  

### Result<T> Class  
The `Result<T>` class is a generic utility for handling operation results, including success, failure, and error states.  

#### Properties  
- **`StatusCode`**: Represents the HTTP-like status code of the operation (e.g., 200 for success, 400 for bad request).  
- **`IsSuccess`**: Indicates whether the operation was successful.  
- **`Data`**: Holds the result data of the operation (if any).  
- **`Errors`**: A list of error messages associated with the operation.  
- **`ErrorMessageString`**: A concatenated string of all error messages, separated by semicolons.  

#### Methods  
- **`Ok(T data)`**: Marks the operation as successful and sets the result data.  
- **`Created(T data)`**: Marks the operation as successful with a 201 status code and sets the result data.  
- **`Conflict(string error)`**: Marks the operation as a conflict (409) and adds an error message.  
- **`NotFound(string error)`**: Marks the operation as not found (404) and adds an error message.  
- **`BadRequest(string error)`**: Marks the operation as a bad request (400) and adds an error message.  
- **`InternalServerError(string error)`**: Marks the operation as an internal server error (500) and adds an error message.  
- **`AddError(string error)`**: Adds an error message to the list of errors.  
- **`FromStatusCode(int statusCode, List<string> errors)`**: Sets the status code and error messages.  
  

## Installation

You can install the `VilasUtils` package via NuGet:

```bash
Install-Package VilasUtils
