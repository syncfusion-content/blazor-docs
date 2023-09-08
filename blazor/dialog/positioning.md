---
layout: post
title: Positioning in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Positioning in Syncfusion Blazor Dialog component and much more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Positioning in Blazor Dialog Component

The [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) can be positioned using the `DialogPositionData` property by providing the X and Y coordinates. It can be positioned inside the target of the `container` or `<body>` of the element based on the given X and Y values.

For X is: left, center, right (or) any offset value
For Y is: top, center, bottom (or) any offset value

The following code demonstrates the different Dialog positions.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="target">
    <div>
        @if (this.ShowButton)
        {
            <SfButton Content="Open Dialog" @onclick="@OpenDialog"></SfButton>
        }
    </div>
    <SfDialog ID="defaultDialog" Target="#target" Width="445px" ShowCloseIcon="true" @bind-Visible="@Visibility">
        <DialogTemplates>
            <Header>
                <div>Choose a Dialog Position</div>
            </Header>
            <Content>
                <table style="width:405px;" id="poschange">
                    <tr>
                        <td>
                            <SfRadioButton ID="LeftTop" TChecked="string" Name="xy" Label="Left Top" Value="left top" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                        <td>
                            <SfRadioButton ID="CenterTop" TChecked="string" Name="xy" Label="Center Top" Value="center top" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                        <td>
                            <SfRadioButton ID="RightTop" TChecked="string" Name="xy" Label="Right Top" Value="right top" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <SfRadioButton ID="LeftCenter" TChecked="string" Name="xy" Label="Left Center" Value="left center" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                        <td>
                            <SfRadioButton ID="CenterCenter" TChecked="string" Name="xy" Label="Center Center" Value="center center" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                        <td>
                            <SfRadioButton ID="RightCenter" TChecked="string" Name="xy" Label="Right Center" Value="right center" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <SfRadioButton ID="LeftBottom" TChecked="string" Name="xy" Label="Left Bottom" Value="left bottom" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                        <td>
                            <SfRadioButton ID="CenterBottom" TChecked="string" Name="xy" Label="Center Bottom" Value="center bottom" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                        <td>
                            <SfRadioButton ID="RightBottom" TChecked="string" Name="xy" Label="Right Bottom" Value="right bottom" @bind-Checked="@Checked" ValueChange="@OnChangeHandler"></SfRadioButton>
                        </td>
                    </tr>
                </table>
            </Content>
            <FooterTemplate><span>Position : { X: '@Xvalue', Y: '@Yvalue' }</span></FooterTemplate>
        </DialogTemplates>
        <DialogPositionData X="@Xvalue" Y="@Yvalue"></DialogPositionData>
        <DialogEvents OnOpen="@BeforeDialogOpen" Closed="@DialogClosed"></DialogEvents>
    </SfDialog>
</div>

<style>
    #defaultDialog table,
    #defaultDialog th,
    #defaultDialog td {
        border: 1px solid #D8D8D8;
        border-collapse: collapse;
    }

    #defaultDialog.e-dialog .e-footer-content {
        padding: 0px 10px 10px;
        text-align: center;
    }

    #target {
        min-height: 450px;
        height: 100%;
    }

    .e-dialog .e-dlg-content {
        padding: 10px 16px 10px;
    }

    .e-radio + label .e-label {
        line-height: 18px;
    }

    td {
        padding: 4px;
    }
</style>

@code {
    private string Xvalue = "center";
    private string Yvalue = "center";
    private bool Visibility { get; set; } = true;
    private bool ShowButton { get; set; } = false;
    private string Checked { get; set; } = "center center";

    private void BeforeDialogOpen(BeforeOpenEventArgs args)
    {
        this.ShowButton = false;
    }

    private void DialogClosed(CloseEventArgs args)
    {
        this.ShowButton = true;
    }

    private void OpenDialog()
    {
        this.Visibility = true;
    }

    private void OnChangeHandler(ChangeArgs<string> arg)
    {
        this.Xvalue = arg.Value.ToString().Split(' ')[0];
        this.Yvalue = arg.Value.ToString().Split(' ')[1];
        this.StateHasChanged();
    }
}

```



![Blazor Dialog displays Different Position](./images/blazor-dialog-position.png)

## See also

* [Positioning in Blazor Dialog Component](https://blazor.syncfusion.com/demos/dialog/positioning)