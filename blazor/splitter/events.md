---
layout: post
title: Events in Blazor Splitter Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Splitter component and much more details.
platform: Blazor
control: Splitter
documentation: ug
---

# Events in Blazor Splitter Component

This section explains the list of events of the splitter component which will be triggered for appropriate splitter actions.

## Created

`Created` event triggers after creating the splitter component with its panes.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents Created="@CreatedHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void CreatedHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## OnResizeStart

`OnResizeStart` event triggers when the split pane is started to resize.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents OnResizeStart="@OnResizeStartHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void OnResizeStartHandler(ResizeEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnResizeStop

`OnResizeStop` event triggers when the resizing of split pane is stopped.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents OnResizeStop="@OnResizeStopHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void OnResizeStopHandler(ResizingEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Resizing

`Resizing` event triggers when a split pane is being resized.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents Resizing="@ResizingHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void ResizingHandler(ResizingEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnCollapse

`OnCollapse` event triggers before the panes get collapsed.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents OnCollapse="@OnCollapseHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void OnCollapseHandler(BeforeExpandEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnExpand

`OnExpand` event triggers before the panes get expanded.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents OnExpand="@OnExpandHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void OnExpandHandler(BeforeExpandEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Collapsed

`Collapsed` event triggers after the panes get collapsed.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents Collapsed="@CollapsedHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void CollapsedHandler(ExpandedEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## Expanded

`Expanded` event triggers after the panes get expanded.

```cshtml

@using Syncfusion.Blazor.Layouts

<SfSplitter>
   <SplitterEvents Expanded="@ExpandedHandler" ></SplitterEvents>
</SfSplitter>
@code{

    public void ExpandedHandler(ExpandedEventArgs args)
    {
        // Here you can customize your code
    }
}

```