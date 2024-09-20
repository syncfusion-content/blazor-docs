---
layout: post
title: Templates in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Templates in the Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Templates in Blazor MultiColumn ComboBox Component

The MultiColumn ComboBox has been provided with several options to customize each header elements.

## Header template

The header element is shown statically at the top of the popup list items within the ComboBox, and any custom element can be placed as a header element using the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) property.

In the following sample, the header of the first column includes the profile icon.

{% highlight cshtml %}

{% include_relative code-snippet/templates/header-template.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVftkhjMyQEKAqB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox with HeaderTemplate](./images/templates/header_template.png)
