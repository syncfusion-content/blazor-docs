---
layout: post
title: Display a Blazor Dialog with custom position | Syncfusion
description: Learn here all about Display a Dialog with custom position in Syncfusion Blazor Dialog component and more.
platform: Blazor
control: Dialog
documentation: ug
---

# Display a Dialog with Custom Position in Blazor Dialog Component

The Blazor Dialog renders in the center of its target container by default, but it can be moved to specific coordinates by supplying `DialogPositionData`. This is helpful when arranging multiple dialogs or aligning them with other layout elements inside a large container. Make sure the target element provides enough space for the specified coordinates so the Dialog remains fully visible.

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