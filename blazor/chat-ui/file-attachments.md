---
layout: post
title: Attachments in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Attachments with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# File Attachments in Blazor Chat UI component

The `Attachment` support in Chat UI enables the users to upload and send files (images, documents, and more) alongside messages for richer, more contextual conversations. This enhances the interaction by allowing users to provide additional context through files.

You can use the `ChatUIAttachment` tage directive to configure the attachments in the Chat UI.

## Enable file attachments

Enable file attachment support by setting the `Enable` property to `true`. By default, it is `false`.

### Setting saveUrl and removeUrl

Set the `SaveUrl` and `RemoveUrl` properties to specify server endpoints for handling file uploads and removals. The `SaveUrl` processes file uploads, while the `RemoveUrl` handles file deletion requests.

## Setting file type

You can use the `AllowedFileTypes` property to specify which file types users can upload. This property accepts file extensions (e.g., '.pdf', '.docx') or MIME types to control the types of files that can be attached.

## Setting file size

Configure the `MaxFileSize` property to define the maximum file size allowed for uploads. Specify the size in bytes. The default value is `30000000` bytes (approximately 30 MB). Files exceeding this limit will not be uploaded.

## Setting save format

Control the format used to send files to the server using the `SaveFormat` property when path is not set. It does not change how files are uploaded. The default value is `Blob`.

 - `Blob`: Used for fast, memory‑efficient local previews.
 - `Base64`: Reads the file as a Base64 data URL, useful when you need an inline data URL.

 ## Setting server path

The `Path` property specifies the public base URL where uploaded files are (or will be) hosted. When this property is set, it takes precedence over the value defined in `SaveFormat`. This means that even if saveFormat includes a different location or structure for storing files, the path property will be used it for generating the file URL.

## Enabling drag-and-drop

Toggle drag-and-drop support for attachments via `AllowDragAndDrop` property. The default value is `false`.

## Setting maximum count

Restrict how many files can be attached at once using `MaximumCount` property. The default value is `10`. If users select more than the allowed count, the maximum count reached error will be displayed.

## Templates

### Customizing the file preview

Provide a custom UI for previewing selected files using `PreviewTemplate` tag directive under `SfChatUI` component tag. Use this to render thumbnails, filenames, progress, remove buttons, or any additional metadata prior to sending.

### Customizing the attachments

Control how attachments appear inside message bubbles with `AttachmentTemplate` tag directive under `ChatUIAttachment` tag directive. Use this to tailor the display of images, documents, or custom file types once the message is posted.
