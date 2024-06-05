---
layout: post
title: Request and Response contents format in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about request and response contents format in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Request and Response Contents Format in Blazor FileManager component

The following table represents the contents of *data, cwd, and files* in the file manager request and response.

|Parameter|Type|Default|Explanation|
|----|----|----|----|
|name|String|-|File name|
|dateCreated|String|-|Date in which file was created (UTC Date string).|
|dateModified|String|-|Date in which file was last modified (UTC Date string).|
|filterPath|String|-|Relative path to the file or folder.|
|hasChild|Boolean|-|Defines this folder has any child folder or not.|
|isFile|Boolean|-|Say whether the item is file or folder.|
|size|Number|-|File size|
|type|String|-|File extension|

The following table represents the contents of *error* in the file manager request and response.

|Parameter|Type|Default|Explanation|
|----|----|----|----|
|code|String|-|Error code|
|message|String|-|Error message|
|fileExists|String[]|-|List of duplicate file names|

The following table represents the contents of *details* in the file manager request and response.

|Parameter|Type|Default|Explanation|
|----|----|----|----|
|name|String|-|File name|
|dateCreated|String|-|Date in which file was created (UTC Date string).|
|dateModified|String|-|Date in which file was last modified (UTC Date string).|
|filterPath|String|-|Relative path to the file or folder.|
|hasChild|Boolean|-|Defines this folder has any child folder or not.|
|isFile|Boolean|-|Say whether the item is file or folder.|
|size|Number|-|File size|
|type|String|-|File extension|
|multipleFiles|Boolean|-|Say whether the details are about single file or multiple files.|