---
title: " Types of data in the Blazor Range Selector component | Syncfusion "

component: "Range Selector"

description: "Learn here all about different types of data for Syncfusion Blazor Range Selector (SfRangeNavigator) component and more."
---

<!-- markdownlint-disable MD036 -->

# Types of data in the Range Selector (SfRangeNavigator)

## Numeric

The numeric scale is used to represent the numeric values of data in a Range Selector. By default, the [`ValueType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_ValueType) of a Range Selector is **Double**.

{% aspTab template="range-navigator/data/double", sourceFiles="double.razor" %}

{% endaspTab %}

![Numeric](images/data/double.png)

### Range

The minimum and the maximum of the scale will be calculated automatically based on the provided data. It can be customized by using the [`Minimum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Minimum), the [`Maximum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Maximum), and the [`Interval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Interval) properties.

{% aspTab template="range-navigator/data/range", sourceFiles="range.razor" %}

{% endaspTab %}

![Numeric range](images/data/numeric-range.png)

### Label Format

The numeric labels can be formatted using the [`LabelFormat`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelFormat) property and it supports all the globalized formats.

{% aspTab template="range-navigator/data/format", sourceFiles="format.razor" %}

{% endaspTab %}

![Numeric label format](images/data/format.png)

The following table shows the results of applying some commonly used label formats to numeric values.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format property value</b></td>
<td><b>Result </b></td>
<td><b>Description </b></td>
</tr>
<tr>
<td>1000</td>
<td>n1</td>
<td>1000.0</td>
<td>The number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>n2</td>
<td>1000.00</td>
<td>The number is rounded to 2 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>n3</td>
<td>1000.000</td>
<td>The number is rounded to 3 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p1</td>
<td>1.0%</td>
<td>The number is converted to percentage with 1 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p2</td>
<td>1.00%</td>
<td>The number is converted to percentage with 2 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p3</td>
<td>1.000%</td>
<td>The number is converted to percentage with 3 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>c1</td>
<td>$1,000.0</td>
<td>The currency symbol is appended to number and the number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>c2</td>
<td>$1,000.00</td>
<td>The currency symbol is appended to number and the number is rounded to 2 decimal places.</td>
</tr>
</table>

### Custom Label Format

The Range Selector also supports the Custom Label formats using the placeholders such as **{value}$**, in which the value represents the axis label, e.g. 20$.

{% aspTab template="range-navigator/data/custom-format", sourceFiles="custom-format.razor" %}

{% endaspTab %}

![Custom label format](images/data/custom-format.png)

## Logarithmic

<!-- markdownlint-disable MD033 -->

The Logarithmic supports the logarithmic scale, and it is used to visualize the data when the Range Selector has numerical values in both the lower (e.g.: 10-6) and the higher (e.g.: 106) orders of the magnitude.

{% aspTab template="range-navigator/data/log", sourceFiles="log.razor" %}

{% endaspTab %}

![Logarithmic](images/data/log.png)

### Range

The minimum and the maximum of the Range Selector will be calculated automatically based on the provided data. It can be customized by using the [`Minimum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Minimum), the [`Maximum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Maximum), and the [`Interval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Interval) properties.

{% aspTab template="range-navigator/data/log-range", sourceFiles="log-range.razor" %}

{% endaspTab %}

![Logarithmic range](images/data/log-range.png)

### Logarithmic Base

The Logarithmic Base can be customized using the [`LogBase`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LogBase) property. The default value of this property is **10**.

{% aspTab template="range-navigator/data/log-base", sourceFiles="log-base.razor" %}

{% endaspTab %}

![Logarithmic base](images/data/log-base.png)

## DateTime

The Range Selector supports the DateTime scale and displays the DateTime values as labels in the specified format.

{% aspTab template="range-navigator/data/date-time", sourceFiles="date-time.razor" %}

{% endaspTab %}

![DateTime](images/data/datetime.png)

### Interval Customization

The DateTime intervals can be customized using the [`Interval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Interval) and the [`IntervalType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_IntervalType) properties of the Range Selector.
For example, if the [`Interval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_Interval) is set to 2 and the [`IntervalType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_IntervalType) is set to years, the interval will be considered to be 2 years.

DateTime supports the following interval types:
* Auto
* Years
* Quarter
* Months
* Weeks
* Days
* Hours
* Minutes

{% aspTab template="range-navigator/data/date-time-interval", sourceFiles="date-time-interval.razor" %}

{% endaspTab %}

![DateTime interval type](images/data/datetime-interval.png)

### Label Format

The [`LabelFormat`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelFormat) property is used to format and parse the date to all globalize format.

{% aspTab template="range-navigator/data/date-time-format", sourceFiles="date-time-format.razor" %}

{% endaspTab %}

![DateTime label format](images/data/datetime-format.png)

The following table shows the results of applying some common DateTime formats to the [`LabelFormat`]((https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelFormat)) property.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format Property Value</b></td>
<td><b>Result </b></td>
<td><b>Description </b></td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>EEEE</td>
<td>Monday</td>
<td>The date is displayed in the day format.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>yMd</td>
<td>04/10/2000</td>
<td>The date is displayed in the month/date/year format.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td> MMM </td>
<td>Apr</td>
<td>The shorthand month for the date is displayed.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>hm</td>
<td>12:00 AM</td>
<td>The time of the date value is displayed as label.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>hms</td>
<td>12:00:00 AM</td>
<td>The label is displayed in hours:minutes:seconds format.</td>
</tr>
</table>