---
layout: post
title: Buttons in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about Buttons in Syncfusion Blazor In-place Editor component and much more.
platform: Blazor
control: In-place Editor
documentation: ug
---

# Buttons in Blazor In-place Editor Component

The In-place Editor has an option to save and cancel using buttons. The `InPlaceEditorSaveButton` and `InPlaceEditorCancelButton` tags accept the button properties for customizing the save and cancel button.

Buttons can be shown or hidden by setting a Boolean value to the `ShowButtons` property.

N> Without buttons, the value will be processed in the following ways.

* **ActionOnBlur**: By clicking outside, the editor component gets focus out and do an action based on this property value.
* **SubmitOnEnter**: Pressing the `Enter` key performs the submit action if this property is set to `true`.

In the following sample, the `Content` and `CssClass` properties of the `Button` value are assigned to the `InPlaceEditorSaveButton` and `InPlaceEditorCancelButton` properties to customize its appearance. Also, check or uncheck the checkbox buttons rendered or removed from the editor.

N> For more details about buttons, refer this documentation [section](../button/getting-started-with-web-app).

```cshtml

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<table class="table-section">
    <tr>
        <td> Submit on Enter: </td>
        <td>
            <SfCheckBox @bind-Checked="SubmitOnEnter" Label="Show" ValueChange="OnChange" TChecked="bool"></SfCheckBox>
        </td>
    </tr>
    <tr>
        <td class="sample-td">Enter your name: </td>
        <td class="sample-td">
            <SfInPlaceEditor @bind-Value="@TextValue" SubmitOnEnter="SubmitOnEnter" TValue="string">
                <EditorComponent>
                    <SfTextBox @bind-Value="@TextValue" Placeholder="Enter some text"></SfTextBox>
                </EditorComponent>
                <InPlaceEditorSaveButton Content="OK" CssClass="e-outline"></InPlaceEditorSaveButton>
                <InPlaceEditorCancelButton Content="Cancel" CssClass="e-outline"></InPlaceEditorCancelButton>
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
    public bool SubmitOnEnter { get; set; } = true;

    public string TextValue = "Andrew";

    private void OnChange(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool>
    args)
    {
        this.SubmitOnEnter = args.Checked;
        this.StateHasChanged();
    }
}

```



![Blazor In-place Editor with Buttons](./images/blazor-inplace-editor-with-buttons.png)

## See Also

* [In-place editor buttons](./how-to/dynamic-edit-mode)