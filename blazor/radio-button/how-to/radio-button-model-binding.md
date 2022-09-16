---
layout: post
title: Model Binding in Blazor RadioButton Component | Syncfusion
description: Learn here all about Radio Button For and Model Binding in Syncfusion Blazor RadioButton component and more.
platform: Blazor
control: Radio Button
documentation: ug
---

# Radio Button Model Binding in Blazor RadioButton Component

To get start quickly with Model Binding in Blazor RadioButton Component, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=4vMuReo0Hz4"%}

This section demonstrates the strongly typed extension support in Radio Button. The view that can bind with any model is called as strongly typed view. You can bind any class as model to view. You can access model properties on that view. You can use data associated with model to render the component.

In this sample, first check the male value and click the submit button to post the selected value in the Radio Button. When female value is checked, validation error message will be shown below the Radio Button.

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