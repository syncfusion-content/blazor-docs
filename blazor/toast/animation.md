---
layout: post
title: Animation in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about animation in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Animation in Blazor Toast Component

The Blazor Toast component supports configurable animations for both showing and hiding notifications through **ToastAnimationSettings**, which contains **ToastShowAnimationSettings** and **ToastHideAnimationSettings**. Animation effects are selected from the **ToastEffect** enum. By default, the toast uses FadeIn for showing and FadeOut for hiding.

For more details, see:
- Blazor Toast overview: https://blazor.syncfusion.com/documentation/toast/
- Toast events: https://blazor.syncfusion.com/documentation/toast/events/
- SfToast API: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.SfToast.html
- ToastEffect enum: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Notifications.ToastEffect.html

The following example demonstrates several animation effects that can be applied to the Toast component.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="Notification" Content="@ToastContent">
    <ToastPosition X="Right" Y="Bottom"></ToastPosition>
    <ToastAnimationSettings>
        <ToastShowAnimationSettings Effect="@ShowAnimation"></ToastShowAnimationSettings>
        <ToastHideAnimationSettings Effect="@HideAnimation"></ToastHideAnimationSettings>
    </ToastAnimationSettings>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div id="toastBtnDefault" style="margin: auto; text-align: center">
        <div id="textbox-contain">
            <div>
                <label>Show Animation</label>
            </div>
            <SfDropDownList Placeholder="Select an animation type"
                            DataSource="@Effects"
                            TValue="string"
                            TItem="DropDownFields">
                <DropDownListEvents ValueChange="@ShowAnimationChange" TValue="string"></DropDownListEvents>
                <DropDownListFieldSettings Text="text" Value="id"></DropDownListFieldSettings>
            </SfDropDownList>

            <div style="margin-top:10px">
                <label>Hide Animation</label>
            </div>
            <SfDropDownList Placeholder="Select an animation type"
                            DataSource="@Effects"
                            TValue="string"
                            TItem="DropDownFields">
                <DropDownListEvents ValueChange="@HideAnimationChange" TValue="string"></DropDownListEvents>
                <DropDownListFieldSettings Text="text" Value="id"></DropDownListFieldSettings>
            </SfDropDownList>
        </div>

        <div style="margin-top:12px">
            <SfButton OnClick="@ShowToast">Show Toast</SfButton>
        </div>
    </div>
</div>

@code {
    private SfToast ToastObj;

    private ToastEffect ShowAnimation = ToastEffect.FadeIn;
    private ToastEffect HideAnimation = ToastEffect.FadeOut;
    private string ToastContent = "A new friend request is pending.";

    public class DropDownFields
    {
        public string id { get; set; } = string.Empty;
        public string text { get; set; } = string.Empty;
    }

    private List<DropDownFields> Effects = new List<DropDownFields>
    {
        new DropDownFields { id = "FadeIn",             text = "Fade In" },
        new DropDownFields { id = "FadeZoomIn",         text = "Fade Zoom In" },
        new DropDownFields { id = "FadeZoomOut",        text = "Fade Zoom Out" },
        new DropDownFields { id = "FlipLeftDownIn",     text = "Flip Left Down In" },
        new DropDownFields { id = "FlipLeftDownOut",    text = "Flip Left Down Out" },
        new DropDownFields { id = "FlipLeftUpIn",       text = "Flip Left Up In" },
        new DropDownFields { id = "FlipRightDownIn",    text = "Flip Right Down In" },
        new DropDownFields { id = "FlipRightDownOut",   text = "Flip Right Down Out" },
        new DropDownFields { id = "FlipRightUpIn",      text = "Flip Right Up In" },
        new DropDownFields { id = "FlipRightUpOut",     text = "Flip Right Up Out" },
        new DropDownFields { id = "SlideBottomIn",      text = "Slide Bottom In" },
        new DropDownFields { id = "SlideBottomOut",     text = "Slide Bottom Out" },
        new DropDownFields { id = "SlideLeftIn",        text = "Slide Left In" },
        new DropDownFields { id = "SlideLeftOut",       text = "Slide Left Out" },
        new DropDownFields { id = "SlideRightIn",       text = "Slide Right In" },
        new DropDownFields { id = "SlideRightOut",      text = "Slide Right Out" },
        new DropDownFields { id = "SlideTopIn",         text = "Slide Top In" },
        new DropDownFields { id = "ZoomIn",             text = "Zoom In" },
        new DropDownFields { id = "ZoomOut",            text = "Zoom Out" }
    };

    private async Task ShowToast()
    {
        await ToastObj.ShowAsync();
    }

    private void ShowAnimationChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> args)
    {
        ShowAnimation = (ToastEffect)System.Enum.Parse(typeof(ToastEffect), args.Value);
        StateHasChanged();
    }

    private void HideAnimationChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> args)
    {
        HideAnimation = (ToastEffect)System.Enum.Parse(typeof(ToastEffect), args.Value);
        StateHasChanged();
    }
}
```
Preview of the code snippet:
- Selecting animation types in the dropdowns configures the show and hide effects for the toast.
- Clicking Show Toast displays a toast at the bottom-right using the selected show animation; when dismissed, the selected hide animation is applied.
- Defaults are Fade In for showing and Fade Out for hiding.