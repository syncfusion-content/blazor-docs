---
layout: post
title: Floating Panels in Blazor Dashboard Layout Component | Syncfusion®
description: Checkout and learn here all about floating panels in Blazor Dashboard Layout component and dynamically enabling or disabling the floating behavior.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Floating Panels in Blazor Dashboard Layout Component

The Dashboard Layout component provides panel floating functionality through the [`AllowFloating`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfDashboardLayout.html#Syncfusion_Blazor_Layouts_SfDashboardLayout_AllowFloating) property. When the property is enabled, panels automatically move upward to occupy any available empty cells in preceding rows. This behavior helps utilize the available Dashboard space efficiently and maintains a compact layout arrangement.

When the property is disabled, panels retain their configured row and column positions, even if empty cells are available above them.

## Floating Behavior

### AllowFloating is Enabled

When the `AllowFloating` property is set to `true`, panels automatically float upward and occupy vacant spaces in the previous rows. This minimizes unused space and optimizes the overall Dashboard layout.

### AllowFloating is Disabled

When the `AllowFloating` property is set to `false`, panels remain fixed in their assigned positions and do not move to fill empty spaces. This preserves the original panel arrangement within the Dashboard.

## Basic Example

The following example demonstrates how to disable the floating behavior using the `AllowFloating` property:

```cshtml
@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[] { 10, 10 })"
                   Columns="5"
                   CellAspectRatio="2"
                   AllowFloating="false">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel SizeX="1" SizeY="1" Row="0" Column="0">
            <ContentTemplate>
                <div>0</div>
            </ContentTemplate>
        </DashboardLayoutPanel>

        <DashboardLayoutPanel SizeX="2" SizeY="2" Row="1" Column="1">
            <ContentTemplate>
                <div>1</div>
            </ContentTemplate>
        </DashboardLayoutPanel>

        <DashboardLayoutPanel SizeX="1" SizeY="2" Row="0" Column="3">
            <ContentTemplate>
                <div>2</div>
            </ContentTemplate>
        </DashboardLayoutPanel>

        <DashboardLayoutPanel SizeX="1" SizeY="1" Row="1" Column="0">
            <ContentTemplate>
                <div>3</div>
            </ContentTemplate>
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

## Dynamically Enable or Disable Floating

You can dynamically change the floating behavior at runtime by binding the `AllowFloating` property to a Boolean variable. In the following example, a button is used to toggle the floating functionality.

```cshtml
@using Syncfusion.Blazor.Layouts

<button @onclick="ToggleFloating"
        class="btn btn-primary"
        style="margin-bottom:15px;">
    Toggle Floating (@allowFloating)
</button>

<SfDashboardLayout @key="allowFloating"
                   CellSpacing="@(new double[] { 10, 10 })"
                   Columns="5"
                   CellAspectRatio="2"
                   AllowFloating="@allowFloating">
    <DashboardLayoutPanels>
        <DashboardLayoutPanel SizeX="1" SizeY="1" Row="0" Column="0">
            <ContentTemplate>
                <div>0</div>
            </ContentTemplate>
        </DashboardLayoutPanel>

        <DashboardLayoutPanel SizeX="2" SizeY="2" Row="1" Column="1">
            <ContentTemplate>
                <div>1</div>
            </ContentTemplate>
        </DashboardLayoutPanel>

        <DashboardLayoutPanel SizeX="1" SizeY="2" Row="0" Column="3">
            <ContentTemplate>
                <div>2</div>
            </ContentTemplate>
        </DashboardLayoutPanel>

        <DashboardLayoutPanel SizeX="1" SizeY="1" Row="1" Column="0">
            <ContentTemplate>
                <div>3</div>
            </ContentTemplate>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

@code {
    private bool allowFloating = false;

    private void ToggleFloating()
    {
        allowFloating = !allowFloating;
    }
}

<style>
    .e-panel-content {
        text-align: center;
        margin-top: 10px;
    }
</style>
```

> **Note:** When updating the `AllowFloating` property dynamically, use the `@key` directive to recreate the Dashboard Layout component and ensure that the floating behavior is refreshed correctly.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBnjwWQqQWJHsVj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}
