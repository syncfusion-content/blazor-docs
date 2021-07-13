# Tree Grid customization

It is possible to customize the default styles of the Tree Grid component. This can be achieved by adding class dynamically to the columns using the `AddClass` method of the [`QueryCellInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_QueryCellInfo) event. Then the required styles are added to this class.

This is demonstrated in the below sample code,

{% aspTab template="tree-grid/how-to/treegrid-customization", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following image represents customized Tree Grid columns,
![`Tree Grid Customization`](../images/treegrid-customization.png)