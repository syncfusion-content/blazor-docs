---
layout: post
title: Add Toggle Button in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to add toggle button in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Add Toggle Button in Blazor Toolbar Component

Toolbar supports adding a toggle button by using the `Template` property.

* By using Toolbar template property, pass required HTML String to render the toggle button.

```cshtml
<Template>
    <SfButton></SfButton>
</Template>
```

* Now render the toggle Button into the targeted element in the Toolbar created event handler and bind click event for it.
On clicking the toggle Button, change the required icon and content based on current active state.

```csharp

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfToolbar>
    <ToolbarItems>
        <ToolbarItem>
            <Template>
                <div><SfButton @ref="MediaButton" CssClass="e-flat" IconCss="@MediaIconCss" IsToggle="true" @onclick="@OnMediaClick"></SfButton></div>
            </Template>
        </ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem>
            <Template>
                <div><SfButton @ref="ZoomButton" CssClass="e-flat" IconCss="@ZoomIconCss" IsToggle="true" @onclick="@OnZoomClick"></SfButton></div>
            </Template>
        </ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem>
            <Template>
                <div><SfButton @ref="UndoButton" CssClass="e-flat" IconCss="@UndoIconCss" IsToggle="true" @onclick="@OnUndoClick"></SfButton></div>
            </Template>
        </ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem>
            <Template>
                <div><SfButton @ref="FilterButton" CssClass="e-flat" IconCss="@FilterIconCss" IsToggle="true" @onclick="@OnFilterClick"></SfButton></div>
            </Template>
        </ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem>
            <Template>
                <div><SfButton @ref="VisibleButton" CssClass="e-flat" IconCss="@VisibleIconCss" IsToggle="true" Content="@Content" @onclick="@OnVisibleClick"></SfButton></div>
            </Template>
        </ToolbarItem>
    </ToolbarItems>
</SfToolbar>
<br />
<div id="content" style="display:@DisplayValue">
    This content will be hidden, when you click on hide button and toggle will get an active state as shown, otherwise it will be visible.
</div>

<style>
    @@font-face {
        font-family: 'Toolbar';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    .e-toolbar .e-btn .e-icons {
        font-family: 'Toolbar' !important;
        font-size: 16px;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
    }

    .e-hide-icon::before {
        content: '\a701';
    }

    .e-show-icon::before {
        content: '\a700';
    }

    .e-filter-icon::before {
        content: '\a709';
    }

    .e-filternone-icon::before {
        content: '\a708';
    }

    .e-undo-icon::before {
        content: '\a706';
    }

    .e-redo-icon::before {
        content: '\a707';
    }

    .e-play-icon::before {
        content: '\a704';
    }

    .e-pause-icon::before {
        content: '\a705';
    }

    .e-zoomin-icon::before {
        content: '\a702';
    }

    .e-zoomout-icon::before {
        content: '\a703';
    }
</style>

@code{
    SfButton MediaButton;
    SfButton ZoomButton;
    SfButton UndoButton;
    SfButton FilterButton;
    SfButton VisibleButton;
    public string Content = "Hide";
    public string DisplayValue { get; set; } = "block";
    public string MediaIconCss = "e-icons e-play-icon";
    public string ZoomIconCss = "e-icons e-zoomin-icon";
    public string UndoIconCss = "e-icons e-undo-icon";
    public string FilterIconCss = "e-icons e-filter-icon";
    public string VisibleIconCss = "e-icons e-hide-icon";
    public void OnMediaClick(MouseEventArgs args)
    {
        if (MediaButton.IconCss == "e-icons e-play-icon")
        {
            MediaIconCss = "e-icons e-pause-icon";
        }
        else
        {
            MediaIconCss = "e-icons e-play-icon";
        }
    }

    public void OnZoomClick(MouseEventArgs args)
    {
        if (ZoomButton.IconCss == "e-icons e-zoomin-icon")
        {
            ZoomIconCss = "e-icons e-zoomout-icon";
        }
        else
        {
            ZoomIconCss = "e-icons e-zoomin-icon";
        }
    }

    public void OnUndoClick(MouseEventArgs args)
    {
        if (UndoButton.IconCss == "e-icons e-undo-icon")
        {
            UndoIconCss = "e-icons e-redo-icon";
        }
        else
        {
            UndoIconCss = "e-icons e-undo-icon";
        }
    }

    public void OnFilterClick(MouseEventArgs args)
    {
        if (FilterButton.IconCss == "e-icons e-filter-icon")
        {
            FilterIconCss = "e-icons e-filternone-icon";
        }
        else
        {
            FilterIconCss = "e-icons e-filter-icon";
        }
    }

    public void OnVisibleClick(MouseEventArgs args)
    {
        if (VisibleButton.Content == "Hide")
        {
            DisplayValue = "none";
            Content = "Show";
            VisibleIconCss = "e-icons e-show-icon";
        }
        else
        {
            DisplayValue = "block";
            Content = "Hide";
            VisibleIconCss = "e-icons e-hide-icon";
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLSWXsZqaepVhRz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Toolbar Item with Toggle Button](../images/blazor-toolbar-item-with-toggle-button.gif)