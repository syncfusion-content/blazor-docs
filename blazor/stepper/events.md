---
layout: post
title: Events in Blazor Stepper Component | Syncfusion
description: Checkout and learn about Events with Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# Events in Blazor Stepper Component

This section describes the Stepper events that will be triggered when an appropriate actions are performed. The following events are available in the Stepper control.

## Created

The Stepper component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_Created) event when the component rendering is completed.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfStepper Created="Created">
    <StepperSteps>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
    </StepperSteps>
</SfStepper>

@code{
    public void Created()
    {
        // Here, you can customize your code.
    }
}

```

## StepChanged

The Stepper component triggers the [StepChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepChanged) event after the active step is changed.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfStepper StepChanged="StepChanged">
    <StepperSteps>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
    </StepperSteps>
</SfStepper>

@code{
    public void StepChanged(StepperChangedEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## StepChanging

The Stepper component triggers the [StepChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepChanging) event before the active step change.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfStepper StepChanging="StepChanging">
    <StepperSteps>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
    </StepperSteps>
</SfStepper>

@code{
    public void StepChanging(StepperChangeEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## StepClicked

The Stepper component triggers the [StepClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepClicked) event when the step is clicked.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfStepper StepClicked="StepClicked">
    <StepperSteps>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
    </StepperSteps>
</SfStepper>

@code{
    public void StepClicked(StepperClickedEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## StepRendered

The Stepper component triggers the [StepRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepRendered) event after rendering of the each step.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfStepper StepRendered="StepRendered">
    <StepperSteps>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
        <StepperStep></StepperStep>
    </StepperSteps>
</SfStepper>

@code{
    public void StepRendered(StepperRenderedEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```