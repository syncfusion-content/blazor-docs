---
layout: post
title: Spinner and Progress in Blazor ProgressButton Component | Syncfusion
description: Checkout and learn here all about spinner and progress in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

<!-- markdownlint-disable MD002 MD022 -->
# Spinner and Progress in Blazor ProgressButton Component

This section explains the Spinner and Progress of Progress Button.

## Spinner

### Change spinner position

Spinner position can be changed by modifying the `Position` property of [SpinSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_SpinSettings). By default, the spinner is positioned at the left of the Progress Button. You can position it at the [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SpinPosition.html#Syncfusion_Blazor_SplitButtons_SpinPosition_Left), [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SpinPosition.html#Syncfusion_Blazor_SplitButtons_SpinPosition_Right), [top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SpinPosition.html#Syncfusion_Blazor_SplitButtons_SpinPosition_Top), [bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SpinPosition.html#Syncfusion_Blazor_SplitButtons_SpinPosition_Bottom), or [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SpinPosition.html#Syncfusion_Blazor_SplitButtons_SpinPosition_Center) of the text content.

### Change spinner size

Spinner size can be changed by modifying the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonSpinSettings.html#Syncfusion_Blazor_SplitButtons_ProgressButtonSpinSettings_Width) property of [SpinSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_SpinSettings). In this demo, the width is set to `20` to change the spinner size.

### Spinner template

You can use custom spinner by specifying the [SpinTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonSpinSettings.html#Syncfusion_Blazor_SplitButtons_ProgressButtonSpinSettings_SpinTemplate) property of [SpinSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonSpinSettings.html#properties) with custom styles.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton Content="Submit">
    <ProgressButtonSpinSettings Position="SpinPosition.Right" Width="20">
        <SpinTemplate>
            <div class="template"></div>
        </SpinTemplate>
    </ProgressButtonSpinSettings>
</SfProgressButton>

<style>
    @@keyframes custom-rolling {
        0% {
            -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
        }

        100% {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }
    }

    .template {
        border: 2px solid green;
        border-style: dotted;
        border-radius: 50%;
        border-top-color: transparent;
        border-bottom-color: transparent;
        height: 16px;
        width: 16px;
    }

    .template {
        -webkit-animation: custom-rolling 1.3s linear infinite;
        animation: custom-rolling 1.3s linear infinite;
    }
</style>

```

![Blazor ProgressButton with Spinner](./images/blazor-progressbutton-spinner.png)

## Progress

### Content animation

The [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_Content) of the Progress Button can be animated during progress using the [Effect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonAnimationSettings.html#Syncfusion_Blazor_SplitButtons_ProgressButtonAnimationSettings_Effect) property of [AnimationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_AnimationSettings). You can also set custom duration and timing function using the [Duration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonAnimationSettings.html#Syncfusion_Blazor_SplitButtons_ProgressButtonAnimationSettings_Duration) and [Easing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonAnimationSettings.html#Syncfusion_Blazor_SplitButtons_ProgressButtonAnimationSettings_Easing) properties. The possible `Effect` values are `None`, [SlideLeft](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.AnimationEffect.html#Syncfusion_Blazor_SplitButtons_AnimationEffect_SlideLeft), [SlideRight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.AnimationEffect.html#Syncfusion_Blazor_SplitButtons_AnimationEffect_SlideRight), [SlideUp](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.AnimationEffect.html#Syncfusion_Blazor_SplitButtons_AnimationEffect_SlideUp), [SlideDown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.AnimationEffect.html#Syncfusion_Blazor_SplitButtons_AnimationEffect_SlideDown), [ZoomIn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.AnimationEffect.html#Syncfusion_Blazor_SplitButtons_AnimationEffect_ZoomIn), and [ZoomOut](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.AnimationEffect.html#Syncfusion_Blazor_SplitButtons_AnimationEffect_ZoomOut).

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton Content="Slide Right">
    <ProgressButtonSpinSettings Position="SpinPosition.Center"></ProgressButtonSpinSettings>
    <ProgressButtonAnimationSettings Effect="Syncfusion.Blazor.SplitButtons.AnimationEffect.SlideRight" Duration= "400" Easing="Linear"></ProgressButtonAnimationSettings>
</SfProgressButton>

```
![Blazor ProgressButton with Animation](./images/blazor-progressbutton-animation.png)

### Change step of the Progress Button

The progress can be visualized at the specified interval by changing the [Step](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressEventArgs.html#Syncfusion_Blazor_SplitButtons_ProgressEventArgs_Step) property in the [OnBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html) event of the Progress Button. In this demo, the Step property is set to `20` to show progress at every 20% increment.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" Content="Progress Step" CssClass="e-hide-spinner">
    <ProgressButtonEvents OnBegin="Begin"></ProgressButtonEvents>
</SfProgressButton>

@code{
    private void Begin(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        args.Step = 20;
    }
}

```
![Changing Step of Blazor ProgressButton](./images/blazor-progressbutton-step.png)

N> The class `e-hide-spinner` hides the spinner in the Progress Button, For more information, see [hide spinner](./how-to/hide-spinner) section.

### Change Progress state dynamically

The progress state can be changed dynamically by modifying the [Percent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressEventArgs.html#Syncfusion_Blazor_SplitButtons_ProgressEventArgs_Percent) event argument in the [OnBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnBegin), [Progressing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_Progressing), [OnEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_OnEnd) events. In this example, on 40% completion of progress, the Percent property is set to `90` to show dynamic change of the progress state. The progress state can be changed dynamically by modifying the Percent property in the [Progress](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ProgressButtonEvents.html#Syncfusion_Blazor_SplitButtons_ProgressButtonEvents_Progressing) event.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" Content="@Content" Duration="15000" CssClass="e-hide-spinner">
    <ProgressButtonEvents OnBegin="Begin" Progressing="Progressing" OnEnd="End"></ProgressButtonEvents>
</SfProgressButton>

@code {
    public string Content = "Progress";
    public void Begin(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        Content = "Progress " + args.Percent + " %";
    }
    public void Progressing(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        Content = "Progressing " + args.Percent + " %";
        if (args.Percent == 40)
        {
            args.Percent = 90;
        }
    }
    public void End(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        Content = "Progress " + args.Percent + " %";
    }
}

```
![Changing Blazor ProgressButton State](./images/blazor-progressbutton-state.png)

### Start and Stop Methods

You can pause and resume the progress using the [StopAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_StopAsync) and [StartAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_StartAsync_System_Double_) methods, respectively. In this example, clicking the Progress Button will pause and resume the progress.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfProgressButton Content="@Content" EnableProgress="true" CssClass="@CssClass" IconCss="@IconCss" @ref="ProgressBtn">
    <ProgressButtonEvents OnEnd="End"></ProgressButtonEvents>
</SfProgressButton>
<SfButton OnClick="Click">Start And Stop</SfButton>

@code {
    SfProgressButton ProgressBtn;
    public string Content = "Download";
    public string CssClass = "e-hide-spinner";
    public string IconCss = "e-icons e-download";

    public async Task Click()
    {
        if(Content == "Download")
        {
            Content = "Pause";
            IconCss = "e-icons e-pause";
        }
        else if (this.Content == "Pause")
        {
            Content = "Resume";
            IconCss = "e-icons e-play";
            await ProgressBtn.StopAsync();
        }
        else if (this.Content == "Resume")
        {
            Content = "Pause";
            IconCss = "e-icons e-pause";
            await ProgressBtn.StartAsync();
        }
    }

    public void End(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
    {
        Content = "Download";
        IconCss = "e-icons e-download";
    }
}

<style>
    .e-download::before {
       content: '\e75d';
    }

    .e-play::before {
        content: '\e72d';
    }

    .e-pause::before {
        content: '\e757';
    }
</style>

```
![Blazor ProgressButton displays Start and Stop Process](./images/blazor-progressbutton-start-stop-process.png)

### EndProgressAsync Method

You can complete the progress by using the [EndProgressAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_EndProgressAsync) method and it will also hide the spinner. In this example, another button has been added to complete the current progress of the progress button.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SplitButtons

<SfProgressButton Content="Progress Button" EnableProgress="true" @ref="ProgressBtnObj">
    <ProgressButtonSpinSettings Position="SpinPosition.Left"></ProgressButtonSpinSettings>
    <ProgressButtonAnimationSettings Effect="Syncfusion.Blazor.SplitButtons.AnimationEffect.SlideRight" Duration="400" Easing="Linear"></ProgressButtonAnimationSettings>
</SfProgressButton>
<SfButton @onclick="OnCompleteClick">Complete</SfButton>

@code
{
    SfProgressButton ProgressBtnObj;
    private async Task OnCompleteClick()
    {
        await ProgressBtnObj.EndProgressAsync();
    }
}

```
