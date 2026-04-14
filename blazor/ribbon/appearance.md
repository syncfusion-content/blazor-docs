---
layout: post
title: Style and Appearance in Blazor Ribbon Component | Syncfusion
description: Learn to configure Style and Appearance properties, dimensions, layout modes, minimization, and custom styling in Syncfusion Blazor Ribbon.
platform: Blazor
control: Ribbon
documentation: ug
---

# Style and Appearance in Blazor Ribbon Component

The Ribbon component provides several properties to customize its visual appearance, allowing control over dimensions, layout modes, styling, and behavior.

## Setting width

Specify the width for the Ribbon component using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_Width) property.

```cshtml
@using Syncfusion.Blazor.Ribbon

<SfRibbon Width="100%"></SfRibbon>

@* Or with specific pixel values *@
<SfRibbon Width="800px"></SfRibbon>
```

## Changing layout modes

Use the [ActiveLayout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_ActiveLayout) property to switch between different layout modes. The Ribbon supports two layout types:

- **Classic**: Displays tabs and groups in a traditional multi-row format
- **Simplified**: Displays all ribbon items in a single row for a more compact appearance

```cshtml
@using Syncfusion.Blazor.Ribbon

<SfRibbon ActiveLayout="@RibbonLayout.Classic"></SfRibbon>

@* Or use simplified layout *@
<SfRibbon ActiveLayout="@RibbonLayout.Simplified"></SfRibbon>
```

## Setting minimized mode

Use the [IsMinimized](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_IsMinimized) property to minimize or collapse the Ribbon. When set to `true`, the ribbon collapses to show only tabs, saving screen space while keeping tab navigation accessible. Users can expand the ribbon by clicking on a tab.

```cshtml
@using Syncfusion.Blazor.Ribbon

<SfRibbon IsMinimized="true"></SfRibbon>
```

## Customization using CSS class

Use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_CssClass) property to customize the appearance of the Ribbon component with custom styles.

```cshtml
@using Syncfusion.Blazor.Ribbon

<SfRibbon Width="100%" CssClass="custom-ribbon-theme"></SfRibbon>
```

The following example demonstrates the usage of [ActiveLayout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_ActiveLayout), [IsMinimized](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_IsMinimized), and [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_CssClass) properties.

```cshtml
@using Syncfusion.Blazor.Ribbon
@using Syncfusion.Blazor.SplitButtons

<div style="width:60%">
    <SfRibbon ActiveLayout="RibbonLayout.Classic" IsMinimized="false" CssClass="custom-ribbon">
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton>
                                        <RibbonSplitButtonSettings Content="Paste" IconCss="e-icons e-paste" Items="@formatItems"></RibbonSplitButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Copy" IconCss="e-icons e-copy"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Format Painter" IconCss="e-icons e-format-painter"></RibbonButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {
    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
    {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
    };
}

<style>
    .custom-ribbon {
        border-bottom: 2px solid #007bff;
        background-color: #f8f9fa;
    }
</style>
```