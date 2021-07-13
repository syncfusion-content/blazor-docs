# Radio ButtonFor and Model Binding

This section demonstrates the Strongly typed extension support in Radio Button. The view that can bind with any model is called as strongly typed view. You can bind any class as model to view. You can access model properties on that view. You can use data associated with model to render the component.

In this sample, first check the male value and click the submit button to post the selected value in the Radio Button. When female value is checked, validation error message will be shown below the Radio Button.

```csharp

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

Output be like

![Radio Button Sample](./../images/rb-form.png)