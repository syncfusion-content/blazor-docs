---
layout: post
title: Resizing in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Resizing in Syncfusion Blazor Dialog component and much more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Resizing in Blazor Dialog Component

The [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) supports resizing feature. To resize the dialog, select and resize it by using its resize handles (grip areas) or hovering on any of the edges or borders of the dialog within the sample container. This allows users to dynamically adjust the dialog size to better accommodate content or fit their preferred viewing area.

To get started quickly with resizing in Blazor Dialog Component, Refer the video below.

{% youtube "https://www.youtube.com/watch?v=qNW5d7C2L7g" %}

## EnableResize Property

The resizable dialog can be created by setting the [EnableResize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_EnableResize) property to true, which is used to change the size of a dialog dynamically and view its content with expanded mode. When enabled, users can interact with the dialog's resize handles to modify its dimensions according to their needs.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="target">
    <div>
        <SfButton Content="Open Dialog" @onclick="@OpenDialog"></SfButton>
    </div>
    <SfDialog ID="defaultDialog" Target="#target" Width="445px" ShowCloseIcon="true" EnableResize="true" @bind-Visible="@IsVisible" Header="Resize Dialog" Content="This is a resizing dialog">
    </SfDialog>
</div>

<style>
    #target {
        height: 500px;
    }
</style>

@code {
    private bool IsVisible { get; set; } = false;

    private void OpenDialog()
    {
        this.IsVisible = true;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVoXFMaTKTKIhlV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dialog with Enabled Resize property](./images/blazor-dialog-enable-resize.gif)" %}

## ResizeHandles Property

The [ResizeHandles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_ResizeHandles) property configures the specific directions in which the dialog can be resized. Resize handles are interactive grip areas positioned on the dialog's edges and corners that users can drag to modify the dialog dimensions. When the target property is configured along with the `EnableResize` property, the dialog can be resized within its specified target container boundaries.

The ResizeDirection enum provides the following options:

* All: Enables resizing in all directions (default)
* East: Enables resizing from the right edge
* North: Enables resizing from the top edge
* NorthEast: Enables resizing from the top-right corner
* NorthWest: Enables resizing from the top-left corner
* South: Enables resizing from the bottom edge
* SouthEast: Enables resizing from the bottom-right corner
* SouthWest: Enables resizing from the bottom-left corner
* West: Enables resizing from the left edge

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="target">
    <SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

    <SfDialog Target="#target" Width="250px" EnableResize="true" ResizeHandles="@dialogResizeDirections" ShowCloseIcon="true" @bind-Visible="@IsVisible" Header="Resizable Dialog" Content="Can resize the dialog in all directions">
    </SfDialog>
</div>

<style>
    #target {
        min-height: 400px;
        height: 100%;
        position: relative;
    }
</style>

@code {
    private bool IsVisible { get; set; } = false;

    private ResizeDirection[] dialogResizeDirections { get; set; } = new ResizeDirection[] { ResizeDirection.All };

    private void OpenDialog()
    {
        this.IsVisible = true;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVytbsYpKFHCFdx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dialog with resizehandle in all direction ](./images/blazor-dialog-resizing-handles.gif)" %}

## Related Events

### OnResizeStart

The Dialog component provides several events that trigger during the resizing process, allowing developers to implement custom logic and handle resize operations programmatically.

The [OnResizeStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnResizeStart) event triggers when the user begins to resize a dialog.

### Resizing

The [Resizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_Resizing) event triggers when the user resize the dialog.

### OnResizeStop

The [OnResizeStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnResizeStop) event triggers when the user stop to resize a dialog.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups

<div id="target">
    <SfButton @onclick="@OpenDialog">Open Dialog</SfButton>

    <div style="display: grid; float: right;">
        @foreach (string evt in EventList)
        {
            <span>@evt "Event Triggered"</span>
        }
    </div>
</div>

<SfDialog Target="#target" Width="250px" EnableResize="true" @bind-Visible="@IsVisible" Content="Dialog with resize events" Header="Resize Events" ShowCloseIcon="true">
    <DialogEvents OnResizeStart="OnResizeStart" Resizing="Resizing" OnResizeStop="OnResizeStop"></DialogEvents>
</SfDialog>

@code {
    private bool IsVisible { get; set; } = false;
    private List<string> EventList = new List<string>();

    private void OpenDialog()
    {
        this.IsVisible = true;
    }

    private void OnResizeStart(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        EventList.Add("OnResizeStart");
    }

    private void Resizing(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        EventList.Add("Resizing");
    }

    private void OnResizeStop(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        EventList.Add("OnResizeStop");
    }
}

<style>
    #target {
        min-height: 400px;
        height: 100%;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVotPCOJffuhZmj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dialog with Resize Events](./images/blazor-dialog-resize-events.gif)" %}
