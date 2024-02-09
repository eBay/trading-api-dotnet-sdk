Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetStoreCustomPage
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




		Friend WithEvents BtnGetStoreCustomPage As System.Windows.Forms.Button 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents TxtPageId As System.Windows.Forms.TextBox 

		Friend WithEvents LblPageId As System.Windows.Forms.Label 

		Friend WithEvents LstCustomPage As System.Windows.Forms.ListView 

		Friend WithEvents ClmTitle As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmPageId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmStatus As System.Windows.Forms.ColumnHeader 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

			Me.BtnGetStoreCustomPage = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LstCustomPage = new System.Windows.Forms.ListView()

			Me.ClmTitle = new System.Windows.Forms.ColumnHeader()

			Me.ClmPageId = new System.Windows.Forms.ColumnHeader()

			Me.TxtPageId = new System.Windows.Forms.TextBox()

			Me.LblPageId = new System.Windows.Forms.Label()

			Me.ClmStatus = new System.Windows.Forms.ColumnHeader()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnGetStoreCustomPage

			' 

			Me.BtnGetStoreCustomPage.Location = new System.Drawing.Point(168, 40)

			Me.BtnGetStoreCustomPage.Name = "BtnGetStoreCustomPage"

			Me.BtnGetStoreCustomPage.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetStoreCustomPage.TabIndex = 28

			Me.BtnGetStoreCustomPage.Text = "GetStoreCustomPage"

        'Me.BtnGetStoreCustomPage.Click += new System.EventHandler(Me.BtnGetStoreCustomPage_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LstCustomPage)

			Me.GrpResult.Location = new System.Drawing.Point(8, 88)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(440, 200)

			Me.GrpResult.TabIndex = 41

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LstCustomPage

			' 

        Me.LstCustomPage.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right

			Me.LstCustomPage.Columns.AddRange(new System.Windows.Forms.ColumnHeader(){Me.ClmTitle,Me.ClmPageId,Me.ClmStatus})

			Me.LstCustomPage.GridLines = true

			Me.LstCustomPage.Location = new System.Drawing.Point(0, 24)

			Me.LstCustomPage.Name = "LstCustomPage"

			Me.LstCustomPage.Size = new System.Drawing.Size(440, 160)

			Me.LstCustomPage.TabIndex = 73

			Me.LstCustomPage.View = System.Windows.Forms.View.Details

			' 

			' ClmTitle

			' 

			Me.ClmTitle.Text = "Title"

			Me.ClmTitle.Width = 80

			' 

			' ClmPageId

			' 

			Me.ClmPageId.Text = "Page Id"

			Me.ClmPageId.Width = 153

			' 

			' TxtPageId

			' 

			Me.TxtPageId.Location = new System.Drawing.Point(208, 8)

			Me.TxtPageId.Name = "TxtPageId"

			Me.TxtPageId.Size = new System.Drawing.Size(104, 20)

			Me.TxtPageId.TabIndex = 43

			Me.TxtPageId.Text = ""

			' 

			' LblPageId

			' 

			Me.LblPageId.Location = new System.Drawing.Point(144, 8)

			Me.LblPageId.Name = "LblPageId"

			Me.LblPageId.Size = new System.Drawing.Size(64, 23)

			Me.LblPageId.TabIndex = 42

			Me.LblPageId.Text = "Page Id:"

			' 

			' ClmStatus

			' 

			Me.ClmStatus.Text = "Status"

			Me.ClmStatus.Width = 195

			' 

			' FrmGetStoreCustomPage

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(456, 293)

			Me.Controls.Add(Me.TxtPageId)

			Me.Controls.Add(Me.LblPageId)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetStoreCustomPage)

			Me.Name = "FrmGetStoreCustomPage"

			Me.Text = "GetStoreCustomPage"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


    Public Context As ApiContext

    Private Sub BtnGetStoreCustomPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetStoreCustomPage.Click



        Try
            LstCustomPage.Items.Clear()

            Dim apicall As GetStoreCustomPageCall = New GetStoreCustomPageCall(Context)

            If TxtPageId.Text <> String.Empty Then

                apicall.PageID = TxtPageId.Text
            End If



            Dim pages As StoreCustomPageTypeCollection = apicall.GetStoreCustomPage()
            Dim page As StoreCustomPageType

            For Each page In pages
                Dim listparams(3) As String

                listparams(0) = page.Name

                listparams(1) = page.PageID.ToString()

                listparams(2) = page.Status.ToString()

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstCustomPage.Items.Add(vi)

            Next page

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class
