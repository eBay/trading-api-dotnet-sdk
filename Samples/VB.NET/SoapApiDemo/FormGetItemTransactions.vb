Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetItemTransactions
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




		Friend WithEvents DatePickModTo As System.Windows.Forms.DateTimePicker 

		Friend WithEvents DatePickModFrom As System.Windows.Forms.DateTimePicker 

		Friend WithEvents LblModSep As System.Windows.Forms.Label 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents ClmPrice As System.Windows.Forms.ColumnHeader 

		Friend WithEvents BtnGetItemTransactions As System.Windows.Forms.Button 

		Friend WithEvents TxtItemId As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemId As System.Windows.Forms.Label 

		Friend WithEvents LblModified As System.Windows.Forms.Label 

		Friend WithEvents LblTransactions As System.Windows.Forms.Label 

		Friend WithEvents LstTransactions As System.Windows.Forms.ListView 

		Friend WithEvents ClmTransId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmAmount As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmQuantity As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmUser As System.Windows.Forms.ColumnHeader 

    Friend WithEvents ClmBestOfferSale As System.Windows.Forms.ColumnHeader




		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblTransactions = New System.Windows.Forms.Label()
        Me.LstTransactions = New System.Windows.Forms.ListView()
        Me.ClmTransId = New System.Windows.Forms.ColumnHeader()
        Me.ClmPrice = New System.Windows.Forms.ColumnHeader()
        Me.ClmAmount = New System.Windows.Forms.ColumnHeader()
        Me.ClmQuantity = New System.Windows.Forms.ColumnHeader()
        Me.ClmUser = New System.Windows.Forms.ColumnHeader()
        Me.ClmBestOfferSale = New System.Windows.Forms.ColumnHeader()
        Me.BtnGetItemTransactions = New System.Windows.Forms.Button()
        Me.DatePickModTo = New System.Windows.Forms.DateTimePicker()
        Me.DatePickModFrom = New System.Windows.Forms.DateTimePicker()
        Me.LblModSep = New System.Windows.Forms.Label()
        Me.TxtItemId = New System.Windows.Forms.TextBox()
        Me.LblItemId = New System.Windows.Forms.Label()
        Me.LblModified = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblTransactions, Me.LstTransactions})
        Me.GrpResult.Location = New System.Drawing.Point(8, 112)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(504, 328)
        Me.GrpResult.TabIndex = 24
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Results"
        '
        'LblTransactions
        '
        Me.LblTransactions.Location = New System.Drawing.Point(16, 24)
        Me.LblTransactions.Name = "LblTransactions"
        Me.LblTransactions.Size = New System.Drawing.Size(112, 23)
        Me.LblTransactions.TabIndex = 15
        Me.LblTransactions.Text = "Item Transactions:"
        '
        'LstTransactions
        '
        Me.LstTransactions.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.LstTransactions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmTransId, Me.ClmPrice, Me.ClmAmount, Me.ClmQuantity, Me.ClmUser, Me.ClmBestOfferSale})
        Me.LstTransactions.GridLines = True
        Me.LstTransactions.Location = New System.Drawing.Point(8, 48)
        Me.LstTransactions.Name = "LstTransactions"
        Me.LstTransactions.Size = New System.Drawing.Size(488, 264)
        Me.LstTransactions.TabIndex = 4
        Me.LstTransactions.View = System.Windows.Forms.View.Details
        '
        'ClmTransId
        '
        Me.ClmTransId.Text = "Transaction Id"
        Me.ClmTransId.Width = 100
        '
        'ClmPrice
        '
        Me.ClmPrice.Text = "Price"
        '
        'ClmAmount
        '
        Me.ClmAmount.Text = "Amount"
        Me.ClmAmount.Width = 66
        '
        'ClmQuantity
        '
        Me.ClmQuantity.Text = "Quantity"
        Me.ClmQuantity.Width = 80
        '
        'ClmUser
        '
        Me.ClmUser.Text = "User Id"
        Me.ClmUser.Width = 80
        '
        'ClmBestOfferSale
        '
        Me.ClmBestOfferSale.Text = "Best Offer Sale"
        Me.ClmBestOfferSale.Width = 90
        '
        'BtnGetItemTransactions
        '
        Me.BtnGetItemTransactions.Location = New System.Drawing.Point(152, 80)
        Me.BtnGetItemTransactions.Name = "BtnGetItemTransactions"
        Me.BtnGetItemTransactions.Size = New System.Drawing.Size(128, 23)
        Me.BtnGetItemTransactions.TabIndex = 23
        Me.BtnGetItemTransactions.Text = "GetItemTransactions"
        '
        'DatePickModTo
        '
        Me.DatePickModTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickModTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickModTo.Location = New System.Drawing.Point(280, 48)
        Me.DatePickModTo.Name = "DatePickModTo"
        Me.DatePickModTo.Size = New System.Drawing.Size(152, 20)
        Me.DatePickModTo.TabIndex = 61
        '
        'DatePickModFrom
        '
        Me.DatePickModFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickModFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickModFrom.Location = New System.Drawing.Point(112, 48)
        Me.DatePickModFrom.Name = "DatePickModFrom"
        Me.DatePickModFrom.Size = New System.Drawing.Size(152, 20)
        Me.DatePickModFrom.TabIndex = 60
        '
        'LblModSep
        '
        Me.LblModSep.Location = New System.Drawing.Point(264, 48)
        Me.LblModSep.Name = "LblModSep"
        Me.LblModSep.Size = New System.Drawing.Size(16, 23)
        Me.LblModSep.TabIndex = 59
        Me.LblModSep.Text = " - "
        '
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(112, 16)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.TabIndex = 70
        Me.TxtItemId.Text = ""
        '
        'LblItemId
        '
        Me.LblItemId.Location = New System.Drawing.Point(56, 16)
        Me.LblItemId.Name = "LblItemId"
        Me.LblItemId.Size = New System.Drawing.Size(56, 16)
        Me.LblItemId.TabIndex = 72
        Me.LblItemId.Text = "Item Id:"
        '
        'LblModified
        '
        Me.LblModified.Location = New System.Drawing.Point(8, 48)
        Me.LblModified.Name = "LblModified"
        Me.LblModified.Size = New System.Drawing.Size(104, 16)
        Me.LblModified.TabIndex = 73
        Me.LblModified.Text = "Modified Between:"
        '
        'FormGetItemTransactions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 457)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblModified, Me.LblItemId, Me.TxtItemId, Me.DatePickModTo, Me.DatePickModFrom, Me.LblModSep, Me.GrpResult, Me.BtnGetItemTransactions})
        Me.Name = "FormGetItemTransactions"
        Me.Text = "GetItemTransactions"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


		Public Context As ApiContext

		Private Sub  FrmGetItemTransactions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			Dim now As DateTime = DateTime.Now

			DatePickModTo.Value = now

			DatePickModFrom.Value = now.AddDays(-5)

		End Sub

		Private Sub  BtnGetItemTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetItemTransactions.Click
			
			Try
			
				LstTransactions.Items.Clear()

				Dim apicall As GetItemTransactionsCall = new GetItemTransactionsCall(Context)

				Dim transactions As TransactionTypeCollection = apicall.GetItemTransactions(TxtItemId.Text, DatePickModFrom.Value, DatePickModTo.Value)

				Dim trans As TransactionType
				For Each  trans In transactions
					Dim listparams(6) As String

					listparams(0) = trans.TransactionID

					listparams(1) = trans.TransactionPrice.Value.ToString()

					listparams(2) = trans.AmountPaid.Value.ToString()

					listparams(3) = trans.QuantityPurchased.ToString()

					listparams(4) = trans.Buyer.UserID

                    listparams(5) = trans.BestOfferSale.ToString()
                  


					Dim vi As ListViewItem= new ListViewItem(listparams)

					LstTransactions.Items.Add(vi)
				Next trans


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class


