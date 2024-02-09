Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormLeaveFeedback
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




		Friend WithEvents TxtUserId As System.Windows.Forms.TextBox 

		Friend WithEvents LblUserId As System.Windows.Forms.Label 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents TxtItemId As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemId As System.Windows.Forms.Label 

		Friend WithEvents BtnLeaveFeedback As System.Windows.Forms.Button 

		Friend WithEvents TxtTransactionId As System.Windows.Forms.TextBox 

		Friend WithEvents LblTransactionId As System.Windows.Forms.Label 

		Friend WithEvents TxtComments As System.Windows.Forms.TextBox 

		Friend WithEvents LblComments As System.Windows.Forms.Label 

		Friend WithEvents LblDuration As System.Windows.Forms.Label 

		Friend WithEvents CboType As System.Windows.Forms.ComboBox 

		Friend WithEvents TxtStatus As System.Windows.Forms.TextBox 

		Friend WithEvents LblStatus As System.Windows.Forms.Label 




		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.TxtUserId = new System.Windows.Forms.TextBox()

			Me.BtnLeaveFeedback = new System.Windows.Forms.Button()

			Me.LblUserId = new System.Windows.Forms.Label()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblStatus = new System.Windows.Forms.Label()

			Me.TxtStatus = new System.Windows.Forms.TextBox()

			Me.TxtItemId = new System.Windows.Forms.TextBox()

			Me.LblItemId = new System.Windows.Forms.Label()

			Me.TxtTransactionId = new System.Windows.Forms.TextBox()

			Me.LblTransactionId = new System.Windows.Forms.Label()

			Me.TxtComments = new System.Windows.Forms.TextBox()

			Me.LblComments = new System.Windows.Forms.Label()

			Me.CboType = new System.Windows.Forms.ComboBox()

			Me.LblDuration = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' TxtUserId

			' 

			Me.TxtUserId.Location = new System.Drawing.Point(88, 32)

			Me.TxtUserId.Name = "TxtUserId"

			Me.TxtUserId.Size = new System.Drawing.Size(80, 20)

			Me.TxtUserId.TabIndex = 22

			Me.TxtUserId.Text = ""

			' 

			' BtnLeaveFeedback

			' 

			Me.BtnLeaveFeedback.Location = new System.Drawing.Point(112, 88)

			Me.BtnLeaveFeedback.Name = "BtnLeaveFeedback"

			Me.BtnLeaveFeedback.Size = new System.Drawing.Size(120, 23)

			Me.BtnLeaveFeedback.TabIndex = 23

			Me.BtnLeaveFeedback.Text = "LeaveFeedback"

        'Me.BtnLeaveFeedback.Click += new System.EventHandler(Me.BtnLeaveFeedback_Click)

			' 

			' LblUserId

			' 

			Me.LblUserId.Location = new System.Drawing.Point(8, 32)

			Me.LblUserId.Name = "LblUserId"

			Me.LblUserId.Size = new System.Drawing.Size(80, 23)

			Me.LblUserId.TabIndex = 24

			Me.LblUserId.Text = "Target User Id:"

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblStatus)

			Me.GrpResult.Controls.Add(Me.TxtStatus)

			Me.GrpResult.Location = new System.Drawing.Point(8, 120)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(352, 64)

			Me.GrpResult.TabIndex = 25

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LblStatus

			' 

			Me.LblStatus.Location = new System.Drawing.Point(16, 24)

			Me.LblStatus.Name = "LblStatus"

			Me.LblStatus.Size = new System.Drawing.Size(80, 23)

			Me.LblStatus.TabIndex = 42

			Me.LblStatus.Text = "Status:"

			' 

			' TxtStatus

			' 

			Me.TxtStatus.Location = new System.Drawing.Point(96, 24)

			Me.TxtStatus.Name = "TxtStatus"

			Me.TxtStatus.ReadOnly = true

			Me.TxtStatus.Size = new System.Drawing.Size(72, 20)

			Me.TxtStatus.TabIndex = 41

			Me.TxtStatus.Text = ""

			' 

			' TxtItemId

			' 

			Me.TxtItemId.Location = new System.Drawing.Point(88, 8)

			Me.TxtItemId.Name = "TxtItemId"

			Me.TxtItemId.Size = new System.Drawing.Size(80, 20)

			Me.TxtItemId.TabIndex = 26

			Me.TxtItemId.Text = ""

			' 

			' LblItemId

			' 

			Me.LblItemId.Location = new System.Drawing.Point(8, 8)

			Me.LblItemId.Name = "LblItemId"

			Me.LblItemId.Size = new System.Drawing.Size(80, 23)

			Me.LblItemId.TabIndex = 27

			Me.LblItemId.Text = "Item Id:"

			' 

			' TxtTransactionId

			' 

			Me.TxtTransactionId.Location = new System.Drawing.Point(280, 8)

			Me.TxtTransactionId.Name = "TxtTransactionId"

			Me.TxtTransactionId.Size = new System.Drawing.Size(80, 20)

			Me.TxtTransactionId.TabIndex = 28

			Me.TxtTransactionId.Text = ""

			' 

			' LblTransactionId

			' 

			Me.LblTransactionId.Location = new System.Drawing.Point(200, 8)

			Me.LblTransactionId.Name = "LblTransactionId"

			Me.LblTransactionId.Size = new System.Drawing.Size(80, 23)

			Me.LblTransactionId.TabIndex = 29

			Me.LblTransactionId.Text = "Transaction Id:"

			' 

			' TxtComments

			' 

			Me.TxtComments.Location = new System.Drawing.Point(88, 56)

			Me.TxtComments.Name = "TxtComments"

			Me.TxtComments.Size = new System.Drawing.Size(272, 20)

			Me.TxtComments.TabIndex = 30

			Me.TxtComments.Text = ""

			' 

			' LblComments

			' 

			Me.LblComments.Location = new System.Drawing.Point(8, 56)

			Me.LblComments.Name = "LblComments"

			Me.LblComments.Size = new System.Drawing.Size(88, 23)

			Me.LblComments.TabIndex = 31

			Me.LblComments.Text = "Comments:"

			' 

			' CboType

			' 

			Me.CboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboType.Location = new System.Drawing.Point(280, 32)

			Me.CboType.Name = "CboType"

			Me.CboType.Size = new System.Drawing.Size(80, 21)

			Me.CboType.TabIndex = 55

			' 

			' LblDuration

			' 

			Me.LblDuration.Location = new System.Drawing.Point(200, 32)

			Me.LblDuration.Name = "LblDuration"

			Me.LblDuration.Size = new System.Drawing.Size(80, 18)

			Me.LblDuration.TabIndex = 54

			Me.LblDuration.Text = "Type:"

			' 

			' FrmLeaveFeedback

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(368, 189)

			Me.Controls.Add(Me.CboType)

			Me.Controls.Add(Me.LblDuration)

			Me.Controls.Add(Me.TxtComments)

			Me.Controls.Add(Me.TxtTransactionId)

			Me.Controls.Add(Me.TxtItemId)

			Me.Controls.Add(Me.TxtUserId)

			Me.Controls.Add(Me.LblComments)

			Me.Controls.Add(Me.LblTransactionId)

			Me.Controls.Add(Me.LblItemId)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnLeaveFeedback)

			Me.Controls.Add(Me.LblUserId)

			Me.Name = "FrmLeaveFeedback"

			Me.Text = "LeaveFeedback"

			'Me.Load += new System.EventHandler(Me.FrmLeaveFeedback_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


		Public Context As ApiContext

		Private Sub  FrmLeaveFeedback_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		

			Dim s As Type = GetType(CommentTypeCodeType)
			Dim item As String

			For Each item in [Enum].GetNames(s)

			

            If item <> "CustomCode" And item <> "Withdrawn" Then

                CboType.Items.Add(item)

            End If
        Next item


			CboType.SelectedIndex = 0

		End Sub

		

		

		Private Sub  BtnLeaveFeedback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLeaveFeedback.Click
		

			Try 
	
				TxtStatus.Text = ""

				Dim apicall As LeaveFeedbackCall= new LeaveFeedbackCall(Context)
				Dim type As CommentTypeCodeType = [Enum].Parse(GetType(CommentTypeCodeType), CboType.SelectedItem.ToString())
            apicall.LeaveFeedback(TxtUserId.Text, TxtItemId.Text, TxtTransactionId.Text, type, TxtComments.Text)

            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try 

    End Sub

End Class

