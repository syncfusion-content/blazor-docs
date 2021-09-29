---
layout: post
title: Pane Settings in Blazor Splitter Component | Syncfusion
description: Checkout and learn here all about Pane Settings in Syncfusion Blazor Splitter component and much more.
platform: Blazor
control: Splitter
documentation: ug
---

# Pane Settings in Blazor Splitter Component

This section explain pane settings behaviors.

## Pane visibility

The `Visible` property is enabled by default in the Blazor splitter. By using this property, you can show or hide the panes on initial load and in dynamic use case scenarios.

In the following code example, bind the `Visible` property as mentioned below to show/hide the panes on CheckBox state change.

```cshtml

@using Syncfusion.Blazor.Layouts

<button class="e-btn" @onclick="@ToggleMiddlePane"> Toggle Middle Pane </button>

<SfSplitter Height="240px" Width="700px" SeparatorSize="2">
    <SplitterPanes>
        <SplitterPane Size="30%" Collapsible="true">
            <ContentTemplate>
                <div> Left Pane </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Size="30%" Collapsible="true" Visible="@this.PaneMiddleVisibility">
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

@code {
    public bool PaneMiddleVisibility { get; set; } = false;

    public void ToggleMiddlePane()
    {
        this.PaneMiddleVisibility = !this.PaneMiddleVisibility;
    }
}

```