---
layout: post
title: Popup Setting in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Popup Setting in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Popup Setting in Dropdown List

## Change the popup width

Specifies the width of the popup list. By default, the popup width sets based on the width of the component.

Default value of [`PopupWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupWidth) is `100%`

In the below sample PopupWidth is set as 300px

{% highlight cshtml %}

{% include_relative code-snippet/popup-setting/popup-width.razor %}

{% endhighlight %}

![Grouping in Blazor DropdownList](./images/popup-setting/blazor_dropdown_popup-width.png)

### TextOverflow

You can see width of the popup is less than the text, then text-overflow:ellipsis will be automatically appeared.

In the below sample PopupWidth is set as 100px then text-overflow:ellipsis is automatically applied

{% highlight cshtml %}

{% include_relative code-snippet/popup-setting/text-overflow.razor %}

{% endhighlight %}

![Grouping in Blazor DropdownList](./images/popup-setting/blazor_dropdown_text-overflow.png)

## Change the popup height

Specifies the height of the popup list.

Default value of PopupHeight is `300px`.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/popup-height.razor %}

{% endhighlight %}

![Grouping in Blazor DropdownList](./images/popup-setting/blazor_dropdown_popup-height.png)

## Change the popup z-index

Specifies the z-index value of the component popup element.

Defaults to 1000

## Show popup on initial loading

You can achieve this by using [`ShowPopupAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ShowPopupAsync) in the Created Event.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/show-popup-on-initial-loading.razor %}

{% endhighlight %}

![Grouping in Blazor DropdownList](./images/popup-setting/blazor_dropdown_popup-initial-loading.png)

## Preventing opening and closing

You can prevent the popup open and close in event argument like args.cancel as true. It can be achieved OnOpen and OnClose events. 

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/preventing-opening-closing.razor %}

{% endhighlight %}

![Grouping in Blazor DropdownList](./images/popup-setting/blazor_dropdown_preventing-opening-closing.png)

## Popup height based on available space

You can achieve this by binding resize event in window and update the height of the popup based on the window height.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/popup-resize.razor %}

{% endhighlight %}

{% tabs %}
{% highlight razor tabtitle="Layout.razor" %}

<script>
    window.addEventListener("resize", function (e) {
        var wrapper = document.getElementById("dropdown").parentElement;
        var popupEle = document.getElementById("dropdown_popup");
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

![Grouping in Blazor DropdownList](./images/popup-setting/blazor_dropdown_popup_resize.gif)

## Events

### OnOpen event

The [`OnOpen`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnOpen) event triggers when the popup is opened. If you cancel this event, the popup remains closed.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/onopen-event.razor %}

{% endhighlight %}

### Opened event

The [`Opened`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Opened) event triggers when the popup opens.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/opened-event.razor %}

{% endhighlight %}

### OnClose event

The [`OnClose`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnClose) event triggers before the popup is closed. If you cancel this event, the popup will remain open.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/onclose-event.razor %}

{% endhighlight %}

### Closed event

The [`Closed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnClose) event triggers after the popup has been closed.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/closed-event.razor %}

{% endhighlight %}
