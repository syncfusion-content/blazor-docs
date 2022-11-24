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

![Blazor DropDownList with Disabled component's text color](./images/style/blazor_dropdown_disable-text-color.png)

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

To display the tooltip in dropdown component, you need to add the title attribute through HtmlAttributes property, which update the attribute to the root element `input`

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

% highlight cshtml %}

{% include_relative code-snippet/style/popup-height.razor %}

{% endhighlight %}

![Blazor DropDownList with Popup height](./images/style/blazor_dropdown_height.png)

### Width of dropdownlist

To customize the width of the popup alone, use the [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupWidth) property. By default, the popup width is set based on the component's width. Use the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Width) to change the width of the component.

% highlight cshtml %}

{% include_relative code-snippet/style/popup-width.razor %}

{% endhighlight %}

![Blazor DropDownList with Popup Width](./images/style/blazor_dropdown_width-popup-width.png)

## Disable specfic items in dropdown list

Prevent some items in the popup list from selecting. This can be achieved by disabling the item for a specific dropdownlist component by adding the custom class for the popup element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_CssClass) property.

In the following code, a single list Item is hidden using jsinterop.

% highlight cshtml %}

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

You can achieve adding attributes to the li items based on datasource value with the help of JSInterop. In the, Opened event need to call the client side script by passing the required arguments (datasource and id) and add the attributes based on the datasource value obtained from the server.

% highlight cshtml %}

{% include_relative code-snippet/style/add-attribute-listitem.razor %}

{% endhighlight %}

{% tabs %}
{% highlight razor tabtitle="~/_Layout.cshtml" %}

    <script> 
        function OnCreated(datasource, id) { 
            setTimeout(() => { 
                //Here popup element is uniquely identified with id. 
                //Classes added via CssClass property will be added to the popup element also. 
                //You can also uniquely identify the popup element with the help of added class. 
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

You can achieve this by rendering the dropdown list inside the SfTab

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-in-tabview.razor %}

{% endhighlight %}

![Blazor DropDownList with tooltip](./images/style/blazor_dropdown-in-tabview.png)

## Dropdownlist inside Dialog

You can achieve this by rendering dropdownlist inside the SfDialog

{% highlight cshtml %}

{% include_relative code-snippet/style/dropdown-inside-dialog.razor %}

{% endhighlight %}

![Blazor DropDownList with tooltip](./images/style/blazor_dropdown_inside-dialog.gif)




