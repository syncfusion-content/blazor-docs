---
layout: post
title: User Interaction with Blazor Signature Component | Syncfusion
description: Checkout and learn about getting started with Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# User Interactions in Blazor Signature component

The Signature control supports various interaction like Undo, Redo, Clear, Disabled, and ReadOnly.

## Undo

It reverts the last action of signature using the [`UndoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_UndoAsync) method.

## Redo

It reverts the last undo action of the signature using the [`RedoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_RedoAsync) method.

## Clear

It clears the signature and makes the canvas empty using the [`ClearAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_ClearAsync) method.

## Disabled

It disables the signature control using the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Disabled) property.

## ReadOnly

It prevents the signature from editing using the [`IsReadOnly`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_IsReadOnly) property.

## User Integration sample

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-primary" @onclick="onUndo">UNDO</SfButton>
<SfButton CssClass="e-primary" @onclick="onRedo">REDO</SfButton>
<SfButton CssClass="e-primary" @onclick="onClear">CLEAR</SfButton>

<SfCheckBox Label="Disable" @onchange="onDisable"></SfCheckBox>
<SfCheckBox Label="Readonly" @onchange="onReadOnly"></SfCheckBox>

<SfSignature @ref="signature" ></SfSignature>

@code{
    private SfSignature signature;
    private void onUndo() {
        signature.UndoAsync();
    }
    private void onRedo() {
        signature.RedoAsync();
    }
    private void onClear() {
        signature.ClearAsync();
    }
    private void onDisable(Microsoft.AspNetCore.Components.ChangeEventArgs args) {
        signature.Disabled = args.Checked;
    }
    private void onReadOnly(Microsoft.AspNetCore.Components.ChangeEventArgs args) {
        signature.IsReadOnly = args.Checked;
    }
}
```

![Blazor Signature Component](./images/blazor-signature-user.png)