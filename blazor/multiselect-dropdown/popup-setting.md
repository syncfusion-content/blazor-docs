---
layout: post
title: Popup Setting in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about Popup Setting in Syncfusion Blazor MultiSelect component and much more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Popup Setting in MultiSelect

## Popup resize

You can dynamically adjust the size of the popup in the MultiSelect component by using the [AllowResize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_AllowResize) property. When enabled, users can resize the popup, improving visibility and control, with the resized dimensions being retained across sessions for a consistent user experience.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/resize.razor %}

{% endhighlight %} 

![Blazor MultiSelect with AllowResize property](./images/popup-setting/blazor_multiselect_resize.gif)

## Change the PopupHeight

Use the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_PopupHeight) property to change the height of the popup. The default value of the `PopupHeight` is `300px`.

{% highlight Razor %}

{% include_relative code-snippet/style/popupHeight-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with PopupHeight property](./images/style/blazor_multiselect_popupHeight-property.png)

## Change the PopupWidth

To customize the width of the popup alone, use the [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_PopupWidth) property. The default value of the `PopupWidth` is `100%`. If popup width unspecified, it sets based on the width of the MultiSelect component.

{% highlight Razor %}

{% include_relative code-snippet/style/popupWidth-property.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with PopupWidth property](./images/style/blazor_multiselect_popupWidth-property.png)

## Change the popup z-index

Customize the [z-index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ZIndex) value of the component popup element.

Defaults to `1000`.

## Show popup on initial loading

You can achieve this by using [ShowPopupAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_ShowPopupAsync) in the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Created) Event.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/show-popup-on-initial-loading.razor %}

{% endhighlight %}

## Preventing opening and closing

Prevent the popup open and close in the event argument like [BeforeOpenEventArgs.cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.BeforeOpenEventArgs.html#Syncfusion_Blazor_DropDowns_BeforeOpenEventArgs_Cancel) and [PopupEventArgs.cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.PopupEventArgs.html#Syncfusion_Blazor_DropDowns_PopupEventArgs_Cancel) as `true`. It is achieved by the [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnOpen) and [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnClose) events. 

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/preventing-opening-closing.razor %}

{% endhighlight %}

![Blazor MultiSelect with Preventing opening and closing](./images/popup-setting/blazor_MultiSelect_preventing-opening-closing.png)

The following events are used to trigger when opening and closing popup.

### OnOpen event

The [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnOpen) event triggers when the popup is opened. If you cancel this event, the popup remains closed.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/onopen-event.razor %}

{% endhighlight %}

### Opened event

The [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Opened) event triggers when the popup opens.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/opened-event.razor %}

{% endhighlight %}

### OnClose event

The [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_OnClose) event triggers before the popup is closed. If you cancel this event, the popup will remain open.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/onclose-event.razor %}

{% endhighlight %}

### Closed event

The [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_Closed) event triggers after the popup has been closed.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/closed-event.razor %}

{% endhighlight %}

## Popup height based on available space

You can achieve this by binding the `resize` event in window and update the height of the popup based on the window height.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/popup-resize.razor %}

{% endhighlight %}

{% tabs %}
{% highlight razor tabtitle="Layout.razor" %}

<script>
    window.addEventListener("resize", function (e) {
        var wrapper = document.getElementById("multiselect").parentElement;
        var popupEle = document.getElementById("multiselect_popup");
        var topVal = wrapper.getBoundingClientRect().top;
        window.innerHeight - topVal;
        if (popupEle) {
            popupEle.style.maxHeight = (window.innerHeight - topVal-50) + "px";
            popupEle.style.height = (window.innerHeight - topVal-50) + "px";

        }
    })
</script>

{% endhighlight %}
{% endtabs %}

![Popup height based on available space in Blazor Multiselect](./images/popup-setting/blazor_multiselect_popup_resize.gif)

## Programmatically opening and closing popup

You can programmatically open and close the popup by accessing the `ShowPopupAsync()` and `HidePopupAsync()` methods through an instance of the multiselect. Bind the click event of a button to these methods. When the button is clicked, it will trigger the respective method and open or close the popup.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/show-or-hide-popup.razor %}

{% endhighlight %} 

![Show or Hide Popup in Blazor Multiselect](./images/popup-setting/blazor_multiselect_show-or-hide-popup.gif)
