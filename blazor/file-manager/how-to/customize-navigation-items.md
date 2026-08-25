---
layout: post
title: How to customize navigation items in Blazor File Manager | Syncfusion
description: Learn how to customize the layout of folder nodes in the Blazor File Manager navigation pane with a custom template.
control: File Manager
platform: Blazor
documentation: ug
---

# How to Customize Navigation Pane in Blazor File Manager

The navigation pane in the [Blazor File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager) component displays the folder hierarchy in a tree-like structure. You can customize the layout of each folder node in the navigation pane using the `NavigationPaneTemplate` property. This allows you to modify the appearance of folders based on your application's requirements.

You may use this template to show additional metadata, custom icons, or other UI elements alongside the folder name.

```cshtml

@using Syncfusion.Blazor.FileManager;

<SfFileManager TValue="FileManagerDirectoryContent">
    <ChildContent>
        <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                                 UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                                 DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                                 GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
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