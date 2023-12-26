---
layout: post
title: Events in Stepper Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# Events

This section describes the stepper events that will be triggered when appropriate actions are performed. The following events are available in the stepper component.

## Created

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_Created) event is triggered when the Stepper component is initially created.

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

The [StepChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepChanged) event occurs when the active step in the Stepper changes. The [StepperChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperChangedEventArgs.html) passed as an event argument provides the information about StepChanged event callback.

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

The [StepChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepChanging) event is triggered before the active step changes in the Stepper. The [StepperChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperChangeEventArgs.html) passed as an event argument provides the information about StepChanging event callback.

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

The [StepClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepClicked) event is triggered when a step in the Stepper is clicked. The [StepperClickedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperClickedEventArgs.html) passed as an event argument provides the information about StepClicked event callback.

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

The [StepRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepRendered) event occurs when step is rendered in the Stepper. The [StepperRenderedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperRenderedEventArgs.html) passed as an event argument provides the information about StepRendered event callback.

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