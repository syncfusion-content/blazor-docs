---
layout: post
title: Style and appearance in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Dialog Customization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Dialog component allows extensive customization options to enhance its appearance and behavior. You can modify its dimensions, support RTL layouts, apply custom styles, and animate its display.

### Width

Configure the dialog width using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_Width) property. Width accepts any valid CSS length (px, %, rem, etc.), letting you define fixed or responsive layouts.

```cshtml
<SfDialog Width="400px">
    <!-- Dialog content -->
</SfDialog>
```

### MinHeight

Set the minimum height of the dialog with the [MinHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_MinHeight) property to ensure essential content remains visible even when the dialog is resized smaller.

```cshtml
<SfDialog MinHeight="200px">
    <!-- Dialog content -->
</SfDialog>
```

### RTL Support

Enable right-to-left rendering by setting [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_EnableRtl) to true. This mirrors the dialog layout for languages such as Arabic and Hebrew.

```cshtml
<SfDialog EnableRtl="true">
    <!-- Dialog content -->
</SfDialog>
```

### CssClass

Use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_CssClass) property to apply custom classes and scope style overrides specifically to the dialog instance.

```cshtml
<SfDialog CssClass="custom-dialog">
    <!-- Dialog content -->
</SfDialog>
```

### Animation

The [DialogAnimationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogAnimationSettings.html) property customizes dialog animations. Configure animation Delay, Duration, and Effect (values from the [DialogEffect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEffect.html) enum) to define how the dialog opens and closes.

To explore animation quickly, watch the following video.

{% youtube "https://www.youtube.com/watch?v=qNW5d7C2L7g" %}

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
delay</td><td>
The Dialog animation will start with the mentioned delay</td></tr>
<tr>
<td>
duration</td><td>
Specifies the animation duration to complete with one animation cycle</td></tr>
<tr>
<td>
effect</td><td>
Specifies the animation effects of Dialog open and close actions effect.
<br /><br />
List of supported animation effects:
<br />
'Fade' | 'FadeZoom' | 'FlipLeftDown' | 'FlipLeftUp' | 'FlipRightDown' | 'FlipRightUp' | 'FlipXDown' |
'FlipXUp' | 'FlipYLeft' | 'FlipYRight' | 'SlideBottom' | 'SlideLeft' | 'SlideRight' | 'SlideTop' |
'Zoom'| 'None'
<br /><br />
If the user sets 'Fade' effect, then the Dialog will open with 'FadeIn' effect and close with 'FadeOut' effect
</td></tr>
</table>

In the following sample, `Zoom` effect is enabled. So, The Dialog will open with `ZoomIn` and close with `ZoomOut` effects.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

<SfDialog Width="500px" ShowCloseIcon="true" @bind-Visible="@IsVisible">
    <DialogTemplates>
        <Header> Dialog </Header>
        <Content> Dialog enabled with Zoom effect </Content>
    </DialogTemplates>
    <DialogAnimationSettings Effect="@AnimationEffect" Duration=400 />
    <DialogButtons>
        <DialogButton Content="Hide" IsPrimary="true" OnClick="@CloseDialog" />
    </DialogButtons>
</SfDialog>

@code {
    private bool IsVisible { get; set; } = true;
    private DialogEffect AnimationEffect = DialogEffect.Zoom;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void CloseDialog()
    {
        this.IsVisible = false;
    }
}

```

### Customizing the dialog header

Use the following CSS to customize the dialog header properties.

```css
.e-dialog .e-dlg-header {
    color: green;
    font-size: 20px;
    font-weight: normal;
}
```

### Customizing the dialog content

Use the following CSS to customize the dialog content properties.

```css
.e-dialog .e-dlg-content {
    color: red;
    font-size: 10px;
    font-weight: normal;
    line-height: normal;
}
```

### Customizing modal dialog overlay

Use the following CSS to customize the modal dialog overlay.

```css
.e-dlg-overlay {
    background-color: slategray;
    opacity: 0.6;
}
```

### Customizing the dialog resize icon

Use the following CSS to customize the dialog resize icon.

```css
/* To change the icon content */
.e-dialog .e-south-east::before, .e-dialog .e-south-west::before {
    content: "\f047";
}

/* To set the icon pack */
.e-dialog .e-resize-handle {
    font: normal normal normal 14px/1 FontAwesome;
}
```

The above CSS demonstration uses the font awesome icon.

### Customizing the dialog close button

Use the following CSS to customize the dialog close button.

```css
/* To specify font size and color */
.e-dialog .e-btn .e-btn-icon.e-icon-dlg-close {
    font-size: 12px;
    color: red;
}
```

### Customizing the dialog footer button

Use the following CSS to customize the dialog footer button.

```css
/* To specify font color, background color and border color */
.e-dialog .e-btn.e-flat, .e-css.e-btn.e-flat {
    background-color: transparent;
    border-color: transparent;
    color: blue;
}
```