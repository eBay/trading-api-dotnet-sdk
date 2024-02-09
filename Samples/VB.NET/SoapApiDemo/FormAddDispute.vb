Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormAddDispute
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

    Friend WithEvents TxtItemId As System.Windows.Forms.TextBox

    Friend WithEvents LblItemId As System.Windows.Forms.Label

    Friend WithEvents CboReason As System.Windows.Forms.ComboBox

    Friend WithEvents LblReason As System.Windows.Forms.Label

    Friend WithEvents BtnAddDispute As System.Windows.Forms.Button

    Friend WithEvents TxtTransactionId As System.Windows.Forms.TextBox

    Friend WithEvents LblTransactionId As System.Windows.Forms.Label

    Friend WithEvents CboExplanation As System.Windows.Forms.ComboBox

    Friend WithEvents LblExplanation As System.Windows.Forms.Label

    Friend WithEvents LblDisputeId As System.Windows.Forms.Label

    Friend WithEvents TxtDisputeId As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        Me.BtnAddDispute = New System.Windows.Forms.Button()

        Me.GrpResult = New System.Windows.Forms.GroupBox()

        Me.LblDisputeId = New System.Windows.Forms.Label()

        Me.TxtDisputeId = New System.Windows.Forms.TextBox()

        Me.TxtItemId = New System.Windows.Forms.TextBox()

        Me.LblItemId = New System.Windows.Forms.Label()

        Me.CboReason = New System.Windows.Forms.ComboBox()

        Me.LblReason = New System.Windows.Forms.Label()

        Me.TxtTransactionId = New System.Windows.Forms.TextBox()

        Me.LblTransactionId = New System.Windows.Forms.Label()

        Me.CboExplanation = New System.Windows.Forms.ComboBox()

        Me.LblExplanation = New System.Windows.Forms.Label()

        Me.GrpResult.SuspendLayout()

        Me.SuspendLayout()

        ' 

        ' BtnAddDispute

        ' 

        Me.BtnAddDispute.Location = New System.Drawing.Point(120, 112)

        Me.BtnAddDispute.Name = "BtnAddDispute"

        Me.BtnAddDispute.Size = New System.Drawing.Size(112, 23)

        Me.BtnAddDispute.TabIndex = 56

        Me.BtnAddDispute.Text = "AddDispute"

        'Me.BtnAddDispute.Click += New System.EventHandler(Me.BtnAddDispute_Click)

        ' 

        ' GrpResult

        ' 

        Me.GrpResult.Controls.Add(Me.LblDisputeId)

        Me.GrpResult.Controls.Add(Me.TxtDisputeId)

        Me.GrpResult.Location = New System.Drawing.Point(8, 144)

        Me.GrpResult.Name = "GrpResult"

        Me.GrpResult.Size = New System.Drawing.Size(352, 64)

        Me.GrpResult.TabIndex = 25

        Me.GrpResult.TabStop = False

        Me.GrpResult.Text = "Result"

        ' 

        ' LblDisputeId

        ' 

        Me.LblDisputeId.Location = New System.Drawing.Point(16, 24)

        Me.LblDisputeId.Name = "LblDisputeId"

        Me.LblDisputeId.Size = New System.Drawing.Size(80, 23)

        Me.LblDisputeId.TabIndex = 42

        Me.LblDisputeId.Text = "Dispute Id:"

        ' 

        ' TxtDisputeId

        ' 

        Me.TxtDisputeId.Location = New System.Drawing.Point(96, 24)

        Me.TxtDisputeId.Name = "TxtDisputeId"

        Me.TxtDisputeId.ReadOnly = True

        Me.TxtDisputeId.Size = New System.Drawing.Size(104, 20)

        Me.TxtDisputeId.TabIndex = 41

        Me.TxtDisputeId.Text = ""

        ' 

        ' TxtItemId

        ' 

        Me.TxtItemId.Location = New System.Drawing.Point(152, 8)

        Me.TxtItemId.Name = "TxtItemId"

        Me.TxtItemId.Size = New System.Drawing.Size(80, 20)

        Me.TxtItemId.TabIndex = 26

        Me.TxtItemId.Text = ""

        ' 

        ' LblItemId

        ' 

        Me.LblItemId.Location = New System.Drawing.Point(72, 8)

        Me.LblItemId.Name = "LblItemId"

        Me.LblItemId.Size = New System.Drawing.Size(80, 23)

        Me.LblItemId.TabIndex = 27

        Me.LblItemId.Text = "Item Id:"

        ' 

        ' CboReason

        ' 

        Me.CboReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.CboReason.Location = New System.Drawing.Point(152, 56)

        Me.CboReason.Name = "CboReason"

        Me.CboReason.Size = New System.Drawing.Size(144, 21)

        Me.CboReason.TabIndex = 55

        ' 

        ' LblReason

        ' 

        Me.LblReason.Location = New System.Drawing.Point(72, 56)

        Me.LblReason.Name = "LblReason"

        Me.LblReason.Size = New System.Drawing.Size(80, 18)

        Me.LblReason.TabIndex = 54

        Me.LblReason.Text = "Reason:"

        ' 

        ' TxtTransactionId

        ' 

        Me.TxtTransactionId.Location = New System.Drawing.Point(152, 32)

        Me.TxtTransactionId.Name = "TxtTransactionId"

        Me.TxtTransactionId.Size = New System.Drawing.Size(80, 20)

        Me.TxtTransactionId.TabIndex = 57

        Me.TxtTransactionId.Text = "0"

        ' 

        ' LblTransactionId

        ' 

        Me.LblTransactionId.Location = New System.Drawing.Point(72, 32)

        Me.LblTransactionId.Name = "LblTransactionId"

        Me.LblTransactionId.Size = New System.Drawing.Size(80, 23)

        Me.LblTransactionId.TabIndex = 58

        Me.LblTransactionId.Text = "Transaction Id:"

        ' 

        ' CboExplanation

        ' 

        Me.CboExplanation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.CboExplanation.Location = New System.Drawing.Point(152, 80)

        Me.CboExplanation.Name = "CboExplanation"

        Me.CboExplanation.Size = New System.Drawing.Size(144, 21)

        Me.CboExplanation.TabIndex = 60

        ' 

        ' LblExplanation

        ' 

        Me.LblExplanation.Location = New System.Drawing.Point(72, 80)

        Me.LblExplanation.Name = "LblExplanation"

        Me.LblExplanation.Size = New System.Drawing.Size(80, 18)

        Me.LblExplanation.TabIndex = 59

        Me.LblExplanation.Text = "Explanation:"

        ' 

        ' FrmAddDispute

        ' 

        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.ClientSize = New System.Drawing.Size(368, 213)

        Me.Controls.Add(Me.CboExplanation)

        Me.Controls.Add(Me.LblExplanation)

        Me.Controls.Add(Me.TxtTransactionId)

        Me.Controls.Add(Me.TxtItemId)

        Me.Controls.Add(Me.LblTransactionId)

        Me.Controls.Add(Me.CboReason)

        Me.Controls.Add(Me.LblReason)

        Me.Controls.Add(Me.LblItemId)

        Me.Controls.Add(Me.GrpResult)

        Me.Controls.Add(Me.BtnAddDispute)

        Me.Name = "FrmAddDispute"

        Me.Text = "AddDispute"

        'Me.Load += new System.EventHandler(Me.FrmAddDispute_Load)

        Me.GrpResult.ResumeLayout(False)

        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub FrmAddDispute_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim reasons As Type = GetType(DisputeReasonCodeType)
        Dim rsn As String

        For Each rsn In [Enum].GetNames(reasons)



            If rsn <> "CustomCode" Then



                CboReason.Items.Add(rsn)

            End If

        Next rsn

        CboReason.SelectedIndex = 0


        Dim explanation As Type = GetType(DisputeExplanationCodeType)
        Dim exp As String

        For Each exp In [Enum].GetNames(explanation)

            If exp <> "CustomCode" Then

                CboExplanation.Items.Add(exp)

            End If

        Next exp

        CboExplanation.SelectedIndex = 0


    End Sub





    Private Sub BtnAddDispute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDispute.Click



        Try



            TxtDisputeId.Text = ""

            Dim ApiCall As AddDisputeCall = New AddDisputeCall(Context)
            Dim DisputeId As String = ApiCall.AddDispute(TxtItemId.Text, TxtTransactionId.Text, [Enum].Parse(GetType(DisputeReasonCodeType), CboReason.SelectedItem.ToString()), [Enum].Parse(GetType(DisputeExplanationCodeType), CboExplanation.SelectedItem.ToString()))

            TxtDisputeId.Text = DisputeId

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class
