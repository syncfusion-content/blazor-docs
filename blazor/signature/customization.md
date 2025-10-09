---
layout: post
title: Customization with Blazor Signature Component | Syncfusion
description: Learn how to customize the Syncfusion Blazor Signature component, including stroke width, stroke color, background color, and background image in Blazor Server and WebAssembly apps.
platform: Blazor
control: Signature
documentation: ug
---

# Customization in Blazor Signature Component

The [Blazor Signature](https://www.syncfusion.com/blazor-components/blazor-signature) component supports customizing the drawing experience and appearance. Configure stroke width (minimum/maximum and velocity-based variation), stroke color, background color, and background image to match application requirements. The component handles canvas rendering internally; no direct canvas API usage is required.

## Stroke Width

Stroke width is controlled by the [`MaxStrokeWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_MaxStrokeWidth), [`MinStrokeWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_MinStrokeWidth), and [`Velocity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Velocity) properties. Variable stroke width is calculated between the specified minimum and maximum values for smoother, more natural signatures, and Velocity fine-tunes the responsiveness.

In the following example, the minimum stroke width is 0.5, maximum stroke width is 3, and velocity is 0.7.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSignature MaxStrokeWidth="3" MinStrokeWidth="0.5" Velocity="0.7"></SfSignature>
```

![Blazor Signature showing variable stroke width settings](./images/blazor-signature-stroke-width.png)

## Stroke Color

Use the [`StrokeColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_StrokeColor) property to set the stroke color. This property accepts standard CSS color formats, such as hex codes, RGB values, and named colors. The default value is "#000000".

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <div class="e-sign-heading">
        <span>
            <SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the stroke color'></SfTextBox>
        </span>
        <span class="e-btn-options">
            <SfButton CssClass="e-primary" @onclick="OnSet">Set Stroke Color</SfButton>
        </span>
    </div>
    <div class='e-sign-content'>
        <SfSignature StrokeColor="@strokeColor" style="width: 400px; height: 300px;"></SfSignature>
    </div>
</div>

@code{
    private SfTextBox text;
    private string strokeColor;
    private void OnSet()
    {
        strokeColor = text.Value;
    }
}

<style>
    .e-sign-content,
    .e-sign-heading {
        width: 400px;
    }

    #signdescription {
        font-size: 14px;
        padding-bottom: 10px;
    }

    .e-btn-options {
        float: right;
        margin: 10px 0px 10px;
    }
</style>
```

![Blazor Signature with custom stroke color applied](./images/blazor-signature-stroke-color.png)

## Background Color

Use the [`BackgroundColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_BackgroundColor) property to set a background color. This property accepts hex codes, RGB values, and named colors.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <div class="e-sign-heading">
        <span>
            <SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the background color'></SfTextBox>
        </span>
        <span class="e-btn-options">
            <SfButton CssClass="e-primary" @onclick="OnSet">Set Background Color</SfButton>
        </span>
    </div>
    <div class='e-sign-content'>
        <SfSignature BackgroundColor="@backgroundColor" style="width: 400px; height: 300px;"></SfSignature>
    </div>
</div>

@code{
    private SfTextBox text;
    private string backgroundColor;
    private void OnSet()
    {
        backgroundColor = text.Value;
    }
}

<style>
    .e-sign-content,
    .e-sign-heading {
        width: 400px;
    }

    #signdescription {
        font-size: 14px;
        padding-bottom: 10px;
    }

    .e-btn-options {
        float: right;
        margin: 10px 0px 10px;
    }
</style>
```

![Blazor Signature with custom background color applied](./images/blazor-signature-bg-color.png)

## Background Image

Use the [`BackgroundImage`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_BackgroundImage) property to set a background image for the signature area. The image can be hosted locally or served from a remote URL.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
<div>
    <div class="e-sign-heading">
        <span>
            <SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the Image URL'></SfTextBox>
        </span>
        <span class="e-btn-options">
            <SfButton CssClass="e-primary" @onclick="OnSet">Set Background Image</SfButton>
        </span>
    </div>
    <div class='e-sign-content'>
        <SfSignature BackgroundImage="@backgroundImage" style="width: 400px; height: 300px;"></SfSignature>
    </div>
</div>

@code{
    private SfTextBox text;
    private string backgroundImage;
    private void OnSet()
    {
        backgroundImage = text.Value;
    }
}

<style>
    .e-sign-content,
    .e-sign-heading {
        width: 400px;
    }

    #signdescription {
        font-size: 14px;
        padding-bottom: 10px;
    }

    .e-btn-options {
        float: right;
        margin: 10px 0px 10px;
    }
</style>
```

N> When loading images from another origin, ensure that the hosting server sends appropriate CORS headers to allow the request from your application’s origin. The following web.config example shows how to enable directory browsing and add a permissive CORS header on IIS for testing. Use restrictive origins in production environments.

```cshtml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
    <system.webServer>
        <directoryBrowse enabled="true" />
		<httpProtocol>
		  <customHeaders>
			<clear />
			<add name="Access-Control-Allow-Origin" value="*" />         
		  </customHeaders>
		</httpProtocol>
    </system.webServer>
</configuration>
```

![Blazor Signature with a custom background image](./images/blazor-signature-bg-image.png)

## See also

* [Save with background](./open-save#save-with-background)