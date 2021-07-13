---
layout: post
title: Swim Lane in Blazor Diagram Component | Syncfusion 
description: Learn about Swim Lane in Blazor Diagram component of Syncfusion, and more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Swimlane

Swimlane is a type of diagram nodes, which is typically used to visualize the relationship between a business process and the department responsible for it by focusing on the logical relationships between activities.

## Create a Swimlane

To create a swimlane, the type of shape should be set as `Swimlane`. By Default swimlane's are arranged vertically.

The following code example illustrates how to define a swimlane object.

### Headers

Header was the primary element for swimlanes. The `Header` property of swimlane allows you to define its textual description and to customize its appearance.

The following code example illustrates how to define a swimlane header.

```csharp
@using Syncfusion.Blazor.Diagrams

@* initialize the diagram with swimlane nodes*@
<SfDiagram Height="500px">
     <DiagramNodes>
          <DiagramNode Width="250" Height="150" OffsetX="400" OffsetY="300" Id="node1">
               @* initialize swimlane nodes*@
                    <DiagramSwimLane Type="Shapes.SwimLane">
                    @* initialize swimlane Header*@
                    <SwimLaneHeader>
                         @* initialize swimlane Header annotation*@
                         <LaneHeaderAnnotation Content="SwimLane">
                              <LaneTextStyle Bold="true" Color="Red"></LaneTextStyle>
                         </LaneHeaderAnnotation>
                    </SwimLaneHeader>
                    @* initialize swimlane phases collection*@
                    <DiagramPhases>
                         @* initialize swimlane phases*@
                              <DiagramPhase Id="phase1" Offset="170">
                              @* initialize swimlane phase header*@
                              <PhaseHeader>
                                   <PhaseHeaderAnnotation Content="Phase2"></PhaseHeaderAnnotation>
                              </PhaseHeader>
                         </DiagramPhase>
                              <DiagramPhase Id="phase2" Offset="400">
                              <PhaseHeader>
                                   <PhaseHeaderAnnotation Content="Phase2"></PhaseHeaderAnnotation>
                              </PhaseHeader>
                         </DiagramPhase>
                    </DiagramPhases>
                    <DiagramLanes>
                         <DiagramLane Id="lane1" Width="50">
                              <LaneHeader>
                                   <LaneHeaderAnnotation Content="Lane1"></LaneHeaderAnnotation>
                              </LaneHeader>
                         </DiagramLane>
                         <DiagramLane Id="lane2" Width="50">
                              <LaneHeader>
                                   <LaneHeaderAnnotation Content="Lane2"></LaneHeaderAnnotation>
                              </LaneHeader>
                         </DiagramLane>
                    </DiagramLanes>
               </DiagramSwimLane>
          </DiagramNode>
     </DiagramNodes>
</SfDiagram>
```

### Customization of headers

The height and width of swimlane header can be customized with `Weight` and `Height` properties of swimlane header. set fill color of header by using the `Style` property. The orientation of swimlane can be customized with the `Orientation` property of the header.

>Note: By default the swimlane orientation has Horizontal.

The following code example illustrates how to customize the swimlane header..

```csharp
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="500px">
     <DiagramNodes>
          <DiagramNode Width="250" Height="150" OffsetX="400" OffsetY="300" Id="node1">
          <DiagramSwimLane Type="Shapes.SwimLane">
               <SwimLaneHeader>
                    @* Customize the SwimLane header style *@
                    <LaneHeaderShapeStyle Fill="red"></LaneHeaderShapeStyle>
               </SwimLaneHeader>
               <DiagramPhases>
                    <DiagramPhase Id="phase1" Offset="170">
                         @* Customize the SwimLane header style *@
                         <PhaseShapeStyle Fill="Blue"></PhaseShapeStyle>
                         <PhaseHeader>
                              <PhaseHeaderAnnotation Content="Phase1"></PhaseHeaderAnnotation>
                         </PhaseHeader>
                    </DiagramPhase>
                    <DiagramPhase Id="phase2" Offset="400">
                         @* Customize the SwimLane header style *@
                         <PhaseShapeStyle Fill="Blue"></PhaseShapeStyle>
                         <PhaseHeader>
                              <PhaseHeaderAnnotation Content="Phase2"></PhaseHeaderAnnotation>
                         </PhaseHeader>
                    </DiagramPhase>
               </DiagramPhases>
               <DiagramLanes>
                    <DiagramLane Id="lane1" Width="50">
                         <LaneHeader>
                              <LaneHeaderAnnotation Content="Lane1"></LaneHeaderAnnotation>
                         </LaneHeader>
                    </DiagramLane>
                    <DiagramLane Id="lane2" Width="50">
                         <LaneHeader>
                              <LaneHeaderAnnotation Content="Lane2"></LaneHeaderAnnotation>
                         </LaneHeader>
                    </DiagramLane>
               </DiagramLanes>
          </DiagramSwimLane>
          </DiagramNode>
     </DiagramNodes>
</SfDiagram>
```

## Lanes

Lane is a functional unit or a responsible department of a business process that helps to map a process within the functional unit or in between other functional units.

The number of `Lanes` can be added to swimlane. The lanes are automatically stacked inside swimlane based on the order they are added.

### Create an empty lane

* The lanes `Id` is used to define the name of the lane and its further used to find the lane at runtime and do any customization.

The following code example illustrates how to define a swimlane with lane.

```csharp
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="500px">
     <DiagramNodes>
          <DiagramNode Width="250" Height="150" OffsetX="400" OffsetY="300" Id="node1">
               <DiagramSwimLane Orientation="Orientation.Horizontal" Type="Shapes.SwimLane">
                    <SwimLaneHeader Height="50"></SwimLaneHeader>
                         <DiagramPhases>
                              <DiagramPhase Id="phase1" Offset="170"></DiagramPhase>
                         </DiagramPhases>
                    <DiagramLanes>
                         <DiagramLane Id="lane1" Width="50"></DiagramLane>
                    </DiagramLanes>
               </DiagramSwimLane>
          </DiagramNode>
     </DiagramNodes>
</SfDiagram>
```

### Create lane header

* The `Header` property of lane allows you to textually describe the lane and to customize the appearance of the description.

The following code example illustrates how to define a lane header.

```csharp
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="500px">
     <DiagramNodes>
          <DiagramNode Width="250" Height="150" OffsetX="400" OffsetY="300" Id="node1">
          <DiagramSwimLane Orientation="Orientation.Horizontal" Type="Shapes.SwimLane">
               <SwimLaneHeader Height="50">
                    <LaneHeaderAnnotation Content="ONLINE PURCHASE STATUS">
                         <LaneTextStyle Bold="true" Color="#111111" FontSize="11"></LaneTextStyle>
                    </LaneHeaderAnnotation>
               </SwimLaneHeader>
               <DiagramLanes>
                    <DiagramLane Id="lane1" Width="50">
                         @* Customize the SwimLane header style *@
                         <LaneHeader>
                              <LaneHeaderAnnotation Content="CUSTOMER"></LaneHeaderAnnotation>
                         </LaneHeader>
                    </DiagramLane>
               </DiagramLanes>
          </DiagramSwimLane>
          </DiagramNode>
     </DiagramNodes>
</SfDiagram>
```

### Customizing Lane header

* The size of lane can be controlled by using the `Width` and `Height` properties of the lane.
* The appearance of the lane can be set by using the `Style` properties.

The following code example illustrates how to customize the lane header.

```csharp
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="500px">
     <DiagramNodes>
          <DiagramNode Width="250" Height="150" OffsetX="400" OffsetY="300" Id="node1">
               <DiagramSwimLane Orientation="Orientation.Horizontal" Type="Shapes.SwimLane">
                    <SwimLaneHeader Height="50">
                         <LaneHeaderAnnotation Content="ONLINE PURCHASE STATUS">
                              <LaneTextStyle Bold="true" Color="#111111" FontSize="11"></LaneTextStyle>
                         </LaneHeaderAnnotation>
                    </SwimLaneHeader>
                    <DiagramLanes>
                         <DiagramLane Id="lane1" Width="50">
                              <LaneHeader>
                                   @* Customize the SwimLane header style *@
                                   <LaneHeaderShapeStyle Fill="red"></LaneHeaderShapeStyle>
                                   <LaneHeaderAnnotation Content="CUSTOMER"></LaneHeaderAnnotation>
                              </LaneHeader>
                         </DiagramLane>
                    </DiagramLanes>
               </DiagramSwimLane>
          </DiagramNode>
     </DiagramNodes>
</SfDiagram>
```

## Phase

 Phase are the subprocess which will split each lane as horizontally or vertically based on the swimlane orientation. The multiple number of `Phase` can be added to swimlane.
The following code example illustrates how to add phase at swimlane.

```csharp
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="500px">
     <DiagramNodes>
          <DiagramNode Width="250" Height="150" OffsetX="400" OffsetY="300" Id="node1">
          <DiagramSwimLane Type="Shapes.SwimLane">
               <SwimLaneHeader Height="50"></SwimLaneHeader>
               @* Customize the SwimLane phase style *@
               <DiagramPhases>
                    <DiagramPhase Id="phase1" Offset="120"></DiagramPhase>
                    <DiagramPhase Id="phase2" Offset="200"></DiagramPhase>
               </DiagramPhases>
               <DiagramLanes>
                    <DiagramLane Id="lane1" Width="50"></DiagramLane>
               </DiagramLanes>
          </DiagramSwimLane>
          </DiagramNode>
     </DiagramNodes>
</SfDiagram>
```

### Customizing Phase

* The length of region can be set by using the `Offset` property of the phase.
* Every phase region can be textually described with the `Header` property of the phase
* You can increase the width of phase by using `PhaseSize` property of swimlane.

The following code example illustrates how to customize the phase in swimlane.

```csharp
@using Syncfusion.Blazor.Diagrams

<SfDiagram Height="500px">
     <DiagramNodes>
          <DiagramNode Width="250" Height="150" OffsetX="400" OffsetY="300" Id="node1">
          <DiagramSwimLane Type="Shapes.SwimLane">
               <SwimLaneHeader Height="50"></SwimLaneHeader>
               @* Customize the SwimLane phase style *@
               <DiagramPhases>
                    <DiagramPhase Id="phase1" Offset="120">
                         <PhaseHeader>
                              <PhaseHeaderAnnotation Content="Phase1"></PhaseHeaderAnnotation>
                         </PhaseHeader>
                    </DiagramPhase>
                    <DiagramPhase Id="phase2" Offset="200">
                         <PhaseHeader>
                              <PhaseHeaderAnnotation Content="Phase2"></PhaseHeaderAnnotation>
                         </PhaseHeader>
                    </DiagramPhase>
               </DiagramPhases>
               <DiagramLanes>
                    <DiagramLane Id="lane1" Width="50"></DiagramLane>
               </DiagramLanes>
          </DiagramSwimLane>
          </DiagramNode>
     </DiagramNodes>
</SfDiagram>

```

## Limitations

* Connectors cannot be canceled when added directly to swimlane. You must initialize the connector through connector collection.
* We cannot edit the phase line style.