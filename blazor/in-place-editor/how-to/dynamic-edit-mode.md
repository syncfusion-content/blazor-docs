---
layout: post
title: Dynamically move In-place Editor to edit mode in Blazor | Syncfusion
description: Learn here all about dynamically moving input to edit mode in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In-place Editor
documentation: ug
---

# Dynamically Move In-place Editor to Edit Mode in Blazor

At component initialization, the In-place Editor can enter edit mode without user interaction by setting the EnableEditMode property to true. By default, EnableEditMode is false. When true, the editor opens programmatically at initial render and can also be toggled at runtime. This differs from the standard user-triggered behavior (click or focus) by immediately presenting the editor for input on page load.

In the following example, editor opened at initial load and when toggling a checkbox, it will remove or open the editor.

```cshtml

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs

<table class="table-section">
    <tr>
        <td> EnableEditMode: </td>
        <td>
            <SfCheckBox @bind-Checked="@EditModeEnable" Label="Disable" ValueChange="OnChange" TChecked="bool"></SfCheckBox>
        </td>
    </tr>
    <tr>
        <td class="sample-td"> Enter your name: </td>
        <td class="sample-td">
            <SfInPlaceEditor @bind-Value="@TextValue" EnableEditMode="EditModeEnable" TValue="string" ActionOnBlur="ActionBlur.Ignore">
                <EditorComponent>
                    <SfTextBox @bind-Value="@TextValue"  Placeholder="Enter some text"></SfTextBox>
                </EditorComponent>
            </SfInPlaceEditor>
        </td>
    </tr>
</table>

<style>
    .table-section {
        margin: 0 auto;
    }

    tr td:first-child {
        text-align: right;
        padding-right: 20px;
    }

    .sample-td {
        padding-top: 10px;
        min-width: 230px;
        height: 100px;
    }
</style>

@code {
    public bool EditModeEnable { get; set; } = true;
    public string TextValue { get; set; } = "Andrew";

    private void OnChange(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        this.EditModeEnable = args.Checked;
        this.StateHasChanged();
    }
}

```