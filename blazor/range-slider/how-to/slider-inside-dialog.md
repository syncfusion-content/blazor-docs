---
layout: post
title: How to render range slider inside a dialog in Blazor | Syncfusion
description: Render Blazor Range Slider inside a dialog and call RepositionAsync when the dialog opens.
platform: Blazor
control: Range Slider
documentation: ug
---

# How to render range slider inside a dialog in Blazor

When the dialog is initially hidden, the Blazor Range Slider may be initialized before layout information is available. As a result, the slider cannot size and position itself correctly, and the initial value may not render accurately. To resolve this, capture the slider instance using `@ref` and call the slider’s [RepositionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_RepositionAsync) method in the dialog’s [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_Opened) event so the component recalculates its layout after the dialog is visible.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<SfButton Content="Open Dialog" OnClick="ToggleDialog"></SfButton>

<SfDialog Width="400px" IsModal="true" @bind-Visible="@IsVisible" ShowCloseIcon="true">
    <DialogEvents Opened="Opened"></DialogEvents>
    <DialogTemplates>
        <Header>Slider in Dialog Popup</Header>
        <Content>
            <SfSlider @ref="sliderObj" TValue="int[]" Min="0" Max="100" Value="@RangeValue" Type="SliderType.Range"></SfSlider>
        </Content>
    </DialogTemplates>
</SfDialog>

@code {
    SfSlider<int[]>? sliderObj;
    public bool IsVisible { get; set; } = false;
    public int[] RangeValue = { 30, 70 };
    public async Task Opened()
    {
       // Await the reposition so the dialog animation has completed and the slider
       // can read the final container size before recomputing its layout.
       if (sliderObj != null)
       {
           await sliderObj.RepositionAsync();
       }
    }
    protected void ToggleDialog()
    {
        IsVisible = !IsVisible;
    }
}

```
