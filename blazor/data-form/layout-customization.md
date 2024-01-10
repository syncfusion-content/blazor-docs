---
layout: post
title: Layout customization in Blazor DataForm component | Syncfusion
description: Checkout and learn here about layout customization such button and label positioning and validation message display with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Layout customization in DataForm component

This segment provides a concise overview of how to position buttons and labels correctly within the DataForm component. It also covers how to customize the button elements and the various ways to present validation messages.

## Button Alignment

The DataForm component provides the capability to position the button horizontally within the form container as needed, utilizing the [ButtonsAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html) property .The `ButtonsAlignment` is categorized into three types, as outlined below,

| FormButtonsAlignment | Snapshot |
| ------------ | ----------------------- |
|[FormButtonsAlignment.Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Center)|![DataForm FormButtonsAlignment.Center](images/blazor_dataform_button_alignment_center.png)|
|[FormButtonsAlignment.Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Left)|![DataForm FormButtonsAlignment.Left](images/blazor_dataform_button_alignment_left.png)|
|[FormButtonsAlignment.Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Left)|![DataForm FormButtonsAlignment.Right](images/blazor_dataform_button_alignment_right.png)|
|[FormButtonsAlignment.Stretch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Stretch)|![DataForm FormButtonsAlignment.Stretch](images/blazor_dataform_button_alignment_stretch.png)|

The below example portrays how to use the `ButtonsAlignment` property in DataForm component

{% tabs %}
{% highlight razor tabtitle="ButtonsAlignment"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Model="@RegistrationDetailsModel"
            ButtonsAlignment="FormButtonsAlignment.Center">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

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

## Adding additional buttons and its customization 

It is possible to incorporate custom buttons along with other elements ,if necessary by using the [FormButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtons.html) `RenderFragment` within the DataForm component.

In the provided code snippet, an extra button component is implemented to reset the input fields when pressed, by utilizing its [OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) event handler of [SfButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_OnClick).

{% tabs %}
{% highlight razor tabtitle="ButtonsAlignment"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Buttons


<SfDataForm EditContext="@RegistrationEditContext">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

    <FormButtons>
        <SfButton type="submit" CssClass="e-success">Register</SfButton>
        <SfButton type="button" CssClass="e-warning" OnClick="ClickHandler">Clear</SfButton>
    </FormButtons>

</SfDataForm>

<style>
    .e-data-form .e-btn.e-success {
        margin-right: 5px; 
    }
</style>

@code {
    public EditContext RegistrationEditContext { get; set; }

    protected override void OnInitialized()
    {
        RegistrationEditContext = new EditContext(RegistrationDetailsModel);
        base.OnInitialized();
    }

    public class RegistrationDetails
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }
    }

    private RegistrationDetails RegistrationDetailsModel = new RegistrationDetails();

    public void ClickHandler()
    {
        RegistrationDetailsModel = new RegistrationDetails();
        RegistrationEditContext = new EditContext(RegistrationDetailsModel);
    }
}

{% endhighlight %}
{% endtabs %}

![DataForm Button Customization](images/blazor_dataform_formbuttons.png)

## Label positioning

DataForm component allows you to align the label either to the top or left to the field editors , We can implement this feature by assigning values to [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_LabelPosition) , Classification of the respective property is outlined below ,

| LabelPosition | Snapshot |
| ------------ | ----------------------- |
|[FormLabelPosition.Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormLabelPosition.html#Syncfusion_Blazor_DataForm_FormLabelPosition_Top)|![DataForm FormLabelPosition.Top](images/blazor_dataform_label_position_top.png)|
|[FormLabelPosition.Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormLabelPosition.html#Syncfusion_Blazor_DataForm_FormLabelPosition_Left)|![DataForm FormLabelPosition.Left](images/blazor_dataform_label_position_left.png)|
|When no specific value is provided, the layout defaults to `FormLabelPosition.Top`. For boolean editors like [SfCheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) and [SfSwitch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html), labels will be positioned to the right.  |![DataForm FormLabelPosition.Left](images/blazor_dataform_default_label_position.png)|

The below code part explains how to configure the `LabelPosition` in DataForm component.

{% tabs %}
{% highlight razor tabtitle="Label Position"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Model="@RegistrationDetailsModel"
            LabelPosition="FormLabelPosition.Left">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    public class RegistrationDetails
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to agree to the Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to the Terms and Conditions")]
        [Display(Name="Agree to the terms")]
        public bool Accept { get; set; }
    }

    private RegistrationDetails RegistrationDetailsModel = new RegistrationDetails();
}

{% endhighlight %}
{% endtabs %}

## Change the Form width 

The DataForm component allows you to customize the width of the form container by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_Width) property.

{% tabs %}
{% highlight razor tabtitle="Width"  %}


@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            Model="@RegistrationDetailsModel">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    public class RegistrationDetails
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to agree to the Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to the Terms and Conditions")]
        [Display(Name = "Agree to the terms")]
        public bool Accept { get; set; }
    }

    private RegistrationDetails RegistrationDetailsModel = new RegistrationDetails();
}

{% endhighlight %}
{% endtabs %}