---
layout: post
title: Spell Checker in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Spell Checker in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
--- 

# Spell Check

Document Editor supports performing `spell checking` for any input text. You can perform spell checking for the text in Document Editor and it will provide suggestions for the mis-spelled words through dialog and in context menu. Document editor's spell checker is compatible with [Hunspell dictionary files](https://github.com/wooorm/dictionaries).

>Note: Spell check operation requires server-side interaction, so Please refer the [example from GitHub](https://github.com/SyncfusionExamples/EJ2-DocumentEditor-WebServices) to configure the web service and set the [serviceUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_ServiceUrl).

If your running web service Url is `http://localhost:62870/`, set the serviceUrl like below:

In the provided below Blazor code, EnableSpellCheck="true" enables real-time spell checking in the Syncfusion SfDocumentEditorContainer, underlining misspelled words and offering suggestions.
```cshtml
@using Syncfusion.Blazor.DocumentEditor 
@using Syncfusion.EJ2.SpellChecker; 

<SfDocumentEditorContainer @ref="container" EnableToolbar=true Height="590px" EnableSpellCheck="true" ServiceUrl="http://localhost:62870/api/documenteditor/">
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;
    public void OnLoad(object args)
    {
    //Accessing spell checker.
    var spellcheck = container.DocumentEditor.SpellChecker;
    //Set language id to map dictionary in server side.;
    spellcheck.SetLanguageIDAsync(1033);
    spellcheck.SetRemoveUnderlineAsync(false);
    //Allow suggetion for miss spelled word/
    spellcheck.SetAllowSpellCheckAndSuggestionAsync(true);
    }
}
```

>Note: Document Editor requires server-side dependencies for spell check configuration.
Refer to the [Document Editor Web API service projects from GitHub](https://github.com/SyncfusionExamples/EJ2-Document-Editor-Web-Services/tree/master/ASP.NET%20Core#spell-check) link for configuring spell checker in server-side.To know about server-side dependencies, please refer this [page](../document-editor/web-services).

## Features

* Supports context menu suggestions.
* Provides built-in options to Ignore, Ignore All, Change, Change All for error words in spell checker        dialog.

## Enable SpellCheck

To enable spell check in DocumentEditor, set [`EnableSpellCheck`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_EnableSpellCheck) property as `true` and then configure SpellCheckSettings.

## Disable SpellCheck

To disable spell check in DocumentEditor, set [`EnableSpellCheck`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_EnableSpellCheck) property as `false` or remove [`EnableSpellCheck`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditorContainer.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditorContainer_EnableSpellCheck) property initialization code. The default value of this property is false.

## Spell check settings

### Remove Underline

By default, mis-spelled words are marked with squiggly line. You can also disable this behavior by enabling the [`SetRemoveUnderlineAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SpellCheckerModule.html#Syncfusion_Blazor_DocumentEditor_SpellCheckerModule_SetRemoveUnderlineAsync_System_Boolean_) API and now, the squiggly lines will never be rendered for mis-spelled words.

```cshtml
spellcheck.SetRemoveUnderlineAsync(false);
```

### AllowSpellCheckAndSuggestion

By default, on performing spell check in Document Editor, both spelling and suggestions of the mis-spelled words will be retrieved, and this mis-spelled words can be corrected through context menu suggestions. You can modify this behavior using the [`SetAllowSpellCheckAndSuggestionAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SpellCheckerModule.html#Syncfusion_Blazor_DocumentEditor_SpellCheckerModule_SetAllowSpellCheckAndSuggestionAsync_System_Boolean_) API, which will perform only spell check.

```cshtml
spellcheck.SetAllowSpellCheckAndSuggestionAsync(true);
```

### LanguageID

Document Editor provides multi-language spell check support. You can add as many languages (dictionaries) in the server-side and to use that language for spell checking in Document Editor, it must be matched with [`SetLanguageIDAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SpellCheckerModule.html#Syncfusion_Blazor_DocumentEditor_SpellCheckerModule_SetLanguageIDAsync_System_Int32_) you pass in the Document Editor.

```cshtml
spellcheck.SetLanguageIDAsync(1033); //LCID of "en-us";
```

### EnableOptimizedSpellCheck

Document Editor provides option to spell check page by page when loading the documents. The default value of this property is false, so when opening the document spell check web API will be called for each word in the document. To optimize the frequency of spell check web API calls, you can enable this property.

The following code example illustrates how to enable optimized spell checking.

```cshtml
spellcheck.SetEnableOptimizedSpellCheckAsync(true);
```

### Spell check dictionary cache

Starting from `v20.1.0.xx`, we have optimized the performance and memory usage of spell checker by adding a static method to initialize the dictionaries with specified cache count.

By default, the spell checker holds only one language dictionary in memory. If you want to hold multiple dictionaries in memory, you need to set the cache limit by using `InitializeDictionaries` method as in the below example.

```csharp
 List<DictionaryData> spellDictCollection = new List<DictionaryData>();
 string personalDictPath = string.Empty;
 int cacheCount = 2;

 // Initialize dictionaries
 SpellChecker.InitializeDictionaries(spellDictCollection, personalDictPath, cacheCount);
```

If dictionaries are initialized using `InitializeDictionaries` method, then we should use default constructor of the `SpellChecker`to check spelling and get suggestion as in the below example code, it will prevent reinitialization of already loaded dictionaries.

```csharp
public string SpellCheck([FromBody] SpellCheckJsonData spellChecker)
{
    try {
            SpellChecker spellCheck = new SpellChecker();
        spellCheck.GetSuggestions(spellChecker.LanguageID, spellChecker.TexttoCheck, spellChecker.CheckSpelling, spellChecker.CheckSuggestion, spellChecker.AddWord);
        return Newtonsoft.Json.JsonConvert.SerializeObject(spellCheck);
    }
    catch
    {
        return "{\"SpellCollection\":[],\"HasSpellingError\":false,\"Suggestions\":null}";
    }
}
```

Previously on every `SpellChecker.GetSuggestion()` method call, the `.aff` and dictionary data will be parsed to generate suggestion for miss spelled word. But, starting from `v20.1.0.xx`, the `.aff` and dictionary data will be parsed only for the first time alone while calling `SpellChecker.GetSuggestion()` method.

### Add new root word and possible words to dictionary

If you find any root word is missing in the dictionary file, then you can add that new root word and the rule to form the possible words to dictionary file using `AddNewWord` API in the server-side Spell check library.

>Note:
>1. The rules are framed automatically using the root word, the possible words and affix file.
>2. If you pass null for the parameters `affPath` and `possibleWords`, then it will add a single root word to dictionary.
>3. This API is included starting from `v20.2.0.xx`.

The following code example demonstrates how to add a new root word to the dictionary along with the rule to form the possible words.

```csharp

SpellChecker spellChecker = new SpellChecker();
// Adds the specified new root word to the dictionary along with the rule to form the possible words.
spellChecker.AddNewWord("en.dic","en.aff", "construct", new string[] { "constructs", "reconstruct", "constructed", "constructive" });

```

## Context menu

Right click on error word to open the context menu with spell check options. Please see below screenshot for your reference.

![Spell check option in Blazor document editor context menu](images/spell-check-menu.png)

### Suggestions

Context menu shows the suggestions for mis-spelled words. By clicking on the required word from suggestion, the error word gets replaced automatically.

### Add To Dictionary

Using this option, you can add the current word to the dictionary. So that the spell checker does not consider that word as error in future.

### Ignore Once and Ignore All

If you do not wish to add the word to dictionary and do not want to show error, use Ignore Once or Ignore All options.

Ignore: ignore only the current occurrence of a word from error.

Ignore All: ignore all occurrence of a word from error in the entire document.

### Spelling

Using this option, you can open spell check dialog. Please see below screenshot for your reference.

![Spell check dialog in Blazor document editor](images/spell-check-dialog.png)
