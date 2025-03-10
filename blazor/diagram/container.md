---
layout: post
title: Container in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Container in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Container in Blazor Diagram Component

Containers provide a powerful way to organize and manage collections of diagram elements. They act as logical groupings of shapes enclosed by a customizable border, allowing for intuitive drag-and-drop operations during runtime. Changes to the container, such as position, size, or style, do not affect its children. This enhances diagram clarity by maintaining organization while allowing individual elements to be edited separately.

## Create a Container
A container can be created and added to the diagram, either programmatically or interactively.

### Add a Container

To create a container, you have to define the container object and add it to the [Nodes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Nodes) collection of the diagram. The following code illustrates how to create a Container Node.

```cshtml
```

[View sample in GitHub](https://github.com/SyncfusionExamples/WPF-Diagram-Examples/tree/master/Samples/Container)

### Container Header

Containers can include descriptive text to identify their purpose or contents through the `Header` property. This feature enhances diagram readability by providing clear labels for grouped elements. The header's visual presentation is fully customizable using the `Style` property.  

The following code example explains how to define a container header and its customization:

```cshtml
```

![WPF Diagram Container Header](Container_images/ContainerHeader.png)

### Header editing

The diagram provides support to edit container headers at runtime. You can achieve the header editing by double-clicking the region of the container's header, or by pressing F2.

![Header Editing](Swimlane-images/Header_Edit.gif).

### Container from Symbol palette

Container nodes can be predefined and added to the symbol palette, enabling quick and consistent reuse throughout your diagrams. When needed, you can simply drag these predefined containers from the palette and drop them directly into your diagram. 

The following code example explains how to define a container and add it to the symbol palette:

```cshtml
```

## Interactively add or remove diagram elements into Container

Diagram elements can be added or removed from a container at runtime. When an element is dropped onto the container's edges, the container automatically adjusts its size to accommodate the new element.

![WPF Diagram Container Interaction](Container_images/Container.gif)

## Interaction

Diagram provides support to select, drag or resize the container interactively. 

### How to select the container
Container can be selected by clicking (tapping) on it. Also, it can be selected at runtime by using the [Select](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_Select_System_Collections_ObjectModel_ObservableCollection_Syncfusion_Blazor_Diagram_IDiagramObject__System_Nullable_System_Boolean__) method and clear the selection in the diagram by using the [ClearSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ClearSelection)

![WPF Diagram Container Selection](Container_images/Container-Selection.png)

### How to drag the container 

* A container can be moved by clicking and dragging it within the diagram.

* When you drag the elements in the diagram, the [PositionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanging) and [PositionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PositionChanged) events get triggered and we can do customization on those events.

![Drag Node](Swimlane-images/Swimlane_Select_Drag.gif)

### Resize

* A selected container is surrounded by eight resize thumbs. Dragging these thumbs adjusts the container’s size.
* When dragging one corner, the opposite corner remains fixed.
* To maintain the container's aspect ratio during resizing, enable the `AspectRatio` constraint in NodeConstraints.
* A container can be resized either by resizing the selector or the tight bounds of the child object. If the child node moves to the edge of the container, it will be automatically resized.

![WPF Diagram Resize Container](Container_images/Container-Resize.gif)
