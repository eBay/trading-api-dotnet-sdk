Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetSellerList
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




    Friend WithEvents DatePickStartTo As System.Windows.Forms.DateTimePicker

    Friend WithEvents LblStartSep As System.Windows.Forms.Label

    Friend WithEvents OptStartTime As System.Windows.Forms.RadioButton

    Friend WithEvents DatePickEndTo As System.Windows.Forms.DateTimePicker

    Friend WithEvents LblEndSep As System.Windows.Forms.Label

    Friend WithEvents OptEndTime As System.Windows.Forms.RadioButton

    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox

    Friend WithEvents TxtUserId As System.Windows.Forms.TextBox

    Friend WithEvents LblUserId As System.Windows.Forms.Label

    Friend WithEvents DatePickStartFrom As System.Windows.Forms.DateTimePicker

    Friend WithEvents DatePickEndFrom As System.Windows.Forms.DateTimePicker

    Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmTitle As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmPrice As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmSold As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmBids As System.Windows.Forms.ColumnHeader

	Friend WithEvents ClmBestOfferEnabled As System.Windows.Forms.ColumnHeader

    Friend WithEvents BtnGetSellerList As System.Windows.Forms.Button

    Friend WithEvents LblList As System.Windows.Forms.Label

    Friend WithEvents LstItems As System.Windows.Forms.ListView


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblList = new System.Windows.Forms.Label()

			Me.LstItems = new System.Windows.Forms.ListView()

			Me.ClmItemId = new System.Windows.Forms.ColumnHeader()

			Me.ClmTitle = new System.Windows.Forms.ColumnHeader()

			Me.ClmPrice = new System.Windows.Forms.ColumnHeader()

			Me.ClmSold = new System.Windows.Forms.ColumnHeader()

			Me.ClmBids = new System.Windows.Forms.ColumnHeader()

			Me.ClmBestOfferEnabled = new System.Windows.Forms.ColumnHeader()

			Me.BtnGetSellerList = new System.Windows.Forms.Button()

			Me.DatePickStartTo = new System.Windows.Forms.DateTimePicker()

			Me.DatePickStartFrom = new System.Windows.Forms.DateTimePicker()

			Me.LblStartSep = new System.Windows.Forms.Label()

			Me.OptStartTime = new System.Windows.Forms.RadioButton()

			Me.DatePickEndTo = new System.Windows.Forms.DateTimePicker()

			Me.DatePickEndFrom = new System.Windows.Forms.DateTimePicker()

			Me.LblEndSep = new System.Windows.Forms.Label()

			Me.OptEndTime = new System.Windows.Forms.RadioButton()

			Me.TxtUserId = new System.Windows.Forms.TextBox()

			Me.LblUserId = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblList)

			Me.GrpResult.Controls.Add(Me.LstItems)

			Me.GrpResult.Location = new System.Drawing.Point(8, 168)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(456, 328)

			Me.GrpResult.TabIndex = 24

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Results"

			' 

			' LblList

			' 

			Me.LblList.Location = new System.Drawing.Point(16, 24)

			Me.LblList.Name = "LblList"

			Me.LblList.Size = new System.Drawing.Size(112, 23)

			Me.LblList.TabIndex = 15

			Me.LblList.Text = "Seller List:"

			' 

			' LstItems

			' 

        Me.LstItems.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right

			Me.LstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader(){Me.ClmItemId, Me.ClmTitle,Me.ClmPrice, Me.ClmSold, Me.ClmBids, Me.ClmBestOfferEnabled})

			Me.LstItems.GridLines = true

			Me.LstItems.Location = new System.Drawing.Point(8, 48)

			Me.LstItems.Name = "LstItems"

			Me.LstItems.Size = new System.Drawing.Size(440, 264)

			Me.LstItems.TabIndex = 4

			Me.LstItems.View = System.Windows.Forms.View.Details

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

			' ClmBids

			' 

			Me.ClmBids.Text = "Bids"

			Me.ClmBids.Width = 39

			' 

			' ClmBestOfferEnabled

			' 

			Me.ClmBestOfferEnabled.Text = "BestOfferEnabled"

			Me.ClmBestOfferEnabled.Width = 80

			' 

			' BtnGetSellerList

			' 

			Me.BtnGetSellerList.Location = new System.Drawing.Point(144, 96)

			Me.BtnGetSellerList.Name = "BtnGetSellerList"

			Me.BtnGetSellerList.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetSellerList.TabIndex = 23

			Me.BtnGetSellerList.Text = "GetSellerList"

        'Me.BtnGetSellerList.Click += new System.EventHandler(Me.BtnGetSellerList_Click)

			' 

			' DatePickStartTo

			' 

			Me.DatePickStartTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickStartTo.Location = new System.Drawing.Point(312, 40)

			Me.DatePickStartTo.Name = "DatePickStartTo"

			Me.DatePickStartTo.Size = new System.Drawing.Size(152, 20)

			Me.DatePickStartTo.TabIndex = 65

			' 

			' DatePickStartFrom

			' 

			Me.DatePickStartFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickStartFrom.Location = new System.Drawing.Point(144, 40)

			Me.DatePickStartFrom.Name = "DatePickStartFrom"

			Me.DatePickStartFrom.Size = new System.Drawing.Size(152, 20)

			Me.DatePickStartFrom.TabIndex = 64

			' 

			' LblStartSep

			' 

			Me.LblStartSep.Location = new System.Drawing.Point(296, 48)

			Me.LblStartSep.Name = "LblStartSep"

			Me.LblStartSep.Size = new System.Drawing.Size(16, 23)

			Me.LblStartSep.TabIndex = 63

			Me.LblStartSep.Text = " - "

			' 

			' OptStartTime

			' 

			Me.OptStartTime.Location = new System.Drawing.Point(8, 40)

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

			Me.DatePickEndTo.Location = new System.Drawing.Point(312, 64)

			Me.DatePickEndTo.Name = "DatePickEndTo"

			Me.DatePickEndTo.Size = new System.Drawing.Size(152, 20)

			Me.DatePickEndTo.TabIndex = 69

			' 

			' DatePickEndFrom

			' 

			Me.DatePickEndFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickEndFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickEndFrom.Location = new System.Drawing.Point(144, 64)

			Me.DatePickEndFrom.Name = "DatePickEndFrom"

			Me.DatePickEndFrom.Size = new System.Drawing.Size(152, 20)

			Me.DatePickEndFrom.TabIndex = 68

			' 

			' LblEndSep

			' 

			Me.LblEndSep.Location = new System.Drawing.Point(296, 72)

			Me.LblEndSep.Name = "LblEndSep"

			Me.LblEndSep.Size = new System.Drawing.Size(16, 23)

			Me.LblEndSep.TabIndex = 67

			Me.LblEndSep.Text = " - "

			' 

			' OptEndTime

			' 

			Me.OptEndTime.Location = new System.Drawing.Point(8, 64)

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

			' LblUserId

			' 

			Me.LblUserId.Location = new System.Drawing.Point(96, 16)

			Me.LblUserId.Name = "LblUserId"

			Me.LblUserId.Size = new System.Drawing.Size(56, 16)

			Me.LblUserId.TabIndex = 72

			Me.LblUserId.Text = "User Id:"

			' 

			' FrmGetSellerList

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(472, 501)

			Me.Controls.Add(Me.LblUserId)

			Me.Controls.Add(Me.TxtUserId)

			Me.Controls.Add(Me.DatePickEndTo)

			Me.Controls.Add(Me.DatePickEndFrom)

			Me.Controls.Add(Me.LblEndSep)

			Me.Controls.Add(Me.OptEndTime)

			Me.Controls.Add(Me.DatePickStartTo)

			Me.Controls.Add(Me.DatePickStartFrom)

			Me.Controls.Add(Me.LblStartSep)

			Me.Controls.Add(Me.OptStartTime)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetSellerList)

			Me.Name = "FrmGetSellerList"

			Me.Text = "GetSellerList"

			'Me.Load += new System.EventHandler(Me.FrmGetSellerList_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


    Public Context As ApiContext


		Private Sub  FrmGetSellerList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


			OptStartTime.Checked = true

			Dim now As DateTime = DateTime.Now

			DatePickStartTo.Value = now

			DatePickStartFrom.Value = now.AddDays(-5)

			DatePickEndTo.Value = now.AddDays(5)

			DatePickEndFrom.Value = now

		End Sub

    Private Sub OptStartTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptStartTime.CheckedChanged

        If OptStartTime.Checked Then

            DatePickStartFrom.Enabled = True

            DatePickStartTo.Enabled = True

            DatePickEndFrom.Enabled = False

            DatePickEndTo.Enabled = False
        End If
    End Sub

    Private Sub OptEndTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptEndTime.CheckedChanged
        If OptEndTime.Checked Then

            DatePickStartFrom.Enabled = False

            DatePickStartTo.Enabled = False

            DatePickEndFrom.Enabled = True

            DatePickEndTo.Enabled = True
        End If
    End Sub



    Private Sub BtnGetSellerList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetSellerList.Click



        Try

            LstItems.Items.Clear()

            Dim apicall As GetSellerListCall = New GetSellerListCall(Context)

            apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)



            'Pagination is required

            apicall.Pagination = New PaginationType()

            apicall.Pagination.PageNumber = 1

            apicall.Pagination.EntriesPerPage = 200


            If TxtUserId.Text.Length > 0 Then
                apicall.UserID = TxtUserId.Text
            End If



            If OptStartTime.Checked = True Then
                apicall.StartTimeFilter = New TimeFilter(DatePickStartFrom.Value, DatePickStartTo.Value)
            ElseIf OptEndTime.Checked = True Then
                apicall.EndTimeFilter = New TimeFilter(DatePickEndFrom.Value, DatePickEndTo.Value)
            End If

            Dim sellerlist As ItemTypeCollection = apicall.GetSellerList()
            Dim item As ItemType

            For Each item In sellerlist
                Dim listparams(6) As String

                listparams(0) = item.ItemID

                listparams(1) = item.Title

                listparams(2) = item.SellingStatus.CurrentPrice.Value.ToString()

                listparams(3) = item.SellingStatus.QuantitySold.ToString()

                listparams(4) = item.SellingStatus.BidCount.ToString()

                If Not item.BestOfferDetails Is Nothing Then
                    listparams(5) = item.BestOfferDetails.BestOfferEnabled.ToString()
                Else
                    listparams(5) = "False"
                End If


                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstItems.Items.Add(vi)
            Next item

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

