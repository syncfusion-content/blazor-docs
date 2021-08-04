---
layout: post
title: Built-in Themes in Blazor - Syncfusion
description: Check out the documentation for Built-in Themes in Blazor
platform: Blazor
component: Common
documentation: ug
---

# Built-in Themes

The Syncfusion Blazor components library provides the following list of built-in themes:

1. Bootstrap 4
2. Bootstrap
3. Google’s Material
4. Microsoft Office’s Fabric
5. High Contrast
6. Tailwind CSS

> The Syncfusion Blazor Bootstrap theme is designed based on `Bootstrap v3`, whereas the Bootstrap 4 theme is designed based on `Bootstrap v4`.

## Theme file syntax and references

The Syncfusion Blazor themes are available as static web assets in the `Syncfusion.Blazor` and `Syncfusion.Blazor.Themes` NuGet packages.

Add the below link reference inside the `<head>` element of the `~/Pages/_Host.cshtml` file for Blazor server app or `~/wwwroot/index.html` file for Blazor WebAssembly app.

If you are using [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) in your application, then use the below reference link.

```html
<head>
    ....
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
</head>
```

If you are using `Syncfusion.Blazor` NuGet package in your application, then use the below reference link.

```html
<head>
    ....
    ....
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
</head>
```

> The below theme file names can be replaced with the above links.
> * bootstrap4.css
> * bootstrap.css
> * bootstrap-dark.css
> * fabric.css
> * fabric-dark.css
> * highcontrast.css
> * material.css
> * material-dark.css
> * tailwind.css

## CDN reference

The Syncfusion Blazor themes also available in the CDN.

```html
<head>
    ....
    ....
    <link href="https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css" rel="stylesheet" />
</head>
```

## Common Variables

The following list of common variables is used in the Syncfusion Blazor library themes for all UI components. You can change these variables to customize the corresponding theme.

### Syncfusion Blazor Bootstrap 4 Theme

<table>
    <style>
        .circle-color-indicator {
            width: 1.5em;
            height: 1.5em;
            border-radius: 50%;
            display: inline-block;
            border: 1px solid rgba(0, 0, 0, .08);
            vertical-align: middle;
        }
        th, td {
        text-align: left;
        padding: 5px 15px;
        vertical-align: top;
        }
    </style>
    <thead>
        <tr>
            <th>Name</th>
            <th>Value</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>$white</td>
            <td>
                <span class="circle-color-indicator" style="background: #fff;"></span> #fff
            </td>
        </tr>
        <tr>
            <td>$gray-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #f8f9fa;"></span> #f8f9fa
            </td>
        </tr>
        <tr>
            <td>$gray-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #e9ecef;"></span> #e9ecef
            </td>
        </tr>
        <tr>
            <td>$gray-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #dee2e6;"></span> #dee2e6
            </td>
        </tr>
        <tr>
            <td>$gray-400</td>
            <td>
                <span class="circle-color-indicator" style="background: #ced4da;"></span> #ced4da
            </td>
        </tr>
        <tr>
            <td>$gray-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #adb5bd;"></span> #adb5bd
            </td>
        </tr>
        <tr>
            <td>$gray-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #6c757d;"></span> #6c757d
            </td>
        </tr>
        <tr>
        <td>$gray-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #495057;"></span> #495057
            </td>
        </tr>
        <tr>
        <td>$gray-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #343a40;"></span> #343a40
            </td>
        </tr>
        <tr>
        <td>$gray-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #212529;"></span> #212529
            </td>
        </tr>
        <tr>
        <td>$black</td>
            <td>
                <span class="circle-color-indicator" style="background: #000;"></span> #000
            </td>
        </tr>
        <tr>
            <td>$blue</td>
            <td>
                <span class="circle-color-indicator" style="background: #007bff;"></span> #007bff
            </td>
        </tr>
        <tr>
            <td>$indigo</td>
            <td>
                <span class="circle-color-indicator" style="background: #6610f2;"></span> #6610f2
            </td>
        </tr>
        <tr>
            <td>$purple</td>
            <td>
                <span class="circle-color-indicator" style="background: #6f42c1;"></span> #6f42c1
            </td>
        </tr>
        <tr>
            <td>$pink</td>
            <td>
                <span class="circle-color-indicator" style="background: #e83e8c;"></span> #e83e8c
            </td>
        </tr>
        <tr>
            <td>$red</td>
            <td>
                <span class="circle-color-indicator" style="background: #dc3545;"></span> #dc3545
            </td>
        </tr>
        <tr>
            <td>$orange</td>
            <td>
                <span class="circle-color-indicator" style="background: #fd7e14;"></span> #fd7e14
            </td>
        </tr>
        <tr>
            <td>$yellow</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffc107;"></span> #ffc107
            </td>
        </tr>
        <tr>
            <td>$green</td>
            <td>
                <span class="circle-color-indicator" style="background: #28a745;"></span> #28a745
            </td>
        </tr>
        <tr>
            <td>$teal</td>
            <td>
                <span class="circle-color-indicator" style="background: #20c997;"></span> #20c997
            </td>
        </tr>
        <tr>
            <td>$cyan</td>
            <td>
                <span class="circle-color-indicator" style="background: #17a2b8;"></span> #17a2b8
            </td>
        </tr>
    </tbody>
</table>

### Syncfusion Blazor Bootstrap Theme

<table>
    <style>
        .circle-color-indicator {
            width: 1.5em;
            height: 1.5em;
            border-radius: 50%;
            display: inline-block;
            border: 1px solid rgba(0, 0, 0, .08);
            vertical-align: middle;
        }
        th, td {
        text-align: left;
        padding: 5px 15px;
        vertical-align: top;
        }
    </style>
    <thead>
        <tr>
            <th>Name</th>
            <th>Value (Default Theme) </th>
            <th>Value (Dark Theme) </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>$brand-primary</td>
            <td>
                <span class="circle-color-indicator" style="background: #317ab9;"></span> #317ab9
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #0070f0;"></span> #0070f0
            </td>
        </tr>
        <tr>
            <td>$brand-primary-darken-10</td>
            <td>
                <span class="circle-color-indicator" style="background: #3071a9;"></span> #3071a9
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #0058bd;"></span> #0058bd
            </td>
        </tr>
        <tr>
            <td>$brand-primary-darken-15</td>
            <td>
                <span class="circle-color-indicator" style="background: #2a6496;"></span> #2a6496
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #00408a;"></span> #00408a
            </td>
        </tr>
        <tr>
            <td>$brand-primary-darken-25</td>
            <td>
                <span class="circle-color-indicator" style="background: #1f496e;"></span> #1f496e
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #002957;"></span> #002957
            </td>
        </tr>
        <tr>
            <td>$brand-primary-darken-35</td>
            <td>
                <span class="circle-color-indicator" style="background: #142f46;"></span> #142f46
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #001124;"></span> #001124
            </td>
        </tr>
        <tr>
            <td>$brand-primary-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff;"></span> #ffffff
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #fff;"></span> #fff
            </td>
        </tr>
        <tr>
            <td>$grey-base</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000;"></span> #000000
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #1a1a1a;"></span> #1a1a1a
            </td>
        </tr>
        <tr>
            <td>$grey-darker</td>
            <td>
                <span class="circle-color-indicator" style="background: #222222;"></span> #222222
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #131313;"></span> #131313
            </td>
        </tr>
        <tr>
            <td>$grey-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333;"></span> #333333
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #2a2a2a;"></span> #2a2a2a
            </td>
        </tr>
        <tr>
            <td>$grey</td>
            <td>
                <span class="circle-color-indicator" style="background: #555555;"></span> #555555
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #313131;"></span> #313131
            </td>
        </tr>
        <tr>
            <td>$grey-light</td>
            <td>
                <span class="circle-color-indicator" style="background: #777777;"></span> #777777
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #393939;"></span> #393939
            </td>
        </tr>
        <tr>
            <td>$grey-44</td>
            <td>
                <span class="circle-color-indicator" style="background: #444444;"></span> #444444
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #414141;"></span> #414141
            </td>
        </tr>
        <tr>
            <td>$grey-88</td>
            <td>
                <span class="circle-color-indicator" style="background: #888888;"></span> #888888
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #484848;"></span> #484848
            </td>
        </tr>
        <tr>
            <td>$grey-99</td>
            <td>
                <span class="circle-color-indicator" style="background: #999999;"></span> #999999
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #505050;"></span> #505050
            </td>
        </tr>
        <tr>
            <td>$grey-8c</td>
            <td>
                <span class="circle-color-indicator" style="background: #8c8c8c;"></span> #8c8c8c
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #585858;"></span> #585858
            </td>
        </tr>
        <tr>
            <td>$grey-ad</td>
            <td>
                <span class="circle-color-indicator" style="background: #adadad;"></span> #adadad
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #676767;"></span> #676767
            </td>
        </tr>
        <tr>
            <td>$grey-dark-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff;"></span> #ffffff
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #f0f0f0;"></span> #f0f0f0
            </td>
        </tr>
        <tr>
            <td>$grey-white</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff;"></span> #ffffff
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #6e6e6e;"></span> #6e6e6e
            </td>
        </tr>
        <tr>
            <td>$grey-lighter</td>
            <td>
                <span class="circle-color-indicator" style="background: #eeeeee;"></span> #eeeeee
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #767676;"></span> #767676
            </td>
        </tr>
        <tr>
            <td>$grey-f9</td>
            <td>
                <span class="circle-color-indicator" style="background: #f9f9f9;"></span> #f9f9f9
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #7e7e7e;"></span> #7e7e7e
            </td>
        </tr>
        <tr>
            <td>$grey-f8</td>
            <td>
                <span class="circle-color-indicator" style="background: #f8f8f8;"></span> #f8f8f8
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #858585;"></span> #858585
            </td>
        </tr>
        <tr>
            <td>$grey-f5</td>
            <td>
                <span class="circle-color-indicator" style="background: #f5f5f5;"></span> #f5f5f5
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #8d8d8d;"></span> #8d8d8d
            </td>
        </tr>
        <tr>
            <td>$grey-e6</td>
            <td>
                <span class="circle-color-indicator" style="background: #e6e6e6;"></span> #e6e6e6
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #959595;"></span> #959595
            </td>
        </tr>
        <tr>
            <td>$grey-dd</td>
            <td>
                <span class="circle-color-indicator" style="background: #dddddd;"></span> #dddddd
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #9c9c9c;"></span> #9c9c9c
            </td>
        </tr>
        <tr>
            <td>$grey-d4</td>
            <td>
                <span class="circle-color-indicator" style="background: #d4d4d4;"></span> #d4d4d4
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #a4a4a4;"></span> #a4a4a4
            </td>
        </tr>
        <tr>
            <td>$grey-cc</td>
            <td>
                <span class="circle-color-indicator" style="background: #cccccc;"></span> #cccccc
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #acacac;"></span> #acacac
            </td>
        </tr>
        <tr>
            <td>$grey-light-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333;"></span> #333333
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #fff;"></span> #fff
            </td>
        </tr>
        <tr>
            <td>$brand-success</td>
            <td>
                <span class="circle-color-indicator" style="background: #5cb85c;"></span> #5cb85c
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #48b14c;"></span> #48b14c
            </td>
        </tr>
        <tr>
            <td>$brand-success-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #3c763d;"></span> #3c763d
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #358238;"></span> #358238
            </td>
        </tr>
        <tr>
            <td>$brand-info</td>
            <td>
                <span class="circle-color-indicator" style="background: #5bc0de;"></span> #5bc0de
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #2aaac0;"></span> #2aaac0
            </td>
        </tr>
        <tr>
            <td>$brand-info-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #31708f;"></span> #31708f
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #208090;"></span> #208090
            </td>
        </tr>
        <tr>
            <td>$brand-warning</td>
            <td>
                <span class="circle-color-indicator" style="background: #f0ad4e;"></span> #f0ad4e
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #fac168;"></span> #fac168
            </td>
        </tr>
        <tr>
            <td>$brand-warning-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #8a6d3b;"></span> #8a6d3b
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #f9ad37;"></span> #f9ad37
            </td>
        </tr>
        <tr>
            <td>$brand-danger</td>
            <td>
                <span class="circle-color-indicator" style="background: #d9534f;"></span> #d9534f
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #d44f4f;"></span> #d44f4f
            </td>
        </tr>
        <tr>
            <td>$brand-danger-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #a94442;"></span> #a94442
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #c12f2f;"></span> #c12f2f
            </td>
        </tr>
        <tr>
            <td>$brand-success-light</td>
            <td>
                <span class="circle-color-indicator" style="background: #dff0d8;"></span> #dff0d8
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #dff0d8;"></span> #dff0d8
            </td>
        </tr>
        <tr>
            <td>$brand-info-light</td>
            <td>
                <span class="circle-color-indicator" style="background: #d9edf7;"></span> #d9edf7
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #d9edf7;"></span> #d9edf7
            </td>
        </tr>
        <tr>
            <td>$brand-warning-light</td>
            <td>
                <span class="circle-color-indicator" style="background: #fcf8e3;"></span> #fcf8e3
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #fcf8e3;"></span> #fcf8e3
            </td>
        </tr>
        <tr>
            <td>$brand-danger-light</td>
            <td>
                <span class="circle-color-indicator" style="background: #f2dede;"></span> #f2dede
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #f2dede;"></span> #f2dede
            </td>
        </tr>
        <tr>
            <td>$input-border-focus</td>
            <td>
                <span class="circle-color-indicator" style="background: #66afe9;"></span> #66afe9
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #104888;"></span> #104888
            </td>
        </tr>
        <tr>
            <td>$brand-success-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #3c763d;"></span> #3c763d
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #2f7432;"></span> #2f7432
            </td>
        </tr>
        <tr>
            <td>$brand-info-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #31708f;"></span> #31708f
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #1a6c7a;"></span> #1a6c7a
            </td>
        </tr>
        <tr>
            <td>$brand-warning-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #8a6d3b;"></span> #8a6d3b
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #9d6106;"></span> #9d6106
            </td>
        </tr>
        <tr>
            <td>$brand-danger-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #a94442;"></span> #a94442
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #ac2a2a;"></span> #ac2a2a
            </td>
        </tr>
        <tr>
            <td>$base-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000;"></span> #000000
            </td>
               <td>
                <span class="circle-color-indicator" style="background: #000;"></span> #000
            </td>
        </tr>
    </tbody>
</table>

### Syncfusion Blazor Material Theme

<table>
    <style>
        .circle-color-indicator {
            width: 1.5em;
            height: 1.5em;
            border-radius: 50%;
            display: inline-block;
            border: 1px solid rgba(0, 0, 0, .08);
            vertical-align: middle;
        }
        th, td {
        text-align: left;
        padding: 5px 15px;
        vertical-align: top;
        }
    </style>
    <thead>
        <tr>
            <th>Name</th>
            <th>Value (Default Theme) </th>
            <th>Value (Dark Theme) </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>$accent</td>
            <td>
                <span class="circle-color-indicator" style="background: #e3165b"></span> #e3165b
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #00b0ff"></span> #00b0ff
            </td>
        <tr>
        <tr>
            <td>$accent-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
        <tr>
        <tr>
            <td>$primary</td>
            <td>
                <span class="circle-color-indicator" style="background: #3f51b5"></span> #3f51b5
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #3f51b5"></span> #3f51b5
            </td>
        <tr>
        <tr>
            <td>$primary-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #e8eaf6"></span> #e8eaf6
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #e8eaf6"></span> #e8eaf6
            </td>
        <tr>
        <tr>
            <td>$primary-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #c5cae9"></span> #c5cae9
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #c5cae9"></span> #c5cae9
            </td>
        <tr>
        <tr>
            <td>$primary-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #9fa8da"></span> #9fa8da
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #9fa8da"></span> #9fa8da
            </td>
        <tr>
        <tr>
            <td>$primary-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #7986cb"></span> #7986cb
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #7986cb"></span> #7986cb
            </td>
        <tr>
        <tr>
            <td>$primary-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$primary-50-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
        <tr>
        <tr>
            <td>$primary-100-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
        <tr>
        <tr>
            <td>$primary-200-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
        <tr>
        <tr>
            <td>$primary-300-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$grey-white</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$grey-black</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
        <tr>
        <tr>
            <td>$grey-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #fafafa"></span> #fafafa
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fafafa"></span> #fafafa
            </td>
        <tr>
        <tr>
            <td>$grey-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #f5f5f5"></span> #f5f5f5
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f5f5f5"></span> #f5f5f5
            </td>
        <tr>
        <tr>
            <td>$grey-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #eeeeee"></span> #eeeeee
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #eee"></span> #eee
            </td>
        <tr>
        <tr>
            <td>$grey-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #e0e0e0"></span> #e0e0e0
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #e0e0e0"></span> #e0e0e0
            </td>
        <tr>
        <tr>
            <td>$grey-400</td>
            <td>
                <span class="circle-color-indicator" style="background: #bdbdbd"></span> #bdbdbd
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #bdbdbd"></span> #bdbdbd
            </td>
        <tr>
        <tr>
            <td>$grey-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #9e9e9e"></span> #9e9e9e
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #9e9e9e"></span> #9e9e9e
            </td>
        <tr>
        <tr>
            <td>$grey-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #757575"></span> #757575
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #757575"></span> #757575
            </td>
        <tr>
        <tr>
            <td>$grey-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #616161"></span> #616161
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #616161"></span> #616161
            </td>
        <tr>
        <tr>
            <td>$grey-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #424242"></span> #424242
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #424242"></span> #424242
            </td>
        <tr>
        <tr>
            <td>$grey-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #212121"></span> #212121
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #212121"></span> #212121
            </td>
        <tr>
        <tr>
            <td>$grey-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #303030"></span> #303030
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #303030"></span> #303030
            </td>
        <tr>
        <tr>
            <td>$grey-light-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
        <tr>
        <tr>
            <td>$grey-dark-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$base-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
        <tr>
        <tr>
            <td>$error-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #f44336"></span> #f44336
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f44336"></span> #f44336
            </td>
        <tr>
    </tbody>
</table>

### Syncfusion Blazor Microsoft Office Fabric Theme

<table>
    <style>
        .circle-color-indicator {
            width: 1.5em;
            height: 1.5em;
            border-radius: 50%;
            display: inline-block;
            border: 1px solid rgba(0, 0, 0, .08);
            vertical-align: middle;
        }
        th, td {
        text-align: left;
        padding: 5px 15px;
        vertical-align: top;
        }
    </style>
    <thead>
        <tr>
            <th>Name</th>
            <th>Value (Default Theme) </th>
            <th>Value (Dark Theme) </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>$theme-primary</td>
            <td>
                <span class="circle-color-indicator" style="background: #0078d7"></span> #0078d7
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #0074cc"></span> #0074cc
            </td>
        <tr>
        <tr>
            <td>$theme-dark-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #006fc7"></span> darken($theme-primary, 3%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #006bbd"></span> 006bbd
            </td>
        <tr>
        <tr>
            <td>$theme-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #005ba3"></span> darken($theme-primary, 10%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #0063ad"></span> 0063ad
            </td>
        <tr>
        <tr>
            <td>$theme-darker</td>
            <td>
                <span class="circle-color-indicator" style="background: #00457a"></span> darken($theme-primary, 18%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #005799"></span> 005799
            </td>
        <tr>
        <tr>
            <td>$theme-secondary</td>
            <td>
                <span class="circle-color-indicator" style="background: #0081e5"></span> lighten($theme-primary, 3%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #007ddb"></span> 007ddb
            </td>
        <tr>
        <tr>
            <td>$theme-tertiary</td>
            <td>
                <span class="circle-color-indicator" style="background: #42acff"></span> lighten($theme-primary, 21%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #38a9ff"></span> 38a9ff
            </td>
        <tr>
        <tr>
            <td>$theme-light</td>
            <td>
                <span class="circle-color-indicator" style="background: #b7e0ff"></span> lighten($theme-primary, 44%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #addcff"></span> addcff
            </td>
        <tr>
        <tr>
            <td>$theme-lighter</td>
            <td>
                <span class="circle-color-indicator" style="background: #d1ebff"></span> lighten($theme-primary, 49%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #c7e7ff"></span> c7e7ff
            </td>
        <tr>
        <tr>
            <td>$theme-lighter-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #aliceblue"></span> lighten($theme-primary, 55%)
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #e6f4ff"></span> e6f4ff
            </td>
        <tr>
        <tr>
            <td>$neutral-white</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #201f1f"></span> #201f1f
            </td>
        <tr>
        <tr>
            <td>$neutral-lighter-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #f8f8f8"></span> #f8f8f8
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #282727"></span> #282727
            </td>
        <tr>
        <tr>
            <td>$neutral-lighter</td>
            <td>
                <span class="circle-color-indicator" style="background: #f4f4f4"></span> #f4f4f4
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #333232"></span> #333232
            </td>
        <tr>
        <tr>
            <td>$neutral-light</td>
            <td>
                <span class="circle-color-indicator" style="background: #eaeaea"></span> #eaeaea
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #414040"></span> #414040
            </td>
        <tr>
        <tr>
            <td>$neutral-quintenaryalt</td>
            <td>
                <span class="circle-color-indicator" style="background: #dadada"></span> #dadada
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #4a4848"></span> #4a4848
            </td>
        <tr>
        <tr>
            <td>$neutral-quintenary</td>
            <td>
                <span class="circle-color-indicator" style="background: #d0d0d0"></span> #d0d0d0
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #514f4f"></span> #514f4f
            </td>
        <tr>
        <tr>
            <td>$neutral-tertiary-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #c8c8c8"></span> #c8c8c8
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #6f6c6c"></span> #6f6c6c
            </td>
        <tr>
        <tr>
            <td>$neutral-tertiary</td>
            <td>
                <span class="circle-color-indicator" style="background: #a6a6a6"></span> #a6a6a6
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #9a9a9a"></span> #9a9a9a
            </td>
        <tr>
        <tr>
            <td>$neutral-secondary-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #767676"></span> #767676
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #c8c8c8"></span> #c8c8c8
            </td>
        <tr>
        <tr>
            <td>$neutral-secondary</td>
            <td>
                <span class="circle-color-indicator" style="background: #666666"></span> #666666
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #dadada"></span> #dadada
            </td>
        <tr>
        <tr>
            <td>$neutral-primary</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333"></span> #333333
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$neutral-dark</td>
            <td>
                <span class="circle-color-indicator" style="background: #212121"></span> #212121
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f4f4f4"></span> #f4f4f4
            </td>
        <tr>
        <tr>
            <td>$neutral-black</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f8f8f8"></span> #f8f8f8
            </td>
        <tr>
        <tr>
            <td>$alert-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #deecf9"></span> #deecf9
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #bf7500"></span> #bf7500
            </td>
        <tr>
        <tr>
            <td>$error-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #fde7e9"></span> #fde7e9
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #cd2a19"></span> #cd2a19
            </td>
        <tr>
        <tr>
            <td>$success-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #dff6dd"></span> #dff6dd
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #37844d"></span> #37844d
            </td>
        <tr>
        <tr>
            <td>$theme-dark-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$theme-primary-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$theme-light-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333"></span> #333333
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
        <tr>
        <tr>
            <td>$neutral-light-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333"></span> #333333
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #dadada"></span> #dadada
            </td>
        <tr>
        <tr>
            <td>$neutral-light-fontalt</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$grey-dark-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
        <tr>
        <tr>
            <td>$base-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333"></span> #333333
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #dadada"></span> #dadada
            </td>
        <tr>
        <tr>
            <td>$message-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333"></span> #333333
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$alert-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #d83b01"></span> #d83b01
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #ff9d48"></span> #ff9d48
            </td>
        <tr>
        <tr>
            <td>$error-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #a80000"></span> #a80000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #ff5f5f"></span> #ff5f5f
            </td>
        <tr>
        <tr>
            <td>$success-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #107c10"></span> #107c10
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #8eff8d"></span> #8eff8d
            </td>
        <tr>
    </tbody>
</table>

### Syncfusion Blazor High Contrast Theme

<table>
    <style>
        .circle-color-indicator {
            width: 1.5em;
            height: 1.5em;
            border-radius: 50%;
            display: inline-block;
            border: 1px solid rgba(0, 0, 0, .08);
            vertical-align: middle;
        }
        th, td {
        text-align: left;
        padding: 5px 15px;
        vertical-align: top;
        }
    </style>
    <thead>
        <tr>
            <th>Name</th>
            <th>Value</th>
        </tr>
    </thead>
        <tr>
            <td>$selection-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffd939"></span> #ffd939
            </td>
        <tr>
        <tr>
            <td>$selection-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
        <tr>
        <tr>
            <td>$selection-border</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffd939"></span> #ffd939
            </td>
        <tr>
        <tr>
            <td>$hover-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #685708"></span> #685708
            </td>
        <tr>
        <tr>
            <td>$hover-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$hover-border</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$border-default</td>
            <td>
                <span class="circle-color-indicator" style="background: #969696"></span> #969696
            </td>
        <tr>
        <tr>
            <td>$border-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #757575"></span> #757575
            </td>
        <tr>
        <tr>
            <td>$border-fg</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$border-fg-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffd939"></span> #ffd939
            </td>
        <tr>
        <tr>
            <td>$bg-base-0</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
        <tr>
        <tr>
            <td>$bg-base-5</td>
            <td>
                <span class="circle-color-indicator" style="background: #0d0d0d"></span> #0d0d0d
            </td>
        <tr>
        <tr>
            <td>$bg-base-10</td>
            <td>
                <span class="circle-color-indicator" style="background: #1a1a1a"></span> #1a1a1a
            </td>
        <tr>
        <tr>
            <td>$bg-base-15</td>
            <td>
                <span class="circle-color-indicator" style="background: #262626"></span> #262626
            </td>
        <tr>
        <tr>
            <td>$bg-base-20</td>
            <td>
                <span class="circle-color-indicator" style="background: #333333"></span> #333333
            </td>
        <tr>
        <tr>
            <td>$bg-base-75</td>
            <td>
                <span class="circle-color-indicator" style="background: #bfbfbf"></span> #bfbfbf
            </td>
        <tr>
        <tr>
            <td>$bg-base-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$header-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffd939"></span> #ffd939
            </td>
        <tr>
        <tr>
            <td>$header-font-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$content-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$content-font-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #969696"></span> #969696
            </td>
        <tr>
        <tr>
            <td>$link</td>
            <td>
                <span class="circle-color-indicator" style="background: #8a8aff"></span> #8a8aff
            </td>
        <tr>
        <tr>
            <td>$invert-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #000000"></span> #000000
            </td>
        <tr>
        <tr>
            <td>$success-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #166600"></span> #166600
            </td>
        <tr>
        <tr>
            <td>$error-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #b30900"></span> #b30900
            </td>
        <tr>
        <tr>
            <td>$message-font</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffffff"></span> #ffffff
            </td>
        <tr>
        <tr>
            <td>$alert-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #944000"></span> #944000
            </td>
        <tr>
        <tr>
            <td>$info-bg</td>
            <td>
                <span class="circle-color-indicator" style="background: #0056b3"></span> #0056b3
            </td>
        <tr>
        <tr>
            <td>$success-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #2bc700"></span> #2bc700
            </td>
        <tr>
        <tr>
            <td>$error-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #ff6161"></span> #ff6161
            </td>
        <tr>
        <tr>
            <td>$alert-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #ff7d1a"></span> #ff7d1a
            </td>
        <tr>
        <tr>
            <td>$info-alt</td>
            <td>
                <span class="circle-color-indicator" style="background: #66b0ff"></span> #66b0ff
            </td>
        <tr>
        <tr>
            <td>$disable</td>
            <td>
                <span class="circle-color-indicator" style="background: #757575"></span> #757575
            </td>
        <tr>
    <tbody>
    </tbody>
</table>


### Syncfusion Blazor Tailwind CSS Theme

<table>
    <style>
        .circle-color-indicator {
            width: 1.5em;
            height: 1.5em;
            border-radius: 50%;
            display: inline-block;
            border: 1px solid rgba(0, 0, 0, .08);
            vertical-align: middle;
        }
        th, td {
        text-align: left;
        padding: 5px 15px;
        vertical-align: top;
        }
    </style>
    <thead>
        <tr>
            <th>Name</th>
            <th>Value (Default Theme) </th>
            <th>Value (Dark Theme) </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>$black</td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #000"></span> #000
            </td>
        <tr>
        <tr>
            <td>$white</td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff"></span> #fff
            </td>
        <tr>
        <tr>
            <td>$cool-gray-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #f9fafb"></span> #f9fafb
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f9fafb"></span> #f9fafb
            </td>
        <tr>
        <tr>
            <td>$cool-gray-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #f3f4f6"></span> #f3f4f6
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f3f4f6"></span> #f3f4f6
            </td>
        <tr>
        <tr>
            <td>$cool-gray-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #e5e7eb"></span> #e5e7eb
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #e5e7eb"></span> #e5e7eb
            </td>
        <tr>
        <tr>
            <td>$cool-gray-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #d1d5db"></span> #d1d5db
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #d1d5db"></span> #d1d5db
            </td>
        <tr>
        <tr>
            <td>$cool-gray-400</td>
            <td>
                <span class="circle-color-indicator" style="background: #9ca3af"></span> #9ca3af
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #9ca3af"></span> #9ca3af
            </td>
        <tr>
        <tr>
            <td>$cool-gray-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #6b7280"></span> #6b7280
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #6b7280"></span> #6b7280
            </td>
        <tr>
        <tr>
            <td>$cool-gray-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #4b5563"></span> #4b5563
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #4b5563"></span> #4b5563
            </td>
        <tr>
        <tr>
            <td>$cool-gray-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #374151"></span> #374151
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #374151"></span> #374151
            </td>
        <tr>
        <tr>
            <td>$cool-gray-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #1f2937"></span> #1f2937
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #1f2937"></span> #1f2937
            </td>
        <tr>
        <tr>
            <td>$cool-gray-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #111827"></span> #111827
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #111827"></span> #111827
            </td>
        <tr>
        <tr>
            <td>$red-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #fef2f2"></span> #fef2f2
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fef2f2"></span> #fef2f2
            </td>
        <tr>
        <tr>
            <td>$red-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #fee2e2"></span> #fee2e2
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fee2e2"></span> #fee2e2
            </td>
        <tr>
        <tr>
            <td>$red-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #fecaca"></span> #fecaca
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fecaca"></span> #fecaca
            </td>
        <tr>
        <tr>
            <td>$red-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #fca5a5"></span> #fca5a5
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fca5a5"></span> #fca5a5
            </td>
        <tr>
        <tr>
            <td>$red-400</td>
            <td>
                <span class="circle-color-indicator" style="background: #f87171"></span> #f87171
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f87171"></span> #f87171
            </td>
        <tr>
        <tr>
            <td>$red-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #ef4444"></span> #ef4444
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #ef4444"></span> #ef4444
            </td>
        <tr>
        <tr>
            <td>$red-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #dc2626"></span> #dc2626
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #dc2626"></span> #dc2626
            </td>
        <tr>
        <tr>
            <td>$red-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #b91c1c"></span> #b91c1c
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #b91c1c"></span> #b91c1c
            </td>
        <tr>
        <tr>
            <td>$red-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #991b1b"></span> #991b1b
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #991b1b"></span> #991b1b
            </td>
        <tr>
        <tr>
            <td>$red-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #7f1d1d"></span> #7f1d1d
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #7f1d1d"></span> #7f1d1d
            </td>
        <tr>
        <tr>
            <td>$green-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #f0fdf4"></span> #f0fdf4
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f0fdf4"></span> #f0fdf4
            </td>
        <tr>
        <tr>
            <td>$green-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #dcfce7"></span> #dcfce7
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #dcfce7"></span> #dcfce7
            </td>
        <tr>
        <tr>
            <td>$green-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #bbf7d0"></span> #bbf7d0
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #bbf7d0"></span> #bbf7d0
            </td>
        <tr>
        <tr>
            <td>$green-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #86efac"></span> #86efac
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #86efac"></span> #86efac
            </td>
        <tr>
        <tr>
            <td>$green-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #22c55e"></span> #22c55e
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #22c55e"></span> #22c55e
            </td>
        <tr>
        <tr>
            <td>$green-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #16a34a"></span> #16a34a
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #16a34a"></span> #16a34a
            </td>
        <tr>
        <tr>
            <td>$green-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #15803d"></span> #15803d
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #15803d"></span> #15803d
            </td>
        <tr>
        <tr>
            <td>$green-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #166534"></span> #166534
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #166534"></span> #166534
            </td>
        <tr>
        <tr>
            <td>$green-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #14532d"></span> #14532d
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #14532d"></span> #14532d
            </td>
        <tr>
        <tr>
            <td>$orange-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #fff7ed"></span> #fff7ed
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fff7ed"></span> #fff7ed
            </td>
        <tr>
        <tr>
            <td>$orange-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #ffedd5"></span> #ffedd5
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #ffedd5"></span> #ffedd5
            </td>
        <tr>
        <tr>
            <td>$orange-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #fed7aa"></span> #fed7aa
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fed7aa"></span> #fed7aa
            </td>
        <tr>
        <tr>
            <td>$orange-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #fdba74"></span> #fdba74
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fdba74"></span> #fdba74
            </td>
        <tr>
        <tr>
            <td>$orange-400</td>
            <td>
                <span class="circle-color-indicator" style="background: #fb923c"></span> #fb923c
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #fb923c"></span> #fb923c
            </td>
        <tr>
        <tr>
            <td>$orange-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #f97316"></span> #f97316
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #f97316"></span> #f97316
            </td>
        <tr>
        <tr>
            <td>$orange-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #ea580c"></span> #ea580c
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #ea580c"></span> #ea580c
            </td>
        <tr>
        <tr>
            <td>$orange-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #c2410c"></span> #c2410c
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #c2410c"></span> #c2410c
            </td>
        <tr>
        <tr>
            <td>$orange-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #9a3412"></span> #9a3412
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #9a3412"></span> #9a3412
            </td>
        <tr>
        <tr>
            <td>$orange-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #7c2d12"></span> #7c2d12
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #7c2d12"></span> #7c2d12
            </td>
        <tr>
        <tr>
            <td>$cyan-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #ecfeff"></span> #ecfeff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #ecfeff"></span> #ecfeff
            </td>
        <tr>
        <tr>
            <td>$cyan-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #cffafe"></span> #cffafe
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #cffafe"></span> #cffafe
            </td>
        <tr>
        <tr>
            <td>$cyan-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #a5f3fc"></span> #a5f3fc
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #a5f3fc"></span> #a5f3fc
            </td>
        <tr>
        <tr>
            <td>$cyan-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #67e8f9"></span> #67e8f9
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #67e8f9"></span> #67e8f9
            </td>
        <tr>
        <tr>
            <td>$cyan-400</td>
            <td>
                <span class="circle-color-indicator" style="background: #22d3ee"></span> #22d3ee
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #22d3ee"></span> #22d3ee
            </td>
        <tr>
        <tr>
            <td>$cyan-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #06b6d4"></span> #06b6d4
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #06b6d4"></span> #06b6d4
            </td>
        <tr>
        <tr>
            <td>$cyan-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #0891b2"></span> #0891b2
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #0891b2"></span> #0891b2
            </td>
        <tr>
        <tr>
            <td>$cyan-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #0e7490"></span> #0e7490
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #0e7490"></span> #0e7490
            </td>
        <tr>
        <tr>
            <td>$cyan-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #155e75"></span> #155e75
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #155e75"></span> #155e75
            </td>
        <tr>
        <tr>
            <td>$cyan-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #164e63"></span> #164e63
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #164e63"></span> #164e63
            </td>
        <tr>
        <tr>
            <td>$indigo-50</td>
            <td>
                <span class="circle-color-indicator" style="background: #eef2ff"></span> #eef2ff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #eef2ff"></span> #eef2ff
            </td>
        <tr>
        <tr>
            <td>$indigo-100</td>
            <td>
                <span class="circle-color-indicator" style="background: #e0e7ff"></span> #e0e7ff
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #e0e7ff"></span> #e0e7ff
            </td>
        <tr>
        <tr>
            <td>$indigo-200</td>
            <td>
                <span class="circle-color-indicator" style="background: #c7d2fe"></span> #c7d2fe
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #c7d2fe"></span> #c7d2fe
            </td>
        <tr>
        <tr>
            <td>$indigo-300</td>
            <td>
                <span class="circle-color-indicator" style="background: #a5b4fc"></span> #a5b4fc
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #a5b4fc"></span> #a5b4fc
            </td>
        <tr>
        <tr>
            <td>$indigo-400</td>
            <td>
                <span class="circle-color-indicator" style="background: #818cf8"></span> #818cf8
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #818cf8"></span> #818cf8
            </td>
        <tr>
        <tr>
            <td>$indigo-500</td>
            <td>
                <span class="circle-color-indicator" style="background: #6366f1"></span> #6366f1
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #6366f1"></span> #6366f1
            </td>
        <tr>
        <tr>
            <td>$indigo-600</td>
            <td>
                <span class="circle-color-indicator" style="background: #4f46e5"></span> #4f46e5
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #4f46e5"></span> #4f46e5
            </td>
        <tr>
        <tr>
            <td>$indigo-700</td>
            <td>
                <span class="circle-color-indicator" style="background: #4338ca"></span> #4338ca
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #4338ca"></span> #4338ca
            </td>
        <tr>
        <tr>
            <td>$indigo-800</td>
            <td>
                <span class="circle-color-indicator" style="background: #3730a3"></span> #3730a3
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #3730a3"></span> #3730a3
            </td>
        <tr>
        <tr>
            <td>$indigo-900</td>
            <td>
                <span class="circle-color-indicator" style="background: #312e81"></span> #312e81
            </td>
            <td>
                <span class="circle-color-indicator" style="background: #312e81"></span> #312e81
            </td>
        <tr>
    </tbody>
</table>


