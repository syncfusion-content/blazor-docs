---
layout: post
title: Style and Appearance in Blazor TreeMap Component | Syncfusion
description: Checkout and learn here all about Style and Appearance in Syncfusion Blazor TreeMap component and much more.
platform: Blazor
control: TreeMap
documentation: ug
---

# Style and Appearance in Blazor TreeMap Component

The Style and Appearance feature allows you to customize the visual design of the **Syncfusion Blazor TreeMap** control to match your application's branding, theme, and user experience requirements. By leveraging CSS selectors and ID-based styling, you can modify colors, typography, spacing, borders, and other visual properties of individual tree map items, text labels, and various TreeMap elements.

## Basic TreeMap Setup

```cshtml
@using Syncfusion.Blazor.TreeMap

<SfTreeMap DataSource="GrowthReports" TValue="GDPReport" WeightValuePath="GDP">
    <TreeMapLeafItemSettings LabelPath="CountryName">
        <TreeMapLeafLabelStyle Color="#000000"></TreeMapLeafLabelStyle>
        <TreeMapLeafBorder Color="#000000" Width="0.5"></TreeMapLeafBorder>
    </TreeMapLeafItemSettings>
</SfTreeMap>

@code{
    public class GDPReport
    {
        public string CountryName { get; set; }
        public double GDP { get; set; }
        public double Percentage { get; set; }
        public int Rank { get; set; }
    };
    public List<GDPReport> GrowthReports = new List<GDPReport> {
            new GDPReport {CountryName="United States", GDP=17946, Percentage=11.08, Rank=1},
            new GDPReport {CountryName="China", GDP=10866, Percentage= 28.42, Rank=2},
            new GDPReport {CountryName="Japan", GDP=4123, Percentage=-30.78, Rank=3},
            new GDPReport {CountryName="Germany", GDP=3355, Percentage=-5.19, Rank=4},
            new GDPReport {CountryName="United Kingdom", GDP=2848, Percentage=8.28, Rank=5},
            new GDPReport {CountryName="France", GDP=2421, Percentage=-9.69, Rank=6},
            new GDPReport {CountryName="India", GDP=2073, Percentage=13.65, Rank=7},
            new GDPReport {CountryName="Italy", GDP=1814, Percentage=-12.45, Rank=8},
            new GDPReport {CountryName="Brazil", GDP=1774, Percentage=-27.88, Rank=9},
            new GDPReport {CountryName="Canada", GDP=1550, Percentage=-15.02, Rank=10}
    };
}
```

## Customize TreeMap Root Element

Customize the root container of the TreeMap to apply global styling such as background color, padding, and borders.

```css
[id] {
    border: 2px solid red;
}
```

![Blazor TreeMap with Border Customization](images/style/blazor-treemap-border-color.png)

## Customize TreeMap Item Rectangles (RectPath)

Style the rectangle elements of individual tree map items using ID-based selectors. Each rectangle is assigned a unique ID based on the level and item index. The `RectPath` suffix identifies rectangle elements.

### Basic Item Rectangle Styling

Customize the appearance of tree map rectangles with colors, borders, and opacity:

```css
[id*="RectPath"] {
    fill: #3498db;
    stroke: #2c3e50;
    stroke-width: 1;
    opacity: 0.9;
}
```

![Blazor TreeMap with Item Rectangle Customization](images/style/blazor-treemap-item-rect-customization.png)

### Level-Based Rectangle Styling

Apply different styles to rectangles at specific hierarchy levels:

```css
/* Level 0 items */
[id*="_Level_Index_0_"] [id*="RectPath"] {
    fill: #e74c3c;
    opacity: 0.85;
}

/* Level 1 items */
[id*="_Level_Index_1_"] [id*="RectPath"] {
    fill: #3498db;
    opacity: 0.8;
}

/* Level 2 items */
[id*="_Level_Index_2_"] [id*="RectPath"] {
    fill: #2ecc71;
    opacity: 0.75;
}
```

### Item Index-Based Rectangle Styling

Customize rectangles based on their item index within a level:

```css
/* First item in each level */
[id*="_Item_Index_0_RectPath"] {
    fill: #f39c12;
}

/* Second item in each level */
[id*="_Item_Index_1_RectPath"] {
    fill: #9b59b6;
}

/* Third item in each level */
[id*="_Item_Index_2_RectPath"] {
    fill: #1abc9c;
}
```

### Alternating Item Styles

Create alternating color patterns across items:

```css
[id*="_Item_Index_0_RectPath"],
[id*="_Item_Index_2_RectPath"],
[id*="_Item_Index_4_RectPath"] {
    fill: #3498db;
}

[id*="_Item_Index_1_RectPath"],
[id*="_Item_Index_3_RectPath"],
[id*="_Item_Index_5_RectPath"] {
    fill: #e74c3c;
}
```

### Combined Level and Item Styling

Apply styles to specific combinations of level and item indices:

```css
/* Level 0, Item 0 - Featured item */
[id*="_Level_Index_0_Item_Index_0_RectPath"] {
    fill: #f39c12;
    stroke: #d68910;
    stroke-width: 3;
    filter: drop-shadow(0 4px 8px rgba(0,0,0,0.3));
}

/* Level 1, Item 1 - Secondary featured */
[id*="_Level_Index_1_Item_Index_1_RectPath"] {
    fill: #e74c3c;
    stroke: #c0392b;
    stroke-width: 2;
}
```

## Customize TreeMap Item Text

Style the text labels of individual tree map items using ID-based selectors. The `Text` suffix identifies text elements within items.

### Basic Item Text Styling

Customize text color, font size, and weight:

```css
[id*="Text"] {
    fill: #2c3e50;
    font-size: 14px;
    font-weight: 500;
    font-family: "Segoe UI", Arial, sans-serif;
}
```

![Blazor TreeMap with Item Rectangle Customization](images/style/blazor-treemap-item-text-customization.png)

### Level-Based Text Styling

Apply different text styles to items at specific hierarchy levels:

```css
/* Level 0 text */
[id*="_Level_Index_0_"] [id*="Text"] {
    fill: #ffffff;
    font-size: 16px;
    font-weight: 700;
}

/* Level 1 text */
[id*="_Level_Index_1_"] [id*="Text"] {
    fill: #2c3e50;
    font-size: 13px;
    font-weight: 600;
}

/* Level 2 text */
[id*="_Level_Index_2_"] [id*="Text"] {
    fill: #34495e;
    font-size: 11px;
    font-weight: 400;
}
```

### Item Index-Based Text Styling

Customize text based on item index:

```css
/* First item text in each level */
[id*="_Item_Index_0_Text"] {
    fill: #ffffff;
    font-weight: 700;
}

/* Second item text in each level */
[id*="_Item_Index_1_Text"] {
    fill: #ecf0f1;
    font-weight: 600;
}

/* Third item text in each level */
[id*="_Item_Index_2_Text"] {
    fill: #95a5a6;
    font-weight: 500;
}
```

### Combined Level and Item Text Styling

Apply styles to specific combinations of level and item indices:

```css
/* Level 0, Item 0 - Featured text */
[id*="_Level_Index_0_Item_Index_0_Text"] {
    fill: #ffffff;
    font-size: 18px;
    font-weight: 700;
    text-anchor: middle;
}

/* Level 1, Item 1 - Secondary featured text */
[id*="_Level_Index_1_Item_Index_1_Text"] {
    fill: #f39c12;
    font-size: 14px;
    font-weight: 600;
}

/* Level 2 text items */
[id*="_Level_Index_2_Item_Index_0_Text"] {
    fill: #2c3e50;
    font-size: 12px;
}
```

### Text Contrast Enhancement

Ensure text readability across different background colors:

```css
[id*="Text"] {
    text-shadow: 1px 1px 2px rgba(255, 255, 255, 0.5);
    paint-order: stroke;
    stroke: rgba(0, 0, 0, 0.1);
    stroke-width: 3px;
}
```

![Blazor TreeMap with Item Text Customization](images/style/blazor-treemap-item-text-advance-customization.png)

## Combine Rectangle and Text Styling

Create cohesive item styling by combining rectangle and text customizations:

```css
/* Featured light theme items */
[id*="_Item_Index_0_RectPath"] {
    fill: #3498db;
}

[id*="_Item_Index_0_Text"] {
    fill: #ffffff;
    font-weight: 700;
}

/* Secondary dark theme items */
[id*="_Item_Index_1_RectPath"] {
    fill: #2c3e50;
}

[id*="_Item_Index_1_Text"] {
    fill: #ecf0f1;
    font-weight: 600;
}

/* Accent theme items */
[id*="_Item_Index_2_RectPath"] {
    fill: #e74c3c;
}

[id*="_Item_Index_2_Text"] {
    fill: #ffffff;
    font-weight: 600;
}
```

## Hover and Interactive States

Style TreeMap items on hover for better user interaction:

```css
/* Hover effect on rectangles */
[id*="RectPath"]:hover {
    opacity: 1;
    filter: brightness(1.15);
    transition: all 0.3s ease;
}

/* Text visibility on hover */
[id*="RectPath"]:hover ~ [id*="Text"] {
    font-weight: 700;
    fill: #ffffff;
}
```

![Blazor TreeMap with Item Text Customization](images/style/blazor-treemap-item-hover-customization.png)

N> SVG presentation attributes such as fill, font-size, and stroke may require **!important** if overridden by inline SVG attributes.
