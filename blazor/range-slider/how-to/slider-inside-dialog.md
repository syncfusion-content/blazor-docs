---
layout: post
title: Range Slider inside Dialog popup in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about Slider inside Dialog popup in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Render Blazor Range Slider Inside Dialog Popup

The Blazor Slider component will be created before the Dialog popup is opened, and the Slider component will not be adapted to the parent element during dynamic rendering. As a result, the Slider does not render with the accurate initial value. To address this case, you must invoke the Slider's [RepositionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSlider-1.html#Syncfusion_Blazor_Inputs_SfSlider_1_RepositionAsync) method when the Dialog component is opened, utilizing the [Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_Opened) event.

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
