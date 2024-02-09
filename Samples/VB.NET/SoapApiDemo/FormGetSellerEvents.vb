Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetSellerEvents
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

		Friend WithEvents BtnGetSellerEvents As System.Windows.Forms.Button 

		Friend WithEvents DatePickModTo As System.Windows.Forms.DateTimePicker 

		Friend WithEvents DatePickModFrom As System.Windows.Forms.DateTimePicker 

		Friend WithEvents LblModSep As System.Windows.Forms.Label 

		Friend WithEvents OptModTime As System.Windows.Forms.RadioButton 

		Friend WithEvents DatePickStartTo As System.Windows.Forms.DateTimePicker 

		Friend WithEvents LblStartSep As System.Windows.Forms.Label 

		Friend WithEvents OptStartTime As System.Windows.Forms.RadioButton 

		Friend WithEvents DatePickEndTo As System.Windows.Forms.DateTimePicker 

		Friend WithEvents LblEndSep As System.Windows.Forms.Label 

		Friend WithEvents OptEndTime As System.Windows.Forms.RadioButton 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents TxtUserId As System.Windows.Forms.TextBox 

		Friend WithEvents ChkIncludeNew As System.Windows.Forms.CheckBox 

		Friend WithEvents LblUserId As System.Windows.Forms.Label 

		Friend WithEvents LblEvents As System.Windows.Forms.Label 

		Friend WithEvents DatePickStartFrom As System.Windows.Forms.DateTimePicker 

		Friend WithEvents DatePickEndFrom As System.Windows.Forms.DateTimePicker 

		Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmTitle As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmPrice As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmSold As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmBids As System.Windows.Forms.ColumnHeader 

		Friend WithEvents LstEvents As System.Windows.Forms.ListView 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()


			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblEvents = new System.Windows.Forms.Label()

			Me.LstEvents = new System.Windows.Forms.ListView()

			Me.ClmItemId = new System.Windows.Forms.ColumnHeader()

			Me.ClmTitle = new System.Windows.Forms.ColumnHeader()

			Me.ClmPrice = new System.Windows.Forms.ColumnHeader()

			Me.ClmSold = new System.Windows.Forms.ColumnHeader()

			Me.BtnGetSellerEvents = new System.Windows.Forms.Button()

			Me.DatePickModTo = new System.Windows.Forms.DateTimePicker()

			Me.DatePickModFrom = new System.Windows.Forms.DateTimePicker()

			Me.LblModSep = new System.Windows.Forms.Label()

			Me.OptModTime = new System.Windows.Forms.RadioButton()

			Me.DatePickStartTo = new System.Windows.Forms.DateTimePicker()

			Me.DatePickStartFrom = new System.Windows.Forms.DateTimePicker()

			Me.LblStartSep = new System.Windows.Forms.Label()

			Me.OptStartTime = new System.Windows.Forms.RadioButton()

			Me.DatePickEndTo = new System.Windows.Forms.DateTimePicker()

			Me.DatePickEndFrom = new System.Windows.Forms.DateTimePicker()

			Me.LblEndSep = new System.Windows.Forms.Label()

			Me.OptEndTime = new System.Windows.Forms.RadioButton()

			Me.TxtUserId = new System.Windows.Forms.TextBox()

			Me.ChkIncludeNew = new System.Windows.Forms.CheckBox()

			Me.LblUserId = new System.Windows.Forms.Label()

			Me.ClmBids = new System.Windows.Forms.ColumnHeader()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblEvents)

			Me.GrpResult.Controls.Add(Me.LstEvents)

			Me.GrpResult.Location = new System.Drawing.Point(8, 168)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(456, 328)

			Me.GrpResult.TabIndex = 24

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Results"

			' 

			' LblEvents

			' 

			Me.LblEvents.Location = new System.Drawing.Point(16, 24)

			Me.LblEvents.Name = "LblEvents"

			Me.LblEvents.Size = new System.Drawing.Size(112, 23)

			Me.LblEvents.TabIndex = 15

			Me.LblEvents.Text = "Seller Events:"

			' 

			' LstEvents

			' 

        Me.LstEvents.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right

			Me.LstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader() {Me.ClmItemId,Me.ClmTitle,Me.ClmPrice,Me.ClmSold,Me.ClmBids})

			Me.LstEvents.GridLines = true

			Me.LstEvents.Location = new System.Drawing.Point(8, 48)

			Me.LstEvents.Name = "LstEvents"

			Me.LstEvents.Size = new System.Drawing.Size(440, 264)

			Me.LstEvents.TabIndex = 4

			Me.LstEvents.View = System.Windows.Forms.View.Details

			' 

			' ClmItemId

			' 

			Me.ClmItemId.Text = "ItemId"

			Me.ClmItemId.Width = 80

			' 

			' ClmTitle

			' 

			Me.ClmTitle.Text = "Title"

			Me.ClmTitle.Width = 173

			' 

			' ClmPrice

			' 

			Me.ClmPrice.Text = "Price"

			' 

			' ClmSold

			' 

			Me.ClmSold.Text = "Quantity Sold"

			Me.ClmSold.Width = 80

			' 

			' BtnGetSellerEvents

			' 

			Me.BtnGetSellerEvents.Location = new System.Drawing.Point(144, 128)

			Me.BtnGetSellerEvents.Name = "BtnGetSellerEvents"

			Me.BtnGetSellerEvents.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetSellerEvents.TabIndex = 23

			Me.BtnGetSellerEvents.Text = "GetSellerEvents"

			'Me.BtnGetSellerEvents.Click += new System.EventHandler(Me.BtnGetSellerEvents_Click)

			' 

			' DatePickModTo

			' 

			Me.DatePickModTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickModTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickModTo.Location = new System.Drawing.Point(312, 48)

			Me.DatePickModTo.Name = "DatePickModTo"

			Me.DatePickModTo.Size = new System.Drawing.Size(152, 20)

			Me.DatePickModTo.TabIndex = 61

			' 

			' DatePickModFrom

			' 

			Me.DatePickModFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickModFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickModFrom.Location = new System.Drawing.Point(144, 48)

			Me.DatePickModFrom.Name = "DatePickModFrom"

			Me.DatePickModFrom.Size = new System.Drawing.Size(152, 20)

			Me.DatePickModFrom.TabIndex = 60

			' 

			' LblModSep

			' 

			Me.LblModSep.Location = new System.Drawing.Point(296, 48)

			Me.LblModSep.Name = "LblModSep"

			Me.LblModSep.Size = new System.Drawing.Size(16, 23)

			Me.LblModSep.TabIndex = 59

			Me.LblModSep.Text = " - "

			' 

			' OptModTime

			' 

			Me.OptModTime.Location = new System.Drawing.Point(8, 48)

			Me.OptModTime.Name = "OptModTime"

			Me.OptModTime.Size = new System.Drawing.Size(128, 24)

			Me.OptModTime.TabIndex = 58

			Me.OptModTime.Text = "Modified Between:"

        'Me.OptModTime.CheckedChanged += new System.EventHandler(Me.Option_CheckedChanged)

			' 

			' DatePickStartTo

			' 

			Me.DatePickStartTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickStartTo.Location = new System.Drawing.Point(312, 72)

			Me.DatePickStartTo.Name = "DatePickStartTo"

			Me.DatePickStartTo.Size = new System.Drawing.Size(152, 20)

			Me.DatePickStartTo.TabIndex = 65

			' 

			' DatePickStartFrom

			' 

			Me.DatePickStartFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickStartFrom.Location = new System.Drawing.Point(144, 72)

			Me.DatePickStartFrom.Name = "DatePickStartFrom"

			Me.DatePickStartFrom.Size = new System.Drawing.Size(152, 20)

			Me.DatePickStartFrom.TabIndex = 64

			' 

			' LblStartSep

			' 

			Me.LblStartSep.Location = new System.Drawing.Point(296, 72)

			Me.LblStartSep.Name = "LblStartSep"

			Me.LblStartSep.Size = new System.Drawing.Size(16, 23)

			Me.LblStartSep.TabIndex = 63

			Me.LblStartSep.Text = " - "

			' 

			' OptStartTime

			' 

			Me.OptStartTime.Location = new System.Drawing.Point(8, 72)

			Me.OptStartTime.Name = "OptStartTime"

			Me.OptStartTime.Size = new System.Drawing.Size(128, 24)

			Me.OptStartTime.TabIndex = 62

			Me.OptStartTime.Text = "Started Between:"

			'Me.OptStartTime.CheckedChanged += new System.EventHandler(Me.Option_CheckedChanged)

			' 

			' DatePickEndTo

			' 

			Me.DatePickEndTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickEndTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickEndTo.Location = new System.Drawing.Point(312, 96)

			Me.DatePickEndTo.Name = "DatePickEndTo"

			Me.DatePickEndTo.Size = new System.Drawing.Size(152, 20)

			Me.DatePickEndTo.TabIndex = 69

			' 

			' DatePickEndFrom

			' 

			Me.DatePickEndFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickEndFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickEndFrom.Location = new System.Drawing.Point(144, 96)

			Me.DatePickEndFrom.Name = "DatePickEndFrom"

			Me.DatePickEndFrom.Size = new System.Drawing.Size(152, 20)

			Me.DatePickEndFrom.TabIndex = 68

			' 

			' LblEndSep

			' 

			Me.LblEndSep.Location = new System.Drawing.Point(296, 96)

			Me.LblEndSep.Name = "LblEndSep"

			Me.LblEndSep.Size = new System.Drawing.Size(16, 23)

			Me.LblEndSep.TabIndex = 67

			Me.LblEndSep.Text = " - "

			' 

			' OptEndTime

			' 

			Me.OptEndTime.Location = new System.Drawing.Point(8, 96)

			Me.OptEndTime.Name = "OptEndTime"

			Me.OptEndTime.Size = new System.Drawing.Size(128, 24)

			Me.OptEndTime.TabIndex = 66

			Me.OptEndTime.Text = "Ended Between:"

        'Me.OptEndTime.CheckedChanged += new System.EventHandler(Me.Option_CheckedChanged)

			' 

			' TxtUserId

			' 

			Me.TxtUserId.Location = new System.Drawing.Point(152, 16)

			Me.TxtUserId.Name = "TxtUserId"

			Me.TxtUserId.TabIndex = 70

			Me.TxtUserId.Text = ""

			' 

			' ChkIncludeNew

			' 

			Me.ChkIncludeNew.Location = new System.Drawing.Point(272, 16)

			Me.ChkIncludeNew.Name = "ChkIncludeNew"

			Me.ChkIncludeNew.Size = new System.Drawing.Size(128, 24)

			Me.ChkIncludeNew.TabIndex = 71

			Me.ChkIncludeNew.Text = "Include New Items"

			' 

			' LblUserId

			' 

			Me.LblUserId.Location = new System.Drawing.Point(96, 16)

			Me.LblUserId.Name = "LblUserId"

			Me.LblUserId.Size = new System.Drawing.Size(56, 16)

			Me.LblUserId.TabIndex = 72

			Me.LblUserId.Text = "User Id:"

			' 

			' ClmBids

			' 

			Me.ClmBids.Text = "Bids"

			Me.ClmBids.Width = 39

			' 

			' FrmGetSellerEvents

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(472, 501)

			Me.Controls.Add(Me.LblUserId)

			Me.Controls.Add(Me.ChkIncludeNew)

			Me.Controls.Add(Me.TxtUserId)

			Me.Controls.Add(Me.DatePickEndTo)

			Me.Controls.Add(Me.DatePickEndFrom)

			Me.Controls.Add(Me.LblEndSep)

			Me.Controls.Add(Me.OptEndTime)

			Me.Controls.Add(Me.DatePickStartTo)

			Me.Controls.Add(Me.DatePickStartFrom)

			Me.Controls.Add(Me.LblStartSep)

			Me.Controls.Add(Me.OptStartTime)

			Me.Controls.Add(Me.DatePickModTo)

			Me.Controls.Add(Me.DatePickModFrom)

			Me.Controls.Add(Me.LblModSep)

			Me.Controls.Add(Me.OptModTime)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetSellerEvents)

			Me.Name = "FrmGetSellerEvents"

			Me.Text = "GetSellerEvents"

			'Me.Load += new System.EventHandler(Me.FrmGetSellerList_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


    Public Context As ApiContext

		Private Sub  FrmGetSellerList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


			OptModTime.Checked = true

			Dim now As DateTime = DateTime.Now

			DatePickModTo.Value = now

			DatePickModFrom.Value = now.AddDays(-5)

			DatePickStartTo.Value = now

			DatePickStartFrom.Value = now.AddDays(-5)

			DatePickEndTo.Value = now.AddDays(5)

			DatePickEndFrom.Value = now
		End Sub

    Private Sub OptStartTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptStartTime.CheckedChanged
        If OptStartTime.Checked Then

            DatePickModFrom.Enabled = False

            DatePickModTo.Enabled = False

            DatePickStartFrom.Enabled = True

            DatePickStartTo.Enabled = True

            DatePickEndFrom.Enabled = False

            DatePickEndTo.Enabled = False
        End If
    End Sub

    Private Sub OptEndTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptEndTime.CheckedChanged

        If OptEndTime.Checked Then
            DatePickModFrom.Enabled = False

            DatePickModTo.Enabled = False

            DatePickStartFrom.Enabled = False

            DatePickStartTo.Enabled = False

            DatePickEndFrom.Enabled = True

            DatePickEndTo.Enabled = True
        End If

    End Sub

    Private Sub OptModTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptModTime.CheckedChanged

        If OptModTime.Checked Then

            DatePickModFrom.Enabled = True

            DatePickModTo.Enabled = True

            DatePickStartFrom.Enabled = False

            DatePickStartTo.Enabled = False

            DatePickEndFrom.Enabled = False

            DatePickEndTo.Enabled = False

        End If

    End Sub



    Private Sub BtnGetSellerEvents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetSellerEvents.Click

        Try

            LstEvents.Items.Clear()
            Dim ApiCall As GetSellerEventsCall = New GetSellerEventsCall(Context)

            If TxtUserId.Text.Length > 0 Then
                ApiCall.UserID = TxtUserId.Text()
            End If

            ApiCall.IncludeNewItem = ChkIncludeNew.Checked

            If OptModTime.Checked Then
                ApiCall.ModTimeFilter = New TimeFilter(DatePickModFrom.Value, DatePickModTo.Value)
            ElseIf OptStartTime.Checked Then
                ApiCall.StartTimeFilter = New TimeFilter(DatePickStartFrom.Value, DatePickStartTo.Value)
            ElseIf OptEndTime.Checked Then
                ApiCall.EndTimeFilter = New TimeFilter(DatePickEndFrom.Value, DatePickEndTo.Value)
            End If

            ApiCall.Execute()

            Dim evt As ItemType

            For Each evt In ApiCall.ItemEventList
                Dim listparams(5) As String

                listparams(0) = evt.ItemID
                listparams(1) = evt.Title
                listparams(2) = evt.SellingStatus.CurrentPrice.Value.ToString()
                listparams(3) = evt.SellingStatus.QuantitySold.ToString()
                listparams(4) = evt.SellingStatus.BidCount.ToString()

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstEvents.Items.Add(vi)

            Next evt

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class


