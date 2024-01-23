---
layout: post
title: Lane interactions in Blazor Diagram Component | Syncfusion
description: How to select, resize(with and without selection) and swap the lane and how to add the child element into lane?.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Lane interaction in Blazor Diagram Component

The diagram provides support to select, resize, or swap the lane interactively. 

### Select

A Lane can be selected by clicking (tap) the header of the lane.

## Resizing lane

* Lane can be resized in the bottom and right direction.
* Lane can be resized by using the resize selector of the lane.
* Lane can be resized by resizing the bottom and right border of the lane without make a selection.
* Once you are able to resize the lane, the swimlane will be automatically resized.
* The lane can be resized either resizing the selector or the tight bounds of the child object. If the child node move to edge of the lane it can be automatically resized.

The following image shows how resize the lane.

![Lane Resizing](../Swimlane-images/Lane_Resize.gif)

## Lane swapping

* Lanes can be swapped by dragging the lanes over another lane.
* The helper should indicate the insertion point when lane swapping. 
The following image shows how to swap lanes.

![Lane Swapping](../Swimlane-images/Lane_Swapping.gif)

## Children interaction in lanes

* You can resize the child node within swimlanes.
* You can drag the child nodes within lane.
* You can interchange the child nodes from one lane to another lane.
* Drag and drop the child nodes from lane to the diagram.
* Drag and drop the child nodes from diagram to the lane.
* Based on the child node interactions,the lane size will be updated.

The following image show children interaction in lane.

![Lane Children Interaction](../Swimlane-images/Child_Interaction.gif)
