---
layout: post
title: Getting Started with Blazor ComboBox Component | Syncfusion
description: Checkout and learn about Form validation with Blazor ComboBox component in Blazor Sever App and Blazor WebAssembly App.
platform: Blazor
control: ComboBox
documentation: ug
---

# Form Validation in ComboBox

## ComboBox inside edit form

EditForm validates all data annotation rules using `DataAnnotationsValidator`. Type or choose the value from the dropdown popup and if the value is valid, then the given input will be ready to submit. Otherwise, an error message will be shown until you choose the valid value. 

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/combobox-inside-editform.razor %}

{% endhighlight %}

![Blazor ComboBox inside editform](./images/form-validation/blazor_combobox_inside-editform.png)

## Form validation using injectable datasource

ComboBox component inside Edit form with required field validation with the injectable datasource is mentioned in the below sample.

{% highlight cshtml %}

{% include_relative code-snippet/form-validation/editform-validation.razor %}

{% endhighlight %}

{% tabs %}
{% highlight cshtml tabtitle="WeatherForecast.cs" %}

    public class Countries
    {
        [Required(ErrorMessage = "The Country field is required.")]
        public string Name { get; set; }

        public string Code { get; set; }
    }

{% endhighlight %}

{% highlight cshtml tabtitle="OwnService.cs " %}

    public class CountryService
    {

        public async Task<List<Countries>> GetDataAsync()
        {
            List<Countries> Country = new List<Countries>
        {
            new Countries() { Name = "Australia", Code = "AU" },
            new Countries() { Name = "Bermuda", Code = "BM" },
            new Countries() { Name = "Canada", Code = "CA" },
            new Countries() { Name = "Cameroon", Code = "CM" },
            new Countries() { Name = "Denmark", Code = "DK" },
            new Countries() { Name = "France", Code = "FR" },
            new Countries() { Name = "Finland", Code = "FI" }
        };
            return await Task.FromResult(Country);
        }
        public async Task<string> GetPreSelectDataAsync()
        {
            string value = "AU";

            return await Task.FromResult(value);
        }

    }

{% endhighlight %}
{% endtabs %}

![Blazor ComboBox with editform validation](./images/form-validation/blazor_combobox_editform-validation.gif)