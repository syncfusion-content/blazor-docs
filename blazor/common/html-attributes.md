---
layout: post
title: HTML attributes and DOM events in Blazor - Syncfusion
description: Learn how to use standard HTML attributes and DOM events with Syncfusion Blazor components on input and root elements, and see equivalent component APIs.
platform: Blazor
control: Common
documentation: ug
---

# Default HTML attributes and DOM events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI components provide the most useful [public API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.html) for component implementation and customization. Apart from this public API, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI components can support the use of default [HTML attributes](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes) and [DOM events](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-8.0) in the root element of its component.

## Use HTML attributes and DOM events on input elements

The following is a list of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI components that use the standard HTML `input` element. You can apply the [HTML input attributes](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input) and DOM events directly to the input element used on these Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

* [SfAutoComplete](https://blazor.syncfusion.com/documentation/autocomplete/getting-started)
* [SfCheckBox](https://blazor.syncfusion.com/documentation/check-box/getting-started)
* [SfComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started)
* [SfDatePicker](https://blazor.syncfusion.com/documentation/datepicker/getting-started)
* [SfDateRangePicker](https://blazor.syncfusion.com/documentation/daterangepicker/getting-started)
* [SfDateTimePicker](https://blazor.syncfusion.com/documentation/datetime-picker/getting-started)
* [SfDropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started)
* [SfMaskedTextBox](https://blazor.syncfusion.com/documentation/input-mask/getting-started)
* [SfMultiSelect](https://blazor.syncfusion.com/documentation/multiselect-dropdown/getting-started)
* [SfNumericTextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started)
* [SfRadioButton](https://blazor.syncfusion.com/documentation/radio-button/getting-started)
* [SfTextBox](https://blazor.syncfusion.com/documentation/textbox/getting-started)
* [SfTimePicker](https://blazor.syncfusion.com/documentation/timepicker/getting-started)
* [SfUpload](https://blazor.syncfusion.com/documentation/file-upload/getting-started)

### Syncfusion<sup style="font-size:70%">&reg;</sup> properties equivalent to HTML attributes

The following table illustrates the HTML attributes and their equivalent Syncfusion<sup style="font-size:70%">&reg;</sup> API.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>HTML Attribute</b></td>
<td><b>Syncfusion<sup style="font-size:70%">&reg;</sup> API</b></td>
<td><b>Components</b></td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#attr-id">id</a></td>
<td>ID</td>
<td>
<ul>
<li>All Components</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefautocomplete">autocomplete</a></td>
<td>Autocomplete</td>
<td>
<ul>
<li>SfTextBox</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefchecked">checked</a></td>
<td>Checked</td>
<td>
<ul>
<li>SfCheckBox</li>
<li>SfRadioButton</li>
</ul>
</td>
</tr>
<tr>
<td rowspan="2"><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefdisabled">disabled</a></td>
<td>Disabled</td>
<td>
<ul>
<li>SfCheckBox</li>
<li>SfRadioButton</li>
</ul>
</td>
</tr>
<tr>
<td>Enabled</td>
<td>
<ul>
<li>Others</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefmax">max</a></td>
<td>Max</td>
<td>
<ul>
<li>SfDatePicker</li>
<li>SfDateRangePicker</li>
<li>SfDateTimePicker</li>
<li>SfNumericTextBox</li>
<li>SfTimePicker</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/input#htmlattrdefminlength">min</a></td>
<td>Min</td>
<td>
<ul>
<li>SfDatePicker</li>
<li>SfDateRangePicker</li>
<li>SfDateTimePicker</li>
<li>SfNumericTextBox</li>
<li>SfTimePicker</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefmultiple">multiple</a></td>
<td>Multiple</td>
<td>
<ul>
<li>SfUpload</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefplaceholder">placeholder</a></td>
<td>Placeholder</td>
<td>
<ul>
<li>Except below components:</li>
<li>SfCheckBox</li>
<li>SfRadioButton</li>
<li>SfUpload</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/readonly">readonly</a></td>
<td>ReadOnly</td>
<td>
<ul>
<li>Except below components:</li>
<li>SfCheckBox</li>
<li>SfRadioButton</li>
<li>SfUpload</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefstep">step</a></td>
<td>Step</td>
<td>
<ul>
<li>SfNumericTextBox</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefvalue">value</a></td>
<td>Value</td>
<td>
<ul>
<li>Except below component:</li>
<li>SfUpload</li>
</ul>
</td>
</tr>
<tr>
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefwidth">width</a></td>
<td>Width</td>
<td>
<ul>
<li>Except below components:</li>
<li>SfCheckBox</li>
<li>SfRadioButton</li>
<li>SfUpload</li>
</ul>
</td>
</tr>
</table>
<!-- markdownlint-enable MD033 -->

N> If both an HTML attribute and a Syncfusion<sup style="font-size:70%">&reg;</sup> API are specified, the Syncfusion API takes precedence and is applied to the DOM element.

```cshtml
<SfTextBox ID="textbox" name="first-name" title="First name." minlength="15" Autocomplete="AutoComplete.Off"></SfTextBox>
```

The textbox will be rendered with the following output.

```html
<span class="....">
    <input id="textbox" class="...." name="first-name" type="text" autocomplete="off" title="First name." minlength="15" .... />
</span>
```

In some cases, HTML attributes must be added to the root/container element instead of the input. Use the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_HtmlAttributes) API to set attributes on the root/container element.

```cshtml
<SfTextBox HtmlAttributes="@(new() { { "style", "background:aliceblue;" } })"></SfTextBox>
```

The textbox will be rendered with the following output.

```html
<span class="...." style="background: aliceblue;" ....>
    <input .... />
</span>
```

### Input DOM events

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components support binding native [DOM events](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling) on input elements.

```cshtml
<div class="form-group">
    <SfTextBox @onfocus="OnTextFocus" @onblur="OnTextFocusOut"></SfTextBox>
</div>

@if (eventName != string.Empty)
{
    <div class="alert alert-info">@eventName event is triggered on the TextBox.</div>
}

@code {
    private string eventName = string.Empty;

    void OnTextFocus()
    {
        eventName = "Focus";
    }

    void OnTextFocusOut()
    {
        eventName = "Focusout";
    }
}
```

## Use HTML attributes and DOM events on the root element

The HTML attributes and DOM events can be applied directly to the component's root element.

```cshtml
<SfChip @onmouseover="OnChipHover" style="border: 1px solid tomato">
    <ChipItems>
        <ChipItem Text="Apple"></ChipItem>
        <ChipItem Text="Mango"></ChipItem>
        <ChipItem Text="Banana"></ChipItem>
    </ChipItems>
</SfChip>

@code {
    public void OnChipHover(MouseEventArgs args)
    {
        // Do something here on chips hover.
    }
}
```

The chip container/root element will be rendered with the following output.

```html
<div style="border: 1px solid tomato" class="...." >
    <div class="...." role="listbox">
        ....
        ....
    </div>
</div>
```
