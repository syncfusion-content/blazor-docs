---
layout: post
title: Label and Size in Blazor RadioButton Component | Syncfusion
description: Checkout and learn here all about Label and Size in Syncfusion Blazor RadioButton component and more.
platform: Blazor
control: Radio Button
documentation: ug
---

# Label and Size in Blazor RadioButton Component

This section explains the different sizes and labels.

## Label

Radio Button caption can be defined by using the [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html#Syncfusion_Blazor_Buttons_SfRadioButton_1_Label) property. This reduces the manual addition of label for Radio Button. You can customize the label position before or after the Radio Button through the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html#Syncfusion_Blazor_Buttons_SfRadioButton_1_LabelPosition) property.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Left Side Label" Name="position" LabelPosition="LabelPosition.Before" Value="Left"  @bind-Checked="stringChecked"></SfRadioButton><br />
<SfRadioButton Label="Right Side Label" Name="position" LabelPosition="LabelPosition.After" Value="Right" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked ="Right";
}

```

![Blazor RadioButton with Label](./images/blazor-radiobutton-label.png)

## Size

The different Radio Button sizes available are default and small. To reduce the size of the default Radio Button to small, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfInputBase-1.html#Syncfusion_Blazor_Buttons_SfInputBase_1_CssClass) property to `e-small`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Small" Name="size" CssClass="e-small" Value="Small" @bind-Checked="stringChecked"></SfRadioButton><br />
<SfRadioButton Label="Default" Name="size" Value="Default" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked ="Default";
}

```

![Blazor RadioButton with Different Size](./images/blazor-radiobutton-different-size.png)

## See Also

* [How to customize the Radio Button appearance](./how-to/customize-radiobutton-appearance)