Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetAccount
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


		Friend WithEvents GrpResults As System.Windows.Forms.GroupBox 

		Friend WithEvents label1 As System.Windows.Forms.Label 

		Friend WithEvents BtnGetAccount As System.Windows.Forms.Button 

		Friend WithEvents OptLastInvoice As System.Windows.Forms.RadioButton 

		Friend WithEvents OptInvoiceDate As System.Windows.Forms.RadioButton 

		Friend WithEvents OptRange As System.Windows.Forms.RadioButton 



		Friend WithEvents DatePickInvoice As System.Windows.Forms.DateTimePicker 

		Friend WithEvents DatePickFrom As System.Windows.Forms.DateTimePicker 

		Friend WithEvents DatePickTo As System.Windows.Forms.DateTimePicker 

		Friend WithEvents LblEntries As System.Windows.Forms.Label 

		Friend WithEvents LstAccountEntries As System.Windows.Forms.ListView 

		Friend WithEvents ClmRef As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmType As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmBalance As System.Windows.Forms.ColumnHeader 

    Friend WithEvents ClmDate As System.Windows.Forms.ColumnHeader

    Friend WithEvents LblAccState As System.Windows.Forms.Label

		Friend WithEvents TxtAccState As System.Windows.Forms.TextBox 

		Friend WithEvents TxtAccBalance As System.Windows.Forms.TextBox 

		Friend WithEvents TxtPayMethod As System.Windows.Forms.TextBox 

		Friend WithEvents LblAccBalance As System.Windows.Forms.Label 

		Friend WithEvents LblPayMethod As System.Windows.Forms.Label 



		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GrpResults = New System.Windows.Forms.GroupBox()
        Me.LblPayMethod = New System.Windows.Forms.Label()
        Me.LblAccBalance = New System.Windows.Forms.Label()
        Me.TxtPayMethod = New System.Windows.Forms.TextBox()
        Me.TxtAccBalance = New System.Windows.Forms.TextBox()
        Me.TxtAccState = New System.Windows.Forms.TextBox()
        Me.LblAccState = New System.Windows.Forms.Label()
        Me.LblEntries = New System.Windows.Forms.Label()
        Me.LstAccountEntries = New System.Windows.Forms.ListView()
        Me.ClmRef = New System.Windows.Forms.ColumnHeader()
        Me.ClmType = New System.Windows.Forms.ColumnHeader()
        Me.ClmItemId = New System.Windows.Forms.ColumnHeader()
        Me.ClmBalance() = New System.Windows.Forms.ColumnHeader()
        Me.ClmDate = New System.Windows.Forms.ColumnHeader()
        Me.BtnGetAccount = New System.Windows.Forms.Button()
        Me.OptLastInvoice = New System.Windows.Forms.RadioButton()
        Me.OptInvoiceDate = New System.Windows.Forms.RadioButton()
        Me.OptRange = New System.Windows.Forms.RadioButton()
        Me.label1 = New System.Windows.Forms.Label()
        Me.DatePickInvoice = New System.Windows.Forms.DateTimePicker()
        Me.DatePickFrom = New System.Windows.Forms.DateTimePicker()
        Me.DatePickTo = New System.Windows.Forms.DateTimePicker()
        Me.GrpResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpResults
        '
        Me.GrpResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblPayMethod, Me.LblAccBalance, Me.TxtPayMethod, Me.TxtAccBalance, Me.TxtAccState, Me.LblAccState, Me.LblEntries, Me.LstAccountEntries})
        Me.GrpResults.Location = New System.Drawing.Point(8, 128)
        Me.GrpResults.Name = "GrpResults"
        Me.GrpResults.Size = New System.Drawing.Size(488, 320)
        Me.GrpResults.TabIndex = 45
        Me.GrpResults.TabStop = False
        Me.GrpResults.Text = "Results"
        '
        'LblPayMethod
        '
        Me.LblPayMethod.Location = New System.Drawing.Point(224, 48)
        Me.LblPayMethod.Name = "LblPayMethod"
        Me.LblPayMethod.Size = New System.Drawing.Size(96, 23)
        Me.LblPayMethod.TabIndex = 21
        Me.LblPayMethod.Text = "Payment Method::"
        '
        'LblAccBalance
        '
        Me.LblAccBalance.Location = New System.Drawing.Point(224, 24)
        Me.LblAccBalance.Name = "LblAccBalance"
        Me.LblAccBalance.Size = New System.Drawing.Size(96, 23)
        Me.LblAccBalance.TabIndex = 20
        Me.LblAccBalance.Text = "Current Balance:"
        '
        'TxtPayMethod
        '
        Me.TxtPayMethod.Location = New System.Drawing.Point(320, 48)
        Me.TxtPayMethod.Name = "TxtPayMethod"
        Me.TxtPayMethod.ReadOnly = True
        Me.TxtPayMethod.Size = New System.Drawing.Size(120, 20)
        Me.TxtPayMethod.TabIndex = 19
        Me.TxtPayMethod.Text = ""
        '
        'TxtAccBalance
        '
        Me.TxtAccBalance.Location = New System.Drawing.Point(320, 24)
        Me.TxtAccBalance.Name = "TxtAccBalance"
        Me.TxtAccBalance.ReadOnly = True
        Me.TxtAccBalance.Size = New System.Drawing.Size(120, 20)
        Me.TxtAccBalance.TabIndex = 18
        Me.TxtAccBalance.Text = ""
        '
        'TxtAccState
        '
        Me.TxtAccState.Location = New System.Drawing.Point(112, 24)
        Me.TxtAccState.Name = "TxtAccState"
        Me.TxtAccState.ReadOnly = True
        Me.TxtAccState.Size = New System.Drawing.Size(104, 20)
        Me.TxtAccState.TabIndex = 17
        Me.TxtAccState.Text = ""
        '
        'LblAccState
        '
        Me.LblAccState.Location = New System.Drawing.Point(16, 24)
        Me.LblAccState.Name = "LblAccState"
        Me.LblAccState.Size = New System.Drawing.Size(88, 23)
        Me.LblAccState.TabIndex = 16
        Me.LblAccState.Text = "Account State:"
        '
        'LblEntries
        '
        Me.LblEntries.Location = New System.Drawing.Point(16, 64)
        Me.LblEntries.Name = "LblEntries"
        Me.LblEntries.Size = New System.Drawing.Size(112, 23)
        Me.LblEntries.TabIndex = 14
        Me.LblEntries.Text = "Account Entries:"
        '
        'LstAccountEntries
        '
        Me.LstAccountEntries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmRef, Me.ClmType, Me.ClmItemId, Me.ClmBalance, Me.ClmDate})
        Me.LstAccountEntries.GridLines = True
        Me.LstAccountEntries.Location = New System.Drawing.Point(16, 88)
        Me.LstAccountEntries.Name = "LstAccountEntries"
        Me.LstAccountEntries.Size = New System.Drawing.Size(464, 224)
        Me.LstAccountEntries.TabIndex = 15
        Me.LstAccountEntries.View = System.Windows.Forms.View.Details
        '
        'ClmRef
        '
        Me.ClmRef.Text = "Reference"
        Me.ClmRef.Width = 66
        '
        'ClmType
        '
        Me.ClmType.Text = "Type"
        Me.ClmType.Width = 51
        '
        'ClmItemId
        '
        Me.ClmItemId.Text = "Item Id"
        Me.ClmItemId.Width = 65
        '
        'ClmBalance
        '
        Me.ClmBalance.Text = "Balance"
        Me.ClmBalance.Width = 68
        '
        'ClmDate
        '
        Me.ClmDate.Text = "Date"
        Me.ClmDate.Width = 98
        '
        'BtnGetAccount
        '
        Me.BtnGetAccount.Location = New System.Drawing.Point(160, 88)
        Me.BtnGetAccount.Name = "BtnGetAccount"
        Me.BtnGetAccount.Size = New System.Drawing.Size(120, 26)
        Me.BtnGetAccount.TabIndex = 46
        Me.BtnGetAccount.Text = "GetAccount"
        '
        'OptLastInvoice
        '
        Me.OptLastInvoice.Location = New System.Drawing.Point(16, 8)
        Me.OptLastInvoice.Name = "OptLastInvoice"
        Me.OptLastInvoice.Size = New System.Drawing.Size(128, 24)
        Me.OptLastInvoice.TabIndex = 47
        Me.OptLastInvoice.Text = "Since Last Invoice"
        '
        'OptInvoiceDate
        '
        Me.OptInvoiceDate.Location = New System.Drawing.Point(16, 32)
        Me.OptInvoiceDate.Name = "OptInvoiceDate"
        Me.OptInvoiceDate.Size = New System.Drawing.Size(128, 24)
        Me.OptInvoiceDate.TabIndex = 48
        Me.OptInvoiceDate.Text = "Invoice Date"
        '
        'OptRange
        '
        Me.OptRange.Location = New System.Drawing.Point(16, 56)
        Me.OptRange.Name = "OptRange"
        Me.OptRange.Size = New System.Drawing.Size(128, 24)
        Me.OptRange.TabIndex = 49
        Me.OptRange.Text = "Between Dates"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(304, 56)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(16, 23)
        Me.label1.TabIndex = 54
        Me.label1.Text = " - "
        '
        'DatePickInvoice
        '
        Me.DatePickInvoice.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickInvoice.Location = New System.Drawing.Point(152, 32)
        Me.DatePickInvoice.Name = "DatePickInvoice"
        Me.DatePickInvoice.Size = New System.Drawing.Size(152, 20)
        Me.DatePickInvoice.TabIndex = 55
        '
        'DatePickFrom
        '
        Me.DatePickFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickFrom.Location = New System.Drawing.Point(152, 56)
        Me.DatePickFrom.Name = "DatePickFrom"
        Me.DatePickFrom.Size = New System.Drawing.Size(152, 20)
        Me.DatePickFrom.TabIndex = 56
        '
        'DatePickTo
        '
        Me.DatePickTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickTo.Location = New System.Drawing.Point(320, 56)
        Me.DatePickTo.Name = "DatePickTo"
        Me.DatePickTo.Size = New System.Drawing.Size(152, 20)
        Me.DatePickTo.TabIndex = 57
        '
        'FormGetAccount
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 461)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DatePickTo, Me.DatePickFrom, Me.DatePickInvoice, Me.label1, Me.OptRange, Me.OptInvoiceDate, Me.OptLastInvoice, Me.BtnGetAccount, Me.GrpResults})
        Me.Name = "FormGetAccount"
        Me.Text = "GetAccount"
        Me.GrpResults.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub OptLastInvoice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptLastInvoice.CheckedChanged
        Dim sel As Boolean = OptLastInvoice.Checked
        If sel = True Then
            DatePickInvoice.Enabled = False
            DatePickFrom.Enabled = False
            DatePickTo.Enabled = False
        End If
    End Sub

    Private Sub OptInvoiceDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptInvoiceDate.CheckedChanged
        Dim sel As Boolean = OptInvoiceDate.Checked
        If sel = True Then
            DatePickInvoice.Enabled = True
            DatePickFrom.Enabled = False
            DatePickTo.Enabled = False
        End If
    End Sub

    Private Sub OptRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRange.CheckedChanged
        Dim sel As Boolean = OptRange.Checked
        If sel = True Then
            DatePickInvoice.Enabled = False
            DatePickFrom.Enabled = True
            DatePickTo.Enabled = True
        End If
    End Sub



    Private Sub BtnGetAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetAccount.Click

        Try

            LstAccountEntries.Items.Clear()

            TxtAccBalance.Text = ""

            TxtAccState.Text = ""

            TxtPayMethod.Text = ""



            Dim apicall As GetAccountCall = New GetAccountCall(Context)

            Dim seltype As AccountHistorySelectionCodeType = AccountHistorySelectionCodeType.CustomCode

            If OptLastInvoice.Checked = True Then

                seltype = AccountHistorySelectionCodeType.LastInvoice

            ElseIf OptInvoiceDate.Checked = True Then

                seltype = AccountHistorySelectionCodeType.SpecifiedInvoice

                apicall.InvoiceDate = DatePickInvoice.Value
            ElseIf OptRange.Checked = True Then
                seltype = AccountHistorySelectionCodeType.BetweenSpecifiedDates
                apicall.StartTimeFilter = New TimeFilter(DatePickFrom.Value, DatePickTo.Value)

            End If



            Dim entrylist As AccountEntryTypeCollection = apicall.GetAccount(seltype)


            If Not apicall.AccountSummary Is Nothing Then

                TxtAccBalance.Text = apicall.AccountSummary.CurrentBalance.Value.ToString()

                TxtAccState.Text = apicall.AccountSummary.AccountState.ToString()

                TxtPayMethod.Text = apicall.AccountSummary.PaymentMethod.ToString()

            End If



            If Not entrylist Is Nothing Then

                Dim entry As AccountEntryType

                For Each entry In entrylist

                    Dim listparams(7) As String

                    listparams(0) = entry.RefNumber

                    listparams(1) = entry.AccountDetailsEntryType.ToString()

                    listparams(2) = entry.ItemID

                    listparams(4) = entry.Balance.Value.ToString()

                    listparams(5) = entry.Date.ToString()

                    Dim vi As ListViewItem = New ListViewItem(listparams)

                    Me.LstAccountEntries.Items.Add(vi)

                Next entry
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub FormGetAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OptRange.Checked = True
        Dim Now As DateTime = DateTime.Now
        DatePickInvoice.Value = Now
        DatePickTo.Value = Now
        DatePickFrom.Value = Now.AddDays(-5)

    End Sub
End Class


