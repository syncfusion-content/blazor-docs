---
layout: post
title: HTML Attributes in Blazor - Syncfusion
description: Check out the documentation for HTML Attributes and supported Blazor components with equivalent properties
platform: Blazor
component: Common
documentation: ug
---

# Default HTML Attributes and DOM Events

The Syncfusion Blazor UI components provide the most useful [public API](https://help.syncfusion.com/cr/blazor/) for component implementation and customization. Apart from this public API, the Syncfusion Blazor UI components can support the use of default [HTML attributes](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes) and [DOM events](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-5.0) in the root element of its component.

## Using HTML attributes and DOM events in the input element

The following is a list of Syncfusion Blazor UI components that use the standard HTML `input` element. You can apply the [HTML input attributes](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input) and DOM events directly to the input element used on these Syncfusion Blazor components.

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

### Available Syncfusion properties equivalent to HTML attributes

The following table illustrates the HTML attributes and their equivalent Syncfusion API.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>HTML Attribute</b></td>
<td><b>Syncfusion API</b></td>
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
<td><a href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#htmlattrdefminlength">min</a></td>
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

N> If you specify both HTML attribute and Syncfusion API in the component, then the Syncfusion API will get higher priority and will be applied to the DOM element.

```cshtml
<SfTextBox ID="textbox" name="first-name" title="First name." minlength="15" Autocomplete="AutoComplete.Off"></SfTextBox>
```

The textbox will be rendered with the following output.

```html
<span class="....">
    <input id="textbox" class="...." name="first-name" type="text" autocomplete="off" title="First name." minlength="15" .... />
</span>
```

In some cases, you may need to add HTML attributes to the root/container element of the above input-based components. For this, you can use [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_HtmlAttributes) Syncfusion API to add HTML attributes to the root/container element.

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

The Syncfusion Blazor UI component supports binding the native [DOM events](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-5.0) on the input element.

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

## Using HTML attributes and DOM events in the root element

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
