---
layout: post
title: Accessibility with ADA compliance in Syncfusion Blazor components
description: The Syncfusion Blazor UI components are compliant with section 508, ADA, WAI-ARIA, WCAG, and keyboard accessibility standards.
platform: Blazor
component: Common
documentation: ug
---

# Accessibility with ADA Compliance in Syncfusion Blazor Components

All the Syncfusion Blazor components follow the WAI-ARIA accessibility standard by default. This enables you to build accessible web applications, which are fully navigable by users with disabilities.

## Accessibility overview

Accessibility in components refers to the practice of designing and building user interface elements in a way that makes them accessible to users with disabilities. This can include a variety of things, such as making sure that text is high-contrast and easy to read, providing alternative text for images, and designing controls and interactions that can be used with a keyboard or assistive technology.

## Accessibility standards

The component is said to be accessible when it is constructed in accordance with certain standards that are required to make it accessible.

The accessibility of the components consists of the following standards and aspects:

[ADA](https://www.ada.gov/) - A law to ensure that people with disabilities have the same opportunities and access as people without disabilities.

[WCAG 2.2](https://www.w3.org/WAI/standards-guidelines/wcag/) - The Web Content Accessibility Guidelines (WCAG) provide guidelines developed by the World Wide Web Consortium (W3C) to ensure web content is accessible to people with disabilities. WCAG 2.2 establishes a framework of accessibility principles and their associated success criteria. The level of accessibility conformance achieved by a web application is determined by the extent to which it meets these success criteria, categorized into three levels: A, AA, and AAA.

[Section 508](https://www.section508.gov/) - It is a set of guidelines for making electronic and information technology (EIT) accessible to people with disabilities. These standards apply to federal agencies in the United States, and they are based on the Web Content Accessibility Guidelines (WCAG).

[WAI-ARIA](https://www.w3.org/WAI/ARIA/) - WAI-ARIA stands for “Web Accessibility Initiative - Accessible Rich Internet Applications.” It is a set of technical specifications and guidelines developed by the World Wide Web Consortium (W3C) as part of the Web Accessibility Initiative (WAI). WAI-ARIA is designed to enhance the accessibility of dynamic web content, particularly web applications and rich internet applications (RIAs), for people with disabilities. WAI-ARIA provides a set of roles, states, and properties that can be added to HTML elements to provide additional context and information about the purpose and behavior of those elements. This can help assistive technologies better understand and interpret web content and interact with web applications.

[Keyboard navigation](https://www.w3.org/TR/WCAG22/#keyboard-accessible) - It refers to the ability to use a keyboard to interact with and navigate through a user interface. It is an important aspect of web accessibility, as it allows people who cannot use a mouse or other pointing device to access and use web content and applications.

Syncfusion Blazor components adhere to these established standards.

## Accessibility compliance

The accessibility support provided by Syncfusion Blazor components is based on a collection of methodologies for adhering to and [applying recognized standards and technical specifications](#accessibility-standards) to ensure an intuitive experience for people with disabilities.

There are several methodologies of accessibility validation that can be performed on the Syncfusion Blazor components, such as:

The [WAI-ARIA patterns](https://www.w3.org/WAI/ARIA/apg/patterns/) are followed by the Syncfusion Blazor components to enable appreciable accessibility.

Each Blazor component is subjected to manual testing with a screen reader and also automated test cases to ensure the component’s required attributes.

Attributes are allocated and updated correctly during interaction as well. Each component has been assigned a distinct `Role` attribute and its own set of ARIA attributes defined by the [WCAG 2.2](https://www.w3.org/TR/WCAG22/) specification.

In addition to the methodologies mentioned above, Syncfusion Blazor components are constructed to support the following accessibility aspects.

### Screen reader support

A screen reader allows people who are blind or visually impaired to use a computer by reading aloud the text that is displayed on the screen. Syncfusion Blazor components followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/) standards to work properly in the screen readers such as [Narrator](https://support.microsoft.com/en-us/windows/complete-guide-to-narrator-e4397a0d-ef4f-b386-d8ae-c172f109bdb1) for Windows and [Embedded VoiceOver](https://support.apple.com/en-in/guide/voiceover/vo2706/mac) for MAC.

### Right-To-Left support

Right-to-Left (RTL) support allows applications to effectively communicate with users who use languages that are written from right to left, such as Arabic, Hebrew, etc. Syncfusion Blazor components support the Right-to-Left feature. Refer to the [Right-to-Left documentation](https://blazor.syncfusion.com/documentation/common/right-to-left) to learn more about this support.

### Color contrast

Syncfusion Blazor components come equipped with [predefined themes](https://blazor.syncfusion.com/documentation/appearance/themes) that guarantee the presence of satisfactory color contrast, benefiting individuals with visual impairments.

### Mobile device support

Syncfusion Blazor components are more user-friendly and accessible to individuals using mobile devices, including those with disabilities. These are designed to be responsive, adaptable to various screen sizes and orientations, and touch-friendly.

### Keyboard navigation support

Syncfusion Blazor components support keyboard navigation, allowing users who rely on alternate methods to effortlessly navigate and interact with the component.

## Ensuring accessibility

Ensuring the accessibility of Syncfusion Blazor components is crucial for making the product inclusive and user-friendly for individuals with disabilities. This process involves various types of accessibility testing, including:

* **Automated testing**: The Syncfusion Blazor component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

* **Manual testing**: This type of testing involves manually evaluating the Syncfusion Blazor components. During manual accessibility testing, testers will ensure accessibility using the screen readers such as [Narrator](https://support.microsoft.com/en-us/windows/complete-guide-to-narrator-e4397a0d-ef4f-b386-d8ae-c172f109bdb1) for Windows and [Embedded VoiceOver](https://support.apple.com/en-in/guide/voiceover/vo2706/mac) for MAC.

Syncfusion Blazor components will keep improving when there is anything required. It also involves client feedback to make the component more accessible.

## Accessibility support for specific components

Consult the component-specific documents below for detailed information about how Syncfusion Blazor components ensure compliance with accessibility standards, encompassing Section 508, WAI-ARIA, WCAG 2.2, keyboard navigation, and more.

<style>
#table
{
border:0 !important;
line-height: 160% !important;
}

tr
{
border:0 !important;
}

td
{
border:0 !important;
vertical-align: top;
}

.controlanchorlink
{
font-size: 14px !important;
text-decoration: none!important;
text-align: left!important;
padding: 1px 0px;
}
.controlcategory-topics
{
font-size: 14px !important;
font-weight: 500!important;
border:0 !important;
line-height: 20px;
}
.controlcategory
{
font-size: 14px !important;
font-weight: 500!important;
border:0 !important;
text-align: left!important;
line-height: 20px;
padding-top: 20px;
}
</style>

<table id="table">
<tbody>
<colgroup>
<col style="width: 25%">
<col style="width: 25%">
<col style="width: 25%">
<col style="width: 25%">
</colgroup>
</tbody>
<tr>
    <td>
        <div><p class="controlcategory-topics">GRIDS</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/datagrid/accessibility">DataGrid</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/pivot-table/accessibility">Pivot Table</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/treegrid/accessibility">TreeGrid</a></div>
        <div><p class="controlcategory">FILE VIEWERS & EDITORS</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/rich-text-editor/accessibility">RichTextEditor</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/pdfviewer-2/keyboard-accessibility">PDF Viewer</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/document-editor/accessibility">Word Processor</a></div>
        <div class="controlanchorlink">Image Editor</div>
        <div><p class="controlcategory">LAYOUT</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/dialog/accessibility">Dialog</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/listview/accessibility">ListView</a></div>
        <div class="controlanchorlink">Tooltip</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/splitter/accessibility">Splitter</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/dashboard-layout/accessibility">Dashboard</a></div>
        <div class="controlanchorlink">Card</div>
        <div class="controlanchorlink">Avatar</div>
        <div class="controlanchorlink">Media Query</div>
    </td>
    <td>
        <div><p class="controlcategory-topics">DATA VISUALIZATION</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/chart/accessibility">Charts</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/accumulation-chart/accessibility">Accumulation Chart</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/stock-chart/accessibility">Stock Chart</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/circular-gauge/accessibility">Circular Gauge</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/linear-gauge/accessibility">Linear Gauge</a></div>
        <div class="controlanchorlink">Diagram</div>
        <div class="controlanchorlink">HeatMap Chart</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/maps/accessibility">Map</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/range-selector/accessibility">Range Selector</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/smith-chart/accessibility">Smith Chart</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/sparkline/accessibility">Sparkline Charts</div>
        <div class="controlanchorlink">Barcode</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/treemap/accessibility">TreeMap</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/bullet-chart/accessibility">Bullet Chart</div>
        <div class="controlanchorlink">Kanban</div>
        <div><p class="controlcategory">BUTTONS</p></div>
        <div class="controlanchorlink">Button</div>
        <div class="controlanchorlink">ButtonGroup</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/drop-down-menu/accessibility">Dropdown Menu</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/progress-button/accessibility">Progress Button</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/split-button/accessibility">SplitButton</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/chip/accessibility">Chips</a></div>
        <div class="controlanchorlink">Icons</div>
        <div class="controlanchorlink">Floating Action Button</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/speeddial/accessibility">Speed Dial</a></div>
    </td>
    <td>
        <div><p class="controlcategory-topics">CALENDARS</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/scheduler/accessibility">Scheduler</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/gantt-chart/accessibility">Gantt Chart</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/calendar/accessibility">Calendar</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/datepicker/accessibility">DatePicker</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/daterangepicker/accessibility">DateRangePicker</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/datetime-picker/accessibility">DateTime Picker</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/timepicker/accessibility">TimePicker</a></div>
        <div><p class="controlcategory">INPUTS</p></div>
        <div class="controlanchorlink">TextBox</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/input-mask/accessibility">Input Mask</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/numeric-textbox/accessibility">Numeric TextBox</a></div>
        <div class="controlanchorlink">RadioButton</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/check-box/accessibility">CheckBox</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/color-picker/accessibility">Color Picker</a></div>
        <div class="controlanchorlink">File Upload</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/range-slider/accessibility">Range Slider</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/toggle-switch-button/accessibility">Toggle Switch Button</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/signature/accessibility">Signature</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/rating/accessibility">Rating</a></div>
        <div><p class="controlcategory">FORMS</p></div>
        <div class="controlanchorlink">In-place Editor</div>
        <div class="controlanchorlink">Query Builder</div>
		<div class="controlanchorlink">Data Form</div>
    </td>
    <td>
        <div><p class="controlcategory-topics">DROPDOWNS</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/autocomplete/accessibility">AutoComplete</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/listbox/accessibility">ListBox</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/combobox/accessibility">ComboBox</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/dropdown-list/accessibility">Dropdown List</a></div>
		<div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/dropdown-tree/accessibility">DropDown Tree</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/multiselect-dropdown/accessibility">Multiselect DropDown</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/mention/accessibility">Mention</a></div>
        <div><p class="controlcategory">NAVIGATION</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/accordion/accessibility">Accordion</a></div>
        <div class="controlanchorlink">Breadcrumb</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/carousel/accessibility">Carousel</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/context-menu/accessibility">Context Menu</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/menu-bar/accessibility">Menu Bar</a></div>
        <div class="controlanchorlink">Sidebar</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/tabs/accessibility">Tabs</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/toolbar/accessibility">Toolbar</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/treeview/accessibility">TreeView</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/file-manager/accessibility">File Manager</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/pager/accessibility">Pager</a></div>
        <div class="controlanchorlink">AppBar</div>
		<div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/stepper/accessibility">Stepper</a></div>
        <div><p class="controlcategory">NOTIFICATION</p></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/toast/accessibility">Toast</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/progress-bar/accessibility">ProgressBar</div>
        <div class="controlanchorlink">Spinner</div>
        <div class="controlanchorlink">Badge</div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/skeleton/accessibility">Skeleton</a></div>
        <div class="controlanchorlink"><a target="_self" href="https://blazor.syncfusion.com/documentation/message/accessibility">Message</a></div>
    </td>
</tr>
</table>
