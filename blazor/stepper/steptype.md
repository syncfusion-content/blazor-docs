---
layout: post
title: Step Type in Blazor Stepper Component | Syncfusion
description: Checkout and learn here all about Step Type with Syncfusion Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# StepType

The [StepType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_StepType) property in the Stepper determines whether steps should be displayed using only with indicators, only labels, or a combination of both. The available values for this property are [Default](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperType.html#Syncfusion_Blazor_Navigations_StepperType_Default), [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperType.html#Syncfusion_Blazor_Navigations_StepperType_Label), and [Indicator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperType.html#Syncfusion_Blazor_Navigations_StepperType_Indicator).

## Default

Steps are displayed with icons and the labels when defined.

## Label

Steps are displayed with only labels irrespective of the step model configured.

### Label positions

The [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_LabelPosition) property offers four positioning options: [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperLabelPosition.html#Syncfusion_Blazor_Navigations_StepperLabelPosition_Top), [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperLabelPosition.html#Syncfusion_Blazor_Navigations_StepperLabelPosition_Bottom), [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperLabelPosition.html#Syncfusion_Blazor_Navigations_StepperLabelPosition_Start), and [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperLabelPosition.html#Syncfusion_Blazor_Navigations_StepperLabelPosition_End). This property indicated the placement of the labels, depending on the updated position. The labels can be positioned only when the icon and label is configured with the stepper step. The available positions are as follows:

#### Top

Positions the label at the top, regardless of the Stepper's orientation.

#### Bottom

Positions the label at the bottom, regardless of the Stepper's orientation.

#### Start

Positions the label to the left side, regardless of the Stepper's orientation.

#### End

Positions the label to the right side, regardless of the Stepper's orientation. By default `labelPosition` is set to `End`.

## Indicator

Steps are displayed with only indicators.