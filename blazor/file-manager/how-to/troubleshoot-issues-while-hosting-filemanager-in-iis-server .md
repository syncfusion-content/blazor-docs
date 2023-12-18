---
layout: post
title: Troubleshoot issues with File Manager while hosting it on an IIS server | Syncfusion
description: Learn here all about troubleshoot issues with File Manager while hosting it on an IIS server and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Troubleshoot issues with File Manager while hosting it on an IIS server

By following the below mentioned steps, you can take to troubleshoot the issue while hosting it on an IIS server

* **Check the configuration of the Syncfusion File Manager component** : Ensure that the File Manager component is configured correctly and that the correct image paths are set in the configuration. You can check the Syncfusion File Manager documentation for more information on configuring the component.
* **Check the file permissions** : Ensure that the files and directories that contain the images are readable by the application pool user. You can modify the file and directory permissions in the file system to allow read access for the application pool user.
* **Check the MIME types** : Ensure that the MIME types for the image files are set correctly in IIS. You can modify the MIME types in the IIS Manager by adding or modifying settings related to static content, such as handlers or modules.
* **Check the URL paths** : Ensure that the URL paths to the image files are correct and that the images are located in the correct location relative to the web root. You can modify the URL paths in the Syncfusion File Manager configuration or in your Blazor application code if necessary.
* **Check the browser console** : Open the browser console and look for any errors related to the image files. This can help identify if there are any issues with the file paths, permissions, or MIME types.
