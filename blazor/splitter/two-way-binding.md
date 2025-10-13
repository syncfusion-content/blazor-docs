---
layout: post
title: Two-way Binding in Blazor Splitter Component | Syncfusion
description: Checkout and learn here all about two way binding in Syncfusion Blazor Splitter component and much more.
platform: Blazor
control: Splitter
documentation: ug
---

# Two-way Binding in Blazor Splitter Component

The `Collapsed` property of a `SplitterPane` supports two-way binding, which can be achieved using the `@bind-Collapsed` attribute. When the value of the bound variable changes, it automatically updates all elements linked via that variable.

In the following example, if either the value is changed in checkbox or splitter first pane collapsed state, it will reflect in both the checkbox and splitter pane.

```cshtml

@using Syncfusion.Blazor.Layouts
@using Syncfusion.Blazor.Buttons

<div>
    <div class="row">
        <SfCheckBox @bind-Checked="@collapsed" Label="CheckBox"></SfCheckBox>
    </div>
    <SfSplitter Height="300px" Width="100%">
        <SplitterPanes>
            <SplitterPane Size="25%" Min="60px" Collapsible="true" @bind-Collapsed="@collapsed">
                <div>
                    <div class="contents">
                        <div>Left pane</div>
                    </div>
                </div>
            </SplitterPane>
            <SplitterPane Size="50%" Min="60px" Collapsible="true">
                <div>
                    <div class='contents'>
                        <div>Right pane</div>
                    </div>
                </div>
            </SplitterPane>
        </SplitterPanes>
    </SfSplitter>
</div>

@code {
    public bool collapsed { get; set; } = false;
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDresDZFpYnFGNWd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Data Binding in Blazor Splitter](./images/blazor-splitter-data-binding.png)

## See Also

* [Resizable split panes](./resizing)