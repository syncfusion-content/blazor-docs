# Get the index value of selected rowcell

You can get the index value of a selected rowcell or row by using the [`GetSelectedRowCellIndexes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_GetSelectedRowCellIndexes) method of the Tree Grid component.

This is demonstrated in the below sample code where the [`GetSelectedRowCellIndexes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_GetSelectedRowCellIndexes) method is called on button click which returns the selected rowcell indexes,

{% aspTab template="tree-grid/how-to/rowcell-index", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

> For getting the rowcell index value, the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html#Syncfusion_Blazor_TreeGrid_TreeGridSelectionSettings_Mode) property of the [`TreeGridSelectionSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html) component should be set as **Cell**.