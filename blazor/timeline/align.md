---
layout: post
title: Alignment in Blazor Timeline Component | Syncfusion
description: Checkout and learn here all about alignment in Syncfusion Blazor Timeline component and more details.
platform: Blazor
control: Timeline
documentation: ug
---

# Alignment in Blazor Timeline component

Control the display of timeline content using the [`Alignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfTimeline.html#Syncfusion_Blazor_Layouts_SfTimeline_Alignment) property, with options such as [`Before`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_Before), [`After`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_After), [`Alternate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_Alternate), and [`AlternateReverse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_AlternateReverse). The  [`oppositeContent`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_OppositeContent) is displayed parallel to the main content when configured within the [`TimelineItem`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html) directive.

## Before

In [`Before`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_Before) alignment, for [`horizontal`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineOrientation.html#Syncfusion_Blazor_Layouts_TimelineOrientation_Horizontal) orientation the item content is placed at the top and [`oppositeContent`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_OppositeContent) at the bottom. In [`vertical`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineOrientation.html#Syncfusion_Blazor_Layouts_TimelineOrientation_Vertical) orientation, content is placed to the left and [`oppositeContent`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_OppositeContent) to the right.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline Alignment="TimelineAlignment.Before">
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content> @item.Content </Content>
                    <OppositeContent> @item.OppositeContent </OppositeContent>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

@code {
    public class TimelineItemModel
    {
        public string Content { get; set; }
        public string OppositeContent { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "ReactJs", OppositeContent = "Owned by Facebook" },
        new TimelineItemModel() { Content = "Angular", OppositeContent = "Owned by Google" },
        new TimelineItemModel() { Content = "VueJs", OppositeContent = "Owned by Evan you" },
        new TimelineItemModel() { Content = "Svelte", OppositeContent = "Owned by Rich Harris" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrSMXMNhTCgiUvW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Timeline Component with Before Alignment](./images/Blazor-align-before.png)" %}

## After

In [`After`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_After) alignment, for [`horizontal`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineOrientation.html#Syncfusion_Blazor_Layouts_TimelineOrientation_Horizontal) orientation, item content is placed at the bottom and [`oppositeContent`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_OppositeContent) at the top. In `vertical` orientation, content is placed to the right and [`oppositeContent`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_OppositeContent) to the left.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline Alignment="TimelineAlignment.After">
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content> @item.Content </Content>
                    <OppositeContent> @item.OppositeContent </OppositeContent>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

@code {
    public class TimelineItemModel
    {
        public string Content { get; set; }
        public string OppositeContent { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "ReactJs", OppositeContent = "Owned by Facebook" },
        new TimelineItemModel() { Content = "Angular", OppositeContent = "Owned by Google" },
        new TimelineItemModel() { Content = "VueJs", OppositeContent = "Owned by Evan you" },
        new TimelineItemModel() { Content = "Svelte", OppositeContent = "Owned by Rich Harris" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBysNCtBpLrvjno?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Timeline Component with After Alignment](./images/Blazor-align-after.png)" %}

## Alternate

In [`Alternate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_Alternate) alignment, item content is arranged alternatively, regardless of the Timeline orientation.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline Alignment="TimelineAlignment.Alternate">
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content> @item.Content </Content>
                    <OppositeContent> @item.OppositeContent </OppositeContent>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

@code {
    public class TimelineItemModel
    {
        public string Content { get; set; }
        public string OppositeContent { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "ReactJs", OppositeContent = "Owned by Facebook" },
        new TimelineItemModel() { Content = "Angular", OppositeContent = "Owned by Google" },
        new TimelineItemModel() { Content = "VueJs", OppositeContent = "Owned by Evan you" },
        new TimelineItemModel() { Content = "Svelte", OppositeContent = "Owned by Rich Harris" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVIiDiDLprmoLpT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Timeline Component with Alternate Alignment](./images/Blazor-align-alternate.png)" %}

## Alternate Reverse

In [`AlternateReverse`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineAlignment.html#Syncfusion_Blazor_Layouts_TimelineAlignment_AlternateReverse) alignment, the item content are arranged in reverse alternate regardless of the Timeline orientation.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline Alignment="TimelineAlignment.AlternateReverse">
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content> @item.Content </Content>
                    <OppositeContent> @item.OppositeContent </OppositeContent>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

@code {
    public class TimelineItemModel
    {
        public string Content { get; set; }
        public string OppositeContent { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "ReactJs", OppositeContent = "Owned by Facebook" },
        new TimelineItemModel() { Content = "Angular", OppositeContent = "Owned by Google" },
        new TimelineItemModel() { Content = "VueJs", OppositeContent = "Owned by Evan you" },
        new TimelineItemModel() { Content = "Svelte", OppositeContent = "Owned by Rich Harris" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNreWNWXhzAhJPqo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Timeline Component with Alternate Reverse Alignment](./images/Blazor-align-alternatereverse.png)" %}