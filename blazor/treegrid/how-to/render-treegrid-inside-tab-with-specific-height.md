---
layout: post
title: How to Render Treegrid Inside Tab With Specific Height in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn about Render Treegrid Inside Tab With Specific Height in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Render Tree Grid inside the Tab with specific height

By default, Tree Grid will occupy the entire space of the parent element when Tree Grid [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Width) property is defined as 100%. But if you render the similar Tree Grid inside the Tab control, it will consider the entire page and render the Tree Grid without horizontal scroller.

```csharp

@using TreeGridComponent.Data;
@using  Syncfusion.Blazor.Grids;
@using  Syncfusion.Blazor.TreeGrid;
@using Syncfusion.Blazor.Navigations

<div style="height:300px">
        <SfTab ID="Ej2Tab" Width="100%">
            <TabItems>
                <TabItem>
                    <ChildContent>
                        <TabHeader Text="Tree Grid 1"></TabHeader>
                    </ChildContent>
                    <ContentTemplate>
                        <SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
                                    TreeColumnIndex="1" Height="100%" Width="100%">
                            <TreeGridColumns>
                                <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="70" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="85"></TreeGridColumn>
                                <TreeGridColumn Field="Priority" HeaderText="Priority" Width="60"></TreeGridColumn>
                                <TreeGridColumn Field="Duration" HeaderText="Duration" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Resources" HeaderText="Resource" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Progress" HeaderText="Progress" Width="70" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                            </TreeGridColumns>
                        </SfTreeGrid>
                    </ContentTemplate>
                </TabItem>
                <TabItem>
                    <ChildContent>
                        <TabHeader Text="Tree Grid 2"></TabHeader>
                    </ChildContent>
                    <ContentTemplate>
                        <SfTreeGrid DataSource="@TreeDataSource" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true"
                                    TreeColumnIndex="1" Height="100%" Width="100%">
                            <TreeGridColumns>
                                <TreeGridColumn Field="TaskId" HeaderText="Task ID" Visible="false" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Duration" HeaderText="Duration" Width="120" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Progress" HeaderText="Progress" Width="120" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                                <TreeGridColumn Field="Resources" HeaderText="Resources" Width="120" Format="C2" TextAlign="TextAlign.Right"></TreeGridColumn>
                            </TreeGridColumns>
                        </SfTreeGrid>
                    </ContentTemplate>
                </TabItem>
            </TabItems>
        </SfTab>
    </div>


    @code{
        SfTreeGrid<TreeData> TreeGrid;

        public List<TreeData> TreeGridData { get; set; }
        public List<WrapData> TreeDataSource { get; set; }
        protected override void OnInitialized()
        {
            this.TreeGridData = TreeData.GetSelfDataSource().ToList();
            this.TreeDataSource = WrapData.GetWrapData().ToList();
        }
    }

```

Output be like the below.

![`Final output`](../images/treegrid-in-tab.PNG)