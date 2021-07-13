---
layout: post
title: Events in Blazor Kanban Component | Syncfusion 
description: Learn about Events in Blazor Kanban component of Syncfusion, and more details.
platform: Blazor
control: Kanban
documentation: ug
---

# Events

This section explains the list of events of the Kanban component which will be triggered for appropriate Kanban actions.

## OnLoad

`OnLoad` event allows customization of Kanban properties before rendering.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents OnLoad="@OnLoadHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void OnLoadHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## ActionBegin

`ActionBegin` event triggers at the beginning of every Kanban action.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents ActionBegin="@ActionBeginHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void ActionBeginHandler(ActionEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## ActionComplete

`ActionComplete` event triggers on successful completion of the Kanban actions.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents ActionComplete="@ActionCompleteHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void ActionCompleteHandler(ActionEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## ActionFailure

`ActionFailure` event triggers when a Kanban action gets failed or interrupted and it will return an error information.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents ActionFailure="@ActionFailureHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void ActionFailureHandler(ActionEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## CardClick

`CardClick` event triggers on single-clicking the Kanban cards.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents CardClick="@CardClickHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void CardClickHandler(CardClickEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## CardDoubleClick

`CardDoubleClick` event triggers on double-clicking the Kanban cards.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents CardDoubleClick="@CardDoubleClickHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void CardDoubleClickHandler(CardClickEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## CardRendered

`CardRendered` event triggers before each card of the Kanban rendering on the page.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents CardRendered="@CardRenderedHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void CardRenderedHandler(CardRenderedEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DataBinding

`DataBinding` event triggers before the data binds to the Kanban.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents DataBinding="@DataBindingHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DataBindingHandler(DataBindingEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DialogClose

`DialogClose` event triggers before the dialog closes.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents DialogClose="@DialogCloseHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DialogCloseHandler(DialogCloseEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DialogOpen

`DialogOpen` event triggers before the dialog opens.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents DialogOpen="@DialogOpenHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DialogOpenHandler(DialogOpenEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DragStart

`DragStart` event triggers when the card drag actions start.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents DragStart="@DragStartHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DragStartHandler(DragEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DragStop

`DragStop` event triggers when the card drag actions stop.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents DragStop="@DragStopHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DragStopHandler(DragEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## QueryCellInfo

`QueryCellInfo` event triggers before each column of the Kanban rendering on the page.

```csharp

@using Syncfusion.Blazor.Kanban

<SfKanban>
   <KanbanEvents QueryCellInfo="@QueryCellInfoHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void QueryCellInfoHandler(QueryCellInfoEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```