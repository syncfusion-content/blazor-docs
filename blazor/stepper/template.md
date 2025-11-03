---
layout: post
title: Template in Blazor Stepper Component | Syncfusion
description: Checkout and learn about Template with Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# Template in Blazor Stepper Component

The Stepper component allows you to customize the default appearance and content of each step, creating a personalized experience for the user. You can use the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfStepper.html#Syncfusion_Blazor_Navigations_SfStepper_Template) tag directive to set the template content for the steps.

The `StepperStep` tag directive options and current step index are passed as `step` and `currentStep` properties in the template context for customization.

```cshtml

@using Syncfusion.Blazor.Navigations

<div class="stepper-template-wrapper">
    <SfStepper ID="stepper" ActiveStep="1">
        <ChildContent>
            <StepperSteps>
                <StepperStep Label="PowerPoint" IconCss="sf-icon-powerpoint"></StepperStep>
                <StepperStep Label="Presentation" IconCss="sf-icon-projector"></StepperStep>
                <StepperStep Label="Backup" IconCss="sf-icon-onedrive"></StepperStep>
            </StepperSteps>
        </ChildContent>
        <Template>
            <div class="template-content">
                <span class="@context.IconCss"></span><br>
                <span class="e-label">@context.Label</span>
            </div>
        </Template>
    </SfStepper>
</div>

<style>
    .template-content {
        background: #fff;
        width: 65px;
    }

    /* Stepper progressbar customization */
    .e-stepper .e-stepper-progressbar {
      height: 3px;
      top: 25px;
    }
    .e-stepper .e-stepper-progressbar .e-progressbar-value {
      background-color: #27d96d;
    }

    /* Stepper status customization */
    #stepper .e-step-completed * {
      color: #19cd60;
    }

    #stepper .e-step-inprogress * {
      color: #3479f3;
    }

    #stepper .e-step-notstarted * {
      color: #bdbdbd;
    }

    @@font-face {
    font-family: 'template_updated';
    src:
    url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
    font-weight: normal;
    font-style: normal;
    }

    [class^="sf-icon-"], [class*=" sf-icon-"] {
    font-family: 'template_updated' !important;
    speak: none; 
    font-size: 40px;
    font-style: normal;
    font-weight: normal;
    font-variant: normal;
    text-transform: none;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    }

    .sf-icon-projector:before { content: "\e700"; }
    .sf-icon-powerpoint:before { content: "\e701"; }
    .sf-icon-onedrive:before { content: "\e702"; }


    .stepper-template-wrapper {
      width: 75%;
      margin: 0px auto;
      min-width: 85px;
      padding: 25px 0;
    }
</style>

```

![Blazor Stepper Component with Template](./images/Blazor-template.png)