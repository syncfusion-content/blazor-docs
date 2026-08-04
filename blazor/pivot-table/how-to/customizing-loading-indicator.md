---
layout: post
title: How to customize the loading indicator in Blazor Pivot Table | Syncfusion
description: Step-by-step example showing how to customize the loading indicator in the Blazor Pivot Table by replacing the default spinner with a custom SpinnerTemplate.
platform: Blazor
control: Pivot Table
documentation: ug
---

# How to customize the loading indicator in Blazor Pivot Table

The pivot table displays a loading indicator during data processing operations such as filtering, sorting, and aggregation calculations. The default loading spinner can be customized to match application design requirements using the [SpinnerTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_SpinnerTemplate) property.

The [SpinnerTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_SpinnerTemplate) property accepts an HTML string that defines the custom loading indicator appearance. This enables control over the visual presentation, including custom styling and animations.

N> You can also disable the loading indicator by setting [SpinnerTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_SpinnerTemplate) to empty string.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
	<PivotViewDataSourceSettings DataSource="@data">
		<PivotViewTemplates>
			<SpinnerTemplate>
				@{
					<i class='fa fa-cog fa-spin fa-3x fa-fw'></i>
				}
			</SpinnerTemplate>
		</PivotViewTemplates>
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
			<PivotViewFormatSetting Name="Sold" Format="N"></PivotViewFormatSetting>
			<PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
		</PivotViewFormatSettings>
	</PivotViewDataSourceSettings>
</SfPivotView>
@code {
	public List<ProductDetails> data { get; set; }
	protected override void OnInitialized()
	{
		this.data = ProductDetails.GetProductData().ToList();
		//Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
	}
}

```

N> You can refer to [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=fluent2) to know how to render and configure the pivot table.