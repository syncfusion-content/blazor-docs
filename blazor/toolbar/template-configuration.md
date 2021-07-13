# Template Configuration

The Toolbar can be rendered by item based collection and by HTML elements.  To render it based on the given HTML element, use `id` as the `target` property. To render the Toolbar, follow the below structure of the HTML elements:

```html
  <div id='template_toolbar'>   --> Root Toolbar Element
    <div>      --> Toolbar Items Container
       <div>   --> Toolbar Item Element
       </div>
    </div>
  </div>
```

Here, the template ID, `#template_toolbar` is directly appended to the Toolbar.

```csharp

@using Syncfusion.Blazor.Navigations

<div id="template_toolbar">
    <div>
        <div><button class="e-btn e-tbar-btn">Cut</button> </div>
        <div><button class="e-btn e-tbar-btn">Copy</button> </div>
        <div><button class="e-btn e-tbar-btn">Paste</button> </div>
        <div class="e-separator"> </div>
        <div><button class="e-btn e-tbar-btn">Bold</button> </div>
        <div><button class="e-btn e-tbar-btn">Italic</button> </div>
    </div>
</div>
<SfToolbar id="template_toolbar">
</SfToolbar>

```

## Popup customization

`Popup` is one of the supported responsive modes of the Toolbar. The Toolbar commands, popup mode priority and button text mode customizations are
achieved in the item based rendering through property declaration. For more information on popup mode, refer [here](./responsive-mode/)

The above behavior can also be achieved with template rendering by defining `equivalent class` names instead of property declaration.

Equivalent class names listed below are needed to add the Toolbar items' `div` element.

### Priority

Class              | Description
------------       | -------------
  e-overflow-show  | Commands are always displayed on the `Toolbar with primary` priority.
  e-overflow-hide  | Commands are always displayed in the `popup with secondary` priority.

### Button text mode

  Class         | Description
------------       | -------------
  e-popup-text     | Button text is only  visible in the `Popup`.
  e-toolbar-text   | Button text is only visible on the `Toolbar`.

```csharp

@using Syncfusion.Blazor.Navigations

<div id="template_toolbar">
    <div>
        <div class="e-overflow-show e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-cut-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">Cut</div></button> </div>
        <div class="e-overflow-show e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-copy-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">Copy</div></button> </div>
        <div class="e-overflow-show e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-paste-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">Paste</div></button> </div>
        <div class="e-separator"> </div>
        <div class="e-overflow-show e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-bold-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">Bold</div></button> </div>
        <div class="e-overflow-hide e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-underline-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">Underline</div></button> </div>
        <div class="e-overflow-show e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-italic-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">Italic</div></button> </div>
        <div class="e-overflow-show e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-ascending-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">A-Z Sort</div></button> </div>
        <div class="e-overflow-show e-popup-text"><button class="e-btn e-tbar-btn"><span class="e-descending-icon e-icons e-btn-icon"></span><div class="e-tbar-btn-text">Z-A Sort</div></button> </div>
    </div>
</div>
<SfToolbar id="template_toolbar" Width="300" OverflowMode="@OverflowMode.Popup">
</SfToolbar>

<style>
    /* Toolbar Styles */
    .e-cut-icon:before {
        content: "\e604"
    }

    .e-copy-icon:before {
        content: "\e70a"
    }

    .e-paste-icon:before {
        content: "\e712"
    }

    .e-color-icon:before {
        content: "\e703";
    }

    .e-bold-icon:before {
        content: "\e339"
    }

    .e-underline-icon:before {
        content: "\e706";
    }

    .e-alignleft-icon:before {
        content: "\e717"
    }

    .e-alignright-icon:before {
        content: "\e715"
    }

    .e-aligncenter-icon:before {
        content: "\e704"
    }

    .e-alignjustify-icon:before {
        content: "\e71b"
    }

    .e-upload-icon:before {
        content: "\e71e"
    }

    .e-download-icon:before {
        content: "\e70a"
    }

    .e-indent-icon:before {
        content: "\e70b"
    }

    .e-outdent-icon:before {
        content: "\e700"
    }

    .e-clear-icon:before {
        content: "\e70d"
    }

    .e-reload-icon:before {
        content: "\e71c"
    }

    .e-export-icon:before {
        content: "\e720";
    }

    .e-italic-icon:before {
        content: "\e710"
    }

    .e-bullets-icon:before {
        content: "\e711";
    }

    .e-numbering-icon:before {
        content: "\e70e";
    }

    .e-ascending-icon:before {
        content: "\e70f";
    }

    .e-descending-icon:before {
        content: "\e707";
    }
</style>

```
