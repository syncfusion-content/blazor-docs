---
layout: post
title: How to Hide DataGrid Header in Blazor DataGrid component - Syncfusion
description: Checkout and learn about Hide DataGrid Header in Blazor DataGrid component of Syncfusion, and more details
platform: Blazor
component: DataGrid
documentation: ug
---

# Hide DataGrid header

You can hide the DataGrid header by applying the below styles to DataGrid component.

{% tabs %}

{% highlight HTML %}

<style>
    .e-grid .e-gridheader .e-columnheader{
        display: none;
    }
</style>

{% endhighlight %}

{% endtabs %}

> if you want to hide the header for particular DataGrid, then you can apply the above styles to that DataGrid using the ID (#Grid.e-grid .e-gridheader .e-columnheader) property value.