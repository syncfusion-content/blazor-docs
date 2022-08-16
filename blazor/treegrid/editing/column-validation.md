---
layout: post
title: Column Validation in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about column validation in Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Column validation in Blazor TreeGrid Component

Column validation allows to validate the edited or added row data and it displays errors for invalid fields before saving data. Tree Grid uses **Form Validator** component for column validation. The validation rules can be set by defining the [TreeGridColumn. ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn~ValidationRules.html).

```cshtml
@using TreeGridComponent.Data; 
@using Syncfusion. Blazor.TreeGrid; 

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskId" 
ParentIdMapping="ParentId" TreeColumnIndex="1" 
Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <TreeGridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"
    ShowDeleteConfirmDialog="true" />
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" IsPrimaryKey="true" 
        Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160">
        </TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100"
        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" 
        ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules { Number = true,
        Min = 0 })" EditType="Syncfusion.Blazor.Grids.EditType.NumericEdit"
        TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right">
        </TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{

    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {       
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public int? ParentId { get; set;}
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,
            TaskName = "Parent Task 1",Duration = 10,Progress = 70,ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,
            TaskName = "Child task 1",Progress = 80,ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,
            TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,
            TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,
            TaskName = "Parent Task 2",Duration = 10,Progress = 70,ParentId = null,
            IsParent = true,});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,
            TaskName = "Child task 1",Duration = 4,Progress = 80,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,
            TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,
            TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,
            TaskName = "Child task 4",Duration = 6,Progress = 77,ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}
```

![Column Validation in Blazor TreeGrid](../images/blazor-treegrid-column-validation.png)

## Data annotation

Data Annotation validation attributes are used to validate the fields in the tree grid. The validation attributes that are supported in the tree grid are listed below.

| Attribute Name | Functionality |
|-------|---------|
| Validations are, <br><br>1. RequiredAttribute<br>2. StringLengthAttribute<br>3. RangeAttribute<br>4. RegularExpressionAttribute<br>5. MinLengthAttribute<br>6. MaxLengthAttribute<br>7. EmailAddressAttribute<br>8. CompareAttribute<br>9. DataTypeAttribute<br>10.  DataType. Custom<br>11. DataType. Date<br>12. DataType. DateTime<br>13. DataType. EmailAddress<br>14. DataType. ImageUrl<br>15. DataType. Url | The data annotation validation attributes are used as `validation rules` in the tree grid CRUD operations |

More information on the data annotation can be found in this [documentation](https://blazor.syncfusion.com/documentation/datagrid/data-annotation/) section.

## Custom validation

Custom validation allows the users to customize the validations manually according to the user's criteria.

Custom validation can be used by overriding the IsValid method inside the class that inherits the Validation Attribute. All the validations are done inside the IsValid method. The same class should be set as a attribute to the specific field property of the tree grid's datasource model class.

The following sample code demonstrates custom validations implemented in the fields `Duration` and `Priority` .

```cshtml
@using TreeGridComponent. Data; 
@using Syncfusion. Blazor. TreeGrid; 
@using System. ComponentModel. DataAnnotations; 

<SfTreeGrid TValue="BusinessObject" DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="0"
Toolbar="@(new List<string>() { "Edit", "Update", "Cancel" })">
    <TreeGridEditSettings Mode="Syncfusion.Blazor.TreeGrid.EditMode.Cell" NewRowPosition="RowPosition.Child"
                          AllowEditing="true" AllowAdding="true" AllowDeleting="true" ShowDeleteConfirmDialog="true" />
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="145"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" EditType="Syncfusion.Blazor.Grids.EditType.NumericEdit" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100" EditType="Syncfusion.Blazor.Grids.EditType.DefaultEdit" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>

</SfTreeGrid>

@code{

    public List<BusinessObject> TreeData = new List<BusinessObject>();
    protected override void OnInitialized()
    {
        TreeData.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, Progress = 70, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", Duration = 4, Progress = 80, ParentId = 1, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, Progress = 65, ParentId = 1, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 4, TaskName = "Parent Task 2", Duration = 6, Progress = 77, ParentId = null, Priority = "Low" });
        TreeData.Add(new BusinessObject() { TaskId = 5, TaskName = "Child Task 5", Duration = 9, Progress = 25, ParentId = 4, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 6", Duration = 9, Progress = 7, ParentId = 5, Priority = "Normal" });
        TreeData.Add(new BusinessObject() { TaskId = 7, TaskName = "Parent Task 3", Duration = 4, Progress = 45, ParentId = null, Priority = "High" });
        TreeData.Add(new BusinessObject() { TaskId = 8, TaskName = "Child Task 7", Duration = 3, Progress = 38, ParentId = 7, Priority = "Critical" });
        TreeData.Add(new BusinessObject() { TaskId = 9, TaskName = "Child Task 8", Duration = 7, Progress = 70, ParentId = 7, Priority = "Low" });
    }
    public class CustomValidationDuration : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int duration = (int)value;
                if (duration >= 1 && duration <= 20)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Duration is not as expected, try between 1 and 20");
                }
            }
            else
            {
                return new ValidationResult("No Value");
            }
        }
    }
    public class CustomValidationPriority : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                if (name.Length >= 1 && name.Length <= 7)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Priority text length is not as expected");
                }
            }
            else
            {
                return new ValidationResult("No Value");
            }
        }
    }

}

```

```cshtml

namespace TreeGridComponent. Data
{

    public class BusinessObject
    {
        [Required]
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        [CustomValidationDuration]
        public int? Duration { get; set; }

        public int Progress { get; set; }
        [CustomValidationPriority]

        public string Priority { get; set; }

        public int? ParentId { get; set; }
    }

}

```

## Custom validator component

Apart from using default validation and custom validation, there are cases where you might want to use your validator component to validate the tree grid edit form. Such cases can be achieved using the `Validator` property of the `TreeGridEditSettings` component which accepts a validation component and inject it inside the `EditForm` of the tree grid. Inside the `Validator` , you can access the data using the implicit named parameter context which is of type [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html).

For creating a form validator component you can refer [here](https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0#validator-components).

In the below code example, the following things have been done.

* Created a form validator component named `MyCustomValidator` which accepts [ValidatorTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ValidatorTemplateContext.html) value as parameter.
* Used the `MyCustomValidator` component inside the `Validator` property.
* This validator component will check whether Duration value is in between 0 to 30.
* Displayed the validation error messages using `ValidationMessage` component.

{% tabs %}

{% highlight c# %}

using Microsoft. AspNetCore. Components; 
using Microsoft. AspNetCore. Components. Forms; 
using Syncfusion. Blazor. Grids; 

public class MyCustomValidator : ComponentBase
{

    [Parameter]
    public ValidatorTemplateContext context { get; set; }

    private ValidationMessageStore messageStore;

    WeatherForecastService Service = new WeatherForecastService();

    [CascadingParameter]
    private EditContext CurrentEditContext { get; set; }

    protected override void OnInitialized()
    {
        messageStore = new ValidationMessageStore(CurrentEditContext);

        CurrentEditContext.OnValidationRequested += ValidateRequested;
        CurrentEditContext.OnFieldChanged += ValidateField;
    }
    protected void HandleValidation(FieldIdentifier identifier)
    {
        //validate your requirment column
        if (identifier.FieldName.Equals("Duration"))
        {
            messageStore.Clear(identifier);

            if ((context.EditContext.Model as Tree).Duration < 0)
            {
                messageStore.Add(identifier, "Duration value should be greater than 0");
            }
            else if ((context.EditContext.Model as Tree).Duration > 30)
            {
                messageStore.Add(identifier, "Duration value should be less than 30");
            }
            else
            {
                messageStore.Clear(identifier);
            }
        }
        if (identifier.FieldName.Equals("TaskId"))
        {
            messageStore.Clear(identifier);

            if ((context.EditContext.Model as Tree).TaskId <= 0 || (context.EditContext.Model as Tree).TaskId == null)
            {
                messageStore.Add(identifier, "Task ID should not be empty value");
            }
            else
            {
                messageStore.Clear(identifier);
            }
        }
    }
    protected void ValidateField(object editContext, FieldChangedEventArgs fieldChangedEventArgs)
    {
        HandleValidation(fieldChangedEventArgs.FieldIdentifier);
    }
    private void ValidateRequested(object editContext, ValidationRequestedEventArgs validationEventArgs)
    {
        //here call the filed you want to validate
        string[] fields = new string[] { "Duration", "TaskId" };
        foreach (var field in fields)
        {
            HandleValidation(CurrentEditContext.Field(field));
        }
    }

}

{% endhighlight %}

{% endtabs %}

{% tabs %}

{% highlight razor %}

@using TreeGridComponent. Data; 
@using Syncfusion. Blazor. TreeGrid; 
@inject WeatherForecastService ForecastService

<SfTreeGrid @ref="TreeGrid" TValue="Tree" DataSource="GridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="0"

            Toolbar="@(new List<string>() { "Add", "Edit", "Update", "Cancel", "Delete" })">
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"
                          Mode="Syncfusion.Blazor.TreeGrid.EditMode.Dialog">
        <Validator>
            @{
                ValidatorTemplateContext txt = context as ValidatorTemplateContext;
            }
            <MyCustomValidator context="@txt"></MyCustomValidator>
            <ValidationMessage For="@(() => (txt.EditContext.Model as Tree).Duration)"></ValidationMessage>
        </Validator>

    </TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(Tree.TaskId) HeaderText="Task ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(Tree.Priority) HeaderText="Priority" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(Tree.Duration) HeaderText="Duration" TextAlign="TextAlign.Right" Width="120"></TreeGridColumn>
    </TreeGridColumns>

</SfTreeGrid>

@code{

    SfTreeGrid<Tree> TreeGrid { get; set; }
    private List<Tree> GridData;
    protected override void OnInitialized()
    {
        GridData = ForecastService.GetTree();
    }

}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent. Data
{

    public class Tree
    {
        [Required(ErrorMessage = "Task ID  should not be empty")]
        public int? TaskId { get; set; }

        [Required(ErrorMessage = "Task Name  should not be empty")]
        public string TaskName { get; set; }

        public string Priority { get; set; }

        public int? Duration { get; set; }
        public int? ParentId { get; set; }

    }
    public static List<Tree> list = new List<Tree>();
    public List<Tree> GetTree()
    {
        if (list.Count == 0)
        {
            list.Add(new Tree() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, ParentId = null, Priority = "Low" });
            list.Add(new Tree() { TaskId = 2, TaskName = "Child task 1", Duration = 4, ParentId = 1, Priority = "Low" });
            list.Add(new Tree() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, ParentId = 1, Priority = "Critical" });
            list.Add(new Tree() { TaskId = 4, TaskName = "Parent Task 2", Duration = 6, ParentId = null, Priority = "Low" });
            list.Add(new Tree() { TaskId = 5, TaskName = "Child Task 5", Duration = 9, ParentId = 4, Priority = "High" });
        }
        return list;
    }

}

{% endhighlight %}

{% endtabs %}

The output will be as follows.

![Blazor TreeGrid with Custom Validator](../images/blazor-treegrid-custom-validator.png)

## Display validation message using in-built tooltip

In the above code example, you can see that `ValidationMessage` component is used, this might be not suitable when using Inline editing or batch editing. In such cases, you can use the in-built validation tooltip to show those error messages by using `ValidatorTemplateContext.ShowValidationMessage(fieldName, IsValid, Message)` method.

Now, HandleValidation method of the MyCustomValidator component would be changed like below.

{% tabs %}

{% highlight c# %}

protected void HandleValidation(FieldIdentifier identifier)
{

    //validate your requirment column
    if (identifier.FieldName.Equals("Duration"))
    {
        messageStore.Clear(identifier);

        if ((context.EditContext.Model as Tree).Duration < 0)
        {
            messageStore.Add(identifier, "Duration value should be greater than 0");
            context.ShowValidationMessage("Duration", false, "Duration value should be greater than 0");
        }
        else if ((context.EditContext.Model as Tree).Duration > 30)
        {
            messageStore.Add(identifier, "Duration value should be less than 30");
            context.ShowValidationMessage("Duration", false, "Duration value should be less than 30");
        }
        else
        {
            messageStore.Clear(identifier);
            context.ShowValidationMessage("Duration", true, null);
        }
    }

}

{% endhighlight %}

{% endtabs %}

The output will be as follows.

![Blazor TreeGrid with Custom Validator](../images/blazor-treegrid-with-custom-validator.png)

## Disable in-built validator component

`Validator` property can also be used to disable the in-built validator component used by the tree grid. For instance, by default, the tree grid uses two validator components, `DataAnnotationValidator` and an internal [ValidationRules](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_ValidationRules) property, for handling edit form validation. If you are willing to use only the `DataAnnotationValidator` component, then it could be simply achieved by using the `Validator` component inside [TreeGridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridEditSettings.html).

{% tabs %}

{% highlight razor %}

@using TreeGridComponent. Data; 
@using Syncfusion. Blazor. TreeGrid; 

<SfTreeGrid @ref="TreeGrid" TValue="Tree" DataSource="GridData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="0" 
Toolbar="@(new List<string>() { "Add", "Edit", "Update", "Cancel", "Delete" })">
<TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"
                          Mode="Syncfusion. Blazor. TreeGrid. EditMode. Dialog">
        <Validator>
            <DataAnnotationsValidator></DataAnnotationsValidator>
        </Validator>
    </TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(Tree.TaskId) HeaderText="Task ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(Tree.Priority) HeaderText="Priority" Width="120"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(Tree.Duration) HeaderText="Duration" TextAlign="TextAlign.Right" Width="120"></TreeGridColumn>
    </TreeGridColumns>

</SfTreeGrid>

@code{

    SfTreeGrid<Tree> TreeGrid { get; set; }
    private List<Tree> GridData;
    protected override void OnInitialized()
    {
        GridData = ForecastService.GetTree();
    }

}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent. Data
{

    public class Tree
    {
        [Required(ErrorMessage = "Task ID  should not be empty")]
        public int? TaskId { get; set; }

        [Required(ErrorMessage = "Task Name  should not be empty")]
        public string TaskName { get; set; }

        public string Priority { get; set; }

        public int? Duration { get; set; }
        public int? ParentId { get; set; }

    }
    public static List<Tree> list = new List<Tree>();
    public List<Tree> GetTree()
    {
        if (list.Count == 0)
        {
            list.Add(new Tree() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, ParentId = null, Priority = "Low" });
            list.Add(new Tree() { TaskId = 2, TaskName = "Child task 1", Duration = 4, ParentId = 1, Priority = "Low" });
            list.Add(new Tree() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, ParentId = 1, Priority = "Critical" });
            list.Add(new Tree() { TaskId = 4, TaskName = "Parent Task 2", Duration = 6, ParentId = null, Priority = "Low" });
            list.Add(new Tree() { TaskId = 5, TaskName = "Child Task 5", Duration = 9, ParentId = 4, Priority = "High" });
        }
        return list;
    }

}

{% endhighlight %}

{% endtabs %}
