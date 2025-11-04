---
layout: post
title: Responsive and Adaptive Layout in Blazor Dashboard Layout | Syncfusion
description: Learn here all about Responsive and Adaptive Layout in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Responsive and Adaptive Layout in Blazor Dashboard Layout Component

The component is provided with built-in responsive support, where panels within the layout get adjusted based on their parent element's dimensions to accommodate any resolution, which relieves the burden of building responsive dashboards.

The Dashboard Layout is designed to automatically adapt with lower resolutions by transforming the entire layout into a stacked one. So that, the panels will be displayed in a vertical column. By default, whenever the screen resolution meets **600px or lower** resolutions this layout transformation occurs. This transformation can be modified for any user defined resolution by defining the [`MediaQuery`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_MediaQuery) property of the component.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{20 ,20 })" Columns="5" MediaQuery="max-width:700px">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrUsLBmpAKBpXmY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Responsive and Adaptive Layout in Blazor DashboardLayout](images/blazor-dashboard-layout-cell-space.png)

The above sample demonstrates usage of the `MediaQuery` property to turn out the layout into a stacked one in user defined resolution. Here, whenever the window size reaches 700px or lesser, the layout becomes a stacked layout.