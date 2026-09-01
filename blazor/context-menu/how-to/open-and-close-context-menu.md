---
layout: post
title: How to open and close Context Menu in Blazor | Syncfusion®
description: Open and close the Blazor Context Menu manually by calling the Open and Close methods with ClientX and ClientY coordinates.
platform: Blazor
control: Context Menu
documentation: ug
---

# How to open and close Context Menu in Blazor

Open and close the Context Menu manually whenever required by using the OpenAsync and Close methods. In the following sample, the Context Menu manually opens while clicking the button using the [OpenAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfContextMenu-1.html#Syncfusion_Blazor_Navigations_SfContextMenu_1_OpenAsync_System_Nullable_System_Double__System_Nullable_System_Double__System_Boolean_) method with `ClientX` and `ClientY` coordinates.

To manually close the Context Menu, the [Close](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfContextMenu-1.html#Syncfusion_Blazor_Navigations_SfContextMenu_1_Close) method can be used.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div id="target">
    <SfContextMenu @ref="contextMenuObj" TValue="MenuItem">
        <MenuItems>
            <MenuItem Text="Cut"></MenuItem>
            <MenuItem Text="Copy"></MenuItem>
            <MenuItem Text="Paste"></MenuItem>
        </MenuItems>
    </SfContextMenu>
    <SfButton @onclick="OpenContextMenu">Open ContextMenu</SfButton>
</div>

@code {
    private SfContextMenu<MenuItem> contextMenuObj;
    private async Task OpenContextMenu(MouseEventArgs e)
    {
        await contextMenuObj.OpenAsync(e.ClientX, e.ClientY);
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrHZRCYfOmvpisg?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Context Menu displays Dialog Menu](./../images/blazor-contextmenu-dialog.webp)" %}