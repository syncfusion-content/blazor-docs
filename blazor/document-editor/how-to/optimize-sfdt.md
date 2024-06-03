---
layout: post
title: Optimize the SFDT file in Blazor DocumentEditor Component | Syncfusion
description: Learn here all about optimize the SFDT file in Document Editor in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# How to optimize the SFDT file

Starting from version v21.1.x, the SFDT file generated in Word Processor component is optimized by default to reduce the file size. All static keys are minified, and the final JSON string is compressed. This helps reduce the SFDT file size relative to a DOCX file and provides the following benefits,
* File transfer between client and server through the internet gets faster.
* The new optimized SFDT files require less storage space than the old SFDT files.
Hence, the optimized SFDT file can't be directly manipulated as JSON string.

> This feature comes with a public API to switch between the old and new optimized SFDT format, allowing backward compatibility.

As a backward compatibility to create older format SFDT files, refer the following code changes,

<table>
<tr>
<td>Client/Server</td><td>Old Code</td><td>New Code from v21.1.x</td>
</tr>
<tr>
<td>Client-side</td>
<td>
{% tabs %}
{% highlight C# tabtitle="Index.razor" %}
<SfDocumentEditorContainer @ref="container" Height="590px"></SfDocumentEditorContainer>
{% endhighlight %}
{% endtabs %}
</td>
<td>
{% tabs %}
{% highlight C# tabtitle="Index.razor" %}
<SfDocumentEditorContainer @ref="container" Height="590px" DocumentEditorSettings="settings">
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { OptimizeSfdt = false };
}
{% endhighlight %}
{% endtabs %}
</td>
</tr>
<tr>
<td>Server-side C#</td>
<td>
{% tabs %}
{% highlight C# tabtitle="C#" %}
WordDocument sfdtDocument = WordDocument.Load(stream, formatType);
string sfdt = JsonSerializer.Serialize(sfdtDocument);
{% endhighlight %}
{% endtabs %}
</td>
<td>
{% tabs %}
{% highlight C# tabtitle="C#" %}
WordDocument sfdtDocument = WordDocument.Load(stream, formatType);
sfdtDocument.OptimizeSfdt = false;
string sfdt = JsonSerializer.Serialize(sfdtDocument);
{% endhighlight %}
{% endtabs %}
</td>
</tr>

</table>

To convert from older format SFDT from a new optimized SFDT file, refer the following code example,

<table>
<tr>
<td>Client/Server</td><td>Code example</td>
</tr>
<tr>
<td>Client-side</td>
<td>
{% tabs %}
{% highlight C# tabtitle="Index.razor" %}
<SfDocumentEditorContainer @ref="container" Height="590px" DocumentEditorSettings="settings">
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    DocumentEditorSettingsModel settings = new DocumentEditorSettingsModel() { OptimizeSfdt = false };
}
{% endhighlight %}
{% endtabs %}
</td>
</tr>
<tr>
<td>Server-side C#</td>
<td>

{% tabs %}
{% highlight C# tabtitle="C#" %}
using(Syncfusion.DocIO.DLS.WordDocument docIODocument = WordDocument.Save(optimizedSfdt)) {
    sfdtDocument = WordDocument.Load(docIODocument);
    sfdtDocument.OptimizeSfdt = false;
    string oldSfdt = JsonSerializer.Serialize(sfdtDocument);
}
{% endhighlight %}
{% endtabs %}
</td>
</tr>
</table>