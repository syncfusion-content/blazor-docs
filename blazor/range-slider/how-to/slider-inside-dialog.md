---
layout: post
title: Range Slider inside Dialog popup in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Slider inside Dialog popup in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Render the Blazor Range Slider Inside a Dialog Popup

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
            <SfSlider @ref="sliderObj" Value=@RangeValue Type="SliderType.Range"></SfSlider>
        </Content>
    </DialogTemplates>
</SfDialog>

@code {
    SfSlider<int[]>? sliderObj;
    public bool IsVisible { get; set; } = false;
    public int[] RangeValue = { 30, 70 };
    public void Opened()
    {
       sliderObj?.RepositionAsync();
    }
    protected void ToggleDialog()
    {
        IsVisible = !IsVisible;
        StateHasChanged();
    }
}

```
