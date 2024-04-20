Imports System
Imports System.Globalization
Imports System.Collections
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormAddItem
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


    Friend WithEvents OpenFileDialogIMG As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnVerifyAddItem As System.Windows.Forms.Button
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents LblItemId As System.Windows.Forms.Label
    Friend WithEvents TxtItemId As System.Windows.Forms.TextBox
    Friend WithEvents TxtListingFee As System.Windows.Forms.TextBox
    Friend WithEvents LblListingFee As System.Windows.Forms.Label
    Friend WithEvents BtnAddItem As System.Windows.Forms.Button
    Friend WithEvents GrpPictures As System.Windows.Forms.GroupBox
    Friend WithEvents CboPicDisplay As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAddPic As System.Windows.Forms.Button
    Friend WithEvents ListPictures As System.Windows.Forms.ListBox
    Friend WithEvents BtnRemovePic As System.Windows.Forms.Button
    Friend WithEvents CboListType As System.Windows.Forms.ComboBox
    Friend WithEvents LblListType As System.Windows.Forms.Label
    Friend WithEvents TxtPayPalEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents LblPayPalEmailAddress As System.Windows.Forms.Label
    Friend WithEvents TxtApplicationData As System.Windows.Forms.TextBox
    Friend WithEvents lblApplicationData As System.Windows.Forms.Label
    Friend WithEvents TxtCategory2 As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory2 As System.Windows.Forms.Label
    Friend WithEvents ChkEnableBestOffer As System.Windows.Forms.CheckBox
    Friend WithEvents CboDuration As System.Windows.Forms.ComboBox
    Friend WithEvents TxtLocation As System.Windows.Forms.TextBox
    Friend WithEvents LblLocation As System.Windows.Forms.Label
    Friend WithEvents LblDuration As System.Windows.Forms.Label
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents LblQuantity As System.Windows.Forms.Label
    Friend WithEvents ChkHighLight As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBoldTitle As System.Windows.Forms.CheckBox
    Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox
    Friend WithEvents TxtBuyItNowPrice As System.Windows.Forms.TextBox
    Friend WithEvents TxtCategory As System.Windows.Forms.TextBox
    Friend WithEvents TxtReservePrice As System.Windows.Forms.TextBox
    Friend WithEvents TxtStartPrice As System.Windows.Forms.TextBox
    Friend WithEvents LblCategory As System.Windows.Forms.Label
    Friend WithEvents LblStartPrice As System.Windows.Forms.Label
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents LblBuyItNowPrice As System.Windows.Forms.Label
    Friend WithEvents LblReservePrice As System.Windows.Forms.Label
    Friend WithEvents conditionLabel As System.Windows.Forms.Label
    Friend WithEvents CboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents LblBINPrice As System.Windows.Forms.Label
































    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OpenFileDialogIMG = New System.Windows.Forms.OpenFileDialog
        Me.BtnVerifyAddItem = New System.Windows.Forms.Button
        Me.grpResults = New System.Windows.Forms.GroupBox
        Me.LblItemId = New System.Windows.Forms.Label
        Me.TxtItemId = New System.Windows.Forms.TextBox
        Me.TxtListingFee = New System.Windows.Forms.TextBox
        Me.LblListingFee = New System.Windows.Forms.Label
        Me.BtnAddItem = New System.Windows.Forms.Button
        Me.GrpPictures = New System.Windows.Forms.GroupBox
        Me.CboPicDisplay = New System.Windows.Forms.ComboBox
        Me.BtnAddPic = New System.Windows.Forms.Button
        Me.ListPictures = New System.Windows.Forms.ListBox
        Me.BtnRemovePic = New System.Windows.Forms.Button
        Me.CboListType = New System.Windows.Forms.ComboBox
        Me.LblListType = New System.Windows.Forms.Label
        Me.TxtPayPalEmailAddress = New System.Windows.Forms.TextBox
        Me.LblPayPalEmailAddress = New System.Windows.Forms.Label
        Me.TxtApplicationData = New System.Windows.Forms.TextBox
        Me.lblApplicationData = New System.Windows.Forms.Label
        Me.TxtCategory2 = New System.Windows.Forms.TextBox
        Me.lblCategory2 = New System.Windows.Forms.Label
        Me.ChkEnableBestOffer = New System.Windows.Forms.CheckBox
        Me.CboDuration = New System.Windows.Forms.ComboBox
        Me.TxtLocation = New System.Windows.Forms.TextBox
        Me.LblLocation = New System.Windows.Forms.Label
        Me.LblDuration = New System.Windows.Forms.Label
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.LblQuantity = New System.Windows.Forms.Label
        Me.ChkHighLight = New System.Windows.Forms.CheckBox
        Me.ChkBoldTitle = New System.Windows.Forms.CheckBox
        Me.TxtTitle = New System.Windows.Forms.TextBox
        Me.TxtDescription = New System.Windows.Forms.TextBox
        Me.TxtBuyItNowPrice = New System.Windows.Forms.TextBox
        Me.TxtCategory = New System.Windows.Forms.TextBox
        Me.TxtReservePrice = New System.Windows.Forms.TextBox
        Me.TxtStartPrice = New System.Windows.Forms.TextBox
        Me.LblCategory = New System.Windows.Forms.Label
        Me.LblStartPrice = New System.Windows.Forms.Label
        Me.LblDescription = New System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.Label
        Me.LblBuyItNowPrice = New System.Windows.Forms.Label
        Me.LblReservePrice = New System.Windows.Forms.Label
        Me.LblBINPrice = New System.Windows.Forms.Label
        Me.conditionLabel = New System.Windows.Forms.Label
        Me.CboCondition = New System.Windows.Forms.ComboBox
        Me.grpResults.SuspendLayout()
        Me.GrpPictures.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialogIMG
        '
        Me.OpenFileDialogIMG.Filter = "JPEG files (*.jpg)|*.jpg|GIf files (*.gIf)|*.gIf|All Files|*.*"
        '
        'BtnVerifyAddItem
        '
        Me.BtnVerifyAddItem.Location = New System.Drawing.Point(264, 432)
        Me.BtnVerifyAddItem.Name = "BtnVerifyAddItem"
        Me.BtnVerifyAddItem.Size = New System.Drawing.Size(112, 23)
        Me.BtnVerifyAddItem.TabIndex = 87
        Me.BtnVerifyAddItem.Text = "VerifyAddItem"
        '
        'grpResults
        '
        Me.grpResults.Controls.Add(Me.LblItemId)
        Me.grpResults.Controls.Add(Me.TxtItemId)
        Me.grpResults.Controls.Add(Me.TxtListingFee)
        Me.grpResults.Controls.Add(Me.LblListingFee)
        Me.grpResults.Location = New System.Drawing.Point(24, 464)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(592, 100)
        Me.grpResults.TabIndex = 79
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Results"
        '
        'LblItemId
        '
        Me.LblItemId.Location = New System.Drawing.Point(8, 24)
        Me.LblItemId.Name = "LblItemId"
        Me.LblItemId.Size = New System.Drawing.Size(100, 23)
        Me.LblItemId.TabIndex = 1
        Me.LblItemId.Text = "ItemId:"
        '
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(120, 24)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.ReadOnly = True
        Me.TxtItemId.Size = New System.Drawing.Size(100, 20)
        Me.TxtItemId.TabIndex = 0
        '
        'TxtListingFee
        '
        Me.TxtListingFee.Location = New System.Drawing.Point(376, 24)
        Me.TxtListingFee.Name = "TxtListingFee"
        Me.TxtListingFee.ReadOnly = True
        Me.TxtListingFee.Size = New System.Drawing.Size(100, 20)
        Me.TxtListingFee.TabIndex = 0
        '
        'LblListingFee
        '
        Me.LblListingFee.Location = New System.Drawing.Point(328, 24)
        Me.LblListingFee.Name = "LblListingFee"
        Me.LblListingFee.Size = New System.Drawing.Size(100, 23)
        Me.LblListingFee.TabIndex = 1
        Me.LblListingFee.Text = "Fees:"
        '
        'BtnAddItem
        '
        Me.BtnAddItem.Location = New System.Drawing.Point(128, 432)
        Me.BtnAddItem.Name = "BtnAddItem"
        Me.BtnAddItem.Size = New System.Drawing.Size(75, 23)
        Me.BtnAddItem.TabIndex = 71
        Me.BtnAddItem.Text = "AddItem"
        '
        'GrpPictures
        '
        Me.GrpPictures.Controls.Add(Me.CboPicDisplay)
        Me.GrpPictures.Controls.Add(Me.BtnAddPic)
        Me.GrpPictures.Controls.Add(Me.ListPictures)
        Me.GrpPictures.Controls.Add(Me.BtnRemovePic)
        Me.GrpPictures.Location = New System.Drawing.Point(24, 272)
        Me.GrpPictures.Name = "GrpPictures"
        Me.GrpPictures.Size = New System.Drawing.Size(520, 136)
        Me.GrpPictures.TabIndex = 78
        Me.GrpPictures.TabStop = False
        Me.GrpPictures.Text = "Pictures that you want to host in eBay"
        '
        'CboPicDisplay
        '
        Me.CboPicDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPicDisplay.Location = New System.Drawing.Point(352, 96)
        Me.CboPicDisplay.Name = "CboPicDisplay"
        Me.CboPicDisplay.Size = New System.Drawing.Size(121, 21)
        Me.CboPicDisplay.TabIndex = 54
        '
        'BtnAddPic
        '
        Me.BtnAddPic.Location = New System.Drawing.Point(360, 24)
        Me.BtnAddPic.Name = "BtnAddPic"
        Me.BtnAddPic.Size = New System.Drawing.Size(75, 23)
        Me.BtnAddPic.TabIndex = 1
        Me.BtnAddPic.Text = "Add..."
        '
        'ListPictures
        '
        Me.ListPictures.Location = New System.Drawing.Point(16, 24)
        Me.ListPictures.Name = "ListPictures"
        Me.ListPictures.Size = New System.Drawing.Size(120, 95)
        Me.ListPictures.TabIndex = 0
        '
        'BtnRemovePic
        '
        Me.BtnRemovePic.Location = New System.Drawing.Point(360, 56)
        Me.BtnRemovePic.Name = "BtnRemovePic"
        Me.BtnRemovePic.Size = New System.Drawing.Size(75, 23)
        Me.BtnRemovePic.TabIndex = 1
        Me.BtnRemovePic.Text = "Remove"
        '
        'CboListType
        '
        Me.CboListType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboListType.Location = New System.Drawing.Point(96, 64)
        Me.CboListType.Name = "CboListType"
        Me.CboListType.Size = New System.Drawing.Size(121, 21)
        Me.CboListType.TabIndex = 116
        '
        'LblListType
        '
        Me.LblListType.Location = New System.Drawing.Point(24, 64)
        Me.LblListType.Name = "LblListType"
        Me.LblListType.Size = New System.Drawing.Size(100, 23)
        Me.LblListType.TabIndex = 115
        Me.LblListType.Text = "List Type:"
        '
        'TxtPayPalEmailAddress
        '
        Me.TxtPayPalEmailAddress.Location = New System.Drawing.Point(352, 232)
        Me.TxtPayPalEmailAddress.Name = "TxtPayPalEmailAddress"
        Me.TxtPayPalEmailAddress.Size = New System.Drawing.Size(100, 20)
        Me.TxtPayPalEmailAddress.TabIndex = 113
        Me.TxtPayPalEmailAddress.Text = "me@ebay.com"
        '
        'LblPayPalEmailAddress
        '
        Me.LblPayPalEmailAddress.Location = New System.Drawing.Point(256, 224)
        Me.LblPayPalEmailAddress.Name = "LblPayPalEmailAddress"
        Me.LblPayPalEmailAddress.Size = New System.Drawing.Size(72, 32)
        Me.LblPayPalEmailAddress.TabIndex = 114
        Me.LblPayPalEmailAddress.Text = "PayPal Email Address:"
        '
        'TxtApplicationData
        '
        Me.TxtApplicationData.Location = New System.Drawing.Point(120, 160)
        Me.TxtApplicationData.Name = "TxtApplicationData"
        Me.TxtApplicationData.Size = New System.Drawing.Size(100, 20)
        Me.TxtApplicationData.TabIndex = 111
        '
        'lblApplicationData
        '
        Me.lblApplicationData.Location = New System.Drawing.Point(24, 160)
        Me.lblApplicationData.Name = "lblApplicationData"
        Me.lblApplicationData.Size = New System.Drawing.Size(100, 23)
        Me.lblApplicationData.TabIndex = 112
        Me.lblApplicationData.Text = "ApplicationData:"
        '
        'TxtCategory2
        '
        Me.TxtCategory2.Location = New System.Drawing.Point(208, 96)
        Me.TxtCategory2.Name = "TxtCategory2"
        Me.TxtCategory2.Size = New System.Drawing.Size(100, 20)
        Me.TxtCategory2.TabIndex = 109
        '
        'lblCategory2
        '
        Me.lblCategory2.Location = New System.Drawing.Point(144, 96)
        Me.lblCategory2.Name = "lblCategory2"
        Me.lblCategory2.Size = New System.Drawing.Size(100, 23)
        Me.lblCategory2.TabIndex = 110
        Me.lblCategory2.Text = "Category2:"
        '
        'ChkEnableBestOffer
        '
        Me.ChkEnableBestOffer.Location = New System.Drawing.Point(232, 56)
        Me.ChkEnableBestOffer.Name = "ChkEnableBestOffer"
        Me.ChkEnableBestOffer.Size = New System.Drawing.Size(104, 32)
        Me.ChkEnableBestOffer.TabIndex = 108
        Me.ChkEnableBestOffer.Text = "Enable Best Offer"
        Me.ChkEnableBestOffer.Visible = False
        '
        'CboDuration
        '
        Me.CboDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDuration.Location = New System.Drawing.Point(432, 96)
        Me.CboDuration.Name = "CboDuration"
        Me.CboDuration.Size = New System.Drawing.Size(104, 21)
        Me.CboDuration.TabIndex = 107
        '
        'TxtLocation
        '
        Me.TxtLocation.Location = New System.Drawing.Point(120, 232)
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.Size = New System.Drawing.Size(100, 20)
        Me.TxtLocation.TabIndex = 105
        Me.TxtLocation.Text = "San Jose"
        '
        'LblLocation
        '
        Me.LblLocation.Location = New System.Drawing.Point(24, 232)
        Me.LblLocation.Name = "LblLocation"
        Me.LblLocation.Size = New System.Drawing.Size(100, 23)
        Me.LblLocation.TabIndex = 106
        Me.LblLocation.Text = "Location:"
        '
        'LblDuration
        '
        Me.LblDuration.Location = New System.Drawing.Point(352, 96)
        Me.LblDuration.Name = "LblDuration"
        Me.LblDuration.Size = New System.Drawing.Size(48, 23)
        Me.LblDuration.TabIndex = 104
        Me.LblDuration.Text = "Duration:"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(432, 64)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.Size = New System.Drawing.Size(100, 20)
        Me.TxtQuantity.TabIndex = 102
        Me.TxtQuantity.Text = "1"
        '
        'LblQuantity
        '
        Me.LblQuantity.Location = New System.Drawing.Point(352, 64)
        Me.LblQuantity.Name = "LblQuantity"
        Me.LblQuantity.Size = New System.Drawing.Size(56, 23)
        Me.LblQuantity.TabIndex = 103
        Me.LblQuantity.Text = "Quantity:"
        '
        'ChkHighLight
        '
        Me.ChkHighLight.Location = New System.Drawing.Point(144, 32)
        Me.ChkHighLight.Name = "ChkHighLight"
        Me.ChkHighLight.Size = New System.Drawing.Size(104, 24)
        Me.ChkHighLight.TabIndex = 101
        Me.ChkHighLight.Text = "HighLight"
        '
        'ChkBoldTitle
        '
        Me.ChkBoldTitle.Location = New System.Drawing.Point(64, 32)
        Me.ChkBoldTitle.Name = "ChkBoldTitle"
        Me.ChkBoldTitle.Size = New System.Drawing.Size(104, 24)
        Me.ChkBoldTitle.TabIndex = 100
        Me.ChkBoldTitle.Text = "Bold"
        '
        'TxtTitle
        '
        Me.TxtTitle.Location = New System.Drawing.Point(96, 8)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(100, 20)
        Me.TxtTitle.TabIndex = 88
        Me.TxtTitle.Text = "My ItemTitle"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(120, 192)
        Me.TxtDescription.Multiline = True
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(100, 20)
        Me.TxtDescription.TabIndex = 93
        Me.TxtDescription.Text = "My item description."
        '
        'TxtBuyItNowPrice
        '
        Me.TxtBuyItNowPrice.Location = New System.Drawing.Point(536, 128)
        Me.TxtBuyItNowPrice.Name = "TxtBuyItNowPrice"
        Me.TxtBuyItNowPrice.Size = New System.Drawing.Size(100, 20)
        Me.TxtBuyItNowPrice.TabIndex = 92
        Me.TxtBuyItNowPrice.Text = "10.0"
        '
        'TxtCategory
        '
        Me.TxtCategory.Location = New System.Drawing.Point(88, 96)
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.Size = New System.Drawing.Size(100, 20)
        Me.TxtCategory.TabIndex = 89
        Me.TxtCategory.Text = "11104"
        '
        'TxtReservePrice
        '
        Me.TxtReservePrice.Location = New System.Drawing.Point(336, 128)
        Me.TxtReservePrice.Name = "TxtReservePrice"
        Me.TxtReservePrice.Size = New System.Drawing.Size(100, 20)
        Me.TxtReservePrice.TabIndex = 90
        Me.TxtReservePrice.Text = "2.0"
        '
        'TxtStartPrice
        '
        Me.TxtStartPrice.Location = New System.Drawing.Point(96, 128)
        Me.TxtStartPrice.Name = "TxtStartPrice"
        Me.TxtStartPrice.Size = New System.Drawing.Size(100, 20)
        Me.TxtStartPrice.TabIndex = 91
        Me.TxtStartPrice.Text = "1.00"
        '
        'LblCategory
        '
        Me.LblCategory.Location = New System.Drawing.Point(24, 96)
        Me.LblCategory.Name = "LblCategory"
        Me.LblCategory.Size = New System.Drawing.Size(100, 23)
        Me.LblCategory.TabIndex = 95
        Me.LblCategory.Text = "Category:"
        '
        'LblStartPrice
        '
        Me.LblStartPrice.Location = New System.Drawing.Point(24, 128)
        Me.LblStartPrice.Name = "LblStartPrice"
        Me.LblStartPrice.Size = New System.Drawing.Size(100, 23)
        Me.LblStartPrice.TabIndex = 97
        Me.LblStartPrice.Text = "Start Price:"
        '
        'LblDescription
        '
        Me.LblDescription.Location = New System.Drawing.Point(24, 192)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(100, 23)
        Me.LblDescription.TabIndex = 99
        Me.LblDescription.Text = "Description:"
        '
        'LblTitle
        '
        Me.LblTitle.Location = New System.Drawing.Point(24, 8)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(100, 23)
        Me.LblTitle.TabIndex = 94
        Me.LblTitle.Text = "Title:"
        '
        'LblBuyItNowPrice
        '
        Me.LblBuyItNowPrice.Location = New System.Drawing.Point(352, 128)
        Me.LblBuyItNowPrice.Name = "LblBuyItNowPrice"
        Me.LblBuyItNowPrice.Size = New System.Drawing.Size(100, 23)
        Me.LblBuyItNowPrice.TabIndex = 98
        Me.LblBuyItNowPrice.Text = "BIN Price:"
        '
        'LblReservePrice
        '
        Me.LblReservePrice.Location = New System.Drawing.Point(232, 128)
        Me.LblReservePrice.Name = "LblReservePrice"
        Me.LblReservePrice.Size = New System.Drawing.Size(80, 23)
        Me.LblReservePrice.TabIndex = 96
        Me.LblReservePrice.Text = "Reserve Price:"
        '
        'LblBINPrice
        '
        Me.LblBINPrice.Location = New System.Drawing.Point(464, 128)
        Me.LblBINPrice.Name = "LblBINPrice"
        Me.LblBINPrice.Size = New System.Drawing.Size(56, 23)
        Me.LblBINPrice.TabIndex = 117
        Me.LblBINPrice.Text = "BIN Price:"
        '
        'conditionLabel
        '
        Me.conditionLabel.Location = New System.Drawing.Point(256, 192)
        Me.conditionLabel.Name = "conditionLabel"
        Me.conditionLabel.Size = New System.Drawing.Size(72, 20)
        Me.conditionLabel.TabIndex = 114
        Me.conditionLabel.Text = "Condition:"
        '
        'CboCondition
        '
        Me.CboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCondition.Location = New System.Drawing.Point(352, 189)
        Me.CboCondition.Name = "CboCondition"
        Me.CboCondition.Size = New System.Drawing.Size(100, 21)
        Me.CboCondition.TabIndex = 116
        '
        'FormAddItem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(672, 590)
        Me.Controls.Add(Me.LblBINPrice)
        Me.Controls.Add(Me.CboCondition)
        Me.Controls.Add(Me.CboListType)
        Me.Controls.Add(Me.LblListType)
        Me.Controls.Add(Me.TxtPayPalEmailAddress)
        Me.Controls.Add(Me.conditionLabel)
        Me.Controls.Add(Me.LblPayPalEmailAddress)
        Me.Controls.Add(Me.TxtApplicationData)
        Me.Controls.Add(Me.lblApplicationData)
        Me.Controls.Add(Me.TxtCategory2)
        Me.Controls.Add(Me.lblCategory2)
        Me.Controls.Add(Me.ChkEnableBestOffer)
        Me.Controls.Add(Me.CboDuration)
        Me.Controls.Add(Me.TxtLocation)
        Me.Controls.Add(Me.LblLocation)
        Me.Controls.Add(Me.LblDuration)
        Me.Controls.Add(Me.TxtQuantity)
        Me.Controls.Add(Me.LblQuantity)
        Me.Controls.Add(Me.ChkHighLight)
        Me.Controls.Add(Me.ChkBoldTitle)
        Me.Controls.Add(Me.TxtTitle)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.TxtBuyItNowPrice)
        Me.Controls.Add(Me.TxtCategory)
        Me.Controls.Add(Me.TxtReservePrice)
        Me.Controls.Add(Me.TxtStartPrice)
        Me.Controls.Add(Me.LblCategory)
        Me.Controls.Add(Me.LblStartPrice)
        Me.Controls.Add(Me.LblDescription)
        Me.Controls.Add(Me.LblTitle)
        Me.Controls.Add(Me.LblBuyItNowPrice)
        Me.Controls.Add(Me.LblReservePrice)
        Me.Controls.Add(Me.BtnVerifyAddItem)
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.BtnAddItem)
        Me.Controls.Add(Me.GrpPictures)
        Me.Name = "FormAddItem"
        Me.Text = "AddItem"
        Me.grpResults.ResumeLayout(False)
        Me.grpResults.PerformLayout()
        Me.GrpPictures.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Context As ApiContext

    Private Sub FrmAddItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim item As String

        Dim durations() As String = Split("Days_1;Days_3;Days_5;Days_7", ";")
        REM Dim durations() As String = [Enum].GetNames(GetType(ListingDurationCodeType))
        For Each item In durations
            If item <> "CustomCode" Then
                CboDuration.Items.Add(item)
            End If
        Next item

        Dim photoDisplay As Type = GetType(PhotoDisplayCodeType)
        For Each item In [Enum].GetNames(photoDisplay)
            If item <> "CustomCode" Then
                CboPicDisplay.Items.Add(item)
            End If
        Next item

        Dim listingType As Type = GetType(ListingTypeCodeType)
        For Each item In [Enum].GetNames(listingType)
            If item <> "CustomCode" And item <> "Unknown" Then
                CboListType.Items.Add(item)
            End If
        Next item

        CboCondition.Items.Add(New ComboxItem("New", 1000))
        CboCondition.Items.Add(New ComboxItem("Used", 3000))

        CboDuration.SelectedIndex = 0
        CboPicDisplay.SelectedIndex = 0
        CboListType.SelectedIndex = 0
        CboCondition.SelectedIndex = 0

    End Sub


    Public Class ComboxItem
        Public Text As String = ""

        Public Value As Integer

        Public Sub New(ByVal _Text As String, ByVal _Value As Integer)
            Text = _Text
            Value = _Value
        End Sub

        Public Overrides Function ToString() As String
            Return Me.Text
        End Function
    End Class

    Private Function FillItem() As ItemType

        Dim item As ItemType = New ItemType
        ' Set UP Defaults
        item.Currency = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
        item.Country = SiteUtility.GetCountryCodeType(Context.Site)

        item.PaymentMethods = New BuyerPaymentMethodCodeTypeCollection
        item.PaymentMethods.Add(BuyerPaymentMethodCodeType.PayPal)
        item.RegionID = "0"

        ' Set specIfied values from the form

        item.Title = Me.TxtTitle.Text

        item.Description = Me.TxtDescription.Text



        item.Quantity = Int32.Parse(TxtQuantity.Text, NumberStyles.None)

        item.Location = TxtLocation.Text

        item.ListingDuration = CboDuration.SelectedItem.ToString()

        item.PrimaryCategory = New CategoryType

        item.PrimaryCategory.CategoryID = Me.TxtCategory.Text

        If TxtStartPrice.Text.Length > 0 Then
            item.StartPrice = New AmountType
            item.StartPrice.currencyID = item.Currency
            item.StartPrice.Value = Convert.ToDouble(Me.TxtStartPrice.Text)
        End If

        If TxtReservePrice.Visible And TxtReservePrice.Text.Length > 0 Then

            item.ReservePrice = New AmountType

            item.ReservePrice.currencyID = item.Currency

            item.ReservePrice.Value = Convert.ToDouble(Me.TxtReservePrice.Text)

        End If

        If TxtBuyItNowPrice.Visible And TxtBuyItNowPrice.Text.Length > 0 Then
            item.BuyItNowPrice = New AmountType
            item.BuyItNowPrice.currencyID = item.Currency
            item.BuyItNowPrice.Value = Convert.ToDouble(Me.TxtBuyItNowPrice.Text)
        End If

        Dim enhancements As ListingEnhancementsCodeTypeCollection = New ListingEnhancementsCodeTypeCollection

        If Me.ChkBoldTitle.Checked Then
            enhancements.Add(ListingEnhancementsCodeType.BoldTitle)
        End If

        If Me.ChkHighLight.Checked Then
            enhancements.Add(ListingEnhancementsCodeType.Highlight)
        End If

        item.ListingType = [Enum].Parse(GetType(ListingTypeCodeType), CboListType.SelectedItem.ToString())

        If ChkEnableBestOffer.Visible Then
            item.BestOfferDetails = New BestOfferDetailsType
            item.BestOfferDetails.BestOfferEnabled = ChkEnableBestOffer.Checked
        End If


        If enhancements.Count > 0 Then
            item.ListingEnhancement = enhancements
        End If

        item.BestOfferDetails = New BestOfferDetailsType
        item.BestOfferDetails.BestOfferEnabled = ChkEnableBestOffer.Checked

        item.PayPalEmailAddress = TxtPayPalEmailAddress.Text
        item.ApplicationData = TxtApplicationData.Text

        If TxtCategory2.Text.Length > 0 Then
            item.SecondaryCategory = New CategoryType
            item.SecondaryCategory.CategoryID = TxtCategory2.Text
        End If

        Dim comboxItem As ComboxItem = CboCondition.SelectedItem
        Dim condition As Integer = comboxItem.Value
        item.ConditionID = condition


        'add shipping information
        item.ShippingDetails = getShippingDetails()
        'add handling time
        item.DispatchTimeMax = 1
        'add policy
        item.ReturnPolicy = GetPolicyForUS()

        Return item

    End Function



    Private Sub BtnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddItem.Click

        Try

            TxtItemId.Text = ""

            TxtListingFee.Text = ""

            Dim item As ItemType = FillItem()
            Dim ApiCall As AddItemCall = New AddItemCall(Context)
            Dim pic As String

            If ListPictures.Items.Count > 0 Then
                ApiCall.PictureFileList = New StringCollection
                item.PictureDetails = New PictureDetailsType
                item.PictureDetails.PhotoDisplay = [Enum].Parse(GetType(PhotoDisplayCodeType), CboPicDisplay.SelectedItem.ToString())
            End If

            For Each pic In ListPictures.Items
                ApiCall.PictureFileList.Add(pic)
            Next


            Dim fees As FeeTypeCollection = ApiCall.AddItem(item)
            Dim fee As FeeType
            TxtItemId.Text = item.ItemID

            For Each fee In fees
                If fee.Name = "ListingFee" Then
                    TxtListingFee.Text = fee.Fee.Value.ToString()
                End If
            Next

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub BtnVerIfyAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerifyAddItem.Click

        Try

            TxtItemId.Text = ""

            TxtListingFee.Text = ""

            Dim item As ItemType = FillItem()

            Dim ApiCall As VerifyAddItemCall = New VerifyAddItemCall(Context)

            'Dim pic As String

            '' eBay Developer Technical Support Team(DTS) - Devanathan
            '' Dated: 24-Feb-2016 9:33PM
            '' Following If condition and for loop were commented to add a dummy image URL for bypass upload site hosting call for VerifyAddItem call

            'For Each pic In ListPictures.Items
            '    ApiCall.PictureFileList.Add(pic)
            'Next


            'If ListPictures.Items.Count > 0 Then
            '    item.PictureDetails = New PictureDetailsType
            '    item.PictureDetails.PhotoDisplay = [Enum].Parse(GetType(PhotoDisplayCodeType), CboPicDisplay.SelectedItem.ToString())
            'End If

            ' eBay Developer Technical Support Team(DTS) - Devanathan
            ' Dated: 24-Feb-2016 9:33PM
            ' Added the following four lines of code dummy image URL for bypass upload site hosting call for VerifyAddItem call

            item.PictureDetails = New PictureDetailsType()
            item.PictureDetails.PhotoDisplaySpecified = True
            item.PictureDetails.PhotoDisplay = PhotoDisplayCodeType.None
            item.PictureDetails.PictureURL = New StringCollection()
            item.PictureDetails.PictureURL.Add("http://i.ebayimg.com/00/s/MTAwMFgxMDAw/z/Oi4AAOSwzgRWzsz9/$_12.JPG?set_id=880000500F")


            Dim fees As FeeTypeCollection = ApiCall.VerifyAddItem(item)
            Dim fee As FeeType


            For Each fee In fees
                If fee.Name = "ListingFee" Then
                    TxtListingFee.Text = fee.Fee.Value.ToString()
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub BtnAddPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPic.Click
        If OpenFileDialogIMG.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ListPictures.Items.Add(OpenFileDialogIMG.FileName)
        End If
    End Sub



    Private Sub BtnRemovePic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemovePic.Click

        If -1 <> ListPictures.SelectedIndex Then
            ListPictures.Items.RemoveAt(ListPictures.SelectedIndex)
        End If

    End Sub

    Private Sub CboListType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboListType.SelectedIndexChanged, CboCondition.SelectedIndexChanged
        Dim selectedText As String = CboListType.Text
        Dim VisibleFlag As Boolean = (selectedText.Equals("StoresFixedPrice") Or selectedText.Equals("FixedPriceItem"))

        ChkEnableBestOffer.Visible = VisibleFlag
        TxtReservePrice.Visible = Not VisibleFlag
        TxtBuyItNowPrice.Visible = Not VisibleFlag

    End Sub

    Private Sub TxtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescription.TextChanged

    End Sub

    Private Sub OpenFileDialogIMG_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogIMG.FileOk

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblBINPrice.Click

    End Sub

    Private Sub LblDuration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblDuration.Click

    End Sub

    Private Function getShippingDetails() As ShippingDetailsType
        'Shipping details.
        Dim sd As ShippingDetailsType = New ShippingDetailsType
        Dim salesTax As SalesTaxType = New SalesTaxType
        salesTax.SalesTaxPercent = 0.0825F
        salesTax.SalesTaxState = "CA"
        sd.ApplyShippingDiscount = True
        Dim at As AmountType = New AmountType
        at.Value = 2.8
        at.currencyID = CurrencyCodeType.USD
        'sd.InsuranceFee = at
        'sd.InsuranceOption = InsuranceOptionCodeType.Optional
        sd.PaymentInstructions = "eBay DotNet SDK test instruction."

        'Set calculated shipping.
        sd.ShippingType = ShippingTypeCodeType.Flat

        Dim st1 As ShippingServiceOptionsType = New ShippingServiceOptionsType
        st1.ShippingService = ShippingServiceCodeType.ShippingMethodStandard.ToString()
        at = New AmountType
        at.Value = 2.0
        at.currencyID = CurrencyCodeType.USD
        st1.ShippingServiceAdditionalCost = at
        at = New AmountType
        at.Value = 1.0
        at.currencyID = CurrencyCodeType.USD
        st1.ShippingServiceCost = at
        st1.ShippingServicePriority = 1
        at = New AmountType
        at.Value = 1.0
        at.currencyID = CurrencyCodeType.USD
        st1.ShippingInsuranceCost = at

        Dim st2 As ShippingServiceOptionsType = New ShippingServiceOptionsType
        st2.ExpeditedService = True
        st2.ShippingService = ShippingServiceCodeType.ShippingMethodExpress.ToString()
        at = New AmountType
        at.Value = 2.0
        at.currencyID = CurrencyCodeType.USD
        st2.ShippingServiceAdditionalCost = at
        at = New AmountType
        at.Value = 1.5
        at.currencyID = CurrencyCodeType.USD
        st2.ShippingServiceCost = at
        st2.ShippingServicePriority = 2
        at = New AmountType
        at.Value = 1.0
        at.currencyID = CurrencyCodeType.USD
        st2.ShippingInsuranceCost = at

        Dim serviceOptions As ShippingServiceOptionsTypeCollection = New ShippingServiceOptionsTypeCollection
        serviceOptions.Add(st1)
        serviceOptions.Add(st2)

        sd.ShippingServiceOptions = serviceOptions

        Return sd

    End Function

    'get policy
    Public Function GetPolicyForUS() As ReturnPolicyType
        Dim policy As ReturnPolicyType = New ReturnPolicyType
        policy.Refund = "MoneyBack"
        policy.ReturnsWithinOption = "Days_14"
        policy.ReturnsAcceptedOption = "ReturnsAccepted"
        policy.ShippingCostPaidByOption = "Buyer"
        Return policy
    End Function


End Class




