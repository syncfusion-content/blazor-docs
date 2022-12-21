---
layout: post
title: Filtering data in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about filtering data in Syncfusion Blazor Mention component and much more details.  
platform: Blazor
control: Mention
documentation: ug
---

# Filtering data in Blazor Mention Component

The Mention component has built-in support for filtering data items, which allows you to easily narrow down the list of mention suggestions based on user input. The filter operation begins as soon as the user starts typing characters in the Mention element, and it is designed to quickly and efficiently search through the available data items to find matches based on the entered characters.

## Limit the minimum filter character

You can control the minimum length of user input to initiate the search action using the `MinLength` property. This can be useful if you have a very large list of data. The default value for `MinLength` is `0`, which means that the suggestion list will open as soon as the user inputs the mention character.

For example, if you set `MinLength` to `3`, the suggestion list will only open when the user has entered at least three characters.

The remote request does not fetch the search data until the search key contains three characters as shown in the following example.

{% highlight razor %}

{% include_relative code-snippet/minimum-filter-char.razor %}

{% endhighlight %}

## Change the filter type

The `FilterType` property allows you to specify the type of filter to use when filtering data items. The Mention supports three different filter types: `Contains`, `StartsWith`, and `EndsWith`.

* `StartsWith` - This filter type searches for items that start with the entered characters.
* `Contains` - This filter type searches for items that contain the entered characters as a substring.
* `EndsWith` - This filter type searches for items that end with the entered characters.

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

The `SuggestionCount` property allows you to specify the number of list items that should be displayed in the suggestion list. This property can be set to any integer value.

{% highlight razor %}

{% include_relative code-snippet/suggestion-list-count.razor %}

{% endhighlight %}

![Blazor Mention with suggestion item count](./images/blazor-mention-suggestion-list.png)

## See also

* [Templates](./templates)