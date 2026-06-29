---
layout: post
title: UML Class Diagram in Blazor Diagram Component | Syncfusion
description: Learn how to create and customize UML class diagrams in the Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram Component
documentation: ug
---

# UML Class Diagram in Blazor Diagram Component

A UML class diagram is a structural diagram that represents the static architecture of a system by depicting classes, interfaces, enumerations, and the relationships between them. The [SfDiagramComponent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor suite supports the creation and visualization of UML class diagrams through the [UmlClassifierShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html) class.

To render a UML classifier, assign a `UmlClassifierShape` to the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Shape) property of a `Node`. This shape supports three classifier types - **Class**, **Interface**, and **Enumeration** - each rendered with its own set of compartments and visual conventions.

## Classifier Types

The [Classifier](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_Classifier) property of `UmlClassifierShape` accepts a [ClassifierShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ClassifierShape.html) enum value that determines which UML shape is rendered.

| Classifier | Description |
|---|---|
| `ClassifierShape.Class` | Renders a UML class with compartments for attributes and operations |
| `ClassifierShape.Interface` | Renders a UML interface with the **«interface»** stereotype and an operations compartment |
| `ClassifierShape.Enumeration` | Renders a UML enumeration with the **«enumeration»** stereotype and a members compartment |

**UmlClassifierShape Properties**

The following properties are available on `UmlClassifierShape` regardless of the classifier type selected:

| Property | Type | Description |
|---|---|---|
| [Classifier](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_Classifier) | `ClassifierShape` | Specifies the type of UML shape to render. Default: `ClassifierShape.Class` |
| [ClassShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_ClassShape) | `UmlClass` | Defines the class name, attributes, and methods when `Classifier` is `ClassifierShape.Class` |
| [InterfaceShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_InterfaceShape) | `UmlInterface` | Defines the interface name, attributes and methods when `Classifier` is `ClassifierShape.Interface` |
| [EnumerationShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_EnumerationShape) | `UmlEnumeration` | Defines the enumeration name and members when `Classifier` is `ClassifierShape.Enumeration` |
| [HeaderStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_HeaderStyle) | `TextStyle` | Customizes the appearance of the classifier name header (the top compartment) |

## UML Class

A UML class is rendered with three compartments: the class name header, an attributes section, and a methods (operations) section.

The following code example shows how to create a UML class node.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "classNode",
            OffsetX = 250,
            OffsetY = 250,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                ClassShape = new UmlClass()
                {
                    Name = "Animal",
                    Attributes = new DiagramObjectCollection<UmlClassAttribute>()
                    {
                        new UmlClassAttribute() { Name = "name", Type = "string", Scope = UmlScope.Private },
                        new UmlClassAttribute() { Name = "age",  Type = "int",    Scope = UmlScope.Private }
                    },
                    Methods = new DiagramObjectCollection<UmlClassMethod>()
                    {
                        new UmlClassMethod() { Name = "eat",  Type = "void", Scope = UmlScope.Public },
                        new UmlClassMethod()
                        {
                            Name = "move",
                            Type = "void",
                            Scope = UmlScope.Public,
                            Parameters = new DiagramObjectCollection<UmlTypedElement>()
                            {
                                new UmlTypedElement() { Name = "speed", Type = "int" }
                            }
                        }
                    }
                }
            }
        });
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/UMLCLassDiagram/UMLClassShape.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLIWjZPfYneFRWq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[UML CLass Example](./images/UmlClassShapes/UMLClassShape.webp)" %}

**UmlClass Properties**

| Property | Type | Description |
|---|---|---|
| [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClass.html#Syncfusion_Blazor_Diagram_UmlClass_Name) | string | The class name displayed in the header compartment. Default: `"ClassName"` |
| [Attributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClass.html#Syncfusion_Blazor_Diagram_UmlClass_Attributes) | `DiagramObjectCollection<UmlClassAttribute>` | Collection of attributes for the class |
| [Methods](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClass.html#Syncfusion_Blazor_Diagram_UmlClass_Methods) | `DiagramObjectCollection<UmlClassMethod>` | Collection of methods (operations) for the class |
| [AttributeHeaderSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClass.html#Syncfusion_Blazor_Diagram_UmlClass_AttributeHeaderSettings) | `UmlSectionHeaderSettings` | Configuration for the attributes section header |
| [MethodHeaderSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClass.html#Syncfusion_Blazor_Diagram_UmlClass_MethodHeaderSettings) | `UmlSectionHeaderSettings` | Configuration for the methods section header |
| [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClass.html) | `TextStyle` | Text style applied to class member rows |

## UML Interface

A UML interface is rendered with the **«interface»** stereotype above its name, followed by an operations compartment. Define an interface node using the [InterfaceShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_InterfaceShape) property with a [UmlInterface](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlInterface.html).

`UmlInterface` supports the same `Attributes`, `Methods`, and header configuration properties as `UmlClass`.

**UmlInterface Properties**

| Property | Type | Description |
|---|---|---|
| [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlInterface.html) | string | The interface name displayed in the header compartment. Default: `"InterfaceName"` |
| [Attributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlInterface.html) | `DiagramObjectCollection<UmlClassAttribute>` | Collection of attributes for the interface |
| [Methods](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlInterface.html) | `DiagramObjectCollection<UmlClassMethod>` | Collection of operations for the interface |
| [AttributeHeaderSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlInterface.html) | `UmlSectionHeaderSettings` | Configuration for the attributes section header |
| [MethodHeaderSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlInterface.html) | `UmlSectionHeaderSettings` | Configuration for the methods section header |
| [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlInterface.html) | `TextStyle` | Text style applied to interface member rows |

The following code example shows how to create a UML interface node.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "interfaceNode",
            OffsetX = 250,
            OffsetY = 250,
            Width = 200,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Interface,
                HeaderStyle = new TextStyle() { Fill = "#E8F4FD" },
                InterfaceShape = new UmlInterface()
                {
                    Name = "IMovable",
                    Methods = new DiagramObjectCollection<UmlClassMethod>()
                    {
                        new UmlClassMethod() { Name = "Move",  Type = "void", Scope = UmlScope.Public },
                        new UmlClassMethod() { Name = "Stop",  Type = "void", Scope = UmlScope.Public },
                        new UmlClassMethod() { Name = "GetSpeed", Type = "double", Scope = UmlScope.Public }
                    }
                }
            }
        });
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/UMLCLassDiagram/UMLInterfaceShape.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLIWjZPfYneFRWq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[UML Interface Example](./images/UmlClassShapes/UMLInterfaceShape.webp)" %}

## UML Enumeration

A UML enumeration is rendered with the **«enumeration»** stereotype above its name and a **Members** compartment listing its literals. Define an enumeration node using the [EnumerationShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_EnumerationShape) property with a [UmlEnumeration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlEnumeration.html).

The following code example shows how to create a UML enumeration node.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "enumNode",
            OffsetX = 250,
            OffsetY = 250,
            Width = 200,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Enumeration,
                EnumerationShape = new UmlEnumeration()
                {
                    Name = "Direction",
                    Members = new DiagramObjectCollection<UmlEnumerationMember>()
                    {
                        new UmlEnumerationMember() { Name = "North" },
                        new UmlEnumerationMember() { Name = "South" },
                        new UmlEnumerationMember() { Name = "East" },
                        new UmlEnumerationMember() { Name = "West" }
                    }
                }
            }
        });
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/UMLCLassDiagram/UmlEnumerationShape.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLIWjZPfYneFRWq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[UML Enumeration Example](./images/UmlClassShapes/UMLEnumeration.webp)" %}

**UmlEnumeration Properties**

| Property | Type | Description |
|---|---|---|
| [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlEnumeration.html#Syncfusion_Blazor_Diagram_UmlEnumeration_Name) | string | The enumeration name. Default: `"EnumerationName"` |
| [Members](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlEnumeration.html#Syncfusion_Blazor_Diagram_UmlEnumeration_Members) | `DiagramObjectCollection<UmlEnumerationMember>` | Collection of enumeration literals |
| [MemberHeaderSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlEnumeration.html) | `UmlSectionHeaderSettings` | Configuration for the members section header |

### UmlEnumerationMember Properties

| Property | Type | Description |
|---|---|---|
| [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlEnumerationMember.html#Syncfusion_Blazor_Diagram_UmlEnumerationMember_Name) | string | The literal name displayed in the members compartment. Default: `"Member"` |
| [IsSeparator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlEnumerationMember.html) | bool | When `true`, renders a horizontal divider in the members compartment |
| [SeparatorStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlEnumerationMember.html) | `ShapeStyle` | Style applied to the separator line |

## UmlScope Values

The `UmlScope` enum controls the visibility prefix symbol rendered next to each attribute or method in a UML classifier.

| Value | Symbol | Description |
|---|---|---|
| `Public` | `+` | Publicly accessible |
| `Protected` | `#` | Accessible within the classifier and its subclasses |
| `Private` | `-` | Accessible only within the classifier |
| `Package` | `~` | Accessible within the same package |

## UmlClassAttribute

[UmlClassAttribute](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassAttribute.html) represents a structural feature of a UML classifier (class or interface). Each attribute is rendered as a row in the **Attributes** compartment, displaying its visibility symbol, name, and type (e.g., `- name : string`).

The following code example shows how to add attributes to a class.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "personNode",
            OffsetX = 250,
            OffsetY = 250,
            Width = 200,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                ClassShape = new UmlClass()
                {
                    Name = "Person",
                    Attributes = new DiagramObjectCollection<UmlClassAttribute>()
                    {
                        new UmlClassAttribute() { Name = "Id",   Type = "int",    Scope = UmlScope.Public },
                        new UmlClassAttribute() { Name = "Name", Type = "string", Scope = UmlScope.Private },
                        new UmlClassAttribute() { IsSeparator = true },
                        new UmlClassAttribute() { Name = "Age",  Type = "int",    Scope = UmlScope.Protected }
                    }
                }
            }
        });
    }
}
```

**UmlClassAttribute Properties**

| Property | Type | Description |
|---|---|---|
| [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassAttribute.html) | string | The attribute name |
| [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassAttribute.html) | string | The data type of the attribute (e.g., `"int"`, `"string"`) |
| [Scope](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassAttribute.html#Syncfusion_Blazor_Diagram_UmlClassAttribute_Scope) | `UmlScope` | Visibility of the attribute. Default: `UmlScope.Public` |
| [IsSeparator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassAttribute.html#Syncfusion_Blazor_Diagram_UmlClassAttribute_IsSeparator) | bool | When `true`, renders a horizontal divider line instead of an attribute row |
| [SeparatorStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassAttribute.html) | `ShapeStyle` | Style applied to the separator line |

## UmlClassMethod

[UmlClassMethod](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassMethod.html) represents an operation in a UML classifier (class or interface). Methods are displayed in the **Operations** compartment with their full signature, including visibility symbol, name, parameter list, and return type (e.g., `+ Add(x : int, y : int) : int`).

The following code example shows how to add methods with parameters to a class.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "mathNode",
            OffsetX = 250,
            OffsetY = 250,
            Width = 220,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                ClassShape = new UmlClass()
                {
                    Name = "Calculator",
                    Methods = new DiagramObjectCollection<UmlClassMethod>()
                    {
                        new UmlClassMethod()
                        {
                            Name = "Add",
                            Type = "int",
                            Scope = UmlScope.Public,
                            Parameters = new DiagramObjectCollection<UmlTypedElement>()
                            {
                                new UmlTypedElement() { Name = "x", Type = "int" },
                                new UmlTypedElement() { Name = "y", Type = "int" }
                            }
                        },
                        new UmlClassMethod()
                        {
                            Name = "Reset",
                            Type = "void",
                            Scope = UmlScope.Public
                        }
                    }
                }
            }
        });
    }
}
```

**UmlClassMethod Properties**

| Property | Type | Description |
|---|---|---|
| [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassMethod.html) | string | The method name |
| [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassMethod.html) | string | The return type of the method |
| [Scope](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassMethod.html) | `UmlScope` | Visibility of the method. Default: `UmlScope.Public` |
| [Parameters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassMethod.html#Syncfusion_Blazor_Diagram_UmlClassMethod_Parameters) | `DiagramObjectCollection<UmlTypedElement>` | Collection of method parameters |
| [IsSeparator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassMethod.html) | bool | When `true`, renders a horizontal divider in the methods compartment |

## UmlTypedElement

Each entry in the `Parameters` collection of a `UmlClassMethod` is a `UmlTypedElement`, which defines a single method parameter by its name and data type. The rendered signature uses the format `name : type` for each parameter (e.g., `speed : int`).

| Property | Type | Description |
|---|---|---|
| [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlTypedElement.html) | string | The parameter name |
| [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlTypedElement.html) | string | The parameter data type (e.g., `"int"`, `"string"`) |

## Using Separators

`UmlClassAttribute`, `UmlClassMethod`, and `UmlEnumerationMember` all support a visual separator row. Set `IsSeparator = true` on any item to render a horizontal divider line in that compartment. Customize the separator's appearance using the `SeparatorStyle` property.

```cshtml
Attributes = new DiagramObjectCollection<UmlClassAttribute>()
{
    new UmlClassAttribute() { Name = "PublicId", Type = "Guid", Scope = UmlScope.Public },
    new UmlClassAttribute() { IsSeparator = true, SeparatorStyle = new ShapeStyle() { StrokeColor = "#BDBDBD", StrokeWidth = 1 } },
    new UmlClassAttribute() { Name = "InternalData", Type = "byte[]", Scope = UmlScope.Private }
}
```

## Customizing Header Style

The [HeaderStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlClassifierShape.html#Syncfusion_Blazor_Diagram_UmlClassifierShape_HeaderStyle) property of `UmlClassifierShape` accepts a [TextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.TextStyle.html) to customize the appearance of the classifier's name header (the top compartment).

The following code example shows how to apply a custom header style to a class node.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "vehicleNode",
            OffsetX = 250,
            OffsetY = 250,
            Width = 200,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                HeaderStyle = new TextStyle()
                {
                    Fill  = "#1565C0",
                    Color = "white"
                },
                ClassShape = new UmlClass()
                {
                    Name = "Vehicle",
                    Attributes = new DiagramObjectCollection<UmlClassAttribute>()
                    {
                        new UmlClassAttribute() { Name = "make",  Type = "string", Scope = UmlScope.Private },
                        new UmlClassAttribute() { Name = "model", Type = "string", Scope = UmlScope.Private }
                    }
                }
            }
        });
    }
}
```

## Customizing Section Headers

Every compartment - **Attributes**, **Operations**, and **Members** - has a configurable header row represented by [UmlSectionHeaderSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlSectionHeaderSettings.html). Assign an instance of this class to `AttributeHeaderSettings`, `MethodHeaderSettings`, or `MemberHeaderSettings` to control the label text, style, add/remove buttons, and expand/collapse behavior for that section.

The `UmlSectionHeaderSettings` class provides the following properties to control section header appearance and behavior:

| Property | Type | Description |
|---|---|---|
| [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlSectionHeaderSettings.html) | string | Text label for the section header (e.g., `"Attributes"`, `"Operations"`) |
| [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlSectionHeaderSettings.html) | `TextStyle` | Visual style for the header row |
| [EnableAddAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlSectionHeaderSettings.html) | bool | Shows or hides the `+` (add) button in the header. Default: `true` |
| [EnableRemoveAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlSectionHeaderSettings.html) | bool | Shows or hides the `–` (remove) button in the header. Default: `true` |
| [IsExpanded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlSectionHeaderSettings.html) | bool | Determines whether the section content is visible. Default: `true` |
| [ShowExpandCollapseIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.UmlSectionHeaderSettings.html) | bool | Shows or hides the toggle icon. Default: `true` |

**Add/Remove Icons**: The `EnableAddAction` and `EnableRemoveAction` properties display interactive buttons in the section header. The **+** button inserts a new row into the compartment, and the **-** button removes the selected row. Both are enabled by default. Clicking either button triggers the [CollectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanging) and [CollectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanged) events on the corresponding collection (`Attributes`, `Methods`, or `Members`).

**Collection Change Events**: When a row is added or removed through the **+** or **–** buttons, [CollectionChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanging) and [CollectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_CollectionChanged) events are triggered.

**Event Arguments Properties:**

Both [CollectionChangingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangingEventArgs.html) and [CollectionChangedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.CollectionChangedEventArgs.html) provide access to the following properties:

- **`args.Action`**: Indicates whether the operation is `Add` or `Remove`
- **`args.Element`**: Returns the element that was added or removed. For UML classifiers, this contains the `UmlClassAttribute`, `UmlClassMethod`, or `UmlEnumerationMember` instance with all its properties.
- **`args.Cancel`** (CollectionChangingEventArgs only): Set to `true` to prevent the change from occurring

**Expand/Collapse Icon**: The `ShowExpandCollapseIcon` property displays a **▼** toggle in the section header, allowing users to expand or collapse the compartment content. The `IsExpanded` property sets the initial state and reflects the current visibility of the section.

The following code example shows how to configure section headers and handle collection change events.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes"
    CollectionChanging="@OnCollectionChanging"
    CollectionChanged="@OnCollectionChanged">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "customerNode",
            OffsetX = 250,
            OffsetY = 300,
            Width = 220,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                HeaderStyle = new TextStyle() { Fill = "#334155", Color = "#FFFFFF", Bold = true },
                ClassShape = new UmlClass()
                {
                    Name = "Customer",

                    AttributeHeaderSettings = new UmlSectionHeaderSettings()
                    {
                        HeaderText = "Properties",
                        ShowExpandCollapseIcon = false,
                        IsExpanded = true,
                        Style = new TextStyle() { Fill = "#475569", Color = "#FFFFFF", Bold = true }
                    },
                    MethodHeaderSettings = new UmlSectionHeaderSettings()
                    {
                        HeaderText = "Operations",
                        ShowExpandCollapseIcon = true,
                        EnableAddAction = true,
                        EnableRemoveAction = true,
                        IsExpanded = true,
                        Style = new TextStyle() { Fill = "#64748B", Color = "#FFFFFF", Bold = true }
                    },
                    Attributes = new DiagramObjectCollection<UmlClassAttribute>()
                    {
                        new UmlClassAttribute() { Name = "CustomerId", Type = "int", Scope = UmlScope.Public, Style = new TextStyle() { Fill = "#E2E8F0", Color = "#334155" } },
                        new UmlClassAttribute() { Name = "Email", Type = "string", Scope = UmlScope.Private, Style = new TextStyle() { Fill = "#E2E8F0", Color = "#334155" } }
                    },
                    Methods = new DiagramObjectCollection<UmlClassMethod>()
                    {
                        new UmlClassMethod() { Name = "PlaceOrder", Type = "void", Scope = UmlScope.Public, Style = new TextStyle() { Fill = "#F8FAFC", Color = "#475569" } },
                        new UmlClassMethod() { Name = "UpdateProfile", Type = "bool", Scope = UmlScope.Public, Style = new TextStyle() { Fill = "#F8FAFC", Color = "#475569" } },
                        new UmlClassMethod() { Name = "GetOrderHistory", Type = "List<Order>", Scope = UmlScope.Public, Style = new TextStyle() { Fill = "#F8FAFC", Color = "#475569" } }
                    }
                }
            }
        });
    }

    private void OnCollectionChanging(CollectionChangingEventArgs args)
    {
        //Action to be performed before collection change.
        if (args.Element is UmlClassAttribute attribute)
        {
            Console.WriteLine($"Attribute '{attribute.Name}' is being {args.Action}ed");
        }
    }

    private void OnCollectionChanged(CollectionChangedEventArgs args)
    {
        //Action to be performed after collection change.
        if (args.Element is UmlClassAttribute attribute)
        {
            attribute.Style = new TextStyle() { Fill = "#E2E8F0", Color = "#334155", Bold = true };
        }
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/UMLCLassDiagram/UMLClassHeaderProperties.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLIWjZPfYneFRWq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[UML ClassHeader Example](./images/UmlClassShapes/UMLClassHeader.webp)" %}

## Editing UML Classifier Members

UML class diagrams support inline editing of classifier members, allowing you to update attribute names and types, method names and return types, and enumeration member names directly on the canvas without writing any code. This feature enables quick modifications to your UML model in real-time.

To edit a member in a UML classifier shape, double-click a UML class method, attribute, member, or header in the classifier to edit, or select the UML class method, attribute, member, or header and press **F2** to start editing.

> **Note:** The visibility scope symbol (e.g., `+`, `-`, `#`, `~`) cannot be edited through inline editing. To change the scope, modify the `Scope` property programmatically via the collection change events.

## UML Relationships

UML class diagrams express the structural connections between classifiers through relationship connectors. Use the [RelationShip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RelationShip.html)  connector to specify the relationship type and how many instances of each class are involved.

### Relationship Types

The [RelationshipShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RelationShip.html#Syncfusion_Blazor_Diagram_RelationShip_RelationshipShape) property accepts a [Relationship](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Relationship.html) enum value.

| Relationship | Description | Example |
|---|---|--|
| `Association` | A general navigable link between classifiers | ![Association](images/UmlClassShapes/AssociationConnector.webp) |
| `Aggregation` | A "has-a" relationship with a hollow diamond at the source | ![Aggregation](images/UmlClassShapes/AggregationConnector.webp) |
| `Composition` | A strong "owns-a" relationship with a filled diamond at the source | ![Composition](images/UmlClassShapes/CompositionConnector.webp) |
| `Inheritance` | An "is-a" relationship with an open triangle arrowhead at the target | ![Inheritance](images/UmlClassShapes/InheritanceConnector.webp) |
| `Dependency` | A dashed arrow expressing a usage dependency | ![Dependency](images/UmlClassShapes/MultiplicityConnector.webp) |
| `Realization` | A dashed line with an open triangle (interface implementation) | ![Realization](images/UmlClassShapes/RealizationConnector.webp) |

The following code example shows how to create various relationship connectors.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="800px" Connectors="@connectors">
    <SnapSettings Constraints="SnapConstraints.None"></SnapSettings>
</SfDiagramComponent>

@code {
    private DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        connectors.Add(new Connector()
        {
            ID = "inheritance",
            SourcePoint = new DiagramPoint() { X = 100, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 200 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Inheritance }
        });
        connectors.Add(new Connector()
        {
            ID = "realization",
            SourcePoint = new DiagramPoint() { X = 250, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 350, Y = 200 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Realization }
        });
        connectors.Add(new Connector()
        {
            ID = "aggregation",
            SourcePoint = new DiagramPoint() { X = 400, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 500, Y = 200 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip()
            {
                RelationshipShape = Relationship.Aggregation,
            }
        });
        connectors.Add(new Connector()
        {
            ID = "composition",
            SourcePoint = new DiagramPoint() { X = 550, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 650, Y = 200 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip()
            {
                RelationshipShape = Relationship.Composition,
            }
        });
        connectors.Add(new Connector()
        {
            ID = "dependency",
            SourcePoint = new DiagramPoint() { X = 700, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 800, Y = 200 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Dependency }
        });
        connectors.Add(new Connector()
        {
            ID = "association",
            SourcePoint = new DiagramPoint() { X = 850, Y = 100 },
            TargetPoint = new DiagramPoint() { X = 950, Y = 200 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip()
            {
                RelationshipShape = Relationship.Association,
            }
        });
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/UMLCLassDiagram/UmlRelationshipShape.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLIWjZPfYneFRWq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[UML Relationship Example](./images/UmlClassShapes/UMLRelationShip.webp)" %}

### RelationShip

Configure the relationship between classes using the following options:

| Property | Type | Description |
|---|---|---|
| [RelationshipShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RelationShip.html#Syncfusion_Blazor_Diagram_RelationShip_RelationshipShape) | `Relationship` | Specifies the type of relationship (Association, Aggregation, Composition, Inheritance, etc.). Default: `Relationship.Aggregation` |
| [AssociationType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RelationShip.html#Syncfusion_Blazor_Diagram_RelationShip_AssociationType) | `AssociationFlow?` | Sets the direction of the relationship (Directional, BiDirectional, etc.). Default is null. |
| [Multiplicity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RelationShip.html#Syncfusion_Blazor_Diagram_RelationShip_Multiplicity) | `ClassifierMultiplicity?` | Defines the cardinality (how many instances) at the source and target ends of the relationship. |

### Association Directionality

When `RelationshipShape` is set to `Relationship.Association`, the [AssociationType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.RelationShip.html#Syncfusion_Blazor_Diagram_RelationShip_AssociationType) property controls the arrow direction using [AssociationFlow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.AssociationFlow.html).

| Value | Description | Example |
|---|---|---|
| `AssociationFlow.Directional` | Arrow points from source to target | ![Directional](images/UmlClassShapes/Directional.webp) |
| `AssociationFlow.BiDirectional` | Arrows point in both directions | ![BiDirectional](images/UmlClassShapes/BiDirectional.webp) |

```cshtml
Shape = new RelationShip()
{
    RelationshipShape = Relationship.Association,
    AssociationType   = AssociationFlow.BiDirectional
}
```

### Multiplicity

[ClassifierMultiplicity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ClassifierMultiplicity.html) defines the cardinality labels rendered at both ends of a relationship connector.

**ClassifierMultiplicity**

Defines the multiplicity labels displayed at both ends of a relationship connector.

[Source](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ClassifierMultiplicity.html) - Specifies the multiplicity label at the source end of the relationship.

[Target](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ClassifierMultiplicity.html) - Specifies the multiplicity label at the target end of the relationship.

**MultiplicityLabel**

Define the cardinality range for each end:

[LowerBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.MultiplicityLabel.html) - The minimum number of instances allowed (e.g., `"0"` for zero or more, `"1"` for one or more).

[UpperBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.MultiplicityLabel.html) - The maximum number of instances allowed (e.g., `"1"` for one, `"*"` for many).

The following code example demonstrates applying multiplicity to a connector.

```cshtml
@using Syncfusion.Blazor.Diagram

<SfDiagramComponent Height="600px" Nodes="@nodes" Connectors="@connectors">
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node>      nodes      = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();

    protected override void OnInitialized()
    {
        nodes.Add(new Node()
        {
            ID = "Order", OffsetX = 150, OffsetY = 200, Width = 180,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                ClassShape = new UmlClass() { Name = "Order" }
            }
        });

        nodes.Add(new Node()
        {
            ID = "Product", OffsetX = 250, OffsetY = 350, Width = 180,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                ClassShape = new UmlClass() { Name = "Product" }
            }
        });

        connectors.Add(new Connector()
        {
            ID = "relation",
            SourceID = "Order",
            TargetID = "Product",
            Type = ConnectorSegmentType.Orthogonal,
            Shape = new RelationShip()
            {
                RelationshipShape = Relationship.Aggregation,
                AssociationType   = AssociationFlow.BiDirectional,
                Multiplicity = new ClassifierMultiplicity()
                {
                    Source = new MultiplicityLabel() { LowerBounds = "1", UpperBounds = "1" },
                    Target = new MultiplicityLabel() { LowerBounds = "0", UpperBounds = "*" }
                }
            }
        });
    }
}
```
![ClassifierMultiplicity in Blazor Diagram](images/UmlClassShapes/ClassifierMultiplicity.webp)

## Adding UML Class Shapes to Symbol Palette

UML class shapes can be added to the [Symbol Palette](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfSymbolPaletteComponent.html) for easy reuse and drag-and-drop functionality. Configure predefined UML classifiers (Class, Interface, Enumeration) with default properties and add them to a palette group.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Diagram.SymbolPalette

<div style="float:left">
    <SfSymbolPaletteComponent @ref="@palette" Width="320px" Height="900px" Palettes="@palettes" SymbolHeight="@symbolHeight" SymbolWidth="@symbolWidth"
        SymbolDragPreviewSize="@symbolDragPreviewSize" GetSymbolInfo="GetSymbolInfo">
    </SfSymbolPaletteComponent>
</div>
<div style="float:left">
        <SfDiagramComponent @ref="@Diagram" Height="700px" Width="600px"></SfDiagramComponent>
</div>
@code {
    private SfDiagramComponent Diagram;
    private DiagramSize symbolDragPreviewSize;
    private SymbolInfo SymbolInfo = new SymbolInfo();
    private SfSymbolPaletteComponent palette;
    private DiagramObjectCollection<Palette> palettes;
    double symbolHeight = 130;
    double symbolWidth = 130;
    private DiagramObjectCollection<NodeBase> umlClassNodes { get; set; }
    private DiagramObjectCollection<NodeBase> umlConnectors { get; set; }
    protected override void OnInitialized()
    {
        symbolDragPreviewSize = new DiagramSize();
        symbolDragPreviewSize.Width = 160;
        symbolDragPreviewSize.Height = 160;
        InitializePalatte();
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        palette.Targets = new DiagramObjectCollection<SfDiagramComponent>
        {
            Diagram
        };
    }
    private void InitializePalatte()
    {
        palettes = new DiagramObjectCollection<Palette>();
        umlClassNodes = new DiagramObjectCollection<NodeBase>();
        umlClassNodes.Add(new Node
        {
            ID = "Class",
            OffsetX = 160,
            OffsetY = 200,
            Width = 200,
            Height = 200,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Class,
                HeaderStyle = new TextStyle() { Fill = "#E3F2FD", StrokeColor = "#1976D2", Bold = true, Color = "#0D47A1" },
                ClassShape = new UmlClass()
                {
                    Name = "ClassName",
                }
            }
        });
        umlClassNodes.Add(new Node
        {
            ID = "Interface",
            OffsetX = 420,
            OffsetY = 200,
            Width = 200,
            Height = 200,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Interface,
                HeaderStyle = new TextStyle() { Fill = "#E3F2FD", StrokeColor = "#1976D2", Bold = true, Color = "#0D47A1" },
                InterfaceShape = new UmlInterface
                {
                    Name = "InterfaceName",
                }
            }
        });
        umlClassNodes.Add(new Node
        {
            ID = "Enumeration",
            OffsetX = 680,
            OffsetY = 200,
            Width = 200,
            Height = 200,
            Shape = new UmlClassifierShape()
            {
                Classifier = ClassifierShape.Enumeration,
                HeaderStyle = new TextStyle()
                {
                    Fill = "#E3F2FD",
                    StrokeColor = "#1976D2",
                    Bold = true,
                    Color = "#0D47A1"
                },
                EnumerationShape = new UmlEnumeration
                {
                    Name = "EnumName",
                }
            }
        });
        umlConnectors = new DiagramObjectCollection<NodeBase>();
        umlConnectors.Add(new Connector
        {
            ID = "Association",
            SourcePoint = new DiagramPoint() { X = 110, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 110 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Association }
        });
        umlConnectors.Add(new Connector
        {
            ID = "Aggregation",
            SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
            TargetPoint = new DiagramPoint() { X = 100, Y = 100 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Aggregation }
        });
        umlConnectors.Add(new Connector
        {
            ID = "Composition",
            SourcePoint = new DiagramPoint() { X = 230, Y = 120 },
            TargetPoint = new DiagramPoint() { X = 320, Y = 230 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Composition }
        });
        umlConnectors.Add(new Connector
        {
            ID = "Inheritance",
            SourcePoint = new DiagramPoint() { X = 100, Y = 300 },
            TargetPoint = new DiagramPoint() { X = 200, Y = 400 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Inheritance }
        });
        umlConnectors.Add(new Connector
        {
            ID = "Multiplicity",
            SourcePoint = new DiagramPoint() { X = 400, Y = 300 },
            TargetPoint = new DiagramPoint() { X = 500, Y = 400 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip()
            {
                RelationshipShape = Relationship.Dependency,
                Multiplicity = new ClassifierMultiplicity()
                {
                    Source = new MultiplicityLabel() { LowerBounds = "1", UpperBounds = "*" },
                    Target = new MultiplicityLabel() { LowerBounds = "0", UpperBounds = "1" }
                }
            }
        });
        umlConnectors.Add(new Connector
        {
            ID = "BiDirectional",
            SourcePoint = new DiagramPoint() { X = 120, Y = 120 },
            TargetPoint = new DiagramPoint() { X = 220, Y = 220 },
            Type = ConnectorSegmentType.Straight,
            Shape = new RelationShip() { RelationshipShape = Relationship.Association, AssociationType = AssociationFlow.BiDirectional }
        });
        palettes.Add(
           new Palette()
           {
               ID = "BasicShape",
               Symbols = umlClassNodes,
               Title = "UML Class Shapes",
           }
        );
        palettes.Add(
           new Palette()
           {
               ID = "ConnectorShape",
               Symbols = umlConnectors,
               Title = "UML Class Connector",
           }
        );
    }
    private SymbolInfo GetSymbolInfo(IDiagramObject symbol)
    {
        SymbolInfo symbolInfo = new SymbolInfo();
        string text = string.Empty;
        text = (symbol as NodeBase).ID;
        symbolInfo.Width = 75;
        symbolInfo.Height = 40;
        symbolInfo.Description = new SymbolDescription()
        {
            Text = text,
            Margin = new DiagramThickness() { Top = 10, Bottom = 10 }
        };
        return symbolInfo;
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/UMLCLassDiagram/UMLCLassSymlbolShapes.razor).

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLIWjZPfYneFRWq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[UML Class Symbol Example](./images/UmlClassShapes/UMLClassSymbolShapes.webp)" %}

You can now drag these predefined UML shapes from the Symbol Palette onto the diagram canvas and customize them with specific class names, attributes, methods, and relationships.

> **Note:** The `UmlClassifierShape` automatically computes the node height based on the number of rows in each compartment. Setting an explicit `Height` is not required.

> **Note:** UML classifier nodes only support resizing from the right (East). Rotation and corner handles are disabled for all classifier types.