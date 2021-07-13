---
layout: post
title: How to Open And Close The Sidebar in Blazor Sidebar Component | Syncfusion
description: Checkout and learn about Open And Close The Sidebar in Blazor Sidebar component of Syncfusion, and more details.
platform: Blazor
control: Sidebar
documentation: ug
---

<!-- markdownlint-disable MD009 -->

# Open and close the Sidebar

Opening and closing the Sidebar can be achieved with `IsOpen` property.

In the following sample, `IsOpen` property has been used to show or hide the Sidebar on button click.

```csharp

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div id="header" style="height:45px;text-align: center;color:white;background-color:midnightblue;font-size:1.2rem;line-height:45px;">
    Header
</div>

<SfSidebar @ref="sidebarObj" Width="250px" @bind-IsOpen="SidebarToggle">
    <ChildContent>
        <div style="text-align: center;" class="text-content">
            <span>Sidebar</span>
            <span>
                <SfButton @onclick="Close" CssClass="e-btn close-btn">Close Sidebar</SfButton>
            </span>
        </div>
    </ChildContent>
</SfSidebar>

<div class="text-content" style="text-align: center;">
    <div>Main content</div>
    <div>
        <SfButton @onclick="Toggle" IsToggle="true" CssClass="e-btn e-info">Toggle Sidebar</SfButton>
    </div>
</div>

@code{
    SfSidebar sidebarObj;
    public bool SidebarToggle = false;
    public void Close()
    {
        SidebarToggle = false;
    }
    public void Toggle()
    {
        SidebarToggle = !SidebarToggle;
    }
}

<style>
    .e-sidebar {
        background-color: #f8f8f8;
        color: black;
    }

    .text-content {
        font-size: 1.5rem;
        padding: 3rem;
    }

    .main > div {
        padding: 0px !important;
    }
</style>

```

Output be like the below.

![output](./../images/open_close.png)
