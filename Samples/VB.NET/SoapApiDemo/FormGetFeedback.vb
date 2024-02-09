Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetFeedback
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

		Friend WithEvents BtnGetFeedback As System.Windows.Forms.Button 

		Friend WithEvents LblUserId As System.Windows.Forms.Label 

		Friend WithEvents TxtUserId As System.Windows.Forms.TextBox 

		Friend WithEvents LblFeedbacks As System.Windows.Forms.Label 

		Friend WithEvents LstComments As System.Windows.Forms.ListView 

		Friend WithEvents ClmUser As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmScore As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmType As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmRole As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmTime As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmComment As System.Windows.Forms.ColumnHeader 

		Friend WithEvents TxtPositive As System.Windows.Forms.TextBox 

		Friend WithEvents TxtNegative As System.Windows.Forms.TextBox 

		Friend WithEvents TxtScore As System.Windows.Forms.TextBox 

		Friend WithEvents LblPositive As System.Windows.Forms.Label 

		Friend WithEvents LblNegative As System.Windows.Forms.Label 

		Friend WithEvents LblScore As System.Windows.Forms.Label 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()


		

			Me.BtnGetFeedback = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblScore = new System.Windows.Forms.Label()

			Me.LblNegative = new System.Windows.Forms.Label()

			Me.LblPositive = new System.Windows.Forms.Label()

			Me.TxtScore = new System.Windows.Forms.TextBox()

			Me.TxtNegative = new System.Windows.Forms.TextBox()

			Me.TxtPositive = new System.Windows.Forms.TextBox()

			Me.LblFeedbacks = new System.Windows.Forms.Label()

			Me.LstComments = new System.Windows.Forms.ListView()

			Me.ClmUser = new System.Windows.Forms.ColumnHeader()

			Me.ClmScore = new System.Windows.Forms.ColumnHeader()

			Me.ClmItemId = new System.Windows.Forms.ColumnHeader()

			Me.ClmType = new System.Windows.Forms.ColumnHeader()

			Me.ClmComment = new System.Windows.Forms.ColumnHeader()

			Me.ClmRole = new System.Windows.Forms.ColumnHeader()

			Me.ClmTime = new System.Windows.Forms.ColumnHeader()

			Me.LblUserId = new System.Windows.Forms.Label()

			Me.TxtUserId = new System.Windows.Forms.TextBox()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnGetFeedback

			' 

			Me.BtnGetFeedback.Location = new System.Drawing.Point(240, 40)

			Me.BtnGetFeedback.Name = "BtnGetFeedback"

			Me.BtnGetFeedback.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetFeedback.TabIndex = 9

			Me.BtnGetFeedback.Text = "GetFeedback"

        'Me.BtnGetFeedback.Click += new System.EventHandler(Me.BtnGetFeedback_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LblScore)

			Me.GrpResult.Controls.Add(Me.LblNegative)

			Me.GrpResult.Controls.Add(Me.LblPositive)

			Me.GrpResult.Controls.Add(Me.TxtScore)

			Me.GrpResult.Controls.Add(Me.TxtNegative)

			Me.GrpResult.Controls.Add(Me.TxtPositive)

			Me.GrpResult.Controls.Add(Me.LblFeedbacks)

			Me.GrpResult.Controls.Add(Me.LstComments)

			Me.GrpResult.Location = new System.Drawing.Point(8, 72)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(544, 336)

			Me.GrpResult.TabIndex = 10

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LblScore

			' 

			Me.LblScore.Location = new System.Drawing.Point(280, 24)

			Me.LblScore.Name = "LblScore"

			Me.LblScore.Size = new System.Drawing.Size(56, 23)

			Me.LblScore.TabIndex = 78

			Me.LblScore.Text = "Score:"

			' 

			' LblNegative

			' 

			Me.LblNegative.Location = new System.Drawing.Point(144, 24)

			Me.LblNegative.Name = "LblNegative"

			Me.LblNegative.Size = new System.Drawing.Size(56, 23)

			Me.LblNegative.TabIndex = 77

			Me.LblNegative.Text = "Negative:"

			' 

			' LblPositive

			' 

			Me.LblPositive.Location = new System.Drawing.Point(16, 24)

			Me.LblPositive.Name = "LblPositive"

			Me.LblPositive.Size = new System.Drawing.Size(48, 23)

			Me.LblPositive.TabIndex = 75

			Me.LblPositive.Text = "Positive:"

			' 

			' TxtScore

			' 

			Me.TxtScore.Location = new System.Drawing.Point(336, 24)

			Me.TxtScore.Name = "TxtScore"

			Me.TxtScore.ReadOnly = true

			Me.TxtScore.Size = new System.Drawing.Size(56, 20)

			Me.TxtScore.TabIndex = 74

			Me.TxtScore.Text = ""

			' 

			' TxtNegative

			' 

			Me.TxtNegative.Location = new System.Drawing.Point(200, 24)

			Me.TxtNegative.Name = "TxtNegative"

			Me.TxtNegative.ReadOnly = true

			Me.TxtNegative.Size = new System.Drawing.Size(56, 20)

			Me.TxtNegative.TabIndex = 73

			Me.TxtNegative.Text = ""

			' 

			' TxtPositive

			' 

			Me.TxtPositive.Location = new System.Drawing.Point(64, 24)

			Me.TxtPositive.Name = "TxtPositive"

			Me.TxtPositive.ReadOnly = true

			Me.TxtPositive.Size = new System.Drawing.Size(56, 20)

			Me.TxtPositive.TabIndex = 71

			Me.TxtPositive.Text = ""

			' 

			' LblFeedbacks

			' 

			Me.LblFeedbacks.Location = new System.Drawing.Point(16, 56)

			Me.LblFeedbacks.Name = "LblFeedbacks"

			Me.LblFeedbacks.Size = new System.Drawing.Size(112, 23)

			Me.LblFeedbacks.TabIndex = 12

			Me.LblFeedbacks.Text = "Feedback:"

			' 

			' LstComments

			' 

			Me.LstComments.Columns.AddRange(new System.Windows.Forms.ColumnHeader() {Me.ClmUser,Me.ClmScore,Me.ClmItemId,Me.ClmType,Me.ClmComment,Me.ClmRole,Me.ClmTime})

			Me.LstComments.GridLines = true

			Me.LstComments.Location = new System.Drawing.Point(16, 88)

			Me.LstComments.Name = "LstComments"

			Me.LstComments.Size = new System.Drawing.Size(520, 240)

			Me.LstComments.TabIndex = 13

			Me.LstComments.View = System.Windows.Forms.View.Details

			' 

			' ClmUser

			' 

			Me.ClmUser.Text = "Commenting User"

			Me.ClmUser.Width = 100

			' 

			' ClmScore

			' 

			Me.ClmScore.Text = "Score"

			Me.ClmScore.Width = 56

			' 

			' ClmItemId

			' 

			Me.ClmItemId.Text = "Item Id"

			Me.ClmItemId.Width = 61

			' 

			' ClmType

			' 

			Me.ClmType.Text = "Type"

			Me.ClmType.Width = 53

			' 

			' ClmComment

			' 

			Me.ClmComment.Text = "Comment"

			Me.ClmComment.Width = 86

			' 

			' ClmRole

			' 

			Me.ClmRole.Text = "Role"

			' 

			' ClmTime

			' 

			Me.ClmTime.Text = "Time"

			Me.ClmTime.Width = 95

			' 

			' LblUserId

			' 

			Me.LblUserId.Location = new System.Drawing.Point(176, 8)

			Me.LblUserId.Name = "LblUserId"

			Me.LblUserId.Size = new System.Drawing.Size(64, 23)

			Me.LblUserId.TabIndex = 13

			Me.LblUserId.Text = "User Id:"

			' 

			' TxtUserId

			' 

			Me.TxtUserId.Location = new System.Drawing.Point(240, 8)

			Me.TxtUserId.Name = "TxtUserId"

			Me.TxtUserId.Size = new System.Drawing.Size(104, 20)

			Me.TxtUserId.TabIndex = 14

			Me.TxtUserId.Text = ""

			' 

			' FrmGetFeedback

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(560, 413)

			Me.Controls.Add(Me.TxtUserId)

			Me.Controls.Add(Me.LblUserId)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetFeedback)

			Me.Name = "FrmGetFeedback"

			Me.Text = "GetFeedback"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)

   End Sub

#End Region


    Public Context As ApiContext


    Private Sub BtnGetFeedback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetFeedback.Click

        Try

            TxtPositive.Text = ""

            TxtNegative.Text = ""

            TxtScore.Text = ""

            LstComments.Items.Clear()

            Dim apicall As GetFeedbackCall = New GetFeedbackCall(Context)

            apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

            Dim feedbacks As FeedbackDetailTypeCollection = apicall.GetFeedback(TxtUserId.Text)

            If Not apicall.FeedbackSummary Is Nothing Then

                TxtPositive.Text = apicall.FeedbackSummary.UniquePositiveFeedbackCount.ToString()

                TxtNegative.Text = apicall.FeedbackSummary.UniqueNegativeFeedbackCount.ToString()

                TxtScore.Text = apicall.FeedbackScore.ToString()

            End If

            Dim feedback As FeedbackDetailType

            For Each feedback In feedbacks
                Dim listparams(7) As String

                listparams(0) = feedback.CommentingUser

                listparams(1) = feedback.CommentingUserScore.ToString()

                listparams(2) = feedback.ItemID

                listparams(3) = feedback.CommentType.ToString()

                listparams(4) = feedback.CommentText

                listparams(5) = feedback.Role.ToString()

                listparams(6) = feedback.CommentTime.ToString()

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstComments.Items.Add(vi)
            Next feedback

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class


