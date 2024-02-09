Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetApiAccessRules
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

		Friend WithEvents BtnGetApiAccessRules As System.Windows.Forms.Button 

		Friend WithEvents LblApiAccessRules As System.Windows.Forms.Label 

		Friend WithEvents LstAccessRules As System.Windows.Forms.ListView 

		Friend WithEvents ClmCallName As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmHourSoft As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmHourHard As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmHourUsage As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmDaySoft As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmDayHard As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmDayUsage As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmCounts As System.Windows.Forms.ColumnHeader 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.BtnGetApiAccessRules = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblApiAccessRules = new System.Windows.Forms.Label()

			Me.LstAccessRules = new System.Windows.Forms.ListView()

			Me.ClmCallName = new System.Windows.Forms.ColumnHeader()

			Me.ClmHourSoft = new System.Windows.Forms.ColumnHeader()

			Me.ClmHourHard = new System.Windows.Forms.ColumnHeader()

			Me.ClmHourUsage = new System.Windows.Forms.ColumnHeader()

			Me.ClmDaySoft = new System.Windows.Forms.ColumnHeader()

			Me.ClmDayHard = new System.Windows.Forms.ColumnHeader()

			Me.ClmDayUsage = new System.Windows.Forms.ColumnHeader()

			Me.ClmCounts = new System.Windows.Forms.ColumnHeader()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnGetApiAccessRules

			' 

			Me.BtnGetApiAccessRules.Location = new System.Drawing.Point(200, 8)

			Me.BtnGetApiAccessRules.Name = "BtnGetApiAccessRules"

			Me.BtnGetApiAccessRules.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetApiAccessRules.TabIndex = 9

			Me.BtnGetApiAccessRules.Text = "GetApiAccessRules"

        'Me.BtnGetApiAccessRules.Click += new System.EventHandler(Me.BtnGetApiAccessRules_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblApiAccessRules)

			Me.GrpResult.Controls.Add(Me.LstAccessRules)

			Me.GrpResult.Location = new System.Drawing.Point(8, 48)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(552, 280)

			Me.GrpResult.TabIndex = 10

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LblApiAccessRules

			' 

			Me.LblApiAccessRules.Location = new System.Drawing.Point(16, 24)

			Me.LblApiAccessRules.Name = "LblApiAccessRules"

			Me.LblApiAccessRules.Size = new System.Drawing.Size(475, 23)

			Me.LblApiAccessRules.TabIndex = 12

			Me.LblApiAccessRules.Text = "Api Access Rules:"

			' 

			' LstAccessRules

			' 

        Me.LstAccessRules.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmCallName, Me.ClmHourSoft, Me.ClmHourHard, Me.ClmHourUsage, Me.ClmDaySoft, Me.ClmDayHard, Me.ClmDayUsage, Me.ClmCounts})

			Me.LstAccessRules.GridLines = true

			Me.LstAccessRules.Location = new System.Drawing.Point(16, 48)

			Me.LstAccessRules.Name = "LstAccessRules"

			Me.LstAccessRules.Size = new System.Drawing.Size(528, 224)

			Me.LstAccessRules.TabIndex = 13

			Me.LstAccessRules.View = System.Windows.Forms.View.Details

			' 

			' ClmCallName

			' 

			Me.ClmCallName.Text = "Api Name"

			Me.ClmCallName.Width = 69

			' 

			' ClmHourSoft

			' 

			Me.ClmHourSoft.Text = "Hour Soft"

			' 

			' ClmHourHard

			' 

			Me.ClmHourHard.Text = "Hour Hard"

			Me.ClmHourHard.Width = 64

			' 

			' ClmHourUsage

			' 

			Me.ClmHourUsage.Text = "Hour Usage"

			Me.ClmHourUsage.Width = 73

			' 

			' ClmDaySoft

			' 

			Me.ClmDaySoft.Text = "Day Soft"

			Me.ClmDaySoft.Width = 58

			' 

			' ClmDayHard

			' 

			Me.ClmDayHard.Text = "Day Hard"

			Me.ClmDayHard.Width = 57

			' 

			' ClmDayUsage

			' 

			Me.ClmDayUsage.Text = "Day Usage"

			Me.ClmDayUsage.Width = 66

			' 

			' ClmCounts

			' 

			Me.ClmCounts.Text = "Aggregates"

			Me.ClmCounts.Width = 72

			' 

			' FrmGetApiAccessRules

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(568, 341)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetApiAccessRules)

			Me.Name = "FrmGetApiAccessRules"

			Me.Text = "GetApiAccessRulesForm"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


    Public Context As ApiContext

		Private Sub  BtnGetApiAccessRules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetApiAccessRules.Click
		Try

            LstAccessRules.Items.Clear()
            Dim apicall As GetApiAccessRulesCall = New GetApiAccessRulesCall(Context)
            Dim rules As ApiAccessRuleTypeCollection = apicall.GetApiAccessRules()
            Dim rule As ApiAccessRuleType

            For Each rule In rules
                Dim listparams(9) As String

                listparams(0) = rule.CallName

                listparams(1) = rule.HourlySoftLimit.ToString()

                listparams(2) = rule.HourlyHardLimit.ToString()

                listparams(3) = rule.HourlyUsage.ToString()

                listparams(4) = rule.DailySoftLimit.ToString()

                listparams(5) = rule.DailyHardLimit.ToString()

                listparams(6) = rule.DailyUsage.ToString()

                listparams(7) = rule.CountsTowardAggregate.ToString()


                Dim vi As ListViewItem = New ListViewItem(listparams)

                Me.LstAccessRules.Items.Add(vi)
            Next rule


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class
