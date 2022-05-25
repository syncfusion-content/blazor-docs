---
layout: post
title: Linear Arrangement in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Linear Arrangement in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram
documentation: ug
---

# Linear Arrangement in Blazor Diagram Component

Linear arrangement is used to linearly arrange the child nodes in layout, which means the parent node is placed in the center corresponding to its children. When line distribution is enabled, linear arrangement is also activated by default. The [Arrangement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.DiagramLayout.html#Syncfusion_Blazor_Diagrams_DiagramLayout_Arrangement) property of layout is used to enable or disable the linear arrangement in layout. By default Arrangement will be `Nonlinear`.

> Linear arrangement is applicable only for complex hierarchical tree layout.

The following code illustrates how to allow a linear arrangement in diagram layout.

```csharp
  
protected override void OnInitialized()
{
    LayoutValue = new DiagramLayout()
        {
            Type = LayoutType.ComplexHierarchicalTree,
            HorizontalSpacing = 40,
            VerticalSpacing = 40,
            Orientation = LayoutOrientation.TopToBottom,
            //To arrange a child nodes in a linear manner
            Arrangement = ChildArrangement.Linear
        };
    }
}

```

## See also

* [How to create a node](../nodes/nodes)

* [How to create a connector](../connectors/connectors)
