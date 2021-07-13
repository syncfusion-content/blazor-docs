# Set the rounded corner

Render the TextBox with `rounded corner` by adding the `e-corner` class to the input parent element.

```csharp
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' CssClass="e-corner"></SfTextBox>
<style>
    .e-input-group.e-corner {
        border-radius: 4px;
    }
</style>
```