Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetCategories
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

		Friend WithEvents LblParent As System.Windows.Forms.Label 

		Friend WithEvents TxtParent As System.Windows.Forms.TextBox 

		Friend WithEvents TxtLevel As System.Windows.Forms.TextBox 

		Friend WithEvents LblLevel As System.Windows.Forms.Label 

		Friend WithEvents BtnGetCategories As System.Windows.Forms.Button 

		Friend WithEvents ChkViewLeaf As System.Windows.Forms.CheckBox 

		Friend WithEvents ClmCatId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmLevel As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmName As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmParent As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmLeaf As System.Windows.Forms.ColumnHeader

		Friend WithEvents ClmBestOfferEnabled As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmMinimumReservePrice As System.Windows.Forms.ColumnHeader



		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGetCategories = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblCategories = New System.Windows.Forms.Label()
        Me.LstCategories = New System.Windows.Forms.ListView()
        Me.ClmCatId = New System.Windows.Forms.ColumnHeader()
        Me.ClmLevel = New System.Windows.Forms.ColumnHeader()
        Me.ClmName = New System.Windows.Forms.ColumnHeader()
        Me.ClmParent = New System.Windows.Forms.ColumnHeader()
        Me.ClmLeaf = New System.Windows.Forms.ColumnHeader()
        Me.ClmBestOfferEnabled = New System.Windows.Forms.ColumnHeader()
        Me.ClmMinimumReservePrice = New System.Windows.Forms.ColumnHeader()
        Me.ChkViewLeaf = New System.Windows.Forms.CheckBox()
        Me.LblParent = New System.Windows.Forms.Label()
        Me.TxtParent = New System.Windows.Forms.TextBox()
        Me.TxtLevel = New System.Windows.Forms.TextBox()
        Me.LblLevel = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGetCategories
        '
        Me.BtnGetCategories.Location = New System.Drawing.Point(200, 96)
        Me.BtnGetCategories.Name = "BtnGetCategories"
        Me.BtnGetCategories.Size = New System.Drawing.Size(128, 23)
        Me.BtnGetCategories.TabIndex = 9
        Me.BtnGetCategories.Text = "GetCategories"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblCategories, Me.LstCategories})
        Me.GrpResult.Location = New System.Drawing.Point(8, 128)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(752, 280)
        Me.GrpResult.TabIndex = 10
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblCategories
        '
        Me.LblCategories.Location = New System.Drawing.Point(16, 24)
        Me.LblCategories.Name = "LblCategories"
        Me.LblCategories.Size = New System.Drawing.Size(475, 23)
        Me.LblCategories.TabIndex = 12
        Me.LblCategories.Text = "Categories:"
        '
        'LstCategories
        '
        Me.LstCategories.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmCatId, Me.ClmLevel, Me.ClmName, Me.ClmParent, Me.ClmLeaf, Me.ClmBestOfferEnabled, Me.ClmMinimumReservePrice})
        Me.LstCategories.GridLines = True
        Me.LstCategories.Location = New System.Drawing.Point(16, 48)
        Me.LstCategories.Name = "LstCategories"
        Me.LstCategories.Size = New System.Drawing.Size(720, 216)
        Me.LstCategories.TabIndex = 13
        Me.LstCategories.View = System.Windows.Forms.View.Details
        '
        'ClmCatId
        '
        Me.ClmCatId.Text = "Category Id"
        Me.ClmCatId.Width = 83
        '
        'ClmLevel
        '
        Me.ClmLevel.Text = "Level"
        Me.ClmLevel.Width = 40
        '
        'ClmName
        '
        Me.ClmName.Text = "Name"
        Me.ClmName.Width = 150
        '
        'ClmParent
        '
        Me.ClmParent.Text = "Parent Id"
        '
        'ClmLeaf
        '
        Me.ClmLeaf.Text = "Leaf"
        Me.ClmLeaf.Width = 40
        '
        'ClmBestOfferEnabled
        '
        Me.ClmBestOfferEnabled.Text = "BestOfferEnabled"
        Me.ClmBestOfferEnabled.Width = 100
        '
        'ClmMinimumReservePrice
        '
        Me.ClmMinimumReservePrice.Text = "MinimumReservePrice"
        Me.ClmMinimumReservePrice.Width = 120
        '
        'ChkViewLeaf
        '
        Me.ChkViewLeaf.Location = New System.Drawing.Point(152, 64)
        Me.ChkViewLeaf.Name = "ChkViewLeaf"
        Me.ChkViewLeaf.Size = New System.Drawing.Size(160, 24)
        Me.ChkViewLeaf.TabIndex = 11
        Me.ChkViewLeaf.Text = "View Leaf Categories Only"
        '
        'LblParent
        '
        Me.LblParent.Location = New System.Drawing.Point(112, 16)
        Me.LblParent.Name = "LblParent"
        Me.LblParent.Size = New System.Drawing.Size(96, 23)
        Me.LblParent.TabIndex = 13
        Me.LblParent.Text = "Category Parent:"
        '
        'TxtParent
        '
        Me.TxtParent.Location = New System.Drawing.Point(208, 16)
        Me.TxtParent.Name = "TxtParent"
        Me.TxtParent.TabIndex = 14
        Me.TxtParent.Text = ""
        '
        'TxtLevel
        '
        Me.TxtLevel.Location = New System.Drawing.Point(208, 40)
        Me.TxtLevel.Name = "TxtLevel"
        Me.TxtLevel.Size = New System.Drawing.Size(48, 20)
        Me.TxtLevel.TabIndex = 16
        Me.TxtLevel.Text = ""
        '
        'LblLevel
        '
        Me.LblLevel.Location = New System.Drawing.Point(112, 40)
        Me.LblLevel.Name = "LblLevel"
        Me.LblLevel.Size = New System.Drawing.Size(96, 23)
        Me.LblLevel.TabIndex = 15
        Me.LblLevel.Text = "Level Limit:"
        '
        'FormGetCategories
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TxtLevel, Me.TxtParent, Me.LblLevel, Me.LblParent, Me.ChkViewLeaf, Me.GrpResult, Me.BtnGetCategories})
        Me.Name = "FormGetCategories"
        Me.Text = "GetCategoriesForm"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext


		Private Sub  BtnGetCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetCategories.Click

		

			Try

			

				LstCategories.Items.Clear()

	

				Dim apicall As GetCategoriesCall = new GetCategoriesCall(Context)
				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
            apicall.ViewAllNodes = Not ChkViewLeaf.Checked



				If TxtLevel.Text.Length > 0 Then

					apicall.LevelLimit = Convert.ToInt32(TxtLevel.Text)
				End If


				If TxtParent.Text.Length > 0 Then
                apicall.CategoryParent = New StringCollection()
                apicall.CategoryParent.Add(TxtParent.Text)
				End If



				Dim cats As CategoryTypeCollection = apicall.GetCategories()
				Dim category As CategoryType


				For Each category in cats
					Dim listparams(8) As String

					listparams(0) = category.CategoryID

					listparams(1) = category.CategoryLevel.ToString()

					listparams(2) =  category.CategoryName

					listparams(3) = category.CategoryParentID(0).ToString()

					listparams(4) =category.LeafCategory.ToString()

					listparams(5) = category.BestOfferEnabled.ToString()

                listparams(6) = apicall.ApiResponse.MinimumReservePrice.ToString()


					Dim vi As ListViewItem= new ListViewItem(listparams)

					Me.LstCategories.Items.Add(vi)

				Next category

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class
