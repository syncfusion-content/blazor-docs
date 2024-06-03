---
layout: post
title: Items in Blazor Timeline Component | Syncfusion
description: Checkout and learn here all about items and how to configure action items in Syncfusion Timeline component and much more.
platform: Blazor
control: Timeline
documentation: ug
---

# Items in Blazor Timeline component

The Timeline items can be added by using the [TimelineItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html) tag directive. Each item can be configured with options such as `Content`, `OppositeContent`, `DotCss`, `Disabled` and `CssClass`.

## Adding content

You can define the item content using the [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_Content) tag directives as a child to `TimelineItem` directive.

### String content

You can define string content for the Timeline items.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 350px">
    <SfTimeline>
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
    public class TimelineItemModel
    {
        public string Content { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "Shipped" },
        new TimelineItemModel() { Content = "Departed" },
        new TimelineItemModel() { Content = "Arrived" },
        new TimelineItemModel() { Content = "Out for Delivery" }
    };
}

```

![Blazor Timeline Component with String Content](./images/Blazor-content-string.png)

### Template content

You can specify the template content for the items in the `Content` tag directive.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 400px">
    <SfTimeline>
        <ChildContent>
            <TimelineItems>
                @foreach (var item in timelineItems)
                {
                    <TimelineItem>
                        <Content>
                            <div class="content-container">
                                <div class="title">
                                    @item.Title
                                </div>
                                <div class="description">
                                    @item.Description
                                </div>
                                <div class="info">
                                    @item.Info
                                </div>
                            </div>
                        </Content>
                    </TimelineItem>
                }
                <TimelineItem>
                    <Content> Out for Delivery </Content>
                </TimelineItem>
            </TimelineItems>
        </ChildContent>
    </SfTimeline>
</div>

<style>
    .content-container {
        position: relative;
        width: 180px;
        padding: 10px;
        margin-left: 5px;
        box-shadow: rgba(9, 30, 66, 0.25) 0px 4px 8px -2px, rgba(9, 30, 66, 0.08) 0px 0px 0px 1px;
        background-color: ghostwhite;
    }

    .content-container::before {
        content: '';
        position: absolute;
        left: -8px;
        transform: translateY(-50%);
        width: 0;
        height: 0;
        border-top: 5px solid transparent;
        border-bottom: 5px solid transparent;
        border-right: 8px solid silver;
    }

    .content-container .title {
        font-size: 16px;
    }

    .content-container .description {
        color: #999999;
        font-size: 12px;
    }

    .content-container .info {
        color: #999999;
        font-size: 10px;
    }
</style>

@code {
    public class TimelineItemModel
    {
        public string Title { get; set; }
        public string Description{ get; set; }
        public string Info { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Title = "Shipped", Description = "Package details received", Info = "- Awaiting dispatch" },
        new TimelineItemModel() { Title = "Departed", Description = "In-transit", Info = "(International warehouse)" },
        new TimelineItemModel() { Title = "Arrived", Description = "Package arrived at nearest hub", Info = "(New york - US)" },
    };
}

```

![Blazor Timeline Component with Template Content](./images/Blazor-content-template.png)

## Adding opposite content

You can add additional information to each Timeline item, by using [OppositeContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_OppositeContent) tag directive as a child to `TimelineItem` which is positioned opposite to the item content. Similar to the `Content` property you can define `string` and template contents to the OppositeContent.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 250px">
    <SfTimeline>
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
        new TimelineItemModel() { Content = "Breakfast", OppositeContent = "8:00 AM" },
        new TimelineItemModel() { Content = "Lunch", OppositeContent = "1:00 PM" },
        new TimelineItemModel() { Content = "Dinner", OppositeContent = "8:00 PM" },
    };
}

```

![Blazor Timeline Component with Opposite Content](./images/Blazor-oppositecontent.png)

## Dot item

You can define CSS class to set icons, background colors, or images to personalize the appearance of dots associated with each Timeline item by using the [DotCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_DotCss) property.

### Adding icons

You can define the CSS class to show the icon for each item using the `DotCss` property.

### Adding images

You can include images for the Timeline items using the `DotCss` property, by setting the CSS `background-image` property.

### Adding text

You can display text for the Timeline items using the `DotCss` property, by adding text to the CSS `content` property.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 250px">
    <SfTimeline>
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem DotCss=@item.DotCss>
                    <Content>
                        @item.Content
                    </Content>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

<style>
    .e-dot.custom-image {
        background-image: url('./dot-image.png');
    }

    .e-dot.custom-text::before {
        content: 'A';
    }
</style>

@code {

    public class TimelineItemModel
    {
        public string Content { get; set; }
        public string DotCss { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "Default" },
        new TimelineItemModel() { Content = "Icon", DotCss = "e-icons e-check" },
        new TimelineItemModel() { Content = "Image", DotCss = "custom-image" },
        new TimelineItemModel() { Content = "Text", DotCss = "custom-text" },
    };
}

```

![Blazor Timeline Component with Dot Item](./images/Blazor-dot-item.png)

## Disabling items

You can use the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_Disabled) property to disable an item when set to `true`. By default, the value is `false`.

```cshtml

@using Syncfusion.Blazor.Layouts

<div class="container" style="height: 250px">
    <SfTimeline>
        <TimelineItems>
            @foreach (var item in timelineItems)
            {
                <TimelineItem Disabled=@item.Disabled>
                    <Content>
                        @item.Content
                    </Content>
                </TimelineItem>
            }
        </TimelineItems>
    </SfTimeline>
</div>

@code {

    public class TimelineItemModel
    {
        public string Content { get; set; }
        public bool Disabled { get; set; }
    }
    private List<TimelineItemModel> timelineItems = new List<TimelineItemModel>()
    {
        new TimelineItemModel() { Content = "Eat" },
        new TimelineItemModel() { Content = "Code" },
        new TimelineItemModel() { Content = "Repeat", Disabled = true },
    };
}

```

![Blazor Timeline Component with Disabled Item](./images/Blazor-disabled)

## CSS class

You can customize the appearance of the Timeline item by specifying a custom CSS class using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.TimelineItem.html#Syncfusion_Blazor_Layouts_TimelineItem_CssClass) property.