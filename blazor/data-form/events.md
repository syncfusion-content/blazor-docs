---
layout: post
title: Event handlers in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to bound event handlers and recieve necessary arguments in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Event handlers in DataForm component

This segment briefly explains about the event handlers in DataForm component.

## OnSubmit

The [OnSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnSubmit) event is activated whenever the form is submitted, regardless of whether the submission is valid or invalid.


{% tabs %}
{% highlight razor tabtitle="Model" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations

<SfDataForm Width="50%"
            Model="@RegistrationDetailsModel"
            OnSubmit="SubmitHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    public void SubmitHandler()
    {
        // Here, you can include your required logic.
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
{% highlight razor tabtitle="EditContext" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations

<SfDataForm Width="50%"
            EditContext="@RegistrationDetailsContext"
            OnSubmit="SubmitHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    EditContext RegistrationDetailsContext { get; set; }

    public void SubmitHandler(EditContext editContext)
    {
        bool isValid = editContext.Validate();

        if(isValid)
        {
            // Here you can handle logic when form submission is valid
        }
        else
        {
            // Here you can handle logic when form submission is invalid
        }
    }

    protected override void OnInitialized()
    {
        RegistrationDetailsContext = new EditContext(RegistrationDetailsModel);
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
}

{% endhighlight %}
{% endtabs %}

## OnValidSubmit

he [OnValidSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnValidSubmit) event is triggered when the form is submitted and all the form validation rules are satisfied.

`OnValidSubmit` is typically used to handle the form submission logic, such as saving the form data to a database, when the form data is valid.

{% tabs %}
{% highlight razor tabtitle="Model" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            Model="@RegistrationDetailsModel"
            OnValidSubmit="OnValidSubmitHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    public void OnValidSubmitHandler()
    {
        // Here, you can include your required logic.
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
{% highlight razor tabtitle="EditContext" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            EditContext="@RegistrationDetailsContext"
            OnValidSubmit="OnValidSubmitHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    EditContext RegistrationDetailsContext { get; set; }

    protected override void OnInitialized()
    {
        RegistrationDetailsContext = new EditContext(RegistrationDetailsModel);
        base.OnInitialized();
    }

    public void OnValidSubmitHandler(EditContext editContext)
    {
        // Here, you can include your required logic.
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

## OnInvalidSubmit

The [OnInvalidSubmit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnInvalidSubmit) event is triggered when the form is submitted but the form validation rules are not satisfied. It's typically used to handle scenarios when the form data is invalid.

{% tabs %}
{% highlight razor tabtitle="Model" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            Model="@RegistrationDetailsModel"
            OnInvalidSubmit="OnInvalidSubmitHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    public void OnInvalidSubmitHandler()
    {
        // Here, you can include your required logic.
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
{% highlight razor tabtitle="EditContext" %}
@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            EditContext="@RegistrationDetailsContext"
            OnInvalidSubmit="OnInvalidSubmitHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {


    EditContext RegistrationDetailsContext { get; set; }

    protected override void OnInitialized()
    {
        RegistrationDetailsContext = new EditContext(RegistrationDetailsModel);
        base.OnInitialized();
    }

    public void OnInvalidSubmitHandler(EditContext editContext)
    {
        // Here, you can include your required logic.
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

## OnUpdate

The [OnUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_OnUpdate) event will be invoked upon editing a field in the DataForm component. The changed field name and newly updated model are available through the [FormUpdateEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormUpdateEventArgs.html) event context. 

{% tabs %}
{% highlight razor tabtitle="Model" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            Model="@RegistrationDetailsModel"
            OnUpdate="OnUpdateHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    public void OnUpdateHandler(FormUpdateEventArgs arguments)
    {
        // Here, you can include your required logic.
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
{% highlight razor tabtitle="EditContext" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm Width="50%"
            EditContext="@RegistrationDetailsContext"
            OnUpdate="OnUpdateHandler">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormAutoGenerateItems></FormAutoGenerateItems>
    </FormItems>

</SfDataForm>

@code {

    EditContext RegistrationDetailsContext { get; set; }

    protected override void OnInitialized()
    {
        RegistrationDetailsContext = new EditContext(RegistrationDetailsModel);
        base.OnInitialized();
    }

    public void OnUpdateHandler(FormUpdateEventArgs arguments)
    {
        // Here, you can include your required logic.
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