---
layout: post
title: API consistency guide for Syncfusion Blazor components
description: Learn the consistency rules used across Syncfusion Blazor component APIs.
platform: Blazor
control: Common
documentation: ug
---

# API consistency guide for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components

This guide outlines the naming, behavior, and configuration patterns used across Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component APIs. Following these conventions helps keep component APIs predictable and easier to learn.

## Property naming

Use clear and descriptive property names that reflect the intent of the API.

- Use PascalCase for public properties, methods, and events.
- Prefer nouns or noun phrases for state properties.
- Use boolean property names that read naturally, such as `AllowFiltering`, `EnableRtl`, and `IsPrimary`.
- Avoid abbreviations unless they are widely recognized in the product or platform.

## Event naming

Events should describe what happened, not what should happen.

- Use the `On` prefix only when it matches the existing component pattern.
- Prefer names that indicate a completed action, such as `Created`, `Changed`, `Closed`, or `Selected`.
- Keep event argument types consistent across related components.

## Parameter defaults

Default values should follow the principle of least surprise.

- Use `false` for optional enabling behavior unless the feature is expected to be active by default.
- Choose defaults that preserve existing behavior for current users.
- Avoid changing a default value unless the change is required for consistency or correctness.

## Value types and nullability

Use the most specific type that fits the API surface.

- Use nullable types when a parameter is optional or can be unset.
- Use enums for closed sets of values instead of free-form strings.
- Keep related APIs aligned so similar features accept the same type across components.

## Collection APIs

Collection-based APIs should be easy to read and consistent to configure.

- Prefer `IEnumerable<T>` or `List<T>` when the caller provides multiple values.
- Use child content or nested tags when the API needs structured configuration.
- Keep collection item names consistent across components when they represent similar concepts.

## Async behavior

Use asynchronous APIs where the underlying operation is asynchronous.

- Use the `Async` suffix for methods that return `Task` or `Task<T>` and perform asynchronous work.
- Keep synchronous and asynchronous method pairs aligned in naming and behavior.
- Do not introduce unnecessary async methods when no asynchronous work is involved.

## Breaking changes

When an API change is required, prefer the least disruptive option.

- Add new APIs instead of renaming existing ones when possible.
- Preserve backward compatibility for established component behaviors.
- Document breaking changes clearly when they cannot be avoided.

## Component-level consistency checks

Before finalizing an API change, review the following items:

1. Does the new API match the naming pattern used by similar components?
2. Does the default value align with the current user experience?
3. Are the parameter and event types consistent with related controls?
4. Is the behavior predictable when the value is omitted or left empty?
5. Is the documentation example aligned with the final API shape?

## Examples

### Boolean API

```razor
<SfButton IsPrimary="true">Primary</SfButton>
```

### Enum-based API

```razor
<SfTextBox FloatLabelType="FloatLabelType.Auto"></SfTextBox>
```

### Collection-based API

```razor
<SfDropDownList DataSource="Countries">
    <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
</SfDropDownList>
```

## Summary

Keep Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor APIs consistent in naming, defaults, types, and behavior so developers can move between components without relearning patterns.