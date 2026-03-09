---
layout: post
title: Serialization | Blazor ChartWizard Component | Syncfusion
description: Checkout and learn here all about Serialization in Syncfusion Blazor ChartWizard component and much more.
platform: Blazor
control: ChartWizard
documentation: ug
---

## Serialization

`SfChartWizard` exposes two convenient APIs to persist and restore the entire chart configuration:

- `SaveChart()` - synchronously serializes the current chart state (settings, series, axes, titles, styles, etc.) to a JSON string.
- `LoadChartAsync(string data)` - asynchronously loads chart configuration from a JSON string produced by `SaveChart()` and applies it to the wizard instance.

Both methods let you implement user workflows such as "Save template", "Load template", or "Export chart configuration" for sharing and reloading charts later.

N>
- The serialized JSON contains the full runtime state of the chart area and settings. Use this string to persist configuration to a database, file, or browser storage.
- `LoadChartAsync` resets the chart settings to defaults and then applies values from the JSON.
- `SaveChart()` returns a plain JSON string; `LoadChartAsync` expects the same shape produced by `SaveChart()`.

### Example — Save chart

```

@using Syncfusion.Blazor.ChartWizard

<SfChartWizard @ref="chartWizardRef" Width="100%">
	<ChartSettings ... />
</SfChartWizard>

<button @onclick="Save">Save Chart</button>

@code {
	private SfChartWizard chartWizardRef;

	private void Save()
	{
		if (chartWizardRef == null)
			return;

		string json = chartWizardRef.SaveChart();
	}
}
```

### Example — Load chart from JSON

```

@using Syncfusion.Blazor.ChartWizard

<SfChartWizard @ref="chartWizardRef" Width="100%">
	<ChartSettings ... />
</SfChartWizard>

<button @onclick="Load">Load Chart</button>

@code {
	private SfChartWizard chartWizardRef;
	private string jsonInput;

	private async Task Load()
	{
		if (chartWizardRef == null || string.IsNullOrWhiteSpace(jsonInput))
			return;

		try
		{
            // jsonInput - JSON string produced by SaveChart()
			await chartWizardRef.LoadChartAsync(jsonInput);
		}
		catch (Exception ex)
		{
			// Handle invalid JSON or deserialization errors
			Console.Error.WriteLine($"Failed to load chart: {ex.Message}");
		}
	}
}

```

## See also

- Explore the [Chart Wizard Demo]() for interactive samples.
