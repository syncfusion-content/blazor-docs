---
layout: post
title: File Menu in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about File Menu in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# File Menu in Blazor Ribbon Component

The Blazor Ribbon component features a built-in file menu to accommodate commands for handling files, such as `New`, `Open`, and `Save`. This guide demonstrates how to configure the file menu, add items, and handle events using the [RibbonFileMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html) tag directive within the [SfRibbon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.SfRibbon.html).

## Visibility

To display the file menu, set the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_Visible) property of the [RibbonFileMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html) tag directive to `true`. By default, this property is `false`, and the file menu is hidden.

## Adding Menu Items

Add items to the file menu by binding a list of `MenuItem` objects to the [MenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_MenuItems) property of the [RibbonFileMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html) tag directive. Each `MenuItem` can have properties such as [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Text), [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_IconCss), and a list of nested sub-menu items.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;
@using Syncfusion.Blazor.Navigations;

<div style="width:40%">
    <SfRibbon>
        <RibbonFileMenuSettings Visible=true MenuItems="@fileMenuItems"></RibbonFileMenuSettings>
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
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut" ></RibbonButtonSettings>
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

    List<MenuItem> fileMenuItems = new List<MenuItem>()
    {
        new MenuItem { Text = "New", IconCss = "e-icons e-file-new", Id = "new" },
        new MenuItem { Text = "Open", IconCss = "e-icons e-folder-open", Id = "open" },
        new MenuItem { Text = "Rename", IconCss = "e-icons e-rename", Id = "rename" },
        new MenuItem {
            Text = "Save as",
            IconCss = "e-icons e-save",
            Id = "save",
            Items = new List<MenuItem>() {
                new MenuItem { Text = "Microsoft Word (.docx)", IconCss = "sf-icon-word", Id = "word" },
                new MenuItem { Text = "Microsoft Word 97-2003(.doc)", IconCss = "sf-icon-word", Id = "word97" },
                new MenuItem { Text = "Download as PDF", IconCss = "e-icons e-export-pdf", Id = "pdf" }
            }
        }
    };
}

{% endhighlight %}
{% endtabs %}

![Ribbon Filemenu Items](./images/filemenu/filemenu_items.png)

## Open Submenu on Click

By default, the file menu opens submenus on mouse hover. To change this behavior to open on a menu item click, set the [ShowItemOnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_ShowItemOnClick) property to `true`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;
@using Syncfusion.Blazor.Navigations;

<div style="width:40%">
    <SfRibbon>
        <RibbonFileMenuSettings Visible=true MenuItems="@fileMenuItems" ShowItemOnClick="true"></RibbonFileMenuSettings>
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
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut" ></RibbonButtonSettings>
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

    List<MenuItem> fileMenuItems = new List<MenuItem>()
    {
        new MenuItem { Text = "New", IconCss = "e-icons e-file-new", Id = "new" },
        new MenuItem { Text = "Open", IconCss = "e-icons e-folder-open", Id = "open" },
        new MenuItem { Text = "Rename", IconCss = "e-icons e-rename", Id = "rename" },
        new MenuItem {
            Text = "Save as",
            IconCss = "e-icons e-save",
            Id = "save",
            Items = new List<MenuItem>() {
                new MenuItem { Text = "Microsoft Word (.docx)", IconCss = "sf-icon-word", Id = "word" },
                new MenuItem { Text = "Microsoft Word 97-2003(.doc)", IconCss = "sf-icon-word", Id = "word97" },
                new MenuItem { Text = "Download as PDF", IconCss = "e-icons e-export-pdf", Id = "pdf" }
            }
        }
    };
}

{% endhighlight %}
{% endtabs %}

## Custom Header Text

To define custom header text for the file menu, use the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_Text) property of the [RibbonFileMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html) tag directive. The default text is `File`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;
@using Syncfusion.Blazor.Navigations;

<div style="width:40%">
    <SfRibbon>
        <RibbonFileMenuSettings Text="Help" Visible=true MenuItems="@fileMenuItems" ShowItemOnClick="true"></RibbonFileMenuSettings>
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
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut" ></RibbonButtonSettings>
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

    List<MenuItem> fileMenuItems = new List<MenuItem>()
    {
        new MenuItem { Text = "New", IconCss = "e-icons e-file-new", Id = "new" },
        new MenuItem { Text = "Open", IconCss = "e-icons e-folder-open", Id = "open" },
        new MenuItem { Text = "Rename", IconCss = "e-icons e-rename", Id = "rename" },
        new MenuItem {
            Text = "Save as",
            IconCss = "e-icons e-save",
            Id = "save",
            Items = new List<MenuItem>() {
                new MenuItem { Text = "Microsoft Word (.docx)", IconCss = "sf-icon-word", Id = "word" },
                new MenuItem { Text = "Microsoft Word 97-2003(.doc)", IconCss = "sf-icon-word", Id = "word97" },
                new MenuItem { Text = "Download as PDF", IconCss = "e-icons e-export-pdf", Id = "pdf" }
            }
        }
    };
}

{% endhighlight %}
{% endtabs %}

![Ribbon Filemenu Items](./images/filemenu/filemenu_customheader.png)

## Events

The `RibbonFileMenuSettings` component exposes several events to control the behavior of the file menu.

|Name|Args|Description|
|---|---|---|
|[FileMenuOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_FileMenuOpening)|FileMenuOpenEventArgs|Triggers before the file menu popup opens.|
|[FileMenuClosing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_FileMenuClosing)|FileMenuCloseEventArgs|Triggers before the file menu popup closes.|
|[FileMenuOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_FileMenuOpened)|FileMenuOpenedEventArgs|Triggers after the file menu popup has opened.|
|[FileMenuClosed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_FileMenuClosed)|FileMenuClosedEventArgs|Triggers after the file menu popup has closed.|
|[FileMenuItemRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_FileMenuItemRendering)|FileMenuItemRenderEventArgs|Triggers while a file menu item is being rendered.|
|[ItemSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonFileMenuSettings.html#Syncfusion_Blazor_Ribbon_RibbonFileMenuSettings_ItemSelecting)|FileMenuItemSelectEventArgs|Triggers when a file menu item is selected.|

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;
@using Syncfusion.Blazor.Navigations;

<div style="width:40%">
    <SfRibbon>
        <RibbonFileMenuSettings Visible=true 
                                MenuItems="@fileMenuItems" 
                                FileMenuOpening="FileMenuOpening" 
                                FileMenuClosing="FileMenuClosing" 
                                FileMenuOpened="FileMenuOpened" 
                                FileMenuClosed="FileMenuClosed" 
                                FileMenuItemRendering="FileMenuItemRendering" 
                                ItemSelecting="ItemSelecting">
        </RibbonFileMenuSettings>
        <RibbonTabs>
            <RibbonTab HeaderText="Home">
                <RibbonGroups>
                    <RibbonGroup HeaderText="Clipboard">
                        <RibbonCollections>
                            <RibbonCollection>
                                <RibbonItems>
                                    <RibbonItem Type=RibbonItemType.Button>
                                        <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut" ></RibbonButtonSettings>
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

    private void FileMenuOpening(FileMenuOpenEventArgs args) { /* your actions here */ }

    private void FileMenuClosing(FileMenuCloseEventArgs args) { /* your actions here */ }

    private void FileMenuOpened(FileMenuOpenedEventArgs args) { /* your actions here */ }

    private void FileMenuClosed(FileMenuClosedEventArgs args) { /* your actions here */ }

    private void FileMenuItemRendering(FileMenuItemRenderEventArgs args) { /* your actions here */ }

    private void ItemSelecting(FileMenuItemSelectEventArgs args) { /* your actions here */ }

    List<MenuItem> fileMenuItems = new List<MenuItem>()
    {
        new MenuItem { Text = "New", IconCss = "e-icons e-file-new", Id = "new" },
        new MenuItem { Text = "Open", IconCss = "e-icons e-folder-open", Id = "open" },
        new MenuItem { Text = "Rename", IconCss = "e-icons e-rename", Id = "rename" },
        new MenuItem {
            Text = "Save as",
            IconCss = "e-icons e-save",
            Id = "save",
            Items = new List<MenuItem>() {
                new MenuItem { Text = "Microsoft Word (.docx)", IconCss = "sf-icon-word", Id = "word" },
                new MenuItem { Text = "Microsoft Word 97-2003(.doc)", IconCss = "sf-icon-word", Id = "word97" },
                new MenuItem { Text = "Download as PDF", IconCss = "e-icons e-export-pdf", Id = "pdf" }
            }
        }
    };
}

{% endhighlight %}
{% endtabs %}