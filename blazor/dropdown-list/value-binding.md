

## Two way binding

The strongly type support and two-way binding support has been provided for Dropdownlist . Therefore, @bind attribute needs to be specified for Value property so that when every value gets changed, changed value will be updated in the bound variable

{% highlight cshtml %}

{% include_relative code-snippet/data-binding/two-way-binding.razor %}

{% endhighlight %}

![Blazor DropdownList with Two way binding](./images/value-binding/blazor_dropdown_two-way-binding.png)


## Dynamically changing TItem

### Dynamically changing TItem using templates

You can render the DropDownList component with [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) and [ValueTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ValueTemplate) with help of RenderFragment

need to add code.