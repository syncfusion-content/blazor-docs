---
layout: post
title: Displaying Tooltip on dynamically created target element in Blazor Tooltip Component | Syncfusion
description: Checkout and learn here all about how to enable tooltips for dynamically generated target elements in Syncfusion Blazor Tooltip component and much more.
platform: Blazor
control: Tooltip
documentation: ug
---

# Displaying Tooltip for Dynamically Created Element

The Tooltip component can be configured to display tooltip for element that are added to the DOM after the initial page load. This behavior is useful in applications where target is rendered dynamically, such as in response to user actions, API calls, or conditional logic.

Set the [`TargetContainer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html#Syncfusion_Blazor_Popups_SfTooltip_TargetContainer) property to the CSS selector of the container that holds your tooltip targets. All elements inside this container that match the Target selector will automatically show tooltips, including those added after the component is rendered—no extra setup needed

```razor
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfTooltip ID="BasicTooltip" Target="[title]" TargetContainer=".tooltip-container">
</SfTooltip>
<div class="tooltip-container">
        <span title="Static tooltip">Static Element</span>
        <SfButton @onclick="AddElement">Add Dynamic Element<SfButton>
        @if (ShowElement)
        {
            <span title="Dynamic tooltip">Dynamic Element</span>
        }
</div>

@code {
    private bool ShowElement = false;
    
    private void AddElement()
    {
        ShowElement = true;
    }
}
```

The TargetContainer property enables automatic tooltip registration for newly added elements, enhancing dynamic content interactivity.

![Blazor Tooltip with Dynamic Targets](images/dynamic-target.gif)