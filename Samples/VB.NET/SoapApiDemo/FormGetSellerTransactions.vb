Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetSellerTransactions
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

    Friend WithEvents LblModified As System.Windows.Forms.Label

    Friend WithEvents LblTransactions As System.Windows.Forms.Label

    Friend WithEvents LstTransactions As System.Windows.Forms.ListView

    Friend WithEvents ClmTransId As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmAmount As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmQuantity As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmUser As System.Windows.Forms.ColumnHeader

    Friend WithEvents BtnGetSellerTransactions As System.Windows.Forms.Button

    Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblTransactions = new System.Windows.Forms.Label()

			Me.LstTransactions = new System.Windows.Forms.ListView()

			Me.ClmItemId = new System.Windows.Forms.ColumnHeader()

			Me.ClmTransId = new System.Windows.Forms.ColumnHeader()

			Me.ClmPrice = new System.Windows.Forms.ColumnHeader()

			Me.ClmAmount = new System.Windows.Forms.ColumnHeader()

			Me.ClmQuantity = new System.Windows.Forms.ColumnHeader()

			Me.ClmUser = new System.Windows.Forms.ColumnHeader()

			Me.BtnGetSellerTransactions = new System.Windows.Forms.Button()

			Me.DatePickModTo = new System.Windows.Forms.DateTimePicker()

			Me.DatePickModFrom = new System.Windows.Forms.DateTimePicker()

			Me.LblModSep = new System.Windows.Forms.Label()

			Me.LblModified = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblTransactions)

			Me.GrpResult.Controls.Add(Me.LstTransactions)

			Me.GrpResult.Location = new System.Drawing.Point(8, 80)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(512, 328)

			Me.GrpResult.TabIndex = 24

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Results"

			' 

			' LblTransactions

			' 

			Me.LblTransactions.Location = new System.Drawing.Point(16, 24)

			Me.LblTransactions.Name = "LblTransactions"

			Me.LblTransactions.Size = new System.Drawing.Size(112, 23)

			Me.LblTransactions.TabIndex = 15

			Me.LblTransactions.Text = "Seller Transactions:"

			' 

			' LstTransactions

			' 

			Me.LstTransactions.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left  Or System.Windows.Forms.AnchorStyles.Right)

			Me.LstTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader() {Me.ClmItemId,Me.ClmTransId,Me.ClmPrice,Me.ClmAmount,Me.ClmQuantity,Me.ClmUser})

			Me.LstTransactions.GridLines = true

			Me.LstTransactions.Location = new System.Drawing.Point(8, 48)

			Me.LstTransactions.Name = "LstTransactions"

			Me.LstTransactions.Size = new System.Drawing.Size(496, 264)

			Me.LstTransactions.TabIndex = 4

			Me.LstTransactions.View = System.Windows.Forms.View.Details

			' 

			' ClmItemId

			' 

			Me.ClmItemId.Text = "Item Id"

			Me.ClmItemId.Width = 88

			' 

			' ClmTransId

			' 

			Me.ClmTransId.Text = "Transaction Id"

			Me.ClmTransId.Width = 100

			' 

			' ClmPrice

			' 

			Me.ClmPrice.Text = "Price"

			' 

			' ClmAmount

			' 

			Me.ClmAmount.Text = "Amount"

			Me.ClmAmount.Width = 66

			' 

			' ClmQuantity

			' 

			Me.ClmQuantity.Text = "Quantity"

			Me.ClmQuantity.Width = 80

			' 

			' ClmUser

			' 

			Me.ClmUser.Text = "User Id"

			Me.ClmUser.Width = 94

			' 

			' BtnGetSellerTransactions

			' 

			Me.BtnGetSellerTransactions.Location = new System.Drawing.Point(200, 48)

			Me.BtnGetSellerTransactions.Name = "BtnGetSellerTransactions"

			Me.BtnGetSellerTransactions.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetSellerTransactions.TabIndex = 23

			Me.BtnGetSellerTransactions.Text = "GetSellerTransactions"

        'Me.BtnGetSellerTransactions.Click += new System.EventHandler(Me.BtnGetSellerTransactions_Click)

			' 

			' DatePickModTo

			' 

			Me.DatePickModTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickModTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickModTo.Location = new System.Drawing.Point(328, 16)

			Me.DatePickModTo.Name = "DatePickModTo"

			Me.DatePickModTo.Size = new System.Drawing.Size(152, 20)

			Me.DatePickModTo.TabIndex = 61

			' 

			' DatePickModFrom

			' 

			Me.DatePickModFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickModFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickModFrom.Location = new System.Drawing.Point(160, 16)

			Me.DatePickModFrom.Name = "DatePickModFrom"

			Me.DatePickModFrom.Size = new System.Drawing.Size(152, 20)

			Me.DatePickModFrom.TabIndex = 60

			' 

			' LblModSep

			' 

			Me.LblModSep.Location = new System.Drawing.Point(264, 16)

			Me.LblModSep.Name = "LblModSep"

			Me.LblModSep.Size = new System.Drawing.Size(16, 23)

			Me.LblModSep.TabIndex = 59

			Me.LblModSep.Text = " - "

			' 

			' LblModified

			' 

			Me.LblModified.Location = new System.Drawing.Point(56, 16)

			Me.LblModified.Name = "LblModified"

			Me.LblModified.Size = new System.Drawing.Size(104, 16)

			Me.LblModified.TabIndex = 73

			Me.LblModified.Text = "Modified Between:"

			' 

			' FrmGetSellerTransactions

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(528, 413)

			Me.Controls.Add(Me.LblModified)

			Me.Controls.Add(Me.DatePickModTo)

			Me.Controls.Add(Me.DatePickModFrom)

			Me.Controls.Add(Me.LblModSep)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetSellerTransactions)

			Me.Name = "FrmGetSellerTransactions"

			Me.Text = "GetSellerTransactions"

			'Me.Load += new System.EventHandler(Me.FrmGetSellerTransactions_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)

   End Sub

#End Region


    Public Context As ApiContext

		Private Sub  FrmGetSellerTransactions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			Dim now As DateTime = DateTime.Now

			DatePickModTo.Value = now

			DatePickModFrom.Value = now.AddDays(-5)

		End Sub


		Private Sub  BtnGetSellerTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetSellerTransactions.Click
			Try

				LstTransactions.Items.Clear()

				Dim apicall As GetSellerTransactionsCall = new GetSellerTransactionsCall(Context)

				Dim transactions As TransactionTypeCollection = apicall.GetSellerTransactions(DatePickModFrom.Value, DatePickModTo.Value)
				dim trans As TransactionType
				For Each trans in transactions
					Dim listparams(6) As String

					listparams(0) = trans.Item.ItemID

					listparams(1) = trans.TransactionID

					listparams(2) = trans.TransactionPrice.Value.ToString()

					listparams(3) = trans.AmountPaid.Value.ToString()

					listparams(4) = trans.QuantityPurchased.ToString()

					listparams(5) = trans.Buyer.UserID

					Dim vi As ListViewItem = new ListViewItem(listparams)

					LstTransactions.Items.Add(vi)

				Next trans

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class