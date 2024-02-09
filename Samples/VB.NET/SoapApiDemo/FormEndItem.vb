Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormEndItem
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

		Friend WithEvents  GrpResult As System.Windows.Forms.GroupBox

		Friend WithEvents  TxtItemId As System.Windows.Forms.TextBox 

		Friend WithEvents  LblItemId As System.Windows.Forms.Label 

		Friend WithEvents  TxtStatus As System.Windows.Forms.TextBox 

		Friend WithEvents  LblStatus As System.Windows.Forms.Label

		Friend WithEvents  BtnEndItem As System.Windows.Forms.Button

		Friend WithEvents  CboReason As System.Windows.Forms.ComboBox

		Friend WithEvents  LblReason As System.Windows.Forms.Label

		<System.Diagnostics.DebuggerStepThrough()> Private Sub  InitializeComponent()

			Me.BtnEndItem = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblStatus = new System.Windows.Forms.Label()

			Me.TxtStatus = new System.Windows.Forms.TextBox()

			Me.TxtItemId = new System.Windows.Forms.TextBox()

			Me.LblItemId = new System.Windows.Forms.Label()

			Me.CboReason = new System.Windows.Forms.ComboBox()

			Me.LblReason = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnEndItem

			' 

			Me.BtnEndItem.Location = new System.Drawing.Point(128, 64)

			Me.BtnEndItem.Name = "BtnEndItem"

			Me.BtnEndItem.Size = new System.Drawing.Size(120, 23)

			Me.BtnEndItem.TabIndex = 23

			Me.BtnEndItem.Text = "EndItem"

        'TODO Me.BtnEndItem.Click += new System.EventHandler(Me.BtnEndItem_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblStatus)

			Me.GrpResult.Controls.Add(Me.TxtStatus)

			Me.GrpResult.Location = new System.Drawing.Point(8, 96)

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

			Me.TxtItemId.Location = new System.Drawing.Point(152, 8)

			Me.TxtItemId.Name = "TxtItemId"

			Me.TxtItemId.Size = new System.Drawing.Size(80, 20)

			Me.TxtItemId.TabIndex = 26

			Me.TxtItemId.Text = ""

			' 

			' LblItemId

			' 

			Me.LblItemId.Location = new System.Drawing.Point(72, 8)

			Me.LblItemId.Name = "LblItemId"

			Me.LblItemId.Size = new System.Drawing.Size(80, 23)

			Me.LblItemId.TabIndex = 27

			Me.LblItemId.Text = "Item Id:"

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

			' FrmEndItem

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(368, 165)

			Me.Controls.Add(Me.CboReason)

			Me.Controls.Add(Me.LblReason)

			Me.Controls.Add(Me.TxtItemId)

			Me.Controls.Add(Me.LblItemId)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnEndItem)

			Me.Name = "FrmEndItem"

			Me.Text = "EndItem"

			'TODO Me.Load += new System.EventHandler(Me.FrmEndItem_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)



 End Sub

#End Region


		Public Context As ApiContext

		Private Sub FrmEndItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim reasons As Type = GetType(EndReasonCodeType)

			Dim rsn As String

			For Each rsn in [Enum].GetNames(reasons)

				If  rsn <> "CustomCode" Then
					CboReason.Items.Add(rsn)
				End If
			Next rsn

			CboReason.SelectedIndex = 0

		End Sub

		

		Private Sub BtnEndItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEndItem.Click

			Try
	
				TxtStatus.Text = ""
            Dim apicall As EndItemCall = New EndItemCall(Context)
            apicall.EndItem(TxtItemId.Text, [Enum].Parse(GetType(EndReasonCodeType), CboReason.SelectedItem.ToString()))

            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()

        Catch ex As Exception
            'Me.txtErrors.Text = ex.Message
            MsgBox(ex.Message)

        End Try

	End Sub

End Class

