---
layout: post
title: Serialization in Blazor Diagram Component | Syncfusion
description: Learn here all about how to save and load the diagram elements in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Serialization in Blazor Diagram Component

Serialization is the process of saving and loading for state persistence of the diagram.

## Save

The [diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) is serialized as string while saving. The [SaveDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SaveDiagram) method of diagram helps to serialize the diagram as a string. The following code illustrates how to save the diagram.

```cshtml
SfDiagramComponent Diagram;
//returns serialized string of the Diagram
string data = Diagram.SaveDiagram();
```

## Load

The [diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) is loaded from the serialized string data by the [LoadDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_LoadDiagram_System_String_) method of diagram. The following code illustrates how to load the diagram from serialized string data.

```cshtml
SfDiagramComponent Diagram;
//returns serialized string of the Diagram
string data = Diagram.SaveDiagram();
//Loads the Diagram from saved json data
await Diagram.LoadDiagram(data);
```

