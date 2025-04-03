---
layout: post
title: Lane Interactions in Blazor Diagram Component | Syncfusion
description: How to select, resize(with and without selection), and swap the lane, and how to add the child element into the lane.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Lane interaction in Blazor Diagram Component

The diagram provides support to select, resize, or swap the lane interactively. 

## Select

A Lane can be selected by clicking (tapping) the header of the lane.

## Resizing lane

* A lane can be resized in the bottom and right direction.
* A lane can be resized by using the resize selector of the lane.
* A lane can be resized by dragging the bottom and right border of the lane without making a selection.
* When a lane is resized, the swimlane will automatically adjust its size.
* A lane can be resized either by resizing the selector or the tight bounds of the child object. If the child node moves to the edge of the lane, it can be automatically resized.

The following image shows how to resize the lane.

![Lane Resizing](../Swimlane-images/Lane_Resize.gif)

## Lane swapping

* Lanes can be swapped by dragging the lanes over another lane.
* The helper will indicate the insertion point during lane swapping.
The following image shows how to swap lanes.

![Lane Swapping](../Swimlane-images/Lane_Swapping.gif)

## Children interaction in lanes

* You can resize the child node within swimlanes.
* You can drag the child nodes within the lane.
* You can interchange the child nodes from one lane to another.
* Drag and drop the child nodes from lane to the diagram.
* Drag and drop the child nodes from diagram to the lane.
* Based on the child node interactions, the lane size will be updated.

The following image shows children interaction in lane.

![Lane Children Interaction](../Swimlane-images/Child_Interaction.gif)
