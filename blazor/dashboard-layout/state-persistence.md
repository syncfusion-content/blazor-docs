---
layout: post
title: State Persistence in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn about State Persistence in Blazor Dashboard Layout component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# State Persistence in Blazor Dashboard Layout Component

State persistence allows users to save and restore the layout of the Blazor Dashboard Layout component. This feature ensures that custom panel positions, sizes, and arrangements remain intact even after a page refresh or navigating away and returning, providing a consistent user experience.

## Enabling Persistence in Dashboard Layout

State persistence allowed Dashboard Layout component to retain the panel positions [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Column), [Row](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Row), width ([SizeX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeX)), and height ([SizeY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_SizeY)) values in the [localStorage](https://www.w3schools.com/html/html5_webstorage.asp) for state maintenance even if the browser is refreshed or if you move to the next page within the browser. This action is handled through the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_EnablePersistence) property which is set to `false` by default. When it is set to `true`, the panel positions `Column`, `Row`, width (`SizeX`), and height (`SizeY`) values of the Dashboard Layout component will be retained even after refreshing the page.

N> The Dashboard Layout component's [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ID) is crucial for state persistence, as data is stored and retrieved based on this unique identifier.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhoNuhoTaPLpvwa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The following output demonstrates the use of `HeaderTemplate` and `ContentTemplate` to define the header and content of panels:

![Blazor Dashboard Layout.](/images/blazor-admin-template-layout-with-header.png)

## Handling Blazor Dashboard Layout State Manually

The Blazor Dashboard Layout component provides built-in methods to manage its state explicitly, allowing you to save, load, and reset panel configurations programmatically based on user interactions or application logic.

*   [`GetPersistDataAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_GetPersistDataAsync): This method retrieves the current state of the Dashboard Layout as a string. The string format makes it suitable for storage in a database, a file, or for transmission over a network.
*   [`SetPersistDataAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_SetPersistDataAsync): Use this method to restore a previously saved Dashboard Layout state by passing the state string obtained from `GetPersistDataAsync`.
*   [`ResetPersistDataAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_ResetPersistDataAsync): This method resets the Dashboard Layout state to its original, default configuration. It also clears any persisted data from the browser's local storage for that component.

```cshtml

@using Syncfusion.Blazor.Layouts
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="SaveState">Save State</SfButton>
<SfButton OnClick="SetState">Set State</SfButton>
<SfButton OnClick="ResetState">Reset State</SfButton>

<SfDashboardLayout @ref="dashboardObject" ID="dashboard" CellSpacing="@(new double[]{10 ,10 })" Columns="6" EnablePersistence="true" >
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

@code {
    
    SfDashboardLayout? dashboardObject;
    public string _state;
    
    private async Task SaveState()
    {
        if (dashboardObject != null)
        {
            _state = await dashboardObject.GetPersistDataAsync();
        }
    }
    private async Task SetState()
    {
        if (dashboardObject != null)
        {
            await dashboardObject.SetPersistDataAsync(_state);

        }
    }
    private async Task ResetState()
    {
        if (dashboardObject != null)
        {
            await dashboardObject.ResetPersistDataAsync();

        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVyZkBIfEuZVDNy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Dashboard Layout.](/images/presistence-sample.png)