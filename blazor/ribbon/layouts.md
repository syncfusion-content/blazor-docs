---
layout: post
title: Layouts in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Layouts in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Layouts in Blazor Ribbon component

The Ribbon component supports customizable layouts through the [ActiveLayout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_ActiveLayout) property. Two primary layouts are available: `Classic` and `Simplified`.

## Classic layout

The Classic layout organizes Ribbon items and groups in a traditional, multi-row format with group headers and collections. Set the [ActiveLayout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_ActiveLayout) property to `RibbonLayout.Classic` to enable this layout. By default, the Ribbon renders in the `Classic` layout.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<div style="width:30%">
    <SfRibbon ActiveLayout="RibbonLayout.Classic">
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton>
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

![Ribbon Classic Layout](./images/layouts/ribbon_classic.png)

### Defining items size

Control the size of Ribbon items using the [AllowedSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html#Syncfusion_Blazor_Ribbon_RibbonItem_AllowedSizes) property in the [RibbonItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html) directive. The Ribbon supports three item sizes:

- **Large**: Large icon with text.
- **Medium**: Small icon with text.
- **Small**: Small icon only.

When resizing to a smaller screen, item sizes adapt based on the available tab content width in the order Large → Medium → Small, and vice versa when space increases.

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
                                <RibbonItem Type=RibbonItemType.SplitButton Disabled=true AllowedSizes="RibbonItemSize.Large">
                                    <RibbonSplitButtonSettings Content="Paste" IconCss="e-icons e-paste" Items="@formatItems"></RibbonSplitButtonSettings>
                                </RibbonItem>
                            </RibbonItems>
                        </RibbonCollection>
                        <RibbonCollection>
                            <RibbonItems>
                                <RibbonItem Type=RibbonItemType.Button AllowedSizes="RibbonItemSize.Medium">
                                    <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut"></RibbonButtonSettings>
                                </RibbonItem>
                                <RibbonItem Type=RibbonItemType.Button AllowedSizes="RibbonItemSize.Medium">
                                    <RibbonButtonSettings Content="Copy" IconCss="e-icons e-copy"></RibbonButtonSettings>
                                </RibbonItem>
                                <RibbonItem Type=RibbonItemType.Button AllowedSizes="RibbonItemSize.Small">
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

![Ribbon Item AllowedSizes](./images/layouts/ribbon_allowedSizes.png)

### Defining items orientation

Use the [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_Orientation) property of the [RibbonGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html) tag directive to arrange items vertically (Column) or horizontally (Row). The default orientation is `Column`.

- Row: A group may contain up to three collections, and each collection can include multiple items.
- Column: A group can contain any number of collections. Each collection can include either one large-sized item or up to three medium/small-sized items.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;
@using Syncfusion.Blazor.DropDowns;

<div style="width:60%">
    <SfRibbon ActiveLayout="RibbonLayout.Classic">
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
                    <RibbonGroup Orientation=Orientation.Row HeaderText="Font">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings @bind-Value="@fontFamValue" AllowFiltering=true DataSource="@fontFamilyItems" FieldSettings="@fieldSetings"></RibbonComboBoxSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings Index="3" AllowFiltering=true DataSource="@fontSizeItems" FieldSettings="@fieldSetings"></RibbonComboBoxSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Decrease Indent" IconCss="e-icons e-decrease-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Increase Indent" IconCss="e-icons e-increase-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
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

    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
        {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
        };
}

{% endhighlight %}
{% endtabs %}

![Ribbon Group Orientation](./images/layouts/ribbon_orientation.png)

### Defining group properties

Customize the appearance and functionality of Ribbon groups using [RibbonGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html) properties such as `HeaderText`, `GroupIconCss`, `ShowLauncherIcon`, `IsCollapsible`, and `Priority`.

|Name|DataType|Description|
|---|---|---|
|[HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_HeaderText)|string|Defines the text that appears as the header for the group.|
|[GroupIconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_GroupIconCss)|string|Specifies the icon displayed in the group popup button during resizing.|
|[ShowLauncherIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_ShowLauncherIcon)|bool|Enables or disables the launcher icon for the group. By default, this property is set to `false`.|
|[IsCollapsible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_IsCollapsible)|bool|Controls whether a group can be collapsed during resizing. By default, this property is set to `true`.|
|[Priority](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_Priority)|int|Determines the collapse/expand order during resizing. Higher values collapse first; lower values expand first.|

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;
@using Syncfusion.Blazor.DropDowns;

<div style="width:60%">
    <SfRibbon>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard" GroupIconCss="e-icons e-paste" Priority="1">
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
                    <RibbonGroup Orientation=Orientation.Row HeaderText="Font" ShowLauncherIcon="true" GroupIconCss="e-icons e-bold" IsCollapsible=false Priority="0">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings @bind-Value="@fontFamValue" ShowClearButton="true" AllowFiltering=true DataSource="@fontFamilyItems" FieldSettings="@fieldSetings"></RibbonComboBoxSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings Index="3" AllowFiltering=true DataSource="@fontSizeItems" FieldSettings="@fieldSetings"></RibbonComboBoxSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Decrease Indent" IconCss="e-icons e-decrease-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Increase Indent" IconCss="e-icons e-increase-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
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

    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
        {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
        };
}

{% endhighlight %}
{% endtabs %}

![Ribbon Group Properties](./images/layouts/ribbon_group_properties.png)

## Simplified layout

In the Simplified layout, the Ribbon organizes items and groups into a single row to save vertical space and emphasize frequently used commands. Set the [ActiveLayout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_ActiveLayout) property to `RibbonLayout.Simplified` to enable this layout.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<div style="width:50%">
    <SfRibbon ActiveLayout="RibbonLayout.Simplified">
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton>
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

![Ribbon Simplified Layout](./images/layouts/ribbon_simplified.png)

### Enabling group overflow popup

Control how overflow items appear within a group during resizing using the [EnableGroupOverflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_EnableGroupOverflow) property.

- Set to `true` to display overflow items in a separate popup near the group.
- Set to `false` to display overflow items in a common popup at the right end of the tab content.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;
@using Syncfusion.Blazor.DropDowns;

<div style="width:48%">
    <SfRibbon ActiveLayout="RibbonLayout.Simplified">
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
                    <RibbonGroup Orientation=Orientation.Row HeaderText="Font" EnableGroupOverflow="true">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings @bind-Value="@fontFamValue" ShowClearButton="true" AllowFiltering=true DataSource="@fontFamilyItems" FieldSettings="@fieldSetings"></RibbonComboBoxSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.ComboBox>
                                        <RibbonComboBoxSettings Index="3" AllowFiltering=true DataSource="@fontSizeItems" FieldSettings="@fieldSetings"></RibbonComboBoxSettings>
                                    </RibbonItem>
                                </RibbonItems>
                            </RibbonCollection>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Decrease Indent" IconCss="e-icons e-decrease-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Increase Indent" IconCss="e-icons e-increase-indent"></RibbonButtonSettings>
                                    </RibbonItem>
                                    <RibbonItem Type=RibbonItemType.Button>
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

    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
        {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
        };
}

{% endhighlight %}
{% endtabs %}

![Ribbon Group Overflow](./images/layouts/ribbon_groupoverflow.png)

## Minimized state

Hide Ribbon contents and display only the tab headers by double-clicking a tab header to toggle the minimized state. When the Ribbon is in a minimized state, clicking a tab header temporarily expands the content; the Ribbon returns to the minimized state when focus moves away.

The minimized state can also be controlled programmatically using the [IsMinimized](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_IsMinimized) property. By default, this property is set to `false`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<div style="width:50%">
    <SfRibbon IsMinimized="true">
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton>
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

![Ribbon Minimized](./images/layouts/ribbon_minimized.png)

## Show or hide the layout switcher

Use the [HideLayoutSwitcher](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html#Syncfusion_Blazor_Ribbon_SfRibbon_HideLayoutSwitcher) property to show or hide the Ribbon layout switcher button. By default, this property is set to `false`, so the switcher is visible.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<div style="width:50%">
    <SfRibbon HideLayoutSwitcher="true">
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.SplitButton>
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

![Ribbon Layout Switcher](./images/layouts/ribbon_layoutswitcher.png)