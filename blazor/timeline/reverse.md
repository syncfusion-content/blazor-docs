---
layout: post
title: Reverse in Blazor Timeline Component | Syncfusion
description: Checkout and learn about Reverse with Blazor Timeline component and more details.
platform: Blazor
control: Timeline
documentation: ug
---

# Reverse in Blazor Timeline component

You can display the Timeline items in reverse order, for different alignments by using the [Reverse]() property which provides adaptability and improves user interaction.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline Reverse=true Alignment=TimelineAlignment.Before>
        <TimelineItems>
            <TimelineItem>
                <Content> June 2022 </Content>
                <OppositeContent> Graduated <br/> Bachelors in Computer Engineering </OppositeContent>
            </TimelineItem>
            <TimelineItem>
                <Content> Aug 2022 </Content>
                <OppositeContent> Software Engineering Internship <br /> ABC Software and Technology </OppositeContent>
            </TimelineItem>
            <TimelineItem>
                <Content> Feb 2023 </Content>
                <OppositeContent> Associate Software Engineer <br/> ABC Software and Technology </OppositeContent>
            </TimelineItem>
            <TimelineItem>
                <Content> Mar 2024 </Content>
                <OppositeContent> Software Level 1 Engineer <br /> XYZ Solutions </OppositeContent>
            </TimelineItem>
        </TimelineItems>
    </SfTimeline>
</div>

```

![Blazor Timeline Component with Common Customized Connector](./images/Blazor-reverse.png)