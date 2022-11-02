---
layout: post
title: Template with Blazor SpeedDial Component | Syncfusion
description: Checkout and learn about template with Blazor SpeedDial component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Template in Blazor SpeedDial

This section has a detailed explanation on the available templates in Speed Dial Component.

## Item Template

You can use the [`ItemTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_ItemTemplate) tag directive to get or set a template content for the SpeedDialItem. The template content is defined as a child content of `ItemTemplate` tag directive.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial Content="Edit" OpenIconCss="e-icons e-edit" Position="FabPosition.BottomRight">
    <ChildContent>
        <SpeedDialItems>
            <SpeedDialItem Text="Cut" IconCss="e-icons e-cut" />
            <SpeedDialItem Text="Copy" IconCss="e-icons e-copy" />
            <SpeedDialItem Text="Paste" IconCss="e-icons e-paste" />
        </SpeedDialItems>
    </ChildContent>
    <ItemTemplate>
        <div class="itemlist">
            <span class="@context.IconCss" style="padding:3px"></span>
            <span class="text" style="padding:0 5px">@context.Text</span>
        </div>
    </ItemTemplate>
</SfSpeedDial>

<style>  
    .e-speeddial-li .itemlist {
        display: inherit;
        width: 100%;
        border: 1px solid transparent;
        align-items: center;
        padding: 5px;
        border-radius: 500px;
        background-color: rgba(104, 99, 104, 0.1);
        box-shadow: 0 0 4px grey;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with ItemTemplate](./images/ItemTemplate.png)

## Popup Template

You can use the [`PopupTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSpeedDial.html#Syncfusion_Blazor_Buttons_SfSpeedDial_PopupTemplate) tag directive to get or set a template content popup of SpeedDialItem. The template content is defined as a child content of `PopupTemplate` tag directive.

{% tabs %}  
{% highlight razor %}

@using Syncfusion.Blazor.Buttons

<SfSpeedDial CssClass="popupSpeedDial" Content="FeedBack"> 
    <PopupTemplate>
        <div class="speeddial-form">
            <p>Here you can customize your code.</p>
        </div>
    </PopupTemplate>
</SfSpeedDial>

<style>
    .speeddial-form {
        width: 200px;
        height: 80px;
        text-align: center;
        border-radius: 15px;
        box-shadow: rgb(0 0 0 / 10%) 0px 10px 15px -3px, rgb(0 0 0 / 5%) 0px 4px 6px -2px;
        background: #f5f5f5;
        padding: 15px;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor SpeedDial with PopupTemplate](./images/SDPopupTemp.png)