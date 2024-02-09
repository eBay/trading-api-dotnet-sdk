Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormRelistItem
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
    Friend WithEvents OpenFileDialogIMG As System.Windows.Forms.OpenFileDialog
    Private components As System.ComponentModel.IContainer
    Private WithEvents grpResults As System.Windows.Forms.GroupBox
    Private WithEvents TxtStartPrice As System.Windows.Forms.TextBox
    Private WithEvents TxtTitle As System.Windows.Forms.TextBox
    Private WithEvents TxtDescription As System.Windows.Forms.TextBox
    Private WithEvents TxtBuyItNowPrice As System.Windows.Forms.TextBox
    Private WithEvents LblStartPrice As System.Windows.Forms.Label
    Private WithEvents LblDescription As System.Windows.Forms.Label
    Private WithEvents LblTitle As System.Windows.Forms.Label
    Private WithEvents LblItemId As System.Windows.Forms.Label
    Private WithEvents TxtItemId As System.Windows.Forms.TextBox
    Private WithEvents TxtListingFee As System.Windows.Forms.TextBox
    Private WithEvents LblListingFee As System.Windows.Forms.Label
    Private WithEvents TxtReservePrice As System.Windows.Forms.TextBox
    Private WithEvents LblBuyItNowPrice As System.Windows.Forms.Label
    Private WithEvents LblReservePrice As System.Windows.Forms.Label
    Private WithEvents LblDuration As System.Windows.Forms.Label
    Private WithEvents CboDuration As System.Windows.Forms.ComboBox
    Private WithEvents BtnRelistItem As System.Windows.Forms.Button
    Private WithEvents LblChangeInstr As System.Windows.Forms.Label
    Private WithEvents TxtRelistItemId As System.Windows.Forms.TextBox
    Private WithEvents LblRelistItemId As System.Windows.Forms.Label
    Friend WithEvents GrpDeleteTag As System.Windows.Forms.GroupBox
    Friend WithEvents ChkPayPalEmailAddress As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCategory2 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkApplicationData As System.Windows.Forms.CheckBox
    Friend WithEvents CboEnableBestOffer As System.Windows.Forms.ComboBox
    Friend WithEvents LblEnableBestOffer As System.Windows.Forms.Label
    Friend WithEvents GrpPictures As System.Windows.Forms.GroupBox
    Friend WithEvents CboPicDisplay As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAddPic As System.Windows.Forms.Button
    Friend WithEvents ListPictures As System.Windows.Forms.ListBox
    Friend WithEvents BtnRemovePic As System.Windows.Forms.Button






















    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OpenFileDialogIMG = New System.Windows.Forms.OpenFileDialog()
        Me.TxtStartPrice = New System.Windows.Forms.TextBox()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.TxtBuyItNowPrice = New System.Windows.Forms.TextBox()
        Me.LblStartPrice = New System.Windows.Forms.Label()
        Me.LblDescription = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.LblItemId = New System.Windows.Forms.Label()
        Me.TxtItemId = New System.Windows.Forms.TextBox()
        Me.TxtListingFee = New System.Windows.Forms.TextBox()
        Me.LblListingFee = New System.Windows.Forms.Label()
        Me.TxtReservePrice = New System.Windows.Forms.TextBox()
        Me.LblBuyItNowPrice = New System.Windows.Forms.Label()
        Me.BtnRelistItem = New System.Windows.Forms.Button()
        Me.LblReservePrice = New System.Windows.Forms.Label()
        Me.LblDuration = New System.Windows.Forms.Label()
        Me.CboDuration = New System.Windows.Forms.ComboBox()
        Me.LblChangeInstr = New System.Windows.Forms.Label()
        Me.TxtRelistItemId = New System.Windows.Forms.TextBox()
        Me.LblRelistItemId = New System.Windows.Forms.Label()
        Me.GrpDeleteTag = New System.Windows.Forms.GroupBox()
        Me.ChkPayPalEmailAddress = New System.Windows.Forms.CheckBox()
        Me.ChkCategory2 = New System.Windows.Forms.CheckBox()
        Me.ChkApplicationData = New System.Windows.Forms.CheckBox()
        Me.CboEnableBestOffer = New System.Windows.Forms.ComboBox()
        Me.LblEnableBestOffer = New System.Windows.Forms.Label()
        Me.GrpPictures = New System.Windows.Forms.GroupBox()
        Me.CboPicDisplay = New System.Windows.Forms.ComboBox()
        Me.BtnAddPic = New System.Windows.Forms.Button()
        Me.ListPictures = New System.Windows.Forms.ListBox()
        Me.BtnRemovePic = New System.Windows.Forms.Button()
        Me.grpResults.SuspendLayout()
        Me.GrpDeleteTag.SuspendLayout()
        Me.GrpPictures.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialogIMG
        '
        Me.OpenFileDialogIMG.Filter = "JPEG files (*.jpg)|*.jpg|GIf files (*.gIf)|*.gIf|All Files|*.*"
        '
        'TxtStartPrice
        '
        Me.TxtStartPrice.Location = New System.Drawing.Point(80, 128)
        Me.TxtStartPrice.Name = "TxtStartPrice"
        Me.TxtStartPrice.Size = New System.Drawing.Size(72, 20)
        Me.TxtStartPrice.TabIndex = 33
        Me.TxtStartPrice.Text = ""
        '
        'TxtTitle
        '
        Me.TxtTitle.Location = New System.Drawing.Point(80, 80)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(392, 20)
        Me.TxtTitle.TabIndex = 30
        Me.TxtTitle.Text = ""
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(80, 152)
        Me.TxtDescription.Multiline = True
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(392, 56)
        Me.TxtDescription.TabIndex = 35
        Me.TxtDescription.Text = ""
        '
        'TxtBuyItNowPrice
        '
        Me.TxtBuyItNowPrice.Location = New System.Drawing.Point(408, 128)
        Me.TxtBuyItNowPrice.Name = "TxtBuyItNowPrice"
        Me.TxtBuyItNowPrice.Size = New System.Drawing.Size(64, 20)
        Me.TxtBuyItNowPrice.TabIndex = 34
        Me.TxtBuyItNowPrice.Text = ""
        '
        'LblStartPrice
        '
        Me.LblStartPrice.Location = New System.Drawing.Point(8, 128)
        Me.LblStartPrice.Name = "LblStartPrice"
        Me.LblStartPrice.Size = New System.Drawing.Size(72, 18)
        Me.LblStartPrice.TabIndex = 40
        Me.LblStartPrice.Text = "Start Price:"
        '
        'LblDescription
        '
        Me.LblDescription.Location = New System.Drawing.Point(8, 152)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(72, 18)
        Me.LblDescription.TabIndex = 42
        Me.LblDescription.Text = "Description:"
        '
        'LblTitle
        '
        Me.LblTitle.Location = New System.Drawing.Point(8, 80)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(72, 18)
        Me.LblTitle.TabIndex = 37
        Me.LblTitle.Text = "Title:"
        '
        'grpResults
        '
        Me.grpResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblItemId, Me.TxtItemId, Me.TxtListingFee, Me.LblListingFee})
        Me.grpResults.Location = New System.Drawing.Point(16, 552)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(464, 56)
        Me.grpResults.TabIndex = 44
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Results"
        '
        'LblItemId
        '
        Me.LblItemId.Location = New System.Drawing.Point(8, 24)
        Me.LblItemId.Name = "LblItemId"
        Me.LblItemId.Size = New System.Drawing.Size(48, 23)
        Me.LblItemId.TabIndex = 1
        Me.LblItemId.Text = "ItemId:"
        '
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(64, 24)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.ReadOnly = True
        Me.TxtItemId.Size = New System.Drawing.Size(120, 20)
        Me.TxtItemId.TabIndex = 0
        Me.TxtItemId.Text = ""
        '
        'TxtListingFee
        '
        Me.TxtListingFee.Location = New System.Drawing.Point(376, 24)
        Me.TxtListingFee.Name = "TxtListingFee"
        Me.TxtListingFee.ReadOnly = True
        Me.TxtListingFee.Size = New System.Drawing.Size(72, 20)
        Me.TxtListingFee.TabIndex = 0
        Me.TxtListingFee.Text = ""
        '
        'LblListingFee
        '
        Me.LblListingFee.Location = New System.Drawing.Point(328, 24)
        Me.LblListingFee.Name = "LblListingFee"
        Me.LblListingFee.Size = New System.Drawing.Size(48, 23)
        Me.LblListingFee.TabIndex = 1
        Me.LblListingFee.Text = "Fees:"
        '
        'TxtReservePrice
        '
        Me.TxtReservePrice.Location = New System.Drawing.Point(256, 128)
        Me.TxtReservePrice.Name = "TxtReservePrice"
        Me.TxtReservePrice.Size = New System.Drawing.Size(64, 20)
        Me.TxtReservePrice.TabIndex = 32
        Me.TxtReservePrice.Text = ""
        '
        'LblBuyItNowPrice
        '
        Me.LblBuyItNowPrice.Location = New System.Drawing.Point(336, 128)
        Me.LblBuyItNowPrice.Name = "LblBuyItNowPrice"
        Me.LblBuyItNowPrice.Size = New System.Drawing.Size(64, 18)
        Me.LblBuyItNowPrice.TabIndex = 41
        Me.LblBuyItNowPrice.Text = "BIN Price:"
        '
        'BtnRelistItem
        '
        Me.BtnRelistItem.Location = New System.Drawing.Point(176, 520)
        Me.BtnRelistItem.Name = "BtnRelistItem"
        Me.BtnRelistItem.Size = New System.Drawing.Size(120, 26)
        Me.BtnRelistItem.TabIndex = 36
        Me.BtnRelistItem.Text = "RelistItem"
        '
        'LblReservePrice
        '
        Me.LblReservePrice.Location = New System.Drawing.Point(168, 128)
        Me.LblReservePrice.Name = "LblReservePrice"
        Me.LblReservePrice.Size = New System.Drawing.Size(80, 18)
        Me.LblReservePrice.TabIndex = 39
        Me.LblReservePrice.Text = "Reserve Price:"
        '
        'LblDuration
        '
        Me.LblDuration.Location = New System.Drawing.Point(8, 104)
        Me.LblDuration.Name = "LblDuration"
        Me.LblDuration.Size = New System.Drawing.Size(72, 18)
        Me.LblDuration.TabIndex = 49
        Me.LblDuration.Text = "Duration:"
        '
        'CboDuration
        '
        Me.CboDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDuration.Location = New System.Drawing.Point(80, 104)
        Me.CboDuration.Name = "CboDuration"
        Me.CboDuration.Size = New System.Drawing.Size(80, 21)
        Me.CboDuration.TabIndex = 53
        '
        'LblChangeInstr
        '
        Me.LblChangeInstr.Location = New System.Drawing.Point(128, 56)
        Me.LblChangeInstr.Name = "LblChangeInstr"
        Me.LblChangeInstr.Size = New System.Drawing.Size(280, 18)
        Me.LblChangeInstr.TabIndex = 54
        Me.LblChangeInstr.Text = "Change all fields that you want to change for the Item:"
        '
        'TxtRelistItemId
        '
        Me.TxtRelistItemId.Location = New System.Drawing.Point(240, 16)
        Me.TxtRelistItemId.Name = "TxtRelistItemId"
        Me.TxtRelistItemId.Size = New System.Drawing.Size(72, 20)
        Me.TxtRelistItemId.TabIndex = 55
        Me.TxtRelistItemId.Text = ""
        '
        'LblRelistItemId
        '
        Me.LblRelistItemId.Location = New System.Drawing.Point(160, 16)
        Me.LblRelistItemId.Name = "LblRelistItemId"
        Me.LblRelistItemId.Size = New System.Drawing.Size(80, 18)
        Me.LblRelistItemId.TabIndex = 56
        Me.LblRelistItemId.Text = "Relist Item Id:"
        '
        'GrpDeleteTag
        '
        Me.GrpDeleteTag.Controls.AddRange(New System.Windows.Forms.Control() {Me.ChkPayPalEmailAddress, Me.ChkCategory2, Me.ChkApplicationData})
        Me.GrpDeleteTag.Location = New System.Drawing.Point(8, 256)
        Me.GrpDeleteTag.Name = "GrpDeleteTag"
        Me.GrpDeleteTag.Size = New System.Drawing.Size(456, 112)
        Me.GrpDeleteTag.TabIndex = 84
        Me.GrpDeleteTag.TabStop = False
        Me.GrpDeleteTag.Text = "Delete Selected Data"
        '
        'ChkPayPalEmailAddress
        '
        Me.ChkPayPalEmailAddress.Location = New System.Drawing.Point(24, 72)
        Me.ChkPayPalEmailAddress.Name = "ChkPayPalEmailAddress"
        Me.ChkPayPalEmailAddress.Size = New System.Drawing.Size(160, 24)
        Me.ChkPayPalEmailAddress.TabIndex = 76
        Me.ChkPayPalEmailAddress.Text = "PayPal Email Address"
        '
        'ChkCategory2
        '
        Me.ChkCategory2.Location = New System.Drawing.Point(24, 48)
        Me.ChkCategory2.Name = "ChkCategory2"
        Me.ChkCategory2.Size = New System.Drawing.Size(160, 24)
        Me.ChkCategory2.TabIndex = 75
        Me.ChkCategory2.Text = "Category2"
        '
        'ChkApplicationData
        '
        Me.ChkApplicationData.Location = New System.Drawing.Point(24, 24)
        Me.ChkApplicationData.Name = "ChkApplicationData"
        Me.ChkApplicationData.Size = New System.Drawing.Size(160, 24)
        Me.ChkApplicationData.TabIndex = 73
        Me.ChkApplicationData.Text = "Application Data"
        '
        'CboEnableBestOffer
        '
        Me.CboEnableBestOffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEnableBestOffer.Items.AddRange(New Object() {"True", "False"})
        Me.CboEnableBestOffer.Location = New System.Drawing.Point(112, 216)
        Me.CboEnableBestOffer.Name = "CboEnableBestOffer"
        Me.CboEnableBestOffer.Size = New System.Drawing.Size(80, 21)
        Me.CboEnableBestOffer.TabIndex = 86
        '
        'LblEnableBestOffer
        '
        Me.LblEnableBestOffer.Location = New System.Drawing.Point(8, 216)
        Me.LblEnableBestOffer.Name = "LblEnableBestOffer"
        Me.LblEnableBestOffer.Size = New System.Drawing.Size(104, 18)
        Me.LblEnableBestOffer.TabIndex = 85
        Me.LblEnableBestOffer.Text = "Enable Best Offer:"
        '
        'GrpPictures
        '
        Me.GrpPictures.Controls.AddRange(New System.Windows.Forms.Control() {Me.CboPicDisplay, Me.BtnAddPic, Me.ListPictures, Me.BtnRemovePic})
        Me.GrpPictures.Location = New System.Drawing.Point(16, 384)
        Me.GrpPictures.Name = "GrpPictures"
        Me.GrpPictures.Size = New System.Drawing.Size(464, 128)
        Me.GrpPictures.TabIndex = 90
        Me.GrpPictures.TabStop = False
        Me.GrpPictures.Text = "Pictures that you want to host in eBay"
        '
        'CboPicDisplay
        '
        Me.CboPicDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPicDisplay.Location = New System.Drawing.Point(352, 96)
        Me.CboPicDisplay.Name = "CboPicDisplay"
        Me.CboPicDisplay.Size = New System.Drawing.Size(104, 21)
        Me.CboPicDisplay.TabIndex = 54
        '
        'BtnAddPic
        '
        Me.BtnAddPic.Location = New System.Drawing.Point(360, 24)
        Me.BtnAddPic.Name = "BtnAddPic"
        Me.BtnAddPic.Size = New System.Drawing.Size(80, 23)
        Me.BtnAddPic.TabIndex = 1
        Me.BtnAddPic.Text = "Add..."
        '
        'ListPictures
        '
        Me.ListPictures.Location = New System.Drawing.Point(16, 24)
        Me.ListPictures.Name = "ListPictures"
        Me.ListPictures.Size = New System.Drawing.Size(328, 95)
        Me.ListPictures.TabIndex = 0
        '
        'BtnRemovePic
        '
        Me.BtnRemovePic.Location = New System.Drawing.Point(360, 56)
        Me.BtnRemovePic.Name = "BtnRemovePic"
        Me.BtnRemovePic.Size = New System.Drawing.Size(80, 23)
        Me.BtnRemovePic.TabIndex = 1
        Me.BtnRemovePic.Text = "Remove"
        '
        'FormRelistItem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 614)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GrpPictures, Me.CboEnableBestOffer, Me.LblEnableBestOffer, Me.GrpDeleteTag, Me.TxtRelistItemId, Me.LblRelistItemId, Me.LblChangeInstr, Me.CboDuration, Me.LblDuration, Me.TxtTitle, Me.TxtDescription, Me.TxtBuyItNowPrice, Me.TxtReservePrice, Me.TxtStartPrice, Me.LblStartPrice, Me.LblDescription, Me.LblTitle, Me.grpResults, Me.LblBuyItNowPrice, Me.BtnRelistItem, Me.LblReservePrice})
        Me.Name = "FormRelistItem"
        Me.Text = "RelistItem"
        Me.grpResults.ResumeLayout(False)
        Me.GrpDeleteTag.ResumeLayout(False)
        Me.GrpPictures.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub FrmRelistItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim durations() As String = Split("Days_1;Days_3;Days_5;Days_7;Days_10;Days_30;Days_60;Days_90;Days_120;GTC", ";")
        REM Dim durations() As String = [Enum].GetNames(GetType(ListingDurationCodeType))
        Dim day As String
        Dim item As String

        For Each day In durations
            If day <> "CustomCode" Then
                CboDuration.Items.Add(day)

            End If

        Next day

        CboDuration.SelectedIndex = -1
        Dim photoDisplay As Type = GetType(PhotoDisplayCodeType)
        For Each item In [Enum].GetNames(photoDisplay)
            If item <> "CustomCode" Then
                CboPicDisplay.Items.Add(item)
            End If
        Next item
        CboPicDisplay.SelectedIndex = 0


    End Sub


    Private Sub BtnRelistItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRelistItem.Click

        Try

            TxtItemId.Text = ""

            TxtListingFee.Text = ""
            Dim pic As String



            ' Populate the Item

            Dim item As ItemType = New ItemType()

            Dim deletedFields As eBay.Service.Core.Soap.StringCollection = New StringCollection()

            item.ItemID = TxtRelistItemId.Text


            If TxtTitle.Text.Length > 0 Then

                item.Title = Me.TxtTitle.Text

            End If



            If TxtDescription.Text.Length > 0 Then

                item.Description = Me.TxtDescription.Text

            End If



            If CboDuration.SelectedIndex <> -1 Then

                item.ListingDuration = CboDuration.SelectedItem.ToString()

            End If


            Dim currencyCode As CurrencyCodeType = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)

            If TxtStartPrice.Text.Length > 0 Then

                item.StartPrice = New AmountType()

                item.StartPrice.currencyID = currencyCode

                item.StartPrice.Value = Double.Parse(Me.TxtStartPrice.Text, NumberStyles.Currency)

            End If

            If TxtReservePrice.Text.Length > 0 Then

                item.ReservePrice = New AmountType()

                item.ReservePrice.currencyID = currencyCode

                item.ReservePrice.Value = Double.Parse(Me.TxtReservePrice.Text, NumberStyles.Currency)

            End If

            If TxtBuyItNowPrice.Text.Length > 0 Then

                item.BuyItNowPrice = New AmountType()

                item.BuyItNowPrice.currencyID = currencyCode

                item.BuyItNowPrice.Value = Double.Parse(Me.TxtBuyItNowPrice.Text, NumberStyles.Currency)

            End If

            If (CboEnableBestOffer.SelectedIndex <> -1) Then
                item.BestOfferDetails = New BestOfferDetailsType()
                item.BestOfferDetails.BestOfferEnabled = Boolean.Parse(CboEnableBestOffer.SelectedItem.ToString())
            End If

            If (ChkCategory2.Checked) Then
                deletedFields.Add("item.secondaryCategory")
            End If

            If (ChkPayPalEmailAddress.Checked) Then
                deletedFields.Add("item.payPalEmailAddress")
            End If

            If (ChkApplicationData.Checked) Then
                deletedFields.Add("item.applicationData")
            End If



            Dim apicall As RelistItemCall = New RelistItemCall(Context)

            If ListPictures.Items.Count > 0 Then
                apicall.PictureFileList = New StringCollection()
                item.PictureDetails = New PictureDetailsType()
                item.PictureDetails.PhotoDisplay = [Enum].Parse(GetType(PhotoDisplayCodeType), CboPicDisplay.SelectedItem.ToString())
            End If

            For Each pic In ListPictures.Items
                apicall.PictureFileList.Add(pic)
            Next

            Dim fees As FeeTypeCollection = apicall.RelistItem(item, deletedFields)
            Dim fee As FeeType

            TxtItemId.Text = item.ItemID


            For Each fee In fees

                If fee.Name = "ListingFee" Then

                    TxtListingFee.Text = fee.Fee.Value.ToString()

                End If
            Next fee

        Catch ex As Exception
            'Me.txtErrors.Text = ex.Message
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

    Private Sub ListPictures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPictures.SelectedIndexChanged

    End Sub
End Class

