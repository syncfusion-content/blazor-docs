---
layout: post
title: Pane Settings in Blazor Splitter Component | Syncfusion
description: Checkout and learn here all about Pane Settings in Syncfusion Blazor Splitter component and much more.
platform: Blazor
control: Splitter
documentation: ug
---

# Pane Settings in the Blazor Splitter Component

This section explains the pane settings behavior.

## Pane visibility

You can show or hide the Splitter panes using the `Visible` property based on the application’s demand like initial load or dynamic cases. The `Visible` property is enabled by default in the Blazor splitter.

In the following code example, the `Visible` property binds to the second `SplitterPane` to show/hide the pane on CheckBox state change.

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