Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormSetNotificationPreferences
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


    Friend WithEvents BtnSetNotificationPreferences As System.Windows.Forms.Button

    Friend WithEvents CboStatus As System.Windows.Forms.ComboBox

    Friend WithEvents LblStatus As System.Windows.Forms.Label

    Friend WithEvents TxtUrl As System.Windows.Forms.TextBox

    Friend WithEvents LblUrl As System.Windows.Forms.Label

    Friend LblEvents() As System.Windows.Forms.Label

    Friend CboEventStatus() As System.Windows.Forms.ComboBox

    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox

    Friend WithEvents label1 As System.Windows.Forms.Label

    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox

    Friend WithEvents PnlUserPrefs As System.Windows.Forms.Panel
    Private excludeEventTpye() As String = {"MyMessagesM2MMessage", "MyMessagesAlertHeader", "MyMessagesAlert", "MyMessageseBayMessageHeader", "MyMessagesM2MMessage", "MyMessagesM2MMessageHeader", "UserIDChanged", "EmailAddressChanged", "PasswordChanged", "PasswordHintChanged", "PaymentDetailChanged", "AccountSuspended", "AccountSummary"}


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnSetNotificationPreferences = New System.Windows.Forms.Button()
        Me.CboStatus = New System.Windows.Forms.ComboBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TxtUrl = New System.Windows.Forms.TextBox()
        Me.LblUrl = New System.Windows.Forms.Label()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.PnlUserPrefs = New System.Windows.Forms.Panel()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSetNotificationPreferences
        '
        Me.BtnSetNotificationPreferences.Location = New System.Drawing.Point(168, 344)
        Me.BtnSetNotificationPreferences.Name = "BtnSetNotificationPreferences"
        Me.BtnSetNotificationPreferences.Size = New System.Drawing.Size(184, 26)
        Me.BtnSetNotificationPreferences.TabIndex = 46
        Me.BtnSetNotificationPreferences.Text = "SetNotificationPreferences"
        '
        'CboStatus
        '
        Me.CboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboStatus.Location = New System.Drawing.Point(232, 32)
        Me.CboStatus.Name = "CboStatus"
        Me.CboStatus.Size = New System.Drawing.Size(144, 21)
        Me.CboStatus.TabIndex = 59
        '
        'LblStatus
        '
        Me.LblStatus.Location = New System.Drawing.Point(16, 32)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(216, 18)
        Me.LblStatus.TabIndex = 58
        Me.LblStatus.Text = "Application Status:"
        '
        'TxtUrl
        '
        Me.TxtUrl.Location = New System.Drawing.Point(232, 8)
        Me.TxtUrl.Name = "TxtUrl"
        Me.TxtUrl.Size = New System.Drawing.Size(256, 20)
        Me.TxtUrl.TabIndex = 56
        Me.TxtUrl.Text = ""
        '
        'LblUrl
        '
        Me.LblUrl.Location = New System.Drawing.Point(16, 8)
        Me.LblUrl.Name = "LblUrl"
        Me.LblUrl.Size = New System.Drawing.Size(216, 16)
        Me.LblUrl.TabIndex = 57
        Me.LblUrl.Text = "Delivery URL:"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.label1, Me.TxtStatus})
        Me.GrpResult.Location = New System.Drawing.Point(8, 376)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(488, 64)
        Me.GrpResult.TabIndex = 60
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(80, 23)
        Me.label1.TabIndex = 42
        Me.label1.Text = "Status:"
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
        'PnlUserPrefs
        '
        Me.PnlUserPrefs.AutoScroll = True
        Me.PnlUserPrefs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlUserPrefs.Location = New System.Drawing.Point(8, 64)
        Me.PnlUserPrefs.Name = "PnlUserPrefs"
        Me.PnlUserPrefs.Size = New System.Drawing.Size(488, 272)
        Me.PnlUserPrefs.TabIndex = 61
        '
        'FormSetNotificationPreferences
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 453)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PnlUserPrefs, Me.GrpResult, Me.CboStatus, Me.LblStatus, Me.TxtUrl, Me.LblUrl, Me.BtnSetNotificationPreferences})
        Me.Name = "FormSetNotificationPreferences"
        Me.Text = "SetNotificationPreferences"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext


    Private Sub FrmSetNotificationPreferences_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim items() As String = [Enum].GetNames(GetType(EnableCodeType))
        Dim stats(items.Length - 1) As String
        Dim stat As String
        Dim count As Int16 = 0


        For Each stat In items
            If stat <> "CustomCode" Then
                stats(count) = stat
                CboStatus.Items.Add(stat)
                count = count + 1
            End If
        Next stat
        CboStatus.SelectedIndex = 0

        Dim events() As String = [Enum].GetNames(GetType(NotificationEventTypeCodeType))
        'Dim events() As String = {NotificationEventTypeCodeType.OutBid.ToString(),NotificationEventTypeCodeType.EndOfAuction.ToString(),NotificationEventTypeCodeType.AuctionCheckoutComplete.ToString(),NotificationEventTypeCodeType.FixedPriceEndOfTransaction.ToString(),NotificationEventTypeCodeType.CheckoutBuyerRequestsTotal.ToString(),NotificationEventTypeCodeType.Feedback.ToString(),NotificationEventTypeCodeType.FeedbackForSeller.ToString(),NotificationEventTypeCodeType.FixedPriceEndOfTransaction.ToString(),NotificationEventTypeCodeType.SecondChanceOffer.ToString(),NotificationEventTypeCodeType.AskSellerQuestion.ToString()}

        Dim ev As String

        ReDim LblEvents(events.Length - 3)
        ReDim CboEventStatus(events.Length - 3)

        Dim y As Int16 = 8
        Dim x As Int16 = 0

        For Each ev In events

            If ev <> "CustomCode" And ev <> "None" Then

                Dim lbl As System.Windows.Forms.Label = New System.Windows.Forms.Label()

                Dim cbo As System.Windows.Forms.ComboBox = New System.Windows.Forms.ComboBox()

                lbl.Location = New System.Drawing.Point(8, y)

                lbl.Size = New System.Drawing.Size(160, 16)

                lbl.Text = ev.ToString()

                cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

                cbo.Location = New System.Drawing.Point(232, y)

                cbo.Size = New System.Drawing.Size(144, 21)

                Dim index As Int16 = 0
                Do While (index < count)
                    cbo.Items.Add(stats(index))
                    index = index + 1
                Loop
                cbo.SelectedIndex = 0

                LblEvents(x) = lbl
                CboEventStatus(x) = cbo

                PnlUserPrefs.Controls.Add(lbl)
                PnlUserPrefs.Controls.Add(cbo)
                y = y + 24
                x = x + 1
            End If
        Next ev

    End Sub


    Private Sub BtnSetNotificationPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetNotificationPreferences.Click
        Try
            TxtStatus.Text = ""

            Dim apicall As SetNotificationPreferencesCall = New SetNotificationPreferencesCall(Context)

            apicall.ApplicationDeliveryPreferences = New ApplicationDeliveryPreferencesType()

            apicall.ApplicationDeliveryPreferences.ApplicationEnable = [Enum].Parse(GetType(EnableCodeType), CboStatus.SelectedItem.ToString())

            If TxtUrl.Text.Length > 0 Then
                apicall.ApplicationDeliveryPreferences.ApplicationURL = TxtUrl.Text
            End If
            Dim notifications As NotificationEnableTypeCollection = New NotificationEnableTypeCollection()

            Dim inx As Int16
            For inx = 0 To LblEvents.Length - 1
                Dim net As NotificationEnableType = New NotificationEnableType()

                If isIncluded(LblEvents(inx).Text) Then
                    net.EventType = [Enum].Parse(GetType(NotificationEventTypeCodeType), LblEvents(inx).Text)
                    net.EventEnable = [Enum].Parse(GetType(EnableCodeType), CboEventStatus(inx).SelectedItem.ToString())

                    notifications.Add(net)
                End If
            Next inx

            apicall.SetNotificationPreferences(notifications)

            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Function isIncluded(ByVal str As String) As Boolean
        Dim i As Integer
        For i = 0 To excludeEventTpye.Length - 1
            If excludeEventTpye(i) = str Then
                Return False
            End If
        Next

        Return True
    End Function

End Class

