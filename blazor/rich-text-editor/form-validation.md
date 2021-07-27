---
layout: post
title: Form validation in Blazor RichTextEditor Component | Syncfusion
description: Learn here all about Form validation in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Form validation in Blazor RichTextEditor Component

This following sample demonstrate how to get the Rich Text Editor validation error message in button click.

## Render the editor in a form

Render the Rich Text Editor in form as below.

```csharp

@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel.DataAnnotations;

<div class="control-section">
    <div class="content-container">
        <div id="content" class="box-form" style="margin: 0 auto; max-width:750px; padding:25px">
            <EditForm Model="@Model">
                <DataAnnotationsValidator />
                <SfRichTextEditor ShowCharCount="true" MaxLength="100" Placeholder="Type something..." @bind-Value="@Model.Description" />
                <ValidationMessage For="@(() => Model.Description)" />
                <div class="btn-grp">
                    <button class="samplebtn e-control e-btn" type="reset" data-ripple="true">Reset</button>
                    <button class="samplebtn e-control e-btn" type="submit" data-ripple="true">Submit</button>
                </div>
            </EditForm>
        </div>
    </div>
</div>

<style>
    .box-form {
        webkit-box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 3px 1px -2px rgba(0, 0, 0, 0.12), 0 1px 5px 0 rgba(0, 0, 0, 0.2);
        box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 3px 1px -2px rgba(0, 0, 0, 0.12), 0 1px 5px 0 rgba(0, 0, 0, 0.2);
    }

    .btn-grp {
        text-align: center;
        margin-top: 15px;
    }

    .validation-message {
        color: #f44336;
        font-family: "Roboto", "Segoe UI", "GeezaPro", "DejaVu Serif", "sans-serif", "-apple-system", "BlinkMacSystemFont";
        font-size: 12px;
        font-weight: normal;
    }
</style>

@code{
    private class FormModel
    {
        [Required]
        [MinLength(20, ErrorMessage = "Please enter at least 20 characters.")]
        public string Description { get; set; }
    }

    private FormModel Model = new FormModel();
}

```

The output will be as follows.

![Form](./images/default-validation.png)

## Validation Rules

The Rich Text Editor is a textarea control. The Rich Text Editor also provides the functionality of character count and its validation. So, you can validate the Rich Text Editor's value on form submission by applying Validation Rules and Validation Message to the Rich Text Editor.

| Rules | Description |
|----------------|---------|
| Required | Requires value for the Rich Text Editor control.|
| MinLength | Requires the value to be of given minimum characters count.|
| MaxLength | Requires the value to be of given maximum characters count.|

This sample is demonstrate form validation using the `DataAnnotationsValidator`.

```csharp

@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel.DataAnnotations;

<EditForm Model="@MyForm">
    <DataAnnotationsValidator />
    <p>
        <label for="description">Enter Text</label>
        <SfRichTextEditor ShowCharCount="true" MaxLength="200" Placeholder="Type something" @bind-Value="@MyForm.Description">
            <RichTextEditorToolbarSettings Items="@Tools" />
        </SfRichTextEditor>
        <ValidationMessage For="@(() => MyForm.Description)"></ValidationMessage>
    </p>
    <button class="e-btn" type="submit">Submit</button>
</EditForm>

@code{
    public class Form
    {
        [Required]
        [MinLength(20, ErrorMessage = "Please enter at least 20 characters.")]
        public string Description { get; set; } = "<div>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</div>";
    }

    private Form MyForm = new Form();

    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo }
    };
}

```

The output will be as follows.

![Form validation](./images/validation-message.png)

## Validation Message

The default error message for a rule can be customizable by defining it along with concern rule object as follows.

```csharp

@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel.DataAnnotations;

<EditForm Model="@MyForm">
    <DataAnnotationsValidator />
    <p>
        <label for="description">Enter Text</label>
        <SfRichTextEditor @bind-Value="@MyForm.Description" ShowCharCount="true" MaxLength="200" Placeholder="Type something">
            <RichTextEditorToolbarSettings items="@Tools" />
        </SfRichTextEditor>
        <ValidationMessage For="@(() => MyForm.Description)"></ValidationMessage>
    </p>
    <button class="e-btn" type="submit">Submit</button>
</EditForm>

@code{
    public class Form
    {
        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum 200 characters only")]
        public string Description { get; set; } = "<div>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</div>";
    }

    private Form MyForm = new Form();

    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo }
    };
}

```

## Custom Placement of Validation Message

The Form Validation error message can be placed from default position to desired custom location.

```csharp

@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel.DataAnnotations;

<EditForm Model="@MyForm">
    <p>
        <ValidationMessage For="@(() => MyForm.Description)"></ValidationMessage>
    </p>
    <DataAnnotationsValidator />
    <p>
        <label for="description">Enter Text</label>
        <SfRichTextEditor ShowCharCount="true" MaxLength="200" Placeholder="Type something" @bind-Value="@MyForm.Description">
            <RichTextEditorToolbarSettings Items="@Tools" />
        </SfRichTextEditor>
    </p>
    <button class="e-btn" type="submit">Submit</button>
</EditForm>

@code{
    public class Form
    {
        [Required(ErrorMessage = "RTE: value is required")]
        [MinLength(15, ErrorMessage = "RTE: Need atleast 15 character length")]
        [MaxLength(100, ErrorMessage = "RTE: Maximum 200 characters only")]
        public string Description { get; set; } = "<div>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</div>";
    }

    private Form MyForm = new Form();

    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo }
    };
}

```

The output will be as follows.

![Custom placement](./images/custom-placement.png)

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.