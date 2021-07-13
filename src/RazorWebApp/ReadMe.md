# HTML Forms in Razor Pages

In the following discussion, the samples include both the HTML/Razor and C# portions as used in Razor Pages. Follow the links for more in-depth information on each section.

## HTML Form Basics

- Form element
  - GET vs POST
- Buttons
  - button vs input button

## Model-Binding Basics

Binding to the page's model property is performed by adding a C# `[BindProperty]` decoration on the 

 the `asp-for` attribute.



## Capturing User-Generated Information

Primitive information falls into three categories: [**Textual**](#textual-information), [**Numeric**](#numeric-information), and [**Conceptual**](#conceptual-information).

### Textual Information

Capturing textual input in a form can be done in the following ways.

| Kind | Element/Type | Sample |
| ------- | ---- | ------ |
| Multi-line | `<textarea>` | <form><textarea rows="3" cols="50" asp-for="LongerText"></textarea></form> |
| Single-line| `<input type="text"` | <form><input type="text" asp-for="StringProperty" /></form> |
| Password | `<input type="password"` | <form><input type="password" asp-for="NotSoSecret"/></form> |
| Email | `<input type="email"` | <form><input type="email" asp-for="NotSoSecret"/></form> |
| URL | `<input type="url"` | <form><input type="url" asp-for="NotSoSecret"/></form> |
| Telephone | `<input type="tel"` | <form><input type="tel" asp-for="NotSoSecret"/></form> |

#### Multi-Line Text

[**`<textarea>`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/textarea) allows for longer textual input, including new-line characters. You can constrain the length of the input using the `maxlength` and `minlength` attributes.

```html
<textarea rows="5" cols="120" asp-for="LongerText"></textarea>
```

```csharp
[BindProperty]
public string LongerText { get; set; }
```

#### Short Single-Line Text

> *This is the default type for the `<input />` element.*

The most commonly used type of input, [**`type="text"`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/text) version of `<input>` is intended for short text. Again, you can constrain the length of the input using the `maxlength` and `minlength` attributes.

```html
<input type="text" asp-for="StringProperty" />
```

```csharp
[BindProperty]
public string StringProperty { get; set; }
```

#### Password

If you want to protect the user's input from over-the-shoulder spying, the [**`type="password"`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/password) version of `<input>`

```html
<input type="password" asp-for="NotSoSecret"/>
```

```csharp
[BindProperty]
public string NotSoSecret { get; set; }
```

#### Email

The [**`type="email"`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/email) input type provides automatic validation for properly formatted email addresses using only the most simplistic expectations.

```html
<input type="email" asp-for="Contact"/>
```

```csharp
[BindProperty]
public string Contact { get; set; }
```

#### URL

The [**`type="url"`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/url) input type provides automatic validation for properly formatted web addresses.

```html
<input type="url" asp-for="CompanyWebsite"/>
```

```csharp
[BindProperty]
public string CompanyWebsite { get; set; }
```

#### Telephone

The [**`type="tel"`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/tel) input type is often useful for mobile browsers because the mobile device can render a numeric keypad for more intuitive input. It does not provide any automatic filtering or validation of input (you can type letters into the textbox), but you can specify a format using the `pattern` attribute.

```html
<input type="tel" pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}" asp-for="HomePhone"/>
```

```csharp
[BindProperty]
public string HomePhone { get; set; }
```

----

### Numeric Information

The [**`type="number"`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/number) version of the `<input>` element is used to constrain user input to numeric values. By default, it only accepts whole numbers, but that can be changed through using the `step` attribute, as shown in the following examples. You can also use the `min` and `max` attributes to define the lower and upper limits (inclusive) for accepted values.

```html
<label>Enter a Whole Number
    <input type="number" asp-for="WholeNumber" />
</label>
<label>Enter a Real Number (to three decimal places)
    <input type="number" step=".001" asp-for="RealNumber" />
</label>
<label>Enter a cash amount (Canadian)
    <input type="number" step=".05" asp-for="Money" />
</label>
```

```csharp
[BindProperty]
public int WholeNumber { get; set; }
[BindProperty]
public double RealNumber { get; set; }
[BindProperty]
public decimal Money { get; set; }
```

The [**`type=range`**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/range) version of the `<input>` element can also be used for numeric input. Browsers typically render these as sliders.

```html
<label>Rate your confidence in understanding numerical inputs
    <input type="range" min="0" max="100" step="10" asp-for="PercentConfident" />
</label>
```

```csharp
[BindProperty]
public int PercentConfident { get; set; }
```


----

### Conceptual Information

HTML 5 offers various controls for capturing what could be considered "conceptual" information. Generally speaking, there are four conceptual types of information the user can enter.

- [**Temporal**](#temporal-information) - Information that is date and/or time related.
- [**Selections**](#selectable-information) - Selecting from a set of items; these include drop-downs, checkboxes and radio buttons.
- [**Colors**](#color-information) - Color information can be expressed in a number of different ways.
- [**Files**](#file-uploads) - Users can upload files of various types to the web server.

#### Temporal Information

> The date and time input types for HTML are based on the [Gregorian Calendar](https://en.wikipedia.org/wiki/Gregorian_calendar).

Working with date/time information in programming can be &hellip; [*complex*](https://www.mojotech.com/blog/the-complexity-of-time-data-programming/). We can easily [get them wrong](https://gist.github.com/timvisee/fcda9bbdff88d45cc9061606b4b923ca).

Normally when we think of date and time information in C#, we think of the `DateTime` data type. There are three HTML 5 data types that translate cleanly to the C# `DateTime`: `type="date"`, `type="datetime-local"` and `type="datetime"` (*this last one is being deprecated*). The `type="month"` can also be translated to the C# `DateTime`, but the day portion will default to the first of the month.

> *(**Note:** There will be [new date and time datatypes in .NET 6](https://devblogs.microsoft.com/dotnet/date-time-and-time-zone-enhancements-in-net-6/) that should help.)*

A lesser-known type in C# is the `TimeSpan`, which nicely handles the `type="time"` input from HTML.

One HTML 5 temporal input types that does *not* cleanly translate into a C# type is the `type="week"`. For this, you should use a `string` data type in C# and parse it to obtain the week and year portions.

> One library to help with using dates and times in C# is [**NodaTime**](https://nodatime.org/).

Review the Microsoft documentation for more about the [C# `DateTime`](https://docs.microsoft.com/dotnet/api/system.datetime) data type. Here are some additional resources for you to learn more about coding with date/time based data.

- [C# DateTime](https://www.tutorialsteacher.com/csharp/csharp-datetime)
- [Working with Dates And Times in Razor Pages Forms](https://www.mikesdotnetting.com/article/352/working-with-dates-and-times-in-razor-pages-forms).

##### Input `type="date"`

The [**`type="date"**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/date) input type captures a specific day.

```html
<input type="date" asp-for="ProjectDueDate" />
```

You can bind this type of HTML input to the `DateTime` type in C#. Note that when the data is parsed, the time portion will be set to midnight (00:00.000).

```csharp
[BindProperty]
public DateTime ProjectDueDate { get; set; }
```

##### Input `type="datetime-local"`

The [**`type="datetime-local"**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/datetime-local) input type captures a specific date and time.

```html
<input type="datetime-local" asp-for="Appointment" />
```

You can bind this type of HTML input to the `DateTime` type in C#. The HTML captures the time information to the minute (meaning that the milliseconds portion of the C# type will be zero).

```csharp
[BindProperty]
public DateTime Appointment { get; set; }
```

##### Input `type="month"`

The [**`type="month"**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/month) input type captures only the year and month information.

```html
<input type="month" asp-for="RentalPeriod" />
```

You can bind this type of HTML input to the `DateTime` type in C#. Note that the day portion will default to the first day of the month and the time portion will default to midnight.

```csharp
[BindProperty]
public DateTime RentalPeriod { get; set; }
```


##### Input `type="time"`

The [**`type="time"**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/time) input type captures time information only.

```html
<input type="time" asp-for="ClassStartTime" />
```

You can bind this type of HTML input to the `TimeSpan` type in C#. The HTML captures the time information to the minute (meaning that the milliseconds portion of the C# type will be zero).

```csharp
[BindProperty]
public TimeSpan ClassStartTime { get; set; }
```

##### Input `type="week"`

The [**`type="week"**](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/week) input type captures the week number of a particular year.

```html
<input type="week" asp-for="FirstWeekOfSchool" />
```

The best C# data type to capture this is the `string` data type. You can parse the string based on the `-` delimiter, in which case the first portion will be the year and the second will be the week number (prepended with a `W`).

```csharp
[BindProperty]
public string FirstWeekOfSchool { get; set; }
```

#### Selectable Information

  - Selections (select, radio, checkboxes)

##### `select`/`option` Elements

The drop-down control (`<select>`) is typically used to choose a single item from the set of offered options. Unless otherwise specified, the selected option is the first `<option>` element in the selection.

```html
<select asp-for="EducationLevel">
    <option value="">[Select a level]</option>
    <option>Doctoral</option>
    <option>Post-Graduate</option>
    <option>Post-Secondary</option>
    <option>High School</option>
    <option>None</option>
</select>
```

Note that in each option, the selected value will be a string. The first option associates an empty string with the "[Select a value]" selection. If no explicit `value` attribute is assigned to an `<option>`, then the text inside the `<option>` element is the value used when selected.

```csharp
[BindProperty]
public string EducationLevel { get; set; }
```

If you use numeric values, you can bind the selection to an `int`, as in the following example.

```html
<select asp-for="EducationLevel">
    <option value="0">[Select a level]</option>
    <option value="5">Doctoral</option>
    <option value="4">Post-Graduate</option>
    <option value="3">Post-Secondary</option>
    <option value="2">High School</option>
    <option value="1">None</option>
</select>
```

```csharp
[BindProperty]
public int EducationLevel { get; set; }
```

##### Input `type="radio"`

Radio buttons typically appear in sets of two or more, since they represent an exclusive selection between various options.

```html
<label><input type="radio" name="EmploymentStatus" value="FullTime-Permanent" />Full-Time (permanent)</label>
<label><input type="radio" name="EmploymentStatus" value="FullTime-Contract" />Full-Time (contract)</label>
<label><input type="radio" name="EmploymentStatus" value="PartTime-Permanent" />Part-Time (permanent)</label>
<label><input type="radio" name="EmploymentStatus" value="PartTime-Contract" />Part-Time (contract)</label>
```

```csharp
[BindProperty]
public string EmploymentStatus{get;set;}
```

##### Input `type="checkbox"`

The checkbox is a control that exists nicely by itself or as a group of checkboxes. When used by itself, you can simply bind it to a `bool` property in the page model.

```html
<input type="checkbox" asp-for="AcceptTerms" /> I accept the terms
```

The checkbox control can have an attribute of `checked`, either with or without a value for the attribute, in order to "check" the box.

```html
<input type="checkbox" asp-for="AcceptTerms" checked /> I accept the terms
```

The above checkboxes can be bound as follows.

```csharp
[BindProperty]
public bool AcceptTerms { get; set; }
```

When working with a group of checkboxes, you cannot use the `asp-for` attribute because there is no single variable to associate each checkbox with. Rather, you should explicitly set the `name` and `value` attributes of each checkbox.

```html
<label><input type="checkbox" name="Course" value="Math 30" />Math 30</label>
<label><input type="checkbox" name="Course" value="Math 31" />Math 31</label>
<label><input type="checkbox" name="Course" value="English 30" />English 30</label>
<label><input type="checkbox" name="Course" value="English 31" />English 31</label>
<label><input type="checkbox" name="Course" value="Physics 30" />Physics 30</label>
<label><input type="checkbox" name="Course" value="Chemistry 30" />Chemistry 30</label>
```

You can then bind the results to an array of strings.

```csharp
[BindProperty]
public string[] Course { get; set; }
```

Alternatively, if you had set the `value` attributes to whole numbers, you could bind to an array of integers.

For more information on working with binding to collections, see the following article on [Binding Simple Collections](https://www.learnrazorpages.com/razor-pages/model-binding#binding-simple-collections).

#### Color Information

Color information can be obtained using the color picker supplied by most modern browsers.

```html
<input type="color" asp-for="PrimaryColor" />
```

The color value will be expressed as a six-digit hex number (e.g. `#472dc8`).

```csharp
[BindProperty]
public string PrimaryColor { get; set; }
```

#### File Uploads

Uploading files requires additional information on the `<form>` element.

The input type is `file`, and the data type used for binding is the `IFormFile` interface in the `Microsoft.AspNetCore.Http` namespace.

```html
<input type="file" asp-for="Avatar" />
```

```csharp
[BindProperty]
public IFormFile Avatar {get;set;}
```

For more information on processing file uploads, see the ["Uploading Files in Razor Pages"](https://www.learnrazorpages.com/razor-pages/forms/file-upload) article.
