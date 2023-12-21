---
layout: post
title: Methods in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about in-built functions along with their correct application within the Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Inbuilt methods in DataForm component

The classification of methods that can be invoked by using the DataForm instance are outlined below 

## IsValid()

 The [IsValid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_IsValid)


{% tabs %}
{% highlight razor tabtitle="IsValid" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Buttons


<SfDataForm Width="50%"
            @ref="DataFormInstance"
            EditContext="@RegistrationDetailsContext">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

<SfButton OnClick="ClickHandler">Click for manual submission</SfButton>

@code {

    SfDataForm DataFormInstance { get; set; }

    EditContext RegistrationDetailsContext { get; set; }

    protected override void OnInitialized()
    {
        RegistrationDetailsContext = new EditContext(RegistrationDetailsModel);
        base.OnInitialized();
    }

    public void ClickHandler()
    {
        // the below method can be invoked wherever neccessary to submit the form manually.
        DataFormInstance?.IsValid();
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
}

{% endhighlight %}
{% endtabs %}

## Refresh()

 The [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_Refresh) method updates the form to reflect any changes in the data model or configuration.It also resets the validation state, clearing any existing validation error messages. 

 {% tabs %}
{% highlight razor tabtitle="Refresh" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Buttons


<SfDataForm Width="50%"
            @ref="DataFormInstance"
            EditContext="@RegistrationDetailsContext">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

    <FormButtons>
        <SfButton typeof="submit">
            Submit
        </SfButton>
        <SfButton type="button" OnClick="ClickHandler">
            Refresh
        </SfButton>

    </FormButtons>

</SfDataForm>


@code {

    SfDataForm DataFormInstance { get; set; }

    EditContext RegistrationDetailsContext { get; set; }

    protected override void OnInitialized()
    {
        RegistrationDetailsContext = new EditContext(RegistrationDetailsModel);
        base.OnInitialized();
    }

    public void ClickHandler()
    {
        // the below method can be invoked wherever necessary to refresh the form.
        DataFormInstance?.Refresh();
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
}

{% endhighlight %}
{% endtabs %}