---
layout: post
title: Form Integration in Blazor File Upload Component | Syncfusion
description: Learn how to integrate the Syncfusion Blazor File Upload component with Blazor's EditForm and DataForm for seamless form-based file management.
platform: Blazor
control: File Upload
documentation: ug
---

# Form Integration in Blazor File Upload Component

The Syncfusion Blazor File Upload component can be integrated with Blazor's `EditForm` and `DataForm` to build robust forms that include file-handling capabilities. This allows you to associate file uploads with a model and trigger validation.

In a form, file validation is triggered by populating a model property when a file is selected and clearing it when removed. The `FileSelected` and `OnRemove` events are used for this purpose. When the form is submitted, the file can be uploaded manually to a server-side endpoint.

## File Upload with EditForm Integration

The File Upload component can be integrated into a Blazor `EditForm` to manage file uploads as part of your data entry process.

To validate the file input, a model property is updated using the `FileSelected` and `OnRemove` events. The file upload is initiated only when the form is valid by calling the `UploadAsync` method in the `OnValidSubmit` event handler.

### Uploading to a Server-Side API (Blazor WASM and Server)

This example shows how to configure the File Upload component to send files to a server-side API endpoint upon form submission. This approach is compatible with both Blazor WebAssembly and Blazor Server applications.

```cshtml
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs

<EditForm Model="@employee" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <div class="form-group">
        <SfUploader @ref="UploadObj" AllowMultiple="false" AutoUpload="false" ID="UploadFiles">
            <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save"
                                     RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
            <UploaderEvents OnRemove="OnRemove" FileSelected="OnSelect"></UploaderEvents>
        </SfUploader>
        <ValidationMessage For="() => employee.files" />
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</EditForm>

@code {
    private SfUploader UploadObj;

    public class Employee
    {
        [Required(ErrorMessage = "Please upload a file")]
        public List<UploaderUploadedFiles> files { get; set; }
    }

    public Employee employee = new Employee();

    public void OnSelect(SelectedEventArgs args)
    {
        this.employee.files = new List<UploaderUploadedFiles> { new UploaderUploadedFiles { Name = args.FilesData[0].Name, Type = args.FilesData[0].Type, Size = args.FilesData[0].Size } };
    }

    public void OnRemove()
    {
        this.employee.files = null;
    }

    public async Task HandleValidSubmit()
    {
        // Upload the selected file manually only when the form is valid
        await this.UploadObj.UploadAsync();
    }
}
```

### Saving Files Directly to the File System (Blazor Server Only)

In a Blazor Server application, you can save uploaded files directly to the server's file system. The following example demonstrates how to use the `ValueChange` event to read the file stream and save it to a path.

> This method writes files to the server's local file system and is only supported in Blazor Server applications. It will not work in a Blazor WebAssembly environment.

```cshtml
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs

<EditForm Model="@employee" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <div class="form-group">
        <SfUploader @ref="UploadObj" AllowMultiple="false" AutoUpload="false" ID="UploadFiles">
            <UploaderEvents ValueChange="OnChange" OnRemove="OnRemove" FileSelected="OnSelect"></UploaderEvents>
        </SfUploader>
        <ValidationMessage For="() => employee.files" />
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</EditForm>

@code {
    private SfUploader UploadObj;

    public class Employee
    {
        [Required(ErrorMessage = "Please upload a file")]
        public List<UploaderUploadedFiles> files { get; set; }
    }

    public Employee employee = new Employee();

    public void OnSelect(SelectedEventArgs args)
    {
        this.employee.files = new List<UploaderUploadedFiles> { new UploaderUploadedFiles { Name = args.FilesData[0].Name, Type = args.FilesData[0].Type, Size = args.FilesData[0].Size } };
    }

    private async Task OnChange(UploadChangeEventArgs args)
    {
        foreach (var file in args.Files)
        {
            if (file.FileInfo != null && file.File != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileInfo.Name);
                using FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);
            }
        }
    }

    public void OnRemove()
    {
        this.employee.files = null;
    }

    public async Task HandleValidSubmit()
    {
        await this.UploadObj.UploadAsync();
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNheNkBrgmbGBlgC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor File Upload component within an EditForm, showing validation and submission.](./images/blazor-uploader-editform.gif)

## File Upload with DataForm Integration

The File Upload component can also be integrated into a Syncfusion `DataForm`, providing a streamlined way to create forms from a model. The example below shows how to save an uploaded file directly to the file system in a Blazor Server application when the form is submitted.

> This file-saving approach is only compatible with Blazor Server applications.

```cshtml
@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Inputs
@using System.IO

<SfDataForm ID="MyForm" Model="@UserModel" Width="50%" OnSubmit="Submit">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(UserModel.files)">
            <Template>
                <SfUploader @ref="UploadObj" AllowMultiple="false" AutoUpload="false" ID="UploadFiles">
                    <UploaderEvents ValueChange="OnChange" OnRemove="OnRemove" FileSelected="OnSelect"></UploaderEvents>
                </SfUploader>
            </Template>
        </FormItem>
    </FormItems>
</SfDataForm>

@code {
    private SfUploader UploadObj;

    public class UserDataModel
    {
        [Required(ErrorMessage = "Please upload a file")]
        public List<UploaderUploadedFiles> files { get; set; }
    }

    private UserDataModel UserModel = new UserDataModel();

    private async Task OnChange(UploadChangeEventArgs args)
    {
        foreach (var file in args.Files)
        {
            if (file.FileInfo != null && file.File != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileInfo.Name);
                using FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);
            }
        }
    }

    private void OnRemove()
    {
        this.UserModel.files = null;
    }

    private void OnSelect(SelectedEventArgs args)
    {
        this.UserModel.files = new List<UploaderUploadedFiles> { new UploaderUploadedFiles { Name = args.FilesData[0].Name, Type = args.FilesData[0].Type, Size = args.FilesData[0].Size } };
    }

    private async Task Submit(object args)
    {
        await this.UploadObj.UploadAsync();
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBSDaBVKlbHqfgu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor File Upload component within a Syncfusion DataForm.](./images/blazor-uploader-dataform.gif)
