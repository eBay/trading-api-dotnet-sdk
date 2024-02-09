Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormRespondToBestOffer
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
    Friend WithEvents LblItemID As System.Windows.Forms.Label
    Friend WithEvents TxtItemID As System.Windows.Forms.TextBox
    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
    Friend WithEvents TxtSellerResponse As System.Windows.Forms.TextBox
    Friend WithEvents TxtBestOfferID As System.Windows.Forms.TextBox
    Friend WithEvents LblSellerResponse As System.Windows.Forms.Label
    Friend WithEvents CboAction As System.Windows.Forms.ComboBox
    Friend WithEvents LblAction As System.Windows.Forms.Label
    Friend WithEvents LblBestOfferID As System.Windows.Forms.Label
    Friend WithEvents BtnRespondToBestOffer As System.Windows.Forms.Button
    Friend WithEvents txtCounterOfferPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblCounterOfferPrice As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCounterOfferQuantity As System.Windows.Forms.TextBox




















    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.LblItemID = New System.Windows.Forms.Label()
        Me.TxtItemID = New System.Windows.Forms.TextBox()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.TxtSellerResponse = New System.Windows.Forms.TextBox()
        Me.TxtBestOfferID = New System.Windows.Forms.TextBox()
        Me.LblSellerResponse = New System.Windows.Forms.Label()
        Me.CboAction = New System.Windows.Forms.ComboBox()
        Me.LblAction = New System.Windows.Forms.Label()
        Me.LblBestOfferID = New System.Windows.Forms.Label()
        Me.BtnRespondToBestOffer = New System.Windows.Forms.Button()
        Me.txtCounterOfferPrice = New System.Windows.Forms.TextBox()
        Me.lblCounterOfferPrice = New System.Windows.Forms.Label()
        Me.txtCounterOfferQuantity = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblItemID
        '
        Me.LblItemID.Location = New System.Drawing.Point(16, 48)
        Me.LblItemID.Name = "LblItemID"
        Me.LblItemID.Size = New System.Drawing.Size(120, 16)
        Me.LblItemID.TabIndex = 73
        Me.LblItemID.Text = "Item ID:"
        '
        'TxtItemID
        '
        Me.TxtItemID.Location = New System.Drawing.Point(160, 48)
        Me.TxtItemID.Name = "TxtItemID"
        Me.TxtItemID.Size = New System.Drawing.Size(152, 20)
        Me.TxtItemID.TabIndex = 72
        Me.TxtItemID.Text = ""
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblStatus, Me.TxtStatus})
        Me.GrpResult.Location = New System.Drawing.Point(16, 320)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(304, 64)
        Me.GrpResult.TabIndex = 71
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblStatus
        '
        Me.LblStatus.Location = New System.Drawing.Point(32, 24)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(80, 23)
        Me.LblStatus.TabIndex = 42
        Me.LblStatus.Text = "Status:"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(112, 24)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(72, 20)
        Me.TxtStatus.TabIndex = 41
        Me.TxtStatus.Text = ""
        '
        'TxtSellerResponse
        '
        Me.TxtSellerResponse.Location = New System.Drawing.Point(160, 200)
        Me.TxtSellerResponse.Multiline = True
        Me.TxtSellerResponse.Name = "TxtSellerResponse"
        Me.TxtSellerResponse.Size = New System.Drawing.Size(152, 56)
        Me.TxtSellerResponse.TabIndex = 69
        Me.TxtSellerResponse.Text = ""
        '
        'TxtBestOfferID
        '
        Me.TxtBestOfferID.Location = New System.Drawing.Point(160, 16)
        Me.TxtBestOfferID.Name = "TxtBestOfferID"
        Me.TxtBestOfferID.Size = New System.Drawing.Size(152, 20)
        Me.TxtBestOfferID.TabIndex = 64
        Me.TxtBestOfferID.Text = ""
        '
        'LblSellerResponse
        '
        Me.LblSellerResponse.Location = New System.Drawing.Point(16, 200)
        Me.LblSellerResponse.Name = "LblSellerResponse"
        Me.LblSellerResponse.Size = New System.Drawing.Size(104, 16)
        Me.LblSellerResponse.TabIndex = 70
        Me.LblSellerResponse.Text = "Seller Response:"
        '
        'CboAction
        '
        Me.CboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAction.Location = New System.Drawing.Point(160, 80)
        Me.CboAction.Name = "CboAction"
        Me.CboAction.Size = New System.Drawing.Size(152, 21)
        Me.CboAction.TabIndex = 67
        '
        'LblAction
        '
        Me.LblAction.Location = New System.Drawing.Point(16, 80)
        Me.LblAction.Name = "LblAction"
        Me.LblAction.Size = New System.Drawing.Size(80, 16)
        Me.LblAction.TabIndex = 66
        Me.LblAction.Text = "Action:"
        '
        'LblBestOfferID
        '
        Me.LblBestOfferID.Location = New System.Drawing.Point(16, 16)
        Me.LblBestOfferID.Name = "LblBestOfferID"
        Me.LblBestOfferID.Size = New System.Drawing.Size(80, 16)
        Me.LblBestOfferID.TabIndex = 65
        Me.LblBestOfferID.Text = "BestOffer ID:"
        '
        'BtnRespondToBestOffer
        '
        Me.BtnRespondToBestOffer.Location = New System.Drawing.Point(128, 280)
        Me.BtnRespondToBestOffer.Name = "BtnRespondToBestOffer"
        Me.BtnRespondToBestOffer.Size = New System.Drawing.Size(136, 23)
        Me.BtnRespondToBestOffer.TabIndex = 68
        Me.BtnRespondToBestOffer.Text = "RespondToBestOffer"
        '
        'txtCounterOfferPrice
        '
        Me.txtCounterOfferPrice.Location = New System.Drawing.Point(160, 120)
        Me.txtCounterOfferPrice.Name = "txtCounterOfferPrice"
        Me.txtCounterOfferPrice.Size = New System.Drawing.Size(152, 20)
        Me.txtCounterOfferPrice.TabIndex = 74
        Me.txtCounterOfferPrice.Text = ""
        '
        'lblCounterOfferPrice
        '
        Me.lblCounterOfferPrice.Location = New System.Drawing.Point(16, 120)
        Me.lblCounterOfferPrice.Name = "lblCounterOfferPrice"
        Me.lblCounterOfferPrice.Size = New System.Drawing.Size(88, 24)
        Me.lblCounterOfferPrice.TabIndex = 75
        Me.lblCounterOfferPrice.Text = "Counter Offer Price:"
        '
        'txtCounterOfferQuantity
        '
        Me.txtCounterOfferQuantity.Location = New System.Drawing.Point(160, 160)
        Me.txtCounterOfferQuantity.Name = "txtCounterOfferQuantity"
        Me.txtCounterOfferQuantity.Size = New System.Drawing.Size(152, 20)
        Me.txtCounterOfferQuantity.TabIndex = 74
        Me.txtCounterOfferQuantity.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 32)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Counter Offer Quantity:"
        '
        'FormRespondToBestOffer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 422)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCounterOfferPrice, Me.txtCounterOfferPrice, Me.LblItemID, Me.TxtItemID, Me.GrpResult, Me.TxtSellerResponse, Me.TxtBestOfferID, Me.LblSellerResponse, Me.CboAction, Me.LblAction, Me.LblBestOfferID, Me.BtnRespondToBestOffer, Me.txtCounterOfferQuantity, Me.Label1})
        Me.Name = "FormRespondToBestOffer"
        Me.Text = "RespondToBestOffer"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub FrmRespondToBestOffer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim activity As Type = GetType(BestOfferActionCodeType)
        Dim act As String

        For Each act In [Enum].GetNames(activity)


            If act <> "CustomCode" Then

                CboAction.Items.Add(act)

            End If

        Next act

        CboAction.SelectedIndex = 0

    End Sub

    Private Sub BtnRespondToBestOffer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRespondToBestOffer.Click
 
        Try

            If TxtItemID.Text.Trim().Length = 0 Then
                MsgBox("Please input item id!")
                Return
            End If

            If TxtBestOfferID.Text.Trim().Length = 0 Then
                MsgBox("Please input best offer id!")
                Return
            End If

            TxtStatus.Text = ""

            Dim apicall As RespondToBestOfferCall = New RespondToBestOfferCall(Context)

            Dim BestOfferIDList As StringCollection = New StringCollection()
            BestOfferIDList.Add(TxtBestOfferID.Text)

            Dim cboActionChoice As String = CboAction.SelectedItem.ToString()
            If cboActionChoice = "Counter" Then
                If txtCounterOfferPrice.Text.Trim().Length = 0 Then
                    MsgBox("Please input counter offer price!")
                    Return
                End If

                If txtCounterOfferQuantity.Text.Trim().Length = 0 Then
                    MsgBox("Please input counter offer quantity!")
                    Return
                End If

                Dim CounterOfferPrice As AmountType = New AmountType()
                CounterOfferPrice.currencyID = CurrencyUtility.GetDefaultCurrencyCodeType(Context.Site)
                CounterOfferPrice.Value = Convert.ToDouble(txtCounterOfferPrice.Text)
                Dim Quantity As Int32 = Convert.ToInt32(txtCounterOfferQuantity.Text)
                apicall.RespondToBestOffer(TxtItemID.Text, BestOfferIDList, [Enum].Parse(GetType(BestOfferActionCodeType), CboAction.SelectedItem.ToString()), TxtSellerResponse.Text, CounterOfferPrice, Quantity)
            Else
                apicall.RespondToBestOffer(TxtItemID.Text, BestOfferIDList, [Enum].Parse(GetType(BestOfferActionCodeType), CboAction.SelectedItem.ToString()), TxtSellerResponse.Text)
            End If
            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub CboAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAction.SelectedIndexChanged
        If CboAction.SelectedItem.ToString() = "Counter" Then
            txtCounterOfferPrice.Enabled = True
            txtCounterOfferQuantity.Enabled = True
        Else
            txtCounterOfferPrice.Enabled = False
            txtCounterOfferQuantity.Enabled = False

        End If
    End Sub
End Class
