---
layout: post
title: Custom Animation for popup in Blazor In-place Editor | Syncfusion
description: Learn here all about setting custom animation for popup mode in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In-place Editor
documentation: ug
---

# Custom Animation for Popup Mode in Blazor In-place Editor Component

In popup mode, the In-place Editor is rendered with the Blazor `Tooltip` component. You can use the tooltip properties and events to customize the popup by configuring properties using the `InPlaceEditorPopupSettings` tag.

In the following example, the popup’s open animation is configured by passing an AnimationModel to the InPlaceEditorPopupSettings tag, and the animation effect is updated at runtime from a Blazor DropDownList ValueChange event. Supported effects include None, FadeIn, FadeZoomIn, and ZoomIn as shown. Close animations can also be customized by setting the Close property on TooltipAnimationSettings. If a selected value does not match a valid Effect, parsing will fail; ensure the dropdown values match the Effect enum exactly. Consider accessibility preferences such as reduced motion when applying animations.

```cshtml

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Popups

<div id='container'>
    <table class="table-section">
        <tr>
            <td> Open Animation: </td>
            <td>
                <SfDropDownList PopupHeight="150px" @bind-Value="DropdownValue" Placeholder="Select a animate type" DataSource="OpenAnimateData">
                    <DropDownListEvents ValueChange="@OnChange" TValue="string" TItem="DropDownFields"></DropDownListEvents>
                    <DropDownListFieldSettings Value="Text" Text="Text"></DropDownListFieldSettings>
                </SfDropDownList>
            </td>
        </tr>
        <tr>
            <td class="sample-td"> Enter your name: </td>
            <td class="sample-td">
                <SfInPlaceEditor @bind-Value="@TextValue" Mode="RenderMode.Popup" TValue="string">
                    <EditorComponent>
                        <SfTextBox @bind-Value="@TextValue" Placeholder="Enter some text"></SfTextBox>
                    </EditorComponent>
                    <InPlaceEditorPopupSettings Animation="@Animation"></InPlaceEditorPopupSettings>
                </SfInPlaceEditor>
            </td>
        </tr>
    </table>
</div>

<style>
    #container {
        display: flex;
        justify-content: center;
    }

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
    public class DropDownFields
    {
        public string Text { get; set; }
    }
    public List<DropDownFields> OpenAnimateData = new List<DropDownFields>()
{
        new DropDownFields(){ Text= "None" },
        new DropDownFields(){ Text= "FadeIn" },
        new DropDownFields(){ Text= "FadeZoomIn" },
        new DropDownFields(){ Text= "ZoomIn" }
    };

    public string DropdownValue { get; set; } = "ZoomIn";
    public string TextValue { get; set; } = "Andrew";

    public AnimationModel Animation { get; set; } = new AnimationModel
    {
        Open = new TooltipAnimationSettings { Delay = 0, Duration = 150, Effect = Effect.ZoomIn }
    };

    public void OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, DropDownFields> args)
    {
        Animation = new AnimationModel
        {
            Open = new TooltipAnimationSettings { Delay = 0, Duration = 150, Effect = (Effect)System.Enum.Parse(typeof(Effect), args.Value) }
        };
    }

}

```