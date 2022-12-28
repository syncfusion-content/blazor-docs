---
layout: post
title: Style and appearance in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Style and Appearance in Dropdown List

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Read-only mode

Specify the boolean value to the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Readonly) whether the DropDownList allows the user to change the value or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

![Blazor DropDownList with Readonly mode](./images/style/blazor_dropdown_readonly-mode.png)

## Disabled state

Specify the boolean value to the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Enabled) property that indicates whether the component is enabled or not.

{% highlight cshtml %}

{% include_relative code-snippet/style/disabled-state.razor %}

{% endhighlight %}

![Blazor DropDownList with Disabled ](./images/style/blazor_dropdown_disabled-state.png)

## Customizing the disabled component’s text color

Use the following CSS to customize the text color when the component is disabled.

```css
.e-input-group.e-control-wrapper .e-input[disabled] {
    -webkit-text-fill-color: #0d9133;
}
```

![Blazor DropDownList with Disabled component text color](./images/style/blazor_dropdown_disable-text-color.png)

## Show the custom icon in dropdown icon

Change the dropdown [icon](https://ej2.syncfusion.com/documentation/appearance/icons/#material) by overriding the style `content`.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon.razor %}

{% endhighlight %}

![Blazor DropDownList with dropdown icon](./images/style/blazor_dropdown_dropdown-icon.png)

Change the dropdown icon for the particular component using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property and add style to the custom class which is mapped to `CssClass`.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-icon-using-cssclass.razor %}

{% endhighlight %}

![Blazor DropDownList with dropdown icon using CssClass](./images/style/blazor_dropdown_dropdown-icon.png)

## Customizing the appearance of container element

Use the following CSS to customize the appearance of container element.

```css
.e-ddl.e-input-group.e-control-wrapper .e-input {
    font-size: 20px;
    font-family: emoji;
    color: #ab3243;
    background: #32a5ab;
}
```

![Blazor DropDownList container element customization](./images/style/blazor_dropdown_appearance-of-container.png)

## Customizing the dropdown icon’s color

Use the following CSS to customize the dropdown icon’s color.

```css
.e-ddl .e-input-group-icon.e-ddl-icon.e-icons, .e-ddl .e-input-group-icon.e-ddl-icon.e-icons:hover {
    color: #bb233d;
    font-size: 13px;
}
```

![Blazor DropDownList icon color](./images/style/blazor_dropdown_icon-color.png)

## Customizing the focus color

Use the following CSS to customize the focusing color of input element.

```css
.e-ddl.e-input-group.e-control-wrapper.e-input-focus::before, .e-ddl.e-input-group.e-control-wrapper.e-input-focus::after {
    background: #c000ff;
}
```

![Blazor DropDownList focus color](./images/style/blazor_dropdown_focus-color.png)

## Customizing the outline theme's focus color

Use the following CSS to customize the focusing color of outline theme.

```css
.e-outline.e-input-group.e-input-focus:hover:not(.e-success):not(.e-warning):not(.e-error):not(.e-disabled):not(.e-float-icon-left),.e-outline.e-input-group.e-input-focus.e-control-wrapper:hover:not(.e-success):not(.e-warning):not(.e-error):not(.e-disabled):not(.e-float-icon-left),.e-outline.e-input-group.e-input-focus:not(.e-success):not(.e-warning):not(.e-error):not(.e-disabled),.e-outline.e-input-group.e-control-wrapper.e-input-focus:not(.e-success):not(.e-warning):not(.e-error):not(.e-disabled) {
    border-color: #b1bd15;
    box-shadow: inset 1px 1px #b1bd15, inset -1px 0 #b1bd15, inset 0 -1px #b1bd15;
}
```

![Blazor DropDownList focusing color outline theme](./images/style/blazor_dropdown_focusing-color-of-outline-theme.png)

Use the `e-outline` to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property to achieve the outline theme

{% highlight cshtml %}

{% include_relative code-snippet/style/outline-theme.razor %}

{% endhighlight %}

![Blazor DropDownList with outline theme](./images/style/blazor_dropdown_outline-theme.png)


## Customizing the background color of focus, hover, and active items

Use the following CSS to customize the background color of the `focus`, `hover`, and `active` items.

```css
.e-dropdownbase .e-list-item.e-item-focus, .e-dropdownbase .e-list-item.e-active, .e-dropdownbase .e-list-item.e-active.e-hover, .e-dropdownbase .e-list-item.e-hover {
    background-color: #1f9c99;
    color: #2319b8;
}
```

![Blazor DropDownList with customizing the focus, hover and active item color](./images/style/blazor_dropdown_outline-theme.png)

## Customizing the appearance of pop-up element

Use the following CSS to customize the appearance of popup element.

```css
.e-dropdownbase .e-list-item, .e-dropdownbase .e-list-item.e-item-focus {
    background-color: #29c2b8;
    color: #207cd9;
    font-family: emoji;
    min-height: 29px;
}
```

![Blazor DropDownList with customizing popup color](./images/style/blazor_dropdown_outline-theme.png)

## Change the HTML attributes

Add the additional html attributes such as styles, class, and more to the root element using the [HTMLAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HtmlAttributes) property.

{% highlight cshtml %}

{% include_relative code-snippet/style/html-attributes.razor %}

{% endhighlight %}

![Blazor DropDownList with different font family](./images/style/blazor_dropdown_html-attributes.png)

## Set the various font family for dropdown list elements

The font-family of the dropdown list can be changed by overriding using the following selector. The overridden can be applied to specific component by adding a class name through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

In the following sample, the font family of the Dropdownlist, ListItem text in dropdownlist and filterInput text are changed.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-font-family.razor %}

{% endhighlight %}

![Blazor DropDownList with different font family](./images/style/blazor_dropdown_font-family.png)

## Show tooltip on list item

You can achieve this behavior by integrating the tooltip component. When the mouse hovers over the DropDownList option, a tooltip appears with information about the hovered list item.

The following code demonstrates how to display a tooltip when hovering over the DropDownList option.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-with-tooltip.razor %}

{% endhighlight %}

![Blazor DropDownList with tooltip](./images/style/blazor-dropdownlist-tooltip.png)

### Tooltip using HTMLAttribute in dropdown component

To display the tooltip in the dropdown component not for individual popup items, add the `Title` attribute through the [HTMLAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HtmlAttributes) property. This updates the attribute on the root input element.

In the following example, the `HtmlAttributes` property is used to add the title attribute to the root input element of the DropDownList with the value `DropDownList Component`. This will display a tooltip with the text `DropDownList Component` when the user hovers over the input element.

{% highlight cshtml %}

{% include_relative code-snippet/style/default-tooltip.razor %}

{% endhighlight %}

![Blazor DropDownList with tooltip](./images/style/blazor_dropdown_default-tooltip.png)

## Customize selected item opacity

Set the opacity to the selected item using the following selector.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-with-opacity-style.razor %}

{% endhighlight %}

![Blazor DropDownList with opacity style](./images/style/blazor_dropdown_opacity-style.png)

## Customizing the height

### Height of dropdownlist

Use the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupHeight) property to change the height of the popup.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-height.razor %}

{% endhighlight %}

![Blazor DropDownList with Popup height](./images/style/blazor_dropdown_height.png)

### Width of dropdownlist

To customize the width of the popup alone, use the [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupWidth) property. By default, the popup width is set based on the component's width. Use the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Width) to change the width of the component.

{% highlight cshtml %}

{% include_relative code-snippet/style/popup-width.razor %}

{% endhighlight %}

![Blazor DropDownList with Popup Width](./images/style/blazor_dropdown_width-popup-width.png)

## Disable specfic items in dropdown list

Prevent some items in the popup list from selecting. This can be achieved by disabling the item for a specific dropdownlist component by adding the custom class for the popup element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

In the following code, a single list Item is hidden using jsinterop.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-listitem.razor %}

{% endhighlight %}

{% tabs %}
{% highlight razor tabtitle="~/_Layout.cshtml" %}

 <script>
        window.disable = function (id) { 
    setTimeout(function (e) { 
        var liCollections = document.querySelectorAll('.e-popup.e-custom-class .e-list-item') 
        if (liCollections && liCollections.length > 0) 
        liCollections[1].classList.add('e-disabled'); 
        liCollections[1].classList.add('e-overlay'); 
    }, 30); 
 } 
</script>

{% endhighlight %}
{% endtabs %}

![Blazor DropDownList with Popup Width](./images/style/blazor_dropdown_disable-listitem.png)

## Adding conditional HTML attribute to list item

This is achieved by adding attributes to the li items based on the data source value with the help of the JSInterop. In the [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Opened) event, call the client-side script by passing the required arguments (data source and id) and adding the attributes based on the data source value obtained from the server.

In the following example, the `Opened` event is used to call the `AddAttribute` method when the DropDownList is opened. The `AddAttribute` method gets the data source from the component instance and calls a JavaScript function using the JavaScript Interop. The JavaScript function receives the data source and the ID of the DropDownList as arguments, and adds the attributes to the li elements based on the data source values.

% highlight cshtml %}

{% include_relative code-snippet/style/add-attribute-listitem.razor %}

{% endhighlight %}

{% tabs %}
{% highlight razor tabtitle="~/_Layout.cshtml" %}

    <script> 
        function AddAttribute(datasource, id) { 
            setTimeout(() => { 
                //Here, the popup element is uniquely identified with an id 
                //Classes added via CssClass property will be added to the popup element also. 
                //You can also uniquely identify the popup element with the help of the added classes. 
                console.log(document.getElementById(id + "_popup")); 
                var listItems = document.getElementById(id + "_popup").querySelectorAll('li'); 
                for (var i = 0; i < listItems.length; i++) { 
                    listItems[i].setAttribute(Object.keys(datasource[i])[2], datasource[i].isAvailable) 
                } 
            }, 100) 
 
        } 
    </script>

{% endhighlight %}
{% endtabs %}

![Adding attribute to listitem in dropdown list](./images/style/blazor_dropdown_add-attribute-listitem.png)

## Displaying dropdown List in Tab

Use the DropDownList component inside a tab view to allow users to select an option from a DropDownList within a tab. This may be accomplished by displaying the dropdown list within the SfTab.

In the following example, the SfTab component is used to display a tab view with three tab items. Each tab item contains a DropDownList component with a different data source. When the user selects a different tab, the corresponding DropDownList is displayed.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-in-tabview.razor %}

{% endhighlight %}

![Blazor DropDownList with tooltip](./images/style/blazor_dropdown-in-tabview.png)

## Dropdownlist inside Dialog

Use the DropDownList inside a dialog component to allow users to select an option from a DropDownList within a dialog box. This can be accomplished by presenting the dropdownlist within the SfDialog.

In the following example, the SfDialog component is used to display a dialog popup with a DropDownList component inside the dialog content. When the user clicks the `Open Dialog` button, the dialog is displayed.

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-inside-dialog.razor %}

{% endhighlight %}

![Blazor DropDownList with tooltip](./images/style/blazor_dropdown_inside-dialog.gif)

## Properties

### CssClass  

Specifies the CSS class name that can be appended with the root element of the DropDownList. One or more custom CSS classes can be added to a DropDownList.

Some of the possible values are

* `e-success`, which denotes the component in success state that is added green color to the dropdownlist's input field.
* `e-warning`, which denotes the component in warning state that is added orange color to the dropdownlist's input field.
* `e-error`, which denotes the component in error state that is added red color to the dropdownlist's input field.
* `e-outline`, which supports only in material theme.
* `e-multi-column`, which provides two or more columns in the popup and the column will be aligned like grid.

{% highlight Razor %}

{% include_relative code-snippet/style/cssclass-properties.razor %}

{% endhighlight %} 

![Blazor DropDownList with CssClass property](./images/style/blazor_dropdown_cssclass-property.png)

### HtmlAttributes  

Allows additional HTML attributes such as title, name, etc., and accepts n number of attributes in a key-value pair format.

{% highlight cshtml %}

{% include_relative code-snippet/style/html-attributes.razor %}

{% endhighlight %}

![Blazor DropDownList with different font family](./images/style/blazor_dropdown_html-attributes.png)

### InputAttributes

You can add the additional input attributes such as disabled, value, and more to the root element.

If you configured both the property and equivalent input attribute, then the component considers the property value.

{% highlight Razor %}

{% include_relative code-snippet/style/inputAttributes-property.razor %}

{% endhighlight %} 

![Blazor DropDownList with HtmlAttributes property](./images/style/blazor_dropdown_input-attributes-propety.png)

### Readonly

Specifies the boolean value whether the DropDownList allows the user to change the value.

Default value of Readonly is `false`.

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

![Blazor DropDownList with Readonly mode](./images/style/blazor_dropdown_readonly-mode.png)

### TabIndex

Specifies the tab order of the DropDownList component.

{% highlight Razor %}

{% include_relative code-snippet/style/tabIndex-property.razor %}

{% endhighlight %}

### ValueExpression

Specifies the expression for defining the value of the bound.

[Click to refer the code for ValueExpression](https://blazor.syncfusion.com/documentation/dropdown-list/how-to/tooltip)

## Methods

### HideSpinnerAsync()

Hides the spinner loader.

#### Declarations

> public Task HideSpinnerAsync()

### ShowSpinnerAsync()

Shows the spinner loader.

#### Declarations

> public Task ShowSpinnerAsync()

{% highlight Razor %}

{% include_relative code-snippet/style/show-or-hide-spinner-method.razor %}

{% endhighlight %} 

![Show or hide spinner in Blazor DropDownList](./images/style/blazor_dropdown_readonly-mode.png)
