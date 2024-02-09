Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetBestOffers
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
    Friend WithEvents LblBestOfferID As System.Windows.Forms.Label
    Friend WithEvents TxtBestOfferID As System.Windows.Forms.TextBox
    Friend WithEvents CboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents LblBestOfferStatus As System.Windows.Forms.Label
    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents LblCurrency As System.Windows.Forms.Label
    Friend WithEvents TxtLocation As System.Windows.Forms.TextBox
    Friend WithEvents LblLocation As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
    Friend WithEvents TxtBuyItNowPrice As System.Windows.Forms.TextBox
    Friend WithEvents LblBuyItNowPrice As System.Windows.Forms.Label
    Friend WithEvents TxtEndTime As System.Windows.Forms.TextBox
    Friend WithEvents LblEndTime As System.Windows.Forms.Label
    Friend WithEvents LstBestOffers As System.Windows.Forms.ListView
    Friend WithEvents ClmBestOfferID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmExpirationTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmPrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmQuantity As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmFeedbackScore As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmRegistrationDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmUserID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmEmail As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmUserIDMessage As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmSellerMessage As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnGetBestOffers As System.Windows.Forms.Button
    Friend WithEvents LblItemID As System.Windows.Forms.Label
    Friend WithEvents TxtItemID As System.Windows.Forms.TextBox






















    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.LblBestOfferID = New System.Windows.Forms.Label()
        Me.TxtBestOfferID = New System.Windows.Forms.TextBox()
        Me.CboFilter = New System.Windows.Forms.ComboBox()
        Me.LblBestOfferStatus = New System.Windows.Forms.Label()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.TxtCurrency = New System.Windows.Forms.TextBox()
        Me.LblCurrency = New System.Windows.Forms.Label()
        Me.TxtLocation = New System.Windows.Forms.TextBox()
        Me.LblLocation = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.TxtBuyItNowPrice = New System.Windows.Forms.TextBox()
        Me.LblBuyItNowPrice = New System.Windows.Forms.Label()
        Me.TxtEndTime = New System.Windows.Forms.TextBox()
        Me.LblEndTime = New System.Windows.Forms.Label()
        Me.LstBestOffers = New System.Windows.Forms.ListView()
        Me.ClmBestOfferID = New System.Windows.Forms.ColumnHeader()
        Me.ClmExpirationTime = New System.Windows.Forms.ColumnHeader()
        Me.ClmPrice = New System.Windows.Forms.ColumnHeader()
        Me.ClmStatus = New System.Windows.Forms.ColumnHeader()
        Me.ClmQuantity = New System.Windows.Forms.ColumnHeader()
        Me.ClmFeedbackScore = New System.Windows.Forms.ColumnHeader()
        Me.ClmRegistrationDate = New System.Windows.Forms.ColumnHeader()
        Me.ClmUserID = New System.Windows.Forms.ColumnHeader()
        Me.ClmEmail = New System.Windows.Forms.ColumnHeader()
        Me.ClmUserIDMessage = New System.Windows.Forms.ColumnHeader()
        Me.ClmSellerMessage = New System.Windows.Forms.ColumnHeader()
        Me.BtnGetBestOffers = New System.Windows.Forms.Button()
        Me.LblItemID = New System.Windows.Forms.Label()
        Me.TxtItemID = New System.Windows.Forms.TextBox()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblBestOfferID
        '
        Me.LblBestOfferID.Location = New System.Drawing.Point(208, 16)
        Me.LblBestOfferID.Name = "LblBestOfferID"
        Me.LblBestOfferID.Size = New System.Drawing.Size(78, 18)
        Me.LblBestOfferID.TabIndex = 94
        Me.LblBestOfferID.Text = "Best Offer ID:"
        '
        'TxtBestOfferID
        '
        Me.TxtBestOfferID.Location = New System.Drawing.Point(320, 16)
        Me.TxtBestOfferID.Name = "TxtBestOfferID"
        Me.TxtBestOfferID.Size = New System.Drawing.Size(88, 20)
        Me.TxtBestOfferID.TabIndex = 95
        Me.TxtBestOfferID.Text = ""
        '
        'CboFilter
        '
        Me.CboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFilter.Location = New System.Drawing.Point(560, 16)
        Me.CboFilter.Name = "CboFilter"
        Me.CboFilter.Size = New System.Drawing.Size(144, 21)
        Me.CboFilter.TabIndex = 91
        '
        'LblBestOfferStatus
        '
        Me.LblBestOfferStatus.Location = New System.Drawing.Point(432, 16)
        Me.LblBestOfferStatus.Name = "LblBestOfferStatus"
        Me.LblBestOfferStatus.Size = New System.Drawing.Size(100, 18)
        Me.LblBestOfferStatus.TabIndex = 90
        Me.LblBestOfferStatus.Text = "Best Offer Status:"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.TxtCurrency, Me.LblCurrency, Me.TxtLocation, Me.LblLocation, Me.LblTitle, Me.TxtTitle, Me.TxtBuyItNowPrice, Me.LblBuyItNowPrice, Me.TxtEndTime, Me.LblEndTime, Me.LstBestOffers})
        Me.GrpResult.Location = New System.Drawing.Point(8, 96)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(760, 336)
        Me.GrpResult.TabIndex = 89
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(552, 64)
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.ReadOnly = True
        Me.TxtCurrency.Size = New System.Drawing.Size(128, 20)
        Me.TxtCurrency.TabIndex = 87
        Me.TxtCurrency.Text = ""
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(472, 64)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(64, 23)
        Me.LblCurrency.TabIndex = 86
        Me.LblCurrency.Text = "Currency:"
        '
        'TxtLocation
        '
        Me.TxtLocation.Location = New System.Drawing.Point(552, 24)
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.ReadOnly = True
        Me.TxtLocation.Size = New System.Drawing.Size(128, 20)
        Me.TxtLocation.TabIndex = 85
        Me.TxtLocation.Text = ""
        '
        'LblLocation
        '
        Me.LblLocation.Location = New System.Drawing.Point(472, 24)
        Me.LblLocation.Name = "LblLocation"
        Me.LblLocation.Size = New System.Drawing.Size(56, 23)
        Me.LblLocation.TabIndex = 84
        Me.LblLocation.Text = "Location:"
        '
        'LblTitle
        '
        Me.LblTitle.Location = New System.Drawing.Point(24, 24)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(72, 23)
        Me.LblTitle.TabIndex = 78
        Me.LblTitle.Text = "Title:"
        '
        'TxtTitle
        '
        Me.TxtTitle.Location = New System.Drawing.Point(96, 24)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.ReadOnly = True
        Me.TxtTitle.Size = New System.Drawing.Size(312, 20)
        Me.TxtTitle.TabIndex = 82
        Me.TxtTitle.Text = ""
        '
        'TxtBuyItNowPrice
        '
        Me.TxtBuyItNowPrice.Location = New System.Drawing.Point(336, 64)
        Me.TxtBuyItNowPrice.Name = "TxtBuyItNowPrice"
        Me.TxtBuyItNowPrice.ReadOnly = True
        Me.TxtBuyItNowPrice.Size = New System.Drawing.Size(128, 20)
        Me.TxtBuyItNowPrice.TabIndex = 83
        Me.TxtBuyItNowPrice.Text = ""
        '
        'LblBuyItNowPrice
        '
        Me.LblBuyItNowPrice.Location = New System.Drawing.Point(232, 64)
        Me.LblBuyItNowPrice.Name = "LblBuyItNowPrice"
        Me.LblBuyItNowPrice.Size = New System.Drawing.Size(96, 23)
        Me.LblBuyItNowPrice.TabIndex = 77
        Me.LblBuyItNowPrice.Text = "BuyItNow Price:"
        '
        'TxtEndTime
        '
        Me.TxtEndTime.Location = New System.Drawing.Point(96, 64)
        Me.TxtEndTime.Name = "TxtEndTime"
        Me.TxtEndTime.ReadOnly = True
        Me.TxtEndTime.Size = New System.Drawing.Size(120, 20)
        Me.TxtEndTime.TabIndex = 81
        Me.TxtEndTime.Text = ""
        '
        'LblEndTime
        '
        Me.LblEndTime.Location = New System.Drawing.Point(24, 64)
        Me.LblEndTime.Name = "LblEndTime"
        Me.LblEndTime.Size = New System.Drawing.Size(64, 23)
        Me.LblEndTime.TabIndex = 76
        Me.LblEndTime.Text = "End Time:"
        '
        'LstBestOffers
        '
        Me.LstBestOffers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmBestOfferID, Me.ClmExpirationTime, Me.ClmPrice, Me.ClmStatus, Me.ClmQuantity, Me.ClmFeedbackScore, Me.ClmRegistrationDate, Me.ClmUserID, Me.ClmEmail, Me.ClmUserIDMessage, Me.ClmSellerMessage})
        Me.LstBestOffers.GridLines = True
        Me.LstBestOffers.Location = New System.Drawing.Point(24, 104)
        Me.LstBestOffers.Name = "LstBestOffers"
        Me.LstBestOffers.Size = New System.Drawing.Size(720, 216)
        Me.LstBestOffers.TabIndex = 13
        Me.LstBestOffers.View = System.Windows.Forms.View.Details
        '
        'ClmBestOfferID
        '
        Me.ClmBestOfferID.Text = "Best Offer ID"
        Me.ClmBestOfferID.Width = 74
        '
        'ClmExpirationTime
        '
        Me.ClmExpirationTime.Text = "Expiration Time"
        Me.ClmExpirationTime.Width = 88
        '
        'ClmPrice
        '
        Me.ClmPrice.Text = "Price"
        Me.ClmPrice.Width = 40
        '
        'ClmStatus
        '
        Me.ClmStatus.Text = "Status"
        Me.ClmStatus.Width = 44
        '
        'ClmQuantity
        '
        Me.ClmQuantity.Text = "Quantity"
        Me.ClmQuantity.Width = 56
        '
        'ClmFeedbackScore
        '
        Me.ClmFeedbackScore.Text = "Buyer Feedback"
        Me.ClmFeedbackScore.Width = 90
        '
        'ClmRegistrationDate
        '
        Me.ClmRegistrationDate.Text = "Buyer Reg Date"
        Me.ClmRegistrationDate.Width = 90
        '
        'ClmUserID
        '
        Me.ClmUserID.Text = "Buyer User ID"
        Me.ClmUserID.Width = 80
        '
        'ClmEmail
        '
        Me.ClmEmail.Text = "Buyer Email"
        Me.ClmEmail.Width = 70
        '
        'ClmUserIDMessage
        '
        Me.ClmUserIDMessage.Text = "Buyer Message"
        Me.ClmUserIDMessage.Width = 120
        '
        'ClmSellerMessage
        '
        Me.ClmSellerMessage.Text = "Seller Message"
        Me.ClmSellerMessage.Width = 120
        '
        'BtnGetBestOffers
        '
        Me.BtnGetBestOffers.Location = New System.Drawing.Point(288, 64)
        Me.BtnGetBestOffers.Name = "BtnGetBestOffers"
        Me.BtnGetBestOffers.Size = New System.Drawing.Size(176, 23)
        Me.BtnGetBestOffers.TabIndex = 88
        Me.BtnGetBestOffers.Text = "GetBestOffers"
        '
        'LblItemID
        '
        Me.LblItemID.Location = New System.Drawing.Point(24, 16)
        Me.LblItemID.Name = "LblItemID"
        Me.LblItemID.Size = New System.Drawing.Size(48, 18)
        Me.LblItemID.TabIndex = 92
        Me.LblItemID.Text = "Item ID:"
        '
        'TxtItemID
        '
        Me.TxtItemID.Location = New System.Drawing.Point(96, 16)
        Me.TxtItemID.Name = "TxtItemID"
        Me.TxtItemID.Size = New System.Drawing.Size(88, 20)
        Me.TxtItemID.TabIndex = 93
        Me.TxtItemID.Text = ""
        '
        'FormGetBestOffers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 445)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblBestOfferID, Me.TxtBestOfferID, Me.CboFilter, Me.LblBestOfferStatus, Me.GrpResult, Me.BtnGetBestOffers, Me.LblItemID, Me.TxtItemID})
        Me.Name = "FormGetBestOffers"
        Me.Text = "GetBestOffers"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub BtnGetBestOffers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CboFilter.Items.Add("All")
        CboFilter.Items.Add("Active")

        CboFilter.SelectedIndex = 0

    End Sub

    Private Sub BtnGetBestOffers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetBestOffers.Click

        Try
            LstBestOffers.Items.Clear()

            Dim apicall As GetBestOffersCall = New GetBestOffersCall(Context)

            If (TxtBestOfferID.Text.Length > 0) Then
                apicall.BestOfferID = TxtBestOfferID.Text
            End If

            apicall.BestOfferStatus = [Enum].Parse(GetType(BestOfferStatusCodeType), CboFilter.SelectedItem.ToString())
            apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

            Dim ItemID As String = TxtItemID.Text
            Dim bestoffers As BestOfferTypeCollection = apicall.GetBestOffers(ItemID)

            TxtTitle.Text = apicall.Item.Title
            TxtLocation.Text = apicall.Item.Location
            TxtEndTime.Text = apicall.Item.ListingDetails.EndTime.ToString()
            TxtBuyItNowPrice.Text = apicall.Item.BuyItNowPrice.Value.ToString()
            TxtCurrency.Text = apicall.Item.BuyItNowPrice.currencyID.ToString()

            Dim bestoffer As BestOfferType

            For Each bestoffer In bestoffers

                Dim listparams(11) As String
                listparams(0) = bestoffer.BestOfferID
                listparams(1) = bestoffer.ExpirationTime.ToString()
                If (bestoffer.Price Is Nothing) Then
                    listparams(2) = ""
                Else
                    listparams(2) = bestoffer.Price.Value.ToString()
                End If
                listparams(3) = bestoffer.Status.ToString()
                listparams(4) = bestoffer.Quantity.ToString()
                listparams(5) = bestoffer.Buyer.FeedbackScore.ToString()
                listparams(6) = bestoffer.Buyer.RegistrationDate.ToString()
                listparams(7) = bestoffer.Buyer.UserID
                listparams(8) = bestoffer.Buyer.Email
                listparams(9) = bestoffer.BuyerMessage
                listparams(10) = bestoffer.SellerMessage

                Dim vi As ListViewItem = New ListViewItem(listparams)
                Me.LstBestOffers.Items.Add(vi)

            Next bestoffer

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
End Class

