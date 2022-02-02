---
layout: post
title: Create a custom component using Blazor TextBox | Syncfusion
description: Learn here all about using Blazor TextBox component to create a custom component with tooltip validation.
platform: Blazor
control: TextBox
documentation: ug
---

# Create a Custom Component with Tooltip Validation Using Blazor TextBox

Custom component allows to reuse the defined components in a razor page anywhere in the application by using the file name of the razor page as HTML tag. For more information please refer [here](https://www.syncfusion.com/faq/blazor/components/how-do-i-create-a-custom-component)

## Defining Blazor TextBox component

The TextBox component is defined in the razor page along with the required properties and event binding. Refer to the following code.

```cshtml

    @using System.Linq.Expressions;
    @using Syncfusion.Blazor.Inputs

    <SfTextBox Value="@Value" FloatLabelType="FloatLabelType.Never" HtmlAttributes="@(new Dictionary<string, object> { { "maxlength", MaxLength }, {"minlength", MinLength}, {"rows", Multiline ? 3 : 1} })"
            ID="@ID" Multiline="@Multiline" ValueChanged="ValueChanged"  ValueExpression="@ValueExpression" Placeholder="@Placeholder" Readonly="@Readonly" @ref="Box" ValidateOnInput="true" Width="200px">
        <ValidationMessage For="@ValidationMessage">
        </ValidationMessage>
    </SfTextBox>

```

T> In the above code, the properties and events are added to the razor page, and the definition for the respective properties can be done on the same page using the `@code` block or on a partial class page. Refer to the following code.

```cs

    private string _value;

    [Parameter]
    public string Value
    {
        get => _value;
        set
        {
            if (!EqualityComparer<string>.Default.Equals(value, _value))
            {
                _value = value;
                ValueChanged.InvokeAsync(value);
            }
        }
    }

    [Parameter]
    public Expression<Func<string>> ValueExpression { get; set; }


    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }

    private SfTextBox Box { get; set; }

    private FieldIdentifier Field { get; set; }

    [CascadingParameter]
    public EditContext EditContext { get; set; } = default!;

    [Parameter]
    public string ID { get; set; }

    [Parameter]
    public int MaxLength { get; set; }

    [Parameter]
    public int MinLength { get; set; }

    [Parameter]
    public bool Multiline { get; set; }

    [Parameter]
    public string Placeholder { get; set; }

    [Parameter]
    public bool Readonly { get; set; }

    [Parameter]
    public Expression<Func<string>> ValidationMessage { get; set; }

    protected override void OnInitialized()
    {
        Field = EditContext.Field("Text");
        EditContext.OnValidationStateChanged += HandleValidationStateChanged;
    }

    private void HandleValidationStateChanged(object sender, ValidationStateChangedEventArgs e)
    {
        StateHasChanged();
        bool _invalid = EditContext.GetValidationMessages(Field).Any();
        Box?.UpdateParentClass("", "");
        StateHasChanged();
    }

```
> It is necessary to bind `Value`, `ValueExpression`, and native `ValueChanged` event for accessing the value changes and triggering validation. To retrieve the validation message from the custom component, it is required to add the `ValidationMessage` tag in the textbox component.

I> The above code snippets are added in a razor file with name as CustomTextBox

## Adding the custom TextBox component in the EditForm

The EditForm with the bound model is declared on the main razor page. Inside the EditForm, the `DataAnnotationsValidator` and `CustomTextBox` with wrapped `SfTooltip` component are added. The DataAnnotationsValidator is added to enable form validation based on validation attributes declared in the model. The CustomTextBox component is then bound with the "Text" property from the model and the "Text" property contains DataAnnotations attributes used for validation. 

```cshtml

    @using System.ComponentModel.DataAnnotations;
    @using Syncfusion.Blazor.Popups

    <EditForm Model="@_Records" OnValidSubmit="HandleSubmit">
        <DataAnnotationsValidator />
        <SfTooltip CloseDelay="0" OnOpen="ToolTipOpen" OpenDelay="0" OpensOn="Hover" Position="Position.TopCenter" Target="#text" WindowCollision="true">
            <CustomTextBox @bind-Value="@(_Records.Text)" ID="text" MaxLength="50" MinLength="1" Multiline="false" Placeholder="Enter a text" Readonly="false"
                                        ValidationMessage="@(() => _Records.Text)" @bind-Value:event="ValueChanged"></CustomTextBox>
            <TooltipTemplates>
                <Content>
                    <ValidationMessage For="@(() => _Records.Text)"></ValidationMessage>
                </Content>
            </TooltipTemplates>
        </SfTooltip>
        <button>Submit</button>
    </EditForm>

    @code {
        private ModalData _Records = new();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private static void ToolTipOpen(TooltipEventArgs args)
        {
            args.Cancel = !args.HasText;
        }

        private void HandleSubmit()
        {

        }

        public class ModalData
        {
            [Required(ErrorMessage = "This field is required."),
            StringLength(100, MinimumLength = 2, ErrorMessage = "Length should be between 2 and 100 characters.")]
            public string Text { get; set; }
        }

    }

```

The SfTooltip component is wrapped around the CustomTextBox and the `Target` property is set to the ID attribute of the CustomTextBox to display tooltip for that particular component. The `ValidationMessage` tag is placed inside the `TooltipTemplates` to display the validation error messages inside the tooltip. 

T> To avoid empty tooltips, tooltips can be restricted based on the presence of text content in the `OnOpen` event callback.