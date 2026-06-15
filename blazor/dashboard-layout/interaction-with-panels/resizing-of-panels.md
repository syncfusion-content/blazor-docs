---
layout: post
title: Resizing Panels in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about resizing panels in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Resizing Panels in Blazor Dashboard Layout Component

The Dashboard Layout component provides a robust panel resizing functionality that enhances user experience by allowing dynamic adjustment of panel dimensions. This feature can be enabled or disabled using the [`AllowResizing`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_AllowResizing) property, providing developers with full control over whether users can modify panel sizes through UI interactions.

Panel resizing is an essential feature in Dashboard configurations as it allows end users to customize the layout according to their preferences and data visualization needs. By default, the resizing capability is disabled, and need to explicitly enable it by setting the `AllowResizing` property to `true`. When enabled, users can drag the resize handles to adjust the width and height of individual panels within the Dashboard grid.

## Enabling Panel Resizing

To enable panel resizing in your Dashboard Layout component, set the `AllowResizing` attribute to `true` on the SfDashboardLayout component. This activates the resize handles that appear on the panel edges and corners, allowing users to modify panel dimensions by clicking and dragging these handles.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10 ,10 })" Columns="5" CellAspectRatio="2"  AllowResizing="true">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
            <ContentTemplate><div>0</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX=2 SizeY=2 Column=1>
            <ContentTemplate><div>1</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeY=2 Column=3>
            <ContentTemplate><div>2</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1>
            <ContentTemplate><div>3</div></ContentTemplate>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

<style>
    .e-panel-content {
        text-align: center;
        margin-top: 10px;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVAsBVwTABPvxgH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Resizing Panels in Blazor DashboardLayout](../images/blazor-dashboard-layout-panel-resizing.gif)" %}

## Resizable Handles Configuration

By default, when resizing is enabled, panels can only be resized in the **south-east** direction using the resize handle located at the bottom-right corner of each panel. However, Syncfusion Dashboard Layout supports resizing in multiple directions to provide greater flexibility. You can configure which resize directions are available by setting the [`ResizableHandles`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ResizableHandles) property.

The following resize directions are supported:

* **North** - Top edge resize handle
* **South** - Bottom edge resize handle
* **East** - Right edge resize handle
* **West** - Left edge resize handle
* **North-East** - Top-right corner handle
* **North-West** - Top-left corner handle
* **South-East** - Bottom-right corner handle
* **South-West** - Bottom-left corner handle

### Example: Configuring Multiple Resize Directions

The following example demonstrates how to enable resizing in the east, west, south, south-west, and south-east directions:

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10, 10})" Columns="6" CellAspectRatio="1.5" AllowResizing="true" ResizableHandles="ResizableHandle.NorthEast">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel SizeX="2" SizeY="2" Column="0" Row="0">
            <ContentTemplate>
                <div class="panel-content">Panel 1</div>
            </ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX="3" SizeY="2" Column="2" Row="0">
            <ContentTemplate>
                <div class="panel-content">Panel 2</div>
            </ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX="2" SizeY="2" Column="5" Row="0">
            <ContentTemplate>
                <div class="panel-content">Panel 3</div>
            </ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX="4" SizeY="2" Column="1" Row="2">
            <ContentTemplate>
                <div class="panel-content">Panel 4</div>
            </ContentTemplate>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

<style>
    .e-panel-content {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 100%;
        background-color: #f5f5f5;
        border: 1px solid #ddd;
    }
</style>

```

## Resize Behavior and Constraints

When implementing panel resizing, it's important to understand how the Dashboard Layout component handles resize operations:

* **Minimum Size Constraints** - Panels have minimum size constraints to ensure content remains visible and usable. The minimum size is determined by the `SizeX` and `SizeY` properties or the default minimum panel dimensions.
* **Grid-Based Resizing** - Panels resize in discrete grid increments rather than pixel-by-pixel, ensuring panels always align properly within the Dashboard grid structure.
* **Collision Handling** - When a panel is resized and overlaps with adjacent panels, the Dashboard Layout automatically repositions panels to prevent overlap and maintain grid alignment.
* **Boundary Limits** - Resizing is constrained within the Dashboard boundaries to prevent panels from being resized outside the visible area.

## Programmatically Controlling Resize Behavior

You can programmatically enable or disable resizing based on user permissions or application state by binding the `AllowResizing` property to a variable:

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10, 10})" Columns="5" CellAspectRatio="2" AllowResizing="@EnableResizing">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
            <ContentTemplate><div>Panel A</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX=2 SizeY=2 Column=1>
            <ContentTemplate><div>Panel B</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeY=2 Column=3>
            <ContentTemplate><div>Panel C</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1>
            <ContentTemplate><div>Panel D</div></ContentTemplate>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

<button @onclick="ToggleResizing">@ToggleButtonText</button>

@code {
    private bool EnableResizing { get; set; } = true;

    private string ToggleButtonText => EnableResizing ? "Disable Resizing" : "Enable Resizing";

    private void ToggleResizing()
    {
        EnableResizing = !EnableResizing;
    }
}
```

This implementation allows users to toggle the resizing functionality on and off using a button click, providing flexible control over the Dashboard interaction.

N> Initially, the panels can be resized only in south-east direction. However, panels can also be resized in east, west, north, south, and south-west directions by defining the required directions with the [`ResizableHandles`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ResizableHandles) property.