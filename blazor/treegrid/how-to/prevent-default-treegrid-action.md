# Prevent default Tree Grid action

The default Tree Grid actions can be prevented by cancelling them in the [`OnActionBegin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionBegin) event.

This is demonstrated in the below sample code where the `Add` operation is prevented by setting `Cancel` argument value of the [`OnActionBegin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionBegin) event to **false**,

{% aspTab template="tree-grid/how-to/prevent-action", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}