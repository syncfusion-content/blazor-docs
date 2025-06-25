---
layout: post
title: Serialization in Blazor Diagram Component | Syncfusion
description: Learn here all about how to save and load the diagram elements in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Serialization in Blazor Diagram Component

Serialization is the process of saving and loading the persistent state of the diagram.

{% youtube "youtube:https://www.youtube.com/watch?v=2hhl00gMObc" %} 

## How to Use Two-Way Binding

When saving and loading the diagram, we must use two-way binding (such as @bind) for nodes and connectors.

```cshtml
<SfDiagramComponent @ref="@diagram" @bind-Connectors="@connectors" @bind-Nodes="@nodes"></SfDiagramComponent>
```

## How to Save the Diagram as String

While saving, the [diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) is serialized as a string. The [SaveDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SaveDiagram) method of the diagram helps to serialize the diagram as a string. The following code illustrates how to save the diagram.

```cshtml
SfDiagramComponent Diagram;
//returns the serialized string of the Diagram
string data = Diagram.SaveDiagram();
```

## How to Load the Diagram from String

The [diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) is loaded from the serialized string data using the [LoadDiagramAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_LoadDiagramAsync_System_String_System_Boolean_) method. The following code illustrates how to load the diagram from serialized string data.

```cshtml
SfDiagramComponent Diagram;
//returns the serialized string of the Diagram
string data = Diagram.SaveDiagram();
//Loads the Diagram from saved data
await Diagram.LoadDiagramAsync(data);
```

## How to Load the SfDiagram JSON Data String Using SfDiagram Component

You can load the [SfDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagrams.SfDiagram.html) serialized JSON data string into [SfDiagramComponent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) using the [LoadDiagramAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_LoadDiagramAsync_System_String_System_Boolean_) method. When you load the SfDiagram serialized string, the isClassicData parameter should be set to true. The default value of isClassicData is false.

The following code illustrates how to load the SfDiagramComponent from SfDiagram serialized string data.

```cshtml
SfDiagram ClassicDiagram;
//returns the serialized string of the SfDiagram
string data = ClassicDiagram.SaveDiagram(); 

SfDiagramComponent Diagram;
//Loads the SfDiagramComponent from saved data of the SfDiagram
await Diagram.LoadDiagramAsync(data, true);
```

## How to Save and Load the Diagram Using File Stream

The diagram provides support to save and load the diagram using a file stream. The below code illustrates how to download the saved diagram as a file.

```cshtml
    SfDiagramComponent diagram;
    private string fileName;
    private string ExtensionType = ".json";

    //Method to save the diagram
    public async Task SaveDiagram()
    {
        fileName = await jsRuntime.InvokeAsync<string>("getDiagramFileName", "");
        await DownloadDiagram(fileName);
    }

    //Method to download the diagram
    public async Task DownloadDiagram(string fileName)
    {
        string data = diagram.SaveDiagram();
        await FileUtil.SaveAs(jsRuntime, data, fileName);
    }

    //Method to load the diagram
    public async Task LoadDiagram()
    {
        diagram.BeginUpdate();
        ExtensionType = ".json";
        await FileUtil.Click(jsRuntime);
        await diagram.EndUpdateAsync();
    }

    public async static Task SaveAs(IJSRuntime js, string data, string fileName)
    {
        await js.InvokeAsync<object>(
        "saveDiagram",
        // Specify IFormatProvider
        Convert.ToString(data), fileName).ConfigureAwait(true);
        // Specify IFormatProvider
    }

    public async static Task Click(IJSRuntime js)
    {
        await js.InvokeAsync<object>(
            "click").ConfigureAwait(true);
    }

    // Js methods to auto download the file
    function getDiagramFileName(dialogName) {
    if (dialogName === 'export')
        return document.getElementById('diagramName').innerHTML.toString();
    if (dialogName === 'save')
        return document.getElementById('diagramName').value.toString();
    else
        return document.getElementById('diagramName').innerHTML.toString();
    }

    function saveDiagram(data, filename) {
    if (window.navigator.msSaveBlob) {
        let blob = new Blob([data], { type: 'data:text/json;charset=utf-8,' });
        window.navigator.msSaveOrOpenBlob(blob, filename + '.json');
    } else {
        let dataStr = 'data:text/json;charset=utf-8,' + encodeURIComponent(data);
        let a = document.createElement('a');
        a.href = dataStr;
        a.download = filename + '.json';
        document.body.appendChild(a);
        a.click();
        a.remove();
    }
    }

    function click() {
    document.getElementById('UploadFiles').click();
    }
```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Serialization/SaveAndLoad)

## How to Import and Export Using Mermaid Syntax

The [SfDiagramComponent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) supports saving diagrams in Mermaid syntax format. Mermaid is a Markdown-inspired syntax that automatically generates diagrams. With this functionality, you can easily create mind maps, flowcharts and sequence diagrams from Mermaid syntax data, simplifying the visualization of complex ideas and processes without manual drawing. Additionally, you can export your mind maps, flowcharts and sequence diagrams to Mermaid syntax, allowing for easy sharing, editing, and use across different platforms.

### How to Save Diagram as Mermaid Syntax

 The [SaveDiagramAsMermaid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SaveDiagramAsMermaid) method serializes the diagram into a Mermaid-compatible string format. This method works for diagrams using Flowchart, Mind Map or Sequence Diagram layouts. The following code illustrates how to save the diagram in Mermaid string format.

```cshtml
SfDiagramComponent Diagram;
//returns the serialized Mermaid string of the Diagram
string data = Diagram.SaveDiagramAsMermaid();
```

### How to Load Diagram from Mermaid Syntax

You can load a [diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) from the serialized Mermaid syntax data using the [LoadDiagramFromMermaidAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_LoadDiagramFromMermaidAsync_System_String_) method. The following code illustrates how to load a diagram from a Mermaid string data.

```cshtml
SfDiagramComponent Diagram;
// Retrieves the serialized Mermaid string of the Diagram
string data = Diagram.SaveDiagramAsMermaid();
// Loads the Diagram from the saved Mermaid string
await Diagram.LoadDiagramFromMermaidAsync(data);
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/MermaidSupport).

>**Note:** Mermaid syntax data serialization and deserialization are only supported for Flowchart, Mind map and Sequence Diagram layouts. Please ensure that your diagram uses one of these layouts for successful data loading.
