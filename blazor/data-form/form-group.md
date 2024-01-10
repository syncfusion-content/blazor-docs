---
layout: post
title: Form Groups in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about the single and multiple form group configuration  with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Form Group Configuration

In DataForm , [FormGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html) feature provides a way to organize the `FormItem` and `FormAutoGenerateItems` with descriptive label text and a layout organized into columns.The below example showcases how to configure `FormGroup` within  DataForm component

{% tabs %}
{% highlight razor tabtitle="Form group" %}

@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Model="@EmployeeDetailsModel">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormGroup LabelText="Employee Information" >
            <FormItem Field="@nameof(EmployeeDetailsModel.EmployeeId)" LabelText="Employee Id" />
            <FormItem Field="@nameof(EmployeeDetailsModel.FirstName)"  LabelText="First Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.LastName)"  LabelText="Last Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.Designation)"  LabelText="Designation" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ReportingPerson)" LabelText="Reporting Person" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ManagerName)"  LabelText="Manager Name" />
        </FormGroup>
    </FormItems>

    <FormButtons>
        <SfButton>Update</SfButton>
    </FormButtons>

</SfDataForm>

@code {

    private EmployeeDetails EmployeeDetailsModel = new EmployeeDetails()
        {
            EmployeeId = 1001,
            FirstName = "Anne",
            LastName = "Dodsworth",
            Department = "Web",
            Designation = "Developer",
            ReportingPerson = "Andrew Fuller",
            ManagerName = "Nancy Davolio"
        };

    
    public class EmployeeDetails
    {
        [Editable(false)]
        [Display(Name = "Please enter the employee ID")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter the first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter the department.")]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Editable(false)]
        public string ReportingPerson { get; set; }
        [Editable(false)]
        public string ManagerName { get; set; }
        [Editable(false)]
        public string Designation { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Group](images/blazor_dataform_single_formgroup.png)

## Multiple Form groups

DataForm allows you to integrate multiple form groups with number of `FormItem` inside it .

{% tabs %}
{% highlight razor tabtitle="Multiple Form Group" %}

@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Model="@EmployeeDetailsModel"
            ColumnCount=2
            ColumnSpacing="20px"
            ButtonsAlignment="FormButtonsAlignment.Right" OnValidSubmit="ValidSubmitHandler">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormGroup LabelText="Employee Information">
            <FormItem Field="@nameof(EmployeeDetailsModel.EmployeeId)" LabelText="Employee Id" />
            <FormItem Field="@nameof(EmployeeDetailsModel.FirstName)" LabelText="First Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.LastName)" LabelText="Last Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.Designation)" LabelText="Designation" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ReportingPerson)" LabelText="Reporting Person" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ManagerName)" LabelText="Manager Name" />
        </FormGroup>
        <FormGroup LabelText="Personal Data">
            <FormItem Field="@nameof(EmployeeDetailsModel.DateOfBirth)" EditorType="FormEditorType.DatePicker" LabelText="Date of birth" />
            <FormItem Field="@nameof(EmployeeDetailsModel.PersonalMailId)" LabelText="Personal Mail" Placeholder="someone@example.com" />
            <FormItem Field="@nameof(EmployeeDetailsModel.BloodGroup)" LabelText="Blood group" Placeholder="Enter blood group" />
            <FormItem Field="@nameof(EmployeeDetailsModel.Country)" LabelText="Country" EditorType="FormEditorType.AutoComplete" />
            <FormItem Field="@nameof(EmployeeDetailsModel.AddressLine)" EditorType="FormEditorType.TextArea" LabelText="Address Line" />
        </FormGroup>
    </FormItems>
    <FormButtons>
        <SfButton>Update</SfButton>
    </FormButtons>
</SfDataForm>


@code {

    public string SuccessMessage { get; set; }
    public async Task ValidSubmitHandler()
    {
        SuccessMessage = "Data updated Successfully!";
        await Task.Delay(2000);
        SuccessMessage = string.Empty;
        StateHasChanged();
    }
    private EmployeeDetails EmployeeDetailsModel = new EmployeeDetails()
        {
            EmployeeId = 1001,
            FirstName = "Anne",
            LastName = "Dodsworth",
            Department = "Web",
            Designation = "Developer",
            ReportingPerson = "Andrew Fuller",
            ManagerName = "Nancy Davolio",
            DateOfBirth = new DateTime(2000, 10, 10),
            AddressLine = @"2501, Aerial Center Parkway, Suite 111, Morrisville",
            Country = Country.Australia
        };

    public enum Country
    {
        Australia,
        Bermuda,
        Finland,
        France,
        Denmark,
        Cameroon,
        Canada
    }
    public class EmployeeDetails
    {
        [Editable(false)]
        [Display(Name = "Please enter the employee ID")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter the first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter the department.")]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Editable(false)]
        public string ReportingPerson { get; set; }
        [Editable(false)]
        public string ManagerName { get; set; }
        [Editable(false)]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter the date of birth.")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter your personal mail address.")]
        public string PersonalMailId { get; set; }
        [Required(ErrorMessage = "Please enter your address line.")]
        public string AddressLine { get; set; }
        [Required(ErrorMessage = "Please enter your blood group.")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Please choose the country.")]
        public Country Country { get; set; }
    }
}


{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Group](images/blazor_dataform_multiple_formgroup.png)

## Form groups with column layout

This section explains how to configure the DataForm component on dividing the collection of [FormGroups](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html) and organizing the subdivisions within the `FormGroup`.

{% tabs %}
{% highlight razor tabtitle="Model" %}

@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Model="@EmployeeDetailsModel"
            ColumnCount=2
            ColumnSpacing="20px">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormGroup ColumnCount="6" LabelText="Employee Information" ColumnSpacing="10px">
            <FormItem Field="@nameof(EmployeeDetailsModel.EmployeeId)" ColumnSpan="6" LabelText="Employee Id" />
            <FormItem Field="@nameof(EmployeeDetailsModel.FirstName)" ColumnSpan="3" LabelText="First Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.LastName)" ColumnSpan="3" LabelText="Last Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.Designation)" ColumnSpan="2" LabelText="Designation" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ReportingPerson)" ColumnSpan="2" LabelText="Reporting Person" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ManagerName)" ColumnSpan="2" LabelText="Manager Name" />
        </FormGroup>

        <FormGroup LabelText="Personal Data" ColumnCount="2" ColumnSpacing="10px">
            <FormItem Field="@nameof(EmployeeDetailsModel.DateOfBirth)" ColumnSpan="1" EditorType="FormEditorType.DatePicker" LabelText="Date of birth" />
            <FormItem Field="@nameof(EmployeeDetailsModel.BloodGroup)" ColumnSpan="1" LabelText="Blood group" Placeholder="Enter blood group" />
            <FormItem Field="@nameof(EmployeeDetailsModel.PersonalMailId)" ColumnSpan="2" LabelText="Personal Mail" Placeholder="someone@example.com" />
            <FormItem Field="@nameof(EmployeeDetailsModel.Country)" ColumnSpan="2" LabelText="Country" EditorType="FormEditorType.AutoComplete" />
            <FormItem Field="@nameof(EmployeeDetailsModel.AddressLine)" ColumnSpan="2" EditorType="FormEditorType.TextArea" LabelText="Address Line" />
        </FormGroup>

    </FormItems>

    <FormButtons>
        <SfButton>Update</SfButton>
    </FormButtons>

</SfDataForm>

@code {

    private EmployeeDetails EmployeeDetailsModel = new EmployeeDetails()
        {
            EmployeeId = 1001,
            FirstName = "Anne",
            LastName = "Dodsworth",
            Department = "Web",
            Designation = "Developer",
            ReportingPerson = "Andrew Fuller",
            ManagerName = "Nancy Davolio",
            DateOfBirth = new DateTime(2000, 10, 10),
            AddressLine = @"2501, Aerial Center Parkway, Suite 111, Morrisville",
            Country = Country.UnitedStates
        };

    public enum Country
    {
        UnitedStates,
        Bermuda,
        Australia,
        Finland,
        France,
        Denmark,
        Cameroon,
        Canada
    }
    public class EmployeeDetails
    {
        [Editable(false)]
        [Display(Name = "Please enter the employee ID")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter the first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter the department.")]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Editable(false)]
        public string ReportingPerson { get; set; }
        [Editable(false)]
        public string ManagerName { get; set; }
        [Editable(false)]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter the date of birth.")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter your personal mail address.")]
        public string PersonalMailId { get; set; }
        [Required(ErrorMessage = "Please enter your address line.")]
        public string AddressLine { get; set; }
        [Required(ErrorMessage = "Please enter your blood group.")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Please choose the country.")]
        public Country Country { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

In the provided example, the DataForm is divided into two sections, with each section populating its respective `FormGroup`. The first group is further segmented into six subsections, with the elements within it distributed according to their assigned column span. In a similar manner, the second group is split into two columns, with its elements being divided accordingly.

![Blazor DataForm Form Group Column Layout](images/blazor_dataform_formgroup_column_layout.png)

## Change the appearance of the form group

You can customize the appearance of the form group by using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html#Syncfusion_Blazor_DataForm_FormGroup_CssClass) property `FormGroup` component. The following example demonstrates how to change the background color and set padding of the form group wrapper .

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

@using Syncfusion.Blazor.DataForm
@using Syncfusion.Blazor.Buttons
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Model="@EmployeeDetailsModel"
            ColumnCount=2
            ColumnSpacing="20px">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormGroup ColumnCount="6" LabelText="Employee Information" CssClass="employee-info" ColumnSpacing="10px">
            <FormItem Field="@nameof(EmployeeDetailsModel.EmployeeId)" ColumnSpan="6" LabelText="Employee Id" />
            <FormItem Field="@nameof(EmployeeDetailsModel.FirstName)" ColumnSpan="3" LabelText="First Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.LastName)" ColumnSpan="3" LabelText="Last Name" />
            <FormItem Field="@nameof(EmployeeDetailsModel.Designation)" ColumnSpan="2" LabelText="Designation" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ReportingPerson)" ColumnSpan="2" LabelText="Reporting Person" />
            <FormItem Field="@nameof(EmployeeDetailsModel.ManagerName)" ColumnSpan="2" LabelText="Manager Name" />
        </FormGroup>

        <FormGroup LabelText="Personal Data" ColumnCount="2" CssClass="personal-data" ColumnSpacing="10px">
            <FormItem Field="@nameof(EmployeeDetailsModel.DateOfBirth)" ColumnSpan="1" EditorType="FormEditorType.DatePicker" LabelText="Date of birth" />
            <FormItem Field="@nameof(EmployeeDetailsModel.BloodGroup)" ColumnSpan="1" LabelText="Blood group" Placeholder="Enter blood group" />
            <FormItem Field="@nameof(EmployeeDetailsModel.PersonalMailId)" ColumnSpan="2" LabelText="Personal Mail" Placeholder="someone@example.com" />
            <FormItem Field="@nameof(EmployeeDetailsModel.Country)" ColumnSpan="2" LabelText="Country" EditorType="FormEditorType.AutoComplete" />
            <FormItem Field="@nameof(EmployeeDetailsModel.AddressLine)" ColumnSpan="2" EditorType="FormEditorType.TextArea" LabelText="Address Line" />
        </FormGroup>

    </FormItems>

    <FormButtons>
        <SfButton>Update</SfButton>
    </FormButtons>

</SfDataForm>

<style>
    .e-data-form{
        background-color: #f0f0f0;
        padding: 10px;
    }

    .employee-info.e-form-group {
        background-color: #e6f7ff; 
        padding: 10px;
    }

    .personal-data.e-form-group {
        background-color: #e6fffb;
        padding: 10px;
    }
</style>

@code {
    private EmployeeDetails EmployeeDetailsModel = new EmployeeDetails()
        {
            EmployeeId = 1001,
            FirstName = "Anne",
            LastName = "Dodsworth",
            Department = "Web",
            Designation = "Developer",
            ReportingPerson = "Andrew Fuller",
            ManagerName = "Nancy Davolio",
            DateOfBirth = new DateTime(2000, 10, 10),
            AddressLine = @"2501, Aerial Center Parkway, Suite 111, Morrisville",
            Country = Country.UnitedStates
        };
}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}
public enum Country
{
    UnitedStates,
    Bermuda,
    Australia,
    Finland,
    France,
    Denmark,
    Cameroon,
    Canada
}

public class EmployeeDetails
{
    [Editable(false)]
    [Display(Name = "Please enter the employee ID")]
    public int EmployeeId { get; set; }
    [Required(ErrorMessage = "Please enter the first name.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Please enter the last name.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Please enter the department.")]
    [Display(Name = "Department")]
    public string Department { get; set; }
    [Editable(false)]
    public string ReportingPerson { get; set; }
    [Editable(false)]
    public string ManagerName { get; set; }
    [Editable(false)]
    public string Designation { get; set; }
    [Required(ErrorMessage = "Please enter the date of birth.")]
    [Display(Name = "Date Of Birth")]
    public DateTime? DateOfBirth { get; set; }
    [Required(ErrorMessage = "Please enter your personal mail address.")]
    public string PersonalMailId { get; set; }
    [Required(ErrorMessage = "Please enter your address line.")]
    public string AddressLine { get; set; }
    [Required(ErrorMessage = "Please enter your blood group.")]
    public string BloodGroup { get; set; }
    [Required(ErrorMessage = "Please choose the country.")]
    public Country Country { get; set; }
}
{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Group Customization](images/blazor_dataform_formgroup_customization.png)

