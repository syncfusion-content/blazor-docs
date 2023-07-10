---
layout: post
title: Interaction on cubic bezier segment | Syncfusion
description: Interaction on Cubic curve segments and editing the control points of cubic curve segments to maintain same distance and angle
platform: Blazor
control: SfDiagramComponent
documentation: ug
---

# How to interact with cubic bezier segments efficiently

While interacting with multiple cubic bezier segments, you can maintain their control points in same distance and angle by using [BezierSmoothness] property of `CubicCurveSegment` class.

| BezierSmoothness value| Description  | Output |
|---|---|---|
| SymmetricDistance| Both segments intersecting control points will be in same distance when any one them is editing | ![SymmetricDistance](../images/blazor-diagram-drag-connector.gif) |
| SymmetricAngle |Both segments intersecting control points will be in same angle when any one them is editing| ![SymmetricAngle](../images/blazor-diagram-drag-connector-end-point.gif) | 
| Symmetric | Both segments intersecting control points will be in same angle and same distance when any one them is editing|![Symmetric](../images/CloneConnector.gif) |
| None | Segemnts control points are independent to each other | ![None](../images/CloneConnector.gif) |
| None | Segemnts control points are independent to each other | ![None](../images/CloneConnector.gif) |
| None | Segemnts control points are independent to each other | ![None](../images/CloneConnector.gif) |
