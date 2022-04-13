---
layout: post
title: Populating items with Blazor Carousel Component | Syncfusion
description: Checkout and learn about populating items with Blazor Carousel component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Carousel
documentation: ug
---

# Populating Items

## Populating items using carousel item

When rendering the Carousel component using items binding, you can assign templates for each item separately or assign a common template to each item. You can also customize the slide transition interval for each item separately. The following example code depicts the functionality as item property binding.

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/populating-items/carousel-item/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/populating-items/carousel-item/carousel-item.cs %}
{% endhighlight %}
{% endtabs %}

## Selection

The Carousel items will be populated from the first index of the Carousel items and can be customized using the following ways,

* Select an item using the property.
* Select an item using the method.

### Select an item using the property

Using the `SelectedIndex` property of the Carousel component, you can set the slide to be populated at the time of initial rendering else you can switch to the particular slide item.

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/populating-items/select-item/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/populating-items/select-item/select-item.cs %}
{% endhighlight %}
{% endtabs %}

### Select an item using the method

Using the `PreviousAsync` or `NextAsync` public method of the Carousel component, you can switch the current populating slide to a previous or next slide.

{% tabs %}
{% highlight cshtml tabtitle="CSHTML" %}
{% include code-snippet/carousel/populating-items/select-item-method/tagHelper %}
{% endhighlight %}
{% highlight c# tabtitle="Data.cs" %}
{% include code-snippet/carousel/populating-items/select-item-method/select-item-method.cs %}
{% endhighlight %}
{% endtabs %}
