---
layout: post
title: Drag and Drop in Blazor Tabs Component | Syncfusion
description: Checkout and learn here all about drag and drop in Syncfusion Blazor Tabs component and much more details.
platform: Blazor
control: Tabs
documentation: ug
---

# Drag and Drop in Blazor Tabs Component

The [Blazor Tab](https://www.syncfusion.com/blazor-components/blazor-tabs) component allows to drag and drop any item by setting `AllowDragAndDrop` &nbsp;to **true**. Items can be reordered to any place by dragging and dropping them onto the desired location.

* If you need to prevent dragging action for a particular item, the `OnDragStart` event can be used which will trigger when the item drag is started. If you need to prevent dropping action for a particular item, the `Dragged` event can be used which will trigger when the drag action is stopped.

* The `DragArea` defines the area in which the draggable element movement will be occurring. Outside that area will be restricted for the draggable element movement.

* The `OnDragStart` event will be triggered before dragging the item from Tab.

* The `Dragged` event will be triggered when the Tab item is dropped on the target element successfully.

In the following sample, the `AllowDragAndDrop` property is enabled.

N> External drag and drop is not possible in blazor Tabs.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfTab CssClass="drag-drop-tab" AllowDragAndDrop="true">
    <TabItems>
        <TabItem Content="India officially the Republic of India, is a country in South Asia. It is the seventh-largest country by area, the second-most populous country with over 1.2 billion people, and the most populous democracy in the world. Bounded by the Indian Ocean on the south, the Arabian Sea on the south-west, and the Bay of Bengal on the south-east, it shares land borders with Pakistan to the west;China, Nepal, and Bhutan to the north-east; and Burma and Bangladesh to the east. In the Indian Ocean, India is in the vicinity of Sri Lanka and the Maldives; in addition, India Andaman and Nicobar Islands share a maritime border with Thailand and Indonesia.">
            <ChildContent>
                <TabHeader Text="India"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="Australia, officially the Commonwealth of Australia, is a country comprising the mainland of the Australian continent, the island of Tasmania and numerous smaller islands. It is the world sixth-largest country by total area. Neighboring countries include Indonesia, East Timor and Papua New Guinea to the north; the Solomon Islands, Vanuatu and New Caledonia to the north-east; and New Zealand to the south-east.">
            <ChildContent>
                <TabHeader Text="Australia"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="The United States of America (USA or U.S.A.), commonly called the United States (US or U.S.) and America, is a federal republic consisting of fifty states and a federal district. The 48 contiguous states and the federal district of Washington, D.C. are in central North America between Canada and Mexico. The state of Alaska is west of Canada and east of Russia across the Bering Strait, and the state of Hawaii is in the mid-North Pacific. The country also has five populated and nine unpopulated territories in the Pacific and the Caribbean.">
            <ChildContent>
                <TabHeader Text="USA"></TabHeader>
            </ChildContent>
        </TabItem>
        <TabItem Content="France, officially the French Republic is a sovereign state comprising territory in western Europe and several overseas regions and territories. The European part of France, called Metropolitan France, extends from the Mediterranean Sea to the English Channel and the North Sea, and from the Rhine to the Atlantic Ocean; France covers 640,679 square kilo metres and as of August 2015 has a population of 67 million, counting all the overseas departments and territories.">
            <ChildContent>
                <TabHeader Text="France"></TabHeader>
            </ChildContent>
        </TabItem>
    </TabItems>
</SfTab>

<style>
    .drag-drop-tab .e-content .e-item {
        font-size: 12px;
        padding: 10px;
        text-align: justify;
    }
</style>

 ```

![Drag and Drop Items in Blazor Tabs](./images/blazor-tabs-drag-drop-items.gif)