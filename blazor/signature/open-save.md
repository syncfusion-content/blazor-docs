---
layout: post
title: Open and Save with Blazor Signature Component | Syncfusion
description: Checkout and learn about getting started with Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# Open and Save Signature

The Signature component supports to open the signature by using hosted/online URL or base64. And it also supports various save options like image, base64, and blob.

## Open Signature

The signature component opens a pre-drawn signature as either base64 or hosted/ online URL using the [`LoadAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_LoadAsync_System_String_System_Int32_System_Int32_) method. It supports the PNG, JPEG, and SVG image's base64.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the url or base64 of the signature'></SfTextBox>
<SfButton id="open" CssClass="e-primary" @onclick="OnOpen">OPEN</SfButton>

<div id="signature-control">
    <SfSignature @ref="signature" id="signature"></SfSignature>
</div>

@code{
    private SfSignature signature;
    private SfTextBox text;
    private void OnOpen()
    {
        var sign = text.Value;
        signature.LoadAsync(sign, 300, 300);
    }
}

<style>
    #signature-control {
        height: 300px;
        width: 300px;
    }

    #signature {
        border: 1px solid lightgray;
        height: 100%;
        width: 100%;
    }
</style>
```

![Blazor Signature Component](./images/blazor-signature-open-image.png)

## Save Signature

The Signature component saves the signature as base64, blob, and image like PNG, JPEG, and SVG.

### Save as Base64

The Signature component saves the signature as base64 using the [`GetSignatureAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_GetSignatureAsync_Syncfusion_Blazor_Inputs_SignatureFileType_) method. It also supports the PNG, JPEG, and SVG format as base64.

```cshtml

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<h4>Sign Here</h4>
<SfSignature @ref="signature"></SfSignature>

<SfButton @onclick="GetSign">GetSignature</SfButton>

@code {
    private SfSignature signature;
    private void GetSign()
    {
        signature.GetSignatureAsync();
    }
}
```

![Blazor Signature Component](./images/blazor-signature-save-base.png)

### Save as Blob

The signature component saves the signature as Blob using the [`SaveAsBlobAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveAsBlobAsync) method. It return the signature as blob.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<h4>Sign Here</h4>
<SfSignature @ref="signature"></SfSignature>

<SfButton @onclick="GetBlob">GetBlob</SfButton>

@code {
    private SfSignature signature;
    private void GetBlob()
    {
        signature.SaveAsBlobAsync();
    }
}
```

![Blazor Signature Component](./images/blazor-signature-save-blob.png)

### Save as Image

The Signature component saves the signature as an image using the [`SaveAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveAsync_Syncfusion_Blazor_Inputs_SignatureFileType_System_String_) method. And the file name and file type of the signature is set by using the `OnSave` event. It also supports to save the signature as an image in formats like PNG, JPEG and SVG.

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

![Blazor Signature Component](./images/blazor-signature-save-image.png)

## Save with Background

The Signature component saves the signature with its background by using the [`SaveWithBackground`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveWithBackground) property. Its default value is true.

In the following sample, the background color is set as ‘rgb(103 58 183)’ and save with background as true.

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

![Blazor Signature Component](./images/blazor-signature-save-bg.png)