---
layout: post
title: Model Binding in Blazor CheckBox Component | Syncfusion
description: Check out and learn here all about Model Binding in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: Checkbox
documentation: ug
---

# Model Binding in Blazor CheckBox Component

To get start quickly with Model Binding in Blazor CheckBox Component, you can check on this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=4vMuReo0Hz4"%}

This section demonstrates the strongly typed extension support in Checkbox. The view that can bind with any model is called as strongly typed view. You can bind any class as model to view, access model properties on that view, and use data associated with model to render the component.

In this sample, first check the option and click the submit button to post the selected value in the Checkbox. When the value is not checked, validation error message will be shown below the Checkbox.

```csharp

@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<EditForm Model="Annotate">
    <DataAnnotationsValidator></DataAnnotationsValidator>
    <div class="form-group">
        <SfCheckBox Label="Option 1" @bind-Checked="@Annotate.Check"></SfCheckBox>
        <ValidationMessage For="@(() => Annotate.Check)" />
    </div>
    <SfButton HtmlAttributes="@Submit" Content="Submit"></SfButton>
</EditForm>

@code {
    public Annotation Annotate = new Annotation();
    public class Annotation
    {
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to the Terms and Conditions")]
        public bool Check { get; set; }
    }
    public Dictionary<string, object> Submit = new Dictionary<string, object>()
    {
        { "type", "submit"}
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhKMVrmrJkahhmZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Model Binding in Blazor CheckBox](./../images/blazor-checkbox-model-binding.png)" %}