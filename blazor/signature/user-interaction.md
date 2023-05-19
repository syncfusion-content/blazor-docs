---
layout: post
title: User Interaction with Blazor Signature Component | Syncfusion
description: Checkout and learn about the user interactions available in Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# User Interactions in Blazor Signature component

The [Blazor Signature](https://www.syncfusion.com/blazor-components/blazor-signature) component supports various interaction like Undo, Redo, Clear, Disabled, and ReadOnly. Every changes occurred in signature can be taken as a snap and saved to collection for handling the above user interactions. 

## Undo

It reverts the last action of signature using the [`UndoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_UndoAsync) method. It removes the latest snap from the collection and load a previous snap to signature. Here, [`CanUndoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_CanUndoAsync) method is used to ensure whether undo can be performed or not.

## Redo

It reverts the last undo action of the signature using the [`RedoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_RedoAsync) method. Here, [`CanRedoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_CanRedoAsync) method is used to ensure whether redo can be performed or not.

## Clear

It clears the signature and makes the canvas empty using the [`ClearAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_ClearAsync) method. Here, [`IsEmptyAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_IsEmptyAsync) method is used to ensure whether the signature is empty or not.

## Disabled

It disables the signature component using the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Disabled) property.

## ReadOnly

It prevents the signature from editing using the [`IsReadOnly`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_IsReadOnly) property.

The following sample explains about user interactions available in signature.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-primary" @ref="undoBtn" @onclick="OnUndo">UNDO</SfButton>
<SfButton CssClass="e-primary" @ref="redoBtn" @onclick="OnRedo">REDO</SfButton>
<SfButton CssClass="e-primary" @ref="clearBtn" @onclick="OnClear">CLEAR</SfButton>

<SfCheckBox Label="Disable" ValueChange="OnDisable" TChecked="bool"></SfCheckBox>
<SfCheckBox Label="Readonly" ValueChange="OnReadOnly" TChecked="bool"></SfCheckBox>

<SfSignature @ref="signature" Disabled="@disabled" IsReadOnly="@isReadOnly" Changed="SignChanged"></SfSignature>

@code{
    private SfSignature signature;
    private SfButton undoBtn;
    private SfButton redoBtn;
    private SfButton clearBtn;
    private bool disabled = false;
    private bool isReadOnly = false;
    private void OnUndo()
    {
        if (!signature.Disabled && !signature.IsReadOnly)
        {
            signature.UndoAsync();
        }
    }
    private void OnRedo()
    {
        if (!signature.Disabled && !signature.IsReadOnly)
        {
            signature.RedoAsync();
        }
    }
    private void OnClear()
    {
        if (!signature.Disabled && !signature.IsReadOnly)
        {
            signature.ClearAsync();
        }
    }
    private void OnDisable(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        disabled = args.Checked;
    }
    private void OnReadOnly(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        isReadOnly = args.Checked;
    }
    private async Task SignChanged()
    {
        bool canUndo = await signature.CanUndoAsync();
        bool canRedo = await signature.CanRedoAsync();
        bool isEmpty = await signature.IsEmptyAsync();
        if (canUndo)
        {
            undoBtn.Disabled = true;
        }
        else
        {
            undoBtn.Disabled = false;
        }
        if (canRedo)
        {
            redoBtn.Disabled = true;
        }
        else
        {
            redoBtn.Disabled = false;
        }
        if (isEmpty)
        {
            clearBtn.Disabled = true;
        }
        else
        {
            clearBtn.Disabled = false;
        }
    }
}
```

![Blazor Signature Component](./images/blazor-signature-user.png)