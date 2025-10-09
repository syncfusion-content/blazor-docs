---
layout: post
title: Positioning in Blazor Toast Component | Syncfusion
description: Check out and learn about positioning in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Positioning in Blazor Toast Component

The toast position can be defined using predefined alignments or customized using explicit offsets. Predefined positions are configured using the `X` (horizontal: Left, Center, Right) and `Y` (vertical: Top, Bottom) properties on the position settings of the Toast component.

## Predefined

`X` positions

* Left
* Center
* Right

`Y` positions

* Top
* Bottom

N> When multiple toasts are shown, dynamic changes to position properties do not affect already displayed toasts; the new position is applied to subsequent toasts after the previous messages are removed. If the toast width is set to 100%, it stretches across the container and horizontal (`X`) alignment has no visible effect.

## Custom

Custom `X` and `Y` positions can be provided as pixel values, numbers, or percentages. Numeric values are interpreted as pixels and are applied as offsets from the top and left of the target container (or the viewport when no target is set).

```cshtml

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Target="@ToastTarget" Title="Matt sent you a friend request" Height="@Height" Width="@Width" Content="@ToastContent">
    <ToastPosition X="@PositionX" Y="@PositionY"></ToastPosition>
</SfToast>

<div class="col-lg-12 col-sm-12 col-md-12 center">
    <div id="toastBtnDefault" style="margin: auto; text-align: center">
        <SfButton @onclick="ShowToast"> Show Toast </SfButton>
        <SfButton @onclick="HideToast"> Hide All </SfButton>
    </div>
</div>

<div class='row' style="padding-top: 20px" id="toast_pos_target">
    <div id="toast_pos"> </div>
    <div id="toast_pos_property">
        <table style="width: 100%">
            <tr>
                <td>
                    <div style='padding:25px 0 0 0;'>
                        <SfRadioButton Label="Position" Name="toastPos" Value=@("Position") Checked=@("Position") ValueChange="@RadioButtonChange" TChecked="string"></SfRadioButton>
                    </div>
                </td>
                <td>
                    <div style='padding:25px 0 0 0;'>
                        <SfRadioButton Label="Custom" Name="toastPos" Value=@("Custom") ValueChange="@RadioButtonChange"   Checked=@("Custom")  TChecked="string"></SfRadioButton>
                    </div>
                </td>
            </tr>
            <tr>
                <td id="dropdownChoose" colspan="2" style="display:@DropDownDisplay;">
                    <SfDropDownList @ref="ListObj" Index="5" Placeholder="Select a position" PopupHeight="200PX" DataSource="@DropDownData" TValue="string" TItem="DropDownfields">
                        <DropDownListFieldSettings Text="id" Value="text"></DropDownListFieldSettings>
                        <DropDownListEvents ValueChange="@DropDownChange" TValue="string"></DropDownListEvents>
                    </SfDropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" id="customChoose" style="display:@TextBoxDisplay;">
                    <form id="formId" class="form-horizontal">
                        <div class='e-row'>
                            <SfTextBox @ref="TextXpos" Value="50" Placeholder="X Position" FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
                        </div>
                        <div class='e-row'>
                            <SfTextBox @ref="TextYpos" Value="50" Placeholder="Y Position" FloatLabelType="@FloatLabelType.Auto"></SfTextBox>
                        </div>
                    </form>
                </td>
            </tr>
            <tr>
                <td>
                    <div style='padding:25px 0 0 0;'>
                        <SfRadioButton Label="Target" Name="toast" Value=@("Target") ValueChange="@RadioButtonChange" TChecked="string"></SfRadioButton>
                    </div>
                </td>
                <td>
                    <div style='padding:25px 0 0 0;'>
                        <SfRadioButton Label="Global" Name="toast" Value=@("Global") Checked=@("Global") ValueChange="@RadioButtonChange" TChecked="string"></SfRadioButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>

<style>
    #toast_default .e-meeting::before {
        content: "\e705";
        font-size: 17px;
    }

    #toast_pos_property {
        width: 250px;
    }

        #toast_pos_property td {
            width: 50%;
        }

    #toast_pos_target {
        margin: 50px 200px;
    }
</style>

@code {
    SfToast ToastObj;
    SfTextBox TextXpos;
    SfTextBox TextYpos;
    SfDropDownList<string, DropDownfields> ListObj;

    private bool CustomFlag;
    private string Width = "300";
    private string Height = "auto";
    private string ToastTarget = null;
    private string PositionX = "Center";
    private string PositionY = "Bottom";
    private string DropDownDisplay { get; set; } = "";
    private string TextBoxDisplay { get; set; } = "none";
    private string ToastContent = "You have a new friend request yet to accept";

    public class DropDownfields
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    private List<DropDownfields> DropDownData = new List<DropDownfields>()
    {
        new DropDownfields(){ id= "topleft", text= "Top Left" },
        new DropDownfields(){ id= "topright", text= "Top Right" },
        new DropDownfields(){ id= "topcenter", text= "Top Center" },
        new DropDownfields(){ id= "bottomleft", text= "Bottom Left" },
        new DropDownfields(){ id= "bottomright", text= "Bottom Right" },
        new DropDownfields(){ id= "bottomcenter", text= "Bottom Center" }
    };

    private async Task ShowToast()
    {
        if (CustomFlag)
        {
            this.SetCustomPosValue();
        }
        await ToastObj.ShowAsync();
    }

    private async Task HideToast()
    {
        await ToastObj.HideAsync("All");
    }

    //Setting Toast Custom Position
    private void SetCustomPosValue()
    {
        PositionX = TextXpos.Value;
        PositionY = TextYpos.Value;
    }

    private async Task DropDownChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> e)
    {
        await ToastObj.HideAsync("All");
        this.SetToastPosition(e.Value.ToString());
    }

    private void SetToastPosition(string value)
    {
        switch (value)
        {
            case "Top Left":
                PositionX = "Left";
                PositionY = "Top";
                break;

            case "Top Right":
                PositionX = "Right";
                PositionY = "Top";
                break;

            case "Top Center":
                PositionX = "Center";
                PositionY = "Top";
                break;

            case "Bottom Left":
                PositionX = "Left";
                PositionY = "Bottom";
                break;

            case "Bottom Right":
                PositionX = "Right";
                PositionY = "Bottom";
                break;

            case "Bottom Center":
                PositionX = "Center";
                PositionY = "Bottom";
                break;
        }
    }

    private async Task RadioButtonChange(Syncfusion.Blazor.Buttons.ChangeArgs<string> e)
    {
        if (e.Value == "Target")
        {
            await ToastObj.HideAsync("All");
            ToastTarget = "#toast_pos_target";
            StateHasChanged();
        }
        else if (e.Value == "Global")
        {
            await ToastObj.HideAsync("All");
            ToastTarget = null;
            StateHasChanged();
        }
        else if (e.Value == "Position")
        {
            await ToastObj.HideAsync("All");
            DropDownDisplay = "table-cell";
            TextBoxDisplay = "none";
            this.SetToastPosition(ListObj.Value.ToString());
            CustomFlag = false;
        }
        else if (e.Value == "Custom")
        {
            await ToastObj.HideAsync("All");
            TextBoxDisplay = "table-cell";
            DropDownDisplay = "none";
            this.SetCustomPosValue();
            CustomFlag = true;
        }
    }
}
```