---
layout: post
title: Two Way Data Binding in Blazor | Syncfusion
description: Check out the documentation for the two way data binding support in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Blazor - Two Way Data Binding

Syncfusion Blazor components provide data binding features with the `@bind-value` Razor directive attribute with a field, property, or Razor expression value. By default, the `bind-value` attribute binds the data value in the `OnChange` event. The `OnChange` event triggers when the element loses its focus.

To perform a two way binding Syncfusion Blazor components, use the `bind-Value` attribute. In the below example, `SfTextBox` component value to the C# `textValue` property. When an `SfTextBox` component loses focus, its bound field or property is updated.

```cshtml

@using Syncfusion.Blazor.Inputs

<p>Binded value in TextBox is: <b>@textValue</b></p>

<SfTextBox @bind-Value="textValue"></SfTextBox>

@code {
    private string textValue { get; set; }

    protected override void OnInitialized()
    {
        textValue = "Syncfusion Blazor";
    }
}

```

![Two-Way Binding in Blazor](../images/blazor-two-way-binding.gif)

The following Syncfusion Blazor components support two way binding:

* [AutoComplete](https://blazor.syncfusion.com/documentation/autocomplete/data-binding)
* [Calendar](https://blazor.syncfusion.com/documentation/calendar/data-binding)
* [ComboBox](https://blazor.syncfusion.com/documentation/combobox/data-binding)
* [DatePicker](https://blazor.syncfusion.com/documentation/datepicker/data-binding)
* [DateRange Picker](https://blazor.syncfusion.com/documentation/daterangepicker/data-binding)
* [DateTime Picker](https://blazor.syncfusion.com/documentation/datetime-picker/data-binding)
* [DropDown List](https://blazor.syncfusion.com/documentation/dropdown-list/data-binding)
* [InPlace Editor](https://blazor.syncfusion.com/documentation/in-place-editor/data-binding)
* [Input Mask](https://blazor.syncfusion.com/documentation/input-mask/data-binding)
* [MultiSelect Dropdown](https://blazor.syncfusion.com/documentation/multiselect-dropdown/data-binding)
* [Numeric TextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/data-binding)
* [RichTextEditor](https://blazor.syncfusion.com/documentation/rich-text-editor/data-binding)
* [Splitter](https://blazor.syncfusion.com/documentation/splitter/two-way-binding)
* [TextBox](https://blazor.syncfusion.com/documentation/textbox/data-binding)
* [TimePicker](https://blazor.syncfusion.com/documentation/timepicker/data-binding)
