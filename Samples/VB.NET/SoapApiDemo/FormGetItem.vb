
Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetItem
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

    Friend WithEvents BtnListItem As System.Windows.Forms.Button





    Friend WithEvents LblTitle As System.Windows.Forms.Label



    Friend WithEvents LblCurrentPrice As System.Windows.Forms.Label

    Friend WithEvents LblBidCount As System.Windows.Forms.Label



    Friend WithEvents LblCategory As System.Windows.Forms.Label


    Friend WithEvents LblCategory2 As System.Windows.Forms.Label


    Friend WithEvents LblStartTime As System.Windows.Forms.Label


    Friend WithEvents LblBuyItNowPrice As System.Windows.Forms.Label

    Friend WithEvents LblQuantity As System.Windows.Forms.Label


    Friend WithEvents LblQuantitySold As System.Windows.Forms.Label


    Friend WithEvents LblEndTime As System.Windows.Forms.Label



    Friend WithEvents LblHighBidder As System.Windows.Forms.Label
    Private WithEvents LblItemId As System.Windows.Forms.Label
    Private WithEvents TxtItemId As System.Windows.Forms.TextBox
    Private WithEvents BtnGetItem As System.Windows.Forms.Button
    Private WithEvents GrpResult As System.Windows.Forms.GroupBox
    Private WithEvents TxtTitle As System.Windows.Forms.TextBox
    Private WithEvents TxtCurrentPrice As System.Windows.Forms.TextBox
    Private WithEvents TxtBidCount As System.Windows.Forms.TextBox
    Private WithEvents TxtCategory As System.Windows.Forms.TextBox
    Private WithEvents TxtCategory2 As System.Windows.Forms.TextBox
    Private WithEvents TxtStartTime As System.Windows.Forms.TextBox
    Private WithEvents TxtBuyItNowPrice As System.Windows.Forms.TextBox
    Private WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Private WithEvents TxtQuantitySold As System.Windows.Forms.TextBox
    Private WithEvents TxtEndTime As System.Windows.Forms.TextBox
    Private WithEvents TxtHighBidder As System.Windows.Forms.TextBox
    Friend WithEvents LblBestOfferEnabled As System.Windows.Forms.Label
    Friend WithEvents TxtBestOfferEnabled As System.Windows.Forms.TextBox
    Friend WithEvents LblBestOfferCount As System.Windows.Forms.Label
    Friend WithEvents TxtBestOfferCount As System.Windows.Forms.TextBox
    Friend WithEvents lblApplicationData As System.Windows.Forms.Label
    Friend WithEvents TxtApplicationData As System.Windows.Forms.TextBox
    Friend WithEvents LblPictureURL As System.Windows.Forms.Label
    Friend WithEvents TxtPictureURL As System.Windows.Forms.TextBox
    Friend WithEvents lblGalleryURL As System.Windows.Forms.Label
    Friend WithEvents TxtGalleryURL As System.Windows.Forms.TextBox
    Friend WithEvents TxtPayPalEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents LblPayPalEmailAddress As System.Windows.Forms.Label


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.LblItemId = New System.Windows.Forms.Label()
        Me.TxtItemId = New System.Windows.Forms.TextBox()
        Me.BtnGetItem = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.lblApplicationData = New System.Windows.Forms.Label()
        Me.TxtApplicationData = New System.Windows.Forms.TextBox()
        Me.LblPictureURL = New System.Windows.Forms.Label()
        Me.TxtPictureURL = New System.Windows.Forms.TextBox()
        Me.lblGalleryURL = New System.Windows.Forms.Label()
        Me.TxtGalleryURL = New System.Windows.Forms.TextBox()
        Me.TxtPayPalEmailAddress = New System.Windows.Forms.TextBox()
        Me.LblPayPalEmailAddress = New System.Windows.Forms.Label()
        Me.LblBestOfferEnabled = New System.Windows.Forms.Label()
        Me.TxtBestOfferEnabled = New System.Windows.Forms.TextBox()
        Me.LblBestOfferCount = New System.Windows.Forms.Label()
        Me.TxtBestOfferCount = New System.Windows.Forms.TextBox()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.TxtCurrentPrice = New System.Windows.Forms.TextBox()
        Me.LblCurrentPrice = New System.Windows.Forms.Label()
        Me.LblBidCount = New System.Windows.Forms.Label()
        Me.TxtBidCount = New System.Windows.Forms.TextBox()
        Me.TxtCategory = New System.Windows.Forms.TextBox()
        Me.LblCategory = New System.Windows.Forms.Label()
        Me.TxtCategory2 = New System.Windows.Forms.TextBox()
        Me.LblCategory2 = New System.Windows.Forms.Label()
        Me.TxtStartTime = New System.Windows.Forms.TextBox()
        Me.LblStartTime = New System.Windows.Forms.Label()
        Me.TxtBuyItNowPrice = New System.Windows.Forms.TextBox()
        Me.LblBuyItNowPrice = New System.Windows.Forms.Label()
        Me.LblQuantity = New System.Windows.Forms.Label()
        Me.TxtQuantity = New System.Windows.Forms.TextBox()
        Me.LblQuantitySold = New System.Windows.Forms.Label()
        Me.TxtQuantitySold = New System.Windows.Forms.TextBox()
        Me.LblEndTime = New System.Windows.Forms.Label()
        Me.TxtEndTime = New System.Windows.Forms.TextBox()
        Me.TxtHighBidder = New System.Windows.Forms.TextBox()
        Me.LblHighBidder = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblItemId
        '
        Me.LblItemId.Location = New System.Drawing.Point(112, 8)
        Me.LblItemId.Name = "LblItemId"
        Me.LblItemId.Size = New System.Drawing.Size(80, 23)
        Me.LblItemId.TabIndex = 40
        Me.LblItemId.Text = "Item Id:"
        '
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(192, 8)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.Size = New System.Drawing.Size(128, 20)
        Me.TxtItemId.TabIndex = 27
        Me.TxtItemId.Text = ""
        '
        'BtnGetItem
        '
        Me.BtnGetItem.Location = New System.Drawing.Point(192, 40)
        Me.BtnGetItem.Name = "BtnGetItem"
        Me.BtnGetItem.Size = New System.Drawing.Size(104, 23)
        Me.BtnGetItem.TabIndex = 28
        Me.BtnGetItem.Text = "GetItem"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblApplicationData, Me.TxtApplicationData, Me.LblPictureURL, Me.TxtPictureURL, Me.lblGalleryURL, Me.TxtGalleryURL, Me.TxtPayPalEmailAddress, Me.LblPayPalEmailAddress, Me.LblBestOfferEnabled, Me.TxtBestOfferEnabled, Me.LblBestOfferCount, Me.TxtBestOfferCount, Me.LblTitle, Me.TxtTitle, Me.TxtCurrentPrice, Me.LblCurrentPrice, Me.LblBidCount, Me.TxtBidCount, Me.TxtCategory, Me.LblCategory, Me.TxtCategory2, Me.LblCategory2, Me.TxtStartTime, Me.LblStartTime, Me.TxtBuyItNowPrice, Me.LblBuyItNowPrice, Me.LblQuantity, Me.TxtQuantity, Me.LblQuantitySold, Me.TxtQuantitySold, Me.LblEndTime, Me.TxtEndTime, Me.TxtHighBidder, Me.LblHighBidder})
        Me.GrpResult.Location = New System.Drawing.Point(8, 72)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(504, 312)
        Me.GrpResult.TabIndex = 41
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'lblApplicationData
        '
        Me.lblApplicationData.Location = New System.Drawing.Point(8, 248)
        Me.lblApplicationData.Name = "lblApplicationData"
        Me.lblApplicationData.Size = New System.Drawing.Size(96, 23)
        Me.lblApplicationData.TabIndex = 95
        Me.lblApplicationData.Text = "ApplicationData:"
        '
        'TxtApplicationData
        '
        Me.TxtApplicationData.Location = New System.Drawing.Point(120, 248)
        Me.TxtApplicationData.Name = "TxtApplicationData"
        Me.TxtApplicationData.ReadOnly = True
        Me.TxtApplicationData.Size = New System.Drawing.Size(120, 20)
        Me.TxtApplicationData.TabIndex = 101
        Me.TxtApplicationData.Text = ""
        '
        'LblPictureURL
        '
        Me.LblPictureURL.Location = New System.Drawing.Point(8, 280)
        Me.LblPictureURL.Name = "LblPictureURL"
        Me.LblPictureURL.Size = New System.Drawing.Size(72, 23)
        Me.LblPictureURL.TabIndex = 93
        Me.LblPictureURL.Text = "PictureURL:"
        '
        'TxtPictureURL
        '
        Me.TxtPictureURL.Location = New System.Drawing.Point(120, 280)
        Me.TxtPictureURL.Name = "TxtPictureURL"
        Me.TxtPictureURL.ReadOnly = True
        Me.TxtPictureURL.Size = New System.Drawing.Size(120, 20)
        Me.TxtPictureURL.TabIndex = 97
        Me.TxtPictureURL.Text = ""
        '
        'lblGalleryURL
        '
        Me.lblGalleryURL.Location = New System.Drawing.Point(264, 280)
        Me.lblGalleryURL.Name = "lblGalleryURL"
        Me.lblGalleryURL.Size = New System.Drawing.Size(72, 16)
        Me.lblGalleryURL.TabIndex = 94
        Me.lblGalleryURL.Text = "GalleryURL:"
        '
        'TxtGalleryURL
        '
        Me.TxtGalleryURL.Location = New System.Drawing.Point(376, 280)
        Me.TxtGalleryURL.Name = "TxtGalleryURL"
        Me.TxtGalleryURL.ReadOnly = True
        Me.TxtGalleryURL.Size = New System.Drawing.Size(120, 20)
        Me.TxtGalleryURL.TabIndex = 96
        Me.TxtGalleryURL.Text = ""
        '
        'TxtPayPalEmailAddress
        '
        Me.TxtPayPalEmailAddress.Location = New System.Drawing.Point(376, 248)
        Me.TxtPayPalEmailAddress.Name = "TxtPayPalEmailAddress"
        Me.TxtPayPalEmailAddress.ReadOnly = True
        Me.TxtPayPalEmailAddress.Size = New System.Drawing.Size(120, 20)
        Me.TxtPayPalEmailAddress.TabIndex = 99
        Me.TxtPayPalEmailAddress.Text = ""
        '
        'LblPayPalEmailAddress
        '
        Me.LblPayPalEmailAddress.Location = New System.Drawing.Point(264, 248)
        Me.LblPayPalEmailAddress.Name = "LblPayPalEmailAddress"
        Me.LblPayPalEmailAddress.Size = New System.Drawing.Size(120, 16)
        Me.LblPayPalEmailAddress.TabIndex = 92
        Me.LblPayPalEmailAddress.Text = "PayPalEmailAddress:"
        '
        'LblBestOfferEnabled
        '
        Me.LblBestOfferEnabled.Location = New System.Drawing.Point(8, 216)
        Me.LblBestOfferEnabled.Name = "LblBestOfferEnabled"
        Me.LblBestOfferEnabled.Size = New System.Drawing.Size(104, 23)
        Me.LblBestOfferEnabled.TabIndex = 74
        Me.LblBestOfferEnabled.Text = "Best Offer Enabled:"
        '
        'TxtBestOfferEnabled
        '
        Me.TxtBestOfferEnabled.Location = New System.Drawing.Point(120, 216)
        Me.TxtBestOfferEnabled.Name = "TxtBestOfferEnabled"
        Me.TxtBestOfferEnabled.ReadOnly = True
        Me.TxtBestOfferEnabled.Size = New System.Drawing.Size(120, 20)
        Me.TxtBestOfferEnabled.TabIndex = 77
        Me.TxtBestOfferEnabled.Text = ""
        '
        'LblBestOfferCount
        '
        Me.LblBestOfferCount.Location = New System.Drawing.Point(264, 216)
        Me.LblBestOfferCount.Name = "LblBestOfferCount"
        Me.LblBestOfferCount.Size = New System.Drawing.Size(96, 23)
        Me.LblBestOfferCount.TabIndex = 75
        Me.LblBestOfferCount.Text = "Best Offer Count:"
        '
        'TxtBestOfferCount
        '
        Me.TxtBestOfferCount.Location = New System.Drawing.Point(376, 216)
        Me.TxtBestOfferCount.Name = "TxtBestOfferCount"
        Me.TxtBestOfferCount.ReadOnly = True
        Me.TxtBestOfferCount.Size = New System.Drawing.Size(120, 20)
        Me.TxtBestOfferCount.TabIndex = 76
        Me.TxtBestOfferCount.Text = ""
        '
        'LblTitle
        '
        Me.LblTitle.Location = New System.Drawing.Point(8, 24)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(72, 23)
        Me.LblTitle.TabIndex = 61
        Me.LblTitle.Text = "Title:"
        '
        'TxtTitle
        '
        Me.TxtTitle.Location = New System.Drawing.Point(80, 24)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.ReadOnly = True
        Me.TxtTitle.Size = New System.Drawing.Size(416, 20)
        Me.TxtTitle.TabIndex = 72
        Me.TxtTitle.Text = ""
        '
        'TxtCurrentPrice
        '
        Me.TxtCurrentPrice.Location = New System.Drawing.Point(120, 88)
        Me.TxtCurrentPrice.Name = "TxtCurrentPrice"
        Me.TxtCurrentPrice.ReadOnly = True
        Me.TxtCurrentPrice.Size = New System.Drawing.Size(120, 20)
        Me.TxtCurrentPrice.TabIndex = 73
        Me.TxtCurrentPrice.Text = ""
        '
        'LblCurrentPrice
        '
        Me.LblCurrentPrice.Location = New System.Drawing.Point(8, 88)
        Me.LblCurrentPrice.Name = "LblCurrentPrice"
        Me.LblCurrentPrice.Size = New System.Drawing.Size(72, 23)
        Me.LblCurrentPrice.TabIndex = 60
        Me.LblCurrentPrice.Text = "Price:"
        '
        'LblBidCount
        '
        Me.LblBidCount.Location = New System.Drawing.Point(8, 120)
        Me.LblBidCount.Name = "LblBidCount"
        Me.LblBidCount.Size = New System.Drawing.Size(72, 23)
        Me.LblBidCount.TabIndex = 62
        Me.LblBidCount.Text = "BidCount:"
        '
        'TxtBidCount
        '
        Me.TxtBidCount.Location = New System.Drawing.Point(120, 120)
        Me.TxtBidCount.Name = "TxtBidCount"
        Me.TxtBidCount.ReadOnly = True
        Me.TxtBidCount.Size = New System.Drawing.Size(120, 20)
        Me.TxtBidCount.TabIndex = 69
        Me.TxtBidCount.Text = ""
        '
        'TxtCategory
        '
        Me.TxtCategory.Location = New System.Drawing.Point(120, 56)
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.ReadOnly = True
        Me.TxtCategory.Size = New System.Drawing.Size(120, 20)
        Me.TxtCategory.TabIndex = 70
        Me.TxtCategory.Text = ""
        '
        'LblCategory
        '
        Me.LblCategory.Location = New System.Drawing.Point(8, 56)
        Me.LblCategory.Name = "LblCategory"
        Me.LblCategory.Size = New System.Drawing.Size(72, 23)
        Me.LblCategory.TabIndex = 54
        Me.LblCategory.Text = "Category:"
        '
        'TxtCategory2
        '
        Me.TxtCategory2.Location = New System.Drawing.Point(376, 56)
        Me.TxtCategory2.Name = "TxtCategory2"
        Me.TxtCategory2.ReadOnly = True
        Me.TxtCategory2.Size = New System.Drawing.Size(120, 20)
        Me.TxtCategory2.TabIndex = 67
        Me.TxtCategory2.Text = ""
        '
        'LblCategory2
        '
        Me.LblCategory2.Location = New System.Drawing.Point(264, 56)
        Me.LblCategory2.Name = "LblCategory2"
        Me.LblCategory2.Size = New System.Drawing.Size(72, 23)
        Me.LblCategory2.TabIndex = 55
        Me.LblCategory2.Text = "Category2:"
        '
        'TxtStartTime
        '
        Me.TxtStartTime.Location = New System.Drawing.Point(120, 152)
        Me.TxtStartTime.Name = "TxtStartTime"
        Me.TxtStartTime.ReadOnly = True
        Me.TxtStartTime.Size = New System.Drawing.Size(120, 20)
        Me.TxtStartTime.TabIndex = 68
        Me.TxtStartTime.Text = ""
        '
        'LblStartTime
        '
        Me.LblStartTime.Location = New System.Drawing.Point(8, 152)
        Me.LblStartTime.Name = "LblStartTime"
        Me.LblStartTime.Size = New System.Drawing.Size(72, 23)
        Me.LblStartTime.TabIndex = 52
        Me.LblStartTime.Text = "StartTime:"
        '
        'TxtBuyItNowPrice
        '
        Me.TxtBuyItNowPrice.Location = New System.Drawing.Point(376, 88)
        Me.TxtBuyItNowPrice.Name = "TxtBuyItNowPrice"
        Me.TxtBuyItNowPrice.ReadOnly = True
        Me.TxtBuyItNowPrice.Size = New System.Drawing.Size(120, 20)
        Me.TxtBuyItNowPrice.TabIndex = 71
        Me.TxtBuyItNowPrice.Text = ""
        '
        'LblBuyItNowPrice
        '
        Me.LblBuyItNowPrice.Location = New System.Drawing.Point(264, 88)
        Me.LblBuyItNowPrice.Name = "LblBuyItNowPrice"
        Me.LblBuyItNowPrice.Size = New System.Drawing.Size(72, 23)
        Me.LblBuyItNowPrice.TabIndex = 53
        Me.LblBuyItNowPrice.Text = "BIN Price:"
        '
        'LblQuantity
        '
        Me.LblQuantity.Location = New System.Drawing.Point(8, 184)
        Me.LblQuantity.Name = "LblQuantity"
        Me.LblQuantity.Size = New System.Drawing.Size(72, 23)
        Me.LblQuantity.TabIndex = 58
        Me.LblQuantity.Text = "Quantity:"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(120, 184)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.ReadOnly = True
        Me.TxtQuantity.Size = New System.Drawing.Size(120, 20)
        Me.TxtQuantity.TabIndex = 64
        Me.TxtQuantity.Text = ""
        '
        'LblQuantitySold
        '
        Me.LblQuantitySold.Location = New System.Drawing.Point(264, 184)
        Me.LblQuantitySold.Name = "LblQuantitySold"
        Me.LblQuantitySold.Size = New System.Drawing.Size(72, 23)
        Me.LblQuantitySold.TabIndex = 59
        Me.LblQuantitySold.Text = "QuantitySold:"
        '
        'TxtQuantitySold
        '
        Me.TxtQuantitySold.Location = New System.Drawing.Point(376, 184)
        Me.TxtQuantitySold.Name = "TxtQuantitySold"
        Me.TxtQuantitySold.ReadOnly = True
        Me.TxtQuantitySold.Size = New System.Drawing.Size(120, 20)
        Me.TxtQuantitySold.TabIndex = 63
        Me.TxtQuantitySold.Text = ""
        '
        'LblEndTime
        '
        Me.LblEndTime.Location = New System.Drawing.Point(264, 152)
        Me.LblEndTime.Name = "LblEndTime"
        Me.LblEndTime.Size = New System.Drawing.Size(72, 23)
        Me.LblEndTime.TabIndex = 56
        Me.LblEndTime.Text = "EndTime:"
        '
        'TxtEndTime
        '
        Me.TxtEndTime.Location = New System.Drawing.Point(376, 152)
        Me.TxtEndTime.Name = "TxtEndTime"
        Me.TxtEndTime.ReadOnly = True
        Me.TxtEndTime.Size = New System.Drawing.Size(120, 20)
        Me.TxtEndTime.TabIndex = 65
        Me.TxtEndTime.Text = ""
        '
        'TxtHighBidder
        '
        Me.TxtHighBidder.Location = New System.Drawing.Point(376, 120)
        Me.TxtHighBidder.Name = "TxtHighBidder"
        Me.TxtHighBidder.ReadOnly = True
        Me.TxtHighBidder.Size = New System.Drawing.Size(120, 20)
        Me.TxtHighBidder.TabIndex = 66
        Me.TxtHighBidder.Text = ""
        '
        'LblHighBidder
        '
        Me.LblHighBidder.Location = New System.Drawing.Point(264, 120)
        Me.LblHighBidder.Name = "LblHighBidder"
        Me.LblHighBidder.Size = New System.Drawing.Size(72, 23)
        Me.LblHighBidder.TabIndex = 57
        Me.LblHighBidder.Text = "HighBidder:"
        '
        'FormGetItem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 393)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GrpResult, Me.LblItemId, Me.TxtItemId, Me.BtnGetItem})
        Me.Name = "FormGetItem"
        Me.Text = "GetItem"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext
    Private fetchedItem As ItemType

    Private Sub BtnGetItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetItem.Click

        Try
            TxtTitle.Text = ""

            TxtCategory.Text = ""

            TxtCategory2.Text = ""

            TxtCurrentPrice.Text = ""

            TxtBuyItNowPrice.Text = ""

            TxtBidCount.Text = ""

            TxtHighBidder.Text = ""

            TxtStartTime.Text = ""

            TxtEndTime.Text = ""

            TxtQuantity.Text = ""

            TxtQuantitySold.Text = ""


            Dim Apicall As GetItemCall = New GetItemCall(Context)
            Apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
            fetchedItem = Apicall.GetItem(TxtItemId.Text)


            ' Set values from the item returned

            TxtTitle.Text = fetchedItem.Title

            TxtCategory.Text = fetchedItem.PrimaryCategory.CategoryID

            If fetchedItem.SecondaryCategory Is Nothing Then
                TxtCategory2.Text = ""
            Else
                TxtCategory2.Text = fetchedItem.SecondaryCategory.CategoryID
            End If



            TxtCurrentPrice.Text = fetchedItem.SellingStatus.CurrentPrice.Value.ToString()

            TxtBuyItNowPrice.Text = fetchedItem.BuyItNowPrice.Value.ToString()

            TxtBidCount.Text = fetchedItem.SellingStatus.BidCount.ToString()



            If fetchedItem.SellingStatus.HighBidder Is Nothing Then
                TxtHighBidder.Text = ""
            Else
                TxtHighBidder.Text = fetchedItem.SellingStatus.HighBidder.UserID
            End If


            TxtStartTime.Text = fetchedItem.ListingDetails.StartTime.ToString()

            TxtEndTime.Text = fetchedItem.ListingDetails.EndTime.ToString()

            TxtQuantity.Text = fetchedItem.Quantity.ToString()

            TxtQuantitySold.Text = fetchedItem.SellingStatus.QuantitySold.ToString()

            TxtBestOfferCount.Text = ""
            TxtBestOfferEnabled.Text = ""
            If Not fetchedItem.BestOfferDetails Is Nothing Then
                TxtBestOfferCount.Text = fetchedItem.BestOfferDetails.BestOfferCount.ToString()
                TxtBestOfferEnabled.Text = fetchedItem.BestOfferDetails.BestOfferEnabled.ToString()
            End If

            If Not fetchedItem.PayPalEmailAddress Is Nothing Then
                TxtPayPalEmailAddress.Text = fetchedItem.PayPalEmailAddress.ToString()
            End If

            If Not fetchedItem.ApplicationData Is Nothing Then
                TxtApplicationData.Text = fetchedItem.ApplicationData.ToString()
            End If

            TxtPictureURL.Text = ""
            TxtGalleryURL.Text = ""
            If Not fetchedItem.PictureDetails Is Nothing Then
                Dim PictureURLs As StringCollection = fetchedItem.PictureDetails.PictureURL

                If Not PictureURLs Is Nothing Then
                    Dim PictureURL As String = ""
                    Dim i As Integer = 0
                    Dim iMax As Integer = PictureURLs.Count - 1
                    For i = 0 To iMax
                        PictureURL += PictureURLs(i) + ","
                    Next

                    TxtPictureURL.Text = PictureURL
                End If

                'If Not fetchedItem.PictureDetails.GalleryURL Is Nothing Then
                'TxtGalleryURL.Text = fetchedItem.PictureDetails.GalleryURL.ToString()
                'End If

            End If


        Catch ex As Exception
            'Me.txtErrors.Text = ex.Message
            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub FormGetItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Function getItem() As ItemType
        Return fetchedItem
    End Function

End Class

