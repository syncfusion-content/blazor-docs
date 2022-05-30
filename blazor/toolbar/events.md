---
layout: post
title: Events in Blazor Toolbar Component | Syncfusion
description: Learn here all about available Toolbar Events and customizing Syncfusion Blazor Toolbar component and performing actions within it.
platform: Blazor
control: Toolbar
documentation: ug
---

# Events in Blazor Toolbar Component

In this section, the list of events of the Toolbar component have been provided which will be
triggered for appropriate Toolbar actions.

The events should be provided to the Tabs using **ToolbarEvents** tag.

## Clicked

`Clicked` event triggers after clicking the Toolbar elements.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfToolbar>
    <ToolbarEvents Clicked="ToolbarClicked">
    </ToolbarEvents>
    <ToolbarItems>
        <ToolbarItem Text="Cut" TooltipText="Cut"></ToolbarItem>
        <ToolbarItem Text="Copy" TooltipText="Copy"></ToolbarItem>
        <ToolbarItem Text="Paste" TooltipText="Paste"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>

@code{
    public void ToolbarClicked(ClickEventArgs args)
    {
        //Here you can customize your code
    }
}
```

## Created

`Created` event triggers after the Toolbar component is created.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfToolbar>
    <ToolbarEvents Created="OnCreated">
    </ToolbarEvents>
    <ToolbarItems>
        <ToolbarItem Text="Cut" TooltipText="Cut"></ToolbarItem>
        <ToolbarItem Text="Copy" TooltipText="Copy"></ToolbarItem>
        <ToolbarItem Text="Paste" TooltipText="Paste"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>

@code{
    public void OnCreated()
    {
        //Here you can customize your code
    }
}
```

## Destroyed

`Destroyed` event triggers when the Toolbar component is destroyed.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfToolbar>
    <ToolbarEvents Destroyed="OnDestroyed">
    </ToolbarEvents>
    <ToolbarItems>
        <ToolbarItem Text="Cut" TooltipText="Cut"></ToolbarItem>
        <ToolbarItem Text="Copy" TooltipText="Copy"></ToolbarItem>
        <ToolbarItem Text="Paste" TooltipText="Paste"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>

@code{
    public void OnDestroyed()
    {
        //Here you can customize your code
    }
}
```