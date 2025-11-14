---
layout: post
title: Size and Position in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about size and position in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Size and Position of Panels in Blazor Dashboard Layout Component

Panels are fundamental building blocks within the Blazor Dashboard Layout component, serving as containers for data visualization and presentation.

Panels are fundamental building blocks within the Blazor Dashboard Layout component, serving as containers for data visualization and presentation.

| **Panel Property** | **Default Value** | **Description** |
| --- | --- | --- |
| <kbd>Id</kbd> | null | Specifies the ID value of the panel. |
| <kbd>Row</kbd> | 0 | Specifies the row value in which the panel to be placed. |
| <kbd>Column</kbd> | 0 | Specifies the column value in which the panel to be placed. |
| <kbd>SizeX</kbd> | 1 | Specifies the width of the panel in cells count. |
| <kbd>SizeY</kbd> | 1 | Specifies the height of the panel in cells count. |
| <kbd>MinSizeX</kbd> | 1 | Specifies the minimum width of the panel in cells count. |
| <kbd>MinSizeY</kbd> | 1 | Specifies the minimum height of the panel in cells count. |
| <kbd>MaxSizeX</kbd> | null | Specifies the maximum width of the panel in cells count. |
| <kbd>MaxSizeY</kbd> |  null | Specifies the maximum height of the panel in cells count. |
| <kbd>HeaderTemplate</kbd> | null | Specifies the header template of the panel. |
| <kbd>ContentTemplate</kbd> | null | Specifies the content template of the panel. |
| <kbd>CssClass</kbd> | null | Specifies the CSS class name that can be appended with each panel element.|

## Positioning of Panels

Panels within the layout can be precisely positioned and ordered using the [`Row`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Row) and [`Column`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Column) properties of each `DashboardLayoutPanel`. This capability is essential for arranging data in any desired layout or order.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{20 ,20 })" Columns="4">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
            <ContentTemplate><div>1</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel  Column=1>
            <ContentTemplate><div>2</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Column=2>
            <ContentTemplate><div>3</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1>
            <ContentTemplate><div>4</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1 Column=1>
            <ContentTemplate><div>5</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1 Column=2>
            <ContentTemplate><div>6</div></ContentTemplate>
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

The following screenshot illustrates panel positioning within the Dashboard Layout, utilizing the `Row` and `Column` properties:

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVgMhrwzVWhKSrw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Panels Position in Blazor DashBoard Layout](../images/blazor-dashboard-layout-panel-position.png)" %}

## Sizing of Panels

A panel's size can be easily adjusted by defining its [`SizeX`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeX) and [`SizeY`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeY) properties.

* `SizeX`: Defines the width of a panel in cells count.
* `SizeY`: Defines the height of a panel in cells count.

These properties are invaluable when designing dashboards where the content and layout of each panel may vary significantly in size, allowing for flexible and responsive designs.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10 ,10 })" Columns="5">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
            <ContentTemplate><div>0</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX=2 Column=1>
            <ContentTemplate><div>1</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeY=2 Column=3>
            <ContentTemplate><div>2</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1>
            <ContentTemplate><div>3</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1 Column=1>
            <ContentTemplate><div>4</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1 Column=2>
            <ContentTemplate><div>5</div></ContentTemplate>
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

The following screenshot demonstrates the sizing of panels within the Dashboard Layout, using the `SizeX` and `SizeY` properties:

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLKMLhcprCIqVxL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Panel Size in Blazor Dashboard Layout](../images/blazor-admin-template-layout-panel-size.png)" %}