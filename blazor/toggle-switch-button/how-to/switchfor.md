---
layout: post
title: How to Switchfor in Blazor Toggle Switch Button  Component | Syncfusion
description: Checkout and learn about Switchfor in Blazor Toggle Switch Button  component of Syncfusion, and more details.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Data Annotations for Toggle Switch Button

This section demonstrates the Strongly typed extension support in Toggle Switch Button. The view that can bind with any model is called as strongly typed view. You can bind any class as model to view. You can access model properties on that view. You can use data associated with model to render the component.

In this sample, first check the option and click the submit button to post the selected value in the Toggle Switch Button. When value is not checked, validation error message will be shown below the Toggle Switch Button.

```csharp

@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<EditForm Model="Annotate">
    <DataAnnotationsValidator></DataAnnotationsValidator>
    <div class="form-group">
        <SfSwitch @bind-Checked="@Annotate.Check">I agree to receive newsletter</SfSwitch>
        <ValidationMessage For="@(() => Annotate.Check)" />
    </div>
    <SfButton HtmlAttributes="@Submit" Content="Submit" IsPrimary="true"></SfButton>
</EditForm>

@code {

    public Annotation Annotate = new Annotation();

    public class Annotation
    {
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to receive newsletter")]
        public bool Check { get; set; }
    }
    public Dictionary<string, object> Submit = new Dictionary<string, object>()
    {
        { "type", "submit"}
    };
}

```

Output be like

![Switch Sample](./../images/switch-form.png)