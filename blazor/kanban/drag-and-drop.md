---
layout: post
title: How to Use Drag and Drop in Blazor Kanban Component | Syncfusion
description: Checkout and learn here all about drag and drop the cards in the Syncfusion Blazor Kanban component.
platform: Blazor
control: Kanban
documentation: ug
---

# Drag and Drop in Blazor Kanban Component

Cards in the Blazor Kanban component can be dragged and dropped across columns, within columns, across swimlane rows, or between Kanban boards and external components.

### Types of drag and drop in kanban

* Internal drag and drop
* External drag and drop

## Internal drag and drop

Allows the user to drag and drop the cards within the Kanban board. Internal drag-and-drop operations can be categorized into the following types:

* Column drag and drop
* Swimlane drag and drop

### Column drag and drop

Users can reposition cards using drag-and-drop functionality. By default, the [AllowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.SfKanban-1.html#Syncfusion_Blazor_Kanban_SfKanban_1_AllowDragAndDrop) property is enabled on the Kanban board, which is used to change the card position from column to column or within the column.

A dotted border is added on Kanban cells except the dragged clone cells when dragging, which indicates the possible ways for dropping the cards into the cells.

In the following example, the drag and drop behavior is disabled on the Kanban board.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/column-drag-drop.razor %}

{% endhighlight %}
{% endtabs %}

### Swimlane drag and drop

By default, cards cannot be dragged across swimlane rows. Enabling the [AllowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.SfKanban-1.html#Syncfusion_Blazor_Kanban_SfKanban_1_AllowDragAndDrop) property allows to drag the cards across the swimlane rows, which is specified inside [KanbanSwimlaneSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.SfKanban-1.html#Syncfusion_Blazor_Kanban_SfKanban_1_SwimlaneSettings) property.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/swimlane-drag-drop.razor %}

{% endhighlight %}
{% endtabs %}

## External drag and drop

Allows the user to drag and drop the cards from one Kanban to another Kanban or Kanban to an external source and vice versa.

### Kanban to Kanban

Users can drag and drop cards between two Kanban boards. This can be achieved by specifying the [ExternalDropId](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.SfKanban-1.html#Syncfusion_Blazor_Kanban_SfKanban_1_ExternalDropId) property which is used to specify the id of the dropped Kanban element and the [DragStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DragStop) event which is used to delete the card on dragged Kanban and add the card on dropped Kanban using the [DeleteCard](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.SfKanban-1.html#Syncfusion_Blazor_Kanban_SfKanban_1_DeleteCardAsync__0_) and [AddCard](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.SfKanban-1.html#Syncfusion_Blazor_Kanban_SfKanban_1_AddCardAsync__0_System_Int32_) public methods.

In the following example, a card can be dragged from one Kanban and dropped into another Kanban using the [DragStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DragStop) event.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/kanban-to-kanban.razor %}

{% endhighlight %}
{% endtabs %}

### Kanban to Schedule

Users can drag cards from the Kanban board and drop them into the Schedule component.

In the following sample, the data is removed from the Kanban board using the [DeleteCard](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.SfKanban-1.html#Syncfusion_Blazor_Kanban_SfKanban_1_DeleteCardAsync__0_) public method at the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnActionBegin) event of Schedule component and added to the Schedule component at Kanban [DragStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Kanban.KanbanEvents-1.html#Syncfusion_Blazor_Kanban_KanbanEvents_1_DragStop) event when dragging and dropping the card to the Schedule.

{% tabs %}
{% highlight cshtml tabtitle="Index.razor" %}

{% include_relative code-snippet/kanban-to-schedule.razor %}

{% endhighlight %}

{% highlight c# tabtitle="Data.cs" %}

{% include_relative code-snippet/kanban-schedule-data.cs %}

{% endhighlight %}
​​​​​​​{% endtabs %}
