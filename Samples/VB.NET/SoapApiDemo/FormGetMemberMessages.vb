Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetMemberMessages
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

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents DatePickStartFrom As System.Windows.Forms.DateTimePicker 

		Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents BtnGetMemberMessages As System.Windows.Forms.Button 

		Friend WithEvents TxtItemId As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemId As System.Windows.Forms.Label 

		Friend WithEvents CboStatus As System.Windows.Forms.ComboBox 

		Friend WithEvents LblStatus As System.Windows.Forms.Label 

		Friend WithEvents CboType As System.Windows.Forms.ComboBox 

		Friend WithEvents LblType As System.Windows.Forms.Label 

		Friend WithEvents ChkPublic As System.Windows.Forms.CheckBox 

		Friend WithEvents LblTimeRange As System.Windows.Forms.Label 

		Friend WithEvents ChkStartFrom As System.Windows.Forms.CheckBox 

		Friend WithEvents ChkStartTo As System.Windows.Forms.CheckBox 

		Friend WithEvents LblMessages As System.Windows.Forms.Label 

		Friend WithEvents LstMessages As System.Windows.Forms.ListView 

		Friend WithEvents ClmStatus As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmType As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmSender As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmMessageId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmBody As System.Windows.Forms.ColumnHeader

		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblMessages = new System.Windows.Forms.Label()

			Me.LstMessages = new System.Windows.Forms.ListView()

			Me.ClmItemId = new System.Windows.Forms.ColumnHeader()

			Me.ClmStatus = new System.Windows.Forms.ColumnHeader()

			Me.ClmType = new System.Windows.Forms.ColumnHeader()

			Me.ClmSender = new System.Windows.Forms.ColumnHeader()

			Me.BtnGetMemberMessages = new System.Windows.Forms.Button()

			Me.DatePickStartTo = new System.Windows.Forms.DateTimePicker()

			Me.DatePickStartFrom = new System.Windows.Forms.DateTimePicker()

			Me.LblStartSep = new System.Windows.Forms.Label()

			Me.TxtItemId = new System.Windows.Forms.TextBox()

			Me.LblItemId = new System.Windows.Forms.Label()

			Me.CboStatus = new System.Windows.Forms.ComboBox()

			Me.LblStatus = new System.Windows.Forms.Label()

			Me.CboType = new System.Windows.Forms.ComboBox()

			Me.LblType = new System.Windows.Forms.Label()

			Me.ChkPublic = new System.Windows.Forms.CheckBox()

			Me.LblTimeRange = new System.Windows.Forms.Label()

			Me.ChkStartFrom = new System.Windows.Forms.CheckBox()

			Me.ChkStartTo = new System.Windows.Forms.CheckBox()

			Me.ClmMessageId = new System.Windows.Forms.ColumnHeader()

			Me.ClmBody = new System.Windows.Forms.ColumnHeader()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblMessages)

			Me.GrpResult.Controls.Add(Me.LstMessages)

			Me.GrpResult.Location = new System.Drawing.Point(8, 168)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(456, 328)

			Me.GrpResult.TabIndex = 24

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Results"

			' 

			' LblMessages

			' 

			Me.LblMessages.Location = new System.Drawing.Point(16, 24)

			Me.LblMessages.Name = "LblMessages"

			Me.LblMessages.Size = new System.Drawing.Size(112, 23)

			Me.LblMessages.TabIndex = 15

			Me.LblMessages.Text = "Messages:"

			' 

			' LstMessages

			' 

        Me.LstMessages.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right)

        Me.LstMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmItemId, Me.ClmMessageId, Me.ClmStatus, Me.ClmType, Me.ClmSender, Me.ClmBody})

			Me.LstMessages.GridLines = true

			Me.LstMessages.Location = new System.Drawing.Point(8, 48)

			Me.LstMessages.Name = "LstMessages"

			Me.LstMessages.Size = new System.Drawing.Size(440, 264)

			Me.LstMessages.TabIndex = 4

			Me.LstMessages.View = System.Windows.Forms.View.Details

			' 

			' ClmItemId

			' 

			Me.ClmItemId.Text = "ItemId"

			Me.ClmItemId.Width = 56

			' 

			' ClmStatus

			' 

			Me.ClmStatus.Text = "Status"

			Me.ClmStatus.Width = 50

			' 

			' ClmType

			' 

			Me.ClmType.Text = "Question Type"

			Me.ClmType.Width = 87

			' 

			' ClmSender

			' 

			Me.ClmSender.Text = "Sender"

			Me.ClmSender.Width = 51

			' 

			' BtnGetMemberMessages

			' 

			Me.BtnGetMemberMessages.Location = new System.Drawing.Point(136, 144)

			Me.BtnGetMemberMessages.Name = "BtnGetMemberMessages"

			Me.BtnGetMemberMessages.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetMemberMessages.TabIndex = 23

			Me.BtnGetMemberMessages.Text = "GetMemberMessages"

        'Me.BtnGetMemberMessages.Click += new System.EventHandler(Me.BtnGetMemberMessages_Click)

			' 

			' DatePickStartTo

			' 

			Me.DatePickStartTo.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickStartTo.Location = new System.Drawing.Point(288, 104)

			Me.DatePickStartTo.Name = "DatePickStartTo"

			Me.DatePickStartTo.Size = new System.Drawing.Size(136, 20)

			Me.DatePickStartTo.TabIndex = 65

			' 

			' DatePickStartFrom

			' 

			Me.DatePickStartFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss"

			Me.DatePickStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom

			Me.DatePickStartFrom.Location = new System.Drawing.Point(104, 104)

			Me.DatePickStartFrom.Name = "DatePickStartFrom"

			Me.DatePickStartFrom.Size = new System.Drawing.Size(136, 20)

			Me.DatePickStartFrom.TabIndex = 64

			' 

			' LblStartSep

			' 

			Me.LblStartSep.Location = new System.Drawing.Point(248, 104)

			Me.LblStartSep.Name = "LblStartSep"

			Me.LblStartSep.Size = new System.Drawing.Size(16, 23)

			Me.LblStartSep.TabIndex = 63

			Me.LblStartSep.Text = " - "

			' 

			' TxtItemId

			' 

			Me.TxtItemId.Location = new System.Drawing.Point(88, 8)

			Me.TxtItemId.Name = "TxtItemId"

			Me.TxtItemId.TabIndex = 70

			Me.TxtItemId.Text = ""

			' 

			' LblItemId

			' 

			Me.LblItemId.Location = new System.Drawing.Point(8, 8)

			Me.LblItemId.Name = "LblItemId"

			Me.LblItemId.Size = new System.Drawing.Size(80, 16)

			Me.LblItemId.TabIndex = 72

			Me.LblItemId.Text = "Item Id:"

			' 

			' CboStatus

			' 

			Me.CboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboStatus.Location = new System.Drawing.Point(88, 32)

			Me.CboStatus.Name = "CboStatus"

			Me.CboStatus.Size = new System.Drawing.Size(144, 21)

			Me.CboStatus.TabIndex = 74

			' 

			' LblStatus

			' 

			Me.LblStatus.Location = new System.Drawing.Point(8, 32)

			Me.LblStatus.Name = "LblStatus"

			Me.LblStatus.Size = new System.Drawing.Size(80, 18)

			Me.LblStatus.TabIndex = 73

			Me.LblStatus.Text = "Status:"

			' 

			' CboType

			' 

			Me.CboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboType.Location = new System.Drawing.Point(88, 56)

			Me.CboType.Name = "CboType"

			Me.CboType.Size = new System.Drawing.Size(144, 21)

			Me.CboType.TabIndex = 76

			' 

			' LblType

			' 

			Me.LblType.Location = new System.Drawing.Point(8, 56)

			Me.LblType.Name = "LblType"

			Me.LblType.Size = new System.Drawing.Size(80, 18)

			Me.LblType.TabIndex = 75

			Me.LblType.Text = "Type:"

			' 

			' ChkPublic

			' 

			Me.ChkPublic.Location = new System.Drawing.Point(88, 80)

			Me.ChkPublic.Name = "ChkPublic"

			Me.ChkPublic.Size = new System.Drawing.Size(160, 24)

			Me.ChkPublic.TabIndex = 77

			Me.ChkPublic.Text = "Retrieve Public Only"

			' 

			' LblTimeRange

			' 

			Me.LblTimeRange.Location = new System.Drawing.Point(16, 104)

			Me.LblTimeRange.Name = "LblTimeRange"

			Me.LblTimeRange.Size = new System.Drawing.Size(64, 16)

			Me.LblTimeRange.TabIndex = 78

			Me.LblTimeRange.Text = "Time Filter:"

			' 

			' ChkStartFrom

			' 

			Me.ChkStartFrom.Location = new System.Drawing.Point(88, 104)

			Me.ChkStartFrom.Name = "ChkStartFrom"

			Me.ChkStartFrom.Size = new System.Drawing.Size(12, 24)

			Me.ChkStartFrom.TabIndex = 79

			' 

			' ChkStartTo

			' 

			Me.ChkStartTo.Location = new System.Drawing.Point(272, 104)

			Me.ChkStartTo.Name = "ChkStartTo"

			Me.ChkStartTo.Size = new System.Drawing.Size(12, 24)

			Me.ChkStartTo.TabIndex = 80

			' 

			' ClmMessageId

			' 

			Me.ClmMessageId.Text = "Message Id"

			Me.ClmMessageId.Width = 69

			' 

			' ClmBody

			' 

			Me.ClmBody.Text = "Question"

			Me.ClmBody.Width = 112

			' 

			' FrmGetMemberMessages

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(472, 501)

			Me.Controls.Add(Me.ChkStartTo)

			Me.Controls.Add(Me.ChkStartFrom)

			Me.Controls.Add(Me.LblTimeRange)

			Me.Controls.Add(Me.ChkPublic)

			Me.Controls.Add(Me.CboType)

			Me.Controls.Add(Me.LblType)

			Me.Controls.Add(Me.CboStatus)

			Me.Controls.Add(Me.LblStatus)

			Me.Controls.Add(Me.LblItemId)

			Me.Controls.Add(Me.TxtItemId)

			Me.Controls.Add(Me.DatePickStartTo)

			Me.Controls.Add(Me.DatePickStartFrom)

			Me.Controls.Add(Me.LblStartSep)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetMemberMessages)

			Me.Name = "FrmGetMemberMessages"

			Me.Text = "GetMemberMessages"

			'Me.Load += new System.EventHandler(Me.FrmGetMemberMessages_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


		Public Context As ApiContext

		Private Sub  FrmGetMemberMessages_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		

        Dim now As DateTime = DateTime.Now

			DatePickStartTo.Value = now

			DatePickStartFrom.Value = now.AddDays(-5)

			

			

        Dim types As Type = GetType(MessageTypeCodeType)
        Dim typ As String

        For Each typ In [Enum].GetNames(types)
            If typ <> "CustomCode" Then

                CboType.Items.Add(typ)

            End If
        Next typ


        CboType.SelectedIndex = 0



        Dim statie As Type = GetType(MessageStatusTypeCodeType)
        Dim stat As String

        For Each stat In [Enum].GetNames(statie)


            If stat <> "CustomCode" Then



                CboStatus.Items.Add(stat)

            End If

        Next stat
        CboStatus.SelectedIndex = 0



		end Sub





		Private Sub  BtnGetMemberMessages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetMemberMessages.Click

		

        Try



            LstMessages.Items.Clear()

            Dim apicall As GetMemberMessagesCall = New GetMemberMessagesCall(Context)

            apicall.DisplayToPublic = ChkPublic.Checked

            Dim messages As MemberMessageExchangeTypeCollection

            If TxtItemId.Text <> String.Empty Then			
                messages = apicall.GetMemberMessages(TxtItemId.Text, [Enum].Parse(GetType(MessageTypeCodeType), CboType.SelectedItem.ToString()), [Enum].Parse(GetType(MessageStatusTypeCodeType), CboStatus.SelectedItem.ToString()))
            Else
                Dim fltr As TimeFilter = New TimeFilter()

                If ChkStartFrom.Checked Then
                    fltr.TimeFrom = DatePickStartFrom.Value
                End If

                If ChkStartTo.Checked Then
                    fltr.TimeTo = DatePickStartTo.Value
                End If

                messages = apicall.GetMemberMessages(fltr, [Enum].Parse(GetType(MessageTypeCodeType), CboType.SelectedItem.ToString()), [Enum].Parse(GetType(MessageStatusTypeCodeType), CboStatus.SelectedItem.ToString()))
            End If

            Dim msg As MemberMessageExchangeType
            For Each msg In messages

                Dim listparams(6) As String
                If Not msg.Item Is Nothing Then
                    listparams(0) = msg.Item.ItemID
                Else
                    listparams(0) = ""
                End If


                listparams(1) = msg.Question.MessageID

                listparams(2) = msg.MessageStatus.ToString()

                listparams(3) = msg.Question.QuestionType.ToString()

                listparams(4) = msg.Question.SenderID

                listparams(5) = msg.Question.Body



                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstMessages.Items.Add(vi)

            Next msg


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class
