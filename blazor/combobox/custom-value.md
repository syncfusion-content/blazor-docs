---
layout: post
title: Adding Custom value to the Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about adding custom value in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Adding Custom Value to Blazor ComboBox Component

You can add custom value to the ComboBox component. When the typed character(s) is not present in the list, a button will be shown in the popup list. By clicking on this button, the custom value character(s) get added to the existing list as a new item. Default value of [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html#Syncfusion_Blazor_DropDowns_SfComboBox_2_AllowCustom) is `true`.

```cshtml
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.Data;


<SfComboBox @ref="@ComboObj" TValue="string" Placeholder="Select a Country" Width="250px" TItem="TItem" DataSource="@DataSource" AllowCustom="true" AllowFiltering="true">
    <ComboBoxFieldSettings Text="Name" Value="Name"></ComboBoxFieldSettings>
    <ComboBoxEvents TValue="string" Filtering="@OnFiltering" TItem="TItem"></ComboBoxEvents>
    <ComboBoxTemplates TItem="TItem">
        <NoRecordsTemplate>
            <div>
                <div id="nodata">No matched item, do you want to add it as new item in list?</div>
                <SfButton id="btn" class="e-control e-btn" style="margin-top: 10px" @onclick="@AddItem">ADD NEW ITEM</SfButton>
            </div>
        </NoRecordsTemplate>
    </ComboBoxTemplates>
</SfComboBox>

@code {
    private SfComboBox<string, TItem> ComboObj;
    private string Custom { get; set; }
    private List<TItem> CustomDataItems { get; set; } = new List<TItem>();
    public class TItem
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    private async Task OnFiltering(Syncfusion.Blazor.DropDowns.FilteringEventArgs args)
    {
        Custom = args.Text;
        args.PreventDefaultAction = true;
        var query = new Query().Where(new WhereFilter() { Field = "Name", Operator = "contains", value = args.Text, IgnoreCase = true });
        query = !string.IsNullOrEmpty(args.Text) ? query : new Query();
        await ComboObj.FilterAsync(CustomDataItems, query);
    }
    private List<TItem> DataSource = new List<TItem>
    {
        new TItem() { Name = "Australia", Code = "AU" },
        new TItem() { Name = "Bermuda", Code = "BM" },
        new TItem() { Name = "Canada", Code = "CA" },
        new TItem() { Name = "Cameroon", Code = "CM" },
        new TItem() { Name = "Denmark", Code = "DK" },
        new TItem() { Name = "France", Code = "FR" },
        new TItem() { Name = "Finland", Code = "FI" },
        new TItem() { Name = "Germany", Code = "DE" },
        new TItem() { Name = "Greenland", Code = "GL" },
        new TItem() { Name = "Hong Kong", Code = "HK" },
        new TItem() { Name = "India", Code = "IN" },
        new TItem() { Name = "Italy", Code = "IT" }
    };
    protected override void OnInitialized()
    {
        CustomDataItems = DataSource;
    }
    private async Task AddItem()
    {
        var customData = new TItem() { Name = Custom, Code = Custom };
        await this.ComboObj.AddItems(new List<TItem> { customData });
        CustomDataItems.Add(customData);
        await this.ComboObj.HidePopupAsync();
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBACVLQKFyiyoKz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ComboBox with custom value](./images/blazor-combobox-custom-value.png)