---
layout: post
title: Model Binding in Blazor RadioButton Component | Syncfusion
description: Learn here all about Radio Button For and Model Binding in Syncfusion Blazor RadioButton component and more.
platform: Blazor
control: Radio Button
documentation: ug
---

# Radio Button Model Binding in Blazor RadioButton Component

To get started quickly with model binding in the Blazor RadioButton component, watch the following video:

{% youtube
"youtube:https://www.youtube.com/watch?v=4vMuReo0Hz4"%}

This section demonstrates strongly typed view support with the RadioButton component. A strongly typed view binds to a model class, allowing access to its properties and rendering the component based on that data. In this example, the component is placed inside an EditForm and uses DataAnnotationsValidator for validation. The Name property groups the radio buttons so only one option can be selected, and @bind-Checked binds the model property to the selected Value.

In this sample, selecting Female triggers a validation error message below the radio button group because the Range attribute is configured to allow only the value "male". This demonstrates how validation rules on the model control the allowed selection and display validation feedback.

```cshtml

@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<EditForm Model="Annotate">
    <DataAnnotationsValidator></DataAnnotationsValidator>
    <div class="form-group">
        <SfRadioButton Label="Male" Name="Gender" Value="male" @bind-Checked="@Annotate.Gender"></SfRadioButton>
        <SfRadioButton Label="Female" Name="Gender" Value="female" @bind-Checked="@Annotate.Gender"></SfRadioButton>
        <ValidationMessage For="@(() => Annotate.Gender)" />
    </div>
</EditForm>

@code {

    public Annotation Annotate = new Annotation();

    public class Annotation
    {
        [Range(typeof(string), "male", "male", ErrorMessage = "Male gender is required.")]
        public string Gender { get; set; } = "male";
    }
}

```

![Data Binding in Blazor RadioButton](./../images/blazor-radiobutton-data-binding.png)