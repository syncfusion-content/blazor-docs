---
layout: post
title: Display string values in Blazor Pivot Table value cells | Syncfusion
description: Learn how to display custom string values in Pivot Table value cells using the CellTemplate with AxisSet.FormattedText in the Syncfusion Blazor Pivot Table component.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Display string values in Blazor Pivot Table value cells

String values can be displayed in value cells by using the [CellTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewTemplates.html#Syncfusion_Blazor_PivotView_PivotViewTemplates_CellTemplate) property of the [PivotViewTemplates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewTemplates.html) class. The template receives an [AxisSet](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.AxisSet.html) context that contains the cell information (for example, Axis, Value, ActualText, and FormattedText). Setting [AxisSet.FormattedText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.AxisSet.html#Syncfusion_Blazor_PivotView_AxisSet_FormattedText) determines the text rendered for that cell without altering the underlying value.

In the following example, each value cell for the **Sold** field is converted to the string format **{hours:D2}:{minutes:D2}:{seconds:D2}** (HH:mm:ss), and the result is assigned to `data.FormattedText` so the cell displays the custom string.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
    <PivotViewTemplates>
        <CellTemplate>
            @{
                var data = context as AxisSet;
                if (data != null)
                {
                    if (data.Axis == "value" && data.ActualText.ToString() == "Sold")
                    {
                        data.FormattedText = SecondsToHms(data.Value);
                        @data.FormattedText
                    }
                    else
                    {
                        @data.FormattedText
                    }
                }
            }
        </CellTemplate>
    </PivotViewTemplates>
    <PivotViewDataSourceSettings DataSource="@dataSource">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code {
    public List<ProductDetails> dataSource { get; set; }
    protected override void OnInitialized()
    {
        this.dataSource = ProductDetails.GetProductData().ToList();
    }
    private string SecondsToHms(Nullable<double> value)
    {
        int hours = (int)Math.Floor((decimal)value / 3600) ;
        int minutes = (int)Math.Floor(((decimal)value % 3600) / 60);
        int seconds = (int)Math.Floor(((decimal)value % 3600) % 60);
        string formattedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        return formattedTime;
    }
}

```

![Display String Value in Blazor PivotTable](images/display-string-value-in-blazor-pivottable.png)