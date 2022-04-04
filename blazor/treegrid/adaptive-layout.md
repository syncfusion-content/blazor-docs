---
layout: post
title: Adaptive Layout in Blazor TreeGrid Component | Syncfusion
description: The Blazor TreeGrid will render the adaptive UI filter, sort, and edit dialogs in full screen for a better user experience.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Adaptive UI Layout in Blazor Tree Grid Component

The Tree Grid user interface (UI) was redesigned to provide an optimal viewing experience and improve usability on small screens. This interface will render the filter, sort, and edit dialogs adaptively and have an option to render the Tree Grid row elements in the vertical direction.

## Render adaptive dialog

To render adaptive dialog UI in the Tree Grid, set the [EnableAdaptiveUI](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_EnableAdaptiveUI) property to true. The Tree Grid will render the filter, sort, and edit dialogs in full screen for a better user experience.

```csharp

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids

<div class="col-lg-12 control-section">
   <div class="content-wrapper">
      <div class="row">
         <div class="content-wrapper e-bigger e-adaptive-demo">
            <div class="e-mobile-layout">
               <div class="e-mobile-content">
                        <SfTreeGrid DataSource="@TreeData" AllowSorting="true" AllowFiltering="true" IdMapping="TaskID" ParentIdMapping="ParentID" TreeColumnIndex="1" EnableAdaptiveUI="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update", "Search" })" Height="100%" Width="100%" AllowPaging="true">
                            <TreeGridFilterSettings Type="@Syncfusion.Blazor.TreeGrid.FilterType.Excel"></TreeGridFilterSettings>
                            <TreeGridPageSettings PageSize="2" PageSizeMode="PageSizeMode.Root" ></TreeGridPageSettings>
                            <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.TreeGrid.EditMode.Dialog"></TreeGridEditSettings>
                            <TreeGridColumns>
                                <TreeGridColumn Field="TaskID" HeaderText="Task ID" IsPrimaryKey="true" Width="135" ValidationRules="@(new ValidationRules() { Required = true, Number = true })" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="280" ValidationRules="@(new ValidationRules() { Required = true })" TextAlign="TextAlign.Left"></TreeGridColumn>
                                <TreeGridColumn Field="Duration" HeaderText="Duration" Width="140" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Progress" HeaderText="Progress" Width="145" EditType="Syncfusion.Blazor.Grids.EditType.DropDownEdit"></TreeGridColumn>
                            </TreeGridColumns>
                        </SfTreeGrid>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

@code{

    private List<SelfReferenceData> TreeData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeData = SelfReferenceData.GetTree().Take(30).ToList();
    }
}

```

![Blazor Tree Grid with Adaptive UI](./images/blazor-treegrid-adaptive.gif)
