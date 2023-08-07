---
layout: post
title: Display a Blazor Dialog with custom position | Syncfusion
description: Learn here all about Display a Dialog with custom position in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Display a Dialog with Custom Position in Blazor Dialog Component

By default, the dialog is displayed in the center of the target container. The dialog position can be set using the `DialogPositionData` property by providing custom `X` and `Y` coordinates. The dialog can be positioned inside the target based on the given X and Y values.

```cshtml

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



![Blazor Dialog with Custom Position](../images/blazor-dialog-custom-position.png)