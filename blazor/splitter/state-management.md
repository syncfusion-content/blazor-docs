---
layout: post
title: State Management in Blazor Splitter Component | Syncfusion
description: Checkout and learn here all about state management in Syncfusion Blazor Splitter component and more.
platform: Blazor
control: Splitter
documentation: ug
---

# State Management in Blazor Splitter Component

State management allows users to save and load Splitter state. The splitter will use user-provided state to render instead of its properties provided declaratively.

The following properties can be saved and loaded into each **SplitterPane** later.

Property|
-----|
Collapsed |
Min |
Max |
Size |

## Enabling Persistence in Splitter

State persistence allows the Splitter to retain the current splitter panes state in the browser local storage for state maintenance. This action is handled through the `EnablePersistence` property which is set to false by default. When it is set to true, some properties of the `SplitterPane` will be retained even after refreshing the page.

N> The state will be persisted based on **ID** property. So, it is recommended to explicitly set the **ID** property for Splitter.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter ID="Splitter" Height="300px" Width="100%" EnablePersistence="true">
    <SplitterPanes>
        <SplitterPane @bind-Min="@PaneMin" @bind-Size="@Pane1Size" Collapsible="true">
            <div>
                <div style="text-align: center">
                    <div>Left pane</div>
                </div>
            </div>
        </SplitterPane>
        <SplitterPane @bind-Min="@PaneMin" @bind-Size="@Pane2Size" Collapsible="true">
            <div>
                <div style="text-align: center">
                    <div>Middle pane</div>
                </div>
            </div>
        </SplitterPane>
        <SplitterPane @bind-Min="@PaneMin" Collapsible="true">
            <div>
                <div style="text-align: center">
                    <div>Last Pane</div>
                </div>
            </div>
        </SplitterPane>
    </SplitterPanes>
</SfSplitter>

@code {
    private string Pane1Size { get; set; } = "25%";
    private string Pane2Size { get; set; } = "50%";
    private string PaneMin { get; set; } = "60px";
}
```