---
layout: post
title: Blazor ProgressBar Events Examples and Reference | Syncfusion®
description: Learn about events in Syncfusion Blazor ProgressBar such as ValueChanged, and how to handle progress changes with ProgressBarEvents.
platform: Blazor
control: ProgressBar
documentation: ug
---

# Blazor ProgressBar Events

This section describes the events of the Syncfusion Blazor [ProgressBar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html) component that are triggered when the corresponding actions are performed. The events should be provided to the ProgressBar through the [ProgressBarEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html) child component, as shown in the following samples.

## ValueChanged

The [ValueChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_ValueChanged) vent is triggered when the progress value is changed.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="80" Height="60" Minimum="0" Maximum="100">
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

The [ProgressCompleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_ProgressCompleted) event is triggered when the progress value attains the [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Maximum) value.

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

The [AnimationComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_AnimationComplete) event is triggered when an animation is enabled and the progress value attains the maximum value.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarAnimation Enable="true"></ProgressBarAnimation>
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

The [AnnotationRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_AnnotationRender) event triggers before each annotation is rendered.

>N> For a full walkthrough of annotation configuration, see the [Progress Annotation](progress-annotation.md) section.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Circular" Value="80" Height="160" Minimum="0" Maximum="100">
    <ProgressBarEvents AnnotationRender="@AnnotationHandler"></ProgressBarEvents>
    <ProgressBarAnnotations>
        <ProgressBarAnnotation>
            <ContentTemplate>
                <div style="font-size:20px;font-weight:bold;color:#000000;fill:#ffffff">
                    <span>
                        80%
                    </span>
                </div>
            </ContentTemplate>
        </ProgressBarAnnotation>
    </ProgressBarAnnotations>
</SfProgressBar>

@code{
    public void AnnotationHandler(AnnotationRenderEventArgs args)
    {
        // Here you can customize the code.
    }
}
```

## TextRender

The [TextRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_TextRender) event triggers before the text is rendered.

>N> Refer to the [Style and Appearance](style-appearance.md) section to configure text properties declaratively.

```cshtml
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" ShowProgressValue="true" Value="100" Height="60" Minimum="0" Maximum="100">
    <ProgressBarEvents TextRender="@TextRenderHandler"></ProgressBarEvents>
</SfProgressBar>

@code{
    public void TextRenderHandler(TextRenderEventArgs args)
    {
        // Here you can customize the text rendering code.
    }
}
```

## Loaded

The [Loaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.ProgressBarEvents.html#Syncfusion_Blazor_ProgressBar_ProgressBarEvents_Loaded) event is triggered after the ProgressBar component is rendered.

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