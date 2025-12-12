---
layout: post
title: Events in Blazor Query Builder Component | Syncfusion
description: Learn about the available events in the Syncfusion Blazor Query Builder, including the new Destroyed event that fires on component disposal.
platform: Blazor
control: Query Builder
---

# Events in Blazor Query Builder Component

This section lists key events available in the Blazor Query Builder and when they are triggered during user interactions and lifecycle changes.

## Created

The Created event is triggered once the component has been initialized and is ready.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data">
    <QueryBuilderEvents TValue="Order" Created="OnCreated"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    public void OnCreated() {
        // Here, you can customize your code.
    }
}
```

## RuleChanged

The RuleChanged event is triggered whenever a rule or group is added, removed, or modified.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data">
    <QueryBuilderEvents TValue="Order" RuleChanged="OnRuleChanged"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    public void OnRuleChanged(RuleChangeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```
## Changed

The Changed event is an EventCallback raised after a condition (And/Or), field, operator, or value change is applied in the Query Builder.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data">
    <QueryBuilderEvents TValue="Order" Changed="OnChanged"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    private void OnChanged(ChangeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnValueChange

Raised before a condition (And/Or), field, operator, or value is changed. Use this to validate or react before committing a change.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data">
    <QueryBuilderEvents TValue="Order" OnValueChange="OnValueChange"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    private void OnValueChange(ChangeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## DataBound

Triggered after the data source is populated and bound to the Query Builder.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data">
    <QueryBuilderEvents TValue="Order" DataBound="OnDataBound"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    private void OnDataBound(object args)
    {
        // Here, you can customize your code.
    }
}
```

## OnActionFailure

The OnActionFailure event is triggered whenever a remote data request or action fails in the QueryBuilder.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@RemoteData">
    <QueryBuilderEvents TValue="Order" OnActionFailure="OnActionFailure"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    private void OnActionFailure(Exception ex)
    {
        // Here, you can customize your code.
    }
}
```

## Drag-and-drop events

Enable drag-and-drop by setting the [`AllowDragAndDrop`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html#Syncfusion_Blazor_QueryBuilder_SfQueryBuilder_1_AllowDragAndDrop) property to `true` (default is `false`).

### RuleDragStarting

Invoked before a rule or group drag starts. You can cancel the drag by setting args.Cancel = true.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data" AllowDragAndDrop="true">
    <QueryBuilderEvents TValue="Order" RuleDragStarting="OnRuleDragStarting"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    private void OnRuleDragStarting(RuleDragStartingEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

### RuleDropping

Invoked before a rule or group is dropped on another. You can cancel the drop by setting args.Cancel = true.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data" AllowDragAndDrop="true">
    <QueryBuilderEvents TValue="Order" RuleDropping="OnRuleDropping"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    private void OnRuleDropping(RuleDroppingEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

### RuleDropped

Raised after a successful drop is completed.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data" AllowDragAndDrop="true">
    <QueryBuilderEvents TValue="Order" RuleDropped="OnRuleDropped"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    private void OnRuleDropped(RuleDroppedEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Destroyed

The Destroyed event is triggered when the component is disposed. Use it to perform reliable cleanup, detach external resources, or finalize logging.

```cshtml
<SfQueryBuilder TValue="Order" DataSource="@Data">
    <QueryBuilderEvents TValue="Order" Destroyed="OnDestroyed"></QueryBuilderEvents>
</SfQueryBuilder>

@code {
    public void OnDestroyed(object args)
    {
        // Here, you can customize your code.
    }
}
```
