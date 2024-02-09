Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormSellerReverseDispute
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




		Friend WithEvents BtnSellerReverseDispute As System.Windows.Forms.Button 

		Friend WithEvents LblDisputeId As System.Windows.Forms.Label 

		Friend WithEvents TxtDisputeId As System.Windows.Forms.TextBox 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents LblStatus As System.Windows.Forms.Label 

		Friend WithEvents TxtStatus As System.Windows.Forms.TextBox 

		Friend WithEvents CboReason As System.Windows.Forms.ComboBox 

		Friend WithEvents LblReason As System.Windows.Forms.Label 

		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.BtnSellerReverseDispute = new System.Windows.Forms.Button()

			Me.LblDisputeId = new System.Windows.Forms.Label()

			Me.CboReason = new System.Windows.Forms.ComboBox()

			Me.LblReason = new System.Windows.Forms.Label()

			Me.TxtDisputeId = new System.Windows.Forms.TextBox()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblStatus = new System.Windows.Forms.Label()

			Me.TxtStatus = new System.Windows.Forms.TextBox()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnSellerReverseDispute

			' 

			Me.BtnSellerReverseDispute.Location = new System.Drawing.Point(128, 64)

			Me.BtnSellerReverseDispute.Name = "BtnSellerReverseDispute"

			Me.BtnSellerReverseDispute.Size = new System.Drawing.Size(136, 23)

			Me.BtnSellerReverseDispute.TabIndex = 56

			Me.BtnSellerReverseDispute.Text = "SellerReverseDispute"

        'Me.BtnSellerReverseDispute.Click += new System.EventHandler(Me.BtnSellerReverseDispute_Click)

			' 

			' LblDisputeId

			' 

			Me.LblDisputeId.Location = new System.Drawing.Point(72, 8)

			Me.LblDisputeId.Name = "LblDisputeId"

			Me.LblDisputeId.Size = new System.Drawing.Size(80, 23)

			Me.LblDisputeId.TabIndex = 27

			Me.LblDisputeId.Text = "Dispute Id:"

			' 

			' CboReason

			' 

			Me.CboReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboReason.Location = new System.Drawing.Point(152, 32)

			Me.CboReason.Name = "CboReason"

			Me.CboReason.Size = new System.Drawing.Size(144, 21)

			Me.CboReason.TabIndex = 55

			' 

			' LblReason

			' 

			Me.LblReason.Location = new System.Drawing.Point(72, 32)

			Me.LblReason.Name = "LblReason"

			Me.LblReason.Size = new System.Drawing.Size(80, 18)

			Me.LblReason.TabIndex = 54

			Me.LblReason.Text = "Reason:"

			' 

			' TxtDisputeId

			' 

			Me.TxtDisputeId.Location = new System.Drawing.Point(152, 8)

			Me.TxtDisputeId.Name = "TxtDisputeId"

			Me.TxtDisputeId.Size = new System.Drawing.Size(80, 20)

			Me.TxtDisputeId.TabIndex = 26

			Me.TxtDisputeId.Text = ""

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblStatus)

			Me.GrpResult.Controls.Add(Me.TxtStatus)

			Me.GrpResult.Location = new System.Drawing.Point(8, 96)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(352, 64)

			Me.GrpResult.TabIndex = 59

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

			' FrmSellerReverseDispute

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(368, 165)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.TxtDisputeId)

			Me.Controls.Add(Me.CboReason)

			Me.Controls.Add(Me.LblReason)

			Me.Controls.Add(Me.LblDisputeId)

			Me.Controls.Add(Me.BtnSellerReverseDispute)

			Me.Name = "FrmSellerReverseDispute"

			Me.Text = "SellerReverseDispute"

        'Me.Load += new System.EventHandler(Me.FrmSellerReverseDispute_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  FrmSellerReverseDispute_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			Dim reason() As String = [Enum].GetNames(GetType(DisputeResolutionReasonCodeType))
			Dim act As String

			For Each act in reason

				If  act <> "CustomCode" Then

					CboReason.Items.Add(act)

				End If

			Next act

			CboReason.SelectedIndex = 0

		End Sub


		Private Sub  BtnSellerReverseDispute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSellerReverseDispute.Click

		

			Try

			

				TxtStatus.Text = ""



				Dim apicall As SellerReverseDisputeCall = new SellerReverseDisputeCall(Context)


            apicall.SellerReverseDispute(TxtDisputeId.Text, [Enum].Parse(GetType(DisputeResolutionReasonCodeType), CboReason.SelectedItem.ToString()))


            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()

			

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class