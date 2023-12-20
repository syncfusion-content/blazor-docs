---
layout: post
title: Stepper Flow in Blazor Stepper Component | Syncfusion
description: Checkout and learn here all about Stepper Flow with Syncfusion Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# Stepper Flow

The Stepper component provides control over the flow of steps through the utilization of the [Linear](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_Linear) property.

## Linear flow

When the `Linear` property is set to `true`, it enables a linear progression. In this mode, users move through steps sequentially, one after the other maintaining a fixed order. By default, the `Linear` property value is `false`.

## Non-Linear flow

In non-liner flow, the users have the flexibility to skip or complete steps in any order they prefer.

## Configure ActiveStep

The [ActiveStep](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_ActiveStep) in the Stepper represents the step currently in the focus or selected by the user.

When users interact with the Stepper, the `ActiveStep` indicates the progress within the sequence of steps. The ActiveStep dynamically changes as users navigate through the steps, helping to maintain a user-centric and intuitive experience. By default the `ActiveStep` is `0`.
