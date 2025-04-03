---
layout: post
title: Pagination in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Pagination in the Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Pagination in Blazor File Manager Component

Pagination provides an option to display files and folders in segmented pages, making it easier to navigate through large directories. This feature is particularly useful when dealing with extensive file systems in the File Manager component.

To enable pagination, you need to set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_AllowPaging) property to **true**. This property determines whether paging is enabled or disabled for the File Manager. When `AllowPaging` is enabled, a pager control rendered at the bottom of the File Manager, allowing you to navigate through different pages.

## Customize the pagination options

Customizing the pagination options in the Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager allows you to tailor the File Manager pager according to your specific requirements. You can customize the pagination to display the number of pages using the `NumericItemsCount` property, change the current page using `CurrentPage` property, display the number of records in the File Manager using the `PageSize` property, and even adjust the page sizes in a dropdown using the `PageSizes` property.

### Change the page size

The Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager allows you to control the number of records displayed per page, providing you with flexibility in managing your data. This feature is particularly useful when you want to adjust the amount of data visible to you at any given time. To achieve this, you can utilize the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html#Syncfusion_Blazor_FileManager_FileManagerPageSettings_PageSize) property. This property is used to specify the initial number of records to display on each page. 

The following example demonstrates how to change the page size of a File Manager using the `PageSize` property.

````cshtml
@using Syncfusion.Blazor.FileManager;
@using Syncfusion.Blazor.Navigations;

<SfFileManager  TValue="FileManagerDirectoryContent" AllowPaging="true">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerPageSettings PageSize="3"></FileManagerPageSettings>
</SfFileManager>
````
Below is a screenshot illustrating the `PageSize` property in the File Manager component.

![Pagination in Blazor File Manager](images/blazor-filemanager-pagesize.png)

### Change the page count

The [NumericItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html#Syncfusion_Blazor_FileManager_FileManagerPageSettings_NumericItemsCount) property is used to control the number of numeric buttons displayed in the pager when pagination is enabled.

 ````cshtml
 @using Syncfusion.Blazor.FileManager;
@using Syncfusion.Blazor.Navigations;
<SfFileManager TValue="FileManagerDirectoryContent" AllowPaging="true" >
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerPageSettings NumericItemsCount="5"></FileManagerPageSettings>
</SfFileManager>
 ````

Below is a screenshot illustrating the `NumericItemsCount` property in the File Manager component.

![Pagination in Blazor File Manager](images/blazor-filemanager-numericitemcount.png)

### Change the current page

The Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager allows you to change the currently displayed page, which can be particularly useful when you need to navigate through different pages of data either upon the initial rendering of the File Manager or update the displayed page based on interactions or specific conditions. The default value of **CurrentPage** property is 1.

To change the current page in the Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager, you can utilize the [CurrentPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html#Syncfusion_Blazor_FileManager_FileManagerPageSettings_CurrentPage) property in [FileManagerPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html) component, which defines the current page number of the pager.

The following example demonstrates how to implement the `CurrentPage` property.

````cshtml
@using Syncfusion.Blazor.FileManager;
@using Syncfusion.Blazor.Navigations;

<SfFileManager TValue="FileManagerDirectoryContent" AllowPaging="true">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerPageSettings PageSize="3" CurrentPage="2">
       
    </FileManagerPageSettings>
</SfFileManager>
````
Below is a screenshot illustrating the `CurrentPage` property in the File Manager component.

![Pagination in Blazor File Manager](images/blazor-filemanager-currentpage.png)


## Pager Template in Blazor File Manager

The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html#Syncfusion_Blazor_FileManager_FileManagerPageSettings_Template) property in the [FileManagerPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html) allows you to insert custom UI elements, such as buttons or any HTML elements into the File Manager page settings. This offers greater flexibility and customization for the paging interface.

### How to navigate to particular page

By invoking the [GoToPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_GoToPageAsync_System_Int32_) method within the pager template for the Blazor File Manager component, you can navigate to a specific page by passing the page number to the method.

Below is an example on how to customize pagination in the Syncfusion<sup style="font-size:70%">&reg;</sup> File Manager by adding a custom button and using the [GoToPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_GoToPageAsync_System_Int32_) method in the pager template for specific page navigation.

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

![Pager Template in Blazor File Manager](images/blazor-filemanager-page-template.png)

### Pager with Page Sizes dropdown

The [FileManagerPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html) component's [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerPageSettings.html#Syncfusion_Blazor_FileManager_FileManagerPageSettings_PageSizes) property enables a dropdown in pager that allows you to dynamically change the number of records displayed in the current page.

Here is a sample demonstrating how `PageSizes` property is used when Pagination enabled in the File Manager.

```cshtml

@using Syncfusion.Blazor.FileManager

    <SfFileManager TValue="FileManagerDirectoryContent" AllowPaging="true" Path="/Text Documents/">
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/Virtualization/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerPageSettings PageSizes="@(new List<int>(){10,25,50})"></FileManagerPageSettings>
    </SfFileManager>

```

The screenshot below shows the page sizes dropdown in the File Manager.

![Pagination in Blazor File Manager](images/blazor-filemanager-pagesize-dropdown.png)

## Events in Pagination

You can add events to handle actions during pagination in the File Manager. 

The [PageChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_PageChanging) event triggers before the page is changed, allowing you to handle actions before navigation.

The [PageChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_PageChanged) event occurs after the page has been switched, allows you to perform actions like loading new data after the page has changed.

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