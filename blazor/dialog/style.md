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

You can set the width of the dialog using the [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_Width) property.

```cshtml
<SfDialog Width="400px">
    <!-- Dialog content -->
</SfDialog>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhHjfioKoHwrfVp?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog Width](./images/dialog-customization/blazor-dialog-width.png)" %}

### MinHeight

Set the minimum height of the dialog using the [`MinHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_MinHeight) property.

```cshtml
<SfDialog MinHeight="200px">
    <!-- Dialog content -->
</SfDialog>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrRDTiyglKQXCjb?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog MinHeight](./images/dialog-customization/blazor-dialog-min-height.png)" %}

### RTL Support

Enable RTL (Right-to-Left) layout using the [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_EnableRtl) property.

```cshtml
<SfDialog EnableRtl="true">
    <!-- Dialog content -->
</SfDialog>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBxtTWeqkZUhnrA?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog RTL Support](./images/dialog-customization/blazor-dialog-rtl.png)" %}

### CssClass

Apply custom CSS classes using the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_CssClass) property.

```cshtml
<SfDialog CssClass="success-dialog"
          Width="400px"
          Header="Success"
          ShowCloseIcon="true"
          Content="Dialog header and content are customized using the CssClass property">
</SfDialog>

<style>
    .success-dialog.e-dialog {
        border-color: #22c55e;
    }

    .success-dialog .e-dlg-header {
        color: #22c55e;
    }

    .success-dialog .e-dlg-content {
        background-color: #f0fdf4;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhxtzCIffgAdyqB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog CSSClass](./images/dialog-customization/blazor-dialog-cssclass.png)" %}

### Animation

The [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) can be animated during the open and close actions. Also, users can customize animation's `Delay`, `Duration` and `Effect` by using the `DialogAnimationSettings` property.

To get started quickly with animation in Blazor Dialog Component, you can check the video below.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrHZzsITIXbwZiF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog CSSClass](./images/dialog-customization/blazor-dialog-animation.png)" %}


### Dialog background color change

Use the following CSS to customize the background color of the Dialog.

```razor
<SfDialog Width="300px"
          Header="Background Color Dialog"
          Content="This dialog demonstrates background color customization."
          ShowCloseIcon="true">
</SfDialog>

<style>
    .e-dialog .e-dlg-header-content, .e-dialog .e-dlg-content {
        background-color: #f0f9ff;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBdjpixrfIBCkXV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog background](./images/dialog-customization/blazor-dialog-background-color.png)" %}

### Dialog border customization with radius

Use the following CSS to customize the Dialog border and apply a border radius.

```razor
<SfDialog Width="300px"
          Header="Border Customized Dialog"
          Content="This dialog demonstrates border and radius customization."
          ShowCloseIcon="true">
</SfDialog>

<style>
    .e-dialog {
        border-radius: 12px;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBdXpCnBzFRaUor?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog border radius](./images/dialog-customization/blazor-dialog-border-radius.png)" %}

### Customizing the dialog header

Use the following CSS to customize the dialog header properties.

```css
.e-dialog .e-dlg-header {
    color: #22c55e;
    font-size: 20px;
    font-weight: normal;
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLxZzsITcfjlroX?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog Header](./images/dialog-customization/blazor-dialog-header.png)" %}

### Customizing the dialog content

Use the following CSS to customize the dialog content properties.

```css
.e-dialog .e-dlg-content {
    color: #f11014;
    font-size: 10px;
    font-weight: normal;
    line-height: normal;
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhRZJiSplLTsmJC?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog Content](./images/dialog-customization/blazor-dialog-content.png)" %}

### Customizing modal dialog overlay

Use the following CSS to customize the modal dialog overlay.

```css
.e-dlg-overlay {
    background-color: slategray;
    opacity: 0.6;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhnZpMSfaLApAky?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog overlay](./images/dialog-customization/blazor-dialog-overlay.png)" %}

### Customizing the dialog resize icon

Use the following CSS to customize the dialog resize icon.

```css
/* To change the resize icon color */
    .e-dialog .e-south-east::before,
    .e-dialog .e-south-west::before {
        color: red;
    }

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrdtTMxVtzhydwJ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog resize icon](./images/dialog-customization/blazor-dialog-resize-icon.png)" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVnjTCyyrIorzfn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog close button](./images/dialog-customization/blazor-dialog-closebtn.png)" %}

### Customizing the dialog footer content

Use the following CSS to customize the dialog footer content.

```css
/* To specify font color, background color and border color */
.e-dialog .e-footer-content {
        background-color: #f0fdf4;
        color: #593fed;
    }
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDrnNzsIyKGWhRFz?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dialog footer](./images/dialog-customization/blazor-dialog-footer.png)" %}