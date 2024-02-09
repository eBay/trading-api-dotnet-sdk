Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormAddOrder
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



		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents BtnAddOrder As System.Windows.Forms.Button 

		Friend WithEvents TxtItemIdOne As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemIdOne As System.Windows.Forms.Label 

		Friend WithEvents CboShipSvc As System.Windows.Forms.ComboBox 

		Friend WithEvents LblShipSvc As System.Windows.Forms.Label 

		Friend WithEvents TxtTransactionIdOne As System.Windows.Forms.TextBox 

		Friend WithEvents LblTransactionIdOne As System.Windows.Forms.Label 

		Friend WithEvents TxtTransactionIdTwo As System.Windows.Forms.TextBox 

		Friend WithEvents LblTransactionIdTwo As System.Windows.Forms.Label 

		Friend WithEvents TxtItemIdTwo As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemIdTwo As System.Windows.Forms.Label 

		Friend WithEvents TxtShipCost As System.Windows.Forms.TextBox 

		Friend WithEvents LblShipCost As System.Windows.Forms.Label 

		Friend WithEvents TxtPaymentInstructions As System.Windows.Forms.TextBox 

		Friend WithEvents LblPaymentInstructions As System.Windows.Forms.Label 

		Friend WithEvents LblOrderId As System.Windows.Forms.Label 

		Friend WithEvents TxtOrderId As System.Windows.Forms.TextBox 

		Friend WithEvents TxtTotal As System.Windows.Forms.TextBox 

		Friend WithEvents LblTotal As System.Windows.Forms.Label 

		Friend WithEvents CboRole As System.Windows.Forms.ComboBox 

		Friend WithEvents LblUserRole As System.Windows.Forms.Label 



		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnAddOrder = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblOrderId = New System.Windows.Forms.Label()
        Me.TxtOrderId = New System.Windows.Forms.TextBox()
        Me.TxtItemIdOne = New System.Windows.Forms.TextBox()
        Me.LblItemIdOne = New System.Windows.Forms.Label()
        Me.CboShipSvc = New System.Windows.Forms.ComboBox()
        Me.LblShipSvc = New System.Windows.Forms.Label()
        Me.TxtTransactionIdOne = New System.Windows.Forms.TextBox()
        Me.LblTransactionIdOne = New System.Windows.Forms.Label()
        Me.TxtTransactionIdTwo = New System.Windows.Forms.TextBox()
        Me.LblTransactionIdTwo = New System.Windows.Forms.Label()
        Me.TxtItemIdTwo = New System.Windows.Forms.TextBox()
        Me.LblItemIdTwo = New System.Windows.Forms.Label()
        Me.TxtShipCost = New System.Windows.Forms.TextBox()
        Me.LblShipCost = New System.Windows.Forms.Label()
        Me.TxtPaymentInstructions = New System.Windows.Forms.TextBox()
        Me.LblPaymentInstructions = New System.Windows.Forms.Label()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.CboRole = New System.Windows.Forms.ComboBox()
        Me.LblUserRole = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnAddOrder
        '
        Me.BtnAddOrder.Location = New System.Drawing.Point(120, 240)
        Me.BtnAddOrder.Name = "BtnAddOrder"
        Me.BtnAddOrder.Size = New System.Drawing.Size(112, 23)
        Me.BtnAddOrder.TabIndex = 56
        Me.BtnAddOrder.Text = "AddOrder"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblOrderId, Me.TxtOrderId})
        Me.GrpResult.Location = New System.Drawing.Point(16, 272)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(352, 64)
        Me.GrpResult.TabIndex = 25
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblOrderId
        '
        Me.LblOrderId.Location = New System.Drawing.Point(16, 24)
        Me.LblOrderId.Name = "LblOrderId"
        Me.LblOrderId.Size = New System.Drawing.Size(80, 23)
        Me.LblOrderId.TabIndex = 42
        Me.LblOrderId.Text = "Order Id:"
        '
        'TxtOrderId
        '
        Me.TxtOrderId.Location = New System.Drawing.Point(96, 24)
        Me.TxtOrderId.Name = "TxtOrderId"
        Me.TxtOrderId.ReadOnly = True
        Me.TxtOrderId.Size = New System.Drawing.Size(104, 20)
        Me.TxtOrderId.TabIndex = 41
        Me.TxtOrderId.Text = ""
        '
        'TxtItemIdOne
        '
        Me.TxtItemIdOne.Location = New System.Drawing.Point(96, 8)
        Me.TxtItemIdOne.Name = "TxtItemIdOne"
        Me.TxtItemIdOne.Size = New System.Drawing.Size(80, 20)
        Me.TxtItemIdOne.TabIndex = 26
        Me.TxtItemIdOne.Text = ""
        '
        'LblItemIdOne
        '
        Me.LblItemIdOne.Location = New System.Drawing.Point(16, 8)
        Me.LblItemIdOne.Name = "LblItemIdOne"
        Me.LblItemIdOne.Size = New System.Drawing.Size(80, 23)
        Me.LblItemIdOne.TabIndex = 27
        Me.LblItemIdOne.Text = "Item Id:"
        '
        'CboShipSvc
        '
        Me.CboShipSvc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboShipSvc.Location = New System.Drawing.Point(96, 80)
        Me.CboShipSvc.Name = "CboShipSvc"
        Me.CboShipSvc.Size = New System.Drawing.Size(256, 21)
        Me.CboShipSvc.TabIndex = 55
        '
        'LblShipSvc
        '
        Me.LblShipSvc.Location = New System.Drawing.Point(16, 80)
        Me.LblShipSvc.Name = "LblShipSvc"
        Me.LblShipSvc.Size = New System.Drawing.Size(80, 18)
        Me.LblShipSvc.TabIndex = 54
        Me.LblShipSvc.Text = "Service:"
        '
        'TxtTransactionIdOne
        '
        Me.TxtTransactionIdOne.Location = New System.Drawing.Point(272, 8)
        Me.TxtTransactionIdOne.Name = "TxtTransactionIdOne"
        Me.TxtTransactionIdOne.Size = New System.Drawing.Size(80, 20)
        Me.TxtTransactionIdOne.TabIndex = 57
        Me.TxtTransactionIdOne.Text = ""
        '
        'LblTransactionIdOne
        '
        Me.LblTransactionIdOne.Location = New System.Drawing.Point(192, 8)
        Me.LblTransactionIdOne.Name = "LblTransactionIdOne"
        Me.LblTransactionIdOne.Size = New System.Drawing.Size(80, 23)
        Me.LblTransactionIdOne.TabIndex = 58
        Me.LblTransactionIdOne.Text = "Transaction Id:"
        '
        'TxtTransactionIdTwo
        '
        Me.TxtTransactionIdTwo.Location = New System.Drawing.Point(272, 32)
        Me.TxtTransactionIdTwo.Name = "TxtTransactionIdTwo"
        Me.TxtTransactionIdTwo.Size = New System.Drawing.Size(80, 20)
        Me.TxtTransactionIdTwo.TabIndex = 61
        Me.TxtTransactionIdTwo.Text = ""
        '
        'LblTransactionIdTwo
        '
        Me.LblTransactionIdTwo.Location = New System.Drawing.Point(192, 32)
        Me.LblTransactionIdTwo.Name = "LblTransactionIdTwo"
        Me.LblTransactionIdTwo.Size = New System.Drawing.Size(80, 23)
        Me.LblTransactionIdTwo.TabIndex = 62
        Me.LblTransactionIdTwo.Text = "Transaction Id:"
        '
        'TxtItemIdTwo
        '
        Me.TxtItemIdTwo.Location = New System.Drawing.Point(96, 32)
        Me.TxtItemIdTwo.Name = "TxtItemIdTwo"
        Me.TxtItemIdTwo.Size = New System.Drawing.Size(80, 20)
        Me.TxtItemIdTwo.TabIndex = 63
        Me.TxtItemIdTwo.Text = ""
        '
        'LblItemIdTwo
        '
        Me.LblItemIdTwo.Location = New System.Drawing.Point(16, 32)
        Me.LblItemIdTwo.Name = "LblItemIdTwo"
        Me.LblItemIdTwo.Size = New System.Drawing.Size(80, 23)
        Me.LblItemIdTwo.TabIndex = 64
        Me.LblItemIdTwo.Text = "Item Id:"
        '
        'TxtShipCost
        '
        Me.TxtShipCost.Location = New System.Drawing.Point(96, 104)
        Me.TxtShipCost.Name = "TxtShipCost"
        Me.TxtShipCost.Size = New System.Drawing.Size(80, 20)
        Me.TxtShipCost.TabIndex = 65
        Me.TxtShipCost.Text = ""
        '
        'LblShipCost
        '
        Me.LblShipCost.Location = New System.Drawing.Point(16, 104)
        Me.LblShipCost.Name = "LblShipCost"
        Me.LblShipCost.Size = New System.Drawing.Size(80, 23)
        Me.LblShipCost.TabIndex = 66
        Me.LblShipCost.Text = "Shipping Cost:"
        '
        'TxtPaymentInstructions
        '
        Me.TxtPaymentInstructions.Location = New System.Drawing.Point(96, 128)
        Me.TxtPaymentInstructions.Multiline = True
        Me.TxtPaymentInstructions.Name = "TxtPaymentInstructions"
        Me.TxtPaymentInstructions.Size = New System.Drawing.Size(256, 80)
        Me.TxtPaymentInstructions.TabIndex = 67
        Me.TxtPaymentInstructions.Text = ""
        '
        'LblPaymentInstructions
        '
        Me.LblPaymentInstructions.Location = New System.Drawing.Point(16, 128)
        Me.LblPaymentInstructions.Name = "LblPaymentInstructions"
        Me.LblPaymentInstructions.Size = New System.Drawing.Size(80, 23)
        Me.LblPaymentInstructions.TabIndex = 68
        Me.LblPaymentInstructions.Text = "Instructions:"
        '
        'TxtTotal
        '
        Me.TxtTotal.Location = New System.Drawing.Point(96, 208)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(80, 20)
        Me.TxtTotal.TabIndex = 69
        Me.TxtTotal.Text = ""
        '
        'LblTotal
        '
        Me.LblTotal.Location = New System.Drawing.Point(16, 208)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(80, 23)
        Me.LblTotal.TabIndex = 70
        Me.LblTotal.Text = "Total Amount:"
        '
        'CboRole
        '
        Me.CboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRole.Location = New System.Drawing.Point(96, 56)
        Me.CboRole.Name = "CboRole"
        Me.CboRole.Size = New System.Drawing.Size(256, 21)
        Me.CboRole.TabIndex = 72
        '
        'LblUserRole
        '
        Me.LblUserRole.Location = New System.Drawing.Point(16, 56)
        Me.LblUserRole.Name = "LblUserRole"
        Me.LblUserRole.Size = New System.Drawing.Size(80, 18)
        Me.LblUserRole.TabIndex = 71
        Me.LblUserRole.Text = "Role:"
        '
        'FormAddOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(384, 341)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CboRole, Me.LblUserRole, Me.TxtTotal, Me.LblTotal, Me.TxtPaymentInstructions, Me.LblPaymentInstructions, Me.TxtShipCost, Me.LblShipCost, Me.TxtItemIdTwo, Me.LblItemIdTwo, Me.TxtTransactionIdTwo, Me.LblTransactionIdTwo, Me.TxtTransactionIdOne, Me.TxtItemIdOne, Me.LblTransactionIdOne, Me.CboShipSvc, Me.LblShipSvc, Me.LblItemIdOne, Me.GrpResult, Me.BtnAddOrder})
        Me.Name = "FormAddOrder"
        Me.Text = "AddOrder"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


		Public Context As ApiContext

		Private Sub  FrmAddOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		

			Dim shpsvcs As Type = GetType(ShippingServiceCodeType)
			Dim svc As String

			for each  svc in [Enum].GetNames(shpsvcs)

			

				If svc <> "CustomCode" Then

				

					CboShipSvc.Items.Add(svc)

				End If

			next svc

			CboShipSvc.SelectedIndex = 0



			Dim roles As Type = GetType(TradingRoleCodeType)
			Dim rol As String

			for each rol in [Enum].GetNames(roles)	

				If rol <> "CustomCode" Then

					CboRole.Items.Add(rol)

				end If

			next rol

			CboRole.SelectedIndex = 0

		end Sub

		

		

		Private Sub  BtnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOrder.Click

		

        Try

            TxtOrderId.Text = ""

            Dim apicall As AddOrderCall = New AddOrderCall(Context)

            Dim order As OrderType = New OrderType()
            order.TransactionArray = New TransactionTypeCollection()
            order.ShippingDetails = New ShippingDetailsType()
            order.PaymentMethods = New BuyerPaymentMethodCodeTypeCollection()

            Dim tr1 As TransactionType = New TransactionType()

            tr1.Item = New ItemType()

            tr1.Item.ItemID = TxtItemIdOne.Text

            tr1.TransactionID = TxtTransactionIdOne.Text

            order.TransactionArray.Add(tr1)



            Dim tr2 As TransactionType = New TransactionType()

            tr2.Item = New ItemType()

            tr2.Item.ItemID = TxtItemIdTwo.Text

            tr2.TransactionID = TxtTransactionIdTwo.Text

            order.TransactionArray.Add(tr2)


            order.ShippingDetails.PaymentInstructions = TxtPaymentInstructions.Text

            Dim shpopt As ShippingServiceOptionsType = New ShippingServiceOptionsType()

            shpopt.ShippingService = CboShipSvc.SelectedItem.ToString()

            shpopt.ShippingServicePriority = 1


            order.ShippingDetails.ShippingServiceOptions = New ShippingServiceOptionsTypeCollection()

            shpopt.ShippingServiceCost = New AmountType()

            shpopt.ShippingServiceCost.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)

            If TxtShipCost.Text.Length > 0 Then
                shpopt.ShippingServiceCost.Value = Convert.ToDouble(TxtShipCost.Text)
            End If

            order.ShippingDetails.ShippingServiceOptions.Add(shpopt)



            order.Total = New AmountType()
            order.Total.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
            If TxtTotal.Text.Length > 0 Then
                order.Total.Value = Convert.ToDouble(TxtTotal.Text)
            End If



            order.CreatingUserRole = [Enum].Parse(GetType(TradingRoleCodeType), CboRole.SelectedItem.ToString())


            order.PaymentMethods.Add(BuyerPaymentMethodCodeType.PaymentSeeDescription)

            Dim orderid As String = apicall.AddOrder(order)

            TxtOrderId.Text = orderid


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub CboShipSvc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboShipSvc.SelectedIndexChanged

    End Sub
End Class


