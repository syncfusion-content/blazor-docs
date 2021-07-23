---
layout: post
title: Individual NuGet Packages in Blazor - Syncfusion
description: Check out the documentation for Individual NuGet Packages in Blazor
platform: Blazor
component: Common
documentation: ug
---

# Individual NuGet packages for Syncfusion Blazor UI components

* Starting with v18.4.0.30 (Volume 4, 2020), the Syncfusion Blazor UI components are separately available in individual NuGet packages. The NuGet packages are segregated based on the component usage and its namespace.

* The complete NuGet package `Syncfusion.Blazor` will also be available along with individual NuGet packages. That is, we have not deprecated its support yet.

W> Do not use both `Syncfusion.Blazor` and individual NuGet packages in the same application. It will throw ambiguous errors while compiling the project.

## Benefits of using individual NuGet packages

* These individual NuGet packages are extremely useful when you are rendering Syncfusion Blazor components in Blazor WebAssembly applications. These packages will reduce the initial loading time in Blazor WebAssembly applications.

* When you install `Syncfusion.Blazor` NuGet package in a Blazor WebAssembly application, it will load the complete Syncfusion Blazor library in the web browser which takes more initial loading time. Whereas, the individual NuGet package installation will resolve this and load the required components assembly alone in the web browser.

* You can utilize the [Blazor WebAssembly lazy loading](https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-5.0) functionality with our Syncfusion Blazor individual NuGet packages.

* You can also use these individual NuGet packages in the Blazor Server application to reduce the application deployment size in production.

## Available NuGet packages

### Syncfusion.Blazor.Core

This package contains the base component, common classes, common functionalities, and interfaces for the entire Syncfusion Blazor UI components.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Core
</td>
<td>
Syncfusion.Blazor.Core.dll
</td>
<td>
SfBaseComponent
</td>
<td>
<ul>
<li><a href="https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web/" target="_blank">Microsoft.AspNetCore.Components.Web</a></li>
<li><a href="https://www.nuget.org/packages/Microsoft.CSharp/" target="_blank">Microsoft.CSharp</a></li>
<li><a href="https://www.nuget.org/packages/Newtonsoft.Json/" target="_blank">Newtonsoft.Json</a></li>
<li><a href="#syncfusionblazorthemes">Syncfusion.Blazor.Themes</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.Licensing/" target="_blank">Syncfusion.Licensing</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.BarcodeGenerator

The Blazor BarcodeGenerator supports the most common 1D and 2D barcode and complete customization of its appearance.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.BarcodeGenerator
</td>
<td>
Syncfusion.Blazor.BarcodeGenerator.dll
</td>
<td>
<ul>
<li>SfBarcodeGenerator</li>
<li>SfDataMatrixGenerator</li>
<li>SfQRCodeGenerator</li>
</ul>
</td>
<td>
<a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

### Syncfusion.Blazor.BulletChart

The Blazor Bullet Chart is used to visually compare measures, similar to the commonly used bar chart. A bullet chart displays one or more measures and compares them with a target value. You can also display the measures in a range of performance such as poor, satisfactory, and good.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.BulletChart
</td>
<td>
Syncfusion.Blazor.BulletChart.dll
</td>
<td>
SfBulletChart
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon">Syncfusion.Blazor.DataVizCommon</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Buttons

The Blazor buttons package contains UI components such as Button, Checkbox, RadioButton, Switch, and Chip component. It is easy to use and integrate within the form.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Buttons
</td>
<td>
Syncfusion.Blazor.Buttons.dll
</td>
<td>
<ul>
<li>SfButton</li>
<li>SfCheckBox</li>
<li>SfChip</li>
<li>SfRadioButton</li>
<li>SfSwitch</li>
</ul>
</td>
<td>
<a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

### Syncfusion.Blazor.Calendars

The Calendars package contains date and time components such as Calendar, DatePicker, DateRangePicker, DateTimePicker, and TimePicker. These components come with options to disable dates, restrict selection, and show custom events.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Calendars
</td>
<td>
Syncfusion.Blazor.Calendars.dll
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
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlists">Syncfusion.Blazor.Lists</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Cards

A Blazor Card is a small layout that shows a defined content in an organized structure.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Cards
</td>
<td>
Syncfusion.Blazor.Cards.dll
</td>
<td>
SfCard
</td>
<td>
<a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

### Syncfusion.Blazor.Charts

The Blazor Chart is a well-crafted charting component to visualize data. It contains a rich gallery of 30+ charts and graphs, ranging from line to financial that cater to all charting scenarios. Its high performance helps to render large amounts of data quickly. It also comes with features such as zooming, panning, tooltip, crosshair, trackball, highlight, and selection.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Charts
</td>
<td>
Syncfusion.Blazor.Charts.dll
</td>
<td>
<ul>
<li>SfAccumulationChart</li>
<li>SfChart</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.CircularGauge

The Blazor Circular Gauge is used for visualizing numeric values on a circular scale with features like multiple axes, rounded corners, and more. We can completely customize the appearance of the gauge to simulate a speedometer, meter gauge, analog clock, etc.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.CircularGauge
</td>
<td>
Syncfusion.Blazor.CircularGauge.dll
</td>
<td>
SfCircularGauge
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Data

The SfDataManager is a data management package to perform data operations such as grouping, sorting in Blazor applications. It will act as an abstraction for using local data sources like IEnumerable, Observable collections, and remote data sources like web services returning JSON, JSONP, OData.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Data
</td>
<td>
Syncfusion.Blazor.Data.dll
</td>
<td>
SfDataManager
</td>
<td>
<a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

### Syncfusion.Blazor.DataVizCommon

The Blazor DataVizCommon is the base package for the svg elements used in the visualization components like charts and range selector.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.DataVizCommon
</td>
<td>
Syncfusion.Blazor.DataVizCommon.dll
</td>
<td>
-
</td>
<td>
<a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

### Syncfusion.Blazor.Diagrams

The Blazor Diagram is used for visualization, design, and editing of interactive diagrams such as flowcharts, BPMN diagrams, and mind maps. It has seamless interaction and editing capabilities.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Diagrams
</td>
<td>
Syncfusion.Blazor.Diagrams.dll
</td>
<td>
<ul>
<li>SfDiagram</li>
<li>SfOverview</li>
<li>SfSymbolPalette</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.DropDowns

A package of Blazor Dropdown contains a collection of Dropdown components such as Dropdown List, Combo Box, AutoComplete, Multiselect Dropdown, and List Box. Dropdown components contain specific features such as data binding, grouping, sorting, filtering, and templates.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.DropDowns
</td>
<td>
Syncfusion.Blazor.DropDowns.dll
</td>
<td>
<ul>
<li>SfAutoComplete</li>
<li>SfComboBox</li>
<li>SfDropDownList</li>
<li>SfListBox</li>
<li>SfMultiSelect</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.FileManager

Blazor File Manager is a graphical user interface component used to manage the file system. It enables the user to perform common file operations such as accessing, editing, uploading, downloading, and sorting files and folders. This component also allows easy navigation for browsing or selecting a file or folder from the file system.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.FileManager
</td>
<td>
Syncfusion.Blazor.FileManager.dll
</td>
<td>
SfFileManager
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorgrid">Syncfusion.Blazor.Grid</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlayouts">Syncfusion.Blazor.Layouts</a></li>
<li><a href="#syncfusionblazorlists">Syncfusion.Blazor.Lists</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
<li><a href="#syncfusionblazorsplitbuttons">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Gantt

The Blazor Gantt is designed to visualize and edit the project schedule and track the project progress. It helps to organize and schedule the projects and also you can update the project schedule through interactions like editing, dragging, and resizing.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Gantt
</td>
<td>
Syncfusion.Blazor.Gantt.dll
</td>
<td>
SfGantt
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorfilemanager">Syncfusion.Blazor.FileManager</a></li>
<li><a href="#syncfusionblazorgrid">Syncfusion.Blazor.Grid</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlayouts">Syncfusion.Blazor.Layouts</a></li>
<li><a href="#syncfusionblazorlists">Syncfusion.Blazor.Lists</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorrichtexteditor">Syncfusion.Blazor.RichTextEditor</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
<li><a href="#syncfusionblazortreegrid">Syncfusion.Blazor.TreeGrid</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Grid

Blazor DataGrid component is used to display and manipulate the tabular data with configuration options to control the way the data is presented. It can pull data from data sources such as IEnumerable, ObservableCollection, OData web services, or DataManager and binding data fields to columns. It also displays the column header to identify the field with support for grouped records.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Grid
</td>
<td>
Syncfusion.Blazor.Grids.dll
</td>
<td>
SfGrid
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core/" target="_blank">Syncfusion.ExcelExport.Net.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.HeatMap

Blazor HeatMap Chart is used to visualize two-dimensional data in which the values are represented in gradient or fixed colors.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.HeatMap
</td>
<td>
Syncfusion.Blazor.HeatMap.dll
</td>
<td>
SfHeatMap
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.InPlaceEditor

The Blazor In-place Editor component is most useful for editing a value dynamically within its context (in-place). Its features include inline and pop-up modes, and customizable user interface (UI) and events.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.InPlaceEditor
</td>
<td>
Syncfusion.Blazor.InPlaceEditor.dll
</td>
<td>
SfInPlaceEditor
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Inputs

A package of Blazor input components. It comes with a collection of form components.  They can be used to get different input values from the users such as text, numbers, patterns, color, and file inputs.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Inputs
</td>
<td>
Syncfusion.Blazor.Inputs.dll
</td>
<td>
<ul>
<li>SfColorPicker</li>
<li>SfMaskedTextBox</li>
<li>SfNumericTextBox</li>
<li>SfSlider</li>
<li>SfTextBox</li>
<li>SfUploader</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
<li><a href="#syncfusionblazorsplitbuttons">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Kanban

The Blazor Kanban board visually depicts work at various stages of a process using columns, cards, and swimlane.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Kanban
</td>
<td>
Syncfusion.Blazor.Kanban.dll
</td>
<td>
SfKanban
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlists">Syncfusion.Blazor.Lists</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Layouts

The layout package contains Splitter and Dashboard Layout components. The Blazor DashboardLayout is a grid structured layout control that helps to create a dashboard with panels. The splitter is a layout component used to construct different layouts using multiple and nested panes that are resizable and expandable.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Layouts
</td>
<td>
Syncfusion.Blazor.Layouts.dll
</td>
<td>
<ul>
<li>SfDashboardLayout</li>
<li>SfSplitter</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.LinearGauge

The Blazor Linear Gauge is used for visualizing numeric values in a linear scale with features like multiple axes, different orientations, and more. We can completely customize the appearance of the gauge to simulate a thermometer, pressure gauge, ruler, etc.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.LinearGauge
</td>
<td>
Syncfusion.Blazor.LinearGauge.dll
</td>
<td>
SfLinearGauge
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Lists

Blazor ListView component allows you to select an item or multiple items from a list-like interface and represents the data in an interactive hierarchical structure across different layouts or views. Lists are used for displaying data, data navigation, and data entry.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Lists
</td>
<td>
Syncfusion.Blazor.Lists.dll
</td>
<td>
SfListView
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Maps

The Blazor Maps component is used for rendering maps from GeoJSON data or other map providers like OpenStreetMap, Google Maps, and Bing Maps. Its rich feature set includes markers, labels, bubbles, navigation lines, legends, tooltips, zooming, panning, drill down, and much more.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Maps
</td>
<td>
Syncfusion.Blazor.Maps.dll
</td>
<td>
SfMaps
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Navigations

A package of Blazor navigation components such as Accordion, ContextMenu, Tabs, Toolbar, TreeView, and Sidebar.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Navigations
</td>
<td>
Syncfusion.Blazor.Navigations.dll
</td>
<td>
<ul>
<li>SfAccordion</li>
<li>SfContextMenu</li>
<li>SfMenu</li>
<li>SfSidebar</li>
<li>SfTab</li>
<li>SfToolbar</li>
<li>SfTreeView</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorlists">Syncfusion.Blazor.Lists</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Notifications

The notification component Toast is used to notify status or summary information to the end-users.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Notifications
</td>
<td>
Syncfusion.Blazor.Notifications.dll
</td>
<td>
SfToast
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.PdfViewer

The Blazor PDF Viewer supports viewing and reviewing PDF files in web applications and also printing them. The thumbnail, bookmark, hyperlink, and table of contents supports provide easy navigation within and outside the PDF files. The form-filling support provides a platform to fill and print with AcroForms. The PDF files can be reviewed with the available annotation tools.

#### For Blazor WebAssembly application

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.PdfViewer
</td>
<td>
Syncfusion.Blazor.PdfViewer.dll
</td>
<td>
SfPdfViewer
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorinplaceeditor">Syncfusion.Blazor.InPlaceEditor</a></li>
<li><a href="#syncfusionblazorlists">Syncfusion.Blazor.Lists</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazornotifications">Syncfusion.Blazor.Notifications</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorsplitbuttons">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

#### For Blazor Server application

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.PdfViewerServer.Windows
</td>
<td>
Syncfusion.Blazor.PdfViewerServer.dll
</td>
<td>
SfPdfViewerServer
</td>
<td>
<ul>
<li><a href="#syncfusionblazorpdfviewer">Syncfusion.Blazor.PdfViewer</a></li>
</ul>
</td>
</tr>
</table>

> If you are developing for Linux or Mac (OSX) operating system, use the following corresponding libraries as follows:
>* For Linux, use [Syncfusion.Blazor.PdfViewerServer.Linux](https://www.nuget.org/packages/Syncfusion.Blazor.PdfViewerServer.Linux)
>* For Mac (OSX), use [Syncfusion.Blazor.PdfViewerServer.OSX](https://www.nuget.org/packages/Syncfusion.Blazor.PdfViewerServer.OSX)

### Syncfusion.Blazor.PivotTable

The Blazor Pivot Table is a powerful control used to organize and summarize business data and display the result in a cross-table format. It includes major functionalities such as data binding, drilling up and down, Excel-like filtering and sorting, editing, Excel and PDF exporting, several built-in aggregations, pivot table field list, and calculated fields.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.PivotTable
</td>
<td>
Syncfusion.Blazor.PivotTable.dll
</td>
<td>
<ul>
<li>SfPivotFieldList</li>
<li>SfPivotView</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcharts">Syncfusion.Blazor.Charts</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorgrid">Syncfusion.Blazor.Grid</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
<li><a href="#syncfusionblazorsplitbuttons">Syncfusion.Blazor.SplitButtons</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core/" target="_blank">Syncfusion.ExcelExport.Net.Core</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Popups

A package of Blazor popup components Dialog and Tooltip. The components are used to display information or get input from the users in a popup.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Popups
</td>
<td>
Syncfusion.Blazor.Popups.dll
</td>
<td>
<ul>
<li>SfDialog</li>
<li>SfTooltip</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.ProgressBar

The Progress Bar control can be used to visualize the changing status of an extended operation such as a download, file transfer, or installation. All the progress bar elements are rendered using scalable vector graphics (SVG) to ensure the quality of the visual experience.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.ProgressBar
</td>
<td>
Syncfusion.Blazor.ProgressBar.dll
</td>
<td>
SfProgressBar
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.QueryBuilder

The Blazor QueryBuilder package contains the QueryBuilder component that allows the users to create and edit filters. It supports data binding, templates, validation, and horizontal and vertical orientation.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.QueryBuilder
</td>
<td>
Syncfusion.Blazor.QueryBuilder.dll
</td>
<td>
SfQueryBuilder
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorsplitbuttons">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.RangeNavigator

The Blazor Range Navigator is an interface for selecting a small range from a larger collection. It is commonly used in financial dashboards to filter a date range for data that needs to be visualized.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.RangeNavigator
</td>
<td>
Syncfusion.Blazor.RangeNavigator.dll
</td>
<td>
SfRangeNavigator
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorcalendars">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazorcharts">Syncfusion.Blazor.Charts</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordatavizcommon">Syncfusion.Blazor.DataVizCommon</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.RichTextEditor

The Rich Text Editor component is the html and markdown editor that provides the best user experience for creating, updating, and formatting the content.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.RichTextEditor
</td>
<td>
Syncfusion.Blazor.RichTextEditor.dll
</td>
<td>
SfRichTextEditor
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorsplitbuttons">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Schedule

The Blazor Scheduler component is an event calendar that facilitates users with the common Outlook-calendar features, thus allowing them to plan and manage their events/appointments and their time in an efficient way.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Schedule
</td>
<td>
Syncfusion.Blazor.Schedule.dll
</td>
<td>
<ul>
<li>SfRecurrenceEditor</li>
<li>SfSchedule</li>
</ul>
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorcalendars">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazorinputs">Syncfusion.Blazor.Inputs</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.ExcelExport.Net.Core/" target="_blank">Syncfusion.ExcelExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.SmithChart

The Blazor Smith Chart is a control for showing the parameters of transmission lines in high-frequency circuit applications. Its rich feature set includes features like legends, markers, tooltips, and data labels.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.SmithChart
</td>
<td>
Syncfusion.Blazor.SmithChart.dll
</td>
<td>
SfSmithChart
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Sparkline

The Blazor Sparkline Charts is a replacement for normal charts to display trends in a very small area. Customize sparklines completely by changing the series or axis type and by adding markers, data labels, range bands, and more.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Sparkline
</td>
<td>
Syncfusion.Blazor.Sparkline.dll
</td>
<td>
SfSparkline
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Spinner

The Blazor Spinner is a loading indicator that denotes long-running tasks with no information about their progress. The component provides circular progress indicators without any interaction capabilities.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Spinner
</td>
<td>
Syncfusion.Blazor.Spinner.dll
</td>
<td>
SfSpinner
</td>
<td>
<a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a>
</td>
</tr>
</table>

### Syncfusion.Blazor.SplitButtons

The Blazor SplitButtons package contains UI components such as DropDownButton, SplitButton, ProgressButton, and ButtonGroup components. DropDownButton and SplitButton component display a list of items when a button is clicked and the ButtonGroup can be used for easy navigation.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.SplitButtons
</td>
<td>
Syncfusion.Blazor.SplitButtons.dll
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
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorbuttons">Syncfusion.Blazor.Buttons</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.StockChart

The Blazor Stock Chart is an easy-to-use financial charting package to track and visualize the stock price of any company over a specific period using charting and range tools. It also comes with a lot of features such as zooming, panning, tooltip, crosshair, trackball, period selector, range selector, and events to make the stock charts more interactive.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.StockChart
</td>
<td>
Syncfusion.Blazor.StockChart.dll
</td>
<td>
SfStockChart
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorcalendars">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazorcharts">Syncfusion.Blazor.Charts</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorsplitbuttons">Syncfusion.Blazor.SplitButtons</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.Themes

This package contains the Syncfusion Blazor UI components theme files.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Themes</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.Themes
</td>
<td>
Syncfusion.Blazor.Themes.dll
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

### Syncfusion.Blazor.TreeGrid

Blazor Tree Grid is a feature-rich control used to visualize self-referential and hierarchical data effectively in a tabular format. It can pull data from data sources such as an enumerable collection of records, RESTful services, OData services, WCF services, or DataManager. It also expands or collapses child data using the tree column.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.TreeGrid
</td>
<td>
Syncfusion.Blazor.TreeGrid.dll
</td>
<td>
SfTreeGrid
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazorgrid">Syncfusion.Blazor.Grid</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="#syncfusionblazorpopups">Syncfusion.Blazor.Popups</a></li>
<li><a href="#syncfusionblazorspinner">Syncfusion.Blazor.Spinner</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.TreeMap

Blazor TreeMap is a feature-rich component used to visualize both hierarchical and flat data. We can customize the look and feel of the treemaps by using the built-in features like color mapping, legends, and label templates.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.TreeMap
</td>
<td>
Syncfusion.Blazor.TreeMap.dll
</td>
<td>
SfTreeMap
</td>
<td>
<ul>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.PdfExport.Net.Core/" target="_blank">Syncfusion.PdfExport.Net.Core</a></li>
</ul>
</td>
</tr>
</table>

### Syncfusion.Blazor.WordProcessor

The Blazor Word Processor (Document Editor) is a component with editing capabilities like Microsoft Word. It is used to create, edit, view, and print Word documents. It provides all the common Word processing features including editing text, formatting contents, resizing images and tables, finding and replacing text, bookmarks, tables of contents, printing, and importing and exporting Word documents.

<table>
<tr>
<td>
<b>NuGet package name</b>
</td>
<td>
<b>Assembly name</b>
</td>
<td>
<b>Components</b>
</td>
<td>
<b>Dependencies</b>
</td>
</tr>
<tr>
<td>
Syncfusion.Blazor.WordProcessor
</td>
<td>
Syncfusion.Blazor.DocumentEditor.dll
</td>
<td>
<ul>
<li>SfDocumentEditor</li>
<li>SfDocumentEditorContainer</li>
</ul>
</td>
<td>
<ul>
<li><a href="https://www.nuget.org/packages/Newtonsoft.Json/" target="_blank">Newtonsoft.Json</a></li>
<li><a href="#syncfusionblazorcore">Syncfusion.Blazor.Core</a></li>
<li><a href="#syncfusionblazorcalendars">Syncfusion.Blazor.Calendars</a></li>
<li><a href="#syncfusionblazorcharts">Syncfusion.Blazor.Charts</a></li>
<li><a href="#syncfusionblazordata">Syncfusion.Blazor.Data</a></li>
<li><a href="#syncfusionblazordropdowns">Syncfusion.Blazor.DropDowns</a></li>
<li><a href="#syncfusionblazornavigations">Syncfusion.Blazor.Navigations</a></li>
<li><a href="https://www.nuget.org/packages/Syncfusion.WordProcessor.AspNet.Core/" target="_blank">Syncfusion.WordProcessor.AspNet.Core</a></li>
</ul>
</td>
</tr>
</table>
<!-- markdownlint-enable MD033 -->