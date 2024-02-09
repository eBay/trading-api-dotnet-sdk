Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetSuggestedCategories
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

		Friend WithEvents LblCategories As System.Windows.Forms.Label 

		Friend WithEvents LstCategories As System.Windows.Forms.ListView 

		Friend WithEvents BtnGetSuggestedCategories As System.Windows.Forms.Button 

		Friend WithEvents ClmCatId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmName As System.Windows.Forms.ColumnHeader 

		Friend WithEvents LblQuery As System.Windows.Forms.Label 

		Friend WithEvents TxtQuery As System.Windows.Forms.TextBox 

		Friend WithEvents ClmPercent As System.Windows.Forms.ColumnHeader 

		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

			Me.BtnGetSuggestedCategories = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblCategories = new System.Windows.Forms.Label()

			Me.LstCategories = new System.Windows.Forms.ListView()

			Me.ClmCatId = new System.Windows.Forms.ColumnHeader()

			Me.ClmName = new System.Windows.Forms.ColumnHeader()

			Me.ClmPercent = new System.Windows.Forms.ColumnHeader()

			Me.LblQuery = new System.Windows.Forms.Label()

			Me.TxtQuery = new System.Windows.Forms.TextBox()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnGetSuggestedCategories

			' 

			Me.BtnGetSuggestedCategories.Location = new System.Drawing.Point(168, 40)

			Me.BtnGetSuggestedCategories.Name = "BtnGetSuggestedCategories"

			Me.BtnGetSuggestedCategories.Size = new System.Drawing.Size(176, 23)

			Me.BtnGetSuggestedCategories.TabIndex = 9

			Me.BtnGetSuggestedCategories.Text = "GetSuggestedCategories"

        'Me.BtnGetSuggestedCategories.Click += new System.EventHandler(Me.BtnGetSuggestedCategories_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblCategories)

			Me.GrpResult.Controls.Add(Me.LstCategories)

			Me.GrpResult.Location = new System.Drawing.Point(8, 72)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(504, 336)

			Me.GrpResult.TabIndex = 10

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LblCategories

			' 

			Me.LblCategories.Location = new System.Drawing.Point(16, 24)

			Me.LblCategories.Name = "LblCategories"

			Me.LblCategories.Size = new System.Drawing.Size(475, 23)

			Me.LblCategories.TabIndex = 12

			Me.LblCategories.Text = "Suggested Categories:"

			' 

			' LstCategories

			' 

			Me.LstCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader(){Me.ClmCatId,Me.ClmName,Me.ClmPercent})

			Me.LstCategories.GridLines = true

			Me.LstCategories.Location = new System.Drawing.Point(16, 48)

			Me.LstCategories.Name = "LstCategories"

			Me.LstCategories.Size = new System.Drawing.Size(480, 280)

			Me.LstCategories.TabIndex = 13

			Me.LstCategories.View = System.Windows.Forms.View.Details

			' 

			' ClmCatId

			' 

			Me.ClmCatId.Text = "Category Id"

			Me.ClmCatId.Width = 70

			' 

			' ClmName

			' 

			Me.ClmName.Text = "Name"

			Me.ClmName.Width = 297

			' 

			' ClmPercent

			' 

			Me.ClmPercent.Text = "Percent Found"

			Me.ClmPercent.Width = 89

			' 

			' LblQuery

			' 

			Me.LblQuery.Location = new System.Drawing.Point(64, 16)

			Me.LblQuery.Name = "LblQuery"

			Me.LblQuery.Size = new System.Drawing.Size(96, 23)

			Me.LblQuery.TabIndex = 13

			Me.LblQuery.Text = "Query:"

			' 

			' TxtQuery

			' 

			Me.TxtQuery.Location = new System.Drawing.Point(160, 16)

			Me.TxtQuery.Name = "TxtQuery"

			Me.TxtQuery.Size = new System.Drawing.Size(288, 20)

			Me.TxtQuery.TabIndex = 14

			Me.TxtQuery.Text = ""

			' 

			' FrmGetSuggestedCategories

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(520, 413)

			Me.Controls.Add(Me.TxtQuery)

			Me.Controls.Add(Me.LblQuery)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetSuggestedCategories)

			Me.Name = "FrmGetSuggestedCategories"

			Me.Text = "GetSuggestedCategoriesForm"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)

   End Sub

#End Region


    Public Context As ApiContext


		Private Sub  BtnGetSuggestedCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetSuggestedCategories.Click

			Try

				LstCategories.Items.Clear()

				Dim apicall As GetSuggestedCategoriesCall = new GetSuggestedCategoriesCall(Context)

            Dim cats As SuggestedCategoryTypeCollection = apicall.GetSuggestedCategories(TxtQuery.Text)

            If Not (cats Is Nothing) Then

                Dim category As SuggestedCategoryType
                For Each category In cats

                    Dim listparams(3) As String

                    listparams(0) = category.Category.CategoryID

                    listparams(1) = String.Join(" : ", category.Category.CategoryParentName.ToArray()) + " : " + category.Category.CategoryName

                    listparams(2) = category.PercentItemFound.ToString()

                    Dim vi As ListViewItem = New ListViewItem(listparams)

                    Me.LstCategories.Items.Add(vi)

                Next category
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

