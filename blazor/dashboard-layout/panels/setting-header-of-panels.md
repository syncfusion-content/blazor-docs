---
layout: post
title: Header and Content in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about Header and Content in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Header and Content Templates in Blazor Dashboard Layout Component

The Blazor Dashboard Layout component utilizes two primary templates for rendering data within its panels:

* [`ContentTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_ContentTemplate): Used to render data or any HTML structure as the main content of a panel.
* [`HeaderTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_HeaderTemplate): Enables the display of a word or phrase that summarizes the panel's content, positioned at the top of each panel.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10 ,10 })" Columns="5">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
            <HeaderTemplate><div>Panel 0</div></HeaderTemplate>
            <ContentTemplate><div>Panel Content</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX=2 SizeY=2 Column=1>
            <HeaderTemplate><div>Panel 1</div></HeaderTemplate>
            <ContentTemplate><div>Panel Content</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeY=2 Column=3>
            <HeaderTemplate><div>Panel 2</div></HeaderTemplate>
            <ContentTemplate><div>Panel Content</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1>
            <HeaderTemplate><div>Panel 3</div></HeaderTemplate>
            <ContentTemplate><div>Panel Content</div></ContentTemplate>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

<style>
    .e-panel-header {
        background-color: rgba(0, 0, 0, .1);
        text-align: center;
    }
    .e-panel-content {
        text-align: center;
        margin-top: 10px;
    }
</style>

```
The following output demonstrates the use of `HeaderTemplate` and `ContentTemplate` to define the header and content of panels:

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLAMVLGpBoyKHBy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dashboard Layout with Header.](images/blazor-admin-template-layout-with-header.png)" %}
