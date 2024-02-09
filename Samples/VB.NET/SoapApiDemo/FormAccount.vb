Imports System
Imports System.Xml
Imports System.Configuration.ConfigurationSettings
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormAccount
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
        If  disposing Then
            If  Not (components Is Nothing) Then
                components.Dispose()
            End If 
        End If 
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Friend WithEvents BtnContinue As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents GrpUrl As System.Windows.Forms.GroupBox
    Friend WithEvents LblUrl As System.Windows.Forms.Label
    Friend WithEvents TxtUrl As System.Windows.Forms.TextBox
    Friend WithEvents GrpAccountAuth As System.Windows.Forms.GroupBox
    Friend WithEvents GrpProgramAuth As System.Windows.Forms.GroupBox
    Friend WithEvents LblDeveloper As System.Windows.Forms.Label
    Friend WithEvents LblApplication As System.Windows.Forms.Label
    Friend WithEvents TxtApplication As System.Windows.Forms.TextBox
    Friend WithEvents TxtDeveloper As System.Windows.Forms.TextBox


    Friend WithEvents TabSettings As System.Windows.Forms.TabControl
    Friend WithEvents TabPageCredentials As System.Windows.Forms.TabPage
    Friend WithEvents TabPageToken As System.Windows.Forms.TabPage
    Friend WithEvents LblToken As System.Windows.Forms.Label
    Friend WithEvents BtnGenerateSID As System.Windows.Forms.Button
    Friend WithEvents LblThree As System.Windows.Forms.Label
    Friend WithEvents LblOne As System.Windows.Forms.Label
    Friend WithEvents BtnLaunchBrowserWithSecret As System.Windows.Forms.Button
    'Friend WithEvents TxtSessionID As System.Windows.Forms.TextBox
    Friend WithEvents LblSessionID As System.Windows.Forms.Label
    Friend WithEvents LblRuInstruct As System.Windows.Forms.Label
    Friend WithEvents LblSidLength As System.Windows.Forms.Label
    Friend WithEvents LblTwo As System.Windows.Forms.Label
    Friend WithEvents GrpFetchToken As System.Windows.Forms.GroupBox
    Friend WithEvents LblFetch As System.Windows.Forms.Label
    Friend WithEvents BtnFetchToken As System.Windows.Forms.Button
    Friend WithEvents TxtToken As System.Windows.Forms.TextBox
    Friend WithEvents LblSignInUrl As System.Windows.Forms.Label
    Friend WithEvents TxtSignInUrl As System.Windows.Forms.TextBox
    Friend WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
		Friend WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader 




























		Friend WithEvents LblEPSUrl As System.Windows.Forms.Label 
		Friend WithEvents TxtEPSUrl As System.Windows.Forms.TextBox 
		Friend WithEvents GrpLogging As System.Windows.Forms.GroupBox 
		Friend WithEvents ChkEnableLog As System.Windows.Forms.CheckBox 
		Friend WithEvents ChkLogMessages As System.Windows.Forms.CheckBox 
		Friend WithEvents ChkLogExceptions As System.Windows.Forms.CheckBox 
		Friend WithEvents label1 As System.Windows.Forms.Label 
		Friend WithEvents TxtLogFile As System.Windows.Forms.TextBox 
		Friend WithEvents BtnLogFile As System.Windows.Forms.Button 
		Friend WithEvents DlgSaveLog As System.Windows.Forms.SaveFileDialog 
		Friend WithEvents TabOther As System.Windows.Forms.TabPage 
		Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox 
		Friend WithEvents LblSite As System.Windows.Forms.Label 
		Friend WithEvents LblVersion As System.Windows.Forms.Label 
		Friend WithEvents LblTimeOut As System.Windows.Forms.Label 
		Friend WithEvents LblLanguage As System.Windows.Forms.Label 
		Friend WithEvents TxtVersion As System.Windows.Forms.TextBox 
		Friend WithEvents TxtTimeOut As System.Windows.Forms.TextBox 
		Friend WithEvents CboLanguage As System.Windows.Forms.ComboBox 
		Friend WithEvents CboSite As System.Windows.Forms.ComboBox 
    Friend WithEvents TxtCertificate As System.Windows.Forms.TextBox
    Friend WithEvents LblCertificate As System.Windows.Forms.Label
    Friend WithEvents TxtSessionID As System.Windows.Forms.TextBox
    Friend WithEvents BtnAddRuName As System.Windows.Forms.Button
    Friend WithEvents BtnEditRuName As System.Windows.Forms.Button
    Friend WithEvents BtnDeleteRuName As System.Windows.Forms.Button
    Friend WithEvents ClmTokenEdit As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmRejEdit As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmAccEdit As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmNameEdit As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListRuNamesEdit As System.Windows.Forms.ListView
    Friend WithEvents CboMethodEdit As System.Windows.Forms.ComboBox
    Friend WithEvents BtnRuNameCancelEdit As System.Windows.Forms.Button
    Friend WithEvents BtnRuNameOkEdit As System.Windows.Forms.Button
    Friend WithEvents BtnGenerateRuName As System.Windows.Forms.Button
    Friend WithEvents LblRetrievalEdit As System.Windows.Forms.Label
    Friend WithEvents TxtDisplayNameEdit As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayEdit As System.Windows.Forms.Label
    Friend WithEvents TxtPrivacyUrlEdit As System.Windows.Forms.TextBox
    Friend WithEvents LblPrivacyEdit As System.Windows.Forms.Label
    Friend WithEvents LblRuNameEdit As System.Windows.Forms.Label
    Friend WithEvents TxtAcceptUrlEdit As System.Windows.Forms.TextBox
    Friend WithEvents LblAcceptUrlEdit As System.Windows.Forms.Label
    Friend WithEvents LblRejectUrlEdit As System.Windows.Forms.Label
    Friend WithEvents TxtRejectUrlEdit As System.Windows.Forms.TextBox
    Friend WithEvents TxtRuNameEdit As System.Windows.Forms.TextBox
    Friend WithEvents TxtRuleName As System.Windows.Forms.TextBox

		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnContinue = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.TabSettings = New System.Windows.Forms.TabControl
        Me.TabPageCredentials = New System.Windows.Forms.TabPage
        Me.GrpUrl = New System.Windows.Forms.GroupBox
        Me.LblEPSUrl = New System.Windows.Forms.Label
        Me.TxtEPSUrl = New System.Windows.Forms.TextBox
        Me.LblSignInUrl = New System.Windows.Forms.Label
        Me.TxtSignInUrl = New System.Windows.Forms.TextBox
        Me.LblUrl = New System.Windows.Forms.Label
        Me.TxtUrl = New System.Windows.Forms.TextBox
        Me.GrpAccountAuth = New System.Windows.Forms.GroupBox
        Me.TxtToken = New System.Windows.Forms.TextBox
        Me.LblToken = New System.Windows.Forms.Label
        Me.GrpProgramAuth = New System.Windows.Forms.GroupBox
        Me.LblDeveloper = New System.Windows.Forms.Label
        Me.LblApplication = New System.Windows.Forms.Label
        Me.TxtApplication = New System.Windows.Forms.TextBox
        Me.TxtDeveloper = New System.Windows.Forms.TextBox
        Me.TxtCertificate = New System.Windows.Forms.TextBox
        Me.LblCertificate = New System.Windows.Forms.Label
        Me.TabOther = New System.Windows.Forms.TabPage
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.CboSite = New System.Windows.Forms.ComboBox
        Me.CboLanguage = New System.Windows.Forms.ComboBox
        Me.TxtTimeOut = New System.Windows.Forms.TextBox
        Me.LblTimeOut = New System.Windows.Forms.Label
        Me.LblSite = New System.Windows.Forms.Label
        Me.LblLanguage = New System.Windows.Forms.Label
        Me.TxtVersion = New System.Windows.Forms.TextBox
        Me.LblVersion = New System.Windows.Forms.Label
        Me.GrpLogging = New System.Windows.Forms.GroupBox
        Me.label1 = New System.Windows.Forms.Label
        Me.BtnLogFile = New System.Windows.Forms.Button
        Me.TxtLogFile = New System.Windows.Forms.TextBox
        Me.ChkLogExceptions = New System.Windows.Forms.CheckBox
        Me.ChkLogMessages = New System.Windows.Forms.CheckBox
        Me.ChkEnableLog = New System.Windows.Forms.CheckBox
        Me.TabPageToken = New System.Windows.Forms.TabPage
        Me.GrpFetchToken = New System.Windows.Forms.GroupBox
        Me.BtnFetchToken = New System.Windows.Forms.Button
        Me.LblTwo = New System.Windows.Forms.Label
        Me.BtnGenerateSID = New System.Windows.Forms.Button
        Me.LblThree = New System.Windows.Forms.Label
        Me.LblFetch = New System.Windows.Forms.Label
        Me.LblOne = New System.Windows.Forms.Label
        Me.BtnLaunchBrowserWithSecret = New System.Windows.Forms.Button
        Me.TxtSessionID = New System.Windows.Forms.TextBox
        Me.LblSessionID = New System.Windows.Forms.Label
        Me.LblRuInstruct = New System.Windows.Forms.Label
        Me.LblSidLength = New System.Windows.Forms.Label
        Me.TxtRuleName = New System.Windows.Forms.TextBox
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.DlgSaveLog = New System.Windows.Forms.SaveFileDialog
        Me.BtnAddRuName = New System.Windows.Forms.Button
        Me.BtnEditRuName = New System.Windows.Forms.Button
        Me.BtnDeleteRuName = New System.Windows.Forms.Button
        Me.ClmTokenEdit = New System.Windows.Forms.ColumnHeader
        Me.ClmRejEdit = New System.Windows.Forms.ColumnHeader
        Me.ClmAccEdit = New System.Windows.Forms.ColumnHeader
        Me.ClmNameEdit = New System.Windows.Forms.ColumnHeader
        Me.ListRuNamesEdit = New System.Windows.Forms.ListView
        Me.CboMethodEdit = New System.Windows.Forms.ComboBox
        Me.BtnRuNameCancelEdit = New System.Windows.Forms.Button
        Me.BtnRuNameOkEdit = New System.Windows.Forms.Button
        Me.BtnGenerateRuName = New System.Windows.Forms.Button
        Me.LblRetrievalEdit = New System.Windows.Forms.Label
        Me.TxtDisplayNameEdit = New System.Windows.Forms.TextBox
        Me.LblDisplayEdit = New System.Windows.Forms.Label
        Me.TxtPrivacyUrlEdit = New System.Windows.Forms.TextBox
        Me.LblPrivacyEdit = New System.Windows.Forms.Label
        Me.LblRuNameEdit = New System.Windows.Forms.Label
        Me.TxtAcceptUrlEdit = New System.Windows.Forms.TextBox
        Me.LblAcceptUrlEdit = New System.Windows.Forms.Label
        Me.LblRejectUrlEdit = New System.Windows.Forms.Label
        Me.TxtRejectUrlEdit = New System.Windows.Forms.TextBox
        Me.TxtRuNameEdit = New System.Windows.Forms.TextBox
        Me.TabSettings.SuspendLayout()
        Me.TabPageCredentials.SuspendLayout()
        Me.GrpUrl.SuspendLayout()
        Me.GrpAccountAuth.SuspendLayout()
        Me.GrpProgramAuth.SuspendLayout()
        Me.TabOther.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.GrpLogging.SuspendLayout()
        Me.TabPageToken.SuspendLayout()
        Me.GrpFetchToken.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnContinue
        '
        Me.BtnContinue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnContinue.Location = New System.Drawing.Point(176, 448)
        Me.BtnContinue.Name = "BtnContinue"
        Me.BtnContinue.Size = New System.Drawing.Size(88, 25)
        Me.BtnContinue.TabIndex = 38
        Me.BtnContinue.Text = "Continue"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(280, 448)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(88, 25)
        Me.BtnCancel.TabIndex = 39
        Me.BtnCancel.Text = "Cancel"
        '
        'TabSettings
        '
        Me.TabSettings.Controls.Add(Me.TabPageCredentials)
        Me.TabSettings.Controls.Add(Me.TabOther)
        Me.TabSettings.Controls.Add(Me.TabPageToken)
        Me.TabSettings.Location = New System.Drawing.Point(8, 8)
        Me.TabSettings.Name = "TabSettings"
        Me.TabSettings.SelectedIndex = 0
        Me.TabSettings.Size = New System.Drawing.Size(360, 432)
        Me.TabSettings.TabIndex = 40
        '
        'TabPageCredentials
        '
        Me.TabPageCredentials.Controls.Add(Me.GrpUrl)
        Me.TabPageCredentials.Controls.Add(Me.GrpAccountAuth)
        Me.TabPageCredentials.Controls.Add(Me.GrpProgramAuth)
        Me.TabPageCredentials.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCredentials.Name = "TabPageCredentials"
        Me.TabPageCredentials.Size = New System.Drawing.Size(352, 406)
        Me.TabPageCredentials.TabIndex = 0
        Me.TabPageCredentials.Text = "Credentials"
        '
        'GrpUrl
        '
        Me.GrpUrl.Controls.Add(Me.LblEPSUrl)
        Me.GrpUrl.Controls.Add(Me.TxtEPSUrl)
        Me.GrpUrl.Controls.Add(Me.LblSignInUrl)
        Me.GrpUrl.Controls.Add(Me.TxtSignInUrl)
        Me.GrpUrl.Controls.Add(Me.LblUrl)
        Me.GrpUrl.Controls.Add(Me.TxtUrl)
        Me.GrpUrl.Location = New System.Drawing.Point(16, 296)
        Me.GrpUrl.Name = "GrpUrl"
        Me.GrpUrl.Size = New System.Drawing.Size(328, 104)
        Me.GrpUrl.TabIndex = 44
        Me.GrpUrl.TabStop = False
        Me.GrpUrl.Text = "Urls to make eBay API Call to:"
        '
        'LblEPSUrl
        '
        Me.LblEPSUrl.Location = New System.Drawing.Point(24, 72)
        Me.LblEPSUrl.Name = "LblEPSUrl"
        Me.LblEPSUrl.Size = New System.Drawing.Size(104, 19)
        Me.LblEPSUrl.TabIndex = 29
        Me.LblEPSUrl.Text = "EPS Url:"
        '
        'TxtEPSUrl
        '
        Me.TxtEPSUrl.Location = New System.Drawing.Point(128, 72)
        Me.TxtEPSUrl.Name = "TxtEPSUrl"
        Me.TxtEPSUrl.Size = New System.Drawing.Size(178, 20)
        Me.TxtEPSUrl.TabIndex = 28
        Me.TxtEPSUrl.Text = ""
        '
        'LblSignInUrl
        '
        Me.LblSignInUrl.Location = New System.Drawing.Point(24, 48)
        Me.LblSignInUrl.Name = "LblSignInUrl"
        Me.LblSignInUrl.Size = New System.Drawing.Size(104, 19)
        Me.LblSignInUrl.TabIndex = 27
        Me.LblSignInUrl.Text = "Sign-In Url:"
        '
        'TxtSignInUrl
        '
        Me.TxtSignInUrl.Location = New System.Drawing.Point(128, 48)
        Me.TxtSignInUrl.Name = "TxtSignInUrl"
        Me.TxtSignInUrl.Size = New System.Drawing.Size(178, 20)
        Me.TxtSignInUrl.TabIndex = 26
        Me.TxtSignInUrl.Text = ""
        '
        'LblUrl
        '
        Me.LblUrl.Location = New System.Drawing.Point(24, 24)
        Me.LblUrl.Name = "LblUrl"
        Me.LblUrl.Size = New System.Drawing.Size(104, 19)
        Me.LblUrl.TabIndex = 25
        Me.LblUrl.Text = "API Server Url:"
        '
        'TxtUrl
        '
        Me.TxtUrl.Location = New System.Drawing.Point(128, 24)
        Me.TxtUrl.Name = "TxtUrl"
        Me.TxtUrl.Size = New System.Drawing.Size(178, 20)
        Me.TxtUrl.TabIndex = 0
        Me.TxtUrl.Text = ""
        '
        'GrpAccountAuth
        '
        Me.GrpAccountAuth.Controls.Add(Me.TxtToken)
        Me.GrpAccountAuth.Controls.Add(Me.LblToken)
        Me.GrpAccountAuth.Location = New System.Drawing.Point(16, 128)
        Me.GrpAccountAuth.Name = "GrpAccountAuth"
        Me.GrpAccountAuth.Size = New System.Drawing.Size(328, 160)
        Me.GrpAccountAuth.TabIndex = 43
        Me.GrpAccountAuth.TabStop = False
        Me.GrpAccountAuth.Text = "eBay Seller Account:"
        '
        'TxtToken
        '
        Me.TxtToken.Location = New System.Drawing.Point(32, 40)
        Me.TxtToken.Multiline = True
        Me.TxtToken.Name = "TxtToken"
        Me.TxtToken.Size = New System.Drawing.Size(272, 112)
        Me.TxtToken.TabIndex = 45
        Me.TxtToken.Text = ""
        '
        'LblToken
        '
        Me.LblToken.Location = New System.Drawing.Point(16, 24)
        Me.LblToken.Name = "LblToken"
        Me.LblToken.Size = New System.Drawing.Size(100, 16)
        Me.LblToken.TabIndex = 44
        Me.LblToken.Text = "Token:"
        '
        'GrpProgramAuth
        '
        Me.GrpProgramAuth.Controls.Add(Me.LblDeveloper)
        Me.GrpProgramAuth.Controls.Add(Me.LblApplication)
        Me.GrpProgramAuth.Controls.Add(Me.TxtApplication)
        Me.GrpProgramAuth.Controls.Add(Me.TxtDeveloper)
        Me.GrpProgramAuth.Controls.Add(Me.TxtCertificate)
        Me.GrpProgramAuth.Controls.Add(Me.LblCertificate)
        Me.GrpProgramAuth.Location = New System.Drawing.Point(16, 16)
        Me.GrpProgramAuth.Name = "GrpProgramAuth"
        Me.GrpProgramAuth.Size = New System.Drawing.Size(328, 104)
        Me.GrpProgramAuth.TabIndex = 41
        Me.GrpProgramAuth.TabStop = False
        Me.GrpProgramAuth.Text = "API CertIf icate"
        '
        'LblDeveloper
        '
        Me.LblDeveloper.Location = New System.Drawing.Point(16, 25)
        Me.LblDeveloper.Name = "LblDeveloper"
        Me.LblDeveloper.Size = New System.Drawing.Size(112, 19)
        Me.LblDeveloper.TabIndex = 18
        Me.LblDeveloper.Text = "Developer:"
        '
        'LblApplication
        '
        Me.LblApplication.Location = New System.Drawing.Point(16, 49)
        Me.LblApplication.Name = "LblApplication"
        Me.LblApplication.Size = New System.Drawing.Size(112, 19)
        Me.LblApplication.TabIndex = 20
        Me.LblApplication.Text = "Application:"
        '
        'TxtApplication
        '
        Me.TxtApplication.Location = New System.Drawing.Point(128, 48)
        Me.TxtApplication.Name = "TxtApplication"
        Me.TxtApplication.Size = New System.Drawing.Size(178, 20)
        Me.TxtApplication.TabIndex = 1
        Me.TxtApplication.Text = ""
        '
        'TxtDeveloper
        '
        Me.TxtDeveloper.Location = New System.Drawing.Point(128, 24)
        Me.TxtDeveloper.Name = "TxtDeveloper"
        Me.TxtDeveloper.Size = New System.Drawing.Size(178, 20)
        Me.TxtDeveloper.TabIndex = 0
        Me.TxtDeveloper.Text = ""
        '
        'TxtCertificate
        '
        Me.TxtCertificate.Location = New System.Drawing.Point(128, 72)
        Me.TxtCertificate.Name = "TxtCertificate"
        Me.TxtCertificate.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TxtCertificate.Size = New System.Drawing.Size(178, 20)
        Me.TxtCertificate.TabIndex = 2
        Me.TxtCertificate.Text = ""
        '
        'LblCertificate
        '
        Me.LblCertificate.Location = New System.Drawing.Point(16, 73)
        Me.LblCertificate.Name = "LblCertificate"
        Me.LblCertificate.Size = New System.Drawing.Size(112, 19)
        Me.LblCertificate.TabIndex = 22
        Me.LblCertificate.Text = "Certificate:"
        '
        'TabOther
        '
        Me.TabOther.Controls.Add(Me.groupBox1)
        Me.TabOther.Controls.Add(Me.GrpLogging)
        Me.TabOther.Location = New System.Drawing.Point(4, 22)
        Me.TabOther.Name = "TabOther"
        Me.TabOther.Size = New System.Drawing.Size(352, 406)
        Me.TabOther.TabIndex = 3
        Me.TabOther.Text = "Other"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.CboSite)
        Me.groupBox1.Controls.Add(Me.CboLanguage)
        Me.groupBox1.Controls.Add(Me.TxtTimeOut)
        Me.groupBox1.Controls.Add(Me.LblTimeOut)
        Me.groupBox1.Controls.Add(Me.LblSite)
        Me.groupBox1.Controls.Add(Me.LblLanguage)
        Me.groupBox1.Controls.Add(Me.TxtVersion)
        Me.groupBox1.Controls.Add(Me.LblVersion)
        Me.groupBox1.Location = New System.Drawing.Point(8, 208)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(336, 128)
        Me.groupBox1.TabIndex = 42
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "API CertIf icate"
        '
        'CboSite
        '
        Me.CboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSite.Location = New System.Drawing.Point(128, 24)
        Me.CboSite.Name = "CboSite"
        Me.CboSite.Size = New System.Drawing.Size(176, 21)
        Me.CboSite.TabIndex = 57
        '
        'CboLanguage
        '
        Me.CboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLanguage.Location = New System.Drawing.Point(128, 48)
        Me.CboLanguage.Name = "CboLanguage"
        Me.CboLanguage.Size = New System.Drawing.Size(176, 21)
        Me.CboLanguage.TabIndex = 56
        '
        'TxtTimeOut
        '
        Me.TxtTimeOut.Location = New System.Drawing.Point(128, 96)
        Me.TxtTimeOut.Name = "TxtTimeOut"
        Me.TxtTimeOut.Size = New System.Drawing.Size(178, 20)
        Me.TxtTimeOut.TabIndex = 23
        Me.TxtTimeOut.Text = ""
        '
        'LblTimeOut
        '
        Me.LblTimeOut.Location = New System.Drawing.Point(16, 96)
        Me.LblTimeOut.Name = "LblTimeOut"
        Me.LblTimeOut.Size = New System.Drawing.Size(112, 16)
        Me.LblTimeOut.TabIndex = 24
        Me.LblTimeOut.Text = "Timeout (ms):"
        '
        'LblSite
        '
        Me.LblSite.Location = New System.Drawing.Point(16, 24)
        Me.LblSite.Name = "LblSite"
        Me.LblSite.Size = New System.Drawing.Size(112, 16)
        Me.LblSite.TabIndex = 18
        Me.LblSite.Text = "Site:"
        '
        'LblLanguage
        '
        Me.LblLanguage.Location = New System.Drawing.Point(16, 48)
        Me.LblLanguage.Name = "LblLanguage"
        Me.LblLanguage.Size = New System.Drawing.Size(112, 16)
        Me.LblLanguage.TabIndex = 20
        Me.LblLanguage.Text = "Error Language:"
        '
        'TxtVersion
        '
        Me.TxtVersion.Location = New System.Drawing.Point(128, 72)
        Me.TxtVersion.Name = "TxtVersion"
        Me.TxtVersion.Size = New System.Drawing.Size(178, 20)
        Me.TxtVersion.TabIndex = 2
        Me.TxtVersion.Text = ""
        '
        'LblVersion
        '
        Me.LblVersion.Location = New System.Drawing.Point(16, 72)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(112, 16)
        Me.LblVersion.TabIndex = 22
        Me.LblVersion.Text = "Version:"
        '
        'GrpLogging
        '
        Me.GrpLogging.Controls.Add(Me.label1)
        Me.GrpLogging.Controls.Add(Me.BtnLogFile)
        Me.GrpLogging.Controls.Add(Me.TxtLogFile)
        Me.GrpLogging.Controls.Add(Me.ChkLogExceptions)
        Me.GrpLogging.Controls.Add(Me.ChkLogMessages)
        Me.GrpLogging.Controls.Add(Me.ChkEnableLog)
        Me.GrpLogging.Location = New System.Drawing.Point(8, 8)
        Me.GrpLogging.Name = "GrpLogging"
        Me.GrpLogging.Size = New System.Drawing.Size(336, 192)
        Me.GrpLogging.TabIndex = 0
        Me.GrpLogging.TabStop = False
        Me.GrpLogging.Text = "Configure Logging"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 96)
        Me.label1.Name = "label1"
        Me.label1.TabIndex = 64
        Me.label1.Text = "Log File"
        '
        'BtnLogFile
        '
        Me.BtnLogFile.Location = New System.Drawing.Point(216, 152)
        Me.BtnLogFile.Name = "BtnLogFile"
        Me.BtnLogFile.Size = New System.Drawing.Size(112, 23)
        Me.BtnLogFile.TabIndex = 63
        Me.BtnLogFile.Text = "Browse"
        '
        'TxtLogFile
        '
        Me.TxtLogFile.Location = New System.Drawing.Point(16, 120)
        Me.TxtLogFile.Name = "TxtLogFile"
        Me.TxtLogFile.Size = New System.Drawing.Size(312, 20)
        Me.TxtLogFile.TabIndex = 3
        Me.TxtLogFile.Text = "Log.txt"
        '
        'ChkLogExceptions
        '
        Me.ChkLogExceptions.Location = New System.Drawing.Point(40, 72)
        Me.ChkLogExceptions.Name = "ChkLogExceptions"
        Me.ChkLogExceptions.TabIndex = 2
        Me.ChkLogExceptions.Text = "Log Exceptions"
        '
        'ChkLogMessages
        '
        Me.ChkLogMessages.Location = New System.Drawing.Point(40, 48)
        Me.ChkLogMessages.Name = "ChkLogMessages"
        Me.ChkLogMessages.TabIndex = 1
        Me.ChkLogMessages.Text = "Log Messages"
        '
        'ChkEnableLog
        '
        Me.ChkEnableLog.Checked = True
        Me.ChkEnableLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEnableLog.Location = New System.Drawing.Point(16, 24)
        Me.ChkEnableLog.Name = "ChkEnableLog"
        Me.ChkEnableLog.TabIndex = 0
        Me.ChkEnableLog.Text = "Enable Logging"
        '
        'TabPageToken
        '
        Me.TabPageToken.Controls.Add(Me.GrpFetchToken)
        Me.TabPageToken.Location = New System.Drawing.Point(4, 22)
        Me.TabPageToken.Name = "TabPageToken"
        Me.TabPageToken.Size = New System.Drawing.Size(352, 406)
        Me.TabPageToken.TabIndex = 1
        Me.TabPageToken.Text = "Token"
        '
        'GrpFetchToken
        '
        Me.GrpFetchToken.Controls.Add(Me.BtnFetchToken)
        Me.GrpFetchToken.Controls.Add(Me.LblTwo)
        Me.GrpFetchToken.Controls.Add(Me.BtnGenerateSID)
        Me.GrpFetchToken.Controls.Add(Me.LblThree)
        Me.GrpFetchToken.Controls.Add(Me.LblFetch)
        Me.GrpFetchToken.Controls.Add(Me.LblOne)
        Me.GrpFetchToken.Controls.Add(Me.BtnLaunchBrowserWithSecret)
        Me.GrpFetchToken.Controls.Add(Me.TxtSessionID)
        Me.GrpFetchToken.Controls.Add(Me.LblSessionID)
        Me.GrpFetchToken.Controls.Add(Me.LblRuInstruct)
        Me.GrpFetchToken.Controls.Add(Me.LblSidLength)
        Me.GrpFetchToken.Controls.Add(Me.TxtRuleName)
        Me.GrpFetchToken.Location = New System.Drawing.Point(8, 8)
        Me.GrpFetchToken.Name = "GrpFetchToken"
        Me.GrpFetchToken.Size = New System.Drawing.Size(336, 256)
        Me.GrpFetchToken.TabIndex = 58
        Me.GrpFetchToken.TabStop = False
        Me.GrpFetchToken.Text = "Fetch Token"
        '
        'BtnFetchToken
        '
        Me.BtnFetchToken.Location = New System.Drawing.Point(104, 216)
        Me.BtnFetchToken.Name = "BtnFetchToken"
        Me.BtnFetchToken.Size = New System.Drawing.Size(88, 24)
        Me.BtnFetchToken.TabIndex = 70
        Me.BtnFetchToken.Text = "Fetch Token"
        '
        'LblTwo
        '
        Me.LblTwo.Location = New System.Drawing.Point(16, 88)
        Me.LblTwo.Name = "LblTwo"
        Me.LblTwo.Size = New System.Drawing.Size(21, 16)
        Me.LblTwo.TabIndex = 68
        Me.LblTwo.Text = "2)"
        Me.LblTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnGenerateSID
        '
        Me.BtnGenerateSID.Location = New System.Drawing.Point(208, 136)
        Me.BtnGenerateSID.Name = "BtnGenerateSID"
        Me.BtnGenerateSID.Size = New System.Drawing.Size(64, 23)
        Me.BtnGenerateSID.TabIndex = 61
        Me.BtnGenerateSID.Text = "Retrieve"
        '
        'LblThree
        '
        Me.LblThree.Location = New System.Drawing.Point(16, 224)
        Me.LblThree.Name = "LblThree"
        Me.LblThree.Size = New System.Drawing.Size(21, 16)
        Me.LblThree.TabIndex = 66
        Me.LblThree.Text = "3)"
        Me.LblThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblFetch
        '
        Me.LblFetch.Location = New System.Drawing.Point(40, 224)
        Me.LblFetch.Name = "LblFetch"
        Me.LblFetch.Size = New System.Drawing.Size(40, 16)
        Me.LblFetch.TabIndex = 67
        Me.LblFetch.Text = "Click"
        '
        'LblOne
        '
        Me.LblOne.Location = New System.Drawing.Point(16, 24)
        Me.LblOne.Name = "LblOne"
        Me.LblOne.Size = New System.Drawing.Size(21, 16)
        Me.LblOne.TabIndex = 57
        Me.LblOne.Text = "1)"
        Me.LblOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnLaunchBrowserWithSecret
        '
        Me.BtnLaunchBrowserWithSecret.Location = New System.Drawing.Point(104, 176)
        Me.BtnLaunchBrowserWithSecret.Name = "BtnLaunchBrowserWithSecret"
        Me.BtnLaunchBrowserWithSecret.Size = New System.Drawing.Size(88, 23)
        Me.BtnLaunchBrowserWithSecret.TabIndex = 65
        Me.BtnLaunchBrowserWithSecret.Text = "Launch Sign-In"
        '
        'TxtSessionID
        '
        Me.TxtSessionID.Location = New System.Drawing.Point(48, 136)
        Me.TxtSessionID.Name = "TxtSessionID"
        Me.TxtSessionID.TabIndex = 73
        Me.TxtSessionID.Text = ""
        '
        'LblSessionID
        '
        Me.LblSessionID.Location = New System.Drawing.Point(40, 88)
        Me.LblSessionID.Name = "LblSessionID"
        Me.LblSessionID.Size = New System.Drawing.Size(260, 40)
        Me.LblSessionID.TabIndex = 58
        Me.LblSessionID.Text = "Retrieve a Session ID to be associated with the token to be generated. And launch" & _
        " the Sign-In Page."
        '
        'LblRuInstruct
        '
        Me.LblRuInstruct.Location = New System.Drawing.Point(40, 24)
        Me.LblRuInstruct.Name = "LblRuInstruct"
        Me.LblRuInstruct.Size = New System.Drawing.Size(128, 24)
        Me.LblRuInstruct.TabIndex = 62
        Me.LblRuInstruct.Text = "Please input rulename"
        '
        'LblSidLength
        '
        Me.LblSidLength.Location = New System.Drawing.Point(160, 136)
        Me.LblSidLength.Name = "LblSidLength"
        Me.LblSidLength.Size = New System.Drawing.Size(36, 16)
        Me.LblSidLength.TabIndex = 60
        Me.LblSidLength.Text = "0"
        Me.LblSidLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtRuleName
        '
        Me.TxtRuleName.Location = New System.Drawing.Point(48, 48)
        Me.TxtRuleName.Name = "TxtRuleName"
        Me.TxtRuleName.TabIndex = 73
        Me.TxtRuleName.Text = ""
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "RuName"
        Me.columnHeader1.Width = 132
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "AcceptURL"
        Me.columnHeader2.Width = 75
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "RejectURL"
        Me.columnHeader3.Width = 84
        '
        'DlgSaveLog
        '
        Me.DlgSaveLog.DefaultExt = "txt"
        Me.DlgSaveLog.OverwritePrompt = False
        '
        'BtnAddRuName
        '
        Me.BtnAddRuName.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnAddRuName.Location = New System.Drawing.Point(8, 136)
        Me.BtnAddRuName.Name = "BtnAddRuName"
        Me.BtnAddRuName.Size = New System.Drawing.Size(64, 23)
        Me.BtnAddRuName.TabIndex = 80
        Me.BtnAddRuName.Text = "Add"
        '
        'BtnEditRuName
        '
        Me.BtnEditRuName.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnEditRuName.Location = New System.Drawing.Point(80, 136)
        Me.BtnEditRuName.Name = "BtnEditRuName"
        Me.BtnEditRuName.Size = New System.Drawing.Size(64, 23)
        Me.BtnEditRuName.TabIndex = 79
        Me.BtnEditRuName.Text = "Edit"
        '
        'BtnDeleteRuName
        '
        Me.BtnDeleteRuName.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnDeleteRuName.Location = New System.Drawing.Point(152, 136)
        Me.BtnDeleteRuName.Name = "BtnDeleteRuName"
        Me.BtnDeleteRuName.Size = New System.Drawing.Size(64, 23)
        Me.BtnDeleteRuName.TabIndex = 78
        Me.BtnDeleteRuName.Text = "Delete"
        '
        'ClmTokenEdit
        '
        Me.ClmTokenEdit.Text = "TokenReturnMethod"
        Me.ClmTokenEdit.Width = 80
        '
        'ClmRejEdit
        '
        Me.ClmRejEdit.Text = "RejectURL"
        Me.ClmRejEdit.Width = 75
        '
        'ClmAccEdit
        '
        Me.ClmAccEdit.Text = "AcceptURL"
        Me.ClmAccEdit.Width = 75
        '
        'ClmNameEdit
        '
        Me.ClmNameEdit.Text = "RuName"
        Me.ClmNameEdit.Width = 80
        '
        'ListRuNamesEdit
        '
        Me.ListRuNamesEdit.FullRowSelect = True
        Me.ListRuNamesEdit.HideSelection = False
        Me.ListRuNamesEdit.Location = New System.Drawing.Point(8, 24)
        Me.ListRuNamesEdit.MultiSelect = False
        Me.ListRuNamesEdit.Name = "ListRuNamesEdit"
        Me.ListRuNamesEdit.Size = New System.Drawing.Size(320, 104)
        Me.ListRuNamesEdit.TabIndex = 77
        Me.ListRuNamesEdit.View = System.Windows.Forms.View.Details
        '
        'CboMethodEdit
        '
        Me.CboMethodEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMethodEdit.Items.AddRange(New Object() {"Redirect", "Fetch Token"})
        Me.CboMethodEdit.Location = New System.Drawing.Point(136, 152)
        Me.CboMethodEdit.Name = "CboMethodEdit"
        Me.CboMethodEdit.Size = New System.Drawing.Size(152, 21)
        Me.CboMethodEdit.TabIndex = 67
        '
        'BtnRuNameCancelEdit
        '
        Me.BtnRuNameCancelEdit.Location = New System.Drawing.Point(240, 184)
        Me.BtnRuNameCancelEdit.Name = "BtnRuNameCancelEdit"
        Me.BtnRuNameCancelEdit.Size = New System.Drawing.Size(72, 23)
        Me.BtnRuNameCancelEdit.TabIndex = 64
        Me.BtnRuNameCancelEdit.Text = "Cancel"
        '
        'BtnRuNameOkEdit
        '
        Me.BtnRuNameOkEdit.Location = New System.Drawing.Point(160, 184)
        Me.BtnRuNameOkEdit.Name = "BtnRuNameOkEdit"
        Me.BtnRuNameOkEdit.Size = New System.Drawing.Size(72, 23)
        Me.BtnRuNameOkEdit.TabIndex = 63
        Me.BtnRuNameOkEdit.Text = "OK"
        '
        'BtnGenerateRuName
        '
        Me.BtnGenerateRuName.Location = New System.Drawing.Point(248, 24)
        Me.BtnGenerateRuName.Name = "BtnGenerateRuName"
        Me.BtnGenerateRuName.Size = New System.Drawing.Size(72, 23)
        Me.BtnGenerateRuName.TabIndex = 62
        Me.BtnGenerateRuName.Text = "Generate"
        '
        'LblRetrievalEdit
        '
        Me.LblRetrievalEdit.Location = New System.Drawing.Point(16, 152)
        Me.LblRetrievalEdit.Name = "LblRetrievalEdit"
        Me.LblRetrievalEdit.Size = New System.Drawing.Size(96, 16)
        Me.LblRetrievalEdit.TabIndex = 24
        Me.LblRetrievalEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDisplayNameEdit
        '
        Me.TxtDisplayNameEdit.Location = New System.Drawing.Point(96, 128)
        Me.TxtDisplayNameEdit.Name = "TxtDisplayNameEdit"
        Me.TxtDisplayNameEdit.Size = New System.Drawing.Size(224, 20)
        Me.TxtDisplayNameEdit.TabIndex = 23
        Me.TxtDisplayNameEdit.Text = ""
        '
        'LblDisplayEdit
        '
        Me.LblDisplayEdit.Location = New System.Drawing.Point(16, 128)
        Me.LblDisplayEdit.Name = "LblDisplayEdit"
        Me.LblDisplayEdit.Size = New System.Drawing.Size(80, 16)
        Me.LblDisplayEdit.TabIndex = 22
        Me.LblDisplayEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPrivacyUrlEdit
        '
        Me.TxtPrivacyUrlEdit.Location = New System.Drawing.Point(96, 104)
        Me.TxtPrivacyUrlEdit.Name = "TxtPrivacyUrlEdit"
        Me.TxtPrivacyUrlEdit.Size = New System.Drawing.Size(224, 20)
        Me.TxtPrivacyUrlEdit.TabIndex = 21
        Me.TxtPrivacyUrlEdit.Text = ""
        '
        'LblPrivacyEdit
        '
        Me.LblPrivacyEdit.Location = New System.Drawing.Point(16, 104)
        Me.LblPrivacyEdit.Name = "LblPrivacyEdit"
        Me.LblPrivacyEdit.Size = New System.Drawing.Size(72, 16)
        Me.LblPrivacyEdit.TabIndex = 20
        Me.LblPrivacyEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRuNameEdit
        '
        Me.LblRuNameEdit.Location = New System.Drawing.Point(16, 24)
        Me.LblRuNameEdit.Name = "LblRuNameEdit"
        Me.LblRuNameEdit.Size = New System.Drawing.Size(72, 23)
        Me.LblRuNameEdit.TabIndex = 11
        Me.LblRuNameEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtAcceptUrlEdit
        '
        Me.TxtAcceptUrlEdit.Location = New System.Drawing.Point(96, 56)
        Me.TxtAcceptUrlEdit.Name = "TxtAcceptUrlEdit"
        Me.TxtAcceptUrlEdit.Size = New System.Drawing.Size(224, 20)
        Me.TxtAcceptUrlEdit.TabIndex = 15
        Me.TxtAcceptUrlEdit.Text = ""
        '
        'LblAcceptUrlEdit
        '
        Me.LblAcceptUrlEdit.Location = New System.Drawing.Point(16, 56)
        Me.LblAcceptUrlEdit.Name = "LblAcceptUrlEdit"
        Me.LblAcceptUrlEdit.Size = New System.Drawing.Size(72, 16)
        Me.LblAcceptUrlEdit.TabIndex = 14
        Me.LblAcceptUrlEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRejectUrlEdit
        '
        Me.LblRejectUrlEdit.Location = New System.Drawing.Point(16, 80)
        Me.LblRejectUrlEdit.Name = "LblRejectUrlEdit"
        Me.LblRejectUrlEdit.Size = New System.Drawing.Size(72, 16)
        Me.LblRejectUrlEdit.TabIndex = 16
        Me.LblRejectUrlEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtRejectUrlEdit
        '
        Me.TxtRejectUrlEdit.Location = New System.Drawing.Point(96, 80)
        Me.TxtRejectUrlEdit.Name = "TxtRejectUrlEdit"
        Me.TxtRejectUrlEdit.Size = New System.Drawing.Size(224, 20)
        Me.TxtRejectUrlEdit.TabIndex = 17
        Me.TxtRejectUrlEdit.Text = ""
        '
        'TxtRuNameEdit
        '
        Me.TxtRuNameEdit.Location = New System.Drawing.Point(96, 24)
        Me.TxtRuNameEdit.Name = "TxtRuNameEdit"
        Me.TxtRuNameEdit.Size = New System.Drawing.Size(144, 20)
        Me.TxtRuNameEdit.TabIndex = 12
        Me.TxtRuNameEdit.Text = ""
        '
        'FormAccount
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 478)
        Me.Controls.Add(Me.TabSettings)
        Me.Controls.Add(Me.BtnContinue)
        Me.Controls.Add(Me.BtnCancel)
        Me.Name = "FormAccount"
        Me.Text = "Account Settings"
        Me.TabSettings.ResumeLayout(False)
        Me.TabPageCredentials.ResumeLayout(False)
        Me.GrpUrl.ResumeLayout(False)
        Me.GrpAccountAuth.ResumeLayout(False)
        Me.GrpProgramAuth.ResumeLayout(False)
        Me.TabOther.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.GrpLogging.ResumeLayout(False)
        Me.TabPageToken.ResumeLayout(False)
        Me.GrpFetchToken.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext
    Private mrunamesretrieved As Boolean = False
    Private mEditing As Boolean = False
    Private mDisplayName As String = ""

		Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
					replaceConfigSettings()
		End Sub

    Private Sub FrmAccount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sites() As String = [Enum].GetNames(GetType(SiteCodeType))
        Dim site As String
        For Each site In sites
            If site <> "CustomCode" Then
                CboSite.Items.Add(site)
            End If
        Next site

        Dim langs() As String = [Enum].GetNames(GetType(ErrorLanguageCodeType))
        Dim lang As String
        For Each lang In langs
            If lang <> "CustomCode" Then
                CboLanguage.Items.Add(lang)
            End If
        Next lang

        CboSite.SelectedIndex = 0
        SetBindings()
    End Sub

    Private Sub BtnGenerateSID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerateSID.Click

        Try

            If Not ValidateApiAccount() Then
                MessageBox.Show("Please fill in Api Account first.")
                Return
            End If

            Dim gsc As GetSessionIDCall = New GetSessionIDCall(Context)
            If TxtRuleName.Text = String.Empty Then
                MsgBox("Please input an RuName!")
                Return
            End If

            'the rule name can be retrived from the app.config file, otherwise the user must input it himself.
            Context.RuName = TxtRuleName.Text
            Dim sessionID As String = gsc.GetSessionID(Context.RuName)
            TxtSessionID.Text = sessionID
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub TxtSessionID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSessionID.TextChanged

        LblSidLength.Text = TxtSessionID.Text.Length.ToString()
    End Sub


    Private Sub BtnFetchToken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFetchToken.Click

        Try
            If (TxtSessionID.Text.Length = 0) Then
                MsgBox("Please retrieve Session ID fisrt, then launch Sign-In, before Fetch Token!")
                Return
            End If
            Dim ftc As FetchTokenCall = New FetchTokenCall(Context)
            Context.ApiCredential.eBayToken = ftc.FetchToken(TxtSessionID.Text)
            Me.TabSettings.SelectedTab = Me.TabPageCredentials
            TxtToken.Text = Context.ApiCredential.eBayToken
            TxtToken.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub BtnLaunchBrowserWithSecret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLaunchBrowserWithSecret.Click

        Try
            If (TxtSessionID.Text.Length = 0) Then
                MsgBox("Please retrieve Session ID fisrt!")
                Return
            End If
            SdkUtility.LaunchSignInPage(Context, TxtSessionID.Text)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub



    Private Sub BtnAddRuName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddRuName.Click


        TxtDisplayNameEdit.Text = mDisplayName
        TxtRuNameEdit.Text = ""
        TxtAcceptUrlEdit.Text = ""
        TxtRejectUrlEdit.Text = ""
        TxtPrivacyUrlEdit.Text = ""

        CboMethodEdit.SelectedIndex = 0

        TxtRuNameEdit.Enabled = True
        BtnGenerateRuName.Visible = True
        CboMethodEdit.SelectedIndex = 0
        mEditing = False
    End Sub


    Private Sub SetBindings()

        TxtDeveloper.DataBindings.Clear()
        TxtApplication.DataBindings.Clear()
        TxtCertificate.DataBindings.Clear()
        TxtUrl.DataBindings.Clear()
        TxtSignInUrl.DataBindings.Clear()
        TxtEPSUrl.DataBindings.Clear()
        TxtVersion.DataBindings.Clear()
        TxtTimeOut.DataBindings.Clear()
        TxtToken.DataBindings.Clear()


        ChkEnableLog.DataBindings.Clear()
        ChkLogExceptions.DataBindings.Clear()
        ChkLogMessages.DataBindings.Clear()
        TxtLogFile.DataBindings.Clear()

        TxtDeveloper.DataBindings.Add("Text", Context.ApiCredential.ApiAccount, "Developer")
        TxtApplication.DataBindings.Add("Text", Context.ApiCredential.ApiAccount, "Application")
        TxtCertificate.DataBindings.Add("Text", Context.ApiCredential.ApiAccount, "Certificate")
        ''TxtUserId.DataBindings.Add("Text", Context.ApiCredential.eBayAccount, "UserName")
        ''TxtPassword.DataBindings.Add("Text", Context.ApiCredential.eBayAccount, "Password")
        TxtToken.DataBindings.Add("Text", Context.ApiCredential, "eBayToken")
        TxtVersion.DataBindings.Add("Text", Context, "Version")
        TxtTimeOut.DataBindings.Add("Text", Context, "Timeout")
        TxtRuleName.DataBindings.Add("Text", Context, "RuleName")


        TxtUrl.DataBindings.Add("Text", Context, "SoapApiServerUrl")
        TxtSignInUrl.DataBindings.Add("Text", Context, "SignInUrl")
        TxtEPSUrl.DataBindings.Add("Text", Context, "EPSServerUrl")

        ChkEnableLog.DataBindings.Add("Checked", Context.ApiLogManager, "EnableLogging")
        ChkLogMessages.DataBindings.Add("Checked", Context.ApiLogManager, "LogApiMessages")
        ChkLogExceptions.DataBindings.Add("Checked", Context.ApiLogManager, "LogExceptions")

        Dim logfile As eBay.Service.Util.FileLogger = Context.ApiLogManager.ApiLoggerList.ItemAt(0)
        TxtLogFile.DataBindings.Add("Text", logfile, "FileName")

    End Sub


    Private Sub ChkEnableLog_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEnableLog.CheckedChanged

        If ChkEnableLog.Checked Then

            ChkLogMessages.Enabled = True
            ChkLogExceptions.Enabled = True
            TxtLogFile.Enabled = True
            BtnLogFile.Enabled = True

        Else

            ChkLogMessages.Enabled = False
            ChkLogExceptions.Enabled = False
            TxtLogFile.Enabled = False
            BtnLogFile.Enabled = False
        End If

    End Sub

    Private Sub BtnLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogFile.Click
        DlgSaveLog.ShowDialog()
    End Sub

    Private Sub DlgSaveLog_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DlgSaveLog.FileOk
        TxtLogFile.Text = DlgSaveLog.FileName
    End Sub

    Private Sub CboSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSite.SelectedIndexChanged
        Context.Site = [Enum].Parse(GetType(SiteCodeType), CboSite.Text)
        Dim lang As ErrorLanguageCodeType = eBay.Service.Util.ErrorLanguageUtility.GetDefaultErrorLanguageCodeType(Context.Site)
        CboLanguage.SelectedIndex = CboLanguage.Items.IndexOf(lang.ToString())
    End Sub

    Private Sub CboLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLanguage.SelectedIndexChanged
        Context.ErrorLanguage = [Enum].Parse(GetType(ErrorLanguageCodeType), CboLanguage.Text)
    End Sub

    Private Sub replaceConfigSettings()

        Dim xDoc As XmlDocument = New XmlDocument

        Dim myDomain As AppDomain = System.AppDomain.CurrentDomain
        Dim sFileName As String = myDomain.SetupInformation.ConfigurationFile
        Dim sDir As String = System.Environment.CurrentDirectory

        Try
            xDoc.Load(sFileName)

            replaceXMLDoc("DevName", Context.ApiCredential.ApiAccount.Developer, xDoc)
            replaceXMLDoc("AppName", Context.ApiCredential.ApiAccount.Application, xDoc)
            replaceXMLDoc("AppCert", Context.ApiCredential.ApiAccount.Certificate, xDoc)
            ''replaceXMLDoc("UserName", Context.ApiCredential.eBayAccount.UserName, xDoc)
            ''replaceXMLDoc("UserPassword", Context.ApiCredential.eBayAccount.Password, xDoc)
            replaceXMLDoc("eBayToken", Context.ApiCredential.eBayToken, xDoc)
            replaceXMLDoc("SoapApiServerUrl", Context.SoapApiServerUrl, xDoc)
            replaceXMLDoc("SignInUrl", Context.SignInUrl, xDoc)
            replaceXMLDoc("EpsServerUrl", Context.EPSServerUrl, xDoc)
            replaceXMLDoc("Version", Context.Version, xDoc)
            replaceXMLDoc("TimeOut", Context.Timeout.ToString(), xDoc)
            Dim logfile As FileLogger = Context.ApiLogManager.ApiLoggerList.ItemAt(0)
            replaceXMLDoc("LogFileName", logfile.FileName, xDoc)

            If (sFileName.StartsWith("file:///")) Then
                sFileName = sFileName.Remove(0, 8)
            End If
            xDoc.Save(sFileName)
            xDoc = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub replaceXMLDoc(ByVal key As String, ByVal val As String, ByVal xDoc As XmlDocument)
        Dim xNode As XmlNode
        For Each xNode In xDoc("configuration")("appSettings")
            If xNode.Name = "add" Then
                If (xNode.Attributes.GetNamedItem("key").Value = key) Then
                    xNode.Attributes.GetNamedItem("value").Value = val
                End If
            End If
        Next

    End Sub

    Private Sub TxtToken_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtToken.TextChanged

    End Sub
End Class
