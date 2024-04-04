---
layout: post
title: Events in Blazor Timeline Component | Syncfusion
description: Checkout and learn here all about events section in Syncfusion Blazor Timeline component and more details.
platform: Blazor
control: Timeline
documentation: ug
---

# Events in Blazor Timeline component

This section describes the Timeline events that will be triggered when an appropriate actions are performed. The following events are available in the TImeline component.

## Created

The Timeline component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfTimeline.html#Syncfusion_Blazor_Layouts_SfTimeline_Created) event when the component rendering is completed.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline Created="TimelineCreated">
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content> @item.Content </Content>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

@code {
    public void TimelineCreated()
    {
        // Here, you can customize your code.
    }
    public class TimelineItemModel
    {
        public string Content { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "Planning" },
        new TimelineItemModel() { Content = "Developing" },
        new TimelineItemModel() { Content = "Testing" },
        new TimelineItemModel() { Content = "Launch" }
    };
}

```

## ItemRendered

The Timeline component triggers the [ItemRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.SfTimeline.html#Syncfusion_Blazor_Layouts_SfTimeline_ItemRendered) event after rendering each item.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline ItemRendered="TimelineItemRendered">
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content> @item.Content </Content>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

@code {
    public void TimelineItemRendered(TimelineRenderedEventArgs args)
    {
        // Here, you can customize your code.
    }
    public class TimelineItemModel
    {
        public string Content { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "Planning" },
        new TimelineItemModel() { Content = "Developing" },
        new TimelineItemModel() { Content = "Testing" },
        new TimelineItemModel() { Content = "Launch" }
    };
}

```
