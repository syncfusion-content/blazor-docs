---
layout: post
title: Orientations in Blazor Timeline Component | Syncfusion
description: Checkout and learn about Orientations with Blazor Timeline component and more details.
platform: Blazor
control: Timeline
documentation: ug
---

# Orientations in Blazor Timeline component

The Timeline component supports the display of items in both horizontal and vertical direction by using the [Orientation]().

## Vertical

You can display the items one below the other vertically by setting the [Orientation]() property to `Vertical`. By default, the items are displayed in vertical orientation.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline Orientation=TimelineOrientation.Vertical>
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content>
                        @item.Content
                    </Content>
                    <OppositeContent>
                        @item.OppositeContent
                    </OppositeContent>
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
        new TimelineItemModel() { Content = "Day 1, 4:00 PM", OppositeContent = "Check-in and campsite visit" },
        new TimelineItemModel() { Content = "Day 1, 7:00 PM", OppositeContent = "Dinner with music" },
        new TimelineItemModel() { Content = "Day 2, 5:30 AM", OppositeContent = "Sunrise between mountains" },
        new TimelineItemModel() { Content = "Day 2, 8:00 AM", OppositeContent = "Breakfast and check-out" }
    };
}

```

![Blazor Timeline Component with Vertical Orientation](./images/Blazor-orientation-vertical.png)

## Horizontal

In horizontal orientation, the items are displayed in a side-by-side manner by setting the [Orientation]() property to `Horizontal`.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container">
    <SfTimeline Orientation=TimelineOrientation.Horizontal>
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem>
                    <Content>
                        @item.Content
                    </Content>
                    <OppositeContent>
                        @item.OppositeContent
                    </OppositeContent>
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
        new TimelineItemModel() { Content = "Day 1, 4:00 PM", OppositeContent = "Check-in and campsite visit" },
        new TimelineItemModel() { Content = "Day 1, 7:00 PM", OppositeContent = "Dinner with music" },
        new TimelineItemModel() { Content = "Day 2, 5:30 AM", OppositeContent = "Sunrise between mountains" },
        new TimelineItemModel() { Content = "Day 2, 8:00 AM", OppositeContent = "Breakfast and check-out" }
    };
}

```

![Blazor Timeline Component with Horizontal Orientation](./images/Blazor-orientation-horizontal.png)
