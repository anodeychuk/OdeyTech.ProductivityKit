# OdeyTech.ProductivityKit

**OdeyTech.ProductivityKit** is a C# .NET library designed to boost your productivity by providing an extensive set of tools, extensions, and utilities that simplify your day-to-day development tasks. This package is distributed as a NuGet package and can be easily integrated into your projects, saving you time and effort.

## Features

1. **Extensions**: The library provides a collection of extension methods organized under the `OdeyTech.ProductivityKit.Extension` namespace, enhancing the functionality of existing .NET types:
    - **CharExtension**: Includes methods like `IsDigit` and `IsLetter` to facilitate working with characters.
    - **DictionaryExtension**: Provides extension methods for Dictionary collections.
    - **IEnumerableExtension**: Offers useful methods like `ForEach`, `IsFilled`, and `IsNullOrEmpty` to streamline working with collections.
    - **IntExtension**: Provides extension methods for `int` objects related to `DateTime`, such as `January`, `February`, `March`, etc., for easy creation of `DateTime` objects.
    - **StringExtension**: Contains methods like `Format`, `IsNullOrEmpty`, and `IsFilled` to improve the handling of strings.
2. **Enums**: The library provides a collection of standard enumerations under the `OdeyTech.ProductivityKit.Enum` namespace to promote consistent naming across your application.
3. **Monads**: The `Monads` class in the `OdeyTech.ProductivityKit` namespace contains utility methods for working with monads and simplifying null checking. Methods such as `If`, `Do`, `DoIfNotNull`, and `Return` are available to work with nullable objects and execute actions or evaluators based on the object's null status.
4. **Reflection**: `OdeyTech.ProductivityKit` simplifies working with reflection, enabling easier access to object properties and methods.
5. **File Handling**: Streamline your file management tasks with built-in utilities to create, read, and manipulate files with ease.
6. **Build Information**: Retrieve and display build data, such as version number and build date, to keep track of your project's progress.
7. **Readability**: Improve the readability of your code by leveraging utility classes and methods designed to make your code cleaner and more maintainable.

## Examples

Detailed examples of how to use the features of **OdeyTech.ProductivityKit** can be found in the [OdeyTech.WPF.Example.Hospital repository][Example] repository.

### Highlight: DictionaryExtension

The `DictionaryExtension` class is a part of the `OdeyTech.ProductivityKit.Extension` namespace and provides extension methods for Dictionary collections.

Example usage:

~~~csharp
// Create a dictionary of users with their ages
Dictionary<string, int> usersWithAges = new Dictionary<string, int>
{
    { "Alice", 25 },
    { "Bob", 31 },
    { "Charlie", 40 },
    { "David", 18 },
    { "Eve", 29 }
};
// Remove users with age greater than 30 from the dictionary
usersWithAges.RemoveWhere(item => item.Value > 30);
~~~

### Highlight: IEnumerableExtension

The `IEnumerableExtension` class is a part of the `OdeyTech.ProductivityKit.Extension` namespace and provides valuable extension methods to work with collections more efficiently.

- **ForEach** - Execute a specified action for each item in the collection.
- **IsFilled** - Check if a collection is not null and contains at least one item.
- **IsNullOrEmpty** - Determine if a collection is null or empty.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit.Extension;
using System.Collections.Generic;
    
var myList = new List<int> { 1, 2, 3 };

// Execute an action for each item in the collection
myList.ForEach(item => Console.WriteLine(item));
    
// Check if the collection is filled
bool isFilled = myList.IsFilled();
    
// Check if the collection is null or empty
bool isEmpty = myList.IsNullOrEmpty();
~~~

### Highlight: IntExtension

The `IntExtension` class is part of the `OdeyTech.ProductivityKit.Extension` namespace and provides valuable extension methods related to`DateTime` for `int` objects.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit.Extension;

// Create a DateTime object for a specific day in January
DateTime januaryDate = 10.January(2023);

// Create a DateTime object for a specific day in February
DateTime februaryDate = 14.February(2023);
~~~

### Highlight: StringExtension

The `StringExtension` class is a part of the `OdeyTech.ProductivityKit.Extension` namespace provides useful extension methods to work with strings.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit.Extension;

string someString = "Hello, World!";

// Use the Format method as an extension method for strings
string formatted = "Hello, {0}!".Format("World");

// Check if the string is null or empty
bool isEmpty = someString.IsNullOrEmpty();

// Check if the string is not null and contains characters.
bool isFilled = someString.IsFilled();
~~~

### Highlight: CharExtension

The `CharExtension` class is part of the `OdeyTech.ProductivityKit.Extension` namespace and provides extension methods for char type, making it easier to perform common checks.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit.Extension;

char numberChar = '3';
char letterChar = 'a';

// Check if a character is a digit
bool isNumberCharDigit = numberChar.IsDigit();

// Check if a character is a letter
bool isLetterCharLetter = letterChar.IsLetter();
~~~

### Highlight: Enum

The `ButtonName` enumeration is a part of the `OdeyTech.ProductivityKit.Enum` namespace and provides a standardized set of button names which can be utilized across your application for consistency and better maintainability.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit.Enum;

public void HandleButtonClick(ButtonName buttonName)
{
    switch(buttonName)
    {
        case ButtonName.Save:
            // handle save button click
            break;
        case ButtonName.Cancel:
            // handle cancel button click
            break;
        //... handle other buttons
    }
}
~~~

### Highlight: Accessor

The `Accessor` class is a part of the `OdeyTech.ProductivityKit` namespace and provides utility methods for accessing and manipulating objects' properties and fields.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit;

class MyClass
{
    public int MyProperty { get; set; }
    private int myField;
}

class Program
{
    static void Main(string[] args)
    {
        MyClass myObject = new MyClass();

        // Set the property value
        Accessor.SetPropertyValue(myObject, "MyProperty", 42);

        // Get the property value
        int propertyValue = (int)Accessor.GetPropertyValue(myObject, "MyProperty");

        // Set the field value
        Accessor.SetFieldValue(myObject, "myField", 5);

        // Get the field value
        int fieldValue = (int)Accessor.GetFieldValue(myObject, "myField");
    }
}
~~~

### Highlight: FileManager

The `FileManager` class is a part of the `OdeyTech.ProductivityKit` namespace and provides utility methods for working with files and directories.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit;
using System.IO;

string filePath = Path.Combine(FileManager.CurrentDirectory, "test.txt");

// Save content to a file
FileManager.SaveFile(filePath, "Hello, World!");

// Read content from a file
string fileContent = FileManager.ReadFile(filePath);

// Check if file exists
FileManager.CheckFileExists(filePath);

// Create a directory if it doesn't exist
FileManager.CreateDirectoryIfNotExists(filePath);

// Get the application folder
string appFolder = FileManager.GetApplicationFolder();
~~~

### Highlight: ProductInfo

The `ProductInfo` class is a part of the `OdeyTech.ProductivityKit` namespace and provides information about a product's assembly, such as copyright, application name, description, and version.

Example usage:

~~~csharp
using OdeyTech.ProductivityKit;
using System.Reflection;

Assembly assembly = Assembly.GetExecutingAssembly();
ProductInfo productInfo = new ProductInfo(assembly);

// Get product information
string appName = productInfo.ApplicationName;
string appDescription = productInfo.ApplicationDescription;
string version = productInfo.Version;
string copyright = productInfo.Copyright;
~~~

## Getting Started

To start using **OdeyTech.ProductivityKit**, install it as a NuGet package in your C# project.

## Usage

To use the library in your project, simply add the following using statements to your C# file:

~~~csharp
using OdeyTech.ProductivityKit;
using OdeyTech.ProductivityKit.Extension;
using OdeyTech.ProductivityKit.Enum;
~~~

Now you can start using the various classes, methods, and extensions provided by **OdeyTech.ProductivityKit**.

## Contributing

We welcome contributions to **OdeyTech.ProductivityKit**! Feel free to submit pull requests or raise issues to help us improve the library.

## License

**OdeyTech.ProductivityKit** is released under the [Non-Commercial License][LICENSE]. See the LICENSE file for more information.

## Stay in Touch

For more information, updates, and future releases, follow me on [LinkedIn][LIn] I'd be happy to connect and discuss any questions or ideas you might have.

[//]: #
   [LIn]: <https://www.linkedin.com/in/anodeychuk/>
   [LICENSE]: <https://github.com/anodeychuk/OdeyTech.ProductivityKit/blob/main/LICENSE>
   [Example]: <https://github.com/anodeychuk/OdeyTech.WPF.Example.Hospital>
