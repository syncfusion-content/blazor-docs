---
layout: post
title: Customization with Blazor Signature Component | Syncfusion
description: Checkout the customization available in Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# Customization of Signature component

The [Blazor Signature](https://www.syncfusion.com/blazor-components/blazor-signature) component draws stroke/path to connect one or more points while drawing in canvas. This path is drawn with moveTo() and lineTo() method. We can able to customize the stroke by modifying its color and width. And the background of the signature also customizable by using its color and image.

## Stroke Width

The stroke width depends on the [`MaxStrokeWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_MaxStrokeWidth), [`MinStrokeWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_MinStrokeWidth) and [`Velocity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Velocity) values. And the variable stroke width is calculated based on the values of MaxStrokeWidth and MinStrokeWidth for smoother signature and velocity value is used for realistic signature.

In the following example, minimum stroke width is set as 0.5, maximum stroke width is set as 3 and velocity is set as 0.7.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfSignature MaxStrokeWidth="3" MinStrokeWidth="0.5" Velocity="0.7"></SfSignature>
```

![Blazor Signature Component](./images/blazor-signature-stroke-width.png)

## Stroke Color

Specify [`StrokeColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_StrokeColor) property to set color of a stroke that accepts hex value, RGB, and text. The default value of this property is "#000000".

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

![Blazor Signature Component](./images/blazor-signature-stroke-color.png)

## Background Color

Specify [`BackgroundColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_BackgroundColor) property to set a background color of a signature that accepts hex code, RGB, and text.

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

![Blazor Signature Component](./images/blazor-signature-bg-color.png)

## Background Image

Specify [`BackgroundImage`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_BackgroundImage) property to set the background image of a signature. The background image can be set by either hosting the image in our local IIS or online image.

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

N> To view the hosted images, you need to enable Directory Browsing option in IIS which creates web.config file inside the hosted folder. Adding below code snippet in the web.config file resolves the CORS issue.

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

![Blazor Signature Component](./images/blazor-signature-bg-image.png)

## See Also

* [Save With Background](./open-save#save-with-background)