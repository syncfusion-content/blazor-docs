---
layout: post
title: Templates in Blazor Tree Grid Component | Syncfusion 
description: Learn about Templates in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Templates

Blazor has templated components which accepts one or more UI segments as input that can be rendered as part of the component during component rendering. Tree Grid is a templated razor component, that allow you to customize various part of the UI using template parameters. It allow you to render custom components or content based on your own logic.

The available template options in tree grid are as follows,

* [`Column template`](./columns/#column-template) - Used to customize cell content.
* [`Header template`](./columns/#header-template) - Used to customize header cell content.
* [`Row template`](./rows/#row-template) - Used to customize row content.
* [`Detail template`](./rows/#detail-template) - Used to customize the detail cell content.

## Template ModelType

To use templates, the tree grid must be bound with named model. This can be done by specifying the model type using the `ModelType` property of the tree grid component as follows.

{% highlight csharp %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid ModelType="@model" Height="400" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0">
    <TreeGridColumns>
        <TreeGridColumn Field="Name" HeaderText="Name" Width="160">
            <HeaderTemplate>
                <div class="rating">
                    <span class="star"></span> DOB
                </div>
            </HeaderTemplate>
        </TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="EmpID" HeaderText="Progress" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Country" HeaderText="Priority" Width="100"></TreeGridColumn>
        </TreeGridColumns>
</SfTreeGrid>

<style>
    .rating .star:before {
        content: '★';
    }
</style>

@code{
    public Employee model = new Employee();
    public IEnumerable<Employee> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = Employee.GetTemplateData();
    }
}

{% endhighlight %}

The following output is displayed as a result of the above code example.

![Template ModelType](images/temptype.png)

## Template Context

Most of the templates used by tree grid are of type `RenderFragment<T>` and they will be passed with parameters. You can access the parameters passed to the templates using implicit parameter named `context`. You can also change this implicit parameter name using `Context` attribute.

For example, you can access the data of the column template using `context` as follows.

{% highlight csharp %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeGrid ModelType="@model" Height="400" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0">
    <TreeGridColumns>
        <TreeGridColumn Field="Name" HeaderText="Name" Width="160"></TreeGridColumn>
        <TreeGridColumn HeaderText="Employee Image" Width="80">
            <Template>
                @{
                    var employee = (context as Employee);
                    <div class="image">
                        <img src="@UriHelper.ToAbsoluteUri($"images/TreeGrid/{employee.Name}.png")" alt="@employee.EmployeeID" />
                    </div>
                }
            </Template>
        </TreeGridColumn>
        <TreeGridColumn Field="DOB" HeaderText="DOB" Width="10" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Format="yMd"></TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="EmpID" HeaderText="Progress" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Country" HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public Employee model = new Employee();
    public IEnumerable<Employee> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = Employee.GetTemplateData();
    }
}

{% endhighlight %}

The following output is displayed as a result of the above code example.

![Template Context](images/columntemp.png)

## TreeGridTemplates component

If a component contains any `RenderFragment` type property then it does not allow any child components other than the render fragment property, which is [`by design in Blazor`](https://github.com/aspnet/AspNetCore/issues/10836).

This prevents us from directly specifying templates such as `RowTemplate` and `DetailTemplate` as descendent of Tree Grid component. Hence the templates such as `RowTemplate` and `DetailTemplate` should be wrapped around a component named `TreeGridTemplates` as follows.

{% highlight csharp %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeGrid ModelType="@model" Height="335" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0" RowHeight="83" GridLines="@GridLine.Vertical">
    <TreeGridTemplates>
        <RowTemplate>
           @{
            var employee = (context as Employee);

            <td style='padding-left:18px; border-bottom: 0.5px solid #e0e0e0;'>
                <div>@employee.EmpID</div>
            </td>
            <td style='padding: 10px 0px 0px 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div style="font-size:14px;">
                    @employee.FullName
                </div>
            </td>
            <td style="border-bottom: 0.5px solid #e0e0e0;">
                <div>
                    <div style="position:relative;display:inline-block;">
                        <img src="@UriHelper.ToAbsoluteUri($"images/" + employee.Name + ".png")" alt="@employee.Name" />
                    </div>
                    <div style="display:inline-block;">
                        <div style="padding:5px;">@employee.Address</div>
                        <div style="padding:5px;">@employee.Country</div>
                        <div style="padding:5px;font-size:12px;">@employee.Contact</div>
                    </div>
                </div>
            </td>
            <td style='padding-left: 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div>@employee.Designation</div>
            </td>
          }
        </RowTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="EmpID" HeaderText="Employee ID" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Name" HeaderText="Employee Name"></TreeGridColumn>
        <TreeGridColumn Field="Address" HeaderText="Employee Details" Width="340" TextAlign="@TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public Employee model = new Employee();
    public IEnumerable<Employee> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = Employee.GetTemplateData();
    }
}

{% endhighlight %}

The following output is displayed as a result of the above code example.

![TreeGridTemplates Component](images/rowtemp.png)