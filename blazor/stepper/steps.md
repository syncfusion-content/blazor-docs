---
layout: post
title: Step in Blazor Stepper Component | Syncfusion
description: Checkout and learn here all about Step with Syncfusion Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# Adding Stepper Steps

The [StepperStep](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html) tag directive can be used to add the Stepper steps. The steps collections represent the options for each step within the stepper.

## Icon

The [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_IconCss) property allows us to specify and customize an icon for each step.

## Text

The [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_Text) property allows to specify the text content for each step.

## Label

By using the [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_Label) property, additional information can be provided for each step.

## Optional

The [Optional](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_Optional) property defines whether the step is optional to skip completion or not. By default the `Optional` property is false.

## Disabled

The [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_Disabled) property can be used to disable any step. By default the `Disabled` property is false.

## Validation

Setting the [IsValid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_IsValid) property to true for valid completion otherwise, set it to false. Indicates whether a step has met its required criteria. The default value is `false`.

## Status

The [Status](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_Status) property holds a [StepperStatus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStatus.html) value representing the progress state of each step. You can set the status for the current active step ([NotStarted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStatus.html#Syncfusion_Blazor_Navigations_StepperStatus_NotStarted), [InProgress](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStatus.html#Syncfusion_Blazor_Navigations_StepperStatus_InProgress), [Completed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStatus.html#Syncfusion_Blazor_Navigations_StepperStatus_Completed)). The default value is `NotStarted.`

## CssClass

The [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_CssClass) property is used to set a custom CSS class for customizing the appearance of the step.
