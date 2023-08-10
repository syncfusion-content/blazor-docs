---
layout: post
title: Creating a Grid Component Using the RenderTreeBuilder Approach in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Creating a Grid Component Using the RenderTreeBuilder Approach in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Creating a Grid Component Using the RenderTreeBuilder Approach

The following code example demonstrates how to create a dynamic Grid Component using the RenderTreeBuilder approach.

```cshtml
@using Syncfusion.Blazor.Grids 
@using System.Dynamic 

<CustomComponent T="Order" DataSource="Orders" ForeignKeyData="Employees"></CustomComponent> 

@code{ 
    public List<Order> Orders { get; set; } = new List<Order>(); 
    public List<Customer> Employees { get; set; } 

    protected override void OnInitialized() 
    { 
        Orders = Enumerable.Range(1, 75).Select(x => new Order() 
            { 
                OrderID = 1000 + x, 
                EmployeeID = x, 
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)], 
                Freight = 2 * x, 
                OrderDate = DateTime.Now.AddDays(-x), 
            }).ToList(); 

        Employees = Enumerable.Range(1, 75).Select(x => new Customer() 
            { 
                EmployeeID = x, 
                FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)], 
            }).ToList(); 
    } 

    public class Order 
    { 
        public int? OrderID { get; set; } 
        public int? EmployeeID { get; set; } 
        public string CustomerID { get; set; } 
        public DateTime? OrderDate { get; set; } 
        public double? Freight { get; set; } 
    } 

    public class Customer 
    { 
        public int? EmployeeID { get; set; } 
        public string FirstName { get; set; } 
    } 
}
```

The following sample code demonstrates creating `CustomComponent` as a component, 

CustomComponent.cs

```cshtml

using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using static SfGrid_RenderTreeBuilder.Pages.Index;
using Microsoft.AspNetCore.Components.Web;

namespace SfGrid_RenderTreeBuilder.Pages
{
    public class CustomComponent<T> : SfGrid<T>
    {
        [Parameter]
        public List<T> Items { get; set; }
        [Parameter]
        public List<Customer> ForeignKeyData { get; set; }

        private SfGrid<T> GridRef { get; set; }
        public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
            {
                await this.GridRef.PdfExport();
            }
            if (args.Item.Id == "Grid_excelexport")  //Id is combination of Grid's ID and itemname
            {
                await this.GridRef.ExcelExport();
            }
        }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<SfGrid<T>>(0);
            builder.AddAttribute(1, nameof(AllowPaging), true);
            builder.AddAttribute(2, nameof(DataSource), DataSource);
            builder.AddAttribute(3, nameof(Width), "100%");
            builder.AddAttribute(4, nameof(Height), "100%");
            builder.AddAttribute(5, nameof(ID),"Grid");
            builder.AddAttribute(6, nameof(AllowPdfExport),true);
            builder.AddAttribute(7, nameof(AllowExcelExport),true);
            builder.AddAttribute(8, nameof(AllowSorting), true);
            builder.AddAttribute(9, nameof(AllowFiltering), true);
            builder.AddAttribute(10, nameof(AllowGrouping), true);
            builder.AddAttribute(11, nameof(Toolbar), new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update", "PdfExport", "ExcelExport" });

            builder.AddAttribute(12, "ChildContent", new RenderFragment(inner =>
            {
                //page settings
                inner.OpenComponent<GridPageSettings>(13);
                inner.AddAttribute(14, nameof(GridPageSettings.PageSize), Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(10));
                inner.CloseComponent();
                //editsettings 
                inner.OpenComponent<GridEditSettings>(15);
                inner.AddAttribute(16, nameof(GridEditSettings.AllowDeleting), Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(true));
                inner.AddAttribute(17, nameof(GridEditSettings.AllowEditing), Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(true));
                inner.AddAttribute(18, nameof(GridEditSettings.AllowAdding), Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(true));
                inner.AddAttribute(19, nameof(GridEditSettings.Mode), Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EditMode>(EditMode.Batch));
                inner.CloseComponent();
                //FilterSettings 
                inner.OpenComponent<GridFilterSettings>(20);
                inner.AddAttribute(21, nameof(GridFilterSettings.ShowFilterBarStatus), Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(true));
                inner.AddAttribute(22, nameof(GridFilterSettings.Type), Syncfusion.Blazor.Grids.FilterType.Excel);
                inner.CloseComponent();
                //grid events
                inner.OpenComponent<GridEvents<T>>(23);
                inner.AddAttribute<Syncfusion.Blazor.Navigations.ClickEventArgs>(24, "OnToolbarClick", EventCallback.Factory.Create<Syncfusion.Blazor.Navigations.ClickEventArgs>(this, ToolbarClickHandler));
                inner.CloseComponent();
                //grid columns
                inner.OpenComponent<GridColumns>(25);
                inner.AddAttribute(26, "ChildContent", (RenderFragment)((_builder1) =>
                {
                    int sequencestarts = 300;
                    foreach (var item in typeof(T).GetProperties())
                    {
                        if (item.Name == "EmployeeID")
                        {
                            _builder1.OpenComponent(27, typeof(Syncfusion.Blazor.Grids.GridForeignColumn<Customer>));
                            _builder1.AddAttribute(28, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(item.Name));
                            _builder1.AddAttribute(29, "ForeignKeyField", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>("EmployeeID"));
                            _builder1.AddAttribute(30, "ForeignDataSource", ForeignKeyData);
                            _builder1.AddAttribute(31, "ForeignKeyValue", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>("FirstName"));
                            _builder1.CloseComponent();
                            _builder1.AddMarkupContent(32, "\r\n");
                        }
                        else
                        {
                            _builder1.OpenComponent(33, typeof(Syncfusion.Blazor.Grids.GridColumn));
                            _builder1.AddAttribute(34, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(item.Name));
                            _builder1.AddAttribute(sequencestarts, "Width", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>("200"));
                            if (item.Name == "OrderID")
                            {
                                _builder1.AddAttribute(35, "IsPrimaryKey", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(true));
                            }
                            if (item.Name == "OrderDate")
                            {
                                sequencestarts++;
                                _builder1.AddAttribute(sequencestarts, "EditType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EditType>(EditType.DatePickerEdit));
                                sequencestarts++;
                                _builder1.AddAttribute(sequencestarts, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ColumnType>(ColumnType.DateOnly));
                                sequencestarts++;
                                _builder1.AddAttribute(sequencestarts, "Format", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>("d"));
                            }
                            _builder1.CloseComponent();
                            _builder1.AddMarkupContent(36, "\r\n");
                        }
                    }
                }));
                inner.CloseComponent();
            }));
            builder.AddComponentReferenceCapture(37, inst => { GridRef = (SfGrid<T>)inst; });
            builder.CloseComponent();
        }
    }
}
```

