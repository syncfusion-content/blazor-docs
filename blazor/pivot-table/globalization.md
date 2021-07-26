---
layout: post
title: Globalization in Blazor Pivot Table Component | Syncfusion 
description: Learn about Globalization in Blazor Pivot Table component of Syncfusion, and more details.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Globalization

Add **UseRequestLocalization** middle-ware in Configure method in **Startup.cs** file to get browser Culture Info.

Refer the following code to add configuration in Startup.cs file

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();
            ....
            ....
        }
    }
}
```

## Localization

Localization library allows you to localize default text content of the pivot table. The pivot table component has static text of some features (like drop and drop region, pivot field list, etc...) that can be changed to other cultures (Arabic, Deutsch, French, etc...).The static local texts in the pivot table component can be changed to other culture by referring the Resource file. You can refer more details about localization [here](https://blazor.syncfusion.com/documentation/common/localization/).

The Resource file is an XML file which contains the strings(key and value pairs) that you want to translate into different language. You can also refer [`Localization`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-3.0) link to know more about how to configure and use localization in the ASP.NET Core application framework.

* Add **.resx** file to [`Resource`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-3.0#resource-files) folder and enter the key value (Locale Keywords) in the **Name** column and the translated string in the **Value** column as follows.

```csharp
<Component_Name>_<Feature_Name>_<Locale_Key>
```

The following are the list of properties and its values used in the pivot table.

Name |Value (in Deutsch culture)
----|-----
PivotView_AddCondition | Bedingung hinzufügen
PivotView_AddToColumn | Zur Spalte hinzufügen
PivotView_AddToFilter | Zum Filter hinzufügen
PivotView_AddToRow | Zur Zeile hinzufügen
PivotView_AddToValue | Zum Wert hinzufügen
PivotView_After | Nach
PivotView_AfterOrEqualTo | Nach oder gleich
PivotView_Aggregate | Aggregat
PivotView_Alert | Warnen
PivotView_All | Alle
PivotView_All Fields | Alle Felder
PivotView_AllValues | Alle Werte
PivotView_And | und
PivotView_Apply | ANWENDEN
PivotView_Area | Bereich
PivotView_Ascending | Aufsteigend
PivotView_Avg | durchschnittlich
PivotView_Bar | Bar
PivotView_BaseField | Basisfeld
PivotView_BaseItem | Basisgegenstand
PivotView_Before | Vor
PivotView_BeforeOrEqualTo | Vorher oder gleich
PivotView_BeginWith | Beginnt mit
PivotView_Between | Zwischen
PivotView_Blank | (Leer)
PivotView_By | durch
PivotView_CalculatedField | Berechnetes Feld
PivotView_CalculatedField_ConfirmMessage | In diesem Namen ist bereits ein Berechnungsfeld vorhanden. Möchten Sie es ersetzen?
PivotView_CalculatedField_DragDropMessage | Ziehen Sie Felder in die Formel und legen Sie sie dort ab
PivotView_CalculatedField_DragMessage | Ziehen Sie das Feld in die Formel
PivotView_CalculatedField_DropMessage | Das berechnete Feld kann nur in der Werteachse in einem anderen Bereich platziert werden.
PivotView_CalculatedField_ExampleWatermark | Beispiel: ('Sum(Order_Count)' + 'Sum(In_Stock)') * 250
PivotView_CalculatedField_ExistMessage | In diesem Namen ist bereits ein Feld vorhanden. Bitte geben Sie einen anderen Namen ein.
PivotView_CalculatedField_MobileWatermark | Fügen Sie hier Felder hinzu und bearbeiten Sie die Formel.
PivotView_CalculatedField_NameWatermark | Geben Sie den Feldnamen ein
PivotView_CalculatedField_OLAPExampleWatermark | Beispiel: [Measures].[Order Quantity] + ([Measures].[Order Quantity] * 0.10)
PivotView_CalculatedField_Tooltip | Ziehen Sie Felder per Drag &amp; Drop, um einen Ausdruck zu erstellen. Und wenn Sie die vorhandenen die berechneten Felder bearbeiten möchten! Dann können Sie dies erreichen, indem Sie einfach das Feld unter 'Berechnete Mitglieder' auswählen.
PivotView_Cancel | Stornieren
PivotView_Chart | Diagramm
PivotView_Clear | Klar
PivotView_ClearFilter | Klar
PivotView_Close | Schließen
PivotView_Collapse | Zusammenbruch
PivotView_Column | Säule
PivotView_ColumnAxisWatermark | Spalte hier ablegen
PivotView_Columns | Säulen
PivotView_ConditionalFormating | Bedingte Formatierung
PivotView_ConditionalFormatting | Bedingte formatierung
PivotView_Contains | Enthält
PivotView_Copy | Kopieren
PivotView_Count | Anzahl
PivotView_CreateCalculatedField | Berechnetes Feld erstellen
PivotView_CSV | CSV
PivotView_Currency | Währung
PivotView_CurrencySymbol | Währungszeichen
PivotView_Custom | Benutzerdefiniert
PivotView_CustomFormat | Benutzerdefiniertes Format
PivotView_CustomFormatMessage | Geben Sie eine benutzerdefinierte Formatzeichenfolge ein
PivotView_Date | Datum
PivotView_DateTextMessage | Zeigen Sie die Elemente an, für die das Datum gilt
PivotView_Days | Tage
PivotView_DecimalPlaces | Nachkommastellen
PivotView_Delete | Löschen
PivotView_DeleteReport | Löschen Sie einen aktuellen Bericht
PivotView_Descending | Absteigend
PivotView_Details | Einzelheiten
PivotView_DifferenceFrom | Unterschied von
PivotView_Dimension | Abmessungen
PivotView_DistinctCount | Deutliche Anzahl
PivotView_DoesNotBeginWith | Beginnt nicht mit
PivotView_DoesNotContains | Beinhaltet nicht
PivotView_DoesNotEndsWith | Endet nicht mit
PivotView_DoesNotEquals | Ist nicht gleich
PivotView_DoNotShowGrandTotals | Keine Gesamtsummen anzeigen
PivotView_DoNotShowSubtotals | Zwischensummen nicht anzeigen
PivotView_Drag | Ziehen
PivotView_DrillThrough | Durchbohren
PivotView_DrillThroughErrorMessage | Die Rohelemente berechneter Felder können nicht angezeigt werden.
PivotView_Edit | Bearbeiten
PivotView_EmptyRecordsMessage | Keine Datensätze zum Anzeigen
PivotView_EmptyReportMessage | Keine Berichte gefunden !!
PivotView_EndAt | Endet bei
PivotView_EndsWith | Endet mit
PivotView_EnterDate | Datum eingeben
PivotView_EnterReportNameMessage | Geben Sie einen Berichtsnamen ein
PivotView_EnterValue | Wert eingeben
PivotView_Equals | Gleich
PivotView_Error | Error
PivotView_Example | z.B:
PivotView_Excel | Excel
PivotView_Expand | Erweitern
PivotView_Export | Export
PivotView_Expression | Ausdruck
PivotView_False | Falsch
PivotView_FieldCaption | Feldbeschriftung
PivotView_FieldCaptionMessage | Feldbeschriftung
PivotView_FieldDropErrorMessage | Das Feld, das Sie verschieben, kann nicht in diesem Bereich des Berichts platziert werden
PivotView_FieldName | Feldname
PivotView_FieldNameMessage | Feldname :
PivotView_FieldType | Feldtyp
PivotView_Filter | Filter
PivotView_FilterAxisWatermark | Filter hier ablegen
PivotView_Filtered | Gefiltert
PivotView_Filters | Filter
PivotView_Format | Format
PivotView_FormatString | Zeichenfolge formatieren
PivotView_FormatType | Formattyp
PivotView_Formula | Formel
PivotView_GrandTotal | Gesamtsumme
PivotView_GrandTotals | Gesamtsummen
PivotView_GreaterThan | Größer als
PivotView_GreaterThanOrEqualTo | Größer als oder gleich wie
PivotView_Group | Gruppe
PivotView_GroupCaptionMessage | Geben Sie die Beschriftung ein, die in der Kopfzeile angezeigt werden soll
PivotView_GroupFieldCaptionMessage | Geben Sie die Beschriftung für das Gruppenfeld ein
PivotView_Grouping | Gruppierung
PivotView_GroupName | Gruppenname
PivotView_Hours | Std
PivotView_Index | Index
PivotView_IntervalBy | Intervall von
PivotView_InvalidFormat | Ungültiges Format.
PivotView_InvalidFormula | Ungültige Formel.
PivotView_InvalidGroupSelectionMessage | Diese Auswahl kann nicht gruppiert werden.
PivotView_JPEG | JPEG
PivotView_Label | Etikette
PivotView_LabelTextMessage | Zeigen Sie die Elemente an, für die das Etikett
PivotView_Left | Links
PivotView_LessThan | Weniger als
PivotView_LessThanOrEqualTo | Gleich oder kleiner als
PivotView_Line | Linie
PivotView_LoadReport | Belastung
PivotView_ManageRecords | Datensätze verwalten
PivotView_Max | Max
PivotView_MdxQuery | MDX-Abfrage
PivotView_Measure | Messen
PivotView_Member | Mitglied
PivotView_MemberLimitMessage | weitere Artikel. Suche, um weiter zu verfeinern.
PivotView_Min | Min
PivotView_Minutes | Protokoll
PivotView_Months | Monate
PivotView_MoreOption | Mehr...
PivotView_MultipleItems | Mehrere Elemente
PivotView_NewReport | Erstellen Sie einen neuen Bericht
PivotView_NewReportConfirmMessage | Möchten Sie Änderungen speichern, um sie zu melden?
PivotView_NoFormatMessage | Kein Format gefunden !!!
PivotView_NoInputMessage | Geben Sie einen Wert ein
PivotView_NoMatchesMessage | Keine Treffer
PivotView_NotBetween | Nicht zwischen
PivotView_NotEquals | Nicht gleich
PivotView_NoValue | Kein Wert
PivotView_Null | Null
PivotView_Number | Nummer
PivotView_NumberFormatting | Zahlenformatierung
PivotView_Of | von
PivotView_OK | OK
PivotView_OutOfRange | Außer Reichweite
PivotView_ParentHierarchy | Übergeordnete Hierarchie
PivotView_PDF | PDF
PivotView_Percent | Prozent
PivotView_Percentage | Prozentsatz
PivotView_PercentageOfColumnTotal | % der Spalte insgesamt
PivotView_PercentageOfDifferenceFrom | % des Unterschieds von
PivotView_PercentageOfGrandTotal | % der Gesamtsumme
PivotView_PercentageOfParentColumnTotal | % der übergeordneten Spalte insgesamt
PivotView_PercentageOfParentRowTotal | % der Gesamtzahl der übergeordneten Zeilen
PivotView_PercentageOfParentTotal | % der Elternsumme
PivotView_PercentageOfRowTotal | % der Zeilensumme
PivotView_PNG | PNG
PivotView_Polar | Polar
PivotView_PopulationStDev | Bevölkerungsstandardabweichung
PivotView_PopulationVar | Populationsvarianz
PivotView_Product | Produkt
PivotView_Quarter | Qtr
PivotView_Quarters | Viertel
PivotView_QuarterYear | Vierteljahr
PivotView_Remove | Entfernen
PivotView_RemoveReportConfirmMessage | Möchten Sie diesen Bericht wirklich löschen?
PivotView_RenameReport | Benennen Sie einen aktuellen Bericht um
PivotView_ReportList | Berichtsliste
PivotView_ReportNameMessage | Berichtsname:
PivotView_Right | Recht
PivotView_Row | Reihe
PivotView_RowAxisWatermark | Hier eine Zeile ablegen
PivotView_Rows | Reihen
PivotView_RunningTotals | Laufende Summen
PivotView_SampleReport | Beispielbericht
PivotView_SampleStDev | Standardabweichung der Probe
PivotView_SampleVar | Stichprobenvarianz
PivotView_SaveAsReport | Als aktuellen Bericht speichern
PivotView_SaveReport | Speichern Sie einen Bericht
PivotView_Scatter | Streuen
PivotView_Search | Suche
PivotView_Seconds | Sekunden
PivotView_SelectedItems | Ausgewählte Artikel
PivotView_SelectGroups | Wählen Sie Gruppen aus
PivotView_ShowColumnGrandTotalsOnly | Nur Gesamtsummenspalten anzeigen
PivotView_ShowColumnSubtotalsOnly | Nur Zwischensummenspalten anzeigen
PivotView_ShowFieldList | Feldliste anzeigen
PivotView_ShowGrandTotals | Gesamtsummen anzeigen
PivotView_ShowRowGrandTotalsOnly | Nur Gesamtsummenzeilen anzeigen
PivotView_ShowRowSubtotalsOnly | Nur Zwischensummenzeilen anzeigen
PivotView_ShowSubtotals | Zwischensummen anzeigen
PivotView_ShowTable | Tabelle anzeigen
PivotView_Sort | Sortieren
PivotView_Standard | Standard
PivotView_StartAt | Beginnt um
PivotView_Subtotals | Zwischensummen
PivotView_Sum | Summe
PivotView_Summaries | Werte zusammenfassen mit
PivotView_SummarizeValuesBy | Werte zusammenfassen mit
PivotView_SVG | SVG
PivotView_SymbolPosition | Symbolposition
PivotView_Total | Gesamt
PivotView_True | Wahr
PivotView_Undefined | nicht definiert
PivotView_Ungroup | Gruppierung aufheben
PivotView_ValidReportNameMessage | Bitte geben Sie einen gültigen Datensatznamen ein !!!
PivotView_Value | Wert
PivotView_ValueAxisWatermark | Wert hier ablegen
PivotView_ValueFieldSettings | Wertefeldeinstellungen
PivotView_Values | Werte
PivotView_ValueTextMessage | Zeigen Sie die Elemente an, für die
PivotView_Warning | Warnung
PivotView_Years | Jahre
PivotView_MultipleAxes | Mehrere Achsen
PivotView_ChartTypeSettings | Configuración de tipo de gráfico
PivotView_ChartType | Tipo de carta
PivotView_Yes | si
PivotView_No | No
PivotView_NumberFormatMenu | Formato de número ...
PivotView_ConditionalFormatingMenu | formato condicional ...
PivotView_CalculatedField_RemoveMessage | Está seguro de que desea eliminar este campo calculado?
PivotView_StackedArea | Área apilada
PivotView_StackedColumn | Columna apilada
PivotView_StackedBar | Barra apilada
PivotView_StepLine | Línea de paso
PivotView_StepArea | Área de paso
PivotView_SplineArea | Área de spline
PivotView_Spline | Ranura
PivotView_StackedColumn100 | Columna 100% apilada
PivotView_StackedBar100 | Barra 100% apilada
PivotView_StackedArea100 | Área 100% apilada
PivotView_Bubble | Burbuja
PivotView_Pareto | Pareto
PivotView_Radar | Radar
PivotView_CalculatedField_ClearTooltipMessage | Bearbeiten Sie die bearbeiteten Feldinformationen
PivotView_CalculatedField_EditTooltipMessage | Berechnetes Feld bearbeiten
PivotView_NumberFormat_ExampleWatermark | Beispiel: C, P, 0000%, ### 0. ## 0 # usw.
PivotView_ShowLegend | Legende anzeigen
PivotView_FieldCaptionWatermark | Geben Sie die Feldbeschriftung ein
PivotView_SortNone_TooltipMessage | Datenreihenfolge sortieren
PivotView_SortAscending_TooltipMessage | Aufsteigende Reihenfolge sortieren
PivotView_SortDescending_TooltipMessage | Absteigende Reihenfolge sortieren
PivotView_ReplaceReport_BeforeMessage | Ein Bericht mit dem Namen
PivotView_ReplaceReport_AfterMessage | ist bereits vorhanden. Möchten Sie es ersetzen?
PivotView_StaticFieldList | Pivot-Feldlis
PivotView_FieldList | Feldliste
PivotView_AddFieldMessage | Feld hier hinzufügen
PivotView_ChooseFieldMessage | Feld auswählen
PivotView_DragFieldsMessage | Ziehen Sie Felder zwischen den folgenden Achsen:
PivotView_Add | Hinzufügen
PivotView_DeferLayoutUpdate | Layoutaktualisierung verschieben

All locale files for different cultures are available in this [GitHub](https://github.com/syncfusion/blazor-locale/tree/master/src) location. You can get any resource file from there and utilize it in your application.

### Blazor Server Side

In the following example, we have demonstrate how to enable **Localization** for pivot table in server side Blazor sample.

* Open the **Startup.cs** file and add the below configuration in the **ConfigureServices** function as follows.

```csharp
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // define the list of cultures your app will support
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("de")
                };
                // set the default culture
                options.DefaultRequestCulture = new RequestCulture("de");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>() {
                 new QueryStringRequestCultureProvider() // Here, You can also use other localization provider
                };
            });
            services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SampleLocalizer));
        }
    }
}
```

> Add [`UseRequestLocalization()`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-3.0#localization-middleware) middle-ware in Configure method in **Startup.cs** file to get browser Culture Information.

* Then, write a **class** by inheriting **ISyncfusionStringLocalizer** interface and override the Manager property to get the resource file details from the application end.

```csharp
using Syncfusion.Blazor;

namespace BlazorApplication
{
     public class SampleLocalizer : ISyncfusionStringLocalizer
    {

        public string Get(string key)
        {
            return this.Manager.GetString(key);
        }

        public System.Resources.ResourceManager Manager
        {
            get
            {
                return BlazorApplication.Resources.SyncfusionBlazorLocale.ResourceManager;
            }
        }
    }
}
```

```csharp
    @using Syncfusion.Blazor.PivotView;
    @using Syncfusion.Blazor

    <SfPivotView TValue="ProductDetails">
        <PivotViewDataSourceSettings DataSource="@data">
            <PivotViewColumns>
                <PivotViewColumn Name="Year"></PivotViewColumn>
                <PivotViewColumn Name="Quarter"></PivotViewColumn>
            </PivotViewColumns>
            <PivotViewRows>
                <PivotViewRow Name="Country"></PivotViewRow>
                <PivotViewRow Name="Products"></PivotViewRow>
            </PivotViewRows>
            <PivotViewValues>
                <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
                <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
            </PivotViewValues>
            <PivotViewFormatSettings>
                <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
    </SfPivotView>
    @code{
        public List<ProductDetails> data { get; set; }
        protected override void OnInitialized()
        {
            this.data = ProductDetails.GetProductData().ToList();
           //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in  getting started for more details.
        }
    }

```

![output](images/localization.png)

### Blazor WebAssembly

In the following examples, demonstrate how to enable **Localization** for pivot table in client side Blazor samples.

* Open the **Program.cs** file and add the below configuration in the **Main** function as follows.

```csharp
using Syncfusion.Blazor;
using System.Globalization;

namespace ClientApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();


            // Register the Syncfusion locale service to customize the  SyncfusionBlazor component locale culture
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

            // Set the default culture of the application
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de");

            await builder.Build().RunAsync();
        }
    }
}
```

* Then, create a **~/Shared/SyncfusionLocalizer.cs** file and implement **ISyncfusionStringLocalizer** interface to the class and override the ResourceManager property to get the resource file details from the application end.

```csharp
using Syncfusion.Blazor;

public class SyncfusionLocalizer : ISyncfusionStringLocalizer
{
    // To get the locale key from mapped resources file
    public string GetText(string key)
    {
        return this.ResourceManager.GetString(key);
    }  

    // To access the resource file and get the exact value for locale key

    public System.Resources.ResourceManager ResourceManager
    {
        get
        {
            // Replace the ApplicationNamespace with your application name.
            return ClientApplication.Resources.SfResources.ResourceManager;
        }
    }
}
```

> **Note** ClientApplication denotes the ApplicationNameSpace of your project.

```csharp
    @using Syncfusion.Blazor.PivotView;

    <SfPivotView TValue="ProductDetails">
        <PivotViewDataSourceSettings DataSource="@data">
            <PivotViewColumns>
                <PivotViewColumn Name="Year"></PivotViewColumn>
                <PivotViewColumn Name="Quarter"></PivotViewColumn>
            </PivotViewColumns>
            <PivotViewRows>
                <PivotViewRow Name="Country"></PivotViewRow>
                <PivotViewRow Name="Products"></PivotViewRow>
            </PivotViewRows>
            <PivotViewValues>
                <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
                <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
            </PivotViewValues>
            <PivotViewFormatSettings>
                <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
    </SfPivotView>
    @code{
        public List<ProductDetails> data { get; set; }
        protected override void OnInitialized()
        {
            this.data = ProductDetails.GetProductData().ToList();
           //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in  getting started for more details.
        }
    }

```

![output](images/localization.png)

## Internationalization

Internationalization library is used to globalize number, date, and time values in pivot table component using format strings in the [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFormatSetting.html#Syncfusion_Blazor_PivotView_PivotViewFormatSetting_Format). In the below sample we set the culture and currency using the `SetCulture` and `SetCurrencyCode` methods.

```csharp
    @using Syncfusion.Blazor.PivotView;
    @using Syncfusion.Blazor
    @using Microsoft.JSInterop;

    <SfPivotView TValue="ProductDetails">
        <PivotViewDataSourceSettings DataSource="@data">
            <PivotViewColumns>
                <PivotViewColumn Name="Year"></PivotViewColumn>
                <PivotViewColumn Name="Quarter"></PivotViewColumn>
            </PivotViewColumns>
            <PivotViewRows>
                <PivotViewRow Name="Country"></PivotViewRow>
                <PivotViewRow Name="Products"></PivotViewRow>
            </PivotViewRows>
            <PivotViewValues>
                <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
                <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
            </PivotViewValues>
            <PivotViewFormatSettings>
                <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
    </SfPivotView>

    @code{
        public List<PivotViewData.ProductDetails> data { get; set; }
        public List<ProductDetails> data { get; set; }
        protected override void OnInitialized()
        {
            this.data = ProductDetails.GetProductData().ToList();
           //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in  getting started for more details.
        }
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                this.JsRuntime.Sf().SetCulture("de-DE").SetCurrencyCode("EUR");
            }
        }
    }

```

> * In the above sample, **Amount** column is formatted by [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFormatSetting.html#Syncfusion_Blazor_PivotView_PivotViewFormatSetting_Format).
> * Default culture is **en-US**. If you want to change the **en-US** culture to a different culture, you have to set accordingly in `SetCulture` method.
> * The decimal separators of pivot table values varies based on the culture applied to the component.

![output](images/pivot-globalization.png)

## Right-to-left (RTL)

Right-to-left (RTL) provides an option to switch the text direction and layout of the pivot table component from right to left. It improves user experiences and accessibility for users who use right-to-left languages (Arabic, Farsi, Urdu, etc...). In the below code sample `EnableRtl` property is used to enable RTL in the pivot table.

```cshtml
@using Syncfusion.Blazor.PivotView

   <SfPivotView TValue="ProductDetails" ShowFieldList="true" EnableRtl="true">
         <PivotViewDataSourceSettings DataSource="@data">
            <PivotViewColumns>
                <PivotViewColumn Name="Year"></PivotViewColumn>
                <PivotViewColumn Name="Quarter"></PivotViewColumn>
            </PivotViewColumns>
            <PivotViewRows>
                <PivotViewRow Name="Country"></PivotViewRow>
                <PivotViewRow Name="Products"></PivotViewRow>
            </PivotViewRows>
            <PivotViewValues>
                <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
                <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
            </PivotViewValues>
            <PivotViewFormatSettings>
                <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
    </SfPivotView>

    @code{
        public List<ProductDetails> data { get; set; }
        protected override void OnInitialized()
        {
            this.data = ProductDetails.GetProductData().ToList();
           //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
        }
    }

```

![output](images/pivot-rtl.png)

> You can refer to our [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap4) to knows how to render and configure the pivot table.