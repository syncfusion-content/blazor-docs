# Displaying Tooltip for Dynamically Created Elements

The Tooltip component automatically displays tooltips on dynamically created elements without requiring manual refresh. This enhancement eliminates extra coding effort and enhances dynamic content interactivity.

## Overview

Dynamic target support allows tooltips to automatically work with elements that are added to the DOM after the initial page load. This is particularly useful in scenarios where content is generated based on user interactions, API responses, or conditional rendering.

## Using TargetContainer Property

Use the `TargetContainer` property to specify a container where target elements will automatically have tooltips applied. This approach provides better control over which elements should have tooltip functionality.

### Basic Example

```razor
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfTooltip ID="BasicTooltip" Target="[title]" TargetContainer=".tooltip-container">
    <div class="tooltip-container">
        <span title="Static tooltip">Static Element</span>
        <SfButton @onclick="AddElement">Add Dynamic Element</SfButton>
        
        @if (ShowElement)
        {
            <span title="Dynamic tooltip">Dynamic Element</span>
        }
    </div>
</SfTooltip>

@code {
    private bool ShowElement = false;
    
    private void AddElement()
    {
        ShowElement = true;
    }
}
```
The TargetContainer property enables automatic tooltip registration for newly added elements, enhancing dynamic content interactivity.

![Blazor Tooltip with Dynamic Targets](images/dynamic-target.gif)