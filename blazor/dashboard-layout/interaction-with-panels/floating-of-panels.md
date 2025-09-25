---
layout: post
title: Floating Panels in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about Floating Panels in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Floating Panels in Blazor Dashboard Layout Component

The Dashboard Layout component includes a panel floating functionality that you can enable or disable using the [`AllowFloating`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_AllowFloating) property. When enabled, this feature ensures effective utilization of the entire layout space for panel placement. Panels within the layout will automatically float upwards to occupy any empty cells available in preceding rows, thus maintaining a compact and optimized dashboard arrangement.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10 ,10 })" Columns="5" CellAspectRatio="2"  AllowFloating="true">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBUCVrcTKrdWwSb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Floating Panels in Blazor DashboardLayout](../images/blazor-dashboard-layout-panel-resizing.gif)