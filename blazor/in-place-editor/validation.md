---
layout: post
title: Validation in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about Validation in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In Place Editor 
documentation: ug
---

# Validation in Blazor In-place Editor Component

Now, validation can be done by using the  EditForm validation on the server-side. We need to handle the validation from the application level and the custom validation can also be achieved by using this.

Please refer to the following link for more details,[EditForm Validation](https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0). Validation for the `TextBox` is achieved in the following sample using the EditForm validation with a custom error message and validation rules.

```cshtml

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Calendars
@using System.ComponentModel.DataAnnotations;

<table class="table-section">
    <tr>
        <td class="sample-td"> Enter your name: </td>
        <td class="sample-td">
            <SfInPlaceEditor @bind-Value="exampleModel.Name" Type="Syncfusion.Blazor.InPlaceEditor.InputType.Text"  TValue="string">
                    <EditorComponent>
                            <EditForm Model="@exampleModel">
                                <DataAnnotationsValidator />
                                <SfTextBox @bind-Value="exampleModel.Name"></SfTextBox>
                                <ValidationMessage For=@(() => exampleModel.Name) />
                            </EditForm>
                    </EditorComponent>
                </SfInPlaceEditor>
        </td>
    </tr>
</table>

<style>
    .table-section {
        margin: 0 auto;
    }

    tr td:first-child {
        text-align: right;
        padding-right: 20px;
    }

    .sample-td {
        padding-top: 10px;
        min-width: 230px;
        height: 100px;
    }
</style>


@code {
    private string primaryKey { get; set; } = "editor1";
    private ExampleModel exampleModel = new ExampleModel();

    public class ExampleModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = "sync";
    }
}
```

The output will be as follows.

![Validation in Blazor In-place Editor](./images/blazor-inplace-editor-validation.png)