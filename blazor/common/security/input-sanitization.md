---
layout: post
title: Input Sanitization in Syncfusion Blazor Components
description: Discover effective techniques for securely sanitizing user input in Syncfusion Blazor components to protect your application from unsafe data.
platform: Blazor
control: Common
documentation: ug
---

# Input Sanitization with Syncfusion Blazor Components

Input sanitization protects applications from malformed or malicious user input by validating, cleaning, and transforming data before it is processed. Syncfusion Blazor components provide rich client‑side validation capabilities, but all input must still be validated and sanitized on the server to maintain a complete security boundary. This guide explains how to implement secure and consistent input sanitization patterns when working with Syncfusion Blazor components.

## Validation Principles

### Validate on the Client

Client-side validation improves the user experience by providing immediate feedback and reducing unnecessary server calls. Syncfusion components offer built‑in features such as `MaxLength`, `masked input`, and `form‑bound validation`. These client-side checks help users correct mistakes early, but they should never be considered authoritative.

### Re-validate on the Server

Server-side validation must always be performed regardless of the client’s behavior. The server should enforce rules using **DataAnnotations**, allow-lists, HTML sanitization libraries, and `ModelState` validation. Even if the client reports valid data, the server must treat all inputs as untrusted.

### Canonicalize Inputs

Before validation, normalize incoming data—trim whitespace, normalize Unicode, decode entities, and standardize encodings. Canonicalizing inputs prevents attackers from exploiting encoded variations or visually deceptive input forms.

### Prefer Allow-listing

Whenever possible, define explicitly which characters, MIME types, or data formats are allowed. Block-listing harmful patterns is incomplete and by-passable, whereas allow-listing offers predictable and secure boundaries.

## DataAnnotations Model Validation

Syncfusion Blazor components integrate seamlessly with Blazor's **DataAnnotations** system. Below is a typical validation model:

{% tabs %}
{% highlight c# %}

using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(24, MinimumLength = 3)]
    [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Only letters, digits, and underscore.")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Enter a valid email address.")]
    [EmailAddress]
    [StringLength(128)]
    public string Email { get; set; } = string.Empty;
}

{% endhighlight %}
{% endtabs %}

## Client-Side Validation in Syncfusion Editors

Syncfusion components integrate naturally with Blazor’s form validation and give immediate visual cues when users input invalid data.

### Text Input Example

{% tabs %}
{% highlight razor %}

<SfTextBox @bind-Value="topUserName" MaxLength="24" Placeholder="Alphanumeric and underscore only" />

@code {
    private string topUserName { get; set; } = string.Empty;
}

{% endhighlight %}
{% endtabs %}

### Form-Level Validation Example

{% tabs %}
{% highlight razor %}

@page "/"
@rendermode InteractiveServer
@using System.ComponentModel.DataAnnotations
@using Microsoft.AspNetCore.Components.Forms
@using Syncfusion.Blazor.Inputs

<h3> Edit form validation</h3>

<EditForm EditContext="@editContext" OnValidSubmit="@OnSubmit">
    <DataAnnotationsValidator />
    
    <SfTextBox @bind-Value="formModel.Email" Placeholder="Enter valid Email address" />
    <ValidationMessage For="() => formModel.Email" />

    <button type="submit">Save</button>
</EditForm>

@code {
    public class UserRecord
    {
        [Required]
        [StringLength(24, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9_]+$")]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        [StringLength(128)]
        public string Email { get; set; } = string.Empty;
    }

    // The model instance used by the form
    private UserRecord formModel { get; } = new();

    // The EditContext wrapping the model
    private EditContext editContext = default!;

    protected override void OnInitialized()
    {
        editContext = new EditContext(formModel);
    }

    private Task OnSubmit()
    {
        // formModel has the validated values
        return Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}

## Secure File Upload Patterns

Syncfusion's **Uploader** component offers client-side validation for file type and file size, but server-side checks must still be implemented.

{% tabs %}
{% highlight razor %}

@page "/"
@using System.ComponentModel.DataAnnotations
@using Microsoft.AspNetCore.Components.Forms
@using Syncfusion.Blazor.Inputs
@rendermode InteractiveServer

<EditForm Model="@employee" OnValidSubmit="@HandleValidSubmit" OnInvalidSubmit="@HandleInvalidSubmit">
    <DataAnnotationsValidator />
    <div class="form-group">
        <SfTextBox @bind-Value="employee.EmpID"></SfTextBox>
        <ValidationMessage For="() => employee.EmpID" />
    </div>

    <div class="form-group">
        <SfUploader @ref="UploadObj"
                    ID="UploadFiles"
                    AllowMultiple="false"  AllowedExtensions=".jpg,.jpeg,.png,.gif"
                    AutoUpload="false">
            <UploaderEvents ValueChange="OnChange"
                            OnRemove="OnRemove"
                            FileSelected="OnSelect">
            </UploaderEvents>
        </SfUploader>
        <ValidationMessage For="() => employee.files" />
    </div>

    <button type="submit" class="btn btn-primary">Submit</button>
</EditForm>

@code {
    // Make sure the type name matches the component (no namespace mismatch)
    private SfUploader UploadObj;

    public class Employee
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string EmpID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please upload a file")]
        public List<UploaderUploadedFiles>? files { get; set; }
    }

    public Employee employee = new();

    // Called when a file is selected
    public void OnSelect(SelectedEventArgs args)
    {
        if (args.FilesData?.Count > 0)
        {
            employee.files = new List<UploaderUploadedFiles>
            {
                new UploaderUploadedFiles {
                    Name = args.FilesData[0].Name,
                    Type = args.FilesData[0].Type,
                    Size = args.FilesData[0].Size
                }
            };
        }
    }

    // Called when the file list changes; save files to disk here
    private async Task OnChange(UploadChangeEventArgs args)
    {
        foreach (var file in args.Files)
        {
            if (file.FileInfo is not null && file.File is not null)
            {
                var path = Path.Combine(_env.WebRootPath, "uploads", file.FileInfo.Name)
                using var filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);
            }
        }
    }

    // Called when the user removes a file
    public void OnRemove(RemovingEventArgs _)
    {
        employee.files = null;
    }

    public Task HandleValidSubmit()
    {
        // No programmatic Upload call needed; files are already saved in OnChange.
        return Task.CompletedTask;
    }

    public Task HandleInvalidSubmit(EditContext _)
    {
        // No programmatic Upload call needed.
        return Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}

## Sanitizing HTML from Syncfusion Rich Text Editor

Syncfusion's Rich Text Editor sanitizes content on the client, but developers must also sanitize HTML again on the server before storing or re-rendering it.

### Client-Side HTML Sanitization

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableHtmlSanitizer="true" Height="220px" />

{% endhighlight %}
{% endtabs %}

## Sanitized Editing in DataGrid

The following example demonstrates sanitization patterns in a Syncfusion **DataGrid**. Inline editors use DataAnnotations for safe text entry, and the Rich Text Editor column sanitizes HTML both on the client and server.

{% tabs %}
{% highlight razor %}

@page "/"

@rendermode InteractiveServer
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.RichTextEditor
@inject ILogger<Home> Logger

<h3>DataGrid Sanitized Editing</h3>

<EditForm EditContext="@editContext" OnValidSubmit="@OnValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <SfGrid TItem="UserRecord"
            DataSource="@Users"
            AllowPaging="true"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
        <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>

        <GridColumns>

            <GridColumn Field=@nameof(UserRecord.Id)
                        HeaderText="ID"
                        IsPrimaryKey="true"
                        TextAlign="TextAlign.Right"
                        Width="90"
                        AllowEditing="false" />

            <GridColumn Field=@nameof(UserRecord.UserName)
                        HeaderText="Username"
                        Width="160">
                <EditTemplate Context="editContextItem">
                    @{
                        var ctx = (UserRecord)editContextItem;
                    }
                    <SfTextBox @bind-Value="ctx.UserName"
                               MaxLength="24"
                               Placeholder="Alphanumeric/underscore only" />
                </EditTemplate>
            </GridColumn>

            <GridColumn Field=@nameof(UserRecord.Email)
                        HeaderText="Email"
                        Width="220" />

            <GridColumn Field=@nameof(UserRecord.NotesHtml)
                        HeaderText="Notes"
                        Width="300">

                <EditTemplate Context="editNotesItem">
                    @{
                        var ctx = (UserRecord)editNotesItem;
                    }
                    <SfRichTextEditor @bind-Value="ctx.NotesHtml"
                                      EnableHtmlSanitizer="true"
                                      Height="180px">
                        <RichTextEditorToolbarSettings Items="@(new List<ToolbarItemModel>
                        {
                            new ToolbarItemModel { Command = ToolbarCommand.Bold },
                            new ToolbarItemModel { Command = ToolbarCommand.Italic },
                            new ToolbarItemModel { Command = ToolbarCommand.Underline },
                            new ToolbarItemModel { Command = ToolbarCommand.OrderedList },
                            new ToolbarItemModel { Command = ToolbarCommand.UnorderedList },
                            new ToolbarItemModel { Command = ToolbarCommand.CreateLink },
                            new ToolbarItemModel { Command = ToolbarCommand.ClearFormat }
                        })" />
                    </SfRichTextEditor>
                </EditTemplate>

                <Template Context="itemContext">
                    @{
                        var item = (UserRecord)itemContext;
                    }
                    <div title="Preview (sanitized at render)">
                        @((MarkupString)item.NotesHtml)
                    </div>
                </Template>

            </GridColumn>
        </GridColumns>
    </SfGrid>
</EditForm>

@code {
    public class UserRecord
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(24, MinimumLength = 3, ErrorMessage = "Username must be 3–24 characters.")]
        [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Only letters, digits, and underscore are allowed.")]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [StringLength(128)]
        public string Email { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Notes cannot exceed 2000 characters.")]
        public string? NotesHtml { get; set; }
    }

    private List<UserRecord> Users = new()
    {
        new UserRecord { Id = 1, UserName = "alice_01", Email = "alice@example.com", NotesHtml = "<p>Hello</p>" },
        new UserRecord { Id = 2, UserName = "bob_02", Email = "bob@example.com", NotesHtml = "<p>Team lead</p>" }
    };

    private EditContext editContext;

    protected override void OnInitialized()
    {
        editContext = new EditContext(new UserRecord());
    }

    private Task OnValidSubmit()
    {
        // Server operations: canonicalize, validate, sanitize HTML again, then persist.
        return Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}

## Logging and Rejecting Malformed Payloads

Reject invalid models and log structured details for security monitoring. Log anomalies (e.g., repeated failed validations, suspicious payload shapes) at appropriate levels and avoid storing raw malicious input without redaction.

{% tabs %}

if (!ModelState.IsValid)
{
    _logger.LogWarning("Validation failed: {@Errors}", ModelState
        .Where(k => k.Value?.Errors.Count > 0)
        .ToDictionary(k => k.Key, v => v.Value!.Errors.Select(e => e.ErrorMessage)));

    return BadRequest(ModelState);
}

{% endtabs %}

Logging validation failures provides visibility into suspicious behavior while preventing harmful data from entering the system.

## See also

[Data Annotation in Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/data-annotation)
[Xhtml validation in Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/xhtml-validation)
[Create Edit Forms with FluentValidation and Syncfusion® Blazor Components](https://www.syncfusion.com/blogs/post/create-edit-forms-with-fluentvalidation-and-syncfusion-blazor-components)
