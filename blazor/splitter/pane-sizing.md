---
layout: post
title: Pane Sizing in Blazor Splitter Component | Syncfusion
description: Learn here all about Pane Sizing in Syncfusion Blazor Splitter component and more.
platform: Blazor
control: Splitter
documentation: ug
---

# Pane Sizing in Blazor Splitter Component

Splitter allows you to provide pane sizes either in `Pixel` or `Percentage` formats.

## Auto size panes

The splitter's panes are adjusted automatically during resizing if the size is not specified externally to panes, because the panes are designed based on flex layout by default. When you add/remove or show/hide the panes, the panes are auto aligned within its container.

```csharp

using Syncfusion.Blazor.Layouts

<SfSplitter Height="200px" Width="600px">
    <SplitterPanes>
        <SplitterPane>
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">Grid </h3>
                        The ASP.NET DataGrid control, or DataTable is a feature-rich control used to display data in a tabular format.
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane>
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">Schedule </h3>
                        The ASP.NET Scheduler, a.k.a. event calendar, facilitates almost all calendar features, thus allowing users to manage their time efficiently
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane>
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">Chart </h3>
                        ASP.NET charts, a well-crafted easy-to-use charting package, is used to add beautiful charts in web and mobile applications
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

<style>
    .content {
        padding: 10px;
    }
</style>

```

The output will be as follows.

![auto sizing](./images/auto-sizing-panes.png)

## Fixed pane

You can render the split panes with fixed size in both `Horizontal` and `Vertical` mode. Even if you provide fixed sizes to all the panes, the last pane is considered as a flexible pane.

```csharp

@using Syncfusion.Blazor.Layouts

<SfSplitter Height="200px" Width="600px">
    <SplitterPanes>
        <SplitterPane Size="200px">
            <ContentTemplate>
                <div> Left pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Size="200px">
            <ContentTemplate>
                <div> Middle pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Size="200px">
            <ContentTemplate>
                <div> Right pane </div>
            </ContentTemplate>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

<style>
    .e-pane {
        text-align: center;
        align-items: center;
        display: grid;
    }
</style>

```

The output will be as follows.

![pane Size](./images/fixed-pane-pixel.png)

Splitter pane Size in `Percentage`.

```csharp

@using Syncfusion.Blazor.Layouts

<SfSplitter Height="200px" Width="600px">
    <SplitterPanes>
        <SplitterPane Size="30%">
            <ContentTemplate>
                <div> Left pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Size="40%">
            <ContentTemplate>
                <div> Middle pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Size="30%">
            <ContentTemplate>
                <div> Right pane </div>
            </ContentTemplate>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

```

The output will be as follows.

![pane Size](./images/fixed-pane-percentage.png)