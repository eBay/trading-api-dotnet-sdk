Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGeteBayOfficialTime
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

		Friend WithEvents BtnGeteBayOfficialTime As System.Windows.Forms.Button 

		Friend WithEvents LblOfficialTime As System.Windows.Forms.Label 





		Friend WithEvents DatePickOfficialTime As System.Windows.Forms.DateTimePicker 








		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGeteBayOfficialTime = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.DatePickOfficialTime = New System.Windows.Forms.DateTimePicker()
        Me.LblOfficialTime = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGeteBayOfficialTime
        '
        Me.BtnGeteBayOfficialTime.Location = New System.Drawing.Point(120, 8)
        Me.BtnGeteBayOfficialTime.Name = "BtnGeteBayOfficialTime"
        Me.BtnGeteBayOfficialTime.Size = New System.Drawing.Size(120, 23)
        Me.BtnGeteBayOfficialTime.TabIndex = 23
        Me.BtnGeteBayOfficialTime.Text = "GeteBayOfficialTime"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.DatePickOfficialTime, Me.LblOfficialTime})
        Me.GrpResult.Location = New System.Drawing.Point(8, 48)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(352, 56)
        Me.GrpResult.TabIndex = 25
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'DatePickOfficialTime
        '
        Me.DatePickOfficialTime.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DatePickOfficialTime.Enabled = False
        Me.DatePickOfficialTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePickOfficialTime.Location = New System.Drawing.Point(96, 16)
        Me.DatePickOfficialTime.Name = "DatePickOfficialTime"
        Me.DatePickOfficialTime.Size = New System.Drawing.Size(160, 20)
        Me.DatePickOfficialTime.TabIndex = 61
        '
        'LblOfficialTime
        '
        Me.LblOfficialTime.Location = New System.Drawing.Point(16, 16)
        Me.LblOfficialTime.Name = "LblOfficialTime"
        Me.LblOfficialTime.Size = New System.Drawing.Size(80, 16)
        Me.LblOfficialTime.TabIndex = 42
        Me.LblOfficialTime.Text = "Official Time:"
        '
        'FormGeteBayOfficialTime
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 117)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GrpResult, Me.BtnGeteBayOfficialTime})
        Me.Name = "FormGeteBayOfficialTime"
        Me.Text = "GeteBayOfficialTime"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext


		Private Sub  FrmGeteBayOfficialTime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DatePickOfficialTime.Value = DateTimePicker.MinDateTime
    End Sub




    Private Sub BtnGeteBayOfficialTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGeteBayOfficialTime.Click



        Try



            Dim apicall As GeteBayOfficialTimeCall = New GeteBayOfficialTimeCall(Context)



            DatePickOfficialTime.Value = apicall.GeteBayOfficialTime()


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub


End Class

