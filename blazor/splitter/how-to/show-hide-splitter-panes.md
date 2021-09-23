---
layout: post
title: Binding the visible property in SplitterPane on Blazor Splitter Component | Syncfusion
description: Learn here all about to show or hide the SplitterPane using visible property in Syncfusion Blazor Splitter component and more.
platform: Blazor
control: Splitter
documentation: ug
---

# Dynamically show/hide the panes using the visible property in Blazor Splitter Component

The `Visible` property is enabled by default in Blazor splitter. By using this property, you can show or hide the panes on initial load and dynamic use case scenarios.

Bind the `Visible` property as mentioned below to show/hide the panes on CheckBox state change.

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