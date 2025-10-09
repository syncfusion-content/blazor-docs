---
layout: post
title: User Interaction with Blazor Signature Component | Syncfusion
description: Learn about user interactions in the Syncfusion Blazor Signature component, including undo, redo, clear, disabled, and read-only states, and how to use CanUndoAsync/CanRedoAsync/IsEmptyAsync with the Changed event.
platform: Blazor
control: Signature
documentation: ug
---

# User Interactions in Blazor Signature component

The [Blazor Signature](https://www.syncfusion.com/blazor-components/blazor-signature) component supports the following interactions and states:
- Undo/Redo: Revert the last action or the last undo.
- Clear: Remove all strokes and reset the canvas.
- Disabled: Prevent any interaction with the component.
- Read-only: Prevent editing while keeping the existing signature visible.

Internally, the component snapshots changes to support undo/redo. The helper methods [`CanUndoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_CanUndoAsync), [`CanRedoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_CanRedoAsync), and [`IsEmptyAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_IsEmptyAsync) are used to determine availability of each action.

## Undo

Revert the most recent stroke or action using [`UndoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_UndoAsync). Use `CanUndoAsync` to check whether undo is available before invoking it.

## Redo

Reapply the last undone action using [`RedoAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_RedoAsync). Use `CanRedoAsync` to check whether redo is available.

## Clear

Clear the canvas using [`ClearAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_ClearAsync). Use `IsEmptyAsync` to determine if there is anything to clear.

## Disabled

Disable user interaction by setting the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Disabled) property to true.

## Read-only

Prevent editing while keeping the content visible by setting [`IsReadOnly`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_IsReadOnly) to true.

The following sample demonstrates these interactions controlled by buttons and checkboxes. The [`Changed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_Changed) event is used to update the UI state after each stroke. Note: In the sample code, the button enable/disable logic should reflect the availability checks (for example, set undoBtn.Disabled to !canUndo). Also, consider awaiting async calls where appropriate.

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

![Blazor Signature interaction demo with undo, redo, clear, disable, and read-only controls](./images/blazor-signature-user.png)