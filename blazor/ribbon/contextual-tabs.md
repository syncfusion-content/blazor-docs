---
layout: post
title: Contextual Tabs in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Contextual Tabs in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# contextual tabs in Blazor Ribbon component

The Ribbon Contextual tabs are similar to the Ribbon tabs that are displayed on demand based on their needs, such as an image or a table tabs. It supports adding all built-in and custom ribbon items to perform specific actions.

## Visible tabs

You can utilize the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonContextualTabSettings.html#Syncfusion_Blazor_Ribbon_RibbonContextualTabSettings_Visible) property to control the visibility of each contextual tab.

## Adding contextual tabs

You can utilize the [ContextualTabs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.ContextualTabs.html#Syncfusion_Blazor_Ribbon_ContextualTabs) property to add contextual tabs in the Ribbon. This property accepts an array of Ribbon tabs, where you can add multiple tabs based on your needs.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using  Syncfusion.Blazor.Buttons;
 
<div class="col-lg-12 control-section default-ribbon-section">
    <div id="ribbonContainer">
        <SfRibbon ID="ribbon">
            <RibbonTabs>
                <RibbonTab HeaderText="Home">
                    <RibbonGroups>
                        <RibbonGroup HeaderText="Clipboard" ID="clipboardGroup" GroupIconCss="e-icons e-paste" ShowLauncherIcon="true">
                            <RibbonCollections>
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
            <RibbonContextualTabs>
                <RibbonContextualTab Visible="true">
                    <RibbonTabs>
                        <RibbonTab ID="ShapeFormat" HeaderText="Shape Format">
                            <RibbonGroups>
                                <RibbonGroup HeaderText="Text decoration" ShowLauncherIcon="true">
                                    <RibbonCollections>
                                        <RibbonCollection>
                                            <RibbonItems>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Text Header" IconCss="e-icons e-text-header"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Text Wrap" IconCss="e-icons e-text-wrap"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Text Annotation" IconCss="e-icons e-text-annotation"></RibbonButtonSettings>
                                                </RibbonItem>
                                            </RibbonItems>
                                        </RibbonCollection>
                                    </RibbonCollections>
                                </RibbonGroup>
                                <RibbonGroup HeaderText="Accessibility">
                                    <RibbonCollections>
                                        <RibbonCollection>
                                            <RibbonItems>
                                                <RibbonItem Type=RibbonItemType.Button AllowedSizes="RibbonItemSize.Large">
                                                    <RibbonButtonSettings Content="Alt Text" IconCss="e-icons e-text-alternative"></RibbonButtonSettings>
                                                </RibbonItem>
                                            </RibbonItems>
                                        </RibbonCollection>
                                    </RibbonCollections>
                                </RibbonGroup>
                                <RibbonGroup HeaderText="Arrange" ShowLauncherIcon="true">
                                    <RibbonCollections>
                                        <RibbonCollection>
                                            <RibbonItems>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Bring Forward" IconCss="e-icons e-bring-forward"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Send Backward" IconCss="e-icons e-send-backward"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Selection Pane" IconCss="e-icons e-show-hide-panel"></RibbonButtonSettings>
                                                </RibbonItem>
                                            </RibbonItems>
                                        </RibbonCollection>
                                    </RibbonCollections>
                                </RibbonGroup>
                            </RibbonGroups>
                        </RibbonTab>
                    </RibbonTabs>
                </RibbonContextualTab>
            </RibbonContextualTabs>
        </SfRibbon>
    </div>
</div>

{% endhighlight %}
{% endtabs %}

![Ribbon Contextual Tabs](./images/contextual-tabs/contextual-tabs.png)

## Selected tabs

By using the [IsSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonContextualTabSettings.html#Syncfusion_Blazor_Ribbon_RibbonContextualTabSettings_IsSelected) property you can control the selected state of each contextual tab and indicates which tab is currently active.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using  Syncfusion.Blazor.Buttons;

<div class="col-lg-12 control-section default-ribbon-section">
    <div id="ribbonContainer">
        <SfRibbon ID="ribbon">
            <RibbonTabs>
                <RibbonTab HeaderText="Home">
                    <RibbonGroups>
                        <RibbonGroup HeaderText="Clipboard" ID="clipboardGroup" GroupIconCss="e-icons e-paste" ShowLauncherIcon="true">
                            <RibbonCollections>
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
            <RibbonContextualTabs>
                <RibbonContextualTab Visible="true" >
                    <RibbonTabs>
                        <RibbonTab HeaderText="Styles">
                            <RibbonGroups>
                                <RibbonGroup HeaderText="Style" ShowLauncherIcon="true">
                                    <RibbonCollections>
                                        <RibbonCollection>
                                            <RibbonItems>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Style" IconCss="e-icons e-style"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Text Box" IconCss="e-icons e-font-name"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Paint" IconCss="e-icons e-paint-bucket"></RibbonButtonSettings>
                                                </RibbonItem>
                                            </RibbonItems>
                                        </RibbonCollection>
                                    </RibbonCollections>
                                </RibbonGroup>
                            </RibbonGroups>
                        </RibbonTab>
                    </RibbonTabs>
                </RibbonContextualTab>
            </RibbonContextualTabs>
        </SfRibbon>
    </div>
</div>

{% endhighlight %}
{% endtabs %}

![Ribbon Selected Tabs](./images/contextual-tabs/selected-tabs.png)

## Methods

### Show tab

You can use the [ShowTab](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.ContextualTabs.html#Syncfusion_Blazor_Ribbon_ShowTab) method to make the specific Contextual tab visible in the Ribbon.

### Hide tab

You can use the [HideTab](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.ContextualTabs.html#Syncfusion_Blazor_Ribbon_HideTab) method to hide specific Contextual tab in the Ribbon.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Ribbon;
@using  Syncfusion.Blazor.Buttons;

<div class="col-lg-12 control-section default-ribbon-section">
    <div id="ribbonContainer">
        <SfButton @onclick="handleShowTab">ShowTab</SfButton>
        <SfButton @onclick="handleHideTab">HideTab</SfButton>
        <SfRibbon ID="ribbon" @ref="ribbon">
            <RibbonTabs>
                <RibbonTab HeaderText="Home">
                    <RibbonGroups>
                        <RibbonGroup HeaderText="Clipboard" ID="clipboardGroup" GroupIconCss="e-icons e-paste" ShowLauncherIcon="true">
                            <RibbonCollections>
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
            <RibbonContextualTabs>
                <RibbonContextualTab>
                    <RibbonTabs>
                        <RibbonTab HeaderText="Arrange & View" ID="ArrangeView">
                            <RibbonGroups>
                                <RibbonGroup HeaderText="Arrange" ShowLauncherIcon="true">
                                    <RibbonCollections>
                                        <RibbonCollection>
                                            <RibbonItems>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Bring Forward" IconCss="e-icons e-bring-forward"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Send Backward" IconCss="e-icons e-send-backward"></RibbonButtonSettings>
                                                </RibbonItem>
                                                <RibbonItem Type=RibbonItemType.Button>
                                                    <RibbonButtonSettings Content="Selection Pane" IconCss="e-icons e-show-hide-panel"></RibbonButtonSettings>
                                                </RibbonItem>
                                            </RibbonItems>
                                        </RibbonCollection>
                                    </RibbonCollections>
                                </RibbonGroup>
                            </RibbonGroups>
                        </RibbonTab>
                    </RibbonTabs>
                </RibbonContextualTab>
            </RibbonContextualTabs>
        </SfRibbon>
    </div>
</div>

@code {

    SfRibbon ribbon;
    private void handleShowTab()
    {
        ribbon.ShowTabAsync("ArrangeView");
    }
    private void handleHideTab()
    {
        ribbon.HideTabAsync("ArrangeView");
    }
}

{% endhighlight %}
{% endtabs %}

![Ribbon Show Hide Tabs](./images/contextual-tabs/show-hide-tabs.png)