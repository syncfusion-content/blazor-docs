
# Accessibility

Linear Gauge provides built-in compliance with the [WAI-ARIA](http://www.w3.org/WAI/PF/aria-practices/) specifications. The
WAI-ARIA accessibility supports are achieved through the attributes like `aria-label`. It helps to provide information about elements in a document for assistive technologies.

<b>Aria-label</b>

This attribute provides the text label with some default description for the following elements in Linear Gauge.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Element</b></td>
<td><b>Default description</b></td>
</tr>
<tr>
<td>Gauge title</td>
<td>Reads the linear gauge title</td>
</tr>
<tr>
<td>Pointer value</td>
<td>Reads the value of the pointer</td>
</tr>
</table>

You can change this default description, using the `Description` property available in [`LinearGaugePointer`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.LinearGauge.LinearGaugePointer_members.html) and the [`SfLinearGauge`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.LinearGauge.SfLinearGauge_members.html) tag. It helps the screen reader to read for assistive purpose.