---
layout: post
title: Style and Appearance in Blazor DataForm Component | Syncfusion
description: Learn how to apply basic styling, colors, fonts, and text formatting to customize the appearance of the Blazor DataForm component and its elements.
platform: Blazor
control: DataForm
documentation: ug
---

# Style and Appearance

The DataForm component can be customized with CSS styling to create visually appealing forms. This section explains how to apply basic colors, fonts, text styling, and other appearance customizations to the DataForm component and its child elements.

## Basic Styling

Customize the DataForm appearance using CSS selectors to style the form background, labels, input fields, and buttons with colors, fonts, and hover effects.

```css
/* Basic styling: Change the overall form background and text color */
#BasicStylingForm.e-data-form {
    background-color: #f5f5f5;
    color: #333;
    padding: 20px;
    border-radius: 8px;
}

#BasicStylingForm.e-data-form:hover {
    background-color: #dde9e9;
}

/* Style the form labels */
#BasicStylingForm .e-form-label {
    color: #4b6075;
    font-weight: 600;
    font-size: 14px;
    letter-spacing: 0.5px;
}

/* Style the input fields */
#BasicStylingForm .e-input {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    font-size: 14px;
    color: #526949;
}

#BasicStylingForm .e-input-group, .e-input-group.e-control-wrapper{
    background: transparent;
}

/* Style the submit button with basic colors */
#BasicStylingForm .e-btn.e-primary {
    background-color: #0b7ffb;
    border: none;
    font-weight: 600;
    padding: 10px 24px;
    font-size: 14px;
    transition: background-color 0.3s ease;
}

#BasicStylingForm .e-btn.e-primary:hover {
    background-color: #093a6f;
    animation: bounce 0.6s;
}

@keyframes bounce {
    0% { transform: translateY(0); }
    30% { transform: translateY(-4px); }
    60% { transform: translateY(2px); }
    100% { transform: translateY(0); }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrdXTriJTArYaVM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Layout & Spacing Customization

Control spacing, padding, margins, and layout of form items to create well-organized and visually balanced forms with proper spacing between elements.

```css
/* Main form container - add padding and spacing */
#LayoutSpacingForm.e-data-form {
    background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
    padding: 30px;
    border-radius: 12px;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
}

/* Customize the grid layout - control spacing between form items */
#LayoutSpacingForm .e-grid-col-1 {
    margin-bottom: 24px;
}

/* Add spacing between label and input field */
#LayoutSpacingForm .e-label-position-top {
    display: flex;
    flex-direction: column;
    gap: 10px;
}

#LayoutSpacingForm .e-form-label {
    margin-bottom: 5px;
    padding: 0;
}

/* Customize form item wrapper spacing */
#LayoutSpacingForm .e-form-item-wrapper {
    padding: 0;
}

#LayoutSpacingForm .e-form-item {
    padding: 8px 0;
}

/* Add padding inside input fields */
#LayoutSpacingForm .e-input {
    padding: 12px 15px !important;
    min-height: 44px;
}

/* Customize button container spacing */
#LayoutSpacingForm .e-button-right {
    margin-top: 30px;
    padding-top: 20px;
    border-top: 2px solid rgba(0, 0, 0, 0.1);
}

/* Button styling with proper spacing */
#LayoutSpacingForm .e-btn.e-primary {
    padding: 12px 32px;
    font-size: 15px;
    min-width: 150px;
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLHNJrCTfpfSzgF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Input Styling

Style input fields with custom borders, focus states, and visual effects to create an enhanced user interaction experience with smooth transitions and color changes.

```css
#InputStylingForm.e-data-form {
    background-color: #ffffff;
    padding: 25px;
    border-radius: 10px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.08);
}

#InputStylingForm .e-form-label {
    color: #404040;
    font-weight: 600;
    margin-bottom: 8px;
}

/* Base input styling - border and background */
#InputStylingForm .e-input-group.e-control-container {
    border: 2px solid #e0e0e0 !important;
    background-color: #f9f9f9;
    border-radius: 6px;
    transition: all 0.3s ease;
    color: #333;
    font-size: 14px;
}

/* Focus state - highlight input on focus */
#InputStylingForm .e-input-group.e-control-container.e-input-focus {
    border-color: #007bff !important;
    background-color: #ffffff;
    box-shadow: 0 0 0 3px rgba(0, 123, 255, 0.1);
    outline: none;
}

/* Hover state - subtle highlight on hover */
#InputStylingForm .e-input-group.e-control-container:hover {
    border-color: #b0b0b0 !important;
    background-color: #fafafa;
}

/* Grid column spacing */
#InputStylingForm .e-grid-col-1 {
    margin-bottom: 20px;
}

/* Button styling */
#InputStylingForm .e-btn.e-primary {
    background: linear-gradient(135deg, #007bff 0%, #0056b3 100%);
    border: none;
    border-radius: 6px;
    padding: 12px 30px;
    font-weight: 600;
    font-size: 14px;
    cursor: pointer;
    transition: all 0.3s ease;
    box-shadow: 0 2px 8px rgba(0, 123, 255, 0.3);
}

#InputStylingForm .e-btn.e-primary:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0, 123, 255, 0.4);
}

#InputStylingForm .e-btn.e-primary:active {
    transform: translateY(0);
    box-shadow: 0 2px 6px rgba(0, 123, 255, 0.3);
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBdXzhiTpICsBUl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Validation Styling

Apply custom styling to validation messages, error states, and valid states to provide clear visual feedback for form validation results.

```css
#ValidationStyleForm.e-data-form {
    background-color: #ffffff;
    padding: 25px;
    border-radius: 10px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.08);
}

#ValidationStyleForm .e-form-label {
    color: #2c3e50;
    font-weight: 600;
    margin-bottom: 8px;
}

/* Base input styling */
#ValidationStyleForm .e-input-group.e-control-container {
    border: 2px solid #e0e0e0 !important;
    background-color: #f9f9f9;
    border-radius: 6px;
    transition: border-color 0.3s ease, box-shadow 0.3s ease;
}

/* Valid state - green border */
#ValidationStyleForm .e-input-group.e-control-container.e-valid-input {
    border-color: #28a745 !important;
    background-color: #f0fdf4;
}

#ValidationStyleForm .e-input-group.e-control-container.e-valid-input.e-input-focus {
    box-shadow: 0 0 0 3px rgba(40, 167, 69, 0.1);
}

/* Invalid state - red border and error styling */
#ValidationStyleForm .e-input-group.e-control-container.e-invalid {
    border-color: #dc3545 !important;
    background-color: #fff5f5;
}

#ValidationStyleForm .e-input-group.e-control-container.e-invalid.e-input-focus {
    box-shadow: 0 0 0 3px rgba(220, 53, 69, 0.1);
}

/* Error message styling */
#ValidationStyleForm .e-error {
    color: #dc3545;
    font-size: 13px;
    font-weight: 500;
    margin-top: 6px;
    animation: slideInError 0.3s ease;
}

/* Success message styling */
#ValidationStyleForm .e-success {
    color: #28a745;
    font-size: 13px;
    font-weight: 500;
    margin-top: 6px;
}

/* Form item with error styling */
#ValidationStyleForm .e-form-item.e-error {
    padding: 8px 0;
}

/* Checkbox styling */
#ValidationStyleForm .e-checkbox-wrapper .e-frame.e-check {
    background-color: #007bff;
    border-color: #007bff;
}

/* Grid column spacing */
#ValidationStyleForm .e-grid-col-1 {
    margin-bottom: 24px;
}

/* Button styling */
#ValidationStyleForm .e-btn.e-primary {
    background-color: #007bff;
    border: none;
    border-radius: 6px;
    padding: 12px 30px;
    font-weight: 600;
    font-size: 14px;
    cursor: pointer;
    transition: all 0.3s ease;
    box-shadow: 0 2px 8px rgba(0, 123, 255, 0.3);
}

#ValidationStyleForm .e-btn.e-primary:hover {
    background-color: #0056b3;
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0, 123, 255, 0.4);
}

/* Animation for error messages */
@keyframes slideInError {
    from {
        opacity: 0;
        transform: translateY(-5px);
    }
    to {
        opacity: 1;
        transform: translateY(0);
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLxXJViJTdLXqQW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Advanced Animations

Create modern user experiences with advanced CSS animations, transitions, glass-morphism effects, and interactive visual feedback for form interactions.

```css
/* Main form with glass-morphism effect */
#AdvancedAnimForm.e-data-form {
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    padding: 40px;
    border-radius: 16px;
    box-shadow: 0 8px 32px 0 rgba(31, 38, 135, 0.2),
                0 0 0 1px rgba(255, 255, 255, 0.5);
    border: 1px solid rgba(255, 255, 255, 0.3);
    animation: formFadeIn 0.6s ease-out;
}

/* Form fade-in animation */
@keyframes formFadeIn {
    from {
        opacity: 0;
        transform: translateY(20px);
    }
    to {
        opacity: 1;
        transform: translateY(0);
    }
}

/* Form items cascade animation */
#AdvancedAnimForm .e-grid-col-1 {
    margin-bottom: 24px;
    animation: slideInLeft 0.5s ease-out both;
}

#AdvancedAnimForm .e-grid-col-1:nth-child(1) { animation-delay: 0.1s; }
#AdvancedAnimForm .e-grid-col-1:nth-child(2) { animation-delay: 0.2s; }
#AdvancedAnimForm .e-grid-col-1:nth-child(3) { animation-delay: 0.3s; }
#AdvancedAnimForm .e-grid-col-1:nth-child(4) { animation-delay: 0.4s; }
#AdvancedAnimForm .e-grid-col-1:nth-child(5) { animation-delay: 0.5s; }

@keyframes slideInLeft {
    from {
        opacity: 0;
        transform: translateX(-30px);
    }
    to {
        opacity: 1;
        transform: translateX(0);
    }
}

/* Label styling with subtle animation on hover */
#AdvancedAnimForm .e-form-label {
    color: #2c3e50;
    font-weight: 600;
    font-size: 14px;
    transition: color 0.3s ease, transform 0.3s ease;
}

#AdvancedAnimForm .e-label-position-top:hover .e-form-label {
    color: #007bff;
    transform: translateX(3px);
}

/* Input styling with smooth transitions */
#AdvancedAnimForm .e-input-group.e-control-wrapper {
    border: 2px solid #e0e0e0;
    background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
    border-radius: 8px;
    transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
    color: #333;
    font-size: 14px;
    padding: 12px 15px !important;
}

/* Input group wrapper */
#AdvancedAnimForm .e-input-group {
    border-radius: 8px;
    overflow: hidden;
}

/* Focus state with glow effect */
#AdvancedAnimForm .e-input-group.e-control-wrapper.e-input-focus {
    border-color: #007bff;
    background: #ffffff;
    box-shadow: 0 0 0 4px rgba(0, 123, 255, 0.15);
    outline: none;
    transform: translateY(-2px);
}

/* Input hover state */
#AdvancedAnimForm .e-input-group.e-control-wrapper:hover {
    border-color: #f864c1 !important;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08) !important;
}

/* Valid state with success animation */
#AdvancedAnimForm .e-input-group.e-control-wrapper.valid {
    border-color: #69beff;
    background: linear-gradient(135deg, #d2e6ed 0%, #e8f5e9 100%);
    animation: successBounce 0.4s ease;
}

@keyframes successBounce {
    0% { transform: scale(0.95); }
    50% { transform: scale(1.02); }
    100% { transform: scale(1); }
}

/* Invalid state with shake animation */
#AdvancedAnimForm .e-input-group.e-control-wrapper.e-error {
    border-color: #dc3545;
    background: linear-gradient(135deg, #fff5f5 0%, #ffe8e8 100%);
    animation: shake 0.3s ease;
}

@keyframes shake {
    0%, 100% { transform: translateX(0); }
    25% { transform: translateX(-5px); }
    75% { transform: translateX(5px); }
}

/* Error message styling */
#AdvancedAnimForm .e-error {
    color: #dc3545 !important;
    font-size: 13px !important;
    font-weight: 500 !important;
    margin-top: 6px !important;
    animation: slideInError 0.3s ease !important;
}

@keyframes slideInError {
    from {
        opacity: 0;
        transform: translateY(-8px);
    }
    to {
        opacity: 1;
        transform: translateY(0);
    }
}

/* Button styling with advanced effects */
#AdvancedAnimForm .e-button-right {
    margin-top: 30px;
    padding-top: 30px;
    border-top: 2px dashed rgba(0, 123, 255, 0.2);
}

#AdvancedAnimForm .e-btn.e-primary {
    background: linear-gradient(135deg, #007bff 0%, #0056b3 100%);
    border: none;
    border-radius: 8px;
    padding: 14px 40px;
    font-weight: 600;
    font-size: 15px;
    cursor: pointer;
    color: white;
    box-shadow: 0 4px 15px rgba(0, 123, 255, 0.3);
    transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
    position: relative;
    overflow: hidden;
}

#AdvancedAnimForm .e-btn.e-primary:hover {
    transform: translateY(-3px);
    box-shadow: 0 8px 25px rgba(0, 123, 255, 0.4);
    letter-spacing: 0.5px;
}

#AdvancedAnimForm .e-btn.e-primary:active {
    transform: translateY(-1px);
    box-shadow: 0 4px 12px rgba(0, 123, 255, 0.3);
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBdDzrspTGEusmS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Responsive Design

Create mobile-friendly forms that adapt to different screen sizes with flexible layouts, touch-optimized controls, and responsive breakpoints for optimal viewing on all devices.

```css
/* Main form styling */
#ResponsiveForm.e-data-form {
    background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
    padding: 24px;
    border-radius: 12px;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
}

#ResponsiveForm .e-form-label {
    color: #2c3e50;
    font-weight: 600;
    font-size: 14px;
}

#ResponsiveForm .e-input-group.e-control-wrapper {
    border: 2px solid #e0e0e0;
    background-color: #f9f9f9;
    border-radius: 8px;
    transition: all 0.3s ease;
    padding: 12px 15px !important;
    font-size: 14px;
}

#ResponsiveForm .e-input-group.e-control-wrapper.e-input-focus {
    border-color: #007bff;
    box-shadow: 0 0 0 3px rgba(0, 123, 255, 0.1);
}

#ResponsiveForm .e-grid-col-1 {
    margin-bottom: 20px;
}

#ResponsiveForm .e-btn.e-primary {
    background: linear-gradient(135deg, #007bff 0%, #0056b3 100%);
    border: none;
    border-radius: 8px;
    padding: 12px 24px;
    font-weight: 600;
    font-size: 14px;
    cursor: pointer;
    transition: all 0.3s ease;
    width: 100%;
    max-width: 200px;
}

#ResponsiveForm .e-btn.e-primary:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0, 123, 255, 0.4);
}

#ResponsiveForm .e-button-right {
    margin-top: 20px;
    display: flex;
    justify-content: center;
}

/* Extra small devices (less than 480px) */
@media (max-width: 479px) {
    #ResponsiveForm.e-data-form {
        padding: 16px;
    }

    #ResponsiveForm .e-form-label {
        font-size: 13px;
    }

    #ResponsiveForm .e-input-group.e-control-wrapper {
        font-size: 13px;
        padding: 10px 12px !important;
    }

    #ResponsiveForm .e-grid-col-1 {
        margin-bottom: 16px;
    }

    #ResponsiveForm .e-btn.e-primary {
        padding: 10px 20px;
        font-size: 13px;
        width: 100%;
        max-width: none;
    }
}

/* Small devices (480px - 767px) */
@media (min-width: 480px) and (max-width: 767px) {
    #ResponsiveForm.e-data-form {
        padding: 20px;
    }

    #ResponsiveForm .e-form-label {
        font-size: 14px;
    }

    #ResponsiveForm .e-input-group.e-control-wrapper {
        font-size: 14px;
        padding: 11px 13px !important;
    }

    #ResponsiveForm .e-grid-col-1 {
        margin-bottom: 18px;
    }

    #ResponsiveForm .e-btn.e-primary {
        padding: 11px 22px;
        width: auto;
    }

    #ResponsiveForm .e-form-layout {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 16px;
    }
}

/* Medium devices (768px - 1023px) */
@media (min-width: 768px) and (max-width: 1023px) {
    #ResponsiveForm.e-data-form {
        padding: 24px;
    }

    #ResponsiveForm .e-form-layout {
        display: grid;
        gap: 16px;
    }

    #ResponsiveForm .e-grid-col-1:nth-child(odd):last-child {
        grid-column: 1 / -1;
        max-width: 50%;
    }
}

/* Large devices (1024px and above) */
@media (min-width: 1024px) {
    #ResponsiveForm.e-data-form {
        padding: 30px;
        max-width: 900px;
        margin: 0 auto;
    }

    #ResponsiveForm .e-form-layout {
        display: grid;
        gap: 20px;
    }

    #ResponsiveForm .e-grid-col-1:last-child {
        grid-column: 1 / -1;
    }
}

/* Touch device optimizations */
@media (hover: none) and (pointer: coarse) {
    #ResponsiveForm .e-input-group.e-control-wrapper,
    #ResponsiveForm .e-btn.e-primary {
        padding: 14px 16px !important;
        min-height: 48px !important;
    }

    #ResponsiveForm .e-btn.e-primary {
        min-width: 48px !important;
    }
}

#ResponsiveForm .e-form-item-wrapper {
    padding: 0;
}

#ResponsiveForm .e-form-item {
    padding: 8px 0;
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrRZJVCffbmYvBB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}