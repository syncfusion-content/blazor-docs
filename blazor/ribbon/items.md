---
layout: post
title: Items in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Items in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Items in Blazor Ribbon component

## Button item

You can render the built-in Ribbon button item by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.Button`. You can customize the button item using the [RibbonButtonSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_ButtonSettings) tag directive, which provides options such as [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonButtonSettings_IconCss), [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonButtonSettings_Content), [IsToggle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonButtonSettings_IsToggle), and more.

### Events

The following events are available in the Button item.

|Name|Args|Description|
|---|---|---|
|[Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonButtonSettings_Created)|EventCallback|Triggers when the button is created|
|[OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonButtonSettings_OnClick)|MouseEventArgs|Triggers when the button is clicked|

Below example demonstrates how to configure a Button item including it's events

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon

<div style="width:30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Cut"
                                                              IconCss="e-icons e-cut"
                                                              OnClick="ClickHandler" Created="Created">
                                        </RibbonButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {
    private void Created() { /* your actions here */ }

    private void ClickHandler(MouseEventArgs args) { /* your actions here */ }
}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon button item.](./images/items/blazor-ribbon-button-item.png)

## Checkbox item

You can render the built-in Ribbon checkbox item by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.Checkbox`. This item is used to toggle between selected and unselected states. You can customize the checkbox using the [RibbonCheckboxSettings]() tag directive with options such as [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonCheckBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonCheckBoxSettings_Label) and [Checked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonCheckBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonCheckBoxSettings_Checked).

### Events

The following events are available in the Checkbox item.

|Name|Args|Description|
|---|---|---|
|[Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonCheckBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonCheckBoxSettings_Created)|EventCallback|Triggers when the checkbox is created|
|[ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonCheckBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonCheckBoxSettings_ValueChange)|ChangeEventArgs|Triggers when the checkbox value changes|

Below example demonstrates how to configure a Checkbox item including it's events

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon

<div style="width:30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Show">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.CheckBox>
                                        <RibbonCheckBoxSettings Label="Ruler"
                                                                Checked="true" 
                                                                Created="Created" 
                                                                ValueChange="ValueChange">
                                        </RibbonCheckBoxSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.CheckBox>
                                        <RibbonCheckBoxSettings Label="Gridlines"></RibbonCheckBoxSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.CheckBox>
                                        <RibbonCheckBoxSettings Label="Navigation Pane"></RibbonCheckBoxSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {
    private void Created() { /* your actions here */ }

    private void ValueChange(ChangeEventArgs args) { /* your actions here */ }
}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon checkbox item.](./images/items/blazor-ribbon-checkbox-item.png)

## DropDownButton item

You can render the built-in Ribbon dropdown button item by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.DropDown`. This item displays a button with a dropdown menu for additional options. The [RibbonDropDownSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_DropDownSettings) tag directive allows you to configure properties such as [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_Content), [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_Items) and more.

### Events

The following events are available in the DropDownButton item.

|Name|Args|Description|
|---|---|---|
|[Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_Created)|EventCallback|Triggers when the dropdown button is created|
|[PopupOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_PopupOpening)|DropDownPopupOpenEventArgs|Triggers before the dropdown popup opens|
|[PopupClosing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_PopupClosing)|DropDownPopupCloseEventArgs|Triggers before the dropdown popup closes|
|[PopupOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_PopupOpened)|DropDownPopupOpenedEventArgs|Triggers after the dropdown popup has opened|
|[PopupClosed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_PopupClosed)|DropDownPopupClosedEventArgs|Triggers after the dropdown popup has closed|
|[ItemRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_ItemRendering)|DropDownItemRenderEventArgs|Triggers during rendering of each dropdown item|
|[ItemSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonDropDownSettings.html#Syncfusion_Blazor_Ribbon_RibbonDropDownSettings_ItemSelecting)|DropDownItemSelectEventArgs|Triggers before selecting a dropdown item|

Below example demonstrates how to configure a DropDownButton item including it's events

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon
@using Syncfusion.Blazor.SplitButtons

<div style="width:30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Header">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.DropDown>
                                        <RibbonDropDownSettings Content="Header" IconCss="e-icons e-header" Items="@headerItems" 
                                                                Created="Created" 
                                                                PopupOpening="PopupOpening" 
                                                                PopupClosing="PopupClosing" 
                                                                PopupOpened="PopupOpened" 
                                                                PopupClosed="PopupClosed" 
                                                                ItemRendering="ItemRendering" 
                                                                ItemSelecting="ItemSelecting">
                                        </RibbonDropDownSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {
    private void Created() { /* your actions here */ }

    private void PopupOpening(DropDownPopupOpenEventArgs args) { /* your actions here */ }

    private void PopupClosing(DropDownPopupCloseEventArgs args) { /* your actions here */ }

    private void PopupOpened(DropDownPopupOpenedEventArgs args) { /* your actions here */ }

    private void PopupClosed(DropDownPopupClosedEventArgs args) { /* your actions here */ }

    private void ItemRendering(DropDownItemRenderEventArgs args) { /* your actions here */ }

    private void ItemSelecting(DropDownItemSelectEventArgs args) { /* your actions here */ }

    List<DropDownMenuItem> headerItems = new List<DropDownMenuItem>()
    {
        new DropDownMenuItem{ Text = "Insert Header" },
        new DropDownMenuItem{ Text = "Edit Header" },
        new DropDownMenuItem{ Text = "Remove Header" }
    };

}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon dropdown item.](./images/items/blazor-ribbon-dropdown-item.png)

## SplitButton item

You can render the built-in Ribbon split button item by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.SplitButton`. This item combines a primary button with a dropdown for secondary actions. The [RibbonSplitButtonSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_SplitButtonSettings) tag directive lets you configure options like [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_Content), [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_Items) and more.

### Events

The following events are available in the SplitButton item.

|Name|Args|Description|
|---|---|---|
|[Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_Created)|EventCallback|Triggers when the split button is created|
|[Clicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_Clicked)|SplitButtonClickedEventArgs|Triggers when the split button is clicked|
|[PopupOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_PopupOpening)|SplitButtonPopupOpenEventArgs|Triggers before the split button popup opens|
|[PopupClosing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_PopupClosing)|SplitButtonPopupCloseEventArgs|Triggers before the split button popup closes|
|[PopupOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_PopupOpened)|SplitButtonPopupOpenedEventArgs|Triggers after the split button popup has opened|
|[PopupClosed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_PopupClosed)|SplitButtonPopupClosedEventArgs|Triggers after the split button popup has closed|
|[ItemRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_ItemRendering)|SplitButtonItemRenderEventArgs|Triggers during rendering of each item in the split button|
|[ItemSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonSplitButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonSplitButtonSettings_ItemSelected)|SplitButtonItemSelectedEventArgs|Triggers when an item in the split button is selected|

Below example demonstrates how to configure a SplitButton item including it's events

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon
@using Syncfusion.Blazor.SplitButtons

<div style="width:30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Header">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton>
                                        <RibbonSplitButtonSettings Content="Paste" IconCss="e-icons e-paste" Items="@formatItems" 
                                                                    Created="Created" 
                                                                    Clicked="Clicked" 
                                                                    PopupOpening="PopupOpening" 
                                                                    PopupClosing="PopupClosing" 
                                                                    PopupOpened="PopupOpened" 
                                                                    PopupClosed="PopupClosed" 
                                                                    ItemRendering="ItemRendering" 
                                                                    ItemSelecting="ItemSelecting">
                                        </RibbonSplitButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {
    private void Created() { /* your actions here */ }

    private void Clicked(SplitButtonClickedEventArgs args) { /* your actions here */ }

    private void PopupOpening(SplitButtonPopupOpenEventArgs args) { /* your actions here */ }

    private void PopupClosing(SplitButtonPopupCloseEventArgs args) { /* your actions here */ }

    private void PopupOpened(SplitButtonPopupOpenedEventArgs args) { /* your actions here */ }

    private void PopupClosed(SplitButtonPopupClosedEventArgs args) { /* your actions here */ }

    private void ItemRendering(SplitButtonItemRenderEventArgs args) { /* your actions here */ }

    private void ItemSelecting(SplitButtonItemSelectedEventArgs args) { /* your actions here */ }

    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
    {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
    };

}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon splitbutton item.](./images/items/blazor-ribbon-splitbutton-item.png)

## Combobox item

You can render the built-in Ribbon combobox item by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.Combobox`. This item provides a dropdown with optional search and filtering capabilities. The [RibbonComboboxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_ComboBoxSettings) tag directive allows you to configure properties like [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_DataSource), [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_AllowFiltering), [Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_Index), [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_Placeholder) and lot more.

### Events

The following events are available in the Combobox item.

|Name|Args|Description|
|---|---|---|
|[PopupOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_PopupOpening)|ComboBoxPopupOpenEventArgs|Triggers before the combobox popup opens|
|[PopupClosing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_PopupClosing)|ComboBoxPopupCloseEventArgs|Triggers before the combobox popup closes|
|[PopupOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_PopupOpened)|ComboBoxPopupOpenedEventArgs|Triggers after the combobox popup has opened|
|[PopupClosed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_PopupClosed)|ComboBoxPopupClosedEventArgs|Triggers after the combobox popup has closed|
|[Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_Filtering)|ComboBoxFilterEventArgs|Triggers during filtering of combobox items|
|[Selecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_Selecting)|ComboBoxSelectEventArgs|Triggers before selecting an item in the combobox|
|[ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonComboBoxSettings.html#Syncfusion_Blazor_Ribbon_RibbonComboBoxSettings_ValueChange)|ComboBoxChangeEventArgs|Triggers when the combobox value changes|

Below example demonstrates how to configure a Combobox item including it's events

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.DropDowns

<div style="width:50%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup Orientation=Orientation.Row HeaderText="Font">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings @bind-Value="@fontFamValue" ShowClearButton="true" AllowFiltering=true DataSource="@fontFamilyItems" FieldSettings="@fieldSetings"
                                        PopupOpening="PopupOpening" 
                                        PopupClosing="PopupClosing" 
                                        PopupOpened="PopupOpened" 
                                        PopupClosed="PopupClosed" 
                                        Filtering="Filtering" 
                                        Selecting="Selecting" 
                                        ValueChange="ValueChange">
                                        </RibbonComboBoxSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings Index="3" AllowFiltering=true DataSource="@fontSizeItems" FieldSettings="@fieldSetings"></RibbonComboBoxSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {

    public string fontFamValue { get; set; } = "Cambria";

    private class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    FieldSettingsModel fieldSetings = new FieldSettingsModel
    {
        Text = "Text",
        Value = "Value"
    };

    List<ComboBoxItem> fontFamilyItems = new List<ComboBoxItem>
    {
        new ComboBoxItem { Text = "Algerian", Value = "Algerian" },
        new ComboBoxItem { Text = "Arial", Value = "Arial" },
        new ComboBoxItem { Text = "Calibri", Value = "Calibri" },
        new ComboBoxItem { Text = "Cambria", Value = "Cambria" },
        new ComboBoxItem { Text = "Cambria Math", Value = "Cambria Math" },
    };

    List<ComboBoxItem> fontSizeItems = new List<ComboBoxItem>
    {
        new ComboBoxItem { Text = "8", Value = "8" },
        new ComboBoxItem { Text = "9", Value = "9" },
        new ComboBoxItem { Text = "10", Value = "10" },
        new ComboBoxItem { Text = "11", Value = "11" },
        new ComboBoxItem { Text = "12", Value = "12" },
    };

    private void PopupOpening(ComboBoxPopupOpenEventArgs args) { /* your actions here */ }

    private void PopupClosing(ComboBoxPopupCloseEventArgs args) { /* your actions here */ }

    private void PopupOpened(ComboBoxPopupOpenedEventArgs args) { /* your actions here */ }

    private void PopupClosed(ComboBoxPopupClosedEventArgs args) { /* your actions here */ }

    private void Filtering(ComboBoxFilterEventArgs args) { /* your actions here */ }

    private void Selecting(ComboBoxSelectEventArgs args) { /* your actions here */ }

    private void ValueChange(ComboBoxChangeEventArgs args) { /* your actions here */ }

}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon combobox item.](./images/items/blazor-ribbon-combobox-item.png)

## Colorpicker item

You can render the built-in Ribbon color picker item by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.ColorPicker`. This item provides a color selection interface, which can be customized using the [RibbonColorPickerSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_ColorPickerSettings) tag directive with properties like [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_Value), [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_Mode) and more.

### Events

The following events are available in the Colorpicker item.

|Name|Args|Description|
|---|---|---|
|[Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_Created)|EventCallback|Triggers when the color picker is created|
|[Opening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_Opening)|ColorPickerOpenEventArgs|Triggers before the color picker opens|
|[Closing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_Closing)|ColorPickerCloseEventArgs|Triggers before the color picker closes|
|[Opened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_Opened)|ColorPickerOpenedEventArgs|Triggers after the color picker has opened|
|[TileRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_TileRendering)|TileRenderEventArgs|Triggers during the rendering of each palette tile|
|[ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_ValueChange)|ColorPickerEventArgs|Triggers when the color value of the picker changes|
|[Selected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonColorPickerSettings.html#Syncfusion_Blazor_Ribbon_RibbonColorPickerSettings_Selected)|ColorPickerSelectedEventArgs|Triggers when a color is selected in the picker or palette|

Below example demonstrates how to configure a Colorpicker item including it's events

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon
@using Syncfusion.Blazor.SplitButtons

<div style="width:30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Font">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.ColorPicker AllowedSizes="RibbonItemSize.Small">
                                        <RibbonColorPickerSettings Value="#123456"
                                                                   Created="Created" 
                                                                   Opening="Opening" 
                                                                   Closing="Closing" 
                                                                   Opened="Opened" 
                                                                   TileRendering="TileRendering" 
                                                                   Selected="Selected" 
                                                                   ValueChange="ValueChange">
                                        </RibbonColorPickerSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {
    private void Created() { /* your actions here */ }

    private void Opening(ColorPickerOpenEventArgs args) { /* your actions here */ }

    private void Closing(ColorPickerCloseEventArgs args) { /* your actions here */ }

    private void Opened(ColorPickerOpenedEventArgs args) { /* your actions here */ }

    private void ValueChange(ColorPickerEventArgs args) { /* your actions here */ }

    private void TileRendering(TileRenderEventArgs args) { /* your actions here */ }

    private void Selected(ColorPickerSelectedEventArgs args) { /* your actions here */ }

}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon colorpicker item.](./images/items/blazor-ribbon-colorpicker-item.png)

## GroupButton item

You can render the built-in Ribbon group button item by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.GroupButton`. This item groups multiple buttons for single or multiple selection. Use the [RibbonGroupButtonSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_GroupButtonSettings) tag directive to configure options like [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroupButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonGroupButtonSettings_Items), [Selection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroupButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonGroupButtonSettings_Selection), and more. `Items` property accepts a collection of [GroupButtonItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.GroupButtonItem.html) through which you can customize each group button item with options such as [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.GroupButtonItem.html#Syncfusion_Blazor_Ribbon_GroupButtonItem_Content), [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.GroupButtonItem.html#Syncfusion_Blazor_Ribbon_GroupButtonItem_IconCss), [Selected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.GroupButtonItem.html#Syncfusion_Blazor_Ribbon_GroupButtonItem_Selected) and more.

### Events

The following event is available in the GroupButton item.

|Name|Args|Description|
|---|---|---|
|[ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroupButtonSettings.html#Syncfusion_Blazor_Ribbon_RibbonGroupButtonSettings_ItemClick)|GroupButtonClickEventArgs|Triggers when an item in the group button is clicked|

Below example demonstrates how to configure a GroupButton item with both selection types including it's event.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon
@using Syncfusion.Blazor.SplitButtons

<div style="width:30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Font">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.GroupButton ID="formatGroupBtn">
                                        <RibbonGroupButtonSettings HeaderText="Format Styles"
                                                                   Selection=GroupButtonSelection.Multiple
                                                                   Items="@formatGroupItems" ItemClick="HandleSelection">
                                        </RibbonGroupButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                    <RibbonGroup HeaderText="Alignment">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.GroupButton ID="alignmentGroup">
                                        <RibbonGroupButtonSettings Selection=GroupButtonSelection.Single
                                                                   Items="@alignGroupItems" ItemClick="HandleSelection">
                                        </RibbonGroupButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {
    
    List<GroupButtonItem> formatGroupItems = new List<GroupButtonItem>
    {
        new GroupButtonItem
        {
            IconCss = "e-icons e-bold",
            Selected = true,
            Content = "Bold"
        },
        new GroupButtonItem
        {
            IconCss = "e-icons e-italic",
            Content = "Italic",
        },
        new GroupButtonItem
        {
            IconCss = "e-icons e-underline",
            Content = "Underline"
        },
        new GroupButtonItem
        {
            IconCss = "e-icons e-strikethrough",
            Content = "Strikethrough"
        },
        new GroupButtonItem
        {
            IconCss = "e-icons e-change-case",
            Content = "Change Case"
        },
    };

    List<GroupButtonItem> alignGroupItems = new List<GroupButtonItem>
    {
        new GroupButtonItem
        {
            IconCss = "e-icons e-align-left",
            Selected = true,
            Content = "Align Left"
        },
        new GroupButtonItem
        {
            IconCss = "e-icons e-align-center",
            Content = "Align Center"
        },
        new GroupButtonItem
        {
            IconCss = "e-icons e-align-right",
            Content = "Align Right"
        },
                new GroupButtonItem
        {
            IconCss = "e-icons e-justify",
            Content = "Justify"
        }
    };
    
    private void HandleSelection(GroupButtonClickEventArgs args) { /* your actions here */ }

}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon groupbutton item.](./images/items/blazor-ribbon-groupbutton-item.png)

## Custom item

The Ribbon supports rendering non-built-in items or your own HTML content by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Type) property as `RibbonItemType.Template`. And then, you can use the [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_ItemTemplate) tag directive to define a custom `RenderFragment` for fully customizable content. [RibbonItemContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItemContext.html) is being passed as context to the template through which you can customize further based on the current state of the Ribbon item.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon

<div style="width:50%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup Orientation=Orientation.Row HeaderText="Inputs">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type="RibbonItemType.Template">
                                        <ItemTemplate>
                                            <input type="text" placeholder="Search..." style="width: 150px; padding: 8px; border: 1px solid #ccc; border-radius: 4px;">
                                        </ItemTemplate>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type="RibbonItemType.Template">
                                        <ItemTemplate>
                                            <input type="date" style="padding: 8px; border: 1px solid #ccc; border-radius: 4px;">
                                        </ItemTemplate>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                    <RibbonGroup Orientation=Orientation.Row HeaderText="Feedbacks">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type="RibbonItemType.Template">
                                        <ItemTemplate>
                                            <div style="display: flex; gap: 5px;">
                                                <span style="color: gold; font-size: 20px;">★</span>
                                                <span style="color: gold; font-size: 20px;">★</span>
                                                <span style="color: gold; font-size: 20px;">★</span>
                                                <span style="color: #ccc; font-size: 20px;">★</span>
                                                <span style="color: #ccc; font-size: 20px;">★</span>
                                            </div>
                                        </ItemTemplate>
                                    </RibbonItem>
                                    <RibbonItem Type="RibbonItemType.Template">
                                        <ItemTemplate>
                                            <div style="position: relative; display: inline-block;">
                                                <button style="padding: 10px; border: none; background: #007bff; color: white; border-radius: 4px;">Inbox</button>
                                                <span style="position: absolute; top: -2px; right: -7px;
                                                            background: red; color: white; font-size: 11px; padding: 0 5px; border-radius: 50%;">5
                                                </span>
                                            </div>
                                        </ItemTemplate>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon custom item.](./images/items/blazor-ribbon-custom-item.png)

## Items display mode

The [DisplayOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_DisplayOptions) property determines how Ribbon items are displayed based on the Ribbon's layout and overflow state. Available options include:

| Value | Description |
|-----|-----|
| `Auto` | The items are displayed in all layouts based on the ribbon's overflow state(Default) |
| `Classic` | The items are displayed only in the classic layout group. |
| `Simplified` | The items are displayed only in the simplified layout group. |
| `Overflow` | The items are displayed only in the overflow popup. |

Below example demonstrates the usages of `DisplayOptions` property to control the visibility of Ribbon items based on the layout and overflow state.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<div style="width:30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton DisplayOptions="@((DisplayMode)DisplayMode.Classic | DisplayMode.Simplified)">
                                        <RibbonSplitButtonSettings Content="Paste" IconCss="e-icons e-paste" Items="@formatItems"></RibbonSplitButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button DisplayOptions="DisplayMode.Classic">
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button DisplayOptions="DisplayMode.Classic">
                                        <RibbonButtonSettings Content="Copy" IconCss="e-icons e-copy"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button DisplayOptions="DisplayMode.Simplified">
                                        <RibbonButtonSettings Content="Format Painter" IconCss="e-icons e-format-painter"></RibbonButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                    <RibbonGroup Orientation=Orientation.Row HeaderText="Font" PopupHeaderText="Font Options" EnableGroupOverflow="true">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button DisplayOptions="DisplayMode.Classic">
                                        <RibbonButtonSettings Content="Decrease Indent" IconCss="e-icons e-decrease-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button DisplayOptions="DisplayMode.Overflow">
                                        <RibbonButtonSettings Content="Increase Indent" IconCss="e-icons e-increase-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button DisplayOptions="DisplayMode.Overflow">
                                        <RibbonButtonSettings Content="Paragraph" IconCss="e-icons e-paragraph"></RibbonButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code {

    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
        {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
        };
}

{% endhighlight %}
{% endtabs %}

![ Blazor Ribbon display-options classic.](./images/items/blazor-ribbon-displayoption-classic.png)

![Blazor Ribbon Display Options Simplified and Overflow.](./images/items/blazor-ribbon-displayoption-simp-overflow.png)

## Enable/Disable items

You can use the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_Disabled) property to disable particular Ribbon item. It prevents the user interaction when set to `true`. By default, the value is `false`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<div style="width: 30%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton Disabled=true>
                                        <RibbonSplitButtonSettings Content="Paste" IconCss="e-icons e-paste" Items="@formatItems"></RibbonSplitButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Copy" IconCss="e-icons e-copy"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Format Painter" IconCss="e-icons e-format-painter"></RibbonButtonSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                        </RibbonCollections>
                    </RibbonGroup>
                </RibbonGroups>
            </RibbonTab>
        </RibbonTabs>
    </SfRibbon>
</div>

@code{
    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
    {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
    };
}

{% endhighlight %}
{% endtabs %}

![Blazor Ribbon disabled item.](./images/items/blazor-ribbon-disabled-item.png)
