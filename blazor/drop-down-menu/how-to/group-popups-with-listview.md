---
layout: post
title: Group dropdown listview items in Blazor Dropdown Menu| Syncfusion
description: Learn here all about grouping dropdown listview items in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Group dropdown listview items in Blazor Dropdown Menu Component

Header in popup items is possible in Dropdown Menu by templating entire popup with ListView. Create ListView with [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_ID) listview and provide it as a `PopupContent` for Dropdown Menu.

In the following example, ListView element is given as `PopupContent` to Dropdown Menu and header can be achieved by [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.FieldSettingsModel.html#Syncfusion_Blazor_Lists_FieldSettingsModel_GroupBy) property.

```cshtml

<SfDropDownButton CssClass="e-caret-hide" IconCss="e-icons e-down">
        <PopupContent>
            <SfListView ID="listview" DataSource="@Data" ShowCheckBox="true">
                <ListViewFieldSettings Text="Text" GroupBy="Category" TValue="ListData"></ListViewFieldSettings>
            </SfListView>
        </PopupContent>
    </SfDropDownButton>

@code {
    public List<ListData> Data = new List<ListData>{
        new ListData{ Class = "data", Text = "Print", Id = "data1", Category = "Customize Quick Access Toolbar" },
        new ListData{ Class = "data", Text = "Save As", Id = "data2", Category = "Customize Quick Access Toolbar" },
        new ListData{ Class = "data", Text = "Update Folder", Id = "data3", Category = "Customize Quick Access Toolbar"},
        new ListData{ Class = "data", Text = "Reply", Id = "data4", Category = "Customize Quick Access Toolbar" }
};

    public class ListData
    {
        public string Text { get; set; }
        public string Id { get; set; }
        public string Class { get; set; }
        public string Category { get; set; }
    }
}

```

Output be like

![Grouping Popup Items in Blazor DropDownMenu](./../images/blazor-dropdownmenu-grouping-popup-item.png)