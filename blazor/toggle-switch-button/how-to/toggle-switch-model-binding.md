---
layout: post
title: Model binding in Blazor Toggle Switch Button Component | Syncfusion
description: Learn here all about model binding in Syncfusion Blazor Toggle Switch Button component and much more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Model Binding in Blazor Toggle Switch Button Component

This section demonstrates the strongly typed extension support in Toggle Switch Button. The view that can bind with any model is called as strongly typed view. You can bind any class as model to view. The model properties can be accessed on that view. The data associated with model can be used to render the component.

In this sample, select the option and click the Submit button to post the value bound to the model. If the value is not checked, a validation error message is displayed below the toggle switch, enforced by the `Range` attribute configured to require `true`. The text content inside the `SfSwitch` acts as its label. To handle form submission logic, use `OnValidSubmit` and `OnInvalidSubmit` on the `EditForm` as needed. The `SfButton` is configured as a submit button using `HtmlAttributes` with `type="submit"`.
```cshtml

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

![Model binding and validation in Blazor Toggle Switch Button](./../images/blazor-toggle-switch-button-model-binding.png)