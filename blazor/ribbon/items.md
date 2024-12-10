---
layout: post
title: Items in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Items in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Ribbon Items

## Built-in items

### Button item

You can render the built-in Ribbon button item by setting the `Type` property as `RibbonItemType.Button`. You can customize the button item using the `RibbonButtonSettings` tag directive, which provides options such as `IconCss`, `Content`, `IsToggle`, and more.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.Button">
    <RibbonButtonSettings Content="Save" IconCss="e-icons e-save"></RibbonButtonSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

### Checkbox item

You can render the built-in Ribbon checkbox item by setting the `Type` property as `RibbonItemType.Checkbox`. This item is used to toggle between selected and unselected states. You can customize the checkbox using the `RibbonCheckboxSettings` tag directive with options such as `Label` and `Checked`.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.Checkbox">
    <RibbonCheckboxSettings Label="Enable Feature" Checked="true"></RibbonCheckboxSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

### DropdownButton item

You can render the built-in Ribbon dropdown button item by setting the `Type` property as `RibbonItemType.DropDown`. This item displays a button with a dropdown menu for additional options. The `RibbonDropDownSettings` tag directive allows you to configure properties such as `Content`, `Items` and more.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.DropDown">
    <RibbonDropDownSettings Content="Options" Items="@DropdownItems"></RibbonDropDownSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

### Split button item

You can render the built-in Ribbon split button item by setting the `Type` property as `RibbonItemType.SplitButton`. This item combines a primary button with a dropdown for secondary actions. The `RibbonSplitButtonSettings` tag directive lets you configure options like `Content`, `Items` and more.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.SplitButton">
    <RibbonSplitButtonSettings Content="Edit" Items="@EditActions"></RibbonSplitButtonSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

### Colorpicker item

You can render the built-in Ribbon color picker item by setting the `Type` property as `RibbonItemType.ColorPicker`. This item provides a color selection interface, which can be customized using the `RibbonColorPickerSettings` tag directive with properties like `Value`, `Mode` and more.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.ColorPicker">
    <RibbonColorPickerSettings Value="#FF0000"></RibbonColorPickerSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

### Groupbutton item

You can render the built-in Ribbon group button item by setting the `Type` property as `RibbonItemType.GroupButton`. This item groups multiple buttons for single or multiple selection. Use the `RibbonGroupButtonSettings` tag directive to configure options like `Items`, `Selection`, and more. `Items` accepts a collection of `GroupButtonItem`. Hence, you can use the `GroupButtonItem` tag directive to customize the groupbutton items which provides options such as Content, IconCss, Selected and more.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.GroupButton">
    <RibbonGroupButtonSettings Items="@GroupButtons" Selection="GroupButtonSelection.Single"></RibbonGroupButtonSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

### Combobox item

You can render the built-in Ribbon combobox item by setting the `Type` property as `RibbonItemType.Combobox`. This item provides a dropdown with optional search and filtering capabilities. The `RibbonComboboxSettings` tag directive allows you to configure properties like `DataSource`, `AllowFiltering`, `Placeholder` and lot more.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.Combobox">
    <RibbonComboboxSettings DataSource="@ComboboxData" AllowFiltering="true" Placeholder="Select an option"></RibbonComboboxSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

## Custom item

The Ribbon supports rendering non-built-in items or your own HTML content by setting the `Type` property as `RibbonItemType.Template`. And then, you can use the `ItemTemplate` tag directive to define a custom `RenderFragment` for fully customizable content.


{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.Template">
    <ItemTemplate>
        <div class="progress-bar">
            <div class="progress-bar-fill" style="width: 75%;"></div>
        </div>
    </ItemTemplate>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

## Items display mode

The `DisplayOptions` property determines how Ribbon items are displayed based on the Ribbon's layout and overflow state. Available options include:

| Value | Description |
|-----|-----|
| `Auto` | The items are displayed in all layouts based on the ribbon's overflow state. |
| `Classic` | The items are displayed only in the classic layout group. |
| `Simplified` | The items are displayed only in the simplified layout group. |
| `Overflow` | The items are displayed only in the overflow popup. |

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.Button" DisplayOptions="RibbonDisplayMode.Classic">
    <RibbonButtonSettings Content="Help"></RibbonButtonSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}

## Enable/Disable items

You can use the `Disabled` property to disable particular Ribbon item. It prevents the user interaction when set to `true`. By default, the value is `false`.

{% tabs %}
{% highlight razor %}

<RibbonItem Type="RibbonItemType.Button" Disabled=true>
    <RibbonButtonSettings Content="Save" IconCss="e-icons e-save"></RibbonButtonSettings>
</RibbonItem>

{% endhighlight %}
{% endtabs %}
