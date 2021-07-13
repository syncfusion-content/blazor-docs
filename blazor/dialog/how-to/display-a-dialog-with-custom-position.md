---
layout: post
title: How to Display A Dialog With Custom Position in Blazor Dialog Component | Syncfusion
description: Checkout and learn about Display A Dialog With Custom Position in Blazor Dialog component of Syncfusion, and more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Display a dialog with custom position

By default, the dialog is displayed in the center of the target container. The dialog position can be set using the `DialogPositionData` property by providing custom `X` and `Y` coordinates.
The dialog can be positioned inside the target based on the given X and Y values.

```csharp

@using Syncfusion.Blazor.Popups

<div id="target">
    <SfDialog Width="360px" Target="#target" Height="120px">
        <DialogTemplates>
            <Header> Position-01 </Header>
            <Content> The dialog is positioned at {X: 420, Y: 14} coordinates </Content>
        </DialogTemplates>
        <DialogPositionData X="420" Y="14" />
    </SfDialog>

    <SfDialog Width="360px" Target="#target" Height="120px">
        <DialogTemplates>
            <Header> Position-02 </Header>
            <Content> The dialog is positioned at {X: 420, Y: 240} coordinates </Content>
        </DialogTemplates>
        <DialogPositionData X="420" Y="240" />
    </SfDialog>
</div>

<style>
    #target {
        min-height: 400px;
    }
</style>

```

The output will be as follows.

![dialog](../images/dialog-custom-position.png)