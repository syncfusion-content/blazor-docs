---
layout: post
title: Templates in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to customize the specific editor component or entire form components in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Templates in DataForm component

In DataForm component we can customize the specific editor field or the entire form components using template feature. 

## Customization of specific field editor

We can customize the particular field editor with required UI customization using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.Template.html) `RenderFragment` inside `FormItem` tag.

{% tabs %}
{% highlight razor tabtitle="Template"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Calendars


<SfDataForm ID="MyForm"
            Model="@CreditCardModel"
            Width="50%">
            
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormItem Field="@nameof(CreditCardModel.Name)" Placeholder="e.g. Andrew Fuller" LabelText="Name on card" ></FormItem>
        <FormItem Field="@nameof(CreditCardModel.CardNumber)" LabelText="Card Number" >
        </FormItem>
        <FormItem Field="@nameof(CreditCardModel.CVV)">
            <Template>
                <label class="e-form-label">CVV*:</label>
                <SfMaskedTextBox Mask="000" @bind-Value="CreditCardModel.CVV" ></SfMaskedTextBox>
            </Template>
        </FormItem>
        <FormItem Field="@nameof(CreditCardModel.ExpiryDate)">
            <Template>
                <label class="e-form-label">Expiry Date*:</label>
                <SfDatePicker TValue="DateTime?" Format="MM/yy" EnableMask="true"></SfDatePicker>
            </Template>
        </FormItem>
    </FormItems>

</SfDataForm>


@code {
    public char PromptCharacter { get; set; } = ' ';

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

    private CreditCard CreditCardModel = new CreditCard();
}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_template.png)

We can also utilize the above `Template` combination with [FormAutoGenerateItems](./form-items.md) which will generate the items except the specified `Formitem`.


## Customization of entire form

`DataForm` have the ability to customize the entire structure of the form, incorporating necessary components within it, and we can also personalize the messages displayed for validation errors.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns
<div class="col-lg-12 control-section">
    <div class="control-wrapper">
        <SfStepper Linear=true ID="stepperValidation" @ref="validationStepper" StepChanging="handleStepChange">
            <StepperSteps>
                <StepperStep IconCss="sf-icon-shopping-cart_01-" Text="Product Details"></StepperStep>
                <StepperStep @ref="stepperStep" IconCss="sf-icon-check" Text="Billing Details"></StepperStep>
            </StepperSteps>
        </SfStepper>
        <div class="form-section">
            <SfDataForm ID="MyForm"
                        Model="ProductDetailsModel"
                        OnValidSubmit="ValidSubmitHandler" OnInvalidSubmit="InValidSubmithandler" ButtonsAlignment="FormButtonsAlignment.Center">
                <FormValidator>
                    <DataAnnotationsValidator></DataAnnotationsValidator>
                    <ValidationSummary />
                </FormValidator>
                <FormTemplate>
                    <div class="product-details" style="display: @ProductContainerDisplay">
                        <h5 class="control-header">Product Info</h5>
                        <div class="form-group">
                            <label class="e-form-label">Category</label>
                            <SfTextBox @bind-Value="ProductDetailsModel.Category" Readonly="true" />
                        </div>
                        <div class="form-group">
                            <label class="e-form-label">Brand</label>
                            <SfDropDownList TValue="string" TItem="string" DataSource="BrandData" @bind-Value="ProductDetailsModel.Brand">
                            </SfDropDownList>
                        </div>
                        <div class="form-group">
                            <label class="e-form-label">Color</label>
                            <SfDropDownList TValue="string" TItem="string" DataSource="Colors" @bind-Value="ProductDetailsModel.Color"></SfDropDownList>
                        </div>
                        <div class="form-group">
                            <label class="e-form-label">Size</label>
                            <SfDropDownList TValue="string" TItem="string" DataSource="SizeData" @bind-Value="ProductDetailsModel.Size"></SfDropDownList>
                        </div>
                    </div>
                    <div class="payment-info" style="display: @BillingContainerDisplay">
                        <h5 class="control-header">Payment Details</h5>
                        <div class="form-group">
                            <label class="e-form-label">Contact Number</label>
                            <SfMaskedTextBox Mask="+(00) 0000000000" Placeholder="eg. +12 1234567890" @bind-Value="ProductDetailsModel.ContactNumber" />
                        </div>
                        <div class="form-group">
                            <label class="e-form-label">Shipping Address</label>
                            <SfTextBox Multiline="true" @bind-Value="ProductDetailsModel.ShippingAddress" />
                        </div>
                        <div class="form-group">
                            <label class="e-form-label">Delivery Instructions (Optional)</label>
                            <SfTextBox Multiline="true" @bind-Value="ProductDetailsModel.DeliveryInstructions" Placeholder="Landmark , alternate contact number etc.. " />
                        </div>
                    </div>
                </FormTemplate>
                <FormButtons>
                    <SfButton>Buy now</SfButton>
                </FormButtons>
            </SfDataForm>
        </div>
    </div>
</div>

@code {
    private SfStepper validationStepper;
    private StepperStep stepperStep;
    public string ProductContainerDisplay { get; set; } = "block";
    public string BillingContainerDisplay { get; set; } = "none";
    public string[] BrandData = new string[] { "Adidas", "Puma", "Reebok", "Nike", "Skechers", "Vans" };
    public string[] Colors = new string[] { "Black", "Grey", "White", "Red", "Beige", "Pink", "Off-White" };
    public string[] SizeData = new string[] { "6UK", "7UK", "8UK", "9UK", "10UK", "11UK" };
    public void InValidSubmithandler()
    {
        stepperStep.IsValid = false;
    }
    public void ValidSubmitHandler()
    {
        stepperStep.IsValid = true;
    }
    private void handleStepChange(StepperChangedEventArgs args)
    {
        if (args.ActiveStep == 0)
        {
            ProductContainerDisplay = "block";
            BillingContainerDisplay = "none";
        }
        else
        {
            ProductContainerDisplay = "none";
            BillingContainerDisplay = "block";
        }
    }
    private ProductDetails ProductDetailsModel = new ProductDetails()
        {
            Category = "Shoes - Men",
            Color = "Black",
            Size = "6UK"
        };
}

{% endhighlight %}
{% highlight razor tabtitle="C#"  %}

    public class ProductDetails
    {
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter the brand.")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter the color.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please enter the size.")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Please enter the shipping address.")]
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string DeliveryInstructions { get; set; }
        [Required(ErrorMessage = "Please enter your contact number.")]
        public string ContactNumber { get; set; }
    }
{% endhighlight %}
{% highlight cshtml tabtitle="Css"  %}

    <style>
    .control-wrapper {
        max-width: 400px;
        margin: 0 auto;
        padding: 0px 0px 0px;
    }

    .control-header {
        text-align: center;
    }

    .form-group {
        margin-bottom: 1em;
    }

    .form-section {
        margin-top: 20x;
    }

    .sf-icon-shopping-cart_01-:before {
        content: "\e710";
    }

    .sf-icon-check:before {
        content: "\e715";
    }

    @@font-face {
        font-family: 'Default';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    [class^="sf-icon-"], [class*=" sf-icon-"] {
        font-family: 'Default' !important;
        speak: none;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: inherit;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }
</style>
{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_template.png)

We can also integrate the `FormTemplate` renderer along with `FormItem` as showcased in the below example.

{% tabs %}
{% highlight razor tabtitle="Form Template"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations

<SfDataForm Width="50%"
            Model="@RegistrationDetailsModel">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormItem Field="@nameof(RegistrationDetailsModel.Name)"></FormItem>
    </FormItems>

    <FormTemplate>
         @* Insert your template layout code here to incorporate additional editor components corresponding to their respective fields *@
    </FormTemplate>

</SfDataForm>

@code {

    public class RegistrationDetails
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }
    }

    private RegistrationDetails RegistrationDetailsModel = new RegistrationDetails();
}

{% endhighlight %}
{% endtabs %}

## Tooltip validation message with template

When using the `Template` renderer, we can also customize the validation message with the help of `Tooltip` component by setting `ID` field to the custom editor component similar to the form item's `ID` property.

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

![Blazor DataForm Form Item](images/blazor_dataform_tooltip_with_templates.png)

## Validation summary 

The [ValidationSummary](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.validationsummary?view=aspnetcore-8.0) tag can be utilized to present a summary of validation messages, and it should be positioned within the `FormValidator` tag to function correctly.The below example demonstrates the usage of it.

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

![Blazor DataForm Form Item](images/blazor_dataform_validation_summary.png)
