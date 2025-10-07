---
layout: post
title: Resizing in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Resizing in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Resizing in Blazor Ribbon component

The Ribbon dynamically adjusts item sizes when the available width changes. As space increases, items expand; as space decreases, items reduce in size. Resizing is supported in both Classic mode and Simplified mode. The sizes that an item can take during resizing can be constrained using the AllowedSizes property.

- **Classic mode**: During resizing, item sizes adjust sequentially based on the available width of the tab content in the order: Large → Medium → Small (and vice versa).
- **Simplified mode**: During resizing, item sizes adjust sequentially in the order: Medium → Small (and vice versa). In Simplified mode, the Large size is not used.

## Defining items allowed size

Use the [AllowedSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_AllowedSizes) property on a [RibbonItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html) to restrict the sizes that the item can take during resizing. When set, the item only switches among the specified sizes, regardless of overall Ribbon resizing.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<div style="width:25%">
    <SfRibbon>
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

{% endhighlight %}
{% endtabs %}

![Ribbon Item AllowedSizes](./images/ribbon_allowedSizes.png)

## Defining items active size

The [ActiveSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_ActiveSize) property on a [RibbonItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html) indicates the current size of the rendered item. By default, the value is Medium. This property is read-only and reflects the item’s current state during resizing.