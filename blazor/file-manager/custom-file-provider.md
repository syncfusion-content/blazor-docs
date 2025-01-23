---
layout: post
title: Custom File Provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Custom File System Provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Custom file provider for Blazor File Manager Component

You can also create a custom file provider specific to your needs to connect with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component, instead of relying on the above listed predefined providers offered by Syncfusion. Additionally, you need to ensure that the file actions requests and responses adhere to the same format used in the file system. Below are the details for each file action, to know more information about their request and response parameters.


* **Read** - This action is used to read files and directories from the file system. It retrieves the list of files and subdirectories in a specified directory. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#reading-files-and-folders) to know about the request and response parameters of read operations.

* **Create** - This action is used to create new files or directories within the file system. It is essential for adding new content or organizing the directory structure. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#creating-files-and-folders) to know about the request and response parameters of create operations.

* **Rename** - This action allows you to rename existing files or directories. It helps in managing and updating file names to maintain a clear and organized file system. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#renaming-files-and-folders) to know about the request and response parameters of rename operations.

* **Delete** - This action is used to delete files or directories from the file system. It is a crucial operation for removing unnecessary or outdated files. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#deleting-files-and-folders) to know about the request and response parameters of delete operations.

* **Get File Details**- This action retrieves detailed information about a specific file or directory, such as size, type, location, and last modified date. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#getting-file-details) to know about the request and response parameters of getting file details.

* **Search** - This action allows you to search for files and directories within the file system based on specified criteria. It is useful for quickly finding files by name or other attributes. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#searching-files-and-folders) to know about the request and response parameters of search operations.

* **Copy** - This action is used to copy files or directories from one location to another within the file system. It helps in duplicating content for backup or organizational purposes. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#copying-files-and-folders) to know about the request and response parameters of copy operations.

* **Move** - This action allows you to move files or directories from one location to another. It is essential for reorganizing the file structure and managing content efficiently. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#moving-files-and-folders) to know about the request and response parameters of move operations.

* **Upload** - This action enables the uploading of files from the client to the server. It is crucial for adding new content to the file system from external sources. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#uploading-files) to know about the request and response parameters of upload operations.

* **Download** - This action allows you to download files from the server to the client. It is useful for accessing and retrieving files stored on the server. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#downloading-files) to know about the request and response parameters of download operations.

* **Get Image** - This action retrieves image files from the file system. It is specifically used for handling image files and displaying them in the application. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/file-operations#getting-images) to know about the request and response parameters of get image operations.

Implementing these operations uniformly ensures that the File Manager component functions smoothly with your custom file provider, maintaining consistency in how files are managed and accessed across different actions.

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/filemanager-azure-nodejs-file-provider)