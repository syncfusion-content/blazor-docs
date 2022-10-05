---
layout: post
title: Native Events in FloatingActionButton Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion FloatingActionButton component and much more.
platform: Blazor
control: FloatingActionButton
documentation: ug
---

# Native Events in Floating Action Button Component

You can define the native event using `event` attribute in component. The value of attribute is treated as an event handler. The event specific data will be available in event arguments.

The different event argument types for each event are,

* Focus Events - UIFocusEventArgs
* Mouse Events - UIMouseEventArgs

## How to bind click event to Floating Action Button

The `onclick` attribute is used to bind the click event for button. Here, we have explained about the sample code snippets of toggle button.

```csharp

    @using Syncfusion.Blazor.Buttons

    <div id="target" style="min-height:200px; position:relative; width:300px; border:1px solid;">
        <SfFab id="fab" @ref="FabBtn" Target="#target" IconCss="@IconCss" Position="FabPosition.BottomRight" IsToggle="true" OnClick="@onToggleClick"></SfFab>
    </div>

    <style>
        .e-play::before{
            content:'\e327';
        }
        .e-pause::before{
            content:'\e325';
        }
    </style>

    @code{
        SfFab FabBtn;
        public string IconCss = "e-icons e-play";
        private void onToggleClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
        {
            if (FabBtn.IconCss == "e-icons e-play")
            {
                IconCss = "e-icons e-pause";
            }
            else
            {
                IconCss = "e-icons e-play";
            }
        }
    }

```

![Blazor Native Event Floating Action Button]()