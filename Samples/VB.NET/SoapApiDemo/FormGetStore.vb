Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetStore
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



    Friend WithEvents BtnGetStore As System.Windows.Forms.Button

    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox

    Friend WithEvents LblName As System.Windows.Forms.Label

    Friend WithEvents TxtName As System.Windows.Forms.TextBox

    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox

    Friend WithEvents LblDescription As System.Windows.Forms.Label

    Friend WithEvents LblSubscription As System.Windows.Forms.Label

    Friend WithEvents TxtSubscription As System.Windows.Forms.TextBox

    Friend WithEvents LstStoreCats As System.Windows.Forms.ListView

    Friend WithEvents ClmCatId As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmName As System.Windows.Forms.ColumnHeader


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()



        Me.BtnGetStore = New System.Windows.Forms.Button()

        Me.GrpResult = New System.Windows.Forms.GroupBox()

        Me.LblName = New System.Windows.Forms.Label()

        Me.TxtName = New System.Windows.Forms.TextBox()

        Me.TxtDescription = New System.Windows.Forms.TextBox()

        Me.LblDescription = New System.Windows.Forms.Label()

        Me.LblSubscription = New System.Windows.Forms.Label()

        Me.TxtSubscription = New System.Windows.Forms.TextBox()

        Me.LstStoreCats = New System.Windows.Forms.ListView()

        Me.ClmCatId = New System.Windows.Forms.ColumnHeader()

        Me.ClmName = New System.Windows.Forms.ColumnHeader()

        Me.GrpResult.SuspendLayout()

        Me.SuspendLayout()

        ' 

        ' BtnGetStore

        ' 

        Me.BtnGetStore.Location = New System.Drawing.Point(192, 8)

        Me.BtnGetStore.Name = "BtnGetStore"

        Me.BtnGetStore.Size = New System.Drawing.Size(104, 23)

        Me.BtnGetStore.TabIndex = 28

        Me.BtnGetStore.Text = "GetStore"

        'Me.BtnGetStore.Click += New System.EventHandler(Me.BtnGetStore_Click)

        ' 

        ' GrpResult

        ' 

        Me.GrpResult.Controls.Add(Me.LstStoreCats)

        Me.GrpResult.Controls.Add(Me.LblName)

        Me.GrpResult.Controls.Add(Me.TxtName)

        Me.GrpResult.Controls.Add(Me.TxtDescription)

        Me.GrpResult.Controls.Add(Me.LblDescription)

        Me.GrpResult.Controls.Add(Me.LblSubscription)

        Me.GrpResult.Controls.Add(Me.TxtSubscription)

        Me.GrpResult.Location = New System.Drawing.Point(8, 40)

        Me.GrpResult.Name = "GrpResult"

        Me.GrpResult.Size = New System.Drawing.Size(440, 248)

        Me.GrpResult.TabIndex = 41

        Me.GrpResult.TabStop = False

        Me.GrpResult.Text = "Result"

        ' 

        ' LblName

        ' 

        Me.LblName.Location = New System.Drawing.Point(8, 24)

        Me.LblName.Name = "LblName"

        Me.LblName.Size = New System.Drawing.Size(72, 23)

        Me.LblName.TabIndex = 61

        Me.LblName.Text = "Name:"

        ' 

        ' TxtName

        ' 

        Me.TxtName.Location = New System.Drawing.Point(80, 24)

        Me.TxtName.Name = "TxtName"

        Me.TxtName.ReadOnly = True

        Me.TxtName.Size = New System.Drawing.Size(120, 20)

        Me.TxtName.TabIndex = 72

        Me.TxtName.Text = ""

        ' 

        ' TxtDescription

        ' 

        Me.TxtDescription.Location = New System.Drawing.Point(80, 48)

        Me.TxtDescription.Multiline = True

        Me.TxtDescription.Name = "TxtDescription"

        Me.TxtDescription.ReadOnly = True

        Me.TxtDescription.Size = New System.Drawing.Size(336, 56)

        Me.TxtDescription.TabIndex = 70

        Me.TxtDescription.Text = ""

        ' 

        ' LblDescription

        ' 

        Me.LblDescription.Location = New System.Drawing.Point(8, 48)

        Me.LblDescription.Name = "LblDescription"

        Me.LblDescription.Size = New System.Drawing.Size(72, 23)

        Me.LblDescription.TabIndex = 54

        Me.LblDescription.Text = "Description:"

        ' 

        ' LblSubscription

        ' 

        Me.LblSubscription.Location = New System.Drawing.Point(224, 24)

        Me.LblSubscription.Name = "LblSubscription"

        Me.LblSubscription.Size = New System.Drawing.Size(72, 23)

        Me.LblSubscription.TabIndex = 58

        Me.LblSubscription.Text = "Subscription:"

        ' 

        ' TxtSubscription

        ' 

        Me.TxtSubscription.Location = New System.Drawing.Point(296, 24)

        Me.TxtSubscription.Name = "TxtSubscription"

        Me.TxtSubscription.ReadOnly = True

        Me.TxtSubscription.Size = New System.Drawing.Size(120, 20)

        Me.TxtSubscription.TabIndex = 64

        Me.TxtSubscription.Text = ""

        ' 

        ' LstStoreCats

        ' 

        Me.LstStoreCats.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right)

        Me.LstStoreCats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmCatId, Me.ClmName})

        Me.LstStoreCats.GridLines = True

        Me.LstStoreCats.Location = New System.Drawing.Point(0, 120)

        Me.LstStoreCats.Name = "LstStoreCats"

        Me.LstStoreCats.Size = New System.Drawing.Size(440, 120)

        Me.LstStoreCats.TabIndex = 73

        Me.LstStoreCats.View = System.Windows.Forms.View.Details

        ' 

        ' ClmCatId

        ' 

        Me.ClmCatId.Text = "Category Id"

        Me.ClmCatId.Width = 80

        ' 

        ' ClmName

        ' 

        Me.ClmName.Text = "Name"

        Me.ClmName.Width = 346

        ' 

        ' FrmGetStore

        ' 

        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.ClientSize = New System.Drawing.Size(456, 293)

        Me.Controls.Add(Me.GrpResult)

        Me.Controls.Add(Me.BtnGetStore)

        Me.Name = "FrmGetStore"

        Me.Text = "GetStore"

        Me.GrpResult.ResumeLayout(False)

        Me.ResumeLayout(False)
    End Sub

#End Region


    Public Context As ApiContext

    Private Sub BtnGetStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetStore.Click



        Try



            LstStoreCats.Items.Clear()

            TxtName.Text = ""

            TxtSubscription.Text = ""

            TxtDescription.Text = ""



            Dim apicall As GetStoreCall = New GetStoreCall(Context)



            Dim store As StoreType = apicall.GetStore()



            TxtName.Text = store.Name

            TxtSubscription.Text = store.SubscriptionLevel.ToString()

            TxtDescription.Text = store.Description

            Dim cat As StoreCustomCategoryType

            For Each cat In store.CustomCategories



                Dim listparams(2) As String

                listparams(0) = cat.CategoryID.ToString()

                listparams(1) = cat.Name



                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstStoreCats.Items.Add(vi)



            Next cat



        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

