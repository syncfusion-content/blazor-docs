---
layout: post
title: Alignment in Blazor Timeline Component | Syncfusion
description: Checkout and learn about Alignment with Blazor Timeline component and more details.
platform: Blazor
control: Timeline
documentation: ug
---

# Alignment in Blazor Timeline component

The [Alignment]() property in the Timeline component determines how item content is positioned relative to each other within the timeline. The available values are `Before`, `After`, `Alternate` and `AlternateReverse`.

## Before

The `Before` alignment places item content at the top and opposite content at the bottom in `horizontal` orientation whereas in `vertical`, it positions content to the left and opposite content to the right.

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

![Blazor Timeline Component with Before Alignment](./images/Blazor-align-before.png)

## After

The `After` alignment places item content at the bottom and opposite content at the top in `horizontal` orientation whereas in `vertical`, it positions content to the right and opposite content to the left.

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

![Blazor Timeline Component with After Alignment](./images/Blazor-align-after.png)

## Alternate

The `Alternate` option positions item content in an alternating manner where items are arranged in a back-and-forth pattern, regardless of the Timeline's orientation.

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

![Blazor Timeline Component with Alternate Alignment](./images/Blazor-align-alternate.png)

## Alternate reverse

The `AlternateReverse` option organizes item content in a reverse alternating style providing an alternative method for displaying timeline items, regardless of the Timeline's orientation.

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

![Blazor Timeline Component with Alternate Reverse Alignment](./images/Blazor-align-alternatereverse.png)