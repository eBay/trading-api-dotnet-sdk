Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetNotificationPreferences
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



		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents BtnGetNotificationPreferences As System.Windows.Forms.Button 

		Friend WithEvents CboRole As System.Windows.Forms.ComboBox 

		Friend WithEvents LblRole As System.Windows.Forms.Label 

		Friend WithEvents LblDelivery As System.Windows.Forms.Label 

		Friend WithEvents LblStatus As System.Windows.Forms.Label 

		Friend WithEvents TxtDelivery As System.Windows.Forms.TextBox 

		Friend WithEvents TxtStatus As System.Windows.Forms.TextBox 

		Friend WithEvents LblUserPref As System.Windows.Forms.Label 

		Friend WithEvents LstPreferences As System.Windows.Forms.ListView 

		Friend WithEvents ClmPref As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmStatus As System.Windows.Forms.ColumnHeader 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.BtnGetNotificationPreferences = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblDelivery = new System.Windows.Forms.Label()

			Me.LblStatus = new System.Windows.Forms.Label()

			Me.TxtDelivery = new System.Windows.Forms.TextBox()

			Me.TxtStatus = new System.Windows.Forms.TextBox()

			Me.LblUserPref = new System.Windows.Forms.Label()

			Me.LstPreferences = new System.Windows.Forms.ListView()

			Me.ClmPref = new System.Windows.Forms.ColumnHeader()

			Me.ClmStatus = new System.Windows.Forms.ColumnHeader()

			Me.CboRole = new System.Windows.Forms.ComboBox()

			Me.LblRole = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnGetNotificationPreferences

			' 

			Me.BtnGetNotificationPreferences.Location = new System.Drawing.Point(176, 40)

			Me.BtnGetNotificationPreferences.Name = "BtnGetNotificationPreferences"

			Me.BtnGetNotificationPreferences.Size = new System.Drawing.Size(160, 23)

			Me.BtnGetNotificationPreferences.TabIndex = 9

			Me.BtnGetNotificationPreferences.Text = "GetNotificationPreferences"

			'Me.BtnGetNotificationPreferences.Click += new System.EventHandler(Me.BtnGetNotificationPreferences_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblDelivery)

			Me.GrpResult.Controls.Add(Me.LblStatus)

			Me.GrpResult.Controls.Add(Me.TxtDelivery)

			Me.GrpResult.Controls.Add(Me.TxtStatus)

			Me.GrpResult.Controls.Add(Me.LblUserPref)

			Me.GrpResult.Controls.Add(Me.LstPreferences)

			Me.GrpResult.Location = new System.Drawing.Point(8, 72)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(544, 336)

			Me.GrpResult.TabIndex = 10

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LblDelivery

			' 

			Me.LblDelivery.Location = new System.Drawing.Point(192, 24)

			Me.LblDelivery.Name = "LblDelivery"

			Me.LblDelivery.Size = new System.Drawing.Size(80, 23)

			Me.LblDelivery.TabIndex = 77

			Me.LblDelivery.Text = "Delivery URL:"

			' 

			' LblStatus

			' 

			Me.LblStatus.Location = new System.Drawing.Point(16, 24)

			Me.LblStatus.Name = "LblStatus"

			Me.LblStatus.Size = new System.Drawing.Size(48, 23)

			Me.LblStatus.TabIndex = 75

			Me.LblStatus.Text = "Status:"

			' 

			' TxtDelivery

			' 

			Me.TxtDelivery.Location = new System.Drawing.Point(272, 24)

			Me.TxtDelivery.Name = "TxtDelivery"

			Me.TxtDelivery.ReadOnly = true

			Me.TxtDelivery.Size = new System.Drawing.Size(256, 20)

			Me.TxtDelivery.TabIndex = 73

			Me.TxtDelivery.Text = ""

			' 

			' TxtStatus

			' 

			Me.TxtStatus.Location = new System.Drawing.Point(64, 24)

			Me.TxtStatus.Name = "TxtStatus"

			Me.TxtStatus.ReadOnly = true

			Me.TxtStatus.Size = new System.Drawing.Size(104, 20)

			Me.TxtStatus.TabIndex = 71

			Me.TxtStatus.Text = ""

			' 

			' LblUserPref

			' 

			Me.LblUserPref.Location = new System.Drawing.Point(16, 56)

			Me.LblUserPref.Name = "LblUserPref"

			Me.LblUserPref.Size = new System.Drawing.Size(112, 23)

			Me.LblUserPref.TabIndex = 12

			Me.LblUserPref.Text = "User Preferences:"

			' 

			' LstPreferences

			' 

			Me.LstPreferences.Columns.AddRange(new System.Windows.Forms.ColumnHeader() {Me.ClmPref,Me.ClmStatus})

			Me.LstPreferences.GridLines = true

			Me.LstPreferences.Location = new System.Drawing.Point(16, 88)

			Me.LstPreferences.Name = "LstPreferences"

			Me.LstPreferences.Size = new System.Drawing.Size(520, 240)

			Me.LstPreferences.TabIndex = 13

			Me.LstPreferences.View = System.Windows.Forms.View.Details

			' 

			' ClmPref

			' 

			Me.ClmPref.Text = "Preference"

			Me.ClmPref.Width = 309

			' 

			' ClmStatus

			' 

			Me.ClmStatus.Text = "Status"

			Me.ClmStatus.Width = 190

			' 

			' CboRole

			' 

			Me.CboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboRole.Location = new System.Drawing.Point(200, 8)

			Me.CboRole.Name = "CboRole"

			Me.CboRole.Size = new System.Drawing.Size(160, 21)

			Me.CboRole.TabIndex = 59

			' 

			' LblRole

			' 

			Me.LblRole.Location = new System.Drawing.Point(144, 8)

			Me.LblRole.Name = "LblRole"

			Me.LblRole.Size = new System.Drawing.Size(56, 18)

			Me.LblRole.TabIndex = 58

			Me.LblRole.Text = "Role:"

			' 

			' FrmGetNotificationPreferences

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(560, 413)

			Me.Controls.Add(Me.CboRole)

			Me.Controls.Add(Me.LblRole)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetNotificationPreferences)

			Me.Name = "FrmGetNotificationPreferences"

			Me.Text = "GetNotificationPreferences"

			'Me.Load += new System.EventHandler(Me.FrmGetNotificationPreferences_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)

   End Sub

#End Region


		Public Context As ApiContext


		Private Sub  FrmGetNotificationPreferences_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		
			Dim roles() As String = [Enum].GetNames(GetType(NotificationRoleCodeType))
			Dim role As String

			For Each role in roles
				If role <> "CustomCode" Then
					CboRole.Items.Add(role)

				End If
			Next role

			CboRole.SelectedIndex = 0

		End Sub

    Private Sub BtnGetNotificationPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetNotificationPreferences.Click

        Try

            TxtStatus.Text = ""

            TxtDelivery.Text = ""

            LstPreferences.Items.Clear()

            Dim apicall As GetNotificationPreferencesCall = New GetNotificationPreferencesCall(Context)

            apicall.GetNotificationPreferences([Enum].Parse(GetType(NotificationRoleCodeType), CboRole.SelectedItem.ToString()))

            If Not apicall.ApplicationDeliveryPreferences Is Nothing Then
                TxtStatus.Text = apicall.ApplicationDeliveryPreferences.ApplicationEnable.ToString()
                TxtDelivery.Text = apicall.ApplicationDeliveryPreferences.ApplicationURL
            End If

            Dim notify As NotificationEnableType

            For Each notify In apicall.UserDeliveryPreferenceList

                Dim listparams(7) As String

                listparams(0) = notify.EventType.ToString()

                listparams(1) = notify.EventEnable.ToString()

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstPreferences.Items.Add(vi)
            Next notify

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

