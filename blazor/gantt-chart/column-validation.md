---
layout: post
title: Column validation in Blazor Gantt Chart Component | Syncfusion
description: Learn how to configure built-in and custom column validation in the Syncfusion Blazor Gantt Chart component, including ValidationRules, DataAnnotations, and custom validator components with form-level checks.
platform: Blazor
control: Gantt Chart
documentation: ug
---

## Column validation in Blazor Gantt Chart

Column validation allows validating edited or newly added row data before saving it. This feature is particularly useful for enforcing specific rules or constraints on individual columns to maintain data integrity. By applying validation rules to columns, error messages are displayed for invalid fields, and saving is prevented until all validations succeed.

The Syncfusion® Blazor Gantt Chart component leverages the Form Validator library for column validation. Validation rules can be defined using the `GanttColumn.ValidationRules` property to specify criteria for validating column values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" TValue="TaskData" DataSource="@TaskCollection" Height="450px" Width="1400px" HighlightWeekends="true"
            Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel"})" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskId" Name="ActivityName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                    ParentID="ParentId"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true"
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
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    protected override void OnInitialized()
    {
        this.TaskCollection = EditingData().ToList();
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string ActivityName { get; set; }
        public int? Duration { get; set; }
        public int Progress { get; set; }           
        public int? ParentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public static List<TaskData> EditingData()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() {
                TaskId = 1,
                ActivityName = "Product concept",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 5,
                Progress = 60,
                ParentId = null,
            },
            new TaskData() {
                TaskId = 2,
                ActivityName = "Defining the product usage",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 3,
                Progress = 70,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 3,
                ActivityName = "Defining the target audience",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 04),
                Duration = 3,
                Progress = 80,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 4,
                ActivityName = "Prepare product sketch and notes",
                StartDate = new DateTime(2021, 04, 05),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 2,
                Progress = 90,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 5,
                ActivityName = "Concept approval",
                StartDate = new DateTime(2021, 04, 08),
                EndDate = new DateTime(2021, 04, 08),
                Duration= 0,
                Progress = 100,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 6,
                ActivityName = "Market research",
                StartDate = new DateTime(2021, 04, 09),
                EndDate = new DateTime(2021, 04, 18),
                Duration = 4,
                Progress = 30,
                ParentId = null,
            },
                new TaskData() {
                TaskId = 7,
                ActivityName = "Demand analysis",
                StartDate = new DateTime(2021, 04, 09),
                EndDate = new DateTime(2021, 04, 12),
                Duration = 4,
                Progress = 40,
                ParentId = 6,
            },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

## Custom validation
Custom validation enables logic beyond built-in rules, including business constraints, dependent-field checks, and conditional validations during Add and Edit operations.

### To implement custom validation in Blazor Gantt Chart:

* Create a class that inherits from `ValidationAttribute`.
Override the `IsValid` method to include custom logic.
* Apply the custom attribute to the model property that needs validation.
* The Gantt Chart will automatically enforce these rules during Add and Edit operations.

The following sample code demonstrates how to implement custom validation for the ActivityName and Progress fields.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using System.ComponentModel.DataAnnotations
<SfGantt @ref="Gantt" TValue="TaskData" DataSource="@TaskCollection" Height="450px" Width="1400px" HighlightWeekends="true"
            Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel"})" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskId" Name="ActivityName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                    ParentID="ParentId"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true"
                        Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </GanttColumn>
        <GanttColumn Field="ActivityName" HeaderText="Task Name" Width="160"/>
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
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    protected override void OnInitialized()
    {
        this.TaskCollection = EditingData().ToList();
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        [CustomValidationActivityName]
        public string ActivityName { get; set; }
        public int? Duration { get; set; }
        [CustomValidationProgress]
        public int Progress { get; set; }           
        public int? ParentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
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
    public static List<TaskData> EditingData()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() {
                TaskId = 1,
                ActivityName = "Product concept",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 5,
                Progress = 60,
                ParentId = null,
            },
            new TaskData() {
                TaskId = 2,
                ActivityName = "Defining the product usage",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 3,
                Progress = 70,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 3,
                ActivityName = "Defining the target audience",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 04),
                Duration = 3,
                Progress = 80,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 4,
                ActivityName = "Prepare product sketch and notes",
                StartDate = new DateTime(2021, 04, 05),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 2,
                Progress = 90,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 5,
                ActivityName = "Concept approval",
                StartDate = new DateTime(2021, 04, 08),
                EndDate = new DateTime(2021, 04, 08),
                Duration= 0,
                Progress = 100,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 6,
                ActivityName = "Market research",
                StartDate = new DateTime(2021, 04, 09),
                EndDate = new DateTime(2021, 04, 18),
                Duration = 4,
                Progress = 30,
                ParentId = null,
            },
                new TaskData() {
                TaskId = 7,
                ActivityName = "Demand analysis",
                StartDate = new DateTime(2021, 04, 09),
                EndDate = new DateTime(2021, 04, 12),
                Duration = 4,
                Progress = 40,
                ParentId = 6,
            },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

## Custom validator component 
Custom validator components provide flexible validation beyond built‑in ValidationRules and ValidationAttribute classes.There are scenarios where these options are not enough. 
For example: Complex business logic
You may need to validate multiple fields together (e.g., EndDate must be after StartDate, or Duration must match Progress).

### How does it work in Gantt Chart?

The Syncfusion® Blazor Gantt Chart supports injecting a custom validator component into its internal EditForm using the `Validator` property of [GanttEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html).

Inside the validator, you can access the current row’s data and the edit context via the implicit parameter context of type `ValidatorTemplateContext`. This enables form-level checks during Add/Edit operations.

For creating a form validator component you can refer [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/?view=aspnetcore-8.0#validator-components).

In the below code example, the following things have been done.

* A form validator component named GanttCustomValidator that accepts `ValidatorTemplateContext` as a parameter.
* Usage of `GanttEditSettings.Validator` to inject the validator into the internal EditForm.
* This validator component will checks for TaskId and ActivityName with per‑field messages.
* Display of errors using the built‑in validation tooltip via
`ValidatorTemplateContext.ShowValidationMessage(fieldName, isValid, message)` method.

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
        public void Dispose()
        {
            if (CurrentEditContext is not null)
            {
                CurrentEditContext.OnValidationRequested -= ValidateRequested;
                CurrentEditContext.OnFieldChanged -= ValidateField;
            }
        }

        private void AddError(FieldIdentifier id, string message)
        {
            _messageStore.Add(id, message);
            context?.ShowValidationMessage(id.FieldName, false, message);
        }

        private void ClearField(FieldIdentifier id)
        {
            _messageStore.Clear(id);
            context?.ShowValidationMessage(id.FieldName, true, null);
        }

        private void HandleValidation(FieldIdentifier identifier)
        {
            if (identifier.Model is GanttData.TaskData taskdata)
            {
                _messageStore.Clear(identifier);
                switch (identifier.FieldName)
                {
                    case nameof(GanttData.TaskData.TaskId):
                        if (taskdata.TaskId <= 0)
                            AddError(identifier, "Task ID is required.");
                        else
                            ClearField(identifier);
                        break;

                    case nameof(GanttData.TaskData.ActivityName):
                        if (string.IsNullOrWhiteSpace(taskdata.ActivityName))
                            AddError(identifier, "Task Name is required.");
                        else if (taskdata.ActivityName.Length < 5 || taskdata.ActivityName.Length > 10)
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
        private void ValidateField(object sender, FieldChangedEventArgs e)
        {
            HandleValidation(e.FieldIdentifier);
        }

        private void ValidateRequested(object sender, ValidationRequestedEventArgs e)
        {
            _messageStore.Clear();
            string[] fieldsToValidate = new[]
            {
                nameof(GanttData.TaskData.TaskId),
                nameof(GanttData.TaskData.ActivityName),
                nameof(GanttData.TaskData.Progress),
                nameof(GanttData.TaskData.StartDate),
                nameof(GanttData.TaskData.EndDate),
            };
            foreach (var field in fieldsToValidate)
            {
                HandleValidation(CurrentEditContext.Field(field));
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using System.ComponentModel.DataAnnotations;
@using ColumnValidationComponents

<SfGantt TValue="GanttData.TaskData" DataSource="@TaskCollection" Height="450px" Width="1400px" HighlightWeekends="true"
            Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel"})" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskId" Name="ActivityName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
        ParentID="ParentId"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true">
        <Validator>
            @{
                ValidatorTemplateContext txt = context as ValidatorTemplateContext;
            }
            <GanttCustomValidator context="@txt"></GanttCustomValidator>
        </Validator>
    </GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" Width="80"
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
    private List<GanttData.TaskData> TaskCollection { get; set; }
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
        public class TaskData
        {
            public int TaskId { get; set; }
            public string ActivityName { get; set; } = string.Empty;
            public int? Duration { get; set; }
            public string Predecessor { get; set; } = string.Empty;
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }
        public static List<TaskData> EditingData()
        {
            List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() {
                TaskId = 1,
                ActivityName = "Product concept",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 5,
                Progress = 60,
                ParentId = null,
            },
            new TaskData() {
                TaskId = 2,
                ActivityName = "Defining the product usage",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 3,
                Progress = 70,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 3,
                ActivityName = "Defining the target audience",
                StartDate = new DateTime(2021, 04, 02),
                EndDate = new DateTime(2021, 04, 04),
                Duration = 3,
                Progress = 80,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 4,
                ActivityName = "Prepare product sketch and notes",
                StartDate = new DateTime(2021, 04, 05),
                EndDate = new DateTime(2021, 04, 08),
                Duration = 2,
                Progress = 90,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 5,
                ActivityName = "Concept approval",
                StartDate = new DateTime(2021, 04, 08),
                EndDate = new DateTime(2021, 04, 08),
                Duration= 0,
                Progress = 100,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 6,
                ActivityName = "Market research",
                StartDate = new DateTime(2021, 04, 09),
                EndDate = new DateTime(2021, 04, 18),
                Duration = 4,
                Progress = 30,
                ParentId = null,
            },
                new TaskData() {
                TaskId = 7,
                ActivityName = "Demand analysis",
                StartDate = new DateTime(2021, 04, 09),
                EndDate = new DateTime(2021, 04, 12),
                Duration = 4,
                Progress = 40,
                ParentId = 6,
            },
        };
            return Tasks;
        }
    }
}

{% endhighlight %}
{% endtabs %}



