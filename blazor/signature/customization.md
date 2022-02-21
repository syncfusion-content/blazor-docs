---
layout: post
title: Customization with Blazor Signature Component | Syncfusion
description: Checkout and learn about getting started with Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# Customization of Signature component

The Signature control supports various customizations like background color, background image, stroke color, stroke width, save with background.

## Stroke Width

The signature stroke width depends on the [`MaxStrokeWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_MaxStrokeWidth), [`MinStrokeWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_MinStrokeWidth) and [`Velocity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Velocity) values. And the variable stroke width is calculated based on the values of maxStrokeWidth and minStrokeWidth for smoother signature and velocity value is used for realistic signature.

In the following example, minimum stroke width is set as 0.5, maximum stroke width is set as 3 and velocity is set as 0.7.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSignature MaxStrokeWidth="3" MinStrokeWidth="0.5" Velocity="0.7"></SfSignature>
```

![Blazor Signature Component](./images/blazor-signature-stroke-width.png)

## Stroke Color

The stroke color is applied using the [`StrokeColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_StrokeColor) property. It accepts hex code, RGB and text.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSignature StrokeColor="red"></SfSignature>
```

![Blazor Signature Component](./images/blazor-signature-stroke-color.png)

## Background Color

The Background color is applied using the [`BackgroundColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_BackgroundColor) property. It accepts hex code, RGB and text.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSignature BackgroundColor="yellow"></SfSignature>
```

![Blazor Signature Component](./images/blazor-signature-bg-color.png)

## Background Image

The Background image is applied using the [`BackgroundImage`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_BackgroundImage) property. It accepts online/hosted URL.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the URL of the background Image'></SfTextBox>
<SfButton id="open" CssClass="e-primary" @onclick="onSet">Set Background</SfButton>

<SfSignature @ref="signature"></SfSignature>

@code{
    private SfSignature signature;
    private SfTextBox text;
    private void onSet()
    {
        signature.BackgroundImage = text.Value;
    }
}
```

![Blazor Signature Component](./images/blazor-signature-bg-image.png)

## See Also

* [Save With Background](./open-save#save-with-background)