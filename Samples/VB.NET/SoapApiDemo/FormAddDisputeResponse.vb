Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormAddDisputeResponse
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


    Friend WithEvents BtnAddDisputeResponse As System.Windows.Forms.Button

    Friend WithEvents LblDisputeId As System.Windows.Forms.Label

    Friend WithEvents TxtMessage As System.Windows.Forms.TextBox

    Friend WithEvents LblMessage As System.Windows.Forms.Label

    Friend WithEvents TxtDisputeId As System.Windows.Forms.TextBox

    Friend WithEvents CboActivity As System.Windows.Forms.ComboBox

    Friend WithEvents LblActivity As System.Windows.Forms.Label

    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox

    Friend WithEvents LblStatus As System.Windows.Forms.Label

    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox

	Friend WithEvents  TxtShippingCarrier As System.Windows.Forms.TextBox

	Friend WithEvents TxtShipmentTrackNumber As System.Windows.Forms.TextBox

	Friend WithEvents LblShippingCarrier As System.Windows.Forms.Label 

	Friend WithEvents LblShipmentTrackNumber As System.Windows.Forms.Label 

	Friend WithEvents LblShippingTime As System.Windows.Forms.Label 

	Friend WithEvents ShippingTimePick As System.Windows.Forms.DateTimePicker



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnAddDisputeResponse = New System.Windows.Forms.Button()
        Me.LblDisputeId = New System.Windows.Forms.Label()
        Me.CboActivity = New System.Windows.Forms.ComboBox()
        Me.LblActivity = New System.Windows.Forms.Label()
        Me.TxtMessage = New System.Windows.Forms.TextBox()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.TxtDisputeId = New System.Windows.Forms.TextBox()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.TxtShippingCarrier = New System.Windows.Forms.TextBox()
        Me.TxtShipmentTrackNumber = New System.Windows.Forms.TextBox()
        Me.LblShippingCarrier = New System.Windows.Forms.Label()
        Me.LblShipmentTrackNumber = New System.Windows.Forms.Label()
        Me.LblShippingTime = New System.Windows.Forms.Label()
        Me.ShippingTimePick = New System.Windows.Forms.DateTimePicker()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnAddDisputeResponse
        '
        Me.BtnAddDisputeResponse.Location = New System.Drawing.Point(128, 224)
        Me.BtnAddDisputeResponse.Name = "BtnAddDisputeResponse"
        Me.BtnAddDisputeResponse.Size = New System.Drawing.Size(136, 23)
        Me.BtnAddDisputeResponse.TabIndex = 56
        Me.BtnAddDisputeResponse.Text = "AddDisputeResponse"
        '
        'LblDisputeId
        '
        Me.LblDisputeId.Location = New System.Drawing.Point(8, 8)
        Me.LblDisputeId.Name = "LblDisputeId"
        Me.LblDisputeId.Size = New System.Drawing.Size(80, 16)
        Me.LblDisputeId.TabIndex = 27
        Me.LblDisputeId.Text = "Dispute Id:"
        '
        'CboActivity
        '
        Me.CboActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboActivity.Location = New System.Drawing.Point(152, 96)
        Me.CboActivity.Name = "CboActivity"
        Me.CboActivity.Size = New System.Drawing.Size(152, 21)
        Me.CboActivity.TabIndex = 55
        '
        'LblActivity
        '
        Me.LblActivity.Location = New System.Drawing.Point(8, 96)
        Me.LblActivity.Name = "LblActivity"
        Me.LblActivity.Size = New System.Drawing.Size(80, 16)
        Me.LblActivity.TabIndex = 54
        Me.LblActivity.Text = "Activity:"
        '
        'TxtMessage
        '
        Me.TxtMessage.Location = New System.Drawing.Point(152, 32)
        Me.TxtMessage.Multiline = True
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.Size = New System.Drawing.Size(200, 56)
        Me.TxtMessage.TabIndex = 57
        Me.TxtMessage.Text = ""
        '
        'LblMessage
        '
        Me.LblMessage.Location = New System.Drawing.Point(8, 32)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(80, 23)
        Me.LblMessage.TabIndex = 58
        Me.LblMessage.Text = "Message:"
        '
        'TxtDisputeId
        '
        Me.TxtDisputeId.Location = New System.Drawing.Point(152, 8)
        Me.TxtDisputeId.Name = "TxtDisputeId"
        Me.TxtDisputeId.Size = New System.Drawing.Size(80, 20)
        Me.TxtDisputeId.TabIndex = 26
        Me.TxtDisputeId.Text = ""
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblStatus, Me.TxtStatus})
        Me.GrpResult.Location = New System.Drawing.Point(8, 264)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(352, 64)
        Me.GrpResult.TabIndex = 59
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblStatus
        '
        Me.LblStatus.Location = New System.Drawing.Point(16, 24)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(80, 23)
        Me.LblStatus.TabIndex = 42
        Me.LblStatus.Text = "Status:"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(96, 24)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(72, 20)
        Me.TxtStatus.TabIndex = 41
        Me.TxtStatus.Text = ""
        '
        'TxtShippingCarrier
        '
        Me.TxtShippingCarrier.Enabled = False
        Me.TxtShippingCarrier.Location = New System.Drawing.Point(152, 128)
        Me.TxtShippingCarrier.Name = "TxtShippingCarrier"
        Me.TxtShippingCarrier.Size = New System.Drawing.Size(152, 20)
        Me.TxtShippingCarrier.TabIndex = 60
        Me.TxtShippingCarrier.Text = ""
        '
        'TxtShipmentTrackNumber
        '
        Me.TxtShipmentTrackNumber.Enabled = False
        Me.TxtShipmentTrackNumber.Location = New System.Drawing.Point(152, 160)
        Me.TxtShipmentTrackNumber.Name = "TxtShipmentTrackNumber"
        Me.TxtShipmentTrackNumber.Size = New System.Drawing.Size(152, 20)
        Me.TxtShipmentTrackNumber.TabIndex = 61
        Me.TxtShipmentTrackNumber.Text = ""
        '
        'LblShippingCarrier
        '
        Me.LblShippingCarrier.Location = New System.Drawing.Point(8, 128)
        Me.LblShippingCarrier.Name = "LblShippingCarrier"
        Me.LblShippingCarrier.Size = New System.Drawing.Size(120, 16)
        Me.LblShippingCarrier.TabIndex = 63
        Me.LblShippingCarrier.Text = "Shipping Carrier Used:"
        '
        'LblShipmentTrackNumber
        '
        Me.LblShipmentTrackNumber.Location = New System.Drawing.Point(8, 160)
        Me.LblShipmentTrackNumber.Name = "LblShipmentTrackNumber"
        Me.LblShipmentTrackNumber.Size = New System.Drawing.Size(136, 16)
        Me.LblShipmentTrackNumber.TabIndex = 64
        Me.LblShipmentTrackNumber.Text = "Shipment Track Number:"
        '
        'LblShippingTime
        '
        Me.LblShippingTime.Location = New System.Drawing.Point(8, 192)
        Me.LblShippingTime.Name = "LblShippingTime"
        Me.LblShippingTime.Size = New System.Drawing.Size(100, 16)
        Me.LblShippingTime.TabIndex = 65
        Me.LblShippingTime.Text = "Shipping Time:"
        '
        'ShippingTimePick
        '
        Me.ShippingTimePick.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.ShippingTimePick.Enabled = False
        Me.ShippingTimePick.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ShippingTimePick.Location = New System.Drawing.Point(152, 192)
        Me.ShippingTimePick.Name = "ShippingTimePick"
        Me.ShippingTimePick.Size = New System.Drawing.Size(152, 20)
        Me.ShippingTimePick.TabIndex = 66
        '
        'FormAddDisputeResponse
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 353)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ShippingTimePick, Me.LblShippingTime, Me.LblShipmentTrackNumber, Me.LblShippingCarrier, Me.TxtShipmentTrackNumber, Me.TxtShippingCarrier, Me.GrpResult, Me.TxtMessage, Me.TxtDisputeId, Me.LblMessage, Me.CboActivity, Me.LblActivity, Me.LblDisputeId, Me.BtnAddDisputeResponse})
        Me.Name = "FormAddDisputeResponse"
        Me.Text = "AddDisputeResponse"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub FrmAddDisputeResponse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim activity As Type = GetType(DisputeActivityCodeType)
        Dim act As String

        For Each act In [Enum].GetNames(activity)


            If act <> "CustomCode" Then

                CboActivity.Items.Add(act)

            End If

        Next act

        CboActivity.SelectedIndex = 0

    End Sub



    Private Sub BtnAddDisputeResponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDisputeResponse.Click

        Try

            TxtStatus.Text = ""

            Dim apicall As AddDisputeResponseCall = New AddDisputeResponseCall(Context)

            If TxtShippingCarrier.Enabled = True Then
                apicall.ShippingCarrierUsed = TxtShippingCarrier.Text
                apicall.ShipmentTrackNumber = TxtShipmentTrackNumber.Text
                apicall.ShippingTime = ShippingTimePick.Value
            End If

            apicall.AddDisputeResponse(TxtDisputeId.Text, TxtMessage.Text, [Enum].Parse(GetType(DisputeActivityCodeType), CboActivity.SelectedItem.ToString()))
            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub CboActivity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboActivity.SelectedIndexChanged

        Dim selectedText As String = CboActivity.Text
        Dim enabledFlag As Boolean = selectedText.Equals("SellerShippedItem")

        TxtShippingCarrier.Enabled = enabledFlag
        TxtShipmentTrackNumber.Enabled = enabledFlag
        ShippingTimePick.Enabled = enabledFlag

    End Sub
End Class
