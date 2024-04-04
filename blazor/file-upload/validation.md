---
layout: post
title: Validation in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about Validation in Syncfusion Blazor File Upload component and much more.
platform: Blazor
control: File Upload
documentation: ug
---

# Validation in Blazor File Upload Component

The uploader component validate the selected files size and extension using the [AllowedExtensions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AllowedExtensions), [MinFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_MinFileSize) and [MaxFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_MaxFileSize) properties. The files can be validated before uploading to the server and can be ignored on uploading. Also, you can validate the files by setting the HTML attributes to the original input element. The validation process occurs on drag-and-drop the files also.

## File type

You can allow the specific files alone to upload using the [AllowedExtensions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AllowedExtensions) property. The extension can be represented as collection by comma separators. The uploader component filters the selected or dropped files to match against the specified file types and processes the upload operation. The validation happens when you specify value to inline attribute to accept the original input element.

`SaveUrl` and `RemoveUrl` actions are explained in this [link](./chunk-upload#save-and-remove-action-for-blazor-aspnet-core-hosted-application).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles" AllowedExtensions=".doc, .docx, .xls, .xlsx">
 <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove">
 </UploaderAsyncSettings>
</SfUploader>
```


![Validation in Blazor FileUpload](./images/blazor-fileupload-validation.png)

## File size

The uploader component allows you to validate the files based on its size. The validation helps to restrict uploading large files or empty files to the server. The size can be represented in `bytes`. By default, the uploader component allows you to upload **minimum file size** as 0 byte and **maximum file size** as 28.4 MB using the [MinFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_MinFileSize) and [MaxFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_MaxFileSize) properties.

`SaveUrl` and `RemoveUrl` actions are explained in this [link](./chunk-upload#save-and-remove-action-for-blazor-aspnet-core-hosted-application).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles" AllowedExtensions=".doc, .docx, .xls, .xlsx"  MinFileSize=10000 MaxFileSize=1000000>
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove">
    </UploaderAsyncSettings>
</SfUploader>
```


![Validating File Size in Blazor FileUpload](./images/blazor-fileupload-size-validation.png)

## File Validation within Edit Form

The provided code snippet demonstrates a Blazor form for editing employee information, including uploader component. It incorporates data validation and displays error messages. Users can select files for upload, which are stored in the files property of the Employee model. The code handles file selection, changes, and removal through the use of the [FileSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_FileSelected), [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange), and [OnRemove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnRemove) events. Additionally, it enables manual file upload during form submission.

### Without server-side API endpoint

```cshtml
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs

 <EditForm Model="@employee" OnValidSubmit="@HandleValidSubmit" OnInvalidSubmit="@HandleInvalidSubmit">  
        <DataAnnotationsValidator />  
        <div class="form-group">  
           <SfTextBox @bind-Value="@employee.EmpID"></SfTextBox>  
           <ValidationMessage For="() => employee.EmpID" /> 
        </div>  
        <div class="form-group">  
            <SfUploader @ref="UploadObj" AllowMultiple=false AutoUpload="false" ID="UploadFiles">  
                <UploaderEvents ValueChange="OnChange" OnRemove="OnRemove" FileSelected="OnSelect"></UploaderEvents>  
            </SfUploader>  
            <ValidationMessage For="() => employee.files" /> 
        </div>  
        <button type="submit" class="btn btn-primary">Submit</button>  
    </EditForm>  
  
@code{
    SfUploader UploadObj;  
    public class Employee 
    { 
        [Required(ErrorMessage ="Please enter your name")] 
        public string EmpID { get; set; } 

        [Required(ErrorMessage = "Please upload a file")] 
        public List<UploaderUploadedFiles> files { get; set; } 
    } 
    public Employee employee = new Employee();  

    public void OnSelect(SelectedEventArgs args) 
    {   
        this.employee.files = new List<UploaderUploadedFiles>() { new UploaderUploadedFiles() { Name = args.FilesData[0].Name, Type = args.FilesData[0].Type, Size = args.FilesData[0].Size } }; 
    } 
    private async Task OnChange(UploadChangeEventArgs args)  
    {  
        foreach (var file in args.Files)  
        {
            if (file.FileInfo != null && file.File != null)
            {
                var path = @"" + file.FileInfo.Name;

                FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);

                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);

                filestream.Close();
            }
        }  
    }  
    public void OnRemove() 
    { 
        this.employee.files = null; 
    } 
 
    public async Task HandleValidSubmit()  
    {  
        await this.UploadObj.Upload(); // Upload the selected file manually  
 
    }   
    public async Task HandleInvalidSubmit() 
    { 
         await this.UploadObj.Upload(); // Upload the selected file manually  
    }  
} 
```

### With server-side API endpoint

```cshtml
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs

 <EditForm Model="@employee" OnValidSubmit="@HandleValidSubmit" OnInvalidSubmit="@HandleInvalidSubmit">  
        <DataAnnotationsValidator />  
        <div class="form-group">  
           <SfTextBox @bind-Value="@employee.EmpID"></SfTextBox>  
           <ValidationMessage For="() => employee.EmpID" /> 
        </div>  
        <div class="form-group">  
            <SfUploader @ref="UploadObj" AllowMultiple=false AutoUpload="false" ID="UploadFiles"> 
             <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save"
                           RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings> 
                <UploaderEvents OnRemove="OnRemove" FileSelected="OnSelect"></UploaderEvents>  
            </SfUploader>  
            <ValidationMessage For="() => employee.files" /> 
        </div>  
        <button type="submit" class="btn btn-primary">Submit</button>  
    </EditForm>  
  
@code{
    SfUploader UploadObj;  
    public class Employee 
    { 
        [Required(ErrorMessage ="Please enter your name")] 
        public string EmpID { get; set; } 

        [Required(ErrorMessage = "Please upload a file")] 
        public List<UploaderUploadedFiles> files { get; set; } 
    } 
    public Employee employee = new Employee();  

    public void OnSelect(SelectedEventArgs args) 
    {   
        this.employee.files = new List<UploaderUploadedFiles>() { new UploaderUploadedFiles() { Name = args.FilesData[0].Name, Type = args.FilesData[0].Type, Size = args.FilesData[0].Size } }; 
    }
    public void OnRemove() 
    { 
        this.employee.files = null; 
    } 
 
    public async Task HandleValidSubmit()  
    {  
        await this.UploadObj.Upload(); // Upload the selected file manually  
 
    }   
    public async Task HandleInvalidSubmit() 
    { 
         await this.UploadObj.Upload(); // Upload the selected file manually  
    }  
} 
```