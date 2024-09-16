---
layout: post
title: Pagination in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about Pagination in the Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Pagination in Blazor File Manager Component

Pagination in the Blazor File Manager component optimizes the performance and user experience by loading only a specified number of files and folders per page. This feature significantly improves performance when managing large datasets, reducing load times and enhancing interaction.

## Enabling Pagination

To enable pagination in the File Manager, set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_AllowPaging) property to `true`. This enables pagination for both details view and large icons view, ensuring efficient navigation and file management across various display modes.

## Events in Pagination

You can add events to handle actions during pagination in the File Manager. The [PageChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_PageChanging) event triggers before the page is changed, allowing you to handle actions before navigation. The [PageChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_PageChanged) event occurs after the page has been switched, allows you to perform actions like loading new data after the page has changed.

````cshtml
@using Syncfusion.Blazor.FileManager;
@using Syncfusion.Blazor.Navigations;
<SfFileManager TValue="FileManagerDirectoryContent" AllowPaging="true">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" PageChanging="OnChanging" PageChanged="OnChanged"></FileManagerEvents>
</SfFileManager>
@code {

    public void OnChanging(PageChangingEventArgs args)
    {
        //Add the required code here
    }
    public void OnChanged(PageChangedEventArgs args)
    {
        //Add the required code here
    }
}

````

## Page Size Configuration

The [FileManagerPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html) component's [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPagesSettings.html#Syncfusion_Blazor_FileManager_FileManagerPagesSettings_PageSizes) property enables a dropdown in pager that allows you to dynamically change the number of records displayed in the current page. [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPagesSettings.html#Syncfusion_Blazor_FileManager_FileManagerPagesSettings_PageSizes) property allows number of items to be loaded in a single page. Here files are sorted using [Custom sorting](https://blazor.syncfusion.com/documentation/file-manager/file-operations#custom-sorting).

The `NumericItemsCount` property is used to control the number of numeric buttons displayed in the pager when pagination is enabled. These buttons allow users to directly navigate to a specific page in the File Manager.

Here is a sample demonstrating Pagination enabled in the File Manager.

```cshtml

@using Syncfusion.Blazor.FileManager

    <SfFileManager TValue="FileManagerDirectoryContent" AllowPaging="true" Path="/Text Documents/" SortComparer="new NaturalSortComparer()">
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerPageSettings PageSize="25" NumericItemsCount="8" PageSizes="@(new List<int>(){10,25,50})"></FileManagerPageSettings>
    </SfFileManager>

```

Below is a screenshot illustrating the pagination feature in the File Manager component.

![Pagination in Blazor FileManager](images/blazor-filemanager-pagination.png)

## Pager Template in Blazor File Manager

The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html#Syncfusion_Blazor_FileManager_FileManagerPageSettings_Template) property in the [FileManagerPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html) allows you to insert custom UI elements, such as buttons or any HTML elements into the File Manager page settings. This offers greater flexibility and customization for the paging interface.

By invoking the [GoToPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_GoToPageAsync) method within the pager template for the Blazor File Manager component, you can navigate to a specific page by passing the page number to the method.

Below is an example on how to customize pagination in the Syncfusion File Manager by adding a custom button and using the [GoToPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_GoToPageAsync) method in the pager template for specific page navigation.

````cshtml
@using Syncfusion.Blazor.FileManager;
@using Syncfusion.Blazor.Navigations;
<SfFileManager @ref="fileManager" TValue="FileManagerDirectoryContent" AllowPaging="true">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerPageSettings PageSize="3">
        <Template>
            <button @onclick="NavigateToPage">Go To Page 2</button>
        </Template>
    </FileManagerPageSettings>
</SfFileManager>
@code {
    SfFileManager<FileManagerDirectoryContent> fileManager;
    
    private async Task NavigateToPage()
    { 
        await fileManager.GoToPageAsync(2);
    }
}

````

The screenshot below shows the Blazor File Manager component with a custom pagination button.

![Pager Template in Blazor FileManager](images/blazor-filemanager-page-template.png)