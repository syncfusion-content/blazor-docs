---
layout: post
title: Timezone-Aware Date Highlighting in DateTimePicker | Syncfusion®
description: Learn how to highlight the current date based on the client timezone in Blazor DateTimePicker components using the TimeZoneOffset property.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Timezone-Aware Date Highlighting in Blazor DateTimePicker

By default, Blazor DateTimePicker components use the server's local time to determine and highlight the current date ("Today") in the popup calendar. In Blazor Server applications, the server and client may be located in different time zones, which can cause the incorrect date to be highlighted.

To address this scenario, DateTimePicker components provide the `TimeZoneOffset` property. When this property is specified, the component calculates the current date using Coordinated Universal Time (UTC) and the provided timezone offset. This ensures that the highlighted date reflects the client's local date rather than the server date.

## TimeZoneOffset property

| Property | Type | Default Value |
|----------|------|--------------|
| TimeZoneOffset | TimeSpan? | null |

When a value is provided, the component calculates the current date using:

```csharp
DateTime.UtcNow + TimeZoneOffset
```

If the property is not specified, the component continues to use the existing behavior:

```csharp
DateTime.Now
```

This behavior preserves backward compatibility for existing applications.

## Configure timezone-aware date highlighting

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?"
                  TimeZoneOffset="@ClientOffset">
</SfDateTimePicker>

@code {
    private TimeSpan ClientOffset = new TimeSpan(5, 30, 0);
}
```

## Use negative timezone offsets

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?"
                  TimeZoneOffset="@ClientOffset">
</SfDateTimePicker>

@code {
    private TimeSpan ClientOffset = TimeSpan.FromHours(-5);
}
```

## Use fractional timezone offsets

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?"
                  TimeZoneOffset="@ClientOffset">
</SfDateTimePicker>

@code {
    private TimeSpan ClientOffset = new TimeSpan(9, 30, 0);
}
```

## Today button behavior

When the `TimeZoneOffset` property is configured, the Today button uses the timezone-adjusted current date.

- Navigates to the timezone-adjusted current date.
- Selects the timezone-adjusted current date.
- Maintains consistency between the selected and highlighted date.

## Timezone calculation examples

| UTC Time | TimeZoneOffset | Highlighted Date |
|----------|----------------|------------------|
| Aug 10 23:30 UTC | +05:30 | Aug 11 |
| Aug 10 23:30 UTC | +09:00 | Aug 11 |
| Aug 10 23:30 UTC | -05:00 | Aug 10 |
| Aug 10 23:30 UTC | -08:00 | Aug 10 |

## Fallback behavior

When the property is not specified or set to `null`:

- Existing applications continue to function without modifications.
- Date calculation uses the server's local time.
- Current highlighting behavior remains unchanged.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?">
</SfDateTimePicker>
```

## Key features

- Supports positive timezone offsets.
- Supports negative timezone offsets.
- Supports fractional timezone offsets.
- Preserves backward compatibility.
- Ensures accurate Today highlighting across regions.
- Provides consistent Today button behavior.
