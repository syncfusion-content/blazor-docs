---
layout: post
title: Open and Save with Blazor Signature Component | Syncfusion
description: Checkout and learn about loading and saving the signature with Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# Open and Save Signature

The [Blazor Signature](https://www.syncfusion.com/blazor-components/blazor-signature) component supports to open the signature by using hosted/online URL or base64. And it also supports various save options like image, base64, and blob.

## Open Signature

The signature component opens a pre-drawn signature as either base64 or hosted/ online URL using the [`LoadAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_LoadAsync_System_String_System_Int32_System_Int32_) method. It supports the PNG, JPEG, and SVG image's base64.

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

![Blazor Signature Component](./images/blazor-signature-open-image.png)

## Save Signature

The Signature component saves the signature as base64, blob, and image like PNG, JPEG, and SVG.

### Save as Base64

The Signature component gets the signature as base64 using the [`GetSignatureAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_GetSignatureAsync_Syncfusion_Blazor_Inputs_SignatureFileType_) method. It also supports the PNG, JPEG, and SVG format as base64.

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

![Blazor Signature Component](./images/blazor-signature-save-base.png)

### Save as Blob

The signature component saves the signature as Blob using [`SaveAsBlobAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveAsBlobAsync) method.

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

![Blazor Signature Component](./images/blazor-signature-save-blob.png)

### Save as Image

The Signature component saves the signature as an image using [`SaveAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveAsync_Syncfusion_Blazor_Inputs_SignatureFileType_System_String_) method. And it accepts file name and file type as parameter. The default file type is PNG.

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

![Blazor Signature Component](./images/blazor-signature-save-image.png)

## Save with Background

The Signature component saves the signature with its background by using the [`SaveWithBackground`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_SaveWithBackground) property. Its default value is true.

In the following sample, the background color is set as ‘rgb(103, 58, 183)’ and save with background as true.

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