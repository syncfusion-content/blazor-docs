# Single click editing with Batch mode

You can make a cell editable on a single click with a [`Batch`](https://blazor.syncfusion.com/documentation/treegrid/edit/#batch) mode of editing in TreeGrid, by using the [`EditCell`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_EditCell_System_Double_System_String_) method.

Set the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridSelectionSettings_Mode) property of **TreeGridSelectionSettings** component to **Both** and bind the [`CellSelected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_CellSelected) event to Tree Grid. In the [`CellSelected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_CellSelected) event handler, call the [`EditCell`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_EditCell_System_Double_System_String_) method based on the clicked cell.

This is demonstrated in the below sample code,

{% aspTab template="tree-grid/how-to/single-click-edit", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following GIF represents the single click edit performed on the Tree Grid with Edit Mode as "Batch",

![Custom control in toolbar](../images/single-click-edit.gif)