---
layout: post
title: Quick Access Toolbar with Blazor Image Editor Component | Syncfusion
description: Checkout the Quick Access Toolbar available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Quick access toolbar in the Blazor Image Editor Component

The quick access toolbars in the Image Editor play a vital role in facilitating interactions with annotations like Rectangle, Ellipse, Line, Arrow, and Path. These toolbars offer a diverse array of tools and options that can be tailored to match the specific requirements and preferences associated with each annotation type. The toolbar is only displayed when an annotation is selected, ensuring a focused and contextual user experience.

The [`ShowQuickAccessToolbar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ShowQuickAccessToolbar) property controls the visibility of the quick access toolbar. Users have the flexibility to enable or disable this toolbar, add or remove items, and create a personalized set of tools.

## Add a custom toolbar item

The quick access toolbar that appears when inserting annotations in the Blazor Image Editor component is customizable using the [`QuickAccessToolbarOpening`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_QuickAccessToolbarOpening) event. This event is triggered when the quick access toolbar is opened, allowing you to modify its contents. To add additional toolbar items to the quick access toolbar, you can access the ToolbarItems property of the [`QuickAccessToolbarEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.QuickAccessToolbarEventArgs.html) object within the event handler. By adding or removing items from the ToolbarItems property based on the Item property, you can customize the options available in the quick access toolbar according to your needs. This gives you the ability to extend the functionality of the quick access toolbar and provide additional tools and options for working with inserted annotations. 

Here is an example of adding the custom toolbar item to the quick access toolbar. 

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Navigations

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync" QuickAccessToolbarOpening="QuickAccessToolbarOpening"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>()
    {
        new ImageEditorToolbarItemModel { Name = "Annotation" },
        new ImageEditorToolbarItemModel { Name = "Confirm" },
        new ImageEditorToolbarItemModel { Name = "Reset" }
    };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private void QuickAccessToolbarOpening(QuickAccessToolbarEventArgs args)
    {
        args.ToolbarItems = new List<ImageEditorToolbarItemModel>() { new ImageEditorToolbarItemModel { Name = "Clone" } };
    }
}
```

![Blazor Image Editor with Quick Access Toolbar](./images/blazor-image-editor-quick-access-toolbar.png)