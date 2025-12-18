---
layout: post
title: Column Validation in Blazor Gantt Chart Component | Syncfusion
description: Learn to configure built-in and custom column validation in Syncfusion Blazor Gantt Chart, including validation rules, data annotations, and custom validators.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Column validation in Blazor Gantt Chart

Column validation ensures that edited or newly added row data meets defined criteria before it is saved. This feature is useful for enforcing rules or constraints on individual columns to maintain data integrity. When validation rules are applied, error messages are displayed for invalid fields, and saving is prevented until all validations pass.

The Syncfusion® Blazor Gantt Chart component uses the Form Validator library to perform column validation. Validation rules can be specified using the [GanttColumn.ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_ValidationRules) property to define criteria for validating column values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" TValue="TaskInfoModel" DataSource="@TaskCollection" Height="450px" Width="1400px" HighlightWeekends="true"
            Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel"})" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskID" Name="ActivityName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                    ParentID="ParentID"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task ID" IsPrimaryKey="true"
                        Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="ActivityName" HeaderText="Task Name" Width="160"
        ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules {
            Required = true,
            RangeLength = new object[] { 5, 10 },
            Messages = new Dictionary<string, object>() {
                { "required", "Task Name is required." },
                { "rangelength", "Task Name must be between 5 and 10 characters." }
            }
        })" />
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150"
                        Format="d" EditType="Syncfusion.Blazor.Grids.EditType.DateTimePickerEdit"
                        ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules { Required = true,Range = new object[] { new DateTime(2020, 1, 1), DateTime.Now }, Messages = new Dictionary<string, object>() { { "required", "Start Date is required." } } })">
        </GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150"
                        Format="g" EditType="Syncfusion.Blazor.Grids.EditType.DateTimePickerEdit"
                        ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules { Required = true, Range = new object[] { new DateTime(2020, 1, 1), DateTime.Now }, Messages = new Dictionary<string, object>() { { "required", "End Date is required." } } })">
        </GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100" 
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"
        ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules { Required = true, Range = new object[] { 2, 10 },})">
        </GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100" EditType="Syncfusion.Blazor.Grids.EditType.NumericEdit"
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"
                        ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules { Required = true,Number = true, Min = 5,Max = 50, Messages = new Dictionary<string, object>() { { "required", "Progress is required." }, { "min", "Progress must be greater than 5" }, { "max", "Progress must be lesser than 50" } } })">
        </GanttColumn>
    </GanttColumns>             
</SfGantt>

@code {
    private List<TaskInfoModel> TaskCollection { get; set; }
    private SfGantt<TaskInfoModel> Gantt;
    protected override void OnInitialized()
    {
        this.TaskCollection = EditingData().ToList();
    }
    public class TaskInfoModel
    {
        public int TaskID { get; set; }
        public string? ActivityName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Duration { get; set; }
        public int Progress { get; set; }           
        public int? ParentID { get; set; }
    }
    public static List<TaskInfoModel> EditingData()
    {
        List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
        new TaskInfoModel() { TaskID = 1, ActivityName = "Product concept", StartDate = new DateTime(2021, 04, 02), Duration = 5, Progress = 60, ParentID = null },
        new TaskInfoModel() { TaskID = 2, ActivityName = "Defining the product usage", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 70, ParentID = 1 },
        new TaskInfoModel() { TaskID = 3, ActivityName = "Defining the target audience", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 80, ParentID = 1 },
        new TaskInfoModel() { TaskID = 4, ActivityName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = 2, Progress = 90, ParentID = 1 },
        new TaskInfoModel() { TaskID = 5, ActivityName = "Concept approval", StartDate = new DateTime(2021, 04, 08), Duration = 0, Progress = 100, ParentID = 1 },
        new TaskInfoModel() { TaskID = 6, ActivityName = "Market research", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 30, ParentID = null },
        new TaskInfoModel() { TaskID = 7, ActivityName = "Demand analysis", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 40, ParentID = 6 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjheWLChfJEBegzY?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

> Validation is not supported for the [Resource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttResourceColumn.html) column.

## Data annotation

The Syncfusion® Blazor Gantt Chart component supports data annotation validation attributes to validate fields in the underlying data model during add and edit operations. These attributes provide a declarative approach to enforce rules directly on model properties, ensuring data integrity without requiring additional validation logic.

**Applying Data Annotation**

* Add validation attributes to the model class properties that are bound to the Gantt Chart.
* Validation messages are displayed using the built-in tooltip in the Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using System.ComponentModel.DataAnnotations
<SfGantt @ref="Gantt" TValue="TaskInfoModel" DataSource="@TaskCollection" Height="450px" Width="1400px" HighlightWeekends="true"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel"})" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskID" Name="ActivityName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentID"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task ID" IsPrimaryKey="true"
                     Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="ActivityName" HeaderText="Task Name" Width="160" />
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150">
        </GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150" EditType="Syncfusion.Blazor.Grids.EditType.DateTimePickerEdit">
        </GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100"
                     TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100" EditType="Syncfusion.Blazor.Grids.EditType.NumericEdit"
                     TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private List<TaskInfoModel> TaskCollection { get; set; }
    private SfGantt<TaskInfoModel> Gantt;
    protected override void OnInitialized()
    {
        this.TaskCollection = EditingData().ToList();
    }
    public class TaskInfoModel
    {
        public int TaskID { get; set; }
        [Required(ErrorMessage = "ActivityName is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "ActivityName must be between 5 and 50 characters")]
        public string? ActivityName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        [Range(0, 100, ErrorMessage = "Progress must be between 0 and 100")]
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskInfoModel> EditingData()
    {
        List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
        new TaskInfoModel() { TaskID = 1, ActivityName = "Product concept", StartDate = new DateTime(2021, 04, 02), Duration = 5, Progress = 60, ParentID = null },
        new TaskInfoModel() { TaskID = 2, ActivityName = "Defining the product usage", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 70, ParentID = 1 },
        new TaskInfoModel() { TaskID = 3, ActivityName = "Defining the target audience", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 80, ParentID = 1 },
        new TaskInfoModel() { TaskID = 4, ActivityName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = 2, Progress = 90, ParentID = 1 },
        new TaskInfoModel() { TaskID = 5, ActivityName = "Concept approval", StartDate = new DateTime(2021, 04, 08), Duration = 0, Progress = 100, ParentID = 1 },
        new TaskInfoModel() { TaskID = 6, ActivityName = "Market research", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 30, ParentID = null },
        new TaskInfoModel() { TaskID = 7, ActivityName = "Demand analysis", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 40, ParentID = 6 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLoWLWLpyjcQTAD?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Custom validation

The Syncfusion® Blazor Gantt Chart component supports custom validation for scenarios where built-in rules or data annotations do not meet specific requirements. This approach is useful for enforcing business-specific constraints, performing dependent-field checks, or applying conditional validations during add and edit operations.

**Implementing Custom Validation**

* Create a class that inherits from `ValidationAttribute` and override the `IsValid` method to include custom logic.
* Apply the custom attribute to the model property that requires validation.
* The Gantt Chart automatically enforces these rules during add and edit operations.

The following example demonstrates how to implement custom validation for the **ActivityName** and **Progress** fields.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using System.ComponentModel.DataAnnotations
<SfGantt @ref="Gantt" TValue="TaskInfoModel" DataSource="@TaskCollection" Height="450px" Width="1400px" HighlightWeekends="true"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel"})" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskID" Name="ActivityName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentID"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task ID" IsPrimaryKey="true"
                     Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="ActivityName" HeaderText="Task Name" Width="160" />
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150">
        </GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150"
                     Format="g" EditType="Syncfusion.Blazor.Grids.EditType.DateTimePickerEdit">
        </GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100"
                     TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100" EditType="Syncfusion.Blazor.Grids.EditType.NumericEdit"
                     TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private List<TaskInfoModel> TaskCollection { get; set; }
    private SfGantt<TaskInfoModel> Gantt;
    protected override void OnInitialized()
    {
        this.TaskCollection = EditingData().ToList();
    }
    public class TaskInfoModel
    {
        public int TaskID { get; set; }
        [CustomValidationActivityName]
        public string? ActivityName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        [CustomValidationProgress]
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    /// <summary>
    /// Provides custom validation for the <c>ActivityName</c> property.
    /// Ensures that the task name is not empty and its length is between 5 and 10 characters.
    /// </summary>
    public class CustomValidationActivityName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = value as string;
            if (string.IsNullOrWhiteSpace(str))
                return new ValidationResult("Task Name is required.");
            if (str.Length < 5 || str.Length > 10)
                return new ValidationResult("Task Name must be between 5 and 10 characters.");
            return ValidationResult.Success;
        }
    }

    /// <summary>
    /// Provides custom validation for the <c>Progress</c> property.
    /// Ensures that the progress value is provided and falls within the range of 5 to 50.
    /// </summary>
    public class CustomValidationProgress : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return new ValidationResult("Progress is required.");
            var v = (int)value;
            if (v < 5)
                return new ValidationResult("Progress must be greater than 5");
            if (v > 50)
                return new ValidationResult("Progress must be lesser than 50");
            return ValidationResult.Success;
        }
    }
    public static List<TaskInfoModel> EditingData()
    {
        List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
        new TaskInfoModel() { TaskID = 1, ActivityName = "Product concept", StartDate = new DateTime(2021, 04, 02), Duration = 5, Progress = 60, ParentID = null },
        new TaskInfoModel() { TaskID = 2, ActivityName = "Defining the product usage", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 70, ParentID = 1 },
        new TaskInfoModel() { TaskID = 3, ActivityName = "Defining the target audience", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 80, ParentID = 1 },
        new TaskInfoModel() { TaskID = 4, ActivityName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = 2, Progress = 90, ParentID = 1 },
        new TaskInfoModel() { TaskID = 5, ActivityName = "Concept approval", StartDate = new DateTime(2021, 04, 08), Duration = 0, Progress = 100, ParentID = 1 },
        new TaskInfoModel() { TaskID = 6, ActivityName = "Market research", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 30, ParentID = null },
        new TaskInfoModel() { TaskID = 7, ActivityName = "Demand analysis", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 40, ParentID = 6 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXreihChTSiAmHFW?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Custom validator component

The Syncfusion® Blazor Gantt Chart component supports custom validator components for scenarios that require validation beyond built-in [ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_ValidationRules) and `ValidationAttribute` classes. This approach allows overriding the default validation logic and implementing complex, application-specific rules.

**Injecting a Custom Validator**

A custom validator component can be injected into the internal EditForm of the Gantt Chart using the [Validator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html#Syncfusion_Blazor_Gantt_GanttEditSettings_Validator) property of [GanttEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html). Inside the validator, the current row's data and the edit context can be accessed through the implicit parameter context of type [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html). This enables form-level checks during add and edit operations.

For details on creating a form validator component, refer to [ASP.NET Core Blazor Validator Components](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/?view=aspnetcore-8.0#validator-components).

**Example: Implementing a Custom Validator**

In the following example:

* A custom validator component named **GanttCustomValidator** accepts [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html) as a parameter.

* The [GanttEditSettings.Validator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html#Syncfusion_Blazor_Gantt_GanttEditSettings_Validator) property is used to inject the validator into the internal EditForm.

* The validator checks **TaskID** and **ActivityName** fields and displays per-field messages.

* Errors are displayed using the built-in validation tooltip via the [ValidatorTemplateContext.ShowValidationMessage(fieldName, isValid, message)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html#Syncfusion_Blazor_Grids_ValidatorTemplateContext_ShowValidationMessage) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/gantt-validator"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using System.ComponentModel.DataAnnotations;
@using ColumnValidationComponents

<SfGantt TValue="GanttData.TaskInfoModel" DataSource="@TaskCollection" Height="450px" Width="1400px" HighlightWeekends="true"
            Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel"})" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskID" Name="ActivityName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
        ParentID="ParentID"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true">
        <Validator>
            @{
                ValidatorTemplateContext txt = context as ValidatorTemplateContext;
            }
            <GanttCustomValidator context="@txt"></GanttCustomValidator>
        </Validator>
    </GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task ID" IsPrimaryKey="true" Width="80"
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="ActivityName" HeaderText="Task Name" Width="160" />
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150" Format="d"
                     EditType="Syncfusion.Blazor.Grids.EditType.DateTimePickerEdit">
        </GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150" Format="g"
                     EditType="Syncfusion.Blazor.Grids.EditType.DateTimePickerEdit">
        </GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100"
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100"
                        EditType="Syncfusion.Blazor.Grids.EditType.NumericEdit"
                        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
    </GanttColumns>
</SfGantt>
@code {
    private List<GanttData.TaskInfoModel> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GanttData.EditingData();
    }
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight c# %}

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ColumnValidationComponents
{
    public class GanttData
    {
        public class TaskInfoModel
        {
            public int TaskID { get; set; }
            public string ActivityName { get; set; } = string.Empty;
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int? Duration { get; set; }
            public string Predecessor { get; set; } = string.Empty;
            public int Progress { get; set; }
            public int? ParentID { get; set; }
        }
        public static List<TaskInfoModel> EditingData()
        {
            List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
            new TaskInfoModel() { TaskID = 1, ActivityName = "Product concept", StartDate = new DateTime(2021, 04, 02), Duration = 5, Progress = 60, ParentID = null },
            new TaskInfoModel() { TaskID = 2, ActivityName = "Defining the product usage", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 70, ParentID = 1 },
            new TaskInfoModel() { TaskID = 3, ActivityName = "Defining the target audience", StartDate = new DateTime(2021, 04, 02), Duration = 3, Progress = 80, ParentID = 1 },
            new TaskInfoModel() { TaskID = 4, ActivityName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = 2, Progress = 90, ParentID = 1 },
            new TaskInfoModel() { TaskID = 5, ActivityName = "Concept approval", StartDate = new DateTime(2021, 04, 08), Duration = 0, Progress = 100, ParentID = 1 },
            new TaskInfoModel() { TaskID = 6, ActivityName = "Market research", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 30, ParentID = null },
            new TaskInfoModel() { TaskID = 7, ActivityName = "Demand analysis", StartDate = new DateTime(2021, 04, 09), Duration = 4, Progress = 40, ParentID = 6 }
            };
            return Tasks;
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight c# %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Gantt;
using Syncfusion.Blazor.Grids;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Dynamic;
using System.Collections.Generic;

namespace ColumnValidationComponents
{
    public class GanttCustomValidator : ComponentBase, IDisposable
    {
        [Parameter] public ValidatorTemplateContext context { get; set; }
        [CascadingParameter] private EditContext CurrentEditContext { get; set; }
        private ValidationMessageStore _messageStore;
        private static readonly DateTime MinDate2020 = new DateTime(2020, 1, 1);
        private static DateTime MaxDateToday => DateTime.Today;
        private static readonly DateTime MaxDate2030 = new DateTime(2030, 12, 31);

        protected override void OnInitialized()
        {
            if (CurrentEditContext is null)
            {
                throw new InvalidOperationException($"{nameof(GanttCustomValidator)} requires a cascading EditContext.");
            }
            _messageStore = new ValidationMessageStore(CurrentEditContext);
            CurrentEditContext.OnValidationRequested += ValidateRequested;
            CurrentEditContext.OnFieldChanged += ValidateField;
        }

        /// <summary>
        /// Adds a validation error message for a given field and notifies the Syncfusion validator template
        /// to display the message within the corresponding column.
        /// </summary>
        private void AddError(FieldIdentifier id, string message)
        {
            _messageStore.Add(id, message);
            context?.ShowValidationMessage(id.FieldName, false, message);
        }

        /// <summary>
        /// Clears validation messages for a given field and notifies the Syncfusion validator template
        /// to remove any message shown for the corresponding column.
        /// </summary>
        private void ClearField(FieldIdentifier id)
        {
            _messageStore.Clear(id);
            context?.ShowValidationMessage(id.FieldName, true, null);
        }

        /// <summary>
        /// Executes field-level validation for the provided <see cref="FieldIdentifier"/>.
        /// Currently validates <c>TaskID</c> and <c>ActivityName</c> of the <see cref="GanttData.TaskInfoModel"/>.
        /// Other fields will be cleared by default.
        /// </summary>
        private void HandleValidation(FieldIdentifier identifier)
        {
            if (identifier.Model is GanttData.TaskInfoModel TaskInfoModel)
            {
                _messageStore.Clear(identifier);
                switch (identifier.FieldName)
                {
                    case nameof(GanttData.TaskInfoModel.TaskID):
                        if (TaskInfoModel.TaskID <= 0)
                            AddError(identifier, "Task ID is required.");
                        else
                            ClearField(identifier);
                        break;

                    case nameof(GanttData.TaskInfoModel.ActivityName):
                        if (string.IsNullOrWhiteSpace(TaskInfoModel.ActivityName))
                            AddError(identifier, "Task Name is required.");
                        else if (TaskInfoModel.ActivityName.Length < 5 || TaskInfoModel.ActivityName.Length > 10)
                            AddError(identifier, "Task Name must be between 5 and 10 characters.");
                        else
                            ClearField(identifier);
                        break;
                    default:
                        ClearField(identifier);
                        break;
                }
                return;
            }
            ClearField(identifier);
        }

        /// <summary>
        /// Handles per-field validation when a field changes in the edit form
        /// by delegating to <see cref="HandleValidation(FieldIdentifier)"/>.
        /// </summary>
        private void ValidateField(object sender, FieldChangedEventArgs e)
        {
            HandleValidation(e.FieldIdentifier);
        }

        /// <summary>
        /// Performs form-level validation when validation is requested (e.g., submit or explicit validation).
        /// Iterates predefined fields and validates each via <see cref="HandleValidation(FieldIdentifier)"/>.
        /// </summary>
        private void ValidateRequested(object sender, ValidationRequestedEventArgs e)
        {
            _messageStore.Clear();
            string[] fieldsToValidate = new[]
            {
                nameof(GanttData.TaskInfoModel.TaskID),
                nameof(GanttData.TaskInfoModel.ActivityName),
                nameof(GanttData.TaskInfoModel.Progress),
                nameof(GanttData.TaskInfoModel.StartDate),
                nameof(GanttData.TaskInfoModel.EndDate),
            };
            foreach (var field in fieldsToValidate)
            {
                HandleValidation(CurrentEditContext.Field(field));
            }
        }

        /// <summary>
        /// Unsubscribes event handlers from the <see cref="EditContext"/> to prevent memory leaks and cleans up resources.
        /// </summary>
        public void Dispose()
        {
            if (CurrentEditContext is not null)
            {
                CurrentEditContext.OnValidationRequested -= ValidateRequested;
                CurrentEditContext.OnFieldChanged -= ValidateField;
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

## See Also
- [How to define columns manually in Blazor Gantt Chart?](https://blazor.syncfusion.com/documentation/gantt-chart/columns#defining-columns)
- [How to use column templates in Blazor Gantt Chart?](https://blazor.syncfusion.com/documentation/gantt-chart/column-template)