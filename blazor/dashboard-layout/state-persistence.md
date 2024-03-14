---
layout: post
title: State Persistence in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn about State Persistence in Blazor Dashboard Layout component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# State Persistence in Blazor Dashboard Layout Component

State persistence allowed Dashboard Layout component to retain the the panel positions [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Column), [Row](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Row), width ([SizeX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeX)), and height ([SizeY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeY)) values in the [localStorage](https://www.w3schools.com/html/html5_webstorage.asp) for state maintenance even if the browser is refreshed or if you move to the next page within the browser. This action is handled through the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_EnablePersistence) property which is set to `false` by default. When it is set to `true`, the panel positions `Column`, `Row`, width (`SizeX`), and height (`SizeY`) values of the Dashboard Layout component will be retained even after refreshing the page.

N> Dashboard Layout component [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ID) is essential to set state persistence. Because the data will be persisted based on the component `ID`.

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