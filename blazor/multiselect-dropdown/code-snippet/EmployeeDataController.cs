using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.Blazor;
using MultiSelect_RefreshDataAsync.Data;

namespace MultiSelect_RefreshDataAsync.Controller
{
    [Route("api/[controller]/{top}")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
            BindDataSource();
        }
        public static List<EmployeeData> order = new List<EmployeeData>();
        [HttpPost]
       
       
        public object Post([FromBody] DataManagerRequest dm, int top)
        {
            if (order.Count == 0)
            {
                BindDataSource();
            }
            IEnumerable DataSource = order.ToList();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<EmployeeData>().Count();
            if (dm.Skip != 0)
            {
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            if (top !=0)
            {
                DataSource = DataOperations.PerformTake(DataSource, top);
            }
            return new { result = DataSource, count = count };


        }
         private void BindDataSource()
        {           
            if (order.Count == 0)
            {
                order = Enumerable.Range(1, 9).Select(x => new EmployeeData()
                {
                    Id = x,
                    Name = new EmployeeName()
                    {
                        FirstName = x,      
                        Text = (new string[] { "ALFKI", "VINET", "BLONP", "BOLID", "WELLI" })[new Random().Next(5)],
                    },
                    Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager",
                                          "Inside Sales Coordinator","Sales Representative", "Vice President, Sales", "Sales Manager",
                                          "Inside Sales Coordinator","Sales Representative", "Vice President, Sales", "Sales Manager",
                                          "Inside Sales Coordinator","Sales Representative", "Vice President, Sales", "Sales Manager",
                                          "Inside Sales Coordinator" })[new Random().Next(7)],
                }).ToList();
            }
        }

    }
}

