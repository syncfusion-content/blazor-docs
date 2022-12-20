---
layout: post
title: Filtering data in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about filtering data in Syncfusion Blazor Mention component and much more details.  
platform: Blazor
control: Mention
documentation: ug
---

# Filtering data in Blazor Mention Component

The Mention component has built-in support to filter data items. The filter operation starts as soon as you start typing characters in the mention element.

## Limit the minimum filter character

You can control the minimum length of user input to initiate the search action using the `MinLength` property. This can be useful if you have a very large list of data. The default value for `MinLength` is `0`, which means that the suggestion list will open as soon as the user inputs the mention character.

For example, if you set `MinLength` to `3`, the suggestion list will only open when the user has entered at least three characters.

The remote request does not fetch the search data until the search key contains three characters as shown in the following example.

{% highlight razor %}

{% include_relative code-snippet/minimum-filter-char.razor %}

{% endhighlight %}

## Change the filter type

While filtering, you can change the filter type to `Contains`, `StartsWith`, or `EndsWith` by using the `FilterType` property. The default filter operator is `Contains`.

* StartsWith - Filter the items that begin with the specified text value.
* Contains - Filter the items that contain the specified text value.
* EndsWith - Filter the items that end with the specified text value.

{% highlight razor %}

{% include_relative code-snippet/filter-type.razor %}

{% endhighlight %}

## Allow spacing between search

The `AllowSpaces` property is used to control whether spaces are allowed in the middle of the mention or not. If `AllowSpaces` is set to `true`, the Mention component will allow spaces in the middle of the mention and the data source will be filtered accordingly. If `AllowSpaces` is set to `false`, the Mention component will not allow spaces in the middle of the mention and the data source will not be filtered on space key press.

> By default, the `AllowSpaces` property is disabled, and the space ends the mention component search.

{% highlight razor %}

{% include_relative code-snippet/allow-space.razor %}

{% endhighlight %}

![Blazor Mention with allow space between search](./images/blazor-mention-allow-space.png)

## Customize the suggestion item count

While filtering, you can customize the number of list items to be displayed in the suggestion list by using the `SuggestionCount` property. This property can be set to any integer value.

{% highlight razor %}

{% include_relative code-snippet/suggestion-list-count.razor %}

{% endhighlight %}

![Blazor Mention with suggestion item count](./images/blazor-mention-suggestion-list.png)

## See also

* [Templates](./templates)