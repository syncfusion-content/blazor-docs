---
layout: post
title: Customize the Navigation Pane in Blazor File Manager | Syncfusion
description: Learn how to customize the Navigation Pane in the Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Customize Navigation Pane in Blazor File Manager Component

The navigation pane in the Blazor File Manager component displays the folder hierarchy in a tree-like structure. You can customize the layout of each folder node in the navigation pane using the `NavigationPaneTemplate` property. This allows you to modify the appearance of folders based on your application's requirements.

You may use this template to show additional metadata, custom icons, or other UI elements alongside the folder name.

```cshtml

@using Syncfusion.Blazor.FileManager;

<SfFileManager TValue="FileManagerDirectoryContent">
    <ChildContent>
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
        </FileManagerAjaxSettings>
    </ChildContent>
    <NavigationPaneTemplate>
        <div class="e-nav-pane-node" style="display: inline-flex; align-items: center;">
            @if (context is FileManagerDirectoryContent item)
            {
                <span class="folder-name" style="margin-left:8px;">@item.Name</span>
            }
        </div>
    </NavigationPaneTemplate>
</SfFileManager>

```