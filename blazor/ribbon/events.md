---
layout: post
title: Events in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Events in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Events in Blazor Ribbon component

The Syncfusion Blazor Ribbon component triggers several events in response to user actions. The following events are available in the Ribbon component.

|Name|Args|Description|
|---|---|---|
|[Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_Created)|EventCallback|Triggers when the Ribbon component's rendering is fully completed.|
|[TabSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_TabSelecting)|TabSelectingEventArgs|Triggers before a tab is selected in the Ribbon component.|
|[TabSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_TabSelected)|TabSelectedEventArgs|Triggers after a tab is successfully selected in the Ribbon component.|
|[RibbonExpanding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_RibbonExpanding)|ExpandEventArgs|Triggers before the Ribbon component is expanded.|
|[RibbonCollapsing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_RibbonCollapsing)|CollapseEventArgs|Triggers before the Ribbon component is collapsed.|
|[LauncherIconClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_LauncherIconClick)|LauncherClickEventArgs|Triggers when the launcher icon in a Ribbon group is clicked.|
|[OverflowPopupOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_OverflowPopupOpening)|OverflowPopupEventArgs|Triggers before the overflow popup in the Ribbon component opens.|
|[OverflowPopupClosing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_OverflowPopupClosing)|OverflowPopupEventArgs|Triggers before the overflow popup in the Ribbon component closes.|

## How to configure Ribbon events

The events defined above are available on the [SfRibbon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html) tag directive. The following code snippet demonstrates how to configure Ribbon events.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon

<div style="width:25%">
    <SfRibbon Created="Created" TabSelecting="TabSelecting" TabSelected="TabSelected" RibbonExpanding="RibbonExpanding" RibbonCollapsing="RibbonCollapsing" LauncherIconClick="LauncherIconClick" OverflowPopupOpening="OverflowPopupOpening" OverflowPopupClosing="OverflowPopupClosing">
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button AllowedSizes="RibbonItemSize.Large">
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut"></RibbonButtonSettings>
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
    private void Created() { /* your actions here */ }

    private void TabSelecting(TabSelectingEventArgs args) { /* your actions here */ }

    private void TabSelected(TabSelectedEventArgs args) { /* your actions here */ }

    private void RibbonExpanding(ExpandEventArgs args) { /* your actions here */ }

    private void RibbonCollapsing(CollapseEventArgs args) { /* your actions here */ }

    private void LauncherIconClick(LauncherClickEventArgs args) { /* your actions here */ }

    private void OverflowPopupOpening(OverflowPopupEventArgs args) { /* your actions here */ }

    private void OverflowPopupClosing(OverflowPopupEventArgs args) { /* your actions here */ }
}

{% endhighlight %}
{% endtabs %}

> For information on events supported by built-in Ribbon items, refer to the [Ribbon Items](./items) documentation.