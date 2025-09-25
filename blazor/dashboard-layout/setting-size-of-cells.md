---
layout: post
title: Configure Grid Layout in Blazor Dashboard | Syncfusion
description: Learn here all about Configuring the Grid Layout in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Configuring the Grid Layout in Blazor Dashboard Layout Component

The **Dashboard Layout** component is built upon a grid structure, which is divided into equally sized subsections known as cells.

| **Properties** | **Description** |
| --- | --- |
| <kbd>Columns</kbd> | Specifies the total number of cells in each row. |
| <kbd>CellAspectRatio</kbd> | Specifies the height of cells to any desired size. |

## Modifying Cell Size

The size of individual grid cells can be modified to suit your design requirements using the [`Columns`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_Columns) and [`CellAspectRatio`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_CellAspectRatio) properties.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10 ,10 })" CellAspectRatio="2" Columns="5">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDrUMrBmpWKQAbtE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

In the sample above, the width of the parent element is divided into five equal cells based on the [`Columns`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_Columns) property value. The `CellAspectRatio` is set to `2`, meaning for every 100px of cell width, the height will be 50px (width / height = 2).

The following output demonstrates the effect of setting [`CellAspectRatio`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_CellAspectRatio) and [`Columns`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_Columns) properties in the Dashboard Layout:

![Changing Cell Size of Blazor Dashboard Layout](images/blazor-dashboard-layout-cell-size.png)

## Setting Cell Spacing

The spacing between individual panels in both rows and columns can be defined using the [`CellSpacing`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_CellSpacing) property. Adding spacing between panels significantly enhances layout clarity and provides a cleaner representation of your data.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{20 ,20 })" Columns="5">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLKMBhQpMKkevti?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The following output demonstrates the clear representation of data achieved by setting the `CellSpacing` property in the Dashboard Layout component:

![Blazor Dashboard Layout with Cell Spacing](images/blazor-dashboard-layout-cell-space.png)

## Graphical Representation of Grid Layout

The underlying grid structure of the Dashboard Layout is initially hidden. This grid can be made visible by enabling the [`ShowGridLines`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ShowGridLines) property. Visualizing these grid lines is particularly helpful during the initial design phase for accurately sizing and positioning panels within the layout.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{10 ,10 })" Columns="5" ShowGridLines="true">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel Column=1>
            <ContentTemplate><div>0</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeX=1 SizeY=2 Column=2>
            <ContentTemplate><div>1</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel SizeY=1 Column=3>
            <ContentTemplate><div>2</div></ContentTemplate>
        </DashboardLayoutPanel>
        <DashboardLayoutPanel Row=1 Column=3>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVKMhBQzsTMyoHg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The following output illustrates the visible gridlines, indicating the cell division of the layout, with data containers (panels) placed over these cells:

![Blazor Dashboard Layout with GridLines](images/blazor-dashboard-layout-gridlines.png)