---
layout: post
title: State Persistence in Blazor Sidebar Component | Syncfusion
description: Checkout and learn about State Persistence in Blazor Sidebar component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Sidebar
documentation: ug
---

# State Persistence in Blazor Sidebar Component

State persistence enables the Sidebar component to retain its [`IsOpen`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfSidebar.html#Syncfusion_Blazor_Navigations_SfSidebar_IsOpen) property value in [`localStorage`](https://www.w3schools.com/html/html5_webstorage.asp), thereby maintaining its state even after a browser refresh or navigation to a different page.

This behavior is controlled by the [`EnablePersistence`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfSidebar.html#Syncfusion_Blazor_Navigations_SfSidebar_EnablePersistence) property, which is set to **false** by default. When set to **true**, the [`IsOpen`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfSidebar.html#Syncfusion_Blazor_Navigations_SfSidebar_IsOpen) property value of the Sidebar component will be retained even after a page refresh.

N> The Sidebar component's [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfSidebar.html#Syncfusion_Blazor_Navigations_SfSidebar_ID) is essential for enabling state persistence, as the persisted data is stored and retrieved based on the component's [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfSidebar.html#Syncfusion_Blazor_Navigations_SfSidebar_ID).

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfSidebar @ref="sidebarObj" ID="Sidebar" Type=SidebarType.Push Width="280px" @bind-IsOpen="SidebarToggle" Target=".maincontent" EnablePersistence="true">
    <ChildContent>
        <div style="text-align: center;" class="text-content">Sidebar</div>
    </ChildContent>
</SfSidebar>

<div id="head">
    <SfAppBar>
        <SfButton class="e-icons e-menu" OnClick="Toggle"></SfButton>
    </SfAppBar>
</div>

<div class="maincontent text-content" style="text-align: center;"><div>Main Content</div></div>

@code {
    SfSidebar sidebarObj;
    public bool SidebarToggle = false;
    public void Toggle()
    {
        SidebarToggle = !SidebarToggle;
    }
}

<style>
    .maincontent {
        height: 665px;
    }
</style>

```
