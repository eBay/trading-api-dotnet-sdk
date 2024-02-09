Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util

Public Class FormGetTokenStatus
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "GetTokenStatus"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(160, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "RevokeToken"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(104, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(160, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "EIASToken"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(104, 112)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(160, 20)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ExpirationTime"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(104, 152)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(160, 20)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "RevocationTime"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(104, 192)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(160, 20)
        Me.TextBox4.TabIndex = 2
        Me.TextBox4.Text = ""
        '
        'FormGetTokenStatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 254)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1, Me.Label1, Me.Button1, Me.Button2, Me.Label2, Me.TextBox2, Me.Label3, Me.TextBox3, Me.Label4, Me.TextBox4})
        Me.Name = "FormGetTokenStatus"
        Me.Text = "FormGetTokenStatus"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Context As ApiContext

    Private Sub GetTokenStatus()
        Try
            If Not ValidateApiAccount() Then
                MessageBox.Show("Please fill in Api Account first.")
                Return
            End If

            Dim apiCall As GetTokenStatusCall = New GetTokenStatusCall(Context)
            apiCall.GetTokenStatus()
            Dim tst As TokenStatusType = apiCall.TokenStatus

            TextBox1.Text = tst.Status.ToString()
            TextBox2.Text = tst.EIASToken
            TextBox3.Text = tst.ExpirationTime.ToString()

            If tst.Status = TokenStatusCodeType.RevokedByApp Or tst.Status = TokenStatusCodeType.RevokedByeBay Or tst.Status = TokenStatusCodeType.RevokedByUser Then
                TextBox4.Enabled = True
                TextBox4.Text = tst.RevocationTime.ToString()
            Else
                TextBox4.Enabled = False
                TextBox4.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function ValidateApiAccount() As Boolean
        Dim apiAccount As ApiAccount
        apiAccount = Context.ApiCredential.ApiAccount
        If apiAccount Is Nothing Or apiAccount.Application.Length = 0 Or apiAccount.Certificate.Length = 0 Or apiAccount.Developer.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GetTokenStatus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not ValidateApiAccount() Then
            MessageBox.Show("Please fill in Api Account first.")
            Return
        End If

        Dim apiCall As RevokeTokenCall = New RevokeTokenCall(Context)
        apiCall.RevokeToken(False)
        GetTokenStatus()
    End Sub
End Class
