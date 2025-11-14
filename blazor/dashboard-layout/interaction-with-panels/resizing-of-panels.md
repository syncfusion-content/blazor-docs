---
layout: post
title: Resizing Panels in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about resizing panels in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Resizing Panels in Blazor Dashboard Layout Component

The Dashboard Layout component provides panel resizing functionality, which can be enabled or disabled using the [`AllowResizing`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_AllowResizing) property. This feature allows users to dynamically adjust panel dimensions through UI interactions using various resizing handlers.

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

N> Initially, the panels can be resized only in south-east direction. However, panels can also be resized in east, west, north, south, and south-west directions by defining the required directions with the [`ResizableHandles`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ResizableHandles) property.