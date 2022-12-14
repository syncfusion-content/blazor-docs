---
layout: post
title: Data Binding in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Mention component and more.
platform: Blazor
control: Mention
documentation: ug
---

# Working with Data in Mention

The DropDownList loads the data either from the local data sources or remote data services. Using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property,  bind the local data or using the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html), bind the remote data.

* **TItem** - Specifies the type of the datasource of the Mention component.

## Binding local data

### Array of complex data

The DropDownList can generate its list items through an array of complex data. For this, the appropriate columns should be mapped to the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html) property.

In the following example, the `Code.ID` column and `Country.CountryID` column from complex data have been mapped to the `Value` and  `Text` respectively.

{% highlight razor %}

{% include_relative code-snippet/complex-data.razor %}

{% endhighlight %}

![Blazor Mention with sortOrder descending](./images/blazor-mention-complex-data.png)
