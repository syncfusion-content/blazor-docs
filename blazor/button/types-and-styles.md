---
layout: post
title: Types and Styles in Blazor Button | Syncfusion®
description: Choose the Blazor Button style and type (primary, outline, flat, toggle, icon, or rounded) to match the action and visual hierarchy of your UI.
platform: Blazor
control: Button
documentation: ug
---

# Types and Styles in Blazor Button

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZhxDxMVVgeLgsiF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Button Component with different Styles](./images/blazor-button-with-different-style.webp)" %}

N> Predefined Button styles provide only a visual indication; therefore, define the Button content to convey meaning to assistive technology users such as screen readers.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVxXRiVhUSIxYKT?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Button with different Types](./images/blazor-button-types.webp)" %}

### Primary Button

The primary button is styled with background color and it is used to represent a primary action. To create a Primary Button, set the [IsPrimary](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IsPrimary) property to `true`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton IsPrimary="true">Primary</SfButton>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVdtxiLhUevkqAx?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Primary Button](./images/blazor-primary-button.webp)" %}

### Toggle Button

A Toggle Button allows you to toggle between two states. The Button is active in the toggled state and can be recognized through the `e-active` CSS class. The functionality of the Toggle Button is handled by the [`@onclick`](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling) event. To create a Toggle Button, set the [IsToggle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IsToggle) property to `true`. In the following code snippet, the Toggle Button text changes to Play/Pause based on the state of the Button.

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
        content: '\e70c';
    }

    .e-pause::before {
        content: '\e326';
    }

</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVHDHCLLAdhgrHC?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Toggle Button](./images/blazor-toggle-button.webp)" %}

## Icons

### Button with font icons

The Button can have an icon to provide the visual representation of the action. To place the icon on a Button, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IconCss) property to `e-icons` with the required icon CSS. By default, the icon is positioned to the left side of the Button. You can customize the icon's position by using the [IconPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IconPosition) property.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton IconCss="e-icons e-play-icon" IconPosition="IconPosition.Right">PLAY</SfButton>
<SfButton IconCss="e-icons e-pause-icon">PAUSE</SfButton>

<style>
    .e-play-icon::before {
        content: '\e70c';
    }
    .e-pause-icon::before {
        content: '\e77b';
    }
</style>
```

The [`IconPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IconPosition) property accepts the following values from the [`IconPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_IconPosition) enum:

* `Left` - Places the icon to the left of the Button content (default).
* `Right` - Places the icon to the right of the Button content.
* `Top` - Places the icon above the Button content.
* `Bottom` - Places the icon below the Button content.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrHDRCFrVtZElQa?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Button with Icon](./images/blazor-button-icon.webp)" %}

## Button size

The two types of Button sizes are default and small. To change the size of the default Button to a small Button, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-small`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-small">SMALL</SfButton>
<SfButton>NORMAL</SfButton>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrdNdMLLUHbxlMP?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Button with different Size](./images/blazor-button-with-different-size.webp)" %}

## See also

* [Styles and Appearances in Blazor Button](style-and-appearance.md)
* [Native Events in Blazor Button](native-event.md)
* [Accessibility in Blazor Button](accessibility.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)