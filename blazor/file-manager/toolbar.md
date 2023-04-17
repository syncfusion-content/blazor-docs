---
layout: post
title: Toolbar in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about Toolbar in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Toolbar in Blazor FileManager Component

The toolbar items can be added using the [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html) [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Items) property in the Blazor FileManager component. Also you can customize the toolbar items using the [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html) and [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) events.

## Enabling or disabling items

In the Blazor FileManager component, you can enable or disable toolbar items by using the FileManager's [EnableToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_EnableToolbarItems_System_String___) and [DisableToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_DisableToolbarItems_System_String___) methods. 

To enable or disable toolbar items, you need to pass the specified items in an array collection of strings to these methods. 

The following example shows how to enable and disable toolbar items on a button click.

```cshtml

@using Syncfusion.Blazor.FileManager
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="Enable" CssClass="e-flat" Content="@Content1"></SfButton>
<SfButton @onclick="Disable" CssClass="e-flat" Content="@Content2"></SfButton>

<SfFileManager AllowDragAndDrop="true" TValue="FileManagerDirectoryContent" @ref="FileManager">
        <FileManagerEvents TValue="FileManagerDirectoryContent" ></FileManagerEvents>
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
        </FileManagerAjaxSettings>
    </SfFileManager>

@code{
    SfFileManager<FileManagerDirectoryContent>? FileManager;
    public string Content1 = "Enable New Folder toolbar item";
    public string Content2 = "Disable New Folder toolbar item";
    public void Enable()
    {
        FileManager?.EnableToolbarItems(new string[] { "New folder" });
    }
    public void Disable()
    {
        FileManager?.DisableToolbarItems(new string[] { "New folder" });
    }
}

```

## Showing or hiding items

In the FileManager component, you can show or hide the Toolbar items. Initially, you can add and customize custom toolbar items using the [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html) [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Items) property and [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event. 

The new toolbar button **Custom** is added using the **ToolbarSettings** API, and the prefix icon and tooltip are added to the newly added toolbar button using the [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event. 

You can show or hide the toolbar items by adding or removing the items using the ToolbarSettings API Items property to update it.

```cshtml

@using Syncfusion.Blazor.FileManager
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="Show" CssClass="e-flat" Content="@Content1"></SfButton>
<SfButton @onclick="Hide" CssClass="e-flat" Content="@Content2"></SfButton>

<SfFileManager AllowDragAndDrop="true"  TValue="FileManagerDirectoryContent">
        <FileManagerEvents TValue="FileManagerDirectoryContent" ></FileManagerEvents>
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                    UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                    DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                    GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerToolbarSettings Items="@Items"></FileManagerToolbarSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarCreated="ToolbarCreate"></FileManagerEvents>
</SfFileManager>

@code {
    SfFileManager<FileManagerDirectoryContent>? fileobj;
    public string[] Items = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details", "Custom" };
    public void ToolbarCreate(ToolbarCreateEventArgs args)
    {
        args.Items.Add(new ToolBarItemModel()
            {
                Text = "Custom",
                PrefixIcon = "e-icons e-fe-tick",
                TooltipText = "Custom Tooltip"
            });
    }
    public string Content1 = "Show Custom toolbar item";
    public string Content2 = "Hide Custom toolbar item";
    public void Show()
    {
        Items = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details", "Custom" };
    }
    public void Hide()
    {
        Items = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details" };
    }
}

<style>
    .e-fe-tick::before {
        content: '\e614';
    }
</style> 

```

## Adding a custom toolbar item with tooltip 

In the Blazor FileManager component, the custom toolbar items can be added and customized using the [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html) [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Items) property and [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event. The new toolbar button **Custom** is added using the **ToolbarSettings** API, and the prefix icon and tooltip are added to the newly added toolbar button using the [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event. 

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager ID="File" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarCreated="toolbarCreate"></FileManagerEvents>
    <FileManagerToolbarSettings Items="@Items"></FileManagerToolbarSettings>
</SfFileManager>

@code {
    public string[] Items = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details", "Custom" };

    public void toolbarCreate(ToolbarCreateEventArgs args)
    {
        args.Items.Add(new ToolBarItemModel()
            {
                Text = "Custom",
                PrefixIcon = "e-icons e-fe-tick",
                TooltipText = "Test Tooltip"
            });
    }
}
<style>
    .e-fe-tick::before {
        content: '\e614';
    }
</style> 

```

## Update items based on selection

Based on the file selection, you can update or display the toolbar items in the Blazor FileManager component. 

To update the toolbar items using the selection, you need to assign the declared string items that you want to display to the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Items) property of [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html) in the [FileSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelection) event.

In the following example, shown the different toolbar items for the **Downloads** Folder.


```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url=https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations
                             UploadUrl=https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload
                             DownloadUrl=https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download
                             GetImageUrl=https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage>
    </FileManagerAjaxSettings>
    <FileManagerToolbarSettings Items="@Items"></FileManagerToolbarSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarCreated="toolbarCreate" FileSelection="OnFileSelect"></FileManagerEvents>
</SfFileManager>

@code {
    public string[] Items = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details", "Custom" };
    public string[] Items1 = new string[] { "Download", "Rename" };
    public string[] Items2 = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details", "Custom" };

    public void toolbarCreate(ToolbarCreateEventArgs args)
    {
        args.Items.AddRange(new List<ToolBarItemModel>()
      {
        new ToolBarItemModel()
        {
          Text = "Custom",
          PrefixIcon = "e-icons e-fe-tick",
          TooltipText = "Custom Tooltip",
        }
      });
    }

    public void OnFileSelect(FileSelectionEventArgs<FileManagerDirectoryContent> args)
    {
        if (args.Action == "Select" && args.FileDetails.Name == "Downloads")
        {
            Items = Items1;
        }
        else
        {
            Items = Items2;
        }
    }

}
<style>
    .e-fe-tick::before {
        content: '\e614';
    }
</style> 

```

## Events

The Blazor FileManager Toolbar component has a [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) and [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) events that can be triggered for certain actions. These events can be attached to the FileManager using the **FileManagerEvents** component, which requires the **TValue** to be provided.

N> All the events should be provided in a single **FileManagerEvents** component.

### ToolbarCreated

The [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event of the Blazor FileManager component is triggered before the creation of the toolbar.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent"></FileManagerEvents>
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarCreated="ToolbarCreate">
    </FileManagerEvents>
</SfFileManager>

@code {
    public void ToolbarCreate(ToolbarCreateEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

### ToolbarItemClicked

The [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) event of the Blazor FileManager component is triggered when a toolbar item is clicked.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent"></FileManagerEvents>
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarItemClicked="ToolbarItemClicked"></FileManagerEvents>
</SfFileManager>

@code {
    public void ToolbarItemClicked(ToolbarClickEventArgs<FileManagerDirectoryContent> args)
    {
        // Here, you can customize your code.
    }
}

```