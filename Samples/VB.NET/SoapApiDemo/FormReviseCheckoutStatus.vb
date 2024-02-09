Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormReviseCheckoutStatus
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
    Private WithEvents GrpResult As System.Windows.Forms.GroupBox
    Private WithEvents TxtItemId As System.Windows.Forms.TextBox
    Private WithEvents LblItemId As System.Windows.Forms.Label
    Private WithEvents TxtStatus As System.Windows.Forms.TextBox
    Private WithEvents LblStatus As System.Windows.Forms.Label
    Private WithEvents BtnReviseCheckoutStatus As System.Windows.Forms.Button
    Private WithEvents CboCheckoutStatus As System.Windows.Forms.ComboBox
    Private WithEvents LblCheckoutStatus As System.Windows.Forms.Label
    Private WithEvents CboPaymentMethod As System.Windows.Forms.ComboBox
    Private WithEvents LblPaymentMethod As System.Windows.Forms.Label
    Private WithEvents CboShipSvc As System.Windows.Forms.ComboBox
    Private WithEvents LblShipSvc As System.Windows.Forms.Label
    Private WithEvents TxtTransactionId As System.Windows.Forms.TextBox
    Private WithEvents LblTransactionId As System.Windows.Forms.Label
    Private WithEvents TxtOrderId As System.Windows.Forms.TextBox
    Private WithEvents LblOrderId As System.Windows.Forms.Label
    Private WithEvents TxtAmountPaid As System.Windows.Forms.TextBox
    Friend WithEvents OptOrder As System.Windows.Forms.RadioButton
    Friend WithEvents OptItem As System.Windows.Forms.RadioButton
    Private WithEvents LblAmount As System.Windows.Forms.Label








































		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnReviseCheckoutStatus = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.TxtItemId = New System.Windows.Forms.TextBox()
        Me.LblItemId = New System.Windows.Forms.Label()
        Me.CboCheckoutStatus = New System.Windows.Forms.ComboBox()
        Me.LblCheckoutStatus = New System.Windows.Forms.Label()
        Me.CboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.LblPaymentMethod = New System.Windows.Forms.Label()
        Me.CboShipSvc = New System.Windows.Forms.ComboBox()
        Me.LblShipSvc = New System.Windows.Forms.Label()
        Me.TxtTransactionId = New System.Windows.Forms.TextBox()
        Me.LblTransactionId = New System.Windows.Forms.Label()
        Me.TxtOrderId = New System.Windows.Forms.TextBox()
        Me.LblOrderId = New System.Windows.Forms.Label()
        Me.TxtAmountPaid = New System.Windows.Forms.TextBox()
        Me.LblAmount = New System.Windows.Forms.Label()
        Me.OptOrder = New System.Windows.Forms.RadioButton()
        Me.OptItem = New System.Windows.Forms.RadioButton()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnReviseCheckoutStatus
        '
        Me.BtnReviseCheckoutStatus.Location = New System.Drawing.Point(136, 176)
        Me.BtnReviseCheckoutStatus.Name = "BtnReviseCheckoutStatus"
        Me.BtnReviseCheckoutStatus.Size = New System.Drawing.Size(144, 23)
        Me.BtnReviseCheckoutStatus.TabIndex = 23
        Me.BtnReviseCheckoutStatus.Text = "ReviseCheckoutStatus"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblStatus, Me.TxtStatus})
        Me.GrpResult.Location = New System.Drawing.Point(40, 208)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(352, 64)
        Me.GrpResult.TabIndex = 25
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
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(176, 8)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.Size = New System.Drawing.Size(80, 20)
        Me.TxtItemId.TabIndex = 26
        Me.TxtItemId.Text = ""
        '
        'LblItemId
        '
        Me.LblItemId.Location = New System.Drawing.Point(104, 8)
        Me.LblItemId.Name = "LblItemId"
        Me.LblItemId.Size = New System.Drawing.Size(72, 23)
        Me.LblItemId.TabIndex = 27
        Me.LblItemId.Text = "Item Id:"
        '
        'CboCheckoutStatus
        '
        Me.CboCheckoutStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCheckoutStatus.Location = New System.Drawing.Point(176, 88)
        Me.CboCheckoutStatus.Name = "CboCheckoutStatus"
        Me.CboCheckoutStatus.Size = New System.Drawing.Size(144, 21)
        Me.CboCheckoutStatus.TabIndex = 55
        '
        'LblCheckoutStatus
        '
        Me.LblCheckoutStatus.Location = New System.Drawing.Point(64, 88)
        Me.LblCheckoutStatus.Name = "LblCheckoutStatus"
        Me.LblCheckoutStatus.Size = New System.Drawing.Size(112, 18)
        Me.LblCheckoutStatus.TabIndex = 54
        Me.LblCheckoutStatus.Text = "Status:"
        '
        'CboPaymentMethod
        '
        Me.CboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPaymentMethod.Location = New System.Drawing.Point(176, 112)
        Me.CboPaymentMethod.Name = "CboPaymentMethod"
        Me.CboPaymentMethod.Size = New System.Drawing.Size(144, 21)
        Me.CboPaymentMethod.TabIndex = 57
        '
        'LblPaymentMethod
        '
        Me.LblPaymentMethod.Location = New System.Drawing.Point(64, 112)
        Me.LblPaymentMethod.Name = "LblPaymentMethod"
        Me.LblPaymentMethod.Size = New System.Drawing.Size(112, 18)
        Me.LblPaymentMethod.TabIndex = 56
        Me.LblPaymentMethod.Text = "Payment Method:"
        '
        'CboShipSvc
        '
        Me.CboShipSvc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboShipSvc.Location = New System.Drawing.Point(176, 136)
        Me.CboShipSvc.Name = "CboShipSvc"
        Me.CboShipSvc.Size = New System.Drawing.Size(144, 21)
        Me.CboShipSvc.TabIndex = 59
        '
        'LblShipSvc
        '
        Me.LblShipSvc.Location = New System.Drawing.Point(64, 136)
        Me.LblShipSvc.Name = "LblShipSvc"
        Me.LblShipSvc.Size = New System.Drawing.Size(112, 18)
        Me.LblShipSvc.TabIndex = 58
        Me.LblShipSvc.Text = "Shipping:"
        '
        'TxtTransactionId
        '
        Me.TxtTransactionId.Location = New System.Drawing.Point(344, 8)
        Me.TxtTransactionId.Name = "TxtTransactionId"
        Me.TxtTransactionId.Size = New System.Drawing.Size(80, 20)
        Me.TxtTransactionId.TabIndex = 60
        Me.TxtTransactionId.Text = ""
        '
        'LblTransactionId
        '
        Me.LblTransactionId.Location = New System.Drawing.Point(264, 8)
        Me.LblTransactionId.Name = "LblTransactionId"
        Me.LblTransactionId.Size = New System.Drawing.Size(80, 23)
        Me.LblTransactionId.TabIndex = 61
        Me.LblTransactionId.Text = "Transaction Id:"
        '
        'TxtOrderId
        '
        Me.TxtOrderId.Location = New System.Drawing.Point(176, 32)
        Me.TxtOrderId.Name = "TxtOrderId"
        Me.TxtOrderId.Size = New System.Drawing.Size(80, 20)
        Me.TxtOrderId.TabIndex = 62
        Me.TxtOrderId.Text = ""
        '
        'LblOrderId
        '
        Me.LblOrderId.Location = New System.Drawing.Point(104, 32)
        Me.LblOrderId.Name = "LblOrderId"
        Me.LblOrderId.Size = New System.Drawing.Size(56, 23)
        Me.LblOrderId.TabIndex = 63
        Me.LblOrderId.Text = "Order Id:"
        '
        'TxtAmountPaid
        '
        Me.TxtAmountPaid.Location = New System.Drawing.Point(176, 64)
        Me.TxtAmountPaid.Name = "TxtAmountPaid"
        Me.TxtAmountPaid.Size = New System.Drawing.Size(80, 20)
        Me.TxtAmountPaid.TabIndex = 64
        Me.TxtAmountPaid.Text = ""
        '
        'LblAmount
        '
        Me.LblAmount.Location = New System.Drawing.Point(64, 64)
        Me.LblAmount.Name = "LblAmount"
        Me.LblAmount.Size = New System.Drawing.Size(112, 23)
        Me.LblAmount.TabIndex = 65
        Me.LblAmount.Text = "Amount Paid:"
        '
        'OptOrder
        '
        Me.OptOrder.Location = New System.Drawing.Point(8, 32)
        Me.OptOrder.Name = "OptOrder"
        Me.OptOrder.Size = New System.Drawing.Size(96, 24)
        Me.OptOrder.TabIndex = 70
        Me.OptOrder.Text = "Revise Order:"
        '
        'OptItem
        '
        Me.OptItem.Location = New System.Drawing.Point(8, 8)
        Me.OptItem.Name = "OptItem"
        Me.OptItem.Size = New System.Drawing.Size(96, 24)
        Me.OptItem.TabIndex = 69
        Me.OptItem.Text = "Revise Item:"
        '
        'FormReviseCheckoutStatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 293)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.OptOrder, Me.OptItem, Me.TxtAmountPaid, Me.LblAmount, Me.TxtOrderId, Me.LblOrderId, Me.TxtTransactionId, Me.LblTransactionId, Me.CboShipSvc, Me.LblShipSvc, Me.CboPaymentMethod, Me.LblPaymentMethod, Me.CboCheckoutStatus, Me.LblCheckoutStatus, Me.TxtItemId, Me.LblItemId, Me.GrpResult, Me.BtnReviseCheckoutStatus})
        Me.Name = "FormReviseCheckoutStatus"
        Me.Text = "ReviseCheckoutStatus"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub FrmReviseCheckoutStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim paymethods() As String = [Enum].GetNames(GetType(BuyerPaymentMethodCodeType))
        Dim pay As String

        For Each pay In paymethods
            If pay <> "CustomCode" Then
                CboPaymentMethod.Items.Add(pay)
            End If
        Next pay

        CboPaymentMethod.SelectedIndex = 0

        Dim svcs() As String = [Enum].GetNames(GetType(ShippingServiceCodeType))
        Dim svc As String

        For Each svc In svcs

            If svc <> "CustomCode" Then
                CboShipSvc.Items.Add(svc)

            End If

        Next svc

        CboShipSvc.SelectedIndex = 0

        Dim statuses() As String = [Enum].GetNames(GetType(CompleteStatusCodeType))
        Dim stat As String

        For Each stat In statuses

            If stat <> "CustomCode" Then
                CboCheckoutStatus.Items.Add(stat)
            End If

        Next stat

        CboCheckoutStatus.SelectedIndex = 0

        OptItem.Select()
    End Sub

    Private Sub BtnReviseCheckoutStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReviseCheckoutStatus.Click
        Try
            TxtStatus.Text = ""
            Dim ApiCall As ReviseCheckoutStatusCall = New ReviseCheckoutStatusCall(Context)

            ApiCall.PaymentMethodUsed = [Enum].Parse(GetType(BuyerPaymentMethodCodeType), CboPaymentMethod.SelectedItem.ToString())

            If TxtAmountPaid.Text <> String.Empty Then
                ApiCall.AmountPaid = New AmountType()

                ApiCall.AmountPaid.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)

                ApiCall.AmountPaid.Value = Convert.ToDouble(TxtAmountPaid.Text)

            End If
            ApiCall.ShippingService = CboShipSvc.SelectedItem.ToString()

            If OptItem.Checked Then
                ApiCall.ReviseCheckoutStatus(TxtItemId.Text, TxtTransactionId.Text, [Enum].Parse(GetType(CompleteStatusCodeType), CboCheckoutStatus.SelectedItem.ToString()))
            Else
                ApiCall.ReviseCheckoutStatus(TxtOrderId.Text, [Enum].Parse(GetType(CompleteStatusCodeType), CboCheckoutStatus.SelectedItem.ToString()))
            End If

            TxtStatus.Text = ApiCall.ApiResponse.Ack.ToString()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub OptItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptItem.CheckedChanged
        TxtItemId.Enabled = True
        TxtTransactionId.Enabled = True
        TxtOrderId.Enabled = False
    End Sub

    Private Sub OptOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptOrder.CheckedChanged
        TxtItemId.Enabled = False
        TxtTransactionId.Enabled = False
        TxtOrderId.Enabled = True

    End Sub
End Class

