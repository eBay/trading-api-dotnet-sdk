Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormAddsecondChanceItem
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
   
		Friend WithEvents grpResults As System.Windows.Forms.GroupBox 

		Friend WithEvents TxtBuyItNowPrice As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemId As System.Windows.Forms.Label 

		Friend WithEvents TxtItemId As System.Windows.Forms.TextBox 





		Friend WithEvents LblBuyItNowPrice As System.Windows.Forms.Label 

		Friend WithEvents LblDuration As System.Windows.Forms.Label 

		Friend WithEvents CboDuration As System.Windows.Forms.ComboBox

		Friend WithEvents TxtOriginalId As System.Windows.Forms.TextBox 

		Friend WithEvents TxtRecipient As System.Windows.Forms.TextBox 

		Friend WithEvents LblRecipient As System.Windows.Forms.Label 

		Friend WithEvents LblOriginalId As System.Windows.Forms.Label 

		Friend WithEvents BtnAddSecondChanceItem As System.Windows.Forms.Button 

		Friend WithEvents ChkCopyMail As System.Windows.Forms.CheckBox 

		Friend WithEvents BtnVerifyAddSecondChanceItem As System.Windows.Forms.Button 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TxtOriginalId = New System.Windows.Forms.TextBox()
        Me.TxtBuyItNowPrice = New System.Windows.Forms.TextBox()
        Me.TxtRecipient = New System.Windows.Forms.TextBox()
        Me.LblRecipient = New System.Windows.Forms.Label()
        Me.LblOriginalId = New System.Windows.Forms.Label()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.LblItemId = New System.Windows.Forms.Label()
        Me.TxtItemId = New System.Windows.Forms.TextBox()
        Me.LblBuyItNowPrice = New System.Windows.Forms.Label()
        Me.BtnAddSecondChanceItem = New System.Windows.Forms.Button()
        Me.ChkCopyMail = New System.Windows.Forms.CheckBox()
        Me.LblDuration = New System.Windows.Forms.Label()
        Me.BtnVerifyAddSecondChanceItem = New System.Windows.Forms.Button()
        Me.CboDuration = New System.Windows.Forms.ComboBox()
        Me.grpResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtOriginalId
        '
        Me.TxtOriginalId.Location = New System.Drawing.Point(104, 8)
        Me.TxtOriginalId.Name = "TxtOriginalId"
        Me.TxtOriginalId.Size = New System.Drawing.Size(80, 20)
        Me.TxtOriginalId.TabIndex = 30
        Me.TxtOriginalId.Text = ""
        '
        'TxtBuyItNowPrice
        '
        Me.TxtBuyItNowPrice.Location = New System.Drawing.Point(104, 72)
        Me.TxtBuyItNowPrice.Name = "TxtBuyItNowPrice"
        Me.TxtBuyItNowPrice.Size = New System.Drawing.Size(64, 20)
        Me.TxtBuyItNowPrice.TabIndex = 34
        Me.TxtBuyItNowPrice.Text = ""
        '
        'TxtRecipient
        '
        Me.TxtRecipient.Location = New System.Drawing.Point(272, 8)
        Me.TxtRecipient.Name = "TxtRecipient"
        Me.TxtRecipient.Size = New System.Drawing.Size(72, 20)
        Me.TxtRecipient.TabIndex = 31
        Me.TxtRecipient.Text = ""
        '
        'LblRecipient
        '
        Me.LblRecipient.Location = New System.Drawing.Point(200, 8)
        Me.LblRecipient.Name = "LblRecipient"
        Me.LblRecipient.Size = New System.Drawing.Size(64, 18)
        Me.LblRecipient.TabIndex = 38
        Me.LblRecipient.Text = "Recipient:"
        '
        'LblOriginalId
        '
        Me.LblOriginalId.Location = New System.Drawing.Point(8, 8)
        Me.LblOriginalId.Name = "LblOriginalId"
        Me.LblOriginalId.Size = New System.Drawing.Size(88, 18)
        Me.LblOriginalId.TabIndex = 37
        Me.LblOriginalId.Text = "Original Item Id:"
        '
        'grpResults
        '
        Me.grpResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblItemId, Me.TxtItemId})
        Me.grpResults.Location = New System.Drawing.Point(8, 160)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(368, 56)
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
        'LblBuyItNowPrice
        '
        Me.LblBuyItNowPrice.Location = New System.Drawing.Point(8, 72)
        Me.LblBuyItNowPrice.Name = "LblBuyItNowPrice"
        Me.LblBuyItNowPrice.Size = New System.Drawing.Size(64, 18)
        Me.LblBuyItNowPrice.TabIndex = 41
        Me.LblBuyItNowPrice.Text = "BIN Price:"
        '
        'BtnAddSecondChanceItem
        '
        Me.BtnAddSecondChanceItem.Location = New System.Drawing.Point(8, 112)
        Me.BtnAddSecondChanceItem.Name = "BtnAddSecondChanceItem"
        Me.BtnAddSecondChanceItem.Size = New System.Drawing.Size(176, 26)
        Me.BtnAddSecondChanceItem.TabIndex = 36
        Me.BtnAddSecondChanceItem.Text = "AddSecondChanceItem"
        '
        'ChkCopyMail
        '
        Me.ChkCopyMail.Location = New System.Drawing.Point(200, 40)
        Me.ChkCopyMail.Name = "ChkCopyMail"
        Me.ChkCopyMail.Size = New System.Drawing.Size(136, 24)
        Me.ChkCopyMail.TabIndex = 45
        Me.ChkCopyMail.Text = "Copy EMail to Seller"
        '
        'LblDuration
        '
        Me.LblDuration.Location = New System.Drawing.Point(8, 40)
        Me.LblDuration.Name = "LblDuration"
        Me.LblDuration.Size = New System.Drawing.Size(64, 18)
        Me.LblDuration.TabIndex = 49
        Me.LblDuration.Text = "Duration:"
        '
        'BtnVerifyAddSecondChanceItem
        '
        Me.BtnVerifyAddSecondChanceItem.Location = New System.Drawing.Point(200, 112)
        Me.BtnVerifyAddSecondChanceItem.Name = "BtnVerifyAddSecondChanceItem"
        Me.BtnVerifyAddSecondChanceItem.Size = New System.Drawing.Size(176, 26)
        Me.BtnVerifyAddSecondChanceItem.TabIndex = 52
        Me.BtnVerifyAddSecondChanceItem.Text = "VerifyAddSecondChanceItem"
        '
        'CboDuration
        '
        Me.CboDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDuration.Location = New System.Drawing.Point(104, 40)
        Me.CboDuration.Name = "CboDuration"
        Me.CboDuration.Size = New System.Drawing.Size(64, 21)
        Me.CboDuration.TabIndex = 53
        '
        'FormAddsecondChanceItem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(384, 229)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CboDuration, Me.BtnVerifyAddSecondChanceItem, Me.LblDuration, Me.ChkCopyMail, Me.TxtOriginalId, Me.TxtBuyItNowPrice, Me.TxtRecipient, Me.LblRecipient, Me.LblOriginalId, Me.grpResults, Me.LblBuyItNowPrice, Me.BtnAddSecondChanceItem})
        Me.Name = "FormAddsecondChanceItem"
        Me.Text = "AddSecondChanceItem"
        Me.grpResults.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


		Public Context As ApiContext

		Private Sub  FrmAddItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		

        Dim durations() As String = Split("Days_1;Days_3;Days_5;Days_7;Days_10;Days_30;Days_60;Days_90;Days_120;GTC", ";")
        REM Dim durations() As String = [Enum].GetNames(GetType(ListingDurationCodeType))
        Dim item As String

        For Each item In durations

            If item <> "CustomCode" Then

                CboDuration.Items.Add(item)
            End If

        Next item



        CboDuration.SelectedIndex = 0

		end Sub

		private Function  FillItem() As ItemType

		

			Dim item As ItemType = new ItemType()

				

			item.ItemID = TxtOriginalId.Text

			

        item.ListingDuration = CboDuration.SelectedItem.ToString()





			If TxtBuyItNowPrice.Text.Length > 0 Then
            item.BuyItNowPrice = New AmountType()

				item.BuyItNowPrice.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)

				item.BuyItNowPrice.Value = Double.Parse(Me.TxtBuyItNowPrice.Text, NumberStyles.Currency)

        End If


        Return item

    End Function


    Private Sub BtnAddSecondChanceItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddSecondChanceItem.Click



        Try



            TxtItemId.Text = ""


            Dim item As ItemType = FillItem()

            Dim apicall As AddSecondChanceItemCall = New AddSecondChanceItemCall(Context)



            apicall.RecipientBidderUserID = TxtRecipient.Text



            apicall.AddSecondChanceItem(item, TxtRecipient.Text)

            TxtItemId.Text = item.ItemID



        Catch ex As Exception
            'Me.txtErrors.Text = ex.Message
            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub BtnVerifyAddSecondChanceItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerifyAddSecondChanceItem.Click



        Try

            TxtItemId.Text = ""


            Dim item As ItemType = FillItem()

            Dim apicall As VerifyAddSecondChanceItemCall = New VerifyAddSecondChanceItemCall(Context)



            apicall.RecipientBidderUserID = TxtRecipient.Text



            apicall.VerifyAddSecondChanceItem(item, TxtRecipient.Text)

            TxtItemId.Text = ""



        Catch ex As Exception
            'Me.txtErrors.Text = ex.Message
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

