---
layout: post
title: How to Checkboxfor in Blazor Checkbox Component | Syncfusion
description: Checkout and learn about Checkboxfor in Blazor Checkbox component of Syncfusion, and more details.
platform: Blazor
control: Checkbox
documentation: ug
---

# CheckboxFor and Model Binding

This section demonstrates the Strongly typed extension support in Checkbox. The view that can bind with any model is called as strongly typed view. You can bind any class as model to view. You can access model properties on that view. You can use data associated with model to render the component.

In this sample, first check the option and click the submit button to post the selected value in the Checkbox. When value is not checked, validation error message will be shown below the Checkbox.

```csharp

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

Output be like

![Button Sample](./../images/cb-form.png)