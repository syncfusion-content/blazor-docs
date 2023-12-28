---
layout: post
title: Animation in Blazor Stepper Component | Syncfusion
description: Checkout and learn here all about Animation with Syncfusion Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# AnimationSettings in Blazor Stepper Component

The Stepper progress bar can be animated during each step transition. You can use the [StepperAnimationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperAnimationSettings.html) tag directive in the Stepper by setting the `Enable` property to `true`. By default, it is `true`.

## Enabling animation

Using the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperAnimationSettings.html#Syncfusion_Blazor_Navigations_StepperAnimationSettings_Enable) property you can activate/deactivate an animation. The default value is true, indicating that animation is enabled.

## Duration

The [Duration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperAnimationSettings.html#Syncfusion_Blazor_Navigations_StepperAnimationSettings_Duration) property specifies the duration of the animation. The default value is set to `1000` milliseconds.

## Delay

The [Delay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperAnimationSettings.html#Syncfusion_Blazor_Navigations_StepperAnimationSettings_Delay) property sets the animation delay. The default value is `0` milliseconds.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfStepper>
    <StepperSteps>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
    </StepperSteps>
    <StepperAnimationSettings Enable=true Delay="500" Duration="2000"></StepperAnimationSettings>
</SfStepper>

```

![Blazor Stepper Component with Animation](./images/Blazor-animation.png)