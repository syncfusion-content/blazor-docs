# Right-To-Left

Radio Button component has RTL support. This can be achieved by setting [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html) as `true`.

The following example illustrates how to enable right-to-left support in Radio Button component.

```csharp
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Default" EnableRtl="true" Value="Default" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked = "Default";
}

```

Output be like

![Radio Button Sample](./../images/rb-rtl.png)