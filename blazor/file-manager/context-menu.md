---
layout: post
title: Context Menu in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Context Menu in Syncfusion Blazor File Manager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Context Menu in Blazor File Manager Component

The context menu items can be added for the files, folders, and layout in the Blazor File Manager component using the properties of the [ContextMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html) below.

* [File](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html#Syncfusion_Blazor_FileManager_FileManagerContextMenuSettings_File) - Specifies the array of string that is used to configure file items.
* [Folder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html#Syncfusion_Blazor_FileManager_FileManagerContextMenuSettings_Folder) - Specifies the array of string that is used to configure folder items.
* [Layout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html#Syncfusion_Blazor_FileManager_FileManagerContextMenuSettings_Layout) - Specifies the array of string that is used to configure layout items.

The following table provides the default context menu item and the corresponding target areas.

<!-- markdownlint-disable MD033 -->
<table border="1">
    <tr>
        <th>Menu Name</th>
        <th>Menu Items</th>
        <th>Target</th>
    </tr>
    <tr>
        <td>Layout</td>
        <td>
            <ul>
                <li>SortBy</li>
                <li>View</li>
                <li>Refresh</li>
                <li>NewFolder</li>
                <li>Upload</li>
                <li>Details</li>
                <li>Select all</li>
            </ul>
        </td>
        <td>
            <ul>
                <li>Empty space in the view section (details view and large icon view area).</li>
                <li>Empty folder content.</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Folders</td>
        <td>
            <ul>
                <li>Open</li>
                <li>Delete</li>
                <li>Rename</li>
                <li>Downloads</li>
                <li>Details</li>
            </ul>
        </td>
        <td>
            <ul>
                <li>Folders in treeview, details view, and large icon view.</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Files</td>
        <td>
            <ul>
                <li>Open</li>
                <li>Delete</li>
                <li>Rename</li>
                <li>Downloads</li>
                <li>Details</li>
            </ul>
        </td>
        <td>
            <ul>
                <li>Files in details view and large icon view.</li>
            </ul>
        </td>
    </tr>
</table>

## Adding Custom Items

In the Blazor File Manager component, the context menu can be customized by utilizing the [ContextMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html) and the [MenuOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_MenuOpened) event. 

The following example demonstrates how to add a custom item to the context menu. The **ContextMenuSettings** is used to add the new menu item, while the **MenuOpened** event is utilized to add an icon to the newly created menu item.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" @ref="FileManager">
    <FileManagerEvents TValue="FileManagerDirectoryContent"></FileManagerEvents>
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerContextMenuSettings File="@Items" Folder="@Items" Layout="@Items"></FileManagerContextMenuSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" MenuOpened="MenuOpened"></FileManagerEvents>
</SfFileManager>

@code {
    SfFileManager<FileManagerDirectoryContent>? FileManager;
    public string[] Items = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details", "Custom" };
    public void MenuOpened(MenuOpenEventArgs<FileManagerDirectoryContent> args)
    {
        for(int i=0; i < args.Items.Count(); i++)
        {
            if (args.Items[i].Id == FileManager?.ID + "_cm_custom")
            {
                args.Items[i].IconCss = "e-icons e-fe-tick";
            }
        }
    }
}

<style>
    .e-fe-tick::before {
        content: '\e614';
    }
</style> 

```

## Showing Different Context Menu for Files and Folders

In the Blazor File Manager component, you can customize the context menu items for files and folders using the File Manager [ContextMenuSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html) [File](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html#Syncfusion_Blazor_FileManager_FileManagerContextMenuSettings_File) and [Folder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html#Syncfusion_Blazor_FileManager_FileManagerContextMenuSettings_Folder) properties. 

The following example demonstrates how to achieve this by showing different context menu items for files and folders.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" @ref="FileManager">
    <FileManagerEvents TValue="FileManagerDirectoryContent"></FileManagerEvents>
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerContextMenuSettings File="@FileItems" Folder="@FolderItems"></FileManagerContextMenuSettings>
</SfFileManager>

@code {
    SfFileManager<FileManagerDirectoryContent>? FileManager;
    public string[] FileItems = new string[] { "Delete", "Download", "Rename", "|", "Details" };
    public string[] FolderItems = new string[] { "Open", "|", "Cut", "Copy", "Paste"};
}

```

## Enabling or Disabling Items

In the Blazor File Manager component, you can enable or disable context menu items by setting the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.MenuItemModel.html#Syncfusion_Blazor_FileManager_MenuItemModel_Disabled) value of the [MenuOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_MenuOpened) event arguments to either **true** or **false**.

In the following example, the **Cut** context menu item is disabled for the folders.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent"></FileManagerEvents>
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" MenuOpened="MenuOpened"></FileManagerEvents>
</SfFileManager>

@code {

    public void MenuOpened(MenuOpenEventArgs<FileManagerDirectoryContent> args) 
    {
        bool isFile = args.FileDetails.Any(detail => !detail.IsFile);

        foreach (var item in args.Items)
        {
            if (item.Text == "Cut")
            {
                item.Disabled = isFile;
            }
        }
    }
}

```


## Showing or Hiding Items

In the Blazor File Manager component, you can control the visibility of context menu items by setting the [Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.MenuItemModel.html#Syncfusion_Blazor_FileManager_MenuItemModel_Hidden) value of the [MenuOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_MenuOpened) event arguments to **true** or **false**. 

In the following example, the **Cut** context menu item is shown for the files.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" >
    <FileManagerEvents TValue="FileManagerDirectoryContent"></FileManagerEvents>
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" MenuOpened="MenuOpened"></FileManagerEvents>
</SfFileManager>

@code {

    public void MenuOpened(MenuOpenEventArgs<FileManagerDirectoryContent> args)
    {
        bool isFile = args.FileDetails.Any(file => !file.IsFile);

        foreach (var item in args.Items)
        {
            if (item.Text == "Cut")
            {
                item.Hidden = isFile;
            }
        }
    }
}

```

## Events

The Blazor File Manager Context Menu component has a [MenuOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_MenuOpened) and [OnMenuClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnMenuClick) events that can be triggered for certain actions. These events can be bound to the File Manager using the **FileManagerEvents**, which requires the **TValue** to be provided.

N> All the events should be provided in a single **FileManagerEvents** component.

### MenuOpened

The [MenuOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_MenuOpened) event of the Blazor File Manager component is triggered before the context menu is opened.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" MenuOpened="MenuOpened"></FileManagerEvents>
</SfFileManager>

@code {
    public void MenuOpened(MenuOpenEventArgs<FileManagerDirectoryContent> args)
    {
        // Here, you can customize your code.
    }
}

```

### OnMenuClick

The [OnMenuClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnMenuClick) event of the Blazor File Manager component is triggered when the context menu item is clicked.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" OnMenuClick="OnMenuClick"></FileManagerEvents>
</SfFileManager>

@code {
    public void OnMenuClick(MenuClickEventArgs<FileManagerDirectoryContent> args)
    {
        // Here, you can customize your code.
    }
}

```

## See Also

[Adding Custom Item To Context Menu](https://blazor.syncfusion.com/documentation/file-manager/how-to/adding-custom-item-to-context-menu)