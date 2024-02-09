Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormSendInvoice
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents GrpSaleTaxType As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSalesTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents LblSalesTaxAmount As System.Windows.Forms.Label
    Friend WithEvents ChkShippingIncludedInTax As System.Windows.Forms.CheckBox
    Friend WithEvents TxtSalesTaxState As System.Windows.Forms.TextBox
    Friend WithEvents LblSalesTaxState As System.Windows.Forms.Label
    Friend WithEvents TxtSalesTaxPercent As System.Windows.Forms.TextBox
    Friend WithEvents LblSalesTaxPercent As System.Windows.Forms.Label
    Friend WithEvents GrpShippingServiceOptions As System.Windows.Forms.GroupBox
    Friend WithEvents TxtShippingServiceCost As System.Windows.Forms.TextBox
    Friend WithEvents TxtShippingServicePriority As System.Windows.Forms.TextBox
    Friend WithEvents LblShippingServiceCost As System.Windows.Forms.Label
    Friend WithEvents CboShippingService As System.Windows.Forms.ComboBox
    Friend WithEvents LblShippingService As System.Windows.Forms.Label
    Friend WithEvents LblShippingServicePriority As System.Windows.Forms.Label
    Friend WithEvents TxtShippingServiceAdditionalCost As System.Windows.Forms.TextBox
    Friend WithEvents LblShippingInsuranceCost As System.Windows.Forms.Label
    Friend WithEvents LblShippingServiceAdditionalCost As System.Windows.Forms.Label
    Friend WithEvents TxtShippingInsuranceCost As System.Windows.Forms.TextBox
    Friend WithEvents ChkEmailCopyToSeller As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCheckoutInstructions As System.Windows.Forms.TextBox
    Friend WithEvents LblCheckoutInstructions As System.Windows.Forms.Label
    Friend WithEvents TxtPayPalEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents LblPayPalEmailAddress As System.Windows.Forms.Label
    Friend WithEvents CboPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents LblPaymentMethod As System.Windows.Forms.Label
    Friend WithEvents TxtInsuranceFee As System.Windows.Forms.TextBox
    Friend WithEvents lblInsuranceFee As System.Windows.Forms.Label
    Friend WithEvents TxtTransactionId As System.Windows.Forms.TextBox
    Friend WithEvents LblTransactionId As System.Windows.Forms.Label
    Friend WithEvents CboInsuranceOption As System.Windows.Forms.ComboBox
    Friend WithEvents LblInsuranceOption As System.Windows.Forms.Label
    Friend WithEvents TxtItemId As System.Windows.Forms.TextBox
    Friend WithEvents LblItemId As System.Windows.Forms.Label
    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
    Friend WithEvents BtnSendInvoice As System.Windows.Forms.Button









    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GrpSaleTaxType = New System.Windows.Forms.GroupBox()
        Me.TxtSalesTaxAmount = New System.Windows.Forms.TextBox()
        Me.LblSalesTaxAmount = New System.Windows.Forms.Label()
        Me.ChkShippingIncludedInTax = New System.Windows.Forms.CheckBox()
        Me.TxtSalesTaxState = New System.Windows.Forms.TextBox()
        Me.LblSalesTaxState = New System.Windows.Forms.Label()
        Me.TxtSalesTaxPercent = New System.Windows.Forms.TextBox()
        Me.LblSalesTaxPercent = New System.Windows.Forms.Label()
        Me.GrpShippingServiceOptions = New System.Windows.Forms.GroupBox()
        Me.TxtShippingServiceCost = New System.Windows.Forms.TextBox()
        Me.TxtShippingServicePriority = New System.Windows.Forms.TextBox()
        Me.LblShippingServiceCost = New System.Windows.Forms.Label()
        Me.CboShippingService = New System.Windows.Forms.ComboBox()
        Me.LblShippingService = New System.Windows.Forms.Label()
        Me.LblShippingServicePriority = New System.Windows.Forms.Label()
        Me.TxtShippingServiceAdditionalCost = New System.Windows.Forms.TextBox()
        Me.LblShippingInsuranceCost = New System.Windows.Forms.Label()
        Me.LblShippingServiceAdditionalCost = New System.Windows.Forms.Label()
        Me.TxtShippingInsuranceCost = New System.Windows.Forms.TextBox()
        Me.ChkEmailCopyToSeller = New System.Windows.Forms.CheckBox()
        Me.TxtCheckoutInstructions = New System.Windows.Forms.TextBox()
        Me.LblCheckoutInstructions = New System.Windows.Forms.Label()
        Me.TxtPayPalEmailAddress = New System.Windows.Forms.TextBox()
        Me.LblPayPalEmailAddress = New System.Windows.Forms.Label()
        Me.CboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.LblPaymentMethod = New System.Windows.Forms.Label()
        Me.TxtInsuranceFee = New System.Windows.Forms.TextBox()
        Me.lblInsuranceFee = New System.Windows.Forms.Label()
        Me.TxtTransactionId = New System.Windows.Forms.TextBox()
        Me.LblTransactionId = New System.Windows.Forms.Label()
        Me.CboInsuranceOption = New System.Windows.Forms.ComboBox()
        Me.LblInsuranceOption = New System.Windows.Forms.Label()
        Me.TxtItemId = New System.Windows.Forms.TextBox()
        Me.LblItemId = New System.Windows.Forms.Label()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.BtnSendInvoice = New System.Windows.Forms.Button()
        Me.GrpSaleTaxType.SuspendLayout()
        Me.GrpShippingServiceOptions.SuspendLayout()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpSaleTaxType
        '
        Me.GrpSaleTaxType.Controls.AddRange(New System.Windows.Forms.Control() {Me.TxtSalesTaxAmount, Me.LblSalesTaxAmount, Me.ChkShippingIncludedInTax, Me.TxtSalesTaxState, Me.LblSalesTaxState, Me.TxtSalesTaxPercent, Me.LblSalesTaxPercent})
        Me.GrpSaleTaxType.Location = New System.Drawing.Point(48, 232)
        Me.GrpSaleTaxType.Name = "GrpSaleTaxType"
        Me.GrpSaleTaxType.Size = New System.Drawing.Size(376, 152)
        Me.GrpSaleTaxType.TabIndex = 100
        Me.GrpSaleTaxType.TabStop = False
        Me.GrpSaleTaxType.Text = "Sale Tax"
        '
        'TxtSalesTaxAmount
        '
        Me.TxtSalesTaxAmount.Location = New System.Drawing.Point(136, 120)
        Me.TxtSalesTaxAmount.Name = "TxtSalesTaxAmount"
        Me.TxtSalesTaxAmount.Size = New System.Drawing.Size(160, 20)
        Me.TxtSalesTaxAmount.TabIndex = 74
        Me.TxtSalesTaxAmount.Text = "3.14"
        '
        'LblSalesTaxAmount
        '
        Me.LblSalesTaxAmount.Location = New System.Drawing.Point(16, 120)
        Me.LblSalesTaxAmount.Name = "LblSalesTaxAmount"
        Me.LblSalesTaxAmount.Size = New System.Drawing.Size(120, 18)
        Me.LblSalesTaxAmount.TabIndex = 75
        Me.LblSalesTaxAmount.Text = "Sales Tax Amount:"
        '
        'ChkShippingIncludedInTax
        '
        Me.ChkShippingIncludedInTax.Checked = True
        Me.ChkShippingIncludedInTax.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkShippingIncludedInTax.Location = New System.Drawing.Point(16, 88)
        Me.ChkShippingIncludedInTax.Name = "ChkShippingIncludedInTax"
        Me.ChkShippingIncludedInTax.Size = New System.Drawing.Size(160, 24)
        Me.ChkShippingIncludedInTax.TabIndex = 73
        Me.ChkShippingIncludedInTax.Text = "Shipping Included In Tax"
        '
        'TxtSalesTaxState
        '
        Me.TxtSalesTaxState.Location = New System.Drawing.Point(136, 56)
        Me.TxtSalesTaxState.Name = "TxtSalesTaxState"
        Me.TxtSalesTaxState.Size = New System.Drawing.Size(160, 20)
        Me.TxtSalesTaxState.TabIndex = 71
        Me.TxtSalesTaxState.Text = "CA"
        '
        'LblSalesTaxState
        '
        Me.LblSalesTaxState.Location = New System.Drawing.Point(16, 56)
        Me.LblSalesTaxState.Name = "LblSalesTaxState"
        Me.LblSalesTaxState.Size = New System.Drawing.Size(120, 18)
        Me.LblSalesTaxState.TabIndex = 72
        Me.LblSalesTaxState.Text = "Sales Tax State:"
        '
        'TxtSalesTaxPercent
        '
        Me.TxtSalesTaxPercent.Location = New System.Drawing.Point(136, 24)
        Me.TxtSalesTaxPercent.Name = "TxtSalesTaxPercent"
        Me.TxtSalesTaxPercent.Size = New System.Drawing.Size(160, 20)
        Me.TxtSalesTaxPercent.TabIndex = 69
        Me.TxtSalesTaxPercent.Text = "8.25"
        '
        'LblSalesTaxPercent
        '
        Me.LblSalesTaxPercent.Location = New System.Drawing.Point(16, 24)
        Me.LblSalesTaxPercent.Name = "LblSalesTaxPercent"
        Me.LblSalesTaxPercent.Size = New System.Drawing.Size(120, 18)
        Me.LblSalesTaxPercent.TabIndex = 70
        Me.LblSalesTaxPercent.Text = "SalesTax Percent:"
        '
        'GrpShippingServiceOptions
        '
        Me.GrpShippingServiceOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.TxtShippingServiceCost, Me.TxtShippingServicePriority, Me.LblShippingServiceCost, Me.CboShippingService, Me.LblShippingService, Me.LblShippingServicePriority, Me.TxtShippingServiceAdditionalCost, Me.LblShippingInsuranceCost, Me.LblShippingServiceAdditionalCost, Me.TxtShippingInsuranceCost})
        Me.GrpShippingServiceOptions.Location = New System.Drawing.Point(48, 48)
        Me.GrpShippingServiceOptions.Name = "GrpShippingServiceOptions"
        Me.GrpShippingServiceOptions.Size = New System.Drawing.Size(376, 176)
        Me.GrpShippingServiceOptions.TabIndex = 99
        Me.GrpShippingServiceOptions.TabStop = False
        Me.GrpShippingServiceOptions.Text = "Shipping Service Options"
        '
        'TxtShippingServiceCost
        '
        Me.TxtShippingServiceCost.Location = New System.Drawing.Point(200, 80)
        Me.TxtShippingServiceCost.Name = "TxtShippingServiceCost"
        Me.TxtShippingServiceCost.Size = New System.Drawing.Size(136, 20)
        Me.TxtShippingServiceCost.TabIndex = 74
        Me.TxtShippingServiceCost.Text = "3.4"
        '
        'TxtShippingServicePriority
        '
        Me.TxtShippingServicePriority.Location = New System.Drawing.Point(200, 144)
        Me.TxtShippingServicePriority.Name = "TxtShippingServicePriority"
        Me.TxtShippingServicePriority.Size = New System.Drawing.Size(136, 20)
        Me.TxtShippingServicePriority.TabIndex = 78
        Me.TxtShippingServicePriority.Text = "1"
        '
        'LblShippingServiceCost
        '
        Me.LblShippingServiceCost.Location = New System.Drawing.Point(16, 80)
        Me.LblShippingServiceCost.Name = "LblShippingServiceCost"
        Me.LblShippingServiceCost.Size = New System.Drawing.Size(136, 23)
        Me.LblShippingServiceCost.TabIndex = 75
        Me.LblShippingServiceCost.Text = "Shipping Service Cost:"
        '
        'CboShippingService
        '
        Me.CboShippingService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboShippingService.Location = New System.Drawing.Point(200, 48)
        Me.CboShippingService.Name = "CboShippingService"
        Me.CboShippingService.Size = New System.Drawing.Size(136, 21)
        Me.CboShippingService.TabIndex = 73
        '
        'LblShippingService
        '
        Me.LblShippingService.Location = New System.Drawing.Point(16, 48)
        Me.LblShippingService.Name = "LblShippingService"
        Me.LblShippingService.Size = New System.Drawing.Size(96, 18)
        Me.LblShippingService.TabIndex = 72
        Me.LblShippingService.Text = "Shipping Service:"
        '
        'LblShippingServicePriority
        '
        Me.LblShippingServicePriority.Location = New System.Drawing.Point(16, 144)
        Me.LblShippingServicePriority.Name = "LblShippingServicePriority"
        Me.LblShippingServicePriority.Size = New System.Drawing.Size(136, 23)
        Me.LblShippingServicePriority.TabIndex = 79
        Me.LblShippingServicePriority.Text = "Shipping Service Priority:"
        '
        'TxtShippingServiceAdditionalCost
        '
        Me.TxtShippingServiceAdditionalCost.Location = New System.Drawing.Point(200, 112)
        Me.TxtShippingServiceAdditionalCost.Name = "TxtShippingServiceAdditionalCost"
        Me.TxtShippingServiceAdditionalCost.Size = New System.Drawing.Size(136, 20)
        Me.TxtShippingServiceAdditionalCost.TabIndex = 76
        Me.TxtShippingServiceAdditionalCost.Text = "2.14"
        '
        'LblShippingInsuranceCost
        '
        Me.LblShippingInsuranceCost.Location = New System.Drawing.Point(16, 24)
        Me.LblShippingInsuranceCost.Name = "LblShippingInsuranceCost"
        Me.LblShippingInsuranceCost.Size = New System.Drawing.Size(136, 23)
        Me.LblShippingInsuranceCost.TabIndex = 71
        Me.LblShippingInsuranceCost.Text = "Shipping Insurance Cost:"
        '
        'LblShippingServiceAdditionalCost
        '
        Me.LblShippingServiceAdditionalCost.Location = New System.Drawing.Point(16, 112)
        Me.LblShippingServiceAdditionalCost.Name = "LblShippingServiceAdditionalCost"
        Me.LblShippingServiceAdditionalCost.Size = New System.Drawing.Size(176, 23)
        Me.LblShippingServiceAdditionalCost.TabIndex = 77
        Me.LblShippingServiceAdditionalCost.Text = "Shipping Service Additional Cost:"
        '
        'TxtShippingInsuranceCost
        '
        Me.TxtShippingInsuranceCost.Location = New System.Drawing.Point(200, 24)
        Me.TxtShippingInsuranceCost.Name = "TxtShippingInsuranceCost"
        Me.TxtShippingInsuranceCost.Size = New System.Drawing.Size(136, 20)
        Me.TxtShippingInsuranceCost.TabIndex = 70
        Me.TxtShippingInsuranceCost.Text = "0"
        '
        'ChkEmailCopyToSeller
        '
        Me.ChkEmailCopyToSeller.Location = New System.Drawing.Point(48, 528)
        Me.ChkEmailCopyToSeller.Name = "ChkEmailCopyToSeller"
        Me.ChkEmailCopyToSeller.Size = New System.Drawing.Size(136, 24)
        Me.ChkEmailCopyToSeller.TabIndex = 98
        Me.ChkEmailCopyToSeller.Text = "Email Copy To Seller"
        '
        'TxtCheckoutInstructions
        '
        Me.TxtCheckoutInstructions.Location = New System.Drawing.Point(184, 496)
        Me.TxtCheckoutInstructions.Name = "TxtCheckoutInstructions"
        Me.TxtCheckoutInstructions.Size = New System.Drawing.Size(240, 20)
        Me.TxtCheckoutInstructions.TabIndex = 96
        Me.TxtCheckoutInstructions.Text = ""
        '
        'LblCheckoutInstructions
        '
        Me.LblCheckoutInstructions.Location = New System.Drawing.Point(48, 496)
        Me.LblCheckoutInstructions.Name = "LblCheckoutInstructions"
        Me.LblCheckoutInstructions.Size = New System.Drawing.Size(120, 18)
        Me.LblCheckoutInstructions.TabIndex = 97
        Me.LblCheckoutInstructions.Text = "Checkout Instructions:"
        '
        'TxtPayPalEmailAddress
        '
        Me.TxtPayPalEmailAddress.Location = New System.Drawing.Point(184, 464)
        Me.TxtPayPalEmailAddress.Name = "TxtPayPalEmailAddress"
        Me.TxtPayPalEmailAddress.Size = New System.Drawing.Size(240, 20)
        Me.TxtPayPalEmailAddress.TabIndex = 94
        Me.TxtPayPalEmailAddress.Text = "test@my.com"
        '
        'LblPayPalEmailAddress
        '
        Me.LblPayPalEmailAddress.Location = New System.Drawing.Point(48, 464)
        Me.LblPayPalEmailAddress.Name = "LblPayPalEmailAddress"
        Me.LblPayPalEmailAddress.Size = New System.Drawing.Size(120, 18)
        Me.LblPayPalEmailAddress.TabIndex = 95
        Me.LblPayPalEmailAddress.Text = "PayPal Email Address:"
        '
        'CboPaymentMethod
        '
        Me.CboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPaymentMethod.Location = New System.Drawing.Point(184, 432)
        Me.CboPaymentMethod.Name = "CboPaymentMethod"
        Me.CboPaymentMethod.Size = New System.Drawing.Size(240, 21)
        Me.CboPaymentMethod.TabIndex = 93
        '
        'LblPaymentMethod
        '
        Me.LblPaymentMethod.Location = New System.Drawing.Point(48, 432)
        Me.LblPaymentMethod.Name = "LblPaymentMethod"
        Me.LblPaymentMethod.Size = New System.Drawing.Size(96, 18)
        Me.LblPaymentMethod.TabIndex = 92
        Me.LblPaymentMethod.Text = "Payment Method:"
        '
        'TxtInsuranceFee
        '
        Me.TxtInsuranceFee.Location = New System.Drawing.Point(376, 400)
        Me.TxtInsuranceFee.Name = "TxtInsuranceFee"
        Me.TxtInsuranceFee.Size = New System.Drawing.Size(48, 20)
        Me.TxtInsuranceFee.TabIndex = 90
        Me.TxtInsuranceFee.Text = "3.14"
        '
        'lblInsuranceFee
        '
        Me.lblInsuranceFee.Location = New System.Drawing.Point(296, 400)
        Me.lblInsuranceFee.Name = "lblInsuranceFee"
        Me.lblInsuranceFee.Size = New System.Drawing.Size(80, 23)
        Me.lblInsuranceFee.TabIndex = 91
        Me.lblInsuranceFee.Text = "Insurance Fee:"
        '
        'TxtTransactionId
        '
        Me.TxtTransactionId.Location = New System.Drawing.Point(312, 16)
        Me.TxtTransactionId.Name = "TxtTransactionId"
        Me.TxtTransactionId.Size = New System.Drawing.Size(112, 20)
        Me.TxtTransactionId.TabIndex = 88
        Me.TxtTransactionId.Text = ""
        '
        'LblTransactionId
        '
        Me.LblTransactionId.Location = New System.Drawing.Point(216, 16)
        Me.LblTransactionId.Name = "LblTransactionId"
        Me.LblTransactionId.Size = New System.Drawing.Size(80, 23)
        Me.LblTransactionId.TabIndex = 89
        Me.LblTransactionId.Text = "Transaction Id:"
        '
        'CboInsuranceOption
        '
        Me.CboInsuranceOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboInsuranceOption.Location = New System.Drawing.Point(144, 400)
        Me.CboInsuranceOption.Name = "CboInsuranceOption"
        Me.CboInsuranceOption.Size = New System.Drawing.Size(144, 21)
        Me.CboInsuranceOption.TabIndex = 87
        '
        'LblInsuranceOption
        '
        Me.LblInsuranceOption.Location = New System.Drawing.Point(48, 400)
        Me.LblInsuranceOption.Name = "LblInsuranceOption"
        Me.LblInsuranceOption.Size = New System.Drawing.Size(96, 18)
        Me.LblInsuranceOption.TabIndex = 86
        Me.LblInsuranceOption.Text = "Insurance Option:"
        '
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(104, 16)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.Size = New System.Drawing.Size(104, 20)
        Me.TxtItemId.TabIndex = 84
        Me.TxtItemId.Text = ""
        '
        'LblItemId
        '
        Me.LblItemId.Location = New System.Drawing.Point(48, 16)
        Me.LblItemId.Name = "LblItemId"
        Me.LblItemId.Size = New System.Drawing.Size(48, 23)
        Me.LblItemId.TabIndex = 85
        Me.LblItemId.Text = "Item Id:"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblStatus, Me.TxtStatus})
        Me.GrpResult.Location = New System.Drawing.Point(40, 600)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(352, 64)
        Me.GrpResult.TabIndex = 83
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblStatus
        '
        Me.LblStatus.Location = New System.Drawing.Point(16, 24)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(80, 23)
        Me.LblStatus.TabIndex = 42
        Me.LblStatus.Text = "Status:"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(96, 24)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(72, 20)
        Me.TxtStatus.TabIndex = 41
        Me.TxtStatus.Text = ""
        '
        'BtnSendInvoice
        '
        Me.BtnSendInvoice.Location = New System.Drawing.Point(160, 568)
        Me.BtnSendInvoice.Name = "BtnSendInvoice"
        Me.BtnSendInvoice.Size = New System.Drawing.Size(120, 23)
        Me.BtnSendInvoice.TabIndex = 82
        Me.BtnSendInvoice.Text = "SendInvoice"
        '
        'FormSendInvoice
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 681)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GrpSaleTaxType, Me.GrpShippingServiceOptions, Me.ChkEmailCopyToSeller, Me.TxtCheckoutInstructions, Me.LblCheckoutInstructions, Me.TxtPayPalEmailAddress, Me.LblPayPalEmailAddress, Me.CboPaymentMethod, Me.LblPaymentMethod, Me.TxtInsuranceFee, Me.lblInsuranceFee, Me.TxtTransactionId, Me.LblTransactionId, Me.CboInsuranceOption, Me.LblInsuranceOption, Me.TxtItemId, Me.LblItemId, Me.GrpResult, Me.BtnSendInvoice})
        Me.Name = "FormSendInvoice"
        Me.Text = "SendInvoice"
        Me.GrpSaleTaxType.ResumeLayout(False)
        Me.GrpShippingServiceOptions.ResumeLayout(False)
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


		Public Context As ApiContext

		Private Sub FrmSendInvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim shippingservice As Type = GetType(ShippingServiceCodeType)
        Dim rsn As String
        For Each rsn In [Enum].GetNames(shippingservice)
            If rsn <> "CustomCode" Then
                CboShippingService.Items.Add(rsn)
            End If
        Next rsn
        CboShippingService.SelectedIndex = 0

        Dim insuranceoption As Type = GetType(InsuranceOptionCodeType)
        For Each rsn In [Enum].GetNames(insuranceoption)
            If rsn <> "CustomCode" Then
                CboInsuranceOption.Items.Add(rsn)
            End If
        Next rsn
        CboInsuranceOption.SelectedIndex = 0

        Dim paymentmethod As Type = GetType(BuyerPaymentMethodCodeType)
        For Each rsn In [Enum].GetNames(paymentmethod)
            If rsn <> "CustomCode" Then
                CboPaymentMethod.Items.Add(rsn)
            End If
        Next rsn
        CboPaymentMethod.SelectedIndex = 0
    End Sub


    Private Sub BtnSendInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendInvoice.Click
		Try
			Dim ApiCall As SendInvoiceCall = New SendInvoiceCall(Context)
			

			TxtStatus.Text = ""
			Dim ItemID As String  = TxtItemId.Text
			Dim TransactionID As String = TxtTransactionId.Text

			Dim ShippingServiceOptionsList As ShippingServiceOptionsTypeCollection = New ShippingServiceOptionsTypeCollection()
			Dim ShippingServiceOption As ShippingServiceOptionsType = New ShippingServiceOptionsType()
			ShippingServiceOptionsList.Add(ShippingServiceOption)

			
            ShippingServiceOption.ShippingInsuranceCost = New AmountType()
            ShippingServiceOption.ShippingInsuranceCost.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
            ShippingServiceOption.ShippingInsuranceCost.Value = Convert.ToDouble(TxtShippingInsuranceCost.Text)
					
            ShippingServiceOption.ShippingService = CboShippingService.SelectedItem.ToString()

            ShippingServiceOption.ShippingServiceCost = New AmountType()
            ShippingServiceOption.ShippingServiceCost.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
            ShippingServiceOption.ShippingServiceCost.Value = Convert.ToDouble(TxtShippingServiceCost.Text)
				
            ShippingServiceOption.ShippingServiceAdditionalCost = New AmountType()
            ShippingServiceOption.ShippingServiceAdditionalCost.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
            ShippingServiceOption.ShippingServiceAdditionalCost.Value = Convert.ToDouble(TxtShippingServiceAdditionalCost.Text)
			
            ShippingServiceOption.ShippingServicePriority = Int32.Parse(TxtShippingServicePriority.Text)

            'SaleTaxType related
            ApiCall.SalesTax = New SalesTaxType()
            ApiCall.SalesTax.SalesTaxPercent = Convert.ToDouble(TxtSalesTaxPercent.Text)
            ApiCall.SalesTax.SalesTaxState = TxtSalesTaxState.Text
            ApiCall.SalesTax.ShippingIncludedInTax = ChkShippingIncludedInTax.Checked

            ApiCall.SalesTax.SalesTaxAmount() = New AmountType()
            ApiCall.SalesTax.SalesTaxAmount.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
            ApiCall.SalesTax.SalesTaxAmount.Value = Convert.ToDouble(TxtSalesTaxAmount.Text)
        
            ApiCall.InsuranceOption = [Enum].Parse(GetType(InsuranceOptionCodeType), CboInsuranceOption.SelectedItem.ToString())

            ApiCall.InsuranceFee = New AmountType()
            ApiCall.InsuranceFee.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
            ApiCall.InsuranceFee.Value = Convert.ToDouble(TxtInsuranceFee.Text)

            ApiCall.PaymentMethodsList = New BuyerPaymentMethodCodeTypeCollection()
            ApiCall.PaymentMethodsList.Add([Enum].Parse(GetType(BuyerPaymentMethodCodeType), CboPaymentMethod.SelectedItem.ToString()))
				
            ApiCall.PayPalEmailAddress = TxtPayPalEmailAddress.Text
            ApiCall.CheckoutInstructions = TxtCheckoutInstructions.Text
            ApiCall.EmailCopyToSeller = ChkEmailCopyToSeller.Checked

            ApiCall.SendInvoice(ItemID, TransactionID, ShippingServiceOptionsList)
            TxtStatus.Text = ApiCall.ApiResponse.Ack.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
End Class

