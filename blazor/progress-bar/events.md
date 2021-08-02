---
layout: post
title: Events in Blazor ProgressBar Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor ProgressBar component and much more details.
platform: Blazor
control: Progress Bar 
documentation: ug
---

# Events in Blazor ProgressBar Component

This section describes the Progress Bar component's events that will be triggered when appropriate actions are performed. The events should be provided to the Progress Bar through the [`ProgressBarEvents`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html).

## ValueChanged

The [`ValueChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_ValueChanged) event triggers when the progress value is changed.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarEvents ValueChanged="@ValueHandler"></ProgressBarEvents>
</SfProgressBar>

@code{
    public void ValueHandler(ProgressValueEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## ProgressCompleted

The [`ProgressCompleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_ProgressCompleted) event triggers when the progress attains the [`Maximum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Maximum) value.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarEvents ProgressCompleted="@ProgressHandler"></ProgressBarEvents>
</SfProgressBar>

@code{
    public void ProgressHandler(ProgressValueEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## AnimationComplete

The [`AnimationComplete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_AnimationComplete) event triggers when an animation is enabled and the progress value is reached.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarEvents AnimationComplete="@AnimationHandler"></ProgressBarEvents>
</SfProgressBar>

@code{
    public void AnimationHandler(ProgressValueEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## AnnotationRender

The [`AnnotationRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_AnnotationRender) event triggers before each annotation is rendered.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarEvents AnnotationRender="@AnnotationHandler"></ProgressBarEvents>
</SfProgressBar>

@code{
    public void AnnotationHandler(AnnotationRenderEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## TextRender

The [`TextRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_TextRender) event triggers before the text is rendered.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarEvents TextRender="@TextRenderHandler"></ProgressBarEvents>
</SfProgressBar>

@code{
    public void TextRenderHandler(TextRenderEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## Loaded

The `Loaded` event triggers after the component is rendered.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarEvents Loaded="@LoadedHandler"></ProgressBarEvents>
</SfProgressBar>

@code{
    public void LoadedHandler(System.EventArgs args)
    {
        // Here you can customize the code.
    }
}
```
