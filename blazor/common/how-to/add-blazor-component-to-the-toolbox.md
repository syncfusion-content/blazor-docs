---
layout: post
title: Add Syncfusion Blazor components to the Toolbox | Syncfusion
description: Learn how to add the Syncfusion Blazor component snippets to the Visual Studio Toolbox in a Blazor project on Windows and explore here to more details.
platform: Blazor
control: Common
documentation: ug
---

# Add Syncfusion® Blazor components to the Visual Studio Toolbox

This guide explains how to add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component snippets to the Visual Studio Toolbox on Windows. By default, the Toolbox shows HTML elements and Bootstrap snippets. Open the Toolbox with <kbd>Ctrl</kbd>+<kbd>Alt</kbd>+<kbd>X</kbd> or navigate to **View → Toolbox**.

To include Syncfusion<sup style="font-size:70%">&reg;</sup> components for Blazor in the Toolbox, follow these steps:

1. Right-click anywhere within the Visual Studio Toolbox, select **Add Tab**, then name the tab (for example, "Syncfusion Blazor Components") and press Enter.

![Add new tab in toolbox](images/new-tab-toolbox.png)

2. In the code editor, write or paste a Blazor component snippet (for example, the Syncfusion<sup style="font-size:70%">&reg;</sup> `SfCalendar`). Select the entire snippet, then drag and drop it into the new tab in the Toolbox.

![Add code snippet to toolbox](images/add-snippet.gif)

3. After the snippet is added, the Toolbox assigns a default name. Right-click the item, select **Rename**, and enter a descriptive name (for example, "SfCalendar").

![Update name](images/update-name.png)

4. Drag the component from the Toolbox into the code editor to insert the snippet into your Blazor project.

N> Dragging a Toolbox item inserts code into the editor. Ensure required namespaces and services are present in the project (for example, `@using Syncfusion.Blazor` and registering Syncfusion services in Program.cs).

![Drag component to editor](images/drag-component.gif)
