---
layout: post
title: Input Types in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Input Types in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Input Types in Blazor TextBox Component

This section explains the list of textbox type attributes.

## Text

Set the `Text` type to TextBox component. It defines a single-line text field, it is the default value of the Textbox component.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Type="InputType.Text"></SfTextBox>

}
```

## Number

Set the `Number` type to TextBox component. It defines an input field for entering a number which will allow only numeric values to be entered, displays a spinner when hover or focus the control.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Type="InputType.Number"></SfTextBox>

}
```

## Password

Set the `Password` type to TextBox component. It defines a single-line text field whose value is obscured.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Type="InputType.Password"></SfTextBox>

}
```

## Email

Set the `Email` type to TextBox component. It defines an input field for entering an email address.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Type="InputType.Email"></SfTextBox>

}
```

## URL

Set the `URL` type to TextBox component. It defines an input field for entering url.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Type="InputType.URL"></SfTextBox>

}
```

## Tel

Set the `Tel` type to TextBox component. It defines an input field for entering telephone number.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Type="InputType.Tel"></SfTextBox>

}
```

## Search

Set the `Search` type to TextBox component. It defines a single line text field for entering a search string.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Type="InputType.Search"></SfTextBox>

}
```
