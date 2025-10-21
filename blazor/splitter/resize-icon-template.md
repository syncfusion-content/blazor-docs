---
layout: post
title: Resize Icon Template Support | Syncfusion
description: Check out and learn here all about how to customize the resize icon in the separator using the template in Syncfusion Blazor Splitter component and much more.
platform: Blazor
control: Splitter
documentation: ug
---

# Resize Icon Template

The Splitter supports customizing the resize icon in the separator using a template. Any markup, such as bars, images, or icons, can be rendered as the resize handle.

```cshtml

@using Syncfusion.Blazor.Layouts

<div>Horizontal Splitter</div>
<SfSplitter Height="240px" Width="100%">
    <SplitterTemplates>
        <Separator>
            <div style="height: 10px; border: 2px solid red"></div>
        </Separator>
    </SplitterTemplates>
    <SplitterPanes>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div> Left Pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div> Middle Pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div> Right Pane </div>
            </ContentTemplate>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhIWttvfkXWBDnr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Splitter with Resize Icon Template](./images/blazor-splitter-resize-icon-template.png)