---
layout: post
title: Events in Blazor Timeline Component | Syncfusion
description: Checkout and learn about Events with Blazor Timeline component and more details.
platform: Blazor
control: Timeline
documentation: ug
---

# Events in Blazor Timeline component

This section describes the TImeline events that will be triggered when an appropriate actions are performed. The following events are available in the TImeline component.

## Created

The [Created]() event is triggered when the Timeline component is created and fully initialized.

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

The [ItemRendered]() event is fired after each item is rendered in Timeline component. By utilizing this, you can modify the appearance or content of the items based on specific conditions.

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
