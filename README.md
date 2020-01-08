[![Build Status](https://dev.azure.com/marcelrienks/UpperBoundLimitedCollections/_apis/build/status/marcelrienks.UpperBoundLimitedCollections?branchName=master)](https://dev.azure.com/marcelrienks/UpperBoundLimitedCollections/_build/latest?definitionId=14&branchName=master)
# UpperBoundLimitedCollections
Set of ```System.Collections.Generic``` types that enforce an upper bound limit when trying to add or insert new items or ranges of items.

Or in other words a collection where you can specify a size limit that will be enforced when trying to add or insert item(s), by first removing a calculated number of elements from the beginning of the collection, to ensure that after the new item(s) have been added or inserted, the size limit of the collection remains intact.
## Types of limitation:
* **UpperBoundLimited**  
A collection type that takes an 'upper bound limit' argument as an overload when calling the *Add(), Insert(), AddRange(), InsertRange()* functions. Therefore the upper bound limit is only enforced when calling one of the functions listed bove, which means that these collections can start off larger than the limit.

* **StrictUpperBoundLimited**  
A collection type that takes an 'upper bound limit' argument in the constructor method when instantiating a the type. Therefore the upper bound limit is always enforced when calling calling the *Add(), Insert(), AddRange(), InsertRange()* functions. Which means that these collections sizes can never be any larger than the limit.
## Types of Collections:
Currently implemented:
* `System.Collections.Generic.List<T>`

*Still to be implemented:*
* `System.Collections.Generic.Dictionary<TKey,TValue>`
* `System.Collections.Generic.Queue<T>`
* `System.Collections.Generic.Stack<T>`
## Collection functions applicable:
The following collection functions have either  
an overload allowing for a limit argument to be passed in when using an **UpperBoundLimited** type.  
or use the global UpperBoundLimit property assigned when passing a limit argument in the constructor when creating a **StrictUpperBoundLimited** type.
* Add()
* AddRange()
* Insert()
* InsertRange()
## Usage:
### Example 1:
This example shows how to add a new item to an UpperBoundLimited type of limitation, of ```System.Collections.Generic.List<T>```  
```csharp
    var list = new UpperBoundLimitedList<string>() { "one", "two", "three" };

    list.Add("four", 5);
```
Results in a list of the following strings, due to the upper bound limit being larger than the total number of items in the list, even after the addition of the new item, allowing for maintaining the list size at 5.  
`{ "one", "two", "three", "four" }`
### Example 2:
This example shows how to add a range of items to an UpperBoundLimited type of limitation, of ```System.Collections.Generic.List<T>```  
```csharp
    var list = new UpperBoundLimitedList<int>() { 1, 2, 3, 4 };
    var range = new int[] { 5, 6 };

    list.AddRange(range, 3);
```
Results in a list of the following integers, due to the first 3 items in the list being removed in order to allow for the addition to take place while maintaining the list size at 3.  
`{ 4, 5, 6 }`
### Example 3:
This example shows how to insert an item to an UpperBoundLimited type of limitation, of ```System.Collections.Generic.List<T>``` at index 1  
```csharp
    var list = new UpperBoundLimitedList<string>() { "A", "B", "C", "D" };

    list.Insert(1, "x", 3);
```
Results in a list of the following strings, due to the first 2 items in the list being removed in order to allow for the insertion of the new item at index 1 to take place while maintaining the list size at 3.  
`{ "C", "x", "D" }`
## Possible Exceptions:
Raised if the item or range of items being added is null.
* `ArgumentNullException` "The argument cannot be null. (Parameter 'item')"
* `ArgumentNullException` "The argument cannot be null. (Parameter 'collection')"

Raised if the 'upperBoundLimit' argument, passed in as overloaded methods, or the collection constructor is 0.
* `ArgumentOutOfRangeException` "The argument must be greater than 0. (Parameter 'upperBoundLimit')"

Raised when the size of the range being added, exceeds the 'upperBoundLimit' argument
* `ArgumentOutOfRangeException` "The range size cannot be greater than the argument 'upperBoundLimit'. (Parameter 'range')"
