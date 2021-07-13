# Label and Size

This section explains the different sizes and labels.

## Label

Radio Button caption can be defined by using the [`Label`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html#Syncfusion_Blazor_Buttons_SfRadioButton_1_Label) property.
This reduces the manual addition of label for Radio Button. You can customize the label position before or after the
Radio Button through the [`LabelPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html#Syncfusion_Blazor_Buttons_SfRadioButton_1_LabelPosition) property.

```csharp
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Left Side Label" Name="position" LabelPosition="RadioLabelPosition.Before" Value="Left"  @bind-Checked="stringChecked"></SfRadioButton><br />
<SfRadioButton Label="Right Side Label" Name="position" LabelPosition="RadioLabelPosition.After" Value="Right" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked ="Right";
}

```

Output be like

![Radio Button Sample](./images/rb-label.png)

## Size

The different Radio Button sizes available are default and small. To reduce the size of the default Radio Button to small,
set the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html) property to `e-small`.

```csharp
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Small" Name="size" CssClass="e-small" Value="Small" @bind-Checked="stringChecked"></SfRadioButton><br />
<SfRadioButton Label="Default" Name="size" Value="Default" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked ="Default";
}

```

Output be like

![Radio Button Sample](./images/rb-size.png)

## See Also

* [How to customize the Radio Button appearance](./how-to/customize-radiobutton-appearance)