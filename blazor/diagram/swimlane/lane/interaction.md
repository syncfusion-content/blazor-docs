---
layout: post
title: Lane Interaction in Blazor Diagram Component | Syncfusion
description: How to select, resize(with and without selection), and swap the lane, and how to add the child element into the lane.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Lane Interaction in Blazor Diagram Component

The diagram supports interactive lane operations, including selecting, resizing, and swapping lanes, as well as working with child elements inside lanes. 

## How to Select a Lane

A [Lane](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Lane.html) can be selected by clicking (tapping) the header of the lane.

## How to Resize a Lane

* A lane can be resized in the bottom and right direction.
* A lane can be resized by using the resize selector of the lane.
* A lane can be resized by dragging the bottom and right border of the lane without making a selection.
* When a lane is resized, the parent swimlane will automatically adjust its size.
* A lane can resized either by resizing the selector or the tight bounds of the child objects. If a child node moves to the edge of the lane, it can be automatically resized.

The following image shows how to resize the lane.

![Lane Resizing](../Swimlane-images/Lane_Resize.gif)

## How to Swap Lanes

* Lanes can be swapped by dragging a lane over another lane.
* A helper indicator appears to show the insertion position during lane swapping.
The following image shows how to swap lanes.

![Lane Swapping](../Swimlane-images/Lane_Swapping.gif)

## How to Interact with Child Nodes in Lanes

* Resize child nodes within swimlanes.
* You can drag the child nodes within the lane.
* Drag child nodes within the same lane to reposition them.
* Drag and drop the child nodes from a lane to the diagram.
* Drag and drop the child nodes from diagram to the lane.
* Based on the child node interactions, the lane size will be updated.

The following image shows children interaction in lane.

![Lane Children Interaction](../Swimlane-images/Child_Interaction.gif)
