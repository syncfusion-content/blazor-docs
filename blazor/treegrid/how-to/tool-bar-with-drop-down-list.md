---
layout: post
title: How to Tool Bar With Drop Down List in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Tool Bar With Drop Down List in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Create custom toolbar with drop-down list

You can create your own ToolBar items in the Tree Grid. It can be added by defining the [`Toolbar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar). Actions for this ToolBar template items are defined in the [`ToolbarClick`]

**Step 1**:

Initialize the template for your custom component. Using the following code add the DropDownList component to the ToolBar.

```csharp
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfDropDownList TValue="string" TItem="Select" DataSource=@LocalData Width="200">
                        <DropDownListFieldSettings Text="text" Value="text"> </DropDownListFieldSettings>
                        <DropDownListEvents TValue="string" ValueChange="OnChange" TItem="Select"> </DropDownListEvents>
                    </SfDropDownList>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
```

**Step 2**:

To render the DropDownList component, use the [`DropDownListEvents`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-1.html)
You can select the Tree Grid row index based on the selected data in the DropDownList. The output will appear as follows.

{% aspTab template="tree-grid/how-to/toolbar-drop-down", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

Output be like the below.
![`Final output`](../images/custom-toolbar-dd.PNG)