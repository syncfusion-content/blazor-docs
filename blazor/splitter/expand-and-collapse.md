---
layout: post
title: Expand and Collapse in Blazor Splitter Component | Syncfusion
description: Checkout and learn here all about how to expand and collapse in Syncfusion Blazor Splitter component and more.
platform: Blazor
control: Splitter
documentation: ug
---

# Expand and Collapse in Blazor Splitter Component

## Collapsible Panes

The Splitter panes include built-in expand and collapse functionalities. By default, this behavior is disabled. Enable the `Collapsible` property within the `SplitterPane` to display the expand or collapse icons. Panes can then be dynamically expanded and collapsed using these icons.

The following code demonstrates enabling collapsible behavior:

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter Height="200px" Width="600px" SeparatorSize=2>
    <SplitterPanes>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">PARIS </h3>
                        Paris, the city of lights and love - this short guide is full of ideas for how to make the most of the romanticism...
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">CAMEMBERT </h3>
                        The village in the Orne department of Normandy where the famous French cheese is originated from.
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">GRENOBLE </h3>
                        The capital city of the French Alps and a major scientific center surrounded by many ski resorts, host of the Winter Olympics in 1968.
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVIWjDbTGevpdop?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Expand and Collapse in Blazor Splitter](./images/blazor-splitter-expand-collapse.png)

## Programmatically Control Expand and Collapse Actions

The Splitter component provides public methods (`ExpandAsync` and `CollapseAsync`) to control pane expansion and collapse programmatically.

```cshtml

@using Syncfusion.Blazor.Layouts
@using Syncfusion.Blazor.Buttons

<SfSplitter @ref="SplitterObj" Height="200px" Width="600px" SeparatorSize=2>
    <SplitterPanes>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">PARIS </h3>
                        Paris, the city of lights and love - this short guide is full of ideas for how to make the most of the romanticism...
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">CAMEMBERT </h3>
                        The village in the Orne department of Normandy where the famous French cheese is originated from.
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">GRENOBLE </h3>
                        The capital city of the French Alps and a major scientific center surrounded by many ski resorts, host of the Winter Olympics in 1968.
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

<div id="button-container">
    <SfButton @onclick="@Expand"> Expand </SfButton>
    <SfButton @onclick="@Collapse"> Collapse </SfButton>
</div>

<style>
    .content {
        padding: 10px;
    }
    #button-container {
        display: flex;
        margin: 20px 22% 40px;
    }
</style>

@code {
    SfSplitter SplitterObj;

    private async Task Expand()
    {
        await this.SplitterObj.ExpandAsync(0);
    }

    private async Task Collapse()
    {
        await this.SplitterObj.CollapseAsync(0);
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhyWttbpwHeoMpA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Expand and Collapse in Blazor Splitter](./images/blazor-splitter-expand-collapse-dynamic.png)

## Specify Initial State to Panes

Specific panes can be rendered in a collapsed state upon page load. To control this behavior, set the `Collapsed` property to `true` for the desired `SplitterPane`. The following code demonstrates rendering the second pane in a collapsed state.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter Height="200px" Width="600px" SeparatorSize=2>
    <SplitterPanes>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">PARIS </h3>
                        Paris, the city of lights and love - this short guide is full of ideas for how to make the most of the romanticism...
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true" @bind-Collapsed="@collapsed">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">CAMEMBERT </h3>
                        The village in the Orne department of Normandy where the famous French cheese is originated from.
                    </div>
                </div>
            </ContentTemplate>
        </SplitterPane>
        <SplitterPane Collapsible="true">
            <ContentTemplate>
                <div>
                    <div class="content">
                        <h3 class="h3">GRENOBLE </h3>
                        The capital city of the French Alps and a major scientific center surrounded by many ski resorts, host of the Winter Olympics in 1968.
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

@code  {

    private bool collapsed { get; set; } = true;

}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBeWZZlpGczrUcO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Expand and Collapse in Blazor Splitter](./images/blazor-splitter-expand-collapse-initial.png)

## See Also

* [Resizable split panes](./resizing)