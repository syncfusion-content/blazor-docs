---
layout: post
title: Customizations in Blazor Avatar Component | Syncfusion®
description: Learn how to use different content types, shapes, and sizes in Blazor Avatar component.
platform: Blazor
control: Avatar
documentation: ug
---

# Customizations with Blazor Avatar Component

Learn how to use different content types, shapes, and sizes in the Blazor Avatar component. 

## Types in Blazor Avatar Component

The Blazor Avatar component supports multiple content types to display user or entity information.

| Content Type | Description |
|-------------|-------------|
| Image Avatar | Displays an image inside the Avatar. |
| SVG Avatar | Displays SVG icons inside the Avatar. |
| Initial Avatar | Displays initials or letters inside the Avatar. |
| Font Avatar | Displays font icons inside the Avatar. |
| Word Avatar | Displays words or text inside the Avatar. |

```cshtml

<!-- Image Avatar -->
<div class="e-avatar e-avatar-xlarge e-avatar-circle">
    <img src="https://cdn.syncfusion.com/blazor/images/avatar/pic01.png" alt="XLarge user avatar image" />
</div>
<br />
<!-- SVG Avatar -->
<div class="e-avatar e-avatar-xlarge e-avatar-circle">
    <div class="svg_icons chrome"></div>
</div>
<br />
<!-- Initial Avatar -->
<div class="e-avatar e-avatar-xlarge e-avatar-circle">GR</div>
<br />
<!-- Font Avatar -->
<div class="e-avatar e-avatar-xlarge e-avatar-circle">
    <div class="e-people icons"></div>
</div>
<br />
<!-- Word Avatar -->
<div class="e-avatar e-avatar-xlarge e-avatar-circle">User</div>

<style>
    /* SVG Icons */
    .chrome {
        background: transparent url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 32 32'%3E%3Cpath fill='%23ffffff' d='M16.033 11.049a5.155 5.155 0 1 1 0 10.312 5.156 5.156 0 0 1 0-10.312zM16.124 0c1.281-.003 9.659.318 14.268 9.043h-.016l.01.018c.33.578 3.745 6.94-.485 14.969 0 0-4.215 8.107-14.565 7.968l-.452-.012-.004.007-.004.007.02-.037c.564-.98 5.112-8.884 6.357-11.067l.016-.028.007-.008.04-.069.11-.127a7.085 7.085 0 0 0 1.457-2.967l.01-.046.035-.151c.088-.424.148-.944.128-1.549l-.006-.117v-.004l-.007-.143-.006-.07-.005-.079-.012-.116v-.01l-.001-.008-.016-.158a7.2 7.2 0 0 0-.096-.572l-.018-.081-.013-.064a9.801 9.801 0 0 0-.692-2.016c-.165-.243-.332-.489-.512-.733l-.142-.187 8.728-2.554s-10.538-.01-13.018-.001l.021.005H16.642l-.14-.013a7.034 7.034 0 0 0-1.132-.003l-.167.016h-.047l-.034-.001c-.193.002-1.213.045-2.492.764l-.005.003-.033.016a7.158 7.158 0 0 0-3.25 3.533l-.059.148-6.485-6.404s4.74 8.311 6.165 10.779l.065.113.023.088a7.14 7.14 0 0 0 7.777 5.118l.144-.02L14.854 32h-.027c-.667-.005-7.894-.234-12.744-7.906 0 0-4.925-7.698.37-16.573l.252-.411.001-.002C2.822 6.904 6.58.374 15.958.003c0 0 .057-.003.166-.003z'/%3E%3C/svg%3E") no-repeat 100% 100%;
    }
    .svg_icons {
        width: 32px;
        height: 32px;
        display: inline-block;
    }
    /* Font Icons */
    @@font-face {
        font-family: 'Contacts';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj0gSRgAAAEoAAAAVmNtYXDnEOdaAAABjAAAADhnbHlmiAnWagAAAcwAAADwaGVhZBD04psAAADQAAAANmhoZWEHiwNuAAAArAAAACRobXR4C9AAAAAAAYAAAAAMbG9jYQAwAHgAAAHEAAAACG1heHABDwA1AAABCAAAACBuYW1lby+ImAAAArwAAAIxcG9zdGUbI4AAAATwAAAAOwABAAADUv9qAFoEAAAAAAAD3QABAAAAAAAAAAAAAAAAAAAAAwABAAAAAQAAWW9ja18PPPUACwPoAAAAANb8zuYAAAAA1vzO5gAAAAAD3QPqAAAACAACAAAAAAAAAAEAAAADACkAAgAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQPwAZAABQAAAnoCvAAAAIwCegK8AAAB4AAxAQIAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wDnAQNS/2oAWgPqAJYAAAABAAAAAAAABAAAAAPoAAAD6AAAAAAAAgAAAAMAAAAUAAMAAQAAABQABAAkAAAABAAEAAEAAOcB//8AAOcA//8AAAABAAQAAAABAAIAAAAAADAAeAACAAAAAAO+A+oADQAZAAA3FBYXIT4BNS4BJyEOARMeARc+ATcuAScOAS4YFwMzFxgDq4H+zYGr4QOCY2KCAwOCYmGCnCtOISFOK3qiAwOiAe1igwICg2JjggICggAAAAACAAAAAAPdA+oAFAAoAAABDgEHIicjDgEHLgEnLgEnPgE3HgEFFBYfARYfATcXFhc2JDcmJCcGBAOkBfK3KioXEFcpBBEMRUsBBfK3tvL8cVRLDggBBsQKLDDPARMFBf7tz87+7QI+ndEEBwI/Izh2DS+RVZ3RBATRnWCmN3BIETecAgcBBPK1tfIEBPIAAAAAABIA3gABAAAAAAAAAAEAAAABAAAAAAABAAgAAQABAAAAAAACAAcACQABAAAAAAADAAgAEAABAAAAAAAEAAgAGAABAAAAAAAFAAsAIAABAAAAAAAGAAgAKwABAAAAAAAKACwAMwABAAAAAAALABIAXwADAAEECQAAAAIAcQADAAEECQABABAAcwADAAEECQACAA4AgwADAAEECQADABAAkQADAAEECQAEABAAoQADAAEECQAFABYAsQADAAEECQAGABAAxwADAAEECQAKAFgA1wADAAEECQALACQBLyBDb250YWN0c1JlZ3VsYXJDb250YWN0c0NvbnRhY3RzVmVyc2lvbiAxLjBDb250YWN0c0ZvbnQgZ2VuZXJhdGVkIHVzaW5nIFN5bmNmdXNpb24gTWV0cm8gU3R1ZGlvd3d3LnN5bmNmdXNpb24uY29tACAAQwBvAG4AdABhAGMAdABzAFIAZQBnAHUAbABhAHIAQwBvAG4AdABhAGMAdABzAEMAbwBuAHQAYQBjAHQAcwBWAGUAcgBzAGkAbwBuACAAMQAuADAAQwBvAG4AdABhAGMAdABzAEYAbwBuAHQAIABnAGUAbgBlAHIAYQB0AGUAZAAgAHUAcwBpAG4AZwAgAFMAeQBuAGMAZgB1AHMAaQBvAG4AIABNAGUAdAByAG8AIABTAHQAdQBkAGkAbwB3AHcAdwAuAHMAeQBuAGMAZgB1AHMAaQBvAG4ALgBjAG8AbQAAAAACAAAAAAAAAAoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMBAgEDAQQABHVzZXIKY2hhdC0wMS13ZgAAAA==) format('truetype');
        font-weight: normal;
        font-style: normal;
    }
    .people,
    .e-people {
        font-family: 'Contacts';
    }
    .e-people:before {
        content: '\e700';
    }
    .e-avatar .e-people.icons {
        font-size: 24px;
    }
</style>

```

## Shapes in Blazor Avatar Component

The Blazor Avatar component supports two shapes: **Square** and **Circular**. By default, the Avatar is rendered in a square shape with a medium size.

```cshtml

<!-- Square Avatar -->
<div class="e-avatar e-avatar-medium">
    <img src="https://cdn.syncfusion.com/blazor/images/avatar/pic01.png" alt="Square avatar image" />
</div>

<!-- Circle Avatar -->
<div class="e-avatar e-avatar-medium e-avatar-circle">
    <img src="https://cdn.syncfusion.com/blazor/images/avatar/pic01.png" alt="Circular avatar image" />
</div>

<style>
    .e-avatar {
        background-image: url(https://cdn.syncfusion.com/blazor/images/avatar/pic01.png);
    }
</style>

```

## Sizes in Blazor Avatar Component

The Blazor Avatar component provides five size options to customize the Avatar appearance based on your UI requirements.

| Size | Class | Description |
|------|-------|-------------|
| Extra Small | e-avatar-xsmall | Displays an extra small sized Avatar. |
| Small | e-avatar-small | Displays a small sized Avatar. |
| Medium | e-avatar-medium | Displays a medium sized Avatar. This is the default size. |
| Large | e-avatar-large | Displays a large sized Avatar. |
| Extra Large | e-avatar-xlarge | Displays an extra large sized Avatar. |

```cshtml

<!-- Extra Small Avatar -->
<div class="e-avatar e-avatar-xsmall"></div>

<!-- Small Avatar -->
<div class="e-avatar e-avatar-small"></div>

<!-- Medium Avatar (Default) -->
<div class="e-avatar e-avatar-medium"></div>

<!-- Large Avatar -->
<div class="e-avatar e-avatar-large"></div>

<!-- Extra Large Avatar -->
<div class="e-avatar e-avatar-xlarge"></div>

<style>
    .e-avatar {
        background-image: url(https://cdn.syncfusion.com/blazor/images/avatar/pic01.png);
    }
</style>

```

## Avatar Integration with ListView Component

Easily integrate the Blazor Avatar component with layout components like ListView and Card to achieve UIs like mobile contact lists, Gmail, Outlook, and more. You can also integrate with the Badge component to represent notification counts in messaging apps.

The following example demonstrates the integration of Avatar within the ListView component.

```cshtml

@using Syncfusion.Blazor.Lists
<div class="control-section">
    <!-- Listview element -->
    <SfListView DataSource="@DataSource" HeaderTitle="Contacts" ShowHeader=true SortOrder="SortOrder.Ascending">
        <ListViewFieldSettings TValue="DataModel" Text="text"></ListViewFieldSettings>
        <ListViewTemplates TValue="DataModel">
            <Template>
                <div class="listWrapper">
                    @if (@context.Avatar != "")
                    {
                        <span class="e-avatar e-avatar-small e-avatar-circle">@context.Avatar</span>
                    }
                    else
                    {
                        <span class="@context.Pic e-avatar e-avatar-small e-avatar-circle"> </span>
                    }
                    <span class="list-text">@context.Text</span>
                </div>
            </Template>
        </ListViewTemplates>
    </SfListView>
</div>
@code {
    private List<DataModel> DataSource = new List<DataModel>()
    {
        new DataModel { Id = "s_01", Text = "Robert", Avatar = "", Pic = "pic04" },
        new DataModel { Id = "s_02", Text = "Nancy", Avatar = "N", Pic = "" },
        new DataModel { Id = "s_03", Text = "John", Avatar = "", Pic = "pic01" },
        new DataModel { Id = "s_05", Text = "Andrew", Avatar = "A", Pic = "" },
        new DataModel { Id = "s_06", Text = "Margaret", Avatar = "", Pic = "pic02" },
        new DataModel { Id = "s_07", Text = "Steven", Avatar = "", Pic = "pic03" },
        new DataModel { Id = "s_08", Text = "Michael", Avatar = "M", Pic = "" },
    };
    // Specifies the model class for ListView datasource.
    public class DataModel
    {
        public string? Id { get; set; }
        public string? Text { get; set; }
        public string? Avatar { get; set; }
        public string? Pic { get; set; }
    }
}
<style>
    .control-section {
        overflow: auto;
    }
    /* Listview Customization */
    .e-control.e-listview {
        max-width: 350px;
        margin: auto;
        border-radius: 3px;
    }
    .e-control.e-listview .listWrapper {
        width: inherit;
        height: inherit;
        position: relative;
        display: flex;
    }
    .e-control.e-listview .e-list-header {
        height: 54px;
    }
    .e-bigger .e-listview:not(.e-list-template) .e-list-item, .e-listview:not(.e-list-template) .e-list-item {
        cursor: pointer;
        height: 50px;
        line-height: 44px;
        border: 0;
        padding:0;
    }
    /* Badge Positioning */
    .e-control.e-listview .e-badge {
        margin-top: 12px;
    }
    .e-control.e-listview .listWrapper .list-text {
        width: 60%;
        display: inline-block;
        vertical-align: middle;
        margin: auto 50px auto 20px;
    }
    /* Avatar Positioning */
    .e-control.e-listview .listWrapper .e-avatar {
        font-size: 10px;
        margin: auto 0;
        left: 5px;
    }
    /* Avatar Background Customization */
    .e-control.e-listview .e-list-item:nth-child(1) .e-avatar {
        background-color: #039BE5;
    }
    .e-control.e-listview .e-list-item:nth-child(3) .e-avatar {
        background-color: #E91E63;
    }
    .e-control.e-listview .e-list-item:nth-child(5) .e-avatar {
        background-color: #009688;
    }
    /* Avatar images using 'background-image' property */
    .pic01 {
        background-image: url("https://cdn.syncfusion.com/blazor/images/avatar/pic01.png");
    }
    .pic02 {
        background-image: url("https://cdn.syncfusion.com/blazor/images/avatar/pic02.png");
    }
    .pic03 {
        background-image: url("https://cdn.syncfusion.com/blazor/images/avatar/pic03.png");
    }
    .pic04 {
        background-image: url("https://cdn.syncfusion.com/blazor/images/avatar/pic04.png");
    }
</style>

```
