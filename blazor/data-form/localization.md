---
layout: post
title: Localization in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to localize the label text and error messages in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Localization in Blazor DataForm Component

DataForm component can be localized to any particular culture. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Configuring localization for label text and error messages

Follow the below steps to configure localization for label text and error messages in Blazor DataForm component.

1.After integrating the localization files in your application as mentioned in the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) section ,Open the required culture file in the Visual Studio.

![Localization step-1](./images/blazor_dataform_localization_step.png)


2.In the opened file click on `Add Resource` button and include the suitable key with the corresponding localized text as like below.


![Localization step-1](./images/blazor_dataform_localization_step1.png)

3.Then, include the [ResourceType](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute.resourcetype?view=net-5.0#system-componentmodel-dataannotations-displayattribute-resourcetype) which we have formed under `Resources` folder and key for the localized text within the [Display](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute?view=net-5.0) attribute of the corresponding property in the model class.Similarly you can localize the error messages in the DataForm component by including the [ErrorMessageResourceType](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute.errormessageresourcetype?view=net-5.0#system-componentmodel-dataannotations-validationattribute-errormessageresourcetype) and [ErrorMessageResourceName](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute.errormessageresourcename?view=net-5.0#system-componentmodel-dataannotations-validationattribute-errormessageresourcename) properties within the [Required](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.requiredattribute?view=net-5.0) attribute of the corresponding property in the model class as mentioned in the below code snippet.

| ![Localization step 3](./images/blazor_dataform_localization_step3.png) | ![Localization step 3](./images/blazor_dataform_localization_step3_2.png) |


{% tabs %}
{% highlight razor tabtitle="Razor"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Calendars


<SfDataForm ID="MyForm"
            Model="@CreditCardModel"
            ValidationDisplayMode="FormValidationDisplay.Tooltip">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
        <ValidationSummary></ValidationSummary>
    </FormValidator>

    <FormItems>
        <FormItem Field="@nameof(CreditCardModel.Name)" Placeholder="e.g. Andrew Fuller" LabelText="Name on card"></FormItem>
        <FormItem Field="@nameof(CreditCardModel.CardNumber)" LabelText="Card Number">
        </FormItem>
        <FormItem Field="@nameof(CreditCardModel.CVV)" ID="CVV">
            <Template>
                <label class="e-form-label">CVV*:</label>
                <SfMaskedTextBox Mask="000" @bind-Value="CreditCardModel.CVV" ID="CVV"></SfMaskedTextBox>
            </Template>
        </FormItem>
        <FormItem Field="@nameof(CreditCardModel.ExpiryDate)" ID="ExpiryDate">
            <Template>
                <label class="e-form-label">Expiry Date*:</label>
                <SfDatePicker TValue="DateTime?" Format="MM/yy" EnableMask="true" ID="ExpiryDate"></SfDatePicker>
            </Template>
        </FormItem>
    </FormItems>

</SfDataForm>


@code {
    public char PromptCharacter { get; set; } = ' ';
    private CreditCard CreditCardModel = new CreditCard();
}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}
public class CreditCard
{
    [Required(ErrorMessage = "Please enter the name on card")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter the card number")]
    [CreditCard]
    public string CardNumber { get; set; }

    [Required(ErrorMessage = "Please enter cvv number")]
    public string CVV { get; set; }

    [Required(ErrorMessage = "Please select/enter expiry date")]
    public DateTime? ExpiryDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

![Localization in DataForm component](./images/blazor_dataform_localization.png)
