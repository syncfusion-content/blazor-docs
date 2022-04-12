---
layout: post
title: Disable the edit mode in Blazor In-place Editor Component | Syncfusion
description: Learn here all about Disable the edit mode specifically in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In Place Editor 
documentation: ug
---

# Disable the Edit Mode Specifically in Blazor In-place Editor Component

The edit mode of the In-place Editor can be disabled by setting the `Disabled` property value to `true`. In the following example, when you check or uncheck the checkbox, the In-place Editor component will disable or enable the edit mode respectively.

```cshtml

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs

<table class="table-section">
    <tr>
        <td> Disabled: </td>
        <td>
            <SfCheckBox @bind-Checked="Checked" Label="Disable" ></SfCheckBox>
        </td>
    </tr>
    <tr>
        <td class="sample-td"> Enter your name: </td>
        <td class="sample-td">
            <SfInPlaceEditor @bind-Value="@TextValue" TValue="string" Disabled="Checked">
                <EditorComponent>
                    <SfTextBox @bind-Value="@TextValue" Placeholder="Enter some text"></SfTextBox>
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
    public string TextValue { get; set; } = "Andrew";
    public bool Checked { get; set; } = true;

}
```