---
layout: post
title: NuGet Packages List for Blazor Components | Syncfusion®
description: Learn here about the installing, managing and upgrading of NuGet packages of Blaor Components and much more details.
platform: Blazor
component: Common
documentation: ug
---

# NuGet Packages for Blazor UI components

Starting with v18.4.0.30 (Volume 4, 2020), the Blazor UI components are separately available in individual NuGet packages. The NuGet packages are segregated based on the component usage and its namespace. The complete NuGet package [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) will also be available along with the individual NuGet packages. It means its support is not deprecated yet.

W> Do not use both `Syncfusion.Blazor` and individual NuGet packages in the same application. It will throw ambiguous errors while compiling the project.

## Syncfusion.Blazor.Core

This package contains the base component, common classes, common functionalities, and interfaces for the entire Blazor UI components.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Core/" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a>
</td>
<td>
Common, Base, MediaQuery
</td>
<td>
<ul>
<li><a href="https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web/" target="_blank" aria-label="Web NuGet Package">Microsoft.AspNetCore.Components.Web</a></li>
<li><a href="https://www.nuget.org/packages/Microsoft.CSharp/" target="_blank" aria-label="CSharp NuGet Package">Microsoft.CSharp</a> (Utilized up to v20.3.0.61)</li>
<li><a href="https://www.nuget.org/packages/Newtonsoft.Json/" target="_blank" aria-label="Newtonsoft Json NuGet Package">Newtonsoft.Json</a> (Utilized up to v19.3.0.59)</li>
<li><a href="#syncfusionblazorthemes" aria-label="Blazor Theme NuGet Package">Syncfusion.Blazor.Themes</a> (Utilized up to v19.4.0.56)</li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Licensing/" target="_blank" aria-label="Syncfusion Licensing NuGet Package">Syncfusion.Licensing</a></li>
<li><a href="https://www.nuget.org/packages/System.Text.Json/" target="_blank" aria-label="Json NuGet Package">System.Text.Json</a> (Utilizing from v19.4.0.38)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.SmartComponents

The Blazor Smart Components are designed to seamlessly integrate with AI and offering intelligent features that go beyond standard user interfaces.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.SmartComponents/" aria-label="Blazor Smart Components NuGet Package">Syncfusion.Blazor.SmartComponents</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/smart-paste/getting-started" aria-label="Blazor Smart Paste Button NuGet Package">Smart Paste Button</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/smart-textarea/getting-started" aria-label="Blazor Smart TextArea NuGet Package">Smart TextArea</a></li>
</ul>
</td>
<td>
<ul>
<li>SfSmartPasteButton</li>
<li>SfSmartTextArea</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="##syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Inouts NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="https://www.nuget.org/packages/Azure.AI.OpenAI/" aria-label="Azure OpenAI NuGet Package">Azure.AI.OpenAI</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.InteractiveChat

The AI AssistView creates an interface through which users can interact with AI-driven suggestions and prompts.

<table>
    <tr>
        <td>
            <b>NuGet package</b>
        </td>
        <td>
            <b>Components friendly name</b>
        </td>
        <td>
            <b>Components name</b>
        </td>
        <td>
            <b>Dependencies</b>
        </td>
    </tr>
    <tr>
        <td><a href="https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat" aria-label="Blazor InteractiveChat NuGet Package">Syncfusion.Blazor.InteractiveChat</a></td>
        <td>
        <ul>
        <li>
        <a href="https://blazor.syncfusion.com/documentation/ai-assistview/getting-started" aria-label="Blazor AI AssitView Component">AI AssistView</a></li>
        <li><a href="https://blazor.syncfusion.com/documentation/chat-ui/getting-started" aria-label="Blazor Chat UI Component">Chat UI</a></li>
        </ul>
        </td>
        <td>
        <ul>
        <li>SfAIAssistView</li>
        <li>SfChatUI</li>
        </ul>
        </td>
        <td>
            <ul>
                <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Core/" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core </a></li>
                <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/" aria-label="Blazor Inputs NuGet Package">Syncfusion.Blazor.Inputs</a></li>
                <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/" aria-label="Blazor Navigations NuGet Package">Syncfusion.Blazor.Navigations</a></li>
                <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Notifications/" aria-label="Blazor Notifications NuGet Package">Syncfusion.Blazor.Notifications</a></li>
            </ul>
        </td>
    </tr>
</table>

## Syncfusion.Blazor.BarcodeGenerator

The Blazor BarcodeGenerator supports the most common 1D and 2D barcode, and complete customization of its appearance.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.BarcodeGenerator/" aria-label="Blazor Barcode NuGet Package">Syncfusion.Blazor.BarcodeGenerator</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/barcode/barcodegenerator" aria-label="Blazor Barcode Component">Barcode Generator</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/barcode/datamatrixgenerator" aria-label="Blazor Data Matrix Generator Component">Data Matrix Generator</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/barcode/qrcodegenerator" aria-label="Blazor QR Code Generator Component">QR Code Generator</a></li>
</ul>
</td>
<td>
<ul>
<li>SfBarcodeGenerator</li>
<li>SfDataMatrixGenerator</li>
<li>SfQRCodeGenerator</li>
</ul>
</td>
<td>
<a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

## Syncfusion.Blazor.BulletChart

The Blazor Bullet Chart is used to visually compare measures, similar to the commonly used bar chart. A bullet chart displays one or more measures, and compares them with a target value. The measures can be displayed in a range of performance such as poor, satisfactory, and good.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.BulletChart/" aria-label="Blazor BulletChart NuGet Package">Syncfusion.Blazor.BulletChart</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/bullet-chart/getting-started-with-web-app" aria-label="Blazor Bullet Chart Component">Bullet Chart</a>
</td>
<td>
SfBulletChart
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a> (Utilizing from v19.1.0.54)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Buttons

The Blazor buttons package contains UI components such as Button, Checkbox, RadioButton, Switch, and Chip component. It is easy to use and integrate within the form.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Buttons/" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/button/getting-started-with-web-app" aria-label="Blazor Button Component">Button</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/check-box/getting-started-with-web-app" aria-label="Blazor CheckBox Component">CheckBox</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/chip/getting-started-with-web-app" aria-label="Blazor Chip Component">Chip</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/floating-action-button/getting-started-with-web-app" aria-label="Blazor Floating Action Button Component">Floating Action Button</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/radio-button/getting-started-webapp" aria-label="Blazor RadioButton Component">RadioButton</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/speeddial/getting-started-webapp" aria-label="Blazor Speed Dial Component">Speed Dial</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started-webapp" aria-label="Blazor Toggle Switch Button Component">Toggle Switch Button</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/appearance/icons" aria-label="Blazor Icons Library">Icon</a></li>
</ul>
</td>
<td>
<ul>
<li>SfButton</li>
<li>SfCheckBox</li>
<li>SfChip</li>
<li>SfFab</li>
<li>SfRadioButton</li>
<li>SfSpeedDial</li>
<li>SfSwitch</li>
<li>SfIcon</li>
</ul>
</td>
<td>
<a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

## Syncfusion.Blazor.Calendars

The Calendars package contains date and time components such as Calendar, DatePicker, DateRangePicker, DateTimePicker, and TimePicker. These components come with options to disable dates, restrict selection, and show custom events.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/calendar/getting-started-with-web-app" aria-label="Blazor Calendar Component">Calendar</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/datepicker/getting-started-with-web-app" aria-label="Blazor DatePicker Component">DatePicker</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/daterangepicker/getting-started-with-web-app" aria-label="Blazor DateRangePicker Component">DateRangePicker</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/datetime-picker/getting-started-with-web-app" aria-label="Blazor DateTimePicker Component">DateTime Picker</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/timepicker/getting-started-webapp" aria-label="Blazor TimePicker Component">Time Picker</a></li>
</ul>
</td>
<td>
<ul>
<li>SfCalendar</li>
<li>SfDatePicker</li>
<li>SfDateRangePicker</li>
<li>SfDateTimePicker</li>
<li>SfTimePicker</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Inputs NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlists" aria-label="Blazor List NuGet Package">Syncfusion.Blazor.Lists</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Cards

A Blazor Card is a small layout that shows a defined content in an organized structure.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Cards/" aria-label="Blazor Card NuGet Package">Syncfusion.Blazor.Cards</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/card/getting-started-with-web-app" aria-label="Blazor Card Component">Card</a>
</td>
<td>
SfCard
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a> (Utilizing from v19.1.0.54)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Charts

The Blazor Chart is a well-crafted charting component to visualize data. It contains a rich gallery of 30+ charts and graphs, ranging from line to financial that cater to all charting scenarios. Its high performance helps to render large amounts of data quickly. It also comes with features such as zooming, panning, tooltip, crosshair, trackball, highlight, and selection.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Charts/" aria-label="Blazor Chart NuGet Package">Syncfusion.Blazor.Charts</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/chart/getting-started-with-web-app" aria-label="Blazor Chart Component">Charts</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/accumulation-chart/getting-started-with-web-app" aria-label="Blazor Accumulation Chart Component">Accumulation Chart</a></li>
</ul>
</td>
<td>
<ul>
<li>SfAccumulationChart</li>
<li>SfChart</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.ChartWizard

The Blazor Chart Wizard is an interactive chart creation and customization component for Blazor applications. It helps users configure chart types, data mappings, styling, and formatting with real-time preview.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.ChartWizard" aria-label="Blazor ChartWizard NuGet Package">Syncfusion.Blazor.ChartWizard</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/chart-wizard/getting-started-with-web-app" aria-label="Blazor ChartWizard Component">Chart Wizard</a></li>
</ul>
</td>
<td>
<ul>
<li>SfChartWizard</li>
</ul>
</td>
<td>
<ul>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Buttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Charts" aria-label="Blazor Chart NuGet Package">Syncfusion.Blazor.Charts</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Core" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Data" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.DataVizCommon" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns" aria-label="Blazor DropDowns NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Grid" aria-label="Blazor Grid NuGet Package">Syncfusion.Blazor.Grid</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Inputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Navigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.SplitButtons" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core" aria-label="Syncfusion ExcelExport NuGet Package">Syncfusion.ExcelExport.Net.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Chart3D

The Blazor 3D Chart is a graphical representation of data in three dimensions, showcasing relationships and trends among variables.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Chart3D" aria-label="Blazor Chart3D NuGet Package">Syncfusion.Blazor.Chart3D</a></td>
<td><a href="https://blazor.syncfusion.com/documentation/3d-chart/getting-started-with-web-app" aria-label="Blazor 3D Chart Component">3D Chart</a></td>
<td>SfChart3D</td>
<td>
<ul>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Core/" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Data/" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.DataVizCommon/" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core/" aria-label="Syncfusion ExcelExport NuGet Package">Syncfusion.ExcelExport.Net.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.CircularGauge

The Blazor Circular Gauge is used for visualizing numeric values on a circular scale with features like multiple axes, rounded corners, and more. The appearance of the gauge can be completely customized to simulate a speedometer, meter gauge, analog clock, etc.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.CircularGauge/" aria-label="Blazor Circular Gauge NuGet Package">Syncfusion.Blazor.CircularGauge</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/circular-gauge/getting-started-with-web-app" aria-label="Blazor Circular Gauge Component">Circular Gauge</a>
</td>
<td>
SfCircularGauge
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Data

The SfDataManager is a data management package to perform data operations such as grouping, sorting in Blazor applications. It will act as an abstraction for using local data sources like IEnumerable, Observable collections, and remote data sources like web services returning JSON, JSONP, OData.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Data/" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/data/getting-started-with-web-app" aria-label="Blazor DataManager Component">DataManager</a>
</td>
<td>
SfDataManager
</td>
<td>
<a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

## Syncfusion.Blazor.DataForm

The Blazor DataForm is a powerful UI component that simplifies the creation of dynamic and interactive forms in your applications. It offers flexible layout options, data binding capabilities, and supports various input types, making it easy to design user-friendly and efficient forms with features like validation and conditional logic.

<table>
<tr>
<td><b>NuGet package</b></td>
<td><b>Components friendly name</b></td>
<td><b>Components name</b></td>
<td><b>Dependencies</b></td>
</tr>
<tr>
<td><a href="https://www.nuget.org/packages/Syncfusion.Blazor.DataForm" aria-label="Blazor DataForm NuGet Package">Syncfusion.Blazor.DataForm</a></td>
<td><a href="https://blazor.syncfusion.com/documentation/data-form/getting-started-with-web-app" aria-label="Blazor DataForm Component">DataForm</a></td>
<td>SfDataForm</td>
<td>
<ul>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.DataVizCommon

The Blazor DataVizCommon is the base package for the svg elements used in the visualization components like charts and range selector.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.DataVizCommon/" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a>
</td>
<td>
-
</td>
<td>
<a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

## Syncfusion.Blazor.DropDowns

A package of Blazor Dropdown contains a collection of Dropdown components such as Dropdown List, Combo Box, AutoComplete, Multiselect Dropdown, and List Box. Dropdown components contain specific features such as data binding, grouping, sorting, filtering, and templates.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns/" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/autocomplete/getting-started-with-web-app" aria-label="Blazor AutoComplete Component">AutoComplete</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/combobox/getting-started-with-web-app" aria-label="Blazor ComboBox Component">ComboBox</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app" aria-label="Blazor DropDown List Component">DropDown List</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/listbox/getting-started-webapp" aria-label="Blazor ListBox Component">ListBox</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/multiselect-dropdown/getting-started-webapp" aria-label="Blazor MultiSelect DropDown Component">MultiSelect DropDown</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/mention/getting-started-webapp" aria-label="Blazor Mention Component">Mention</a></li>
</ul>
</td>
<td>
<ul>
<li>SfAutoComplete</li>
<li>SfComboBox</li>
<li>SfDropDownList</li>
<li>SfListBox</li>
<li>SfMultiSelect</li>
<li>SfMention</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornotifications" aria-label="Blazor Notification NuGet Package">Syncfusion.Blazor.Notifications</a> (Utilizing from v21.1.35)</li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.FileManager

Blazor File Manager is a graphical user interface component used to manage the file system. It enables the user to perform common file operations such as accessing, editing, uploading, downloading, and sorting files and folders. This component also allows easy navigation for browsing or selecting a file or folder from the file system.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.FileManager/" aria-label="Blazor FileManager NuGet Package">Syncfusion.Blazor.FileManager</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/file-manager/getting-started-with-web-app" aria-label="Blazor FileManager Component">FileManager</a>
</td>
<td>
SfFileManager
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorgrid" aria-label="Blazor DataGrid NuGet Package">Syncfusion.Blazor.Grid</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlayouts" aria-label="Blazor Layout NuGet Package">Syncfusion.Blazor.Layouts</a></li>
<li><a href="#syncfusionblazorlists" aria-label="Blazor List NuGet Package">Syncfusion.Blazor.Lists</a></li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
<li><a href="#syncfusionblazorsplitbuttons" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Grid

Blazor DataGrid component is used to display and manipulate the tabular data with configuration options to control the way the data is presented. It can pull data from data sources such as IEnumerable, ObservableCollection, OData web services, or DataManager and binding data fields to columns. It also displays the column header to identify the field with support for grouped records.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Grid/" aria-label="Blazor DataGrid NuGet Package">Syncfusion.Blazor.Grid</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app" aria-label="Blazor DataGrid Component">DataGrid</a>
</td>
<td>
SfGrid
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core/" target="_blank" aria-label="Syncfusion ExcelExport NuGet Package">Syncfusion.ExcelExport.Net.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.HeatMap

Blazor HeatMap Chart is used to visualize two-dimensional data in which the values are represented in gradient or fixed colors.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.HeatMap/" aria-label="Blazor HeatMap NuGet Package">Syncfusion.Blazor.HeatMap</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/heatmap-chart/getting-started-with-web-app" aria-label="Blazor HeatMap Chart Component">HeatMap Chart</a>
</td>
<td>
SfHeatMap
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a> (Utilizing from v19.1.0.54)</li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a> (Utilizing from v19.1.0.54)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.InPlaceEditor

The Blazor In-place Editor component is most useful for editing a value dynamically within its context (in-place). Its features include inline and pop-up modes, and customizable user interface (UI) and events.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.InPlaceEditor/" aria-label="Blazor InPlacEditor NuGet Package">Syncfusion.Blazor.InPlaceEditor</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/in-place-editor/getting-started-with-web-app" aria-label="Blazor InPlaceEditor Component">In-place Editor</a>
</td>
<td>
SfInPlaceEditor
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.ImageEditor

The Blazor Image Editor component loads and modifies the images by performing actions like cropping, rotating, resizing, applying filters, inserting text and shapes such as rectangles, circles, and arrows on top of an image, and drawing freehand.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.ImageEditor/" aria-label="Blazor ImageEditor NuGet Package">Syncfusion.Blazor.ImageEditor</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/image-editor/getting-started-with-web-app" aria-label="Blazor ImageEditor Component">Image Editor</a>
</td>
<td>
SfImageEditor
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorsplitbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.SplitButtons</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Inputs

A package of Blazor input components comes with a collection of form components. They can be used to get different input values from the users such as text, numbers, patterns, color, and file inputs.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/color-picker/getting-started-with-web-app" aria-label="Blazor Color Picker Component">Color Picker</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/input-mask/getting-started-with-web-app" aria-label="Blazor Input Mask Component">Input Mask</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started-webapp" aria-label="Blazor Numeric TextBox Component">Numeric TextBox</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/rating/getting-started-webapp" aria-label="Blazor Rating Component">Rating</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/range-slider/getting-started-webapp" aria-label="Blazor Range Slider Component">Range Slider</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/textbox/getting-started-webapp" aria-label="Blazor TextBox Component">TextBox</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/file-upload/getting-started-with-web-app" aria-label="Blazor File Upload Component">File Upload</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/signature/getting-started-webapp" aria-label="Blazor Signature Component">Signature</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/textarea/getting-started-webapp" aria-label="Blazor TextArea Component">TextArea</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/otp-input/getting-started-webapp" aria-label="Blazor OTP Input Component">OTP Input</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/speech-to-text/getting-started-web-app" aria-label="Blazor Speech To Text Component">Speech To Text</a></li>
</ul>
</td>
<td>
<ul>
<li>SfColorPicker</li>
<li>SfMaskedTextBox</li>
<li>SfNumericTextBox</li>
<li>SfRating</li>
<li>SfSlider</li>
<li>SfTextBox</li>
<li>SfUploader</li>
<li>SfSignature</li>
<li>SfTextArea</li>
<li>SfOtpInput</li>
<li>SfSpeechToText</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
<li><a href="#syncfusionblazorsplitbuttons" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Kanban

The Blazor Kanban board visually depicts work at various stages of a process using columns, cards, and swimlane.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Kanban/" aria-label="Blazor Kanban NuGet Package">Syncfusion.Blazor.Kanban</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/kanban/getting-started-with-web-app" aria-label="Blazor Kanban Component">Kanban</a>
</td>
<td>
SfKanban
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlists" aria-label="Blazor List NuGet Package">Syncfusion.Blazor.Lists</a> (Utilized up to v19.2.0.62)</li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a> (Utilized up to v19.3.0.43)</li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Layouts

The layout package contains Splitter and Dashboard Layout components. The Blazor DashboardLayout is a grid structured layout control that helps to create a dashboard with panels. The splitter is a layout component used to construct different layouts using multiple and nested panes that are resizable and expandable.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Layouts/" aria-label="Blazor Layout NuGet Package">Syncfusion.Blazor.Layouts</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/dashboard-layout/getting-started-with-web-app" aria-label="Blazor Dashboard Layout Component">Dashboard Layout</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/splitter/getting-started-webapp" aria-label="Blazor Splitter Component">Splitter</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/timeline/getting-started-webapp" aria-label="Blazor Timeline Component">Timeline</a></li>
</ul>
</td>
<td>
<ul>
<li>SfDashboardLayout</li>
<li>SfSplitter</li>
<li>SfTimeline</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.LinearGauge

The Blazor Linear Gauge is used for visualizing numeric values in a linear scale with features like multiple axes, different orientations, and more. The appearance of the gauge can be completely customized to simulate a thermometer, pressure gauge, ruler, etc.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.LinearGauge/" aria-label="Blazor Linear Gauge NuGet Package">Syncfusion.Blazor.LinearGauge</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/linear-gauge/getting-started-webapp" aria-label="Blazor Linear Gauge Component">Linear Gauge</a>
</td>
<td>
SfLinearGauge
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Lists

Blazor ListView component allows to select an item or multiple items from a list-like interface and represents the data in an interactive hierarchical structure across different layouts or views. Lists are used for displaying data, data navigation, and data entry.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Lists/" aria-label="Blazor ListView NuGet Package">Syncfusion.Blazor.Lists</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/listview/getting-started-webapp" aria-label="Blazor ListView Component">ListView</a>
</td>
<td>
SfListView
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Maps

The Blazor Maps component is used for rendering maps from GeoJSON data or other map providers like OpenStreetMap, Google Maps, and Bing Maps. Its rich feature set includes markers, labels, bubbles, navigation lines, legends, tooltips, zooming, panning, drill down, and much more.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Maps/" aria-label="Blazor Map NuGet Package">Syncfusion.Blazor.Maps</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/maps/getting-started-webapp" aria-label="Blazor Map Component">Maps</a>
</td>
<td>
SfMaps
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.MultiColumnComboBox

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td><a href="https://www.nuget.org/packages/Syncfusion.Blazor.MultiColumnComboBox" aria-label="Blazor MultiColumn ComboBox NuGet Package">Syncfusion.Blazor.MultiColumnComboBox</a></td>
<td><a href="https://blazor.syncfusion.com/documentation/multicolumn-combobox/getting-started" aria-label="Blazor MultiColumn ComboBox Component">MultiColumn ComboBox</a></td>
<td>SfMultiColumnComboBox</td>
<td>
<ul>
    <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Core/" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
    <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Data/" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
    <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Grid/" aria-label="Blazor DataGrid NuGet Package">Syncfusion.Blazor.Grid</a></li>
    <li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Navigations

A package of Blazor navigation components such as Accordion, Context Menu, Tabs, Toolbar, TreeView, and Sidebar.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/accordion/getting-started-with-web-app" aria-label="Blazor Accordion Component">Accordion</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/appbar/getting-started-with-web-app" aria-label="Blazor AppBar Component">AppBar</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/breadcrumb/getting-started-with-web-app" aria-label="Blazor Breadcrumb Component">Breadcrumb</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/context-menu/getting-started-with-web-app" aria-label="Blazor Context Menu Component">ContextMenu</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/dropdown-tree/getting-started-with-web-app" aria-label="Blazor DropDown Tree Component">DropDown Tree</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/menu-bar/getting-started-webapp" aria-label="Blazor Menu Bar Component">Menu Bar</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/sidebar/getting-started-webapp" aria-label="Blazor Sidebar Component">Sidebar</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/stepper/getting-started-webapp" aria-label="Blazor Stepper Component">Stepper</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/tabs/getting-started-webapp" aria-label="Blazor Tab Component">Tabs</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/toolbar/getting-started-webapp" aria-label="Blazor Toolbar Component">Toolbar</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/treeview/getting-started-webapp" aria-label="Blazor TreeView Component">TreeView</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/pager/getting-started-webapp" aria-label="Blazor Pager Component">Pager</a></li>
</ul>
</td>
<td>
<ul>
<li>SfAccordion</li>
<li>SfAppBar</li>
<li>SfBreadcrumb</li>
<li>SfContextMenu</li>
<li>SfDropDownTree</li>
<li>SfMenu</li>
<li>SfSidebar</li>
<li>SfStepper</li>
<li>SfTab</li>
<li>SfToolbar</li>
<li>SfTreeView</li>
<li>SfPager</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a> (Utilizing from v20.2.0.36)</li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlists" aria-label="Blazor List NuGet Package">Syncfusion.Blazor.Lists</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a> (Utilizing from v19.3.0.43)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Notifications

The notification component Toast is used to notify status or summary information to the end-users.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Notifications/" aria-label="Blazor Notification NuGet Package">Syncfusion.Blazor.Notifications</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/toast/getting-started-webapp" aria-label="Blazor Toast Component">Toast</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/skeleton/getting-started-webapp" aria-label="Blazor Skeleton Component">Skeleton</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/message/getting-started-webapp" aria-label="Blazor Message Component">Message</a></li>
</ul>
</td>
<td>
<ul>
<li>SfToast</li>
<li>SfSkeleton</li>
<li>SfMessage</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.PivotTable

The Blazor Pivot Table is a powerful control used to organize and summarize business data and display the result in a cross-table format. It includes major functionalities such as data binding, drilling up and down, Excel-like filtering and sorting, editing, Excel and PDF exporting, several built-in aggregations, pivot table field list, and calculated fields.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.PivotTable/" aria-label="Blazor Pivot Table NuGet Package">Syncfusion.Blazor.PivotTable</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/pivot-table/getting-started-webapp" aria-label="Blazor Pivot Table Component">Pivot Table</a>
</td>
<td>
<ul>
<li>SfPivotFieldList</li>
<li>SfPivotView</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a> (Utilizing from v20.1.0.47)</li>
<li><a href="#syncfusionblazorcharts" aria-label="Blazor Chart NuGet Package">Syncfusion.Blazor.Charts</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorgrid" aria-label="Blazor DataGrid NuGet Package">Syncfusion.Blazor.Grid</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
<li><a href="#syncfusionblazorsplitbuttons" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core/" target="_blank" aria-label="Syncfusion ExcelExport NuGet Package">Syncfusion.ExcelExport.Net.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Popups

A package of Blazor popup components Dialog and Tooltip are used to display information or to get input from the users in a popup.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Popups/" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/dialog/getting-started-with-web-app" aria-label="Blazor Dialog Component">Dialog</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/predefined-dialogs/getting-started-webapp" aria-label="Blazor Predefined Dialog Component">Predefined Dialog</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/tooltip/getting-started-webapp" aria-label="Blazor Tooltip NuGet Package">Tooltip</a></li>
</ul>
</td>
<td>
<ul>
<li>SfDialog</li>
<li>SfTooltip</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.ProgressBar

The Progress Bar control can be used to visualize the changing status of an extended operation such as a download, file transfer, or installation. All the progress bar elements are rendered using scalable vector graphics (SVG) to ensure the quality of the visual experience.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.ProgressBar/" aria-label="Blazor ProgressBar NuGet Package">Syncfusion.Blazor.ProgressBar</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/progress-bar/getting-started-webapp" aria-label="Blazor ProgressBar Component">ProgressBar</a>
</td>
<td>
SfProgressBar
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.QueryBuilder

The Blazor QueryBuilder package contains the QueryBuilder component that allows the users to create and edit filters. It supports data binding, templates, validation, and horizontal and vertical orientation.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.QueryBuilder/" aria-label="Blazor QueryBuilder NuGet Package">Syncfusion.Blazor.QueryBuilder</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/query-builder/getting-started-webapp" aria-label="Blazor QueryBuilder Component">QueryBuilder</a>
</td>
<td>
SfQueryBuilder
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorsplitbuttons" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Ribbon

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Ribbon" aria-label="Blazor Ribbon NuGet Package">Syncfusion.Blazor.Ribbon</a></td>
<td><a href="https://blazor.syncfusion.com/documentation/ribbon/getting-started" aria-label="Blazor Ribbon Component">Ribbon</a></td>
<td>SfRibbon</td>
<td>
<ul>
<li><a href="https://www.nuget.org/packages/Newtonsoft.Json/" aria-label="Newtonsoft Json NuGet Package">Newtonsoft.Json</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Buttons/" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Core/" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns/" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Popups/" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.SplitButtons/" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.RangeNavigator

The Blazor Range Navigator is an interface for selecting a small range from a larger collection. It is commonly used in financial dashboards to filter a date range for data that needs to be visualized.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.RangeNavigator/" aria-label="Blazor RangeNavigator NuGet Package">Syncfusion.Blazor.RangeNavigator</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/range-selector/getting-started-webapp" aria-label="Blazor Range Selector Component">Range Selector</a>
</td>
<td>
SfRangeNavigator
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorcalendars" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazorcharts" aria-label="Blazor Chart NuGet Package">Syncfusion.Blazor.Charts</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Sankey

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Sankey" aria-label="Blazor Sankey NuGet Package">Syncfusion.Blazor.Sankey</a></td>
<td><a href="https://blazor.syncfusion.com/documentation/sankey/getting-started" aria-label="Blazor Sankey Component">Sankey</a></td>
<td>SfSankey</td>
<td>
<ul>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Core/" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.Data/" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Blazor.DataVizCommon/" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Schedule

The Blazor Scheduler component is an event calendar that facilitates users with the common Outlook-calendar features, thus allowing them to plan and manage their events/appointments and their time in an efficient way.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Schedule/" aria-label="Blazor Schedule NuGet Package">Syncfusion.Blazor.Schedule</a>
</td>
<td>
<ul>
<li><a href="https://help.syncfusion.com/scheduler-sdk/blazor/schedule/getting-started-webapp" aria-label="Blazor Scheduler Component">Scheduler</a></li>
<li>Recurrence Editor</li>
</ul>
</td>
<td>
<ul>
<li>SfRecurrenceEditor</li>
<li>SfSchedule</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns" aria-label="Blazor DropDown NuGet Package">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs" aria-label="Blazor Input NuGet Package">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core/" target="_blank" aria-label="Syncfusion ExcelExport NuGet Package">Syncfusion.ExcelExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.SmithChart

The Blazor Smith Chart is a control for showing the parameters of transmission lines in high-frequency circuit applications. Its rich feature set includes features like legends, markers, tooltips, and data labels.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.SmithChart/" aria-label="Blazor Smith Chart NuGet Package">Syncfusion.Blazor.SmithChart</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/smith-chart/getting-started-webapp" aria-label="Blazor Smith Chart Component">Smith Chart</a>
</td>
<td>
SfSmithChart
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a> (Utilizing from v19.1.0.54)</li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a> (Utilizing from v19.1.0.54)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Sparkline

The Blazor Sparkline Charts is a replacement for normal charts to display trends in a very small area. Customize sparklines completely by changing the series or axis type and by adding markers, data labels, range bands, and more.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Sparkline/" aria-label="Blazor Sparkline NuGet Package">Syncfusion.Blazor.Sparkline</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/sparkline/getting-started-webapp" aria-label="Blazor Sparkline Component">Sparkline</a>
</td>
<td>
SfSparkline
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon" aria-label="Blazor DataVizCommon NuGet Package">Syncfusion.Blazor.DataVizCommon</a> (Utilizing from v19.1.0.54)</li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a> (Utilizing from v19.2.0.48)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Spinner

The Blazor Spinner is a loading indicator that denotes long-running tasks with no information about their progress. The component provides circular progress indicators without any interaction capabilities.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Spinner/" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/spinner/getting-started-webapp" aria-label="Blazor Spinner Component">Spinner</a>
</td>
<td>
SfSpinner
</td>
<td>
<a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

## Syncfusion.Blazor.SplitButtons

The Blazor SplitButtons package contains UI components such as DropDownButton, SplitButton, ProgressButton, and ButtonGroup components. DropDownButton and SplitButton component display a list of items when a button is clicked and the ButtonGroup can be used for easy navigation.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.SplitButtons/" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a>
</td>
<td>
<ul>
<li><a href="https://blazor.syncfusion.com/documentation/button-group/getting-started-with-web-app" aria-label="Blazor ButtonGroup Component">ButtonGroup</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/drop-down-menu/getting-started-with-web-app" aria-label="Blazor DropDownButton Component">DropDownButton</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/progress-button/getting-started-webapp" aria-label="Blazor ProgressButton Component">ProgressButton</a></li>
<li><a href="https://blazor.syncfusion.com/documentation/split-button/getting-started-webapp" aria-label="Blazor SplitButton Component">SplitButton</a></li>
</ul>
</td>
<td>
<ul>
<li>SfButtonGroup</li>
<li>SfDropDownButton</li>
<li>SfProgressButton</li>
<li>SfSplitButton</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons" aria-label="Blazor Button NuGet Package">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.StockChart

The Blazor Stock Chart is an easy-to-use financial charting package to track and visualize the stock price of any company over a specific period using charting and range tools. It also comes with a lot of features such as zooming, panning, tooltip, crosshair, trackball, period selector, range selector, and events to make the stock charts more interactive.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.StockChart/" aria-label="Blazor Stock Chart NuGet Package">Syncfusion.Blazor.StockChart</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/stock-chart/getting-started-webapp" aria-label="Blazor Stock Chart Component">Stock Chart</a>
</td>
<td>
SfStockChart
</td>
<td>
<ul>
<li><a href="#syncfusionblazorrangenavigator" aria-label="Blazor RangeNavigator NuGet Package">Syncfusion.Blazor.RangeNavigator</a> (Utilizing from v19.1.0.54)</li>
<li><a href="#syncfusionblazorcalendars" aria-label="Blazor Calendar NuGet Package">Syncfusion.Blazor.Calendars</a> (Utilized up to v18.4.0.49)</li>
<li><a href="#syncfusionblazorcharts" aria-label="Blazor Chart NuGet Package">Syncfusion.Blazor.Charts</a> (Utilized up to v18.4.0.49)</li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a> (Utilized up to v18.4.0.49)</li>
<li><a href="#syncfusionblazorsplitbuttons" aria-label="Blazor SplitButton NuGet Package">Syncfusion.Blazor.SplitButtons</a> (Utilized up to v18.4.0.49)</li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.Themes

This package contains the Blazor UI components theme files.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Friendly name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.Themes/" aria-label="Blazor Theme NuGet Package">Syncfusion.Blazor.Themes</a>
</td>
<td>
<ul>
<li>Material</li>
<li>Material Dark</li>
<li>Fabric</li>
<li>Fabric Dark</li>
<li>Bootstrap</li>
<li>Bootstrap Dark</li>
<li>Bootstrap v4</li>
<li>High-Contrast</li>
</ul>
</td>
<td>
None
</td>
</tr>
</table>

## Syncfusion.Blazor.TreeGrid

Blazor Tree Grid is a feature-rich control used to visualize self-referential and hierarchical data effectively in a tabular format. It can pull data from data sources such as an enumerable collection of records, RESTful services, OData services, WCF services, or DataManager. It also expands or collapses child data using the tree column.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.TreeGrid/" aria-label="Blazor TreeGrid NuGet Package">Syncfusion.Blazor.TreeGrid</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp" aria-label="Blazor TreeGrid Component">TreeGrid</a>
</td>
<td>
SfTreeGrid
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorgrid" aria-label="Blazor DataGrid NuGet Package">Syncfusion.Blazor.Grid</a></li>
<li><a href="#syncfusionblazornavigations" aria-label="Blazor Navigation NuGet Package">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups" aria-label="Blazor Popup NuGet Package">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner" aria-label="Blazor Spinner NuGet Package">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

## Syncfusion.Blazor.TreeMap

Blazor TreeMap is a feature-rich component used to visualize both hierarchical and flat data.  The look and feel of the treemaps can be customized by using the built-in features like color mapping, legends, and label templates.

<table>
<tr>
<td>
<b>NuGet package</b>
</td>
<td>
<b>Components friendly name</b>
</td>
<td>
<b>Components name</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
<a href="https://www.nuget.org/packages/Syncfusion.Blazor.TreeMap/" aria-label="Blazor TreeMap NuGet Package">Syncfusion.Blazor.TreeMap</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/treemap/getting-started-webapp" aria-label="Blazor TreeMap Component">TreeMap</a>
</td>
<td>
SfTreeMap
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore" aria-label="Blazor Core NuGet Package">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata" aria-label="Blazor Data NuGet Package">Syncfusion.Blazor.Data</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank" aria-label="Syncfusion PdfExport NuGet Package">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

<!-- markdownlint-enable MD033 -->

## Benefits of using individual NuGet packages

* These individual NuGet packages are extremely useful while rendering Blazor components in Blazor WebAssembly applications. These packages will reduce the initial loading time in Blazor WebAssembly applications.

* While installing `Syncfusion.Blazor` NuGet package in a Blazor WebAssembly application, it will load the complete Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor library in the web browser which takes more initial loading time. Whereas, the individual NuGet package installation will resolve this and load the required components assembly alone in the web browser.

* The [Lazy load assemblies in Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-7.0) functionality can be utilized with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor individual NuGet packages.

* These individual NuGet packages can be used in the Blazor Server application to reduce the application deployment size in production.
