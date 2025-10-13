---
layout: post
title: Events in Blazor Kanban Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Kanban component and much more details.
platform: Blazor
control: Kanban
documentation: ug
---

# Event Handling in Blazor Kanban Component

his guide provides a comprehensive overview of the available events in the [Blazor Kanban](https://www.syncfusion.com/blazor-components/blazor-kanban-board) component. These events enable developers to customize behavior and respond to user interactions effectively.

## OnLoad event

[OnLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_OnLoad) is triggered before the Kanban component is rendered, allowing customization of its properties.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" OnLoad="@OnLoadHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void OnLoadHandler(Object args)
    {
        // Here you can customize your code
    }
}

```

## ActionBegin event

[ActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_ActionBegin) event triggers at the beginning of every Kanban action.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" ActionBegin="@ActionBeginHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void ActionBeginHandler(ActionEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## ActionComplete event

[ActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_ActionComplete) is triggered after a Kanban action completes successfully.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" ActionComplete="@ActionCompleteHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void ActionCompleteHandler(ActionEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## ActionFailure event

[ActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_ActionFailure) is triggered when a Kanban action fails or is interrupted, providing error details.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" ActionFailure="@ActionFailureHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void ActionFailureHandler(ActionEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## CardClick event

[CardClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_CardClick) is triggered when a user clicks on a Kanban card.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" CardClick="@CardClickHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void CardClickHandler(CardClickEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## CardDoubleClick event

[CardDoubleClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_CardDoubleClick) is triggered when a user double-clicks a Kanban card.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" CardDoubleClick="@CardDoubleClickHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void CardDoubleClickHandler(CardClickEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## CardRendered event

[CardRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_CardRendered) is triggered before each Kanban card is rendered on the page.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" CardRendered="@CardRenderedHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void CardRenderedHandler(CardRenderedEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DataBinding event

[DataBinding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DataBinding) is triggered before data is bound to the Kanban component.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" DataBinding="@DataBindingHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DataBindingHandler(DataBindingEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DialogClose event

[DialogClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DialogClose) is triggered before the Kanban dialog closes.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" DialogClose="@DialogCloseHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DialogCloseHandler(DialogCloseEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DialogOpen event

[DialogOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DialogOpen) is triggered before the Kanban dialog opens.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" DialogOpen="@DialogOpenHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DialogOpenHandler(DialogOpenEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DragStart event

[DragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DragStart) is triggered when a card drag operation begins.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" DragStart="@DragStartHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DragStartHandler(DragEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## DragStop event

[DragStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DragStop) is triggered when a card drag operation ends.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" DragStop="@DragStopHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void DragStopHandler(DragEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```

## QueryCellInfo event

[QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_QueryCellInfo) is triggered before each Kanban column is rendered on the page.

```cshtml

@using Syncfusion.Blazor.Kanban

<SfKanban TValue="TasksModel">
   <KanbanEvents TValue="TasksModel" QueryCellInfo="@QueryCellInfoHandler" ></KanbanEvents>
</SfKanban>
@code{

    public void QueryCellInfoHandler(QueryCellInfoEventArgs<TValue> args)
    {
        // Here you can customize your code
    }
}

```