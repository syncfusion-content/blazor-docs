---
layout: post
title: Serialization in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Serialization in Syncfusion Blazor Diagram component and much more.
platform: Blazor
control: Diagram
documentation: ug
---

> Syncfusion recommends using [Blazor Diagram Component](https://blazor.syncfusion.com/documentation/diagram-component/getting-started) which provides better performance than this diagram control. Blazor Diagram Component will be actively developed in the future.

# Serialization in Blazor Diagram Component

**Serialization** is the process of saving and loading for state persistence of the diagram.

## Save

The diagram is serialized as string while saving. The server-side method, [SaveDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_SaveDiagram) helps to serialize the diagram as a string. The following code illustrates how to save the diagram.


```csharp
SfDiagram Diagram;
//Returns serialized string of the Diagram.
string Data = await  this.Diagram.SaveDiagram();
```

This string can be converted to JSON data and stored for future use. The following snippet illustrates how to save the serialized string into local storage.

```csharp
localStorage.setItem('fileName', saveData);
saveData = localStorage.getItem('fileName');

```

Diagram can also be saved as raster or vector image files. For more information about saving the diagram as images, refer to [Print and Export](./export).


## Load

Diagram is loaded from the serialized string data by server-side method, [LoadDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html#Syncfusion_Blazor_Diagrams_SfDiagram_LoadDiagram_System_String_). The following code illustrates how to load the diagram from serialized string data.

```csharp
SfDiagram Diagram;

//Returns serialized string of the Diagram.
string Data = await this.Diagram.SaveDiagram();

//Loads the Diagram from saved json data.
this.Diagram.LoadDiagram(this.Data);
```

> Before loading a new diagram, existing diagram is cleared.

## Prevent default values
The diagram provides supports to simplify the saved JSON object without adding the default properties that are presented in the diagram. The following code illustrates how to simplify the JSON object.

```cshtml
@using Syncfusion.Blazor.Diagrams

@* Initialize diagram *@
<SfDiagram Height="600px">
    <DiagramSerializationSettings PreventDefaults="true"></DiagramSerializationSettings>
</SfDiagram>
```