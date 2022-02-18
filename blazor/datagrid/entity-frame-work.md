---
layout: post
title: Entity Framework in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Entity Framework in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Entity Framework in Blazor DataGrid Component

This section uses and follows the code explained in the [Entity Framework data binding](./data-binding/#entity-framework) section hence we recommend you to refer Entity framework data binding section before continuing  this section.

## Handle CRUD in data access layer class

Now add methods **AddOrder**, **UpdateOrder**, **DeleteOrder** in the **"OrderDataAccessLayer.cs"** to handle the insert, update and remove operations respectively.**CRUD** record details are bound to the **Order** parameter. Please refer the following code.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGrid.Shared.Models;

namespace EFGrid.Shared.DataAccess
{
    public class OrderDataAccessLayer
    {
        OrderContext db = new OrderContext();
        public DbSet<Order> GetAllOrders()
        {
            try
            {
                return db.Orders;
            }
            catch
            {
                throw;
            }
        }
        public void AddOrder(Order Order)
        {
            try
            {
                db.Orders.Add(Order);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateOrder(Order Order)
        {
            try
            {
                db.Entry(Order).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteOrder(int id)
        {
            try
            {
                Order ord = db.Orders.Find(id);
                db.Orders.Remove(ord);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
```

## Enable CRUD in web API

Now you have to create a new **Post**, **Put**, **Delete** method in the Web API controller which will perform the CRUD operations and returns the appropriate resultant data. The **'SfDataManager'** will make requests to this action based on route name.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using EFGrid.Shared.DataAccess;
using EFGrid.Shared.Models;

namespace WebApplication1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        OrderDataAccessLayer db = new OrderDataAccessLayer();
        [HttpGet]
        public object Get()
        {

            IQueryable<Order> data = db.GetAllOrders().AsQueryable();
            var count = data.Count();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return data;
            }
        }
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public void Post([FromBody]Order Order)
        {

            Random rand = new Random();
            db.AddOrder(Order);

        }
        [HttpPut]
        public object Put([FromBody]Order Order)
        {
            db.UpdateOrder(Order);
            return Order;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteOrder(id);
        }
    }
}
```

## Configure the datagrid to perform CRUD operations

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Normal"></GridEditSettings>
        <GridColumns>
            <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" IsIdentity="true" TextAlign="@Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
            <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="90"></GridColumn>
            <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="90"></GridColumn>
        </GridColumns>
</SfGrid>

@code{
    public class Order {
        public int? OrderID { get; set; }
        public string  CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

>You can find the fully working sample [here](https://github.com/ej2gridsamples/Blazor/blob/master/EntityFramework.zip).