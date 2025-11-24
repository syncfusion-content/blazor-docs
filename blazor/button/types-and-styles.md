---
layout: post
title: Types and Styles in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Types and Styles in Syncfusion Blazor Button component and much more.
platform: Blazor
control: Button
documentation: ug
---

# Types and Styles in Blazor Button Component

This section explains the different styles and types of Buttons.

## Button styles

The Blazor Button has the following predefined styles that can be defined using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property.

| Class | Description |
| -------- | -------- |
| e-primary | Used to represent a primary action. |
| e-success | Used to represent a positive action. |
| e-info |  Used to represent an informative action. |
| e-warning | Used to represent an action with caution. |
| e-danger | Used to represent a negative action. |
| e-link |  Changes the appearance of the Button like a hyperlink. |

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-primary">Primary</SfButton>
<SfButton CssClass="e-success">Success</SfButton>
<SfButton CssClass="e-info">Info</SfButton>
<SfButton CssClass="e-warning">Warning</SfButton>
<SfButton CssClass="e-danger">Danger</SfButton>
<SfButton CssClass="e-link">Link</SfButton>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVgChrhiGfocEOi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Button Component with different Styles](./images/blazor-button-with-different-style.png)" %}

N> Predefined Button styles provide only the visual indication. So, Button content should define the Button style for the users of assistive technologies such as screen readers.

## Button types

The types of Blazor Button are as follows:

* Flat Button
* Outline Button
* Round Button
* Primary Button
* Toggle Button

### Flat Button

The Flat Button is styled with no background color. To create a Flat Button, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-flat`.

### Outline Button

An Outline Button has a border with transparent background. To create an Outline Button, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-outline`.

### Round Button

A Round Button is circular in shape. Usually, it contains an icon representing its action. To create a Round Button, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-round`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-flat">Flat</SfButton>
<SfButton CssClass="e-outline">Outline</SfButton>
<SfButton CssClass="e-round" IconCss="e-icons e-plus-icon" IsPrimary="true"></SfButton>

<style>
    .e-plus-icon::before {
        content: '\e823';
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrUsBLBsQJYnPIv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Button with different Types](./images/blazor-button-types.png)" %}

### Primary Button

The primary button is styled with background color and it is used to represent a primary action. To create a Primary Button, set the [IsPrimary](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IsPrimary) property to `true`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton IsPrimary="true">Primary</SfButton>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhgCVrLWmyJUodV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Primary Button](./images/blazor-primary-button.png)" %}

### Toggle Button

A toggle Button allows you to change between the two states. The Button is active in toggled state and can be recognized through the `e-active class`. The functionality of the toggle Button is handled by [OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_OnClick) event. To create a toggle Button, set the [IsToggle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IsToggle) property to true. In the following code snippet, the toggle Button text changes to play/pause based on the state of the Button with the use of OnClick event.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-flat" IsPrimary="true" IconCss="@IconCss" Content="@Content" IsToggle="true" @onclick="OnToggleClick" @ref="ToggleBtnObj"></SfButton>

@code {
    SfButton ToggleBtnObj;
    public string IconCss = "e-icons e-play";
    public string Content = "Play";
    public void OnToggleClick()
    {
        if(ToggleBtnObj.Content == "Play")
        {
            this.Content = "Pause";
            this.IconCss = "e-icons e-pause";
        }
        else
        {
            this.Content = "Play";
            this.IconCss = "e-icons e-play";
        }
    }
}

<style>

    .e-play::before {
        content: '\e324';
    }

    .e-pause::before {
        content: '\e326';
    }

</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBAiVVrMGexGnCy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toggle Button](./images/blazor-toggle-button.png)" %}

## Icons

### Button with font icons

The Button can have an icon to provide the visual representation of the action. To place the icon on a Button, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IconCss) property to `e-icons` with the required icon CSS. By default, the icon is positioned to the left side of the Button. You can customize the icon's position by using the [IconPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IconPosition) property.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton IconCss="e-icons e-play-icon" IconPosition="IconPosition.Right">PLAY</SfButton>
<SfButton IconCss="e-icons e-pause-icon">PAUSE</SfButton>

<style>
    .e-play-icon::before {
        content: '\e324';
    }
    .e-pause-icon::before {
        content: '\e326';
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBUCVrVscdsTwUD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Button with Icon](./images/blazor-button-icon.png)" %}

## Button size

The two types of Button sizes are default and small. To change the size of the default Button to small Button, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-small`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-small">SMALL</SfButton>
<SfButton>NORMAL</SfButton>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLAWLVrWcxyVIJP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Button with different Size](./images/blazor-button-with-different-size.png)" %}