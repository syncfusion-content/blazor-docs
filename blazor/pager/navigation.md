---
layout: post
title: Navigation in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about available methods in Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Navigation in Pager Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component provides built-in methods for programmatically controlling navigation and updating pager settings. These methods allow external actions such as navigating to specific pages, moving to the first or last page, updating page size, and refreshing the component. Each method can be invoked asynchronously to ensure smooth interaction within Blazor applications.

## Navigate to a Specific Page

The [GoToPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_GoToPageAsync_System_Int32_) method navigates to the specified page number.

| Parameter  | Type | Description                     |
|------------|------|---------------------------------|
| pageNo  | int  | Indicates the page number to navigate.|


```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="NavigateToPage">Go to Page 5</SfButton>

@code
{
    private SfPager? pager;

    private async Task NavigateToPage()
    {
        await pager?.GoToPageAsync(5);
    }
}
```

## Navigate to the Last Page

The [GoToLastPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_GoToLastPageAsync) method navigates to the last page of the Pager component.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="NavigateToLastPage">Go to Last Page</SfButton>

@code
{

    private SfPager? pager;

    private async Task NavigateToLastPage()
    {
        await pager?.GoToLastPageAsync();
    }
}
```

## Navigate to the First Page

The [GoToFirstPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_GoToFirstPageAsync) method navigates to the first page of the Pager component.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="NavigateToFirstPage">Go to First Page</SfButton>

@code
{

    private SfPager? pager;

    private async Task NavigateToFirstPage()
    {
        await pager?.GoToFirstPageAsync();
    }
}
```

## Navigate to the Next Page

The [GoToNextPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_GoToNextPageAsync) method navigates to the next page of the Pager component.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="NavigateToNextPage">Go to Next Page</SfButton>

@code
{
    private SfPager? pager;

    private async Task NavigateToNextPage()
    {
        await pager?.GoToNextPageAsync();
    }
}
```

## Navigate to the Previous Page

The [GoToPreviousPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_GoToPreviousPageAsync) method navigates to the previous page of the Pager component.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="NavigateToPreviousPage">Go to Previous Page</SfButton>

@code
{
    private SfPager? pager;

    private async Task NavigateToPreviousPage()
    {
        await pager?.GoToPreviousPageAsync();
    }
}
```

## Update Page Size

The [UpdatePageSizeAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_UpdatePageSizeAsync_System_Int32_) method updates the page size of the Pager component.

| Parameter | Type | Description                  |
|-----------|------|------------------------------|
| pageSize  | int  | The number of items to be shown on a page. |

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="UpdatePageSize">Set Page Size to 20</SfButton>

@code
{
    private SfPager? pager;

    private async Task UpdatePageSize()
    {
        await pager?.UpdatePageSizeAsync(20);
    }
}
```

## Update Numeric Items Count

The [UpdateNumericItemsCountAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_UpdateNumericItemsCountAsync_System_Int32_) method updates the numeric item count displayed in the Pager.

| Parameter        | Type | Description                                |
|-------------------|------|--------------------------------------------|
| numericItemsCount | int  | The number of numeric items to display.   |

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="UpdateNumericItemsCount">Set Numeric Items to 5</SfButton>

@code
{
    private SfPager? pager;

    private async Task UpdateNumericItemsCount()
    {
        await pager?.UpdateNumericItemsCountAsync(5);
    }
}
```

## Refresh Pager

The [RefreshAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_RefreshAsync) method applies all property changes and re-renders the Pager component.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfPager @ref="pager" PageSize="10" TotalItemsCount="100"></SfPager>
<SfButton @onclick="RefreshPager">Refresh Pager</SfButton>

@code
{
    private SfPager? pager;

    private async Task RefreshPager()
    {
        await pager?.RefreshAsync();
    }
}
```