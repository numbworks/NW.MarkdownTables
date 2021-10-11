# NW.MarkdownTables
Contact: numbworks@gmail.com

## Revision History

| Date | Author | Description |
|---|---|---|
| 2020-12-27 | numbworks | Created. |
| 2021-10-11 | numbworks | Version numbers removed. |


## Introduction

`NW.MarkdownTables` is a `.NET Standard` library written in `C#` to create Markdown tables out of the provided objects. 

It makes very easy to format objects in tabular format while logging and to create examples for the documentation of the project while developing it.

## Example 1: Main Scenario 

Let's imagine to have a `Car` class such as: 

```csharp
class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public uint Year { get; set; }
    public uint Price { get; set; }
    public string Currency { get; set; }
}
```

If we do have an instance of that class that we want to format as `Markdown` table, we can do that by writing the following few lines of code:

```csharp
using System;
using NW.MarkdownTables;

/* ... */

Car car = new Car()
{
    Brand = "Dodge",
    Model = "Charger",
    Year = 1966,
    Price = 13500,
    Currency = "USD"
};

IMarkdownTabulizer markdownTabulizer = new MarkdownTabulizer();
string markdownTable = markdownTabulizer.ToMarkdownTable(false, car);

Console.WriteLine(markdownTable);
```

The output will be:

|Brand|Model|Year|Price|Currency|
|---|---|---|---|---|
|Dodge|Charger|1966|13500|USD|

By setting the `smallerFontSize` boolean flag in the `ToMarkdownTable` method to `true`, you'll get all the cells to be surrounded with `<sub></sub>` tags. This is a known workaround in `Markdown` to obtain a smaller font.

## Example 2: Multiple rows

If you want to create a `Markdown` table with multiple rows, the `ToMarkdownTable` method supports collections of objects as well. Each object in the list will be one row of the table. 

You'll be asked to provide one of the available `NullHandlingStrategies` in order to instruct the method about how you want to handle eventual `null` items in your collection:

Please check the following example:

```csharp
using System;
using System.Collections.Generic; 
using NW.MarkdownTables;
using NW.MarkdownTables.Strategies;

/* ... */

List<Car> cars = new List<Car>()
{

    new Car()
    {
        Brand = "Dodge",
        Model = "Charger",
        Year = 1966,
        Price = 13500,
        Currency = "USD"
    },
    new Car()
    {
        Brand = "Hummer",
        Model = "H2",
        Year = 2001,
        Price = 24200,
        Currency = "USD"
    }

};

IMarkdownTabulizer markdownTabulizer = new MarkdownTabulizer();
string markdownTable
    = markdownTabulizer.ToMarkdownTable(
        false,
        NullHandlingStrategies.ThrowException,
        cars);

Console.WriteLine(markdownTable);
```

The output will be:

|Brand|Model|Year|Price|Currency|
|---|---|---|---|---|
|Dodge|Charger|1966|13500|USD|
|Hummer|H2|2001|24200|USD|

## Example 3: Additional Methods

In addition to the `ToMarkdownTable` method, the `MarkdownTabulizer` class provides additional methods that could be useful in some specific use cases, such as:

```csharp
/* ... */
public string ToMarkdownRow
    (bool smallerFontSize, params string[] values) { /* ... */ }
public string ToMarkdownRow<T>
    (bool smallerFontSize, T obj) { /* ... */ }
public string ToMarkdownHeader
    (bool smallerFontSize, params string[] values) { /* ... */ }
public string ToMarkdownHeader<T>
    (bool smallerFontSize, T obj) { /* ... */ }
/* ... */
```

## Markdown Toolset

Suggested toolset to view and edit this Markdown file:

- [Visual Studio Code](https://code.visualstudio.com/)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown PDF](https://marketplace.visualstudio.com/items?itemName=yzane.markdown-pdf)