# Templates

The ComboBox has been provided with several options to customize each list item, group title,
selected value, header, and footer elements.

## Item template

The content of each list item within the ComboBox can be customized with the
help of [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate)
property.

In the following sample, each list item is split into two columns to display relevant data.

```csharp
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a customer" DataSource="@Data">
    <ComboBoxTemplates TItem="EmployeeData">
        <ItemTemplate>
            <span><span class='name'>@((context as EmployeeData).FirstName)</span><span class='country'>@((context as EmployeeData).Country)</span></span>
        </ItemTemplate>
    </ComboBoxTemplates>
    <ComboBoxFieldSettings Text="FirstName" Value="Country"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public class EmployeeData
    {
        public string FirstName { get; set; }
        public string Country { get; set; }
    }
    List<EmployeeData> Data = new List<EmployeeData>
{
        new EmployeeData() { FirstName = "Andrew Fuller",  Country = "England" },
        new EmployeeData() { FirstName = "Anne Dodsworth", Country = "USA" },
        new EmployeeData() { FirstName = "Janet Leverling", Country = "USA" },
        new EmployeeData() { FirstName = "Laura Callahan", Country = "USA"},
        new EmployeeData() { FirstName = "Margaret Peacock", Country = "USA"},
        new EmployeeData() { FirstName = "Michael Suyama", Country = "USA", },
        new EmployeeData() { FirstName = "Nancy Davolio", Country = "USA"},
        new EmployeeData() { FirstName = "Robert King", Country = "England"},
        new EmployeeData() { FirstName = "Steven Buchanan", Country = "England"},
    };
}

<style>
    .country {
        right: 15px;
        position: absolute;
    }
</style>
```

The output will be as follows.

![ComboBox](./images/item_template.png)

## Group template

The group header title under which appropriate sub-items are categorized can also be
customize with the help of
[GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property.
This template is common for both inline and floating group header template.

In the following sample, employees are grouped according to their country.

```csharp
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a customer" DataSource="@Data">
    <ComboBoxTemplates TItem="EmployeeData">
        <GroupTemplate>
            <span class="group">@(context.Text)</span>
        </GroupTemplate>
    </ComboBoxTemplates>
    <ComboBoxFieldSettings Value="FirstName" GroupBy="Country"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public class EmployeeData
    {
        public string FirstName { get; set; }
        public string Country { get; set; }
    }
    List<EmployeeData> Data = new List<EmployeeData>
{
        new EmployeeData() { FirstName = "Andrew Fuller",  Country = "England" },
        new EmployeeData() { FirstName = "Anne Dodsworth", Country = "USA" },
        new EmployeeData() { FirstName = "Janet Leverling", Country = "USA" },
        new EmployeeData() { FirstName = "Laura Callahan", Country = "USA"},
        new EmployeeData() { FirstName = "Margaret Peacock", Country = "USA"},
        new EmployeeData() { FirstName = "Michael Suyama", Country = "USA", },
        new EmployeeData() { FirstName = "Nancy Davolio", Country = "USA"},
        new EmployeeData() { FirstName = "Robert King", Country = "England"},
        new EmployeeData() { FirstName = "Steven Buchanan", Country = "England"},
    };
}

<style>
    .group {
        color: slategrey;
    }
</style>
```

The output will be as follows.

![ComboBox](./images/group_template.png)

## Header template

The header element is shown statically at the top of the popup list items within the
ComboBox, and any custom element can be placed as a header element using the
[HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) property.

In the following sample, the list items and its headers are designed and displayed as two columns
similar to multiple columns of the grid.

```csharp
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a customer" DataSource="@Data">
    <ComboBoxTemplates TItem="EmployeeData">
        <ItemTemplate>
            <span class='item'><span class='name'>@((context as EmployeeData).FirstName)</span><span class='city'>@((context as EmployeeData).Country)</span></span>
        </ItemTemplate>
        <HeaderTemplate>
            <span class='head'><span class='name'>Name</span><span class='city'>Country</span></span>
        </HeaderTemplate>
    </ComboBoxTemplates>
    <ComboBoxFieldSettings Value="Country" Text="FirstName"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public class EmployeeData
    {
        public string FirstName { get; set; }
        public string Country { get; set; }
    }
    List<EmployeeData> Data = new List<EmployeeData>
{
        new EmployeeData() { FirstName = "Andrew Fuller",  Country = "England" },
        new EmployeeData() { FirstName = "Anne Dodsworth", Country = "USA" },
        new EmployeeData() { FirstName = "Janet Leverling", Country = "USA" },
        new EmployeeData() { FirstName = "Laura Callahan", Country = "USA"},
        new EmployeeData() { FirstName = "Margaret Peacock", Country = "USA"},
        new EmployeeData() { FirstName = "Michael Suyama", Country = "USA", },
        new EmployeeData() { FirstName = "Nancy Davolio", Country = "USA"},
        new EmployeeData() { FirstName = "Robert King", Country = "England"},
        new EmployeeData() { FirstName = "Steven Buchanan", Country = "England"},
    };
}

<style>
    .head, .item {
        display: table;
        width: 100%;
        margin: auto;
    }

    .head {
        height: 40px;
        font-size: 15px;
        font-weight: 600;
    }

    .name, .city {
        display: table-cell;
        vertical-align: middle;
        width: 50%;
    }

    .head .name {
        text-indent: 16px;
    }

</style>
```

The output will be as follows.

![ComboBox](./images/header_template.png)

## Footer template

The ComboBox has options to show a footer element at the bottom of the list items in the popup list.
Here, you can place any custom element as a footer element using the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) property.

In the following sample, footer element displays the total number of list items present in the ComboBox.

```csharp
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" DataSource="@Data" Placeholder="Select a customer">
    <ComboBoxTemplates TItem="EmployeeData">
        <FooterTemplate>
            <span class='footer'>Total list Item: 6 </span>
        </FooterTemplate>
    </ComboBoxTemplates>
    <ComboBoxFieldSettings Value="Country" Text="FirstName"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public class EmployeeData
    {
        public string FirstName { get; set; }
        public string Country { get; set; }
    }
    List<EmployeeData> Data = new List<EmployeeData>
{
       new EmployeeData() { FirstName = "Andrew Fuller",  Country = "England" },
        new EmployeeData() { FirstName = "Anne Dodsworth", Country = "USA" },
        new EmployeeData() { FirstName = "Janet Leverling", Country = "USA" },
        new EmployeeData() { FirstName = "Laura Callahan", Country = "USA"},
        new EmployeeData() { FirstName = "Margaret Peacock", Country = "USA"},
        new EmployeeData() { FirstName = "Michael Suyama", Country = "USA", },
    };
}

<style>
    .footer {
        text-indent: 1.2em;
        display: block;
        font-size: 15px;
        line-height: 40px;
        border-top: 1px solid #e0e0e0;
    }
</style>
```

The output will be as follows.

![ComboBox](./images/footer_template.png)

## No records template

The ComboBox is provided with support to custom design the popup list content when no data is found
and no matches found on search with the help of
[NoRecordsTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_NoRecordsTemplate) property.

In the following sample, popup list content displays the notification of no data available.

```csharp
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="Countries" Placeholder="Select a customer" DataSource="@Country">
    <ComboBoxTemplates TItem="Countries">
        <NoRecordsTemplate>
            <span class='norecord'> NO DATA AVAILABLE</span>
        </NoRecordsTemplate>
    </ComboBoxTemplates>
</SfComboBox>

@code {
    public class EmployeeData { }
    public EmployeeData Data = new EmployeeData();

    public class Countries { }

    List<Countries> Country = new List<Countries> { };
}
```

The output will be as follows.

![ComboBox](./images/data_template.png)

## Action failure template

There is also an option to custom design the popup list content when the data fetch request
fails at the remote server. This can be achieved using the
[ActionFailureTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ActionFailureTemplate) property.

In the following sample, when the data fetch request fails, the ComboBox displays the notification.

```csharp
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="EmployeeData" Placeholder="Select a customer" Query="@Query">
    <ComboBoxTemplates TItem="EmployeeData">
        <ActionFailureTemplate>
            <span class='norecord'>Data fetch get fails </span>
        </ActionFailureTemplate>
    </ComboBoxTemplates>
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svcs/Employees" Adaptor="Adaptors.ODataV4Adaptor" CrossDomain=true></SfDataManager>
    <ComboBoxFieldSettings Value="Country" Text="FirstName"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public class EmployeeData
    {
        public string FirstName { get; set; }
    }
    public EmployeeData Data = new EmployeeData();
    public Query Query = new Query().Select(new List<string> {"FirstName", "Country"}).Take(6).RequiresCount();
}
```

The output will be as follows.

![ComboBox](./images/action_template.png)