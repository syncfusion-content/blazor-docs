using System;
using System.Linq;
using MultiSelect_RefreshDataAsync.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Syncfusion.Blazor.Data;
using System.Linq.Dynamic.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiSelect_WebAPIMultiSelect_WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        public OrderDataAccessLayer OrderService = new OrderDataAccessLayer();
        // GET: api/Default
        [HttpGet]
        public async Task<object> Get(int? code)
        {
            try
            {
                Microsoft.AspNetCore.Http.IQueryCollection queryString = Request.Query;
                if (queryString == null)
                    return null;
                IQueryable<Order> dataSource = OrderService.GetAllOrders();
                int countAll = dataSource.Count();
                StringValues sSkip, sTake, sFilter, sSort;
                int skip = (queryString.TryGetValue("$skip", out sSkip)) ? Convert.ToInt32(sSkip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out sTake)) ? Convert.ToInt32(sTake[0]) : countAll;

                string filter = (queryString.TryGetValue("$filter", out sFilter)) ? sFilter[0] : null;    //filter query   
                List<DynamicLinqExpression.Filter> listFilter = ParsingFilterFormula.PrepareFilter(filter);
                if (listFilter.Count() > 0)
                {
                    Expression<Func<Order, bool>> deleg = DynamicLinqExpression.ExpressionBuilder.GetExpressionFilter<Order>(listFilter);
                    dataSource = dataSource.Where(deleg);
                }


                string sort = (queryString.TryGetValue("$orderby", out sSort)) ? sSort[0] : null;         //sort query
                if (sort != null)
                {
                    string s = DynamicLinqExpression.GetSortString(sort);
                    if (s == null)
                        return null;
                    else if (s.Length > 0)
                    {
                        dataSource = dataSource.OrderBy(s);
                    }
                }
                int countFiltered = dataSource.Count();
                dataSource = dataSource.Skip(skip).Take(top);
                if (queryString.Keys.Contains("$inlinecount"))
                    return new { Items = dataSource, Count = countFiltered };
                else
                    return dataSource;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }


    //========== parsing the filter formula
    class ParsingFilterFormula
    {
        public static List<DynamicLinqExpression.Filter> PrepareFilter(string filter)
        {
            /* possible filters from SfGrid:
            startswith(tolower(Street),'sa')
            endswith(tolower(Zip),'1')
            substringof('11',tolower(Zip))
            tolower(Zip) eq '0-11'
            tolower(Zip) ne '0-11'
            Timestamp lt null
                lt, le, gt, ge

            multiple:  (startswith(tolower(Street),'sa')) and (startswith(tolower(Country),'xy'))
            */
            const string patt_startswith = "startswith(";
            const string patt_endswith = "endswith(";
            const string patt_substringof = "substringof(";
            const string patt_tolower = "tolower(";

            try
            {
                if (filter == null || filter.Length < 2)
                    return new List<DynamicLinqExpression.Filter>();

                List<DynamicLinqExpression.Filter> listFilter = new List<DynamicLinqExpression.Filter>();

                if (filter.Substring(0, 1) == "(" && filter.Substring(filter.Length - 1, 1) == ")")
                    filter = filter.Substring(1, filter.Length - 2); // remove first and last parentheses

                string[] filterparts = filter.Split(") and ("); // get parts for multiple selection
                foreach (string filterpart in filterparts)
                {
                    DynamicLinqExpression.Op operation = DynamicLinqExpression.Op.None;
                    string filterfield = "";
                    string filtervalue = "";

                    if (filterpart.Length > 2 && filterpart.Substring(filterpart.Length - 1) == ")" &&      //startswith(tolower(Street),'sa') or endswith(tolower(Zip),'1')
                        (filterpart.StartsWith(patt_startswith) || filterpart.StartsWith(patt_endswith)))
                    {
                        string s;
                        DynamicLinqExpression.Op op = DynamicLinqExpression.Op.None;
                        if (filterpart.StartsWith(patt_startswith))
                        {
                            s = filterpart.Substring(patt_startswith.Length);
                            op = DynamicLinqExpression.Op.StartsWith;
                        }
                        else
                        {
                            s = filterpart.Substring(patt_endswith.Length);
                            op = DynamicLinqExpression.Op.EndsWith;
                        }
                        // tolower(Street),'sa')
                        s = s.Substring(0, s.Length - 1);
                        // tolower(Street),'sa'
                        string[] p = s.Split(",", 2);
                        if (p.Length == 2)
                        {
                            filterfield = p[0]; // may be "tolower(Street)"
                            if (filterfield.StartsWith(patt_tolower) && filterfield.Contains(")"))
                            {
                                filterfield = filterfield.Split('(', ')')[1];
                            }
                            filtervalue = p[1];
                            if (filtervalue.Length >= 2 && filtervalue[0] == '\'')
                            {
                                filtervalue = filtervalue.Substring(1, filtervalue.Length - 2);
                            }
                            if (filtervalue.Length > 0 && filterfield.Length > 0)
                                operation = op;
                        }
                    }
                    else if (filterpart.Length > 2 && filterpart.Substring(filterpart.Length - 1) == ")" &&   //substringof('11-111',tolower(Zip))
                        filterpart.StartsWith(patt_substringof))
                    {
                        string s = filterpart.Substring(patt_substringof.Length);
                        // '11-111', tolower(Zip))
                        s = s.Substring(0, s.Length - 1);
                        // '11-111', tolower(Zip)
                        string[] p = s.Split(",", 2);
                        if (p.Length == 2)
                        {
                            filterfield = p[1]; // may be "tolower(Street)"
                            if (filterfield.StartsWith(patt_tolower) && filterfield.Contains(")"))
                            {
                                filterfield = filterfield.Split('(', ')')[1];
                            }
                            filtervalue = p[0];
                            if (filtervalue.Length >= 2 && filtervalue[0] == '\'')
                            {
                                filtervalue = filtervalue.Substring(1, filtervalue.Length - 2);
                            }
                            if (filtervalue.Length > 0 && filterfield.Length > 0)
                                operation = DynamicLinqExpression.Op.Contains;
                        }
                    }
                    else if (filterpart.Length > 2)   //tolower(Zip) eq '0-11' or Timestamp lt null
                    {
                        string s = filterpart;
                        string[] p;
                        if (s.StartsWith(patt_tolower) && s.Contains(")")) // tolower(Zip) eq '0-11'
                        {
                            s = s.Substring(patt_tolower.Length);
                            // Zip) eq '0-11'
                            p = s.Split(")", 2);
                        }
                        else // Zip eq '0-11'
                        {
                            p = s.Split(" ", 2);
                        }
                        if (p.Length == 2)
                        {
                            filterfield = p[0];
                            s = p[1].Trim(); // eq '0-11'
                            p = s.Split(" ", 2);
                            if (p.Length == 2)
                            {
                                filtervalue = p[1];
                                if (filtervalue.Length >= 2 && filtervalue[0] == '\'')
                                {
                                    filtervalue = filtervalue.Substring(1, filtervalue.Length - 2);
                                }
                                if (filtervalue.Length > 0 && filterfield.Length > 0)
                                {
                                    switch (p[0])
                                    {
                                        case "eq":
                                            operation = DynamicLinqExpression.Op.Equals;
                                            break;
                                        case "ne":
                                            operation = DynamicLinqExpression.Op.NotEquals;
                                            break;
                                        case "lt":
                                            operation = DynamicLinqExpression.Op.LessThan;
                                            break;
                                        case "le":
                                            operation = DynamicLinqExpression.Op.LessThanOrEqual;
                                            break;
                                        case "gt":
                                            operation = DynamicLinqExpression.Op.GreaterThan;
                                            break;
                                        case "ge":
                                            operation = DynamicLinqExpression.Op.GreaterThanOrEqual;
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    if (operation != DynamicLinqExpression.Op.None)
                    {
                        listFilter.Add(new DynamicLinqExpression.Filter { PropertyName = filterfield, Operation = operation, Value = filtervalue.ToString() });
                    };
                }

                return listFilter;
            }
            catch (Exception)
            {
                return new List<DynamicLinqExpression.Filter>();
            }
        }
}

    class DynamicLinqExpression
    {
        public static string GetSortString(string sSort)
        {
            try
            {
                // "SubStandard,Standard,Class desc"  ->  "SubStandard ASC, Standard ASC, Class DESC"
                string[] listSort = sSort.Split(",");
                if (listSort.Length == 0)
                    return "";

                string sOut = "";
                foreach (string s in listSort)
                {
                    if (s.Length <= 0)
                        return null; // error

                    string[] p = s.Split(" ");
                    if (p.Length < 1 || p[0].Trim().Length == 0)
                        return null; // error
                    bool bDescending = (p.Length > 1 && p[1].Contains("desc"));
                    string sortColumn = p[0];
                    if (sOut.Length > 0)
                        sOut += ", ";
                    sOut += p[0].Trim();
                    if (p.Length > 1 && p[1].Contains("desc"))
                        sOut += " DESC";
                    else
                        sOut += " ASC";
                }
                return sOut;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //==========  Build Where Clause Dynamically in Linq basing on https://www.codeproject.com/Tips/582450/Build-Where-Clause-Dynamically-in-Linq
        public enum Op
        {
            None,
            Equals,
            NotEquals,
            GreaterThan,
            LessThan,
            GreaterThanOrEqual,
            LessThanOrEqual,
            Contains,
            StartsWith,
            EndsWith
        }

        public class Filter
        {
            public string PropertyName { get; set; }
            public Op Operation { get; set; }
            public object Value { get; set; }
        }

        public static class ExpressionBuilder
        {
            private static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
            private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

            public static Expression<Func<T, bool>> GetExpressionFilter<T>(IList<Filter> filters)
            {
                if (filters.Count == 0)
                    return null;

                ParameterExpression param = Expression.Parameter(typeof(T), "t");
                Expression exp = null;

                if (filters.Count == 1)
                    exp = GetExpressionFilter<T>(param, filters[0]);
                else if (filters.Count == 2)
                    exp = GetExpressionFilter<T>(param, filters[0], filters[1]);
                else
                {
                    while (filters.Count > 0)
                    {
                        var f1 = filters[0];
                        var f2 = filters[1];

                        if (exp == null)
                            exp = GetExpressionFilter<T>(param, filters[0], filters[1]);
                        else
                            exp = Expression.AndAlso(exp, GetExpressionFilter<T>(param, filters[0], filters[1]));

                        filters.Remove(f1);
                        filters.Remove(f2);

                        if (filters.Count == 1)
                        {
                            exp = Expression.AndAlso(exp, GetExpressionFilter<T>(param, filters[0]));
                            filters.RemoveAt(0);
                        }
                    }
                }

                return Expression.Lambda<Func<T, bool>>(exp, param);
            }

            private static Expression GetExpressionFilter<T>(ParameterExpression param, Filter filter)
            {
                MemberExpression member = Expression.Property(param, filter.PropertyName);

                ParameterExpression table = Expression.Parameter(typeof(T), "");
                Expression column = Expression.PropertyOrField(table, filter.PropertyName);

                ConstantExpression constantExpression;
                if (column.Type == typeof(DateTime) || column.Type == typeof(DateTime?))
                {
                    DateTime? d = MyUtils.GetDateFromString(filter.Value.ToString());
                    constantExpression = Expression.Constant(d);
                }
                else if (column.Type == typeof(int) || column.Type == typeof(int?))
                {
                    int? i = MyUtils.StringToInt(filter.Value.ToString(), 0);
                    constantExpression = Expression.Constant(i);
                }
                else
                    constantExpression = Expression.Constant(filter.Value);

                UnaryExpression unaryExpression = Expression.Convert(constantExpression, column.Type);

                switch (filter.Operation)
                {
                    case Op.Equals:
                        return Expression.Equal(member, unaryExpression);

                    case Op.NotEquals:
                        return Expression.NotEqual(member, unaryExpression);

                    case Op.GreaterThan:
                        return Expression.GreaterThan(member, unaryExpression);

                    case Op.GreaterThanOrEqual:
                        return Expression.GreaterThanOrEqual(member, unaryExpression);

                    case Op.LessThan:
                        return Expression.LessThan(member, unaryExpression);

                    case Op.LessThanOrEqual:
                        return Expression.LessThanOrEqual(member, unaryExpression);

                    case Op.Contains:
                        return Expression.Call(member, containsMethod, unaryExpression);

                    case Op.StartsWith:
                        return Expression.Call(member, startsWithMethod, unaryExpression);

                    case Op.EndsWith:
                        return Expression.Call(member, endsWithMethod, unaryExpression);
                }

                return null;
            }

            private static BinaryExpression GetExpressionFilter<T>(ParameterExpression param, Filter filter1, Filter filter2)
            {
                Expression bin1 = GetExpressionFilter<T>(param, filter1);
                Expression bin2 = GetExpressionFilter<T>(param, filter2);

                return Expression.AndAlso(bin1, bin2);
            }
        }
    }

    public class MyUtils
    {
        public static int StringToInt(string sVal, int iDefault)
        {
            if (sVal == null)
                return iDefault;
            try
            {
                return System.Convert.ToInt32(sVal);
            }
            catch (Exception)
            {
                return iDefault;
            }
        }

        //convert string to date (string may be: 2000.12.31 or 31.12.2000 or 31.12.00 or 1.1.2001 or 1.1.01 - any delimiter)
        //if the string contains of additional time HH:MM then it is also used
        public static DateTime? GetDateFromString(string sDateTime)
        {
            DateTime dtRet = DateTime.Now;

            try
            {
                string s1 = GetDateFromStringPart(ref sDateTime);
                string s2 = GetDateFromStringPart(ref sDateTime);
                string s3 = GetDateFromStringPart(ref sDateTime);
                string s4 = GetDateFromStringPart(ref sDateTime);
                string s5 = GetDateFromStringPart(ref sDateTime);
                int vD = 0;
                int vM = 0;
                int vY = 0;
                int vHH = 0;
                int vMM = 0;

                if (s1.Length != 1 && s1.Length != 2 && s1.Length != 4 ||
                    s2.Length != 1 && s2.Length != 2 ||
                    s3.Length != 2 && s3.Length != 4 ||
                    s1.Length == 4 && s3.Length == 4)
                    return null;
                if (s1.Length == 4)
                {
                    // YYYY.MM.DD
                    vY = StringToInt(s1, -1);
                    vM = StringToInt(s2, -1);
                    vD = StringToInt(s3, -1);
                }
                else
                {
                    // DD.MM.YYYY or DD.MM.YY
                    vD = StringToInt(s1, -1);
                    vM = StringToInt(s2, -1);
                    vY = StringToInt(s3, -1);
                    if (vY < 90)
                        vY += 2000;
                    else if (vY < 100)
                        vY += 1900;
                }
                if (vD < 1 || vD > 31 || vM < 1 || vM > 12 || vY < 1990 || vY > 2090)
                    return null;

                if (s4.Length > 0 && s5.Length > 0)
                {
                    vHH = StringToInt(s4, -1);
                    vMM = StringToInt(s5, -1);
                    if (vHH < 0 || vHH > 23 || vMM < 0 || vMM > 59)
                        return null;
                }
                else
                {
                    vHH = 0;
                    vMM = 0;
                }
                dtRet = new DateTime(vY, vM, vD, vHH, vMM, 0);

                return dtRet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static string GetDateFromStringPart(ref string s)
        {
            string sPart = "";
            while (!string.IsNullOrEmpty(s) && (s[0] < '0' || s[0] > '9'))
            {
                s = s.Substring(1);
            }
            while (!string.IsNullOrEmpty(s) && s[0] >= '0' && s[0] <= '9')
            {
                sPart += s[0];
                s = s.Substring(1);
            }
            return sPart;
        }

    }


}
