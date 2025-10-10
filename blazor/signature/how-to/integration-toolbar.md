---
layout: post
title: Toolbar Integration with Blazor Signature Component | Syncfusion
description: Checkout and learn about getting started with Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# Integration Signature with Toolbar

The Signature component can be integrated with a toolbar to provide common actions such as undo, redo, clear, save, color selection, and stroke width adjustments. In this example, the toolbar buttons and pickers interact with the Signature using its events and APIs:
- The Signature Changed event updates button states after each stroke.
- CanUndoAsync, CanRedoAsync, and IsEmptyAsync determine whether Undo, Redo, and Clear/Save should be enabled.
- SaveAsync is used to export the signature, with SplitButton events (Clicked and ItemSelected) selecting the format (PNG, JPEG, SVG).
- ColorPicker ValueChange updates stroke and background colors.
- DropDownList ValueChange adjusts MaxStrokeWidth.
- CheckBox ValueChange toggles the Disabled state.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.SplitButtons

<div class="control-section">
    <div id="signature-toolbar-control">
        <SfToolbar ID="toolbar">
            <ToolbarItems>
                <ToolbarItem Type="@ItemType.Button" TooltipText="Undo (Ctrl + Z)">
                    <Template>
                        <SfButton Disabled="undoDisabled" @ref="undoButton" IconCss="e-icons e-undo" @onclick="@onUndo" Content="Undo" />
                    </Template>
                </ToolbarItem>
                <ToolbarItem Type="@ItemType.Button" TooltipText="Redo (Ctrl + Y)">
                    <Template>
                        <SfButton Disabled="redoDisabled" @ref="redoButton" IconCss="e-icons e-redo" @onclick="@onRedo" Content="Redo" />
                    </Template>
                </ToolbarItem>
                <ToolbarItem Type="@ItemType.Separator" />
                <ToolbarItem Type="@ItemType.Button" TooltipText="save">
                    <Template>
                        <SfSplitButton Content="Save" IconCss="e-sign-icons e-save" Disabled="saveDisabled">
                            <SplitButtonEvents Clicked="onSaveClicked" ItemSelected="onSaveType" />
                            <DropDownMenuItems>
                                <DropDownMenuItem Text="PNG" />
                                <DropDownMenuItem Text="JPEG" />
                                <DropDownMenuItem Text="SVG" />
                            </DropDownMenuItems>
                        </SfSplitButton>
                    </Template>
                </ToolbarItem>
                <ToolbarItem Type="@ItemType.Separator" />
                <ToolbarItem Type="@ItemType.Button" TooltipText="Stroke Color">
                    <Template>
                        <SfColorPicker Mode="ColorPickerMode.Palette" CssClass="circle-palette" Value="@strokeColor" ShowButtons="false" ModeSwitcher="false" Columns="4" PresetColors="@circlePaletteColors" ValueChange="@onStrokeColor" />
                    </Template>
                </ToolbarItem>
                <ToolbarItem Type="@ItemType.Separator" />
                <ToolbarItem Type="@ItemType.Button" TooltipText="Background Color">
                    <Template>
                        <SfColorPicker CssClass="circle-palette e-bg-color" NoColor="true" Mode="ColorPickerMode.Palette" Value="@backgroundColor" ShowButtons="false" ModeSwitcher="false" Columns="4" PresetColors="@circlePaletteColors1" ValueChange="@onBgColor" />
                    </Template>
                </ToolbarItem>
                <ToolbarItem Type="@ItemType.Separator" />
                <ToolbarItem Type="@ItemType.Input" TooltipText="Stroke Width">
                    <Template>
                        <SfDropDownList TItem="double" TValue="double" Width="60px" Value="@maxStrokeWidth" DataSource="@data">
                            <DropDownListEvents TItem="double" TValue="double" ValueChange="@ValueChangeHandler" />
                        </SfDropDownList>
                    </Template>
                </ToolbarItem>
                <ToolbarItem Type="@ItemType.Separator" />
                <ToolbarItem Type="@ItemType.Button" TooltipText="Clear">
                    <Template>
                        <SfButton Disabled="clearDisabled" @ref="clearButton" IconCss="e-sign-icons e-clear" @onclick="@onClear" Content="Clear" />
                    </Template>
                </ToolbarItem>
                <ToolbarItem Type="ItemType.Input" Align="ItemAlign.Right" TooltipText="Disabled">
                    <Template>
                        <SfCheckBox Label="Disabled" ValueChange="@onDisabled" TChecked="bool" />
                    </Template>
                </ToolbarItem>
            </ToolbarItems>
        </SfToolbar>
        <div id="signature-control">
            <SfSignature id="signature" @ref="signature" style=" width: 100%; height: 100%;" BackgroundColor="@backgroundColor" StrokeColor="@strokeColor"
                         Disabled="@disabled" MaxStrokeWidth="@maxStrokeWidth" Changed="SignChanged" />
        </div>
    </div>
</div>
@code{
    private SfSignature signature;
    private string backgroundColor = "#ffffff";
    private string strokeColor = "#000000";
    private double maxStrokeWidth = 2;
    private bool disabled = false;
    private SfButton clearButton;
    private SfButton undoButton;
    private SfButton redoButton;
    private bool redoDisabled = true;
    private bool undoDisabled = true;
    private bool clearDisabled = true;
    private bool saveDisabled = true;
    private SignatureFileType type = SignatureFileType.Png;
    private Dictionary<string, string[]> circlePaletteColors = new Dictionary<string, string[]>() {
        { "Custom", new string[] {"#000000", "#e91e63", "#9c27b0", "#673ab7", "#2196f3", "#03a9f4", "#00bcd4",
        "#009688", "#8bc34a", "#cddc39", "#ffeb3b", "#ffc107" } }
    };
    private Dictionary<string, string[]> circlePaletteColors1 = new Dictionary<string, string[]>() {
        { "Custom", new string[] {"#ffffff", "#f44336", "#e91e63", "#9c27b0", "#673ab7", "#2196f3", "#03a9f4", "#00bcd4",
        "#009688", "#8bc34a", "#cddc39", "#ffeb3b" } }
    };
    public double[] data = new double[] { 1, 2, 3, 4, 5 };
    private async Task SignChanged()
    {
        await updateSaveClear();
        await updateUndoRedo();
    }
    private void ValueChangeHandler(Syncfusion.Blazor.DropDowns.ChangeEventArgs<double, double> args)
    {
        maxStrokeWidth = args.Value;
    }
    private async Task onUndo()
    {
        bool canUndo = await signature.CanUndoAsync();
        if (canUndo)
        {
            await signature.UndoAsync();
            await updateUndoRedo();
            await updateSaveClear();
        }
    }
    private async Task onRedo()
    {
        bool canRedo = await signature.CanRedoAsync();
        if (canRedo)
        {
            await signature.RedoAsync();
            await updateUndoRedo();
            await updateSaveClear();
        }
    }
    private async Task updateUndoRedo()
    {
        bool canUndo = await signature.CanUndoAsync();
        bool canRedo = await signature.CanRedoAsync();
        redoDisabled = !canRedo;
        undoDisabled = !canUndo;
    }
    private async Task updateSaveClear()
    {
        bool isEmpty = await signature.IsEmptyAsync();
        if (isEmpty)
        {
            saveDisabled = true;
            clearDisabled = true;
        }
        else
        {
            saveDisabled = false;
            clearDisabled = false;
        }
    }
    private async Task onClear()
    {
        await signature.ClearAsync();
        await updateSaveClear();
    }
    private void onBgColor(ColorPickerEventArgs args)
    {
        backgroundColor = args.CurrentValue.Hex;
    }
    private void onStrokeColor(ColorPickerEventArgs args)
    {
        strokeColor = args.CurrentValue.Hex;
    }
    private void onDisabled(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        disabled = args.Checked;
    }
    private void onSaveClicked(Syncfusion.Blazor.SplitButtons.ClickEventArgs args)
    {
        signature.SaveAsync();
    }
    private void onSaveType(MenuEventArgs args)
    {
        switch (args.Item.Text)
        {
            case "PNG":
                type = SignatureFileType.Png;
                break;
            case "JPEG":
                type = SignatureFileType.Jpeg;
                break;
            case "SVG":
                type = SignatureFileType.Svg;
                break;
        }
        signature.SaveAsync(type, "Signature");
    }
}
<style>
    @@font-face {
        font-family: 'font-icons';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj1tSfwAAAEoAAAAVmNtYXDOQM6IAAABqAAAAE5nbHlmPRFAxQAAAhAAAAlsaGVhZB6WKa0AAADQAAAANmhoZWEIUQQLAAAArAAAACRobXR4KAAAAAAAAYAAAAAobG9jYQowB4oAAAH4AAAAFm1heHABIAGEAAABCAAAACBuYW1lbLYTYgAAC3wAAAJJcG9zdIlCId8AAA3IAAAAjwABAAAEAAAAAFwEAAAAAAAD9AABAAAAAAAAAAAAAAAAAAAACgABAAAAAQAAc7rwy18PPPUACwQAAAAAAN3B8l4AAAAA3cHyXgAAAAAD9AP0AAAACAACAAAAAAAAAAEAAAAKAXgADAAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQQAAZAABQAAAokCzAAAAI8CiQLMAAAB6wAyAQgAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wDnCgQAAAAAXAQAAAAAAAABAAAAAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAAAAAIAAAADAAAAFAADAAEAAAAUAAQAOgAAAAYABAABAALnAecK//8AAOcA5wT//wAAAAAAAQAGAAgAAAABAAIAAwAEAAUABgAHAAgACQAAAAAAAAA6AFoAiACyAOgCKAPQBFYEtgAAAAQAAAAAA/QD8wADAAsAGQAjAAABESERARUzNTMVITUjESERMxUzESMRIREjESMRFSERIzUjNSEDHv3EAR5HSP6bSAH0j0dH/TZIRwPoR0j8pwFx/uIBHgI8j4/X1/7iAR5I/O4BZv6aA1r8pkcDWUhHAAAAAwAAAAAD7gP0AAMABwAPAAAlFSE1EzM1IwEhESMRIREjA0T9d1p8fP78A96r/XKl8WVlAgP//BkD6P7OATIAAAMAAAAAA/QD9AACAAYAGQAANyUnNxcBJzcHFz8DNS8HDwIMASTqO+kB0+qpbulyBQQCAgQFpggJCQoJCQkMOuo66QHS6alu6XIICQoJCgkIpgcEAwEBAwQAAAAABAAAAAAD9APqAAIABgAKAA8AACUHNyUBJwElByc3AQMlCQEBN8ctAj/+laMBbAFPeaF6/XNQAVsCjf78nyzH+v6ZowFkC3ihd/3r/qxJAoABCwAAAgAAAAAD8wPoAB4AIgAAEw8HFR8KMz8DFSE1IQE3CQI9BgsJBwcEAwICAwQHBwkLqgkJCQoJCQlGAo39iP7IPwE6AfH+xwGwBg0ODg8PDxAQDxAPDw4ODaoGBAICBAZGM0gBOT7+xwHyATkAAgAAAAAD8wPqAEkBGgAAAR8FDwwVHxM/CjUvFCUzNT8RHxMVJx8BFQcfBh0BDw0rAS8OPwo1LwsjDwQBDwMVHxU7AT8DAT8EPQEvBTUvFg8TA4MGBAMCAQEBAQQHHBAKCQcDAwECAQEDAwQFBgYHCAcJCAkICQkJCAkIBwgHBgYFBAMDAgECBQUHCQkKDAwNDQ4ODw4dHBoiJv4aJgQCBAYGCAkLDA8ICAkJCgoLDAkKCQkJCAkIEA4ODQwLCQkHBgUEEwMCAgcGBQUDAwIBAgIDBAQEBQUGBgYHBwcHBgcGBgYFBQUEAwMCAgEBAQICBAUFBgcHBQIDAgMDJgcHBwcGBwYGCwsJBwv+oAMCAQEBBAUHChEVGRwVFhYWFxYgHxwTEBAODQUGBAUDAVwHBgUCAQIDBAUDpAMEBggKCw0PCAkJCQkKCwsLCwwMDQ0NDQ0MCwsLCgkJCRAODAsJCAYFAwIB3AYFBgYGBgYGDQ0tGhMVFwwMDQ4OCwsLCwoLCgoJCQgIBwYGBAQDAQEBAgMEBggJCwwOGfEVFRMSEhAQDg4NDAsKCgkIDwsKCglwChgODg8ODw4NDAoFBAMDAwEBAQEBAgMDBQUFDRARExQWFxgYGBkYBhMdGBQPBQYGBggICAkHBwcGBgYFBQQEBAMCAgEBAgIDBAQEBQUGBgYHBwcICAgHBwcGBRoaFBUXDA0NKAcFBAQCAgEBAgQEB/6gBAQFBgYNDxASEh4gISEXFhYUExIYFBAIBwQCAgICBAFbCQsNBggHCAcICAgEoxgdHh4eHh0cGgwMCwsKCQgIBwYFAwMCAQEBAgIDBAQFBgYMDxARERISEhIRAAAAAAUAAAAAA/QD5AA5AI4AswDaAXcAAAEzHw8VDwcvBj0BLxUlHxMDDwUvFz8BHwk/BTUvDDclHwclLws1PwYfBicXDwQvCzU/DTMfAycPDh8KDwQdAR8XOwE/CBMfAx0BHw07AT8NPQIvLCMPAQMxBwgODg0LCwoJCAcGBQQDAgEBAQIDAwQEBAUEAwQCAgICBAMFCAQFBgUGBwcICQgKGxwcHh8V/sMGBg8SExUXFxkgIB8fHx4dHBsSF+IDBQoJCgsMDg4QEBESExQUFRUWHBkiHRkUDwsHAwEBbiAaGxwdHR4eCAgIBwYGAgIBAgMFBSAfHh0bGhgfWAEXBi0dIh8aFg/+1yAZHQ0LCQgHBQQDAgEDAwQJDhERExUXGBoc6QUJCQcGfxMPDg0LCgkHBgUDAgEDBAMFBQYHCAgJDxAREhAQIyS5Dw4NDAsJCAcFAwMDAQEBAgMGCAoLDRcaExh0BAMCAQICAwQJDA8RExUXFxoaGhIkJCMhIR8ODg4MCwsQDwkHBgYE1wMDAgEBAgMEBAUFBgcHBwgICAkICQgHCAcGBgYFBAMDAgICAgMFBQYGCAgKCgoMDBIJBwgKCwsNDQ4QDyMkJEMdHhwdHBwcGxoaGRgXFxYWFBQCTAEDBAcICgsMDQ0PDxAQEBFtBAUDAwMCAQEBAQIDAwMFBDcsIAsWFgoKCgcHBgUFBAMCBQQGCQsIqQoKExQTFBITERUSEA8NCwkGBQIF/ncEAwQBAQEBAQIDBAUGBwgJCgsMERAZGRcWFRIQCgcGvxoWFBUTFBISAwEBAwUGBgYGBgYFBAQTFBQTFBUUG5gjAxkRGBgYFhIVFhUbDQ0LDAoKCggHBgUFAwIEAgEBAwQGBwoLWwEFBwgH3BUSEREQEBAODw0NDAwKCgkGBQUEBAQDAwMCAgEBBAZBBQUHBwkJCgsICAgJCAkSExMTFBUUFR8gFRnJCAgICQkJCQkJChMUFBQTFBMSEhEQChMQDQwIBgIBAQIEBgUFBgUGAXQTExYWNwgJCAgHBwYGBgUEAwMCAgICAwMEBQYGBgcHCAgJCG0RERAQEBAPDw4ODQwLCgkKEwwNDQwNDQ0NDQ0ZGBUiDg4MCwsKCAgHBQUEAwEBAgMADAAAAAAD8gP0AAgADAAQABQAGAAcAEQASABMAFAAVABYAAATFSE1JwcnBycFMzcjNxc3JwcXNyc/ATUnBxUXNRcVHwg/CD0BLwcrAQ8HNxc3JwcXNyc7AScjJREhEQMhESF+AwSperIsRwFaCgYWRRwGFp8JHRCZIiLOIhkDBAYICgoGBgcFDAoKCAYFAgEDBAYICQsGBgYGDAoKCAYFAgFxDxYGrBMPHEgWBgoBEPyuRAPk/BwBr96cVT+yGUsDIhMWBxwcChYQLgcGBgYGChYJBgsLCQgHBQEBAQECBAcHCgsFBwYGCwsJCAcFAQECBQYICQsGBj8QHAYGHw8WI1H9BQL7/GMD6AAAAAQAAAAAA/QDqAAGADYAPQBBAAABNxMVITUBJRUfCTsBPwk9AS8KDwolEQMHAwERAyERIQJJg+v8kgEKAToBAQUHCAoGBQYHBgYGBgYGCQkHBAIBAQIEBwkJBgYGBgYGBwYFBgoIBwQCAQEq7YL1/vY9A+j8GAFBqf7tQpYBR3oHBgYMCgkHAwICAQECAgMHCQoMBgYHBwYGDAoJBwMCAQEBAQEBAgMHCQoMBgZ5/cgBF6gBMP64AeH87ANQAAAAAAAAEgDeAAEAAAAAAAAAAQAAAAEAAAAAAAEACgABAAEAAAAAAAIABwALAAEAAAAAAAMACgASAAEAAAAAAAQACgAcAAEAAAAAAAUACwAmAAEAAAAAAAYACgAxAAEAAAAAAAoALAA7AAEAAAAAAAsAEgBnAAMAAQQJAAAAAgB5AAMAAQQJAAEAFAB7AAMAAQQJAAIADgCPAAMAAQQJAAMAFACdAAMAAQQJAAQAFACxAAMAAQQJAAUAFgDFAAMAAQQJAAYAFADbAAMAAQQJAAoAWADvAAMAAQQJAAsAJAFHIGZvbnQtaWNvbnNSZWd1bGFyZm9udC1pY29uc2ZvbnQtaWNvbnNWZXJzaW9uIDEuMGZvbnQtaWNvbnNGb250IGdlbmVyYXRlZCB1c2luZyBTeW5jZnVzaW9uIE1ldHJvIFN0dWRpb3d3dy5zeW5jZnVzaW9uLmNvbQAgAGYAbwBuAHQALQBpAGMAbwBuAHMAUgBlAGcAdQBsAGEAcgBmAG8AbgB0AC0AaQBjAG8AbgBzAGYAbwBuAHQALQBpAGMAbwBuAHMAVgBlAHIAcwBpAG8AbgAgADEALgAwAGYAbwBuAHQALQBpAGMAbwBuAHMARgBvAG4AdAAgAGcAZQBuAGUAcgBhAHQAZQBkACAAdQBzAGkAbgBnACAAUwB5AG4AYwBmAHUAcwBpAG8AbgAgAE0AZQB0AHIAbwAgAFMAdAB1AGQAaQBvAHcAdwB3AC4AcwB5AG4AYwBmAHUAcwBpAG8AbgAuAGMAbwBtAAAAAAIAAAAAAAAACgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACgECAQMBBAEFAQYBBwEIAQkBCgELAAdzYXZlXzAyB3NhdmUtMDEHZWRpdF8wMwdlZGl0XzAxBWNsZWFyDHBhaW50LWJ1Y2tldA9wYWludC1idWNrZXQtd2YGaW1hZ2VzC3BpY3R1cmVzLXdmAAAA) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    .e-sign-icons {
        font-family: 'font-icons' !important;
        font-size: 55px;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    #signature-toolbar-control .e-clear::before {
        content: '\e706';
    }

    #signature-toolbar-control .e-save::before {
        content: '\e701';
    }

    #signature-toolbar-control {
        border: 1px solid lightgray;
    }

    .highcontrast #signature-toolbar-control {
        border: 1px solid white;
    }

    #signature-toolbar-control #toolbar {
        border: none;
        border-bottom: 1px solid lightgray;
        box-sizing: border-box;
    }

    #signature-toolbar-control #toolbar {
        height: 44px !important;
    }

    .e-bigger #signature-toolbar-control #toolbar {
        height: 54px !important;
    }

    .e-bigger .material #signature-toolbar-control div#toolbar,
    .e-bigger .material-dark #signature-toolbar-control div#toolbar {
        height: 57px !important;
    }

    .e-bigger .bootstrap4 #signature-toolbar-control div#toolbar,
    .e-bigger .bootstrap4-dark #signature-toolbar-control div#toolbar {
        height: 65px !important;
    }

    .bootstrap4 #signature-toolbar-control div#toolbar,
    .bootstrap4-dark #signature-toolbar-control div#toolbar,
    .bootstrap-dark #signature-toolbar-control div#toolbar,
    .bootstrap #signature-toolbar-control div#toolba {
        height: 49px !important;
    }

    .bootstrap5 #signature-toolbar-control #toolbar .e-split-btn,
    .bootstrap5 #signature-toolbar-control #toolbar .e-dropdown-btn {
        color: #6c757d
    }

    .bootstrap4 #signature-toolbar-control #toolbar .e-split-btn,
    .bootstrap4 #signature-toolbar-control #toolbar .e-dropdown-btn {
        color: #495057;
    }

    .highcontrast #signature-toolbar-control #toolbar .e-split-btn,
    .highcontrast #signature-toolbar-control #toolbar .e-dropdown-btn {
        color: #fff;
    }

    .fabric #signature-toolbar-control #toolbar .e-split-btn,
    .fabric #signature-toolbar-control #toolbar .e-dropdown-btn,
    .bootstrap5 #signature-toolbar-control #toolbar .e-split-btn,
    .bootstrap5 #signature-toolbar-control #toolbar .e-dropdown-btn,
    .bootstrap4 #signature-toolbar-control #toolbar .e-split-btn,
    .bootstrap4 #signature-toolbar-control #toolbar .e-dropdown-btn {
        background-color: transparent !important;
        border-color: lightgray;
    }

    .fabric-dark #signature-toolbar-control #toolbar .e-dropdown-btn,
    .fabric-dark #signature-toolbar-control #toolbar .e-split-btn,
    .bootstrap5-dark #signature-toolbar-control #toolbar .e-split-btn,
    .bootstrap5-dark #signature-toolbar-control #toolbar .e-dropdown-btn,
    .bootstrap4-dark #signature-toolbar-control #toolbar .e-split-btn,
    .bootstrap4-dark #signature-toolbar-control #toolbar .e-dropdown-btn {
        background-color: transparent !important;
        border-color: gray;
    }

    #signature-toolbar-control .e-btn:disabled {
        opacity: 0.5 !important;
        pointer-events: none;
    }

    #signature-toolbar-control #signature-control {
        height: 300px;
        width: 100%;
        margin: 0;
    }

    #signature-toolbar-control #signature {
        border: none !important;
    }

    .circle-palette .e-container {
        background-color: transparent;
        border-color: transparent;
        width: 160px;
    }

    .circle-palette .e-container .e-custom-palette.e-palette-group {
        height: 182px;
    }

    .circle-palette .e-container .e-palette .e-tile {
        border: 0;
        color: #fff;
        height: 32px;
        font-size: 18px;
        width: 32px;
        line-height: 36px;
        border-radius: 50%;
        margin: 4px;
        font-family: "e-icons";
        font-style: normal;
        font-variant: normal;
        font-weight: normal;
        text-transform: none;
    }

    .circle-palette .e-container .e-palette .e-tile.e-selected::before {
        content: '\e933';
    }

    .circle-palette .e-container .e-palette .e-tile.e-selected {
        outline: none;
    }

    .circle-palette .e-split-colorpicker .e-selected-color .e-split-preview {
        border: 1px solid lightgray;
    }

    .e-container .e-custom-palette .e-palette {
        padding: 0px;
    }

    .e-bg-color .e-circle-palette.e-nocolor-item.e-selected .e-circle-selection {
        background: transparent;
    }

    .e-bg-color .e-circle-palette.e-nocolor-item.e-selected {
        border: 3px solid lightgray;
    }
</style>
```

![Blazor Signature integrated with toolbar controls for undo, redo, save (format selection), color pickers, stroke width, clear, and disable toggle](../images/blazor-signature-toolbar.PNG)