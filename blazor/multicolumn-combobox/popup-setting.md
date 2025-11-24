---
layout: post
title: Popup Setting in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Popup Setting in Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Popup Setting in MultiColumn ComboBox

## Change the popup width

Customize the width of the popup using the [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupWidth) property. If popup width unspecified, it sets based on the width of the MultiColumn ComboBox component.

In the following sample, the `PopupWidth` is set as `600px`.

{% highlight cshtml %}

{% include_relative code-snippet/popup-setting/popup-width.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZVpjuVgTiMSUiaN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Popup Width](./images/popup-setting/blazor_multicolumn_combobox_popup_width.gif)" %}

## Change the popup height

Customize the height of the popup using the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupHeight) property.

In the following sample, the `PopupHeight` is set as `500px`.

{% highlight cshtml %}

{% include_relative code-snippet/popup-setting/popup-height.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBpDYVqfsBWhhbe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Popup Height](./images/popup-setting/blazor_multicolumn_combobox_popup_height.gif)" %}

## Change the popup z-index

Customize the [z-index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ZIndex) value of the component popup element.

Defaults to `1000`

## Show popup on initial loading

You can achieve this by using [ShowPopupAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ShowPopupAsync) in the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxEvents-2.html#Syncfusion_Blazor_DropDowns_ComboBoxEvents_2_Created) Event.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/show-popup-on-initial-loading.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with Show popup on initial loading](./images/popup-setting/blazor_multicolumn_combobox_show-popup-on-initial-loading.gif)

## Preventing opening and closing

Prevent the popup open and close in the event argument like [PopupOpeningEventArgs.cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.PopupOpeningEventArgs.html#Syncfusion_Blazor_MultiColumnComboBox_PopupOpeningEventArgs_Cancel) and [PopupClosingEventArgs.cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.PopupClosingEventArgs.html#Syncfusion_Blazor_MultiColumnComboBox_PopupClosingEventArgs_Cancel) as `true`. It is achieved by the [PopupOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupOpening) and [PopupClosing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupClosing) events. 

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/preventing-opening-closing.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthpZaLATiBxZOUT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Preventing opening and closing](./images/popup-setting/blazor_multicolumn_combobox_preventing_opening_closing.gif)" %}

The following events are used to trigger when opening and closing popup.

### PopupOpening event

The [PopupOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupOpening) event triggers when the popup is opened. If you cancel this event, the popup remains closed.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/popupopening-event.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVTjaLqTCKWriug?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with PopupOpening event](./images/popup-setting/blazor_multicolumn_combobox_popupopening_event.gif)" %}

### PopupOpened event

The [PopupOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupOpened) event triggers when the popup opens.

### PopupClosing event

The [PopupClosing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupClosing) event triggers before the popup is closed. If you cancel this event, the popup will remain open.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/popupclosing-event.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrztOrApMUzEyWp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Popup Closing event](./images/popup-setting/blazor_multicolumn_combobox_popupclosing_event.gif)" %}

### PopupClosed event

The [PopupClosed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupClosed) event triggers after the popup has been closed.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/popupclosed-event.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVTZaBATiKbyovf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with PopupClosed event](./images/popup-setting/blazor_multicolumn_combobox_popupclosed_event.gif)" %}

## Popup height based on available space

You can achieve this by binding the `resize` event in window and update the height of the popup based on the window height.

{% highlight Razor %}

{% include_relative code-snippet/popup-setting/popup-resize.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVpDEhUJMTfqTjg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Popup resize](./images/popup-setting/blazor_multicolumn_combobox_popup_resize.gif)" %}

{% tabs %}
{% highlight razor tabtitle="Layout.razor" %}

<script>
    window.addEventListener("resize", function (e) {
        var wrapper = document.getElementById("multicolumncombobox").parentElement;
        var popupEle = document.getElementById("multicolumncombobox_popup");
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
