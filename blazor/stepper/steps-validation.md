---
layout: post
title: Validation in Blazor Stepper Component | Syncfusion
description: Checkout and learn about Validation with Blazor Stepper component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Stepper
documentation: ug
---

# Steps validation in Blazor Stepper Component

The Stepper component allows you to set the validation state for each step, displaying either a success or error icon. You can define the success state of a step by setting the [IsValid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.StepperStep.html#Syncfusion_Blazor_Navigations_StepperStep_IsValid) property to `true`. If set to `false`, the step will display an error state. By default, the `IsValid` property is `null`.

> Based on the `StepType`, the validation state icon will be displayed either as an indicator or as part of the step label/text.

```cshtml

@using Syncfusion.Blazor.Navigations
@using System.ComponentModel.DataAnnotations

<SfStepper @ref="stepper" StepChanging="@handleStepChange" Linear=true>
    <StepperSteps>
        <StepperStep @ref="stepperStep1" IconCss="sf-icon-survey-intro" Text="Survey Info"></StepperStep>
        <StepperStep @ref="stepperStep2" IconCss="sf-icon-survey-feedback" Text="Feedback"></StepperStep>
        <StepperStep @ref="stepperStep3" IconCss="sf-icon-survey-status" Text="Status"></StepperStep>
    </StepperSteps>
</SfStepper>

<EditForm Model="@model">
    <DataAnnotationsValidator />
    <div class="valid-form">
        @if (currentStep == 1)
        {
            <div class="form-group">
                <label for="name">Enter Your Name:</label>
                <div class="validation-container">
                    <InputText id="name" @bind-Value="@model.Name" />
                    <ValidationMessage For="@(() => model.Name)" />
                </div>
            </div>
            <div class="form-group">
                <label for="email">Enter Your Email Address:</label>
                <div class="validation-container">
                    <InputText id="email" @bind-Value="@model.Email" />
                    <ValidationMessage For="@(() => model.Email)" />
                </div>
            </div>
        }
        else if (currentStep == 2)
        {
            <div class="feedback-form">
                <p>Anything else you'd like to share?</p>
                <div class="validation-container">
                    <InputTextArea id="Feedback" @bind-Value="@model.Feedback"></InputTextArea>
                    @if (isValidMsg)
                    {
                        <ValidationMessage For="@(() => model.Feedback)" />
                    }
                    @if (model.Feedback != null && model.Feedback.Length < 15)
                    {
                        <div class="validation-message">Please enter at least 15 characters.</div>
                    }
                </div>

            </div>
        }
    </div>
    @if (currentStep == 2)
    {
        <button type="submit" style="margin-right: 3%;" class="e-btn" @onclick="@onPreviousStep"> Previous </button>
    }
    @if (currentStep != 3)
    {
        content = "";
        <button type="submit" style="margin-right: 3%;" class="e-btn" @onclick="@onNextStep">@(currentStep == 1 ? "Next" : "Submit Feedback")</button>
    }
    <h5 style="margin-top: 20px; color: green">@content</h5>
    @if (currentStep == 3)
    {
        if (showFeedBack)
        {
            <h6><b>Please confirm to submit your feedback.</b></h6>
            <p>@model.Feedback</p>
            <button type="submit" style="margin-right: 3%;" class="e-btn" @onclick="@onPreviousStep"> Previous </button>
            <button type="submit" class="e-btn" @onclick="@orderConfirm">Confirm</button>
        }
        else
        {
            <button type="submit" style="margin-top: 20px;" class="e-btn" @onclick="@onReset"> Reset </button>
        }
    }
    
</EditForm>

@code {
    private StepperModel model = new StepperModel();
    private SfStepper stepper;
    private StepperStep stepperStep1;
    private StepperStep stepperStep2;
    private StepperStep stepperStep3;
    private int currentStep = 1;
    private bool isValid = false;
    private string content = "";
    private bool isValidMsg = false;
    private bool showFeedBack = false;

    private async void onNextStep()
    {
        await stepper.NextStepAsync();
    }
    private async void onPreviousStep()
    {
        await stepper.PreviousStepAsync();
    }
    private async void onReset()
    {
        currentStep = 1;        
        await stepper.ResetAsync();
        await Task.Delay(50);
        model.Name = string.Empty;
        model.Email = string.Empty;
        model.Feedback = string.Empty;
        StateHasChanged();
    }

    private void orderConfirm()
    {
        if (isValid && currentStep == 3)
        {
            content = "Thanks! Feedback has been submitted successfully.";
            showFeedBack = false;
        }
    }

    private void handleStepChange(StepperChangeEventArgs args)
    {
        if (args.ActiveStep != args.PreviousStep || currentStep == 3)
        {
            isValid = false;
            switch (currentStep)
                {
                case 1:
                    if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrEmpty(model.Email))
                    {
                        stepperStep1.IsValid = true;
                        if (args.ActiveStep < args.PreviousStep)
                        {
                            stepperStep1.IsValid = null;
                            stepperStep2.IsValid = null;
                            stepperStep3.IsValid = null;
                        }
                        else
                        {
                            currentStep++;
                        }
                        args.Cancel = false;
                    }
                    else
                    {
                        stepperStep1.IsValid = false;
                        args.Cancel = true;
                    }
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(model.Feedback) && model.Feedback.Length >= 15)
                    {
                        stepperStep2.IsValid = isValid = true;
                        if (args.ActiveStep < args.PreviousStep)
                        {
                            currentStep = currentStep - 1;
                            stepperStep2.IsValid = null;
                            if (args.ActiveStep == 0)
                            {
                                stepperStep1.IsValid = null;
                            }
                        }
                        else
                        {
                            currentStep++;
                            showFeedBack = true;
                        }
                        args.Cancel = false;
                        }
                    else
                    {
                        if (args.ActiveStep == 0)
                        {
                            stepperStep1.IsValid = null;
                            currentStep -= 1;
                            args.Cancel = false;
                        }
                        else
                        {
                            stepperStep2.IsValid = isValid = false;
                            args.Cancel = isValidMsg = true;
                        }
                    }
                    break;
                case 3:
                    stepperStep3.IsValid = true;
                    if (args.ActiveStep < args.PreviousStep)
                    {
                        currentStep = currentStep - 1;
                        stepperStep3.IsValid = null;
                    }
                    break;
            }
        }
    }


    public class StepperModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your feedback")]
        [MinLength(15)]
        public string Feedback { get; set; }
    }
}

<style>
    @@font-face {
        font-family: 'Survey-icons';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    [class^="sf-icon-"],
    [class*=" sf-icon-"] {
        font-family: 'Survey-icons' !important;
        speak: none;
        font-size: 55px;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: inherit;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .sf-icon-survey-feedback:before {
        content: "\e700";
    }

    .sf-icon-survey-intro:before {
        content: "\e703";
    }

    .sf-icon-survey-status:before {
        content: "\e707";
    }

    label {
        min-width: 200px;
    }

    form {
        margin: 0 auto;
        width: fit-content;
    }

    .form-group {
        margin-top: 20px;
        display: flex;
    }

    .validation-message {
        font-size: 14px;
    }

    .valid-form {
        margin: 40px 0;
        padding: 0 10px;
    }
</style>

```

![Validation using editform](./images/edit-form.png)
