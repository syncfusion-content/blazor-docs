---
layout: post
title: Data Binding in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Data Binding in Blazor DropDown List Component

Data binding can be achieved by using the `bind-Value` attribute and it supports string, int, Enum and bool types. If component value has been changed, it will affect all the places where you bind the variable for the **bind-value** attribute.

* **TValue** - specifies the type of the each list item of the dropdown component.
* **TItem** - specifies the type of the whole list of the dropdown component.

## Binding Local Data

Below code demonstrate the binding local data to the DropDownList.

```cshtml
@using Syncfusion.Blazor.DropDowns

<p>DropDownList value is:<strong>@DropVal</strong></p>

<SfDropDownList TValue="string" Placeholder="e.g. Australia" TItem="Country" @bind-Value="@DropVal" DataSource="@Countries">
    <DropDownListFieldSettings Value="Name"></DropDownListFieldSettings>
</SfDropDownList>

@code {

    public string DropVal;

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    List<Country> Countries = new List<Country>
{
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
    };
}
```

### Primitive type

You can bind the data to the DropDownList as a list of string, int, double and bool type items.

The following code demonstrates array of string and integer values to the DropDownList component.

```cshtml

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/primitive-type-string %}

{% endhighlight %}

```

```cshtml

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/primitive-type-int %}

{% endhighlight %}

```

### Complex data type

The DropDownList can generate its list items through an array of complex data. For this, the appropriate columns should be mapped to the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FieldSettingsModel.html) property.

In the following example, `Code.ID` column and `Country.CountryID` column from complex data have been mapped to the `Value` field and `Text` field, respectively.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/complex-data-type %}

{% endhighlight %}

### Expando object binding

You can bind ExpandoObject data to the DropDownList component. The following example `ExpandoObject` is bound to the collection of vehicles data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/expando-object-binding %}

{% endhighlight %}


### Observable collection binding

You can bind ObservableCollection data to the DropDownList component. In the following example, `Observable Data` is bound to a collection of colors data.

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/observable-collection %}

{% endhighlight %}


### Dynamic object binding



### Enum data binding




## Index Value Binding

Index value binding can be achieved by using `bind-Index` attribute and it supports int and int nullable types. By using this attribute you can bind the values respective to its index.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TValue="string" Placeholder="e.g. Australia" TItem="Country" @bind-Index="@ddlIndex" DataSource="@Countries">
    <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {

    private int? ddlIndex { get; set; } = 1;

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    List<Country> Countries = new List<Country>
{
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
    };
}
```