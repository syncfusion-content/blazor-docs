---
layout: post
title: Animation in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about animation in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Animation in Blazor Toast Component

The toast component supports custom animations for both show and hide actions from the provided `ToastHideAnimationSettings` and  `ToastShowAnimationSettings` option of the `Animation` library. The default animation is given as `FadeIn` for showing the toast and `FadeOut` for hiding the toast.

The following sample demonstrates some types of animations that suit toast.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="Matt sent you a friend request" Content="@ToastContent">
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
                <label> Show Animation </label>
            </div>
            <SfDropDownList Placeholder="Select a animate type" DataSource="@Effects" TValue="string" TItem="DropDownFields">
                <DropDownListEvents ValueChange="@ShowAnimationChange" TValue="string"></DropDownListEvents>
                <DropDownListFieldSettings Text="text" Value="id"></DropDownListFieldSettings>
            </SfDropDownList>

            <div>
                <label> Hide Animation </label>
            </div>
            <SfDropDownList Placeholder="Select a animate type" DataSource="@Effects" TValue="string" TItem="DropDownFields">
                <DropDownListEvents ValueChange="@HideAnimationChange" TValue="string"></DropDownListEvents>
                <DropDownListFieldSettings Text="text" Value="id"></DropDownListFieldSettings>
            </SfDropDownList>
        </div>
        <SfButton @onclick="@ShowToast"> Show Toast </SfButton>
    </div>
</div>

<style>
    #elementToastTime .e-toast-message {
        padding: 10px;
        text-align: center;
    }

    #textbox-contain {
        text-align: initial;
        display: inline-block;
        width: 20%;
        margin: 0 auto;
    }

    .top-row.px-4 {
        display: none;
    }

    .content.px-4 {
        margin-top: 103px;
        margin-left: -12%;
    }
</style>

@code {
    SfToast ToastObj;

    private ToastEffect ShowAnimation = ToastEffect.FadeIn;
    private ToastEffect HideAnimation = ToastEffect.FadeOut;
    private string ToastContent = "You have a new friend request yet to accept";

    public class DropDownFields
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    private List<DropDownFields> Effects = new List<DropDownFields>()
{
        new DropDownFields(){ id= "FadeIn", text= "Fade In" },
        new DropDownFields(){ id= "FadeZoomIn", text= "Fade Zoom In" },
        new DropDownFields(){ id= "FadeZoomOut", text= "Fade Zoom Out" },
        new DropDownFields(){ id= "FlipLeftDownIn", text= "Flip Left Down In" },
        new DropDownFields(){ id= "FlipLeftDownOut", text= "Flip Left Down Out" },
        new DropDownFields(){ id= "FlipLeftUpIn", text= "Flip Left Up In" },
        new DropDownFields(){ id= "FlipRightDownIn", text= "Flip Right Up In" },
        new DropDownFields(){ id= "FlipRightDownOut", text= "Flip Right Down Out" },
        new DropDownFields(){ id= "FlipRightUpIn", text= "Flip Right Up In" },
        new DropDownFields(){ id= "FlipRightUpOut", text= "Flip Right Up Out" },
        new DropDownFields(){ id= "SlideBottomIn", text= "Slide Bottom In" },
        new DropDownFields(){ id= "SlideBottomOut", text= "Slide Bottom Out" },
        new DropDownFields(){ id= "SlideLeftIn", text= "Slide Left In" },
        new DropDownFields(){ id= "SlideLeftOut", text= "Slide Left Out" },
        new DropDownFields(){ id= "SlideRightIn", text= "Slide Right In" },
        new DropDownFields(){ id= "SlideRightOut", text= "Slide Right Out" },
        new DropDownFields(){ id= "SlideTopIn", text= "Slide Top In" },
        new DropDownFields(){ id= "ZoomIn", text= "Zoom In" },
        new DropDownFields(){ id= "ZoomOut", text= "Zoom Out" }
    };

    private async Task ShowToast()
    {
        await ToastObj.ShowAsync();
    }

    private void ShowAnimationChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> args)
    {
        this.ShowAnimation  = (ToastEffect)System.Enum.Parse(typeof(ToastEffect), args.Value);
        StateHasChanged();
    }

    private void HideAnimationChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> args)
    {
        this.HideAnimation = (ToastEffect)System.Enum.Parse(typeof(ToastEffect), args.Value);
        StateHasChanged();
    }
}

```