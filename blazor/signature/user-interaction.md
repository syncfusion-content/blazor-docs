---
layout: post
title: User Interaction with Blazor Signature Component | Syncfusion
description: Checkout and learn about the user interactions available in Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# User Interactions in Blazor Signature component

The below interactions were available in Signature, and we can walk through one by one.

* Undo and Redo
* Clear
* Disabled
* ReadOnly

## Undo and Redo

In the Signature, every action can be maintained as a snap for undo and redo operations. And maintained SnapIndex for indexing the snap collection.

The [`UndoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_UndoAsync) method reverts the last action of signature by decreasing SnapIndex value to  index previous snap. Here, [`CanUndoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_CanUndoAsync) method is used to ensure whether undo can be performed or not.

The [`RedoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_RedoAsync) method reverts the last undo action of the signature by increasing the SnapIndex to  get the next snap. Here, [`CanRedoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_CanRedoAsync) method is used to ensure whether redo can be performed or not.

## Clear

The [`ClearAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_ClearAsync) method is used to clears the signature and makes the canvas empty. This is also considered in Undo/ Redo. Here, [`IsEmptyAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_IsEmptyAsync) method is used to ensure whether the signature is empty or not.

## Disabled

The [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Disabled) property is used to enables/disables the signature component. In the disabled state, the user is not allowed to draw signature. And it can’t be focused until the user enabled the signature.

## ReadOnly

The [`IsReadOnly`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_IsReadOnly) property is used to enables/disables the ReadOnly Signature. It can be focused but it prevents drawing in Signature.

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