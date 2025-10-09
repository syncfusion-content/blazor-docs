---
layout: post
title: Open and Save with Blazor Signature Component | Syncfusion
description: Learn how to load and save signatures in the Syncfusion Blazor Signature component, including opening from URL/base64 and saving as image, base64, or blob in Blazor Server and WebAssembly apps.
platform: Blazor
control: Signature
documentation: ug
---

# Open and Save Signature

The [Blazor Signature](https://www.syncfusion.com/blazor-components/blazor-signature) component supports loading a pre-drawn signature from a hosted/online URL or a base64 string, and saving signatures in multiple formats such as image files, base64, and blob.

## Open Signature

Load a pre-drawn signature from a base64 string or a hosted/online URL using the [`LoadAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_LoadAsync_System_String_System_Int32_System_Int32_) method. PNG, JPEG, and SVG base64 formats are supported. When loading from a different origin, ensure the hosting server allows cross-origin requests (CORS).

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <div class="e-sign-heading">
        <div class="e-header-item">
            <SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the url or base64 of the signature'></SfTextBox>
        </div>
        <div class="e-btn-options">
            <SfButton id="open" CssClass="e-primary" @onclick="OnOpen">Open</SfButton>
        </div>
    </div>
    <div class="e-sign-content">
        <SfSignature @ref="signature" style="width: 400px; height: 300px;"></SfSignature>
    </div>
</div>

@code{
    private SfSignature signature;
    private SfTextBox text;
    private async void OnOpen()
    {
        var sign = text.Value;
        await signature.LoadAsync(sign, 300, 300);
    }
}

<style>
    .e-sign-content,
    .e-sign-heading {
        width: 400px;
    }

    .e-btn-options {
        float: right;
        margin: 0px 0px 10px;
    }

    .e-header-item {
        padding-bottom: 10px;
    }
</style>
```

![Load a signature from a URL or base64 into the Blazor Signature component](./images/blazor-signature-open-image.png)

## Save Signature

Save the drawn signature as base64, blob, or an image (PNG, JPEG, SVG) according to application needs.

### Save as Base64

Retrieve the signature as a base64 string using the [`GetSignatureAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_GetSignatureAsync_Syncfusion_Blazor_Inputs_SignatureFileType_) method. PNG, JPEG, and SVG formats are supported. The base64 value can be stored, uploaded, or displayed as needed.

```cshtml

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<h4>Sign Here</h4>
<SfSignature @ref="signature"></SfSignature>

<SfButton @onclick="GetSign">GetSignature</SfButton>

@code {
    private SfSignature signature;
    private async void GetSign()
    {
        await signature.GetSignatureAsync();
    }
}
```

![Get the signature as a base64 string](./images/blazor-signature-save-base.png)

### Save as Blob

Save the signature as a Blob using the [`SaveAsBlobAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveAsBlobAsync) method for scenarios that require binary data handling.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<h4>Sign Here</h4>
<SfSignature @ref="signature"></SfSignature>

<SfButton @onclick="GetBlob">GetBlob</SfButton>

@code {
    private SfSignature signature;
    private async void GetBlob()
    {
        await signature.SaveAsBlobAsync();
    }
}
```

![Save the signature as a Blob](./images/blazor-signature-save-blob.png)

### Save as Image

Save the signature as an image using the [`SaveAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveAsync_Syncfusion_Blazor_Inputs_SignatureFileType_System_String_) method. Provide the file type and file name as parameters; the default file type is PNG. The example below uses a SplitButton to choose the output format.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SplitButtons

<div>
    <span>Sign here</span>
    <span>
        <SfSplitButton Content="SAVE">
            <SplitButtonEvents ItemSelected="OnSaveType" Clicked="OnSave">
            </SplitButtonEvents>
            <DropDownMenuItems>
                <DropDownMenuItem Text="Png"></DropDownMenuItem>
                <DropDownMenuItem Text="Jpeg"></DropDownMenuItem>
                <DropDownMenuItem Text="Svg"></DropDownMenuItem>
            </DropDownMenuItems>
        </SfSplitButton>
    </span>
</div>
<SfSignature @ref="signature"></SfSignature>

@code {
    private SfSignature signature;
    private SignatureFileType type = SignatureFileType.Png;
    private async void OnSaveType(MenuEventArgs args)
    {
        switch (args.Item.Text)
        {
            case "PNG":
                type = SignatureFileType.Png;
                break;
            case "JPEG":
                type = SignatureFileType.Jpeg;
                break;
            case "SVG":
                type = SignatureFileType.Svg;
                break;
        }
        await signature.SaveAsync(type, "Signature");
    }
    private async void OnSave(Syncfusion.Blazor.SplitButtons.ClickEventArgs args)
    {
        await signature.SaveAsync();
    }
}
```

![Save the signature as an image file (PNG, JPEG, or SVG)](./images/blazor-signature-save-image.png)

## Save with Background

Control whether the signature background is included in the saved output using the [`SaveWithBackground`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveWithBackground) property (default: true). Set this property based on whether a solid background should be preserved (for example, keep background for JPEG) or excluded (for transparency in PNG/SVG when set to false).

In the following sample, the background color is set to rgb(103, 58, 183) and the signature is saved with the background.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SplitButtons

<div>
    <span>Sign here</span>
    <span>
        <SfSplitButton Content="SAVE">
            <SplitButtonEvents ItemSelected="OnSaveType" Clicked="OnSave">
            </SplitButtonEvents>
            <DropDownMenuItems>
                <DropDownMenuItem Text="Png"></DropDownMenuItem>
                <DropDownMenuItem Text="Jpeg"></DropDownMenuItem>
                <DropDownMenuItem Text="Svg"></DropDownMenuItem>
            </DropDownMenuItems>
        </SfSplitButton>
    </span>
</div>
<SfSignature @ref="signature" BackgroundColor="rgb(103 58 183)"></SfSignature>

@code {
    private SfSignature signature;
    private SignatureFileType type = SignatureFileType.Png;
    private void OnSaveType(MenuEventArgs args)
    {
        switch (args.Item.Text)
        {
            case "PNG":
                type = SignatureFileType.Png;
                break;
            case "JPEG":
                type = SignatureFileType.Jpeg;
                break;
            case "SVG":
                type = SignatureFileType.Svg;
                break;
        }
        signature.SaveAsync(type, "Signature");
    }
    private void OnSave(Syncfusion.Blazor.SplitButtons.ClickEventArgs args)
    {
        signature.SaveAsync();
    }
}
```

![Save the signature with a background color](./images/blazor-signature-save-bg.png)