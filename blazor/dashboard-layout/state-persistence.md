---
layout: post
title: State Persistence in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn about State Persistence in Blazor Dashboard Layout component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# State Persistence in Blazor Dashboard Layout Component

In the Blazor Dashboard layout component, when utilizing the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_EnablePersistence) property, it is additionally necessary to set the [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ID) for the Blazor Dashboard Layout component. Because the data will be persisted based on the component `ID`, providing an `ID` is mandatory for persistence. However, the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_EnablePersistence) property only maintains the panel positions [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Column), [Row](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Row), width ([SizeX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeX)), and height ([SizeY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeY)) of the panels when performed on the page reloads in the Dashboard Layout component. 


```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout ID="dashboard" CellSpacing="@(new double[]{10 ,10 })" Columns="6" EnablePersistence=true>
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
    #dashboard .e-panel-header {
        background-color: rgba(0, 0, 0, .1);
        text-align: center;
    }

    #dashboard .e-panel-content {
        text-align: center;
        margin-top: 10px;
    }
</style>

```