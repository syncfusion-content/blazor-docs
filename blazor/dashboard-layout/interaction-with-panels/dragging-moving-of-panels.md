---
layout: post
title: Drag and Drop in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about Drag and Drop in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Drag and Drop in Blazor Dashboard Layout Component

The Dashboard Layout component is provided with dragging functionality to drag and reorder the panels within the layout. While dragging a panel, a holder will be highlighted below the panel indicating the panel placement on panel drop. This helps the users to decide whether to place the panel in the current position or revert to previous position without disturbing the layout.

If one or more panels collide while dragging, then the colliding panels will be pushed towards left, right, top, or bottom direction where an adaptive space for the collided panel is available. The position changes of these collided panels will be updated dynamically during dragging of a panel, so the users can conclude whether to place the panel in the current position or not.

N> The complete panel will act as the handler for dragging the panel such that the dragging action occurs on clicking anywhere over a panel.

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

The above sample demonstrates dragging and pushing of panels. For example, while dragging the panel 0 over panel 1, these panels get collided and push the panel 1 towards the feasible direction, so that, the panel 0 gets placed in the panel 1 position.

The following output demonstrates the dragging functionality of dashboard component.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBeMsigAIcgTaPQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Drag and Drop Panels in Blazor DashboardLayout](../images/blazor-dashboard-layout-drag-and-drop.gif)" %}

## Customizing the dragging handler

The dragging handler for the panels can be customized using the [`DraggableHandle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_DraggableHandle) property to restrict the dragging action within a particular element in the panel.

```cshtml

@using Syncfusion.Blazor.Layouts

    <SfDashboardLayout CellSpacing="@(new double[]{10 ,10 })" CellAspectRatio="2" Columns="5" DraggableHandle=".e-panel-header">
        <DashboardLayoutPanels>
            <DashboardLayoutPanel>
                <HeaderTemplate><div>Panel 1</div></HeaderTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel SizeX=2 SizeY=2 Column=1>
                <HeaderTemplate><div>Panel 2</div></HeaderTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel SizeY=2 Column=3>
                <HeaderTemplate><div>Panel 3</div></HeaderTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Row=1>
                <HeaderTemplate><div>Panel 4</div></HeaderTemplate>
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

The following output demonstrates customizing the dragging handler of the panels, where the dragging action of panel occurs only with the header of the panel.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLyiMsUAeyvtIeu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5 backgroundimage "[Customizing Dragging Handler of Panels in Blazor DashboardLayout](../images/blazor-dashboard-layout-drag-handler-of-panels.gif)" %}