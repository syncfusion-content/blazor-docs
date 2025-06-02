---
layout: post
title: Foreign key column in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Foreign key column in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sending context as additional parameters from events in Blazor DataGrid

The Syncfusion Blazor DataGrid offers flexibility to pass additional context information during events. This capability is especially useful for dynamically updating Grid data based on interactions with other components, enabling seamless, real-time data modifications within the Grid.

To implement this, follow these steps:

   1. Place the [ComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started-with-web-app) inside the Grid's `GridEditSettings.Template` to customize the edit form.

   2. Bind the ComboBox’s `ValueChange` event to a handler method.

   3. The method receives two parameters:

      * **args**: The event arguments containing the new `ComboBox` value and selected item.

      * **Contextdata**: The current row data is referenced by the variable **Supplier**, which is cast from the template’s context object as **SuppliermBM**.

    4. Within the event handler, you can update properties of the current row, such as **SupplierName**, **SupplierNameKana**, and **SupplierShortName**, based on the selected ComboBox value. The Grid is directly bound to the data object, so changes made to this object are immediately reflected in the Grid UI.

The following example demonstrates this approach:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor

<SfGrid ID="Grid" @ref="Grid" DataSource="@Suppliers" Toolbar="@(new List<string>{"Add","Edit","Delete","Update"})" Height="650">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Dialog">
        <Validator>
            <DataAnnotationsValidator />
        </Validator>
        <Template>
            @{
                var Supplier = (context as SuppliermBM)!;
                <div class="row">
                    <div class="col-6">
                        <SfTextBox ID="SupplierCd" @bind-Value="@(Supplier.SupplierCd)" Type="Syncfusion.Blazor.Inputs.InputType.Text" Enabled=@false Placeholder="仕入先コード *" FloatLabelType="FloatLabelType.Always" HtmlAttributes="@(new Dictionary<string, object>() { { "maxlength", 14 } })" />
                        <ValidationMessage For="@(() => Supplier.SupplierCd)" />
                    </div>
                    <div class="col-6">
                        <SfTextBox ID="SupplierName" @bind-Value="@(Supplier.SupplierName)" Placeholder="仕入先名 *" FloatLabelType="FloatLabelType.Always" HtmlAttributes="@(new Dictionary<string, object>() { { "maxlength", 50 }})" />
                        <ValidationMessage For="@(() => Supplier.SupplierName)" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <SfTextBox ID="SupplierNameKana" @bind-Value="@(Supplier.SupplierNameKana)" Placeholder="仕入先名ｶﾅ" FloatLabelType="FloatLabelType.Always" HtmlAttributes="@(new Dictionary<string, object>() { { "maxlength", 50 }})" />
                    </div>
                    <div class="col-6">
                        <SfTextBox ID="SupplierShortName" @bind-Value="@(Supplier.SupplierShortName)" Placeholder="仕入先略名 *" FloatLabelType="FloatLabelType.Always" HtmlAttributes="@(new Dictionary<string, object>() { { "maxlength", 50 }})" />
                        <ValidationMessage For="@(() => Supplier.SupplierShortName)" />
                    </div>
                </div>
                <SfComboBox @ref="comboPayToObj" ID="PayToCd" AllowCustom="false" AllowFiltering="true" TItem="Supplierm" @bind-Value="@(Supplier.PayToCd)" Placeholder="支払先" FloatLabelType="FloatLabelType.Always" TValue="string" DataSource="@Payments" CssClass="e-multi-column" ShowClearButton="true" EnableVirtualization="true">
                    <ComboBoxFieldSettings Value="SupplierCd" Text="SupplierName" />
                    <ComboBoxEvents TValue="string" TItem="Supplierm" ValueChange="@((args)=>ChangePayToCd(args, Supplier))" />
                    <ComboBoxTemplates TItem="Supplierm" Context="comboContext">
                        <HeaderTemplate>
                            <table><tr><th>支払先コード</th><th>支払先名</th></tr></table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td>@((comboContext as Supplierm).SupplierCd)</td>
                                        <td>@((comboContext as Supplierm).SupplierName)</td>
                                    </tr>
                                </tbody>
                            </table>
                        </ItemTemplate>
                    </ComboBoxTemplates>
                </SfComboBox>
            }
        </Template>
    </GridEditSettings>
    <GridSearchSettings IgnoreCase="true"></GridSearchSettings>
    <GridColumns>
        <GridColumn Field="@nameof(SuppliermBM.SupplierCd)" HeaderText="仕入先コード" ShowInColumnChooser="false" IsPrimaryKey="true" FilterSettings="@(new FilterSettings { Operator = Operator.Contains })" />
        <GridColumn Field="@nameof(SuppliermBM.SupplierName)" HeaderText="仕入先名" ShowInColumnChooser="false" FilterSettings="@(new FilterSettings { Operator = Operator.Contains })" />
        <GridColumn Field="@nameof(SuppliermBM.SupplierNameKana)" HeaderText="仕入先名ｶﾅ" FilterSettings="@(new FilterSettings { Operator = Operator.Contains })" />
        <GridColumn Field="@nameof(SuppliermBM.SupplierShortName)" HeaderText="仕入先略名" FilterSettings="@(new FilterSettings { Operator = Operator.Contains })" />
    </GridColumns>
</SfGrid>

@code {
    public SfComboBox<string, Supplierm> comboPayToObj { get; set; }
    public SfGrid<SuppliermBM> Grid { get; set; }

    // Sample data for payments and suppliers.
    public List<Supplierm> Payments = new List<Supplierm>
    {
        new Supplierm { SupplierCd = "Supplier01", SupplierName = "Supplier01" },
        new Supplierm { SupplierCd = "Supplier02", SupplierName = "Supplier02" },
        new Supplierm { SupplierCd = "Supplier03", SupplierName = "Supplier03" },
        new Supplierm { SupplierCd = "Supplier04", SupplierName = "Supplier04" },
        new Supplierm { SupplierCd = "Supplier05", SupplierName = "Supplier05" }
    };

    // Method to handle value change in ComboBox.
    public void ChangePayToCd(ChangeEventArgs<string, Supplierm> args, SuppliermBM Contextdata)
    {
         if (args.ItemData != null)
        {
            Grid.PreventRender(false);
            Contextdata.SupplierName = "Changed";
            Contextdata.SupplierNameKana = "Changed";
            Contextdata.SupplierShortName = "Changed";
        }
    }

    // Sample list of suppliers with required fields.
    public List<SuppliermBM> Suppliers { get; set; } = Enumerable.Range(1, 50).Select(x => new SuppliermBM
        {
            SupplierCd = $"000{x}",
            SupplierName = $"仕入先{x}",
            SupplierNameKana = $"シリュウサキ{x}",
            SupplierShortName = $"仕入{x}",
            ZipCd = $"000-000{x}",
            Address1 = $"住所1{x}",
            Address2 = $"ビル等{x}",
            Tel1 = $"000-0000-000{x}",
            FaxNo = $"000-0000-000{x}",
            MailAddress = $"test{x}@test.com",
            SupplierBranch = $"支店{x}",
            SupplierSection = $"部署{x}",
            SupplierPic = $"担当者{x}",
            HonorificTitleName = $"敬称{x}",
            Attribute1Name = $"属性1{x}",
            Attribute2Name = $"属性2{x}",
            Note = $"備考{x}",
            IsEnabled = true,
            InvoiceCompanyNo = $"000000000000{x}",
            InvoiceTypeName = $"請求書区分{x}",
            ClosingDateTypeName = $"締日{x}",
            RoundTypeName = $"金額端数処理区分{x}",
            TaxTypeName = $"消費税計算単位区分{x}",
            TaxRoundTypeName = $"消費税端数処理区分{x}",
            SupplierTypeName = $"仕入先区分名{x}",
            PayToCd = $"支払先コード{x}",
            PayTypeName = $"支払区分{x}",
            PayDateTypeName = $"支払基準日区分{x}",
            PayCondition = $"支払条件{x}",
            BankAccountName = $"振込用口座{x}",
            CommissionTypeName = $"振込手数料負担区分{x}",
            PayCycleName = $"支払サイクル{x}",
            PayDueDateName = $"支払日{x}",
            PoLegth = x,
            PoStartDate = DateTime.Now,
            PoEndDate = DateTime.Now.AddMonths(1),
            CreateDate = DateTime.Now,
            CreateUserName = $"ユーザー{x}",
            UpdateDate = DateTime.Now,
            UpdateUserName = $"更新者{x}"
        }).ToList();

    public class Supplierm
    {
        public string SupplierCd { get; set; }
        public string SupplierName { get; set; }
    }

    public class SuppliermBM
    {
        public string SupplierCd { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNameKana { get; set; }
        public string SupplierShortName { get; set; }
        public string ZipCd { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Tel1 { get; set; }
        public string FaxNo { get; set; }
        public string MailAddress { get; set; }
        public string SupplierBranch { get; set; }
        public string SupplierSection { get; set; }
        public string SupplierPic { get; set; }
        public string HonorificTitleName { get; set; }
        public string Attribute1Name { get; set; }
        public string Attribute2Name { get; set; }
        public string Note { get; set; }
        public bool IsEnabled { get; set; }
        public string InvoiceCompanyNo { get; set; }
        public string InvoiceTypeName { get; set; }
        public string ClosingDateTypeName { get; set; }
        public string RoundTypeName { get; set; }
        public string TaxTypeName { get; set; }
        public string TaxRoundTypeName { get; set; }
        public string SupplierTypeName { get; set; }
        public string PayToCd { get; set; }
        public string PayTypeName { get; set; }
        public string PayDateTypeName { get; set; }
        public string PayCondition { get; set; }
        public string BankAccountName { get; set; }
        public string CommissionTypeName { get; set; }
        public string PayCycleName { get; set; }
        public string PayDueDateName { get; set; }
        public int PoLegth { get; set; }
        public DateTime PoStartDate { get; set; }
        public DateTime PoEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserName { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUserName { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjheZIWaBrEumlde?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}