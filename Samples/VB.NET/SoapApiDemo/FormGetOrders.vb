Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetOrders
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

		Friend WithEvents BtnGetOrders As System.Windows.Forms.Button 

		Friend WithEvents ChkStartTo As System.Windows.Forms.CheckBox 

		Friend WithEvents ChkStartFrom As System.Windows.Forms.CheckBox 

		Friend WithEvents LblTimeRange As System.Windows.Forms.Label 

		Friend WithEvents CboRole As System.Windows.Forms.ComboBox 

		Friend WithEvents LblRole As System.Windows.Forms.Label 

		Friend WithEvents CboStatus As System.Windows.Forms.ComboBox 

		Friend WithEvents LblStatus As System.Windows.Forms.Label 

		Friend WithEvents DatePickStartTo As System.Windows.Forms.DateTimePicker 

		Friend WithEvents DatePickStartFrom As System.Windows.Forms.DateTimePicker 

		Friend WithEvents LblStartSep As System.Windows.Forms.Label 









		Friend WithEvents LblOrders As System.Windows.Forms.Label 

		Friend WithEvents LstOrders As System.Windows.Forms.ListView 

		Friend WithEvents ClmOrderId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmStatus As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmCreator As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmSaved As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmItems As System.Windows.Forms.ColumnHeader 

		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGetOrders = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblOrders = New System.Windows.Forms.Label()
        Me.LstOrders = New System.Windows.Forms.ListView()
        Me.ClmOrderId = New System.Windows.Forms.ColumnHeader()
        Me.ClmStatus = New System.Windows.Forms.ColumnHeader()
        Me.ClmCreator = New System.Windows.Forms.ColumnHeader()
        Me.ClmSaved = New System.Windows.Forms.ColumnHeader()
        Me.ClmItems = New System.Windows.Forms.ColumnHeader()
        Me.ChkStartTo = New System.Windows.Forms.CheckBox()
        Me.ChkStartFrom = New System.Windows.Forms.CheckBox()
        Me.LblTimeRange = New System.Windows.Forms.Label()
        Me.CboRole = New System.Windows.Forms.ComboBox()
        Me.LblRole = New System.Windows.Forms.Label()
        Me.CboStatus = New System.Windows.Forms.ComboBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.DatePickStartTo = New System.Windows.Forms.DateTimePicker()
        Me.DatePickStartFrom = New System.Windows.Forms.DateTimePicker()
        Me.LblStartSep = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGetOrders
        '
        Me.BtnGetOrders.Location = New System.Drawing.Point(200, 88)
        Me.BtnGetOrders.Name = "BtnGetOrders"
        Me.BtnGetOrders.Size = New System.Drawing.Size(128, 23)
        Me.BtnGetOrders.TabIndex = 9
        Me.BtnGetOrders.Text = "GetOrders"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblOrders, Me.LstOrders})
        Me.GrpResult.Location = New System.Drawing.Point(8, 128)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(544, 232)
        Me.GrpResult.TabIndex = 10
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblOrders
        '
        Me.LblOrders.Location = New System.Drawing.Point(8, 24)
        Me.LblOrders.Name = "LblOrders"
        Me.LblOrders.Size = New System.Drawing.Size(112, 23)
        Me.LblOrders.TabIndex = 12
        Me.LblOrders.Text = "Orders:"
        '
        'LstOrders
        '
        Me.LstOrders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmOrderId, Me.ClmStatus, Me.ClmCreator, Me.ClmSaved, Me.ClmItems})
        Me.LstOrders.GridLines = True
        Me.LstOrders.Location = New System.Drawing.Point(8, 56)
        Me.LstOrders.Name = "LstOrders"
        Me.LstOrders.Size = New System.Drawing.Size(520, 136)
        Me.LstOrders.TabIndex = 13
        Me.LstOrders.View = System.Windows.Forms.View.Details
        '
        'ClmOrderId
        '
        Me.ClmOrderId.Text = "Order Id"
        Me.ClmOrderId.Width = 95
        '
        'ClmStatus
        '
        Me.ClmStatus.Text = "Status"
        Me.ClmStatus.Width = 75
        '
        'ClmCreator
        '
        Me.ClmCreator.Text = "Creator"
        Me.ClmCreator.Width = 84
        '
        'ClmSaved
        '
        Me.ClmSaved.Text = "Amount Saved"
        Me.ClmSaved.Width = 91
        '
        'ClmItems
        '
        Me.ClmItems.Text = "Items"
        Me.ClmItems.Width = 162
        '
        'ChkStartTo
        '
        Me.ChkStartTo.Location = New System.Drawing.Point(280, 56)
        Me.ChkStartTo.Name = "ChkStartTo"
        Me.ChkStartTo.Size = New System.Drawing.Size(12, 24)
        Me.ChkStartTo.TabIndex = 93
        '
        'ChkStartFrom
        '
        Me.ChkStartFrom.Location = New System.Drawing.Point(96, 56)
        Me.ChkStartFrom.Name = "ChkStartFrom"
        Me.ChkStartFrom.Size = New System.Drawing.Size(12, 24)
        Me.ChkStartFrom.TabIndex = 92
        '
        'LblTimeRange
        '
        Me.LblTimeRange.Location = New System.Drawing.Point(16, 56)
        Me.LblTimeRange.Name = "LblTimeRange"
        Me.LblTimeRange.Size = New System.Drawing.Size(72, 16)
        Me.LblTimeRange.TabIndex = 91
        Me.LblTimeRange.Text = "Time Filter:"
        '
        'CboRole
        '
        Me.CboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRole.Location = New System.Drawing.Point(96, 32)
        Me.CboRole.Name = "CboRole"
        Me.CboRole.Size = New System.Drawing.Size(144, 21)
        Me.CboRole.TabIndex = 89
        '
        'LblRole
        '
        Me.LblRole.Location = New System.Drawing.Point(16, 32)
        Me.LblRole.Name = "LblRole"
        Me.LblRole.Size = New System.Drawing.Size(80, 18)
        Me.LblRole.TabIndex = 88
        Me.LblRole.Text = "Role:"
        '
        'CboStatus
        '
        Me.CboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboStatus.Location = New System.Drawing.Point(96, 8)
        Me.CboStatus.Name = "CboStatus"
        Me.CboStatus.Size = New System.Drawing.Size(144, 21)
        Me.CboStatus.TabIndex = 87
        '
        'LblStatus
        '
        Me.LblStatus.Location = New System.Drawing.Point(16, 8)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(80, 18)
        Me.LblStatus.TabIndex = 86
        Me.LblStatus.Text = "Status:"
        '
        'DatePickStartTo
        '
        Me.DatePickStartTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickStartTo.Location = New System.Drawing.Point(296, 56)
        Me.DatePickStartTo.Name = "DatePickStartTo"
        Me.DatePickStartTo.Size = New System.Drawing.Size(136, 20)
        Me.DatePickStartTo.TabIndex = 83
        '
        'DatePickStartFrom
        '
        Me.DatePickStartFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickStartFrom.Location = New System.Drawing.Point(112, 56)
        Me.DatePickStartFrom.Name = "DatePickStartFrom"
        Me.DatePickStartFrom.Size = New System.Drawing.Size(136, 20)
        Me.DatePickStartFrom.TabIndex = 82
        '
        'LblStartSep
        '
        Me.LblStartSep.Location = New System.Drawing.Point(256, 56)
        Me.LblStartSep.Name = "LblStartSep"
        Me.LblStartSep.Size = New System.Drawing.Size(16, 23)
        Me.LblStartSep.TabIndex = 81
        Me.LblStartSep.Text = " - "
        '
        'FormGetOrders
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(560, 365)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ChkStartTo, Me.ChkStartFrom, Me.LblTimeRange, Me.CboRole, Me.LblRole, Me.CboStatus, Me.LblStatus, Me.DatePickStartTo, Me.DatePickStartFrom, Me.LblStartSep, Me.GrpResult, Me.BtnGetOrders})
        Me.Name = "FormGetOrders"
        Me.Text = "GetOrders"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  FrmGetOrders_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim now As DateTime = DateTime.Now

			DatePickStartTo.Value = now

			DatePickStartFrom.Value = now.AddDays(-5)

			CboRole.Items.Add("NotSpecified")

			Dim roles() As String = [Enum].GetNames(GetType(TradingRoleCodeType))
			Dim rl As String

        For Each rl In roles
            If rl <> "CustomCode" Then
                CboRole.Items.Add(rl)
            End If

        Next rl

        CboRole.SelectedIndex = 0
        CboStatus.Items.Add("NotSpecified")

        Dim statie() As String = [Enum].GetNames(GetType(OrderStatusCodeType))
        Dim stat As String

        For Each stat In statie

            If stat <> "CustomCode" Then
                CboStatus.Items.Add(stat)
            End If

        Next stat

        CboStatus.SelectedIndex = 0

		End Sub


		Private Sub  BtnGetOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetOrders.Click

		

        Try

            LstOrders.Items.Clear()
            Dim apicall As GetOrdersCall = New GetOrdersCall(Context)


            Dim fltr As TimeFilter = New TimeFilter()

            If ChkStartFrom.Checked Then
                fltr.TimeFrom = DatePickStartFrom.Value
            End If



            If ChkStartTo.Checked Then
                fltr.TimeTo = DatePickStartTo.Value
            End If


            Dim orders As OrderTypeCollection = apicall.GetOrders(fltr, [Enum].Parse(GetType(TradingRoleCodeType), CboRole.SelectedItem.ToString()), [Enum].Parse(GetType(OrderStatusCodeType), CboStatus.SelectedItem.ToString()))

            Dim order As OrderType

            For Each order In orders

                Dim listparams(5) As String

                listparams(0) = order.OrderID

                listparams(1) = order.OrderStatus.ToString()

                listparams(2) = order.CreatingUserRole.ToString()

                listparams(3) = order.AmountSaved.Value.ToString()

                Dim itemids(order.TransactionArray.Count) As String

                Dim indx As Int16 = 0
                Dim trans As TransactionType

                For Each trans In order.TransactionArray

                    itemids(indx) = trans.Item.ItemID

                    indx = indx + 1

                Next trans

                listparams(4) = String.Join(", ", itemids)


                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstOrders.Items.Add(vi)
            Next order

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class


