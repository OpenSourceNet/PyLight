Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub RunF5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunF5ToolStripMenuItem.Click
        Dim objWriter As New System.IO.StreamWriter("C:\PyLightSource\bin-project.py", False)
        objWriter.WriteLine(RichTextBox1.Text)
        objWriter.Close()
        System.Diagnostics.Process.Start("C:\PyLightSource\bin-project.py")
    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Dim dlg As OpenFileDialog = New OpenFileDialog
            dlg.Title = "Open"
            dlg.Filter = "PyLight Files (*.pylf)|*.pylf"
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.LoadFile(dlg.FileName)
            End If
        Catch ex As Exception : End Try
    End Sub
    Private Sub PyLightFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PyLightFileToolStripMenuItem.Click
        Try
            Dim dlg As SaveFileDialog = New SaveFileDialog
            dlg.Title = "Save"
            dlg.Filter = "PyLight Files  (*.pylf)|*.pylf"
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText)
            End If
        Catch ex As Exception : End Try
    End Sub
    Private Sub PythonFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PythonFileToolStripMenuItem.Click
        Form2.Show()
    End Sub
    Private Sub TempToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TempToolStripMenuItem.Click
        System.Diagnostics.Process.Start("C:\PyLightSource")
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Form3.TextBox2.Text = "" Then
            'do nothing
        Else
            If RichTextBox1.Text = "" Then
                End
            Else
                Dim result As Integer = MessageBox.Show("The last run file has been saved to filepath [c:/PyLightSource]", "PyLight", MessageBoxButtons.OK)
                End
            End If
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.password
        Form3.TextBox2.Text = My.Settings.username
        If Form3.TextBox2.Text = "" Then
            MenuStrip1.Visible = False
            MenuStrip2.Visible = True
            RichTextBox1.Enabled = False
            Timer1.Enabled = False
            ToolStripStatusLabel1.Enabled = False
            RichTextBox1.Text = ("Please specify the installation file path for Python before using PyLight." + vbCrLf + "" + vbCrLf + "Please follow the instructions below to specify the installation file path for Python:" + vbCrLf + "" + vbCrLf + "1) Use the menu on the top." + vbCrLf + "2) Click 'Specify Inst Path'" + vbCrLf + "3) Specify the file path. If Python is not installed on this pc, please click the 'Download' button." + vbCrLf + "" + vbCrLf + "Thank you for using PyLight.")
        Else
            ToolStripStatusLabel1.Enabled = True
            Timer1.Enabled = True
            MenuStrip1.Visible = True
            MenuStrip2.Visible = False
            RichTextBox1.Enabled = True
            RichTextBox1.Text = ""
            If (Not System.IO.Directory.Exists("C:\PyLightSource")) Then
                System.IO.Directory.CreateDirectory("C:\PyLightSource")
            End If
        End If
    End Sub
    Private Sub FontToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem1.Click
        Dim result As Integer = MessageBox.Show("Changing font will remove syntax highlighting. Do you wish to continue?", "PyLight", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            'do nothing
        ElseIf result = DialogResult.Yes Then
            Dim FS As New FontDialog
            Try
                FS.ShowDialog()
                RichTextBox1.Font = FS.Font
            Catch ex As Exception
                'Do nothing on exeption 
            End Try
        End If
    End Sub
    Private Sub ColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show("Changing color will remove syntax highlighting. Do you wish to continue?", "PyLight", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            'do nothing
        ElseIf result = DialogResult.Yes Then
            Dim FC As New ColorDialog
            Try
                FC.ShowDialog()
                RichTextBox1.ForeColor = FC.Color
            Catch ex As Exception
                'Again, do nothing on exception
            End Try
        End If
    End Sub
    Private Sub ExitAltF4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitAltF4ToolStripMenuItem.Click
        If RichTextBox1.Text = "" Then
            End
        Else
            Dim result As Integer = MessageBox.Show("The last run file has been saved to filepath [c:/PyLightSource]", "PyLight", MessageBoxButtons.OK)
            End
        End If
    End Sub
    Private Sub SpecifyInstPathToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecifyInstPathToolStripMenuItem1.Click
        Form3.Show()
    End Sub
    Sub New()
        InitializeComponent()
        ToolStripTextBox2.Tag = "Online assistance"
        ToolStripTextBox2.Text = CStr(ToolStripTextBox2.Tag)
    End Sub
    Private Sub ToolStripTextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            System.Diagnostics.Process.Start("http://www.google.com/search?hl=en&q=" + (ToolStripTextBox2.Text) + "&aq=f&aqi=g-e7g3&aql=&oq=&gs_rfai=")
            ToolStripTextBox2.Text = "Online assistance"
        End If
    End Sub
    Private Sub OnTextBoxTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox2.TextChanged
        If String.IsNullOrEmpty(ToolStripTextBox2.Text) Then
            ToolStripTextBox2.Text = CStr(ToolStripTextBox2.Tag)
            ToolStripTextBox2.SelectAll()
        End If
    End Sub
    Private Sub DownloadModulesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadModulesToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.sourcenick.blogspot.com")
    End Sub
    Private Sub CreateAModuleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAModuleToolStripMenuItem.Click
        Form4.Show()
    End Sub
    Private Sub PythonLibraryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PythonLibraryToolStripMenuItem.Click

        System.Diagnostics.Process.Start("https://docs.python.org/2.7/library/")

    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        RichTextBox1.Text = ""
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        RichTextBox2.Text = RichTextBox1.Text
        Dim AB As New PrintDialog
        Try
            AB.ShowDialog()
            RichTextBox2.Text = AB.PrintToFile
        Catch ex As Exception
            'Again, do nothing on exception
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = "Code Lines : " & RichTextBox1.Lines.Length
    End Sub
    Private Sub DayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayToolStripMenuItem.Click
        TextBox1.Text = "1"
        My.Settings.password = TextBox1.Text
        My.Settings.Save()
        My.Settings.Reload()
        RichTextBox1.BackColor = Color.White
        RichTextBox1.ForeColor = Color.Black
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If TextBox1.Text = "" Then
            TextBox1.Text = "1"
        End If
        If TextBox1.Text = "1" Then
            RichTextBox1.BackColor = Color.White
            RichTextBox1.ForeColor = Color.Black

        ElseIf TextBox1.Text = "2" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.White

        ElseIf TextBox1.Text = "3" Then
            RichTextBox1.BackColor = Color.Gold
            RichTextBox1.ForeColor = Color.Black

        ElseIf TextBox1.Text = "4" Then
            RichTextBox1.BackColor = Color.Snow
            RichTextBox1.ForeColor = Color.Red

        ElseIf TextBox1.Text = "5" Then
            RichTextBox1.BackColor = Color.HotPink
            RichTextBox1.ForeColor = Color.White

        End If
    End Sub

    Private Sub NightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NightToolStripMenuItem.Click
        TextBox1.Text = "2"
        My.Settings.password = TextBox1.Text
        My.Settings.Save()
        My.Settings.Reload()
        RichTextBox1.BackColor = Color.Black
        RichTextBox1.ForeColor = Color.White
    
    End Sub

    Private Sub CoolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoolToolStripMenuItem.Click
        TextBox1.Text = "3"
        My.Settings.password = TextBox1.Text
        My.Settings.Save()
        My.Settings.Reload()
        RichTextBox1.BackColor = Color.Gold
        RichTextBox1.ForeColor = Color.Black

    End Sub

    Private Sub SeaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeaToolStripMenuItem.Click
        TextBox1.Text = "4"
        My.Settings.password = TextBox1.Text
        My.Settings.Save()
        My.Settings.Reload()
        RichTextBox1.BackColor = Color.Snow
        RichTextBox1.ForeColor = Color.Red

    End Sub

    Private Sub PinkyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PinkyToolStripMenuItem.Click
        TextBox1.Text = "5"
        My.Settings.password = TextBox1.Text
        My.Settings.Save()
        My.Settings.Reload()
        RichTextBox1.BackColor = Color.HotPink
        RichTextBox1.ForeColor = Color.White

    End Sub

    Private Sub RichTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
        If TextBox1.Text = "1" Then
            If e.KeyCode = Keys.Space Then
                Dim selectionlength As Integer = RichTextBox1.SelectionLength
                Dim selectionstart As Integer = RichTextBox1.SelectionStart
                Dim letter As String = String.Empty
                Do Until letter = " " Or RichTextBox1.SelectionStart = 0
                    RichTextBox1.SelectionStart -= 1
                    RichTextBox1.SelectionLength += 1
                    letter = RichTextBox1.Text.Substring(RichTextBox1.SelectionStart, 1)
                Loop
                If RichTextBox1.SelectedText = "print" Or RichTextBox1.SelectedText = " print" Or RichTextBox1.SelectedText = " if" Or RichTextBox1.SelectedText = "if" Or RichTextBox1.SelectedText = " for" Or RichTextBox1.SelectedText = "for" Or RichTextBox1.SelectedText = " while" Or RichTextBox1.SelectedText = "while" Or RichTextBox1.SelectedText = "else" Or RichTextBox1.SelectedText = " else" Or RichTextBox1.SelectedText = "elif" Or RichTextBox1.SelectedText = " elif" Then
                    RichTextBox1.SelectionColor = Color.Orange
                ElseIf RichTextBox1.SelectedText = "def" Or RichTextBox1.SelectedText = " def" Or RichTextBox1.SelectedText = "import" Or RichTextBox1.SelectedText = " import" Or RichTextBox1.SelectedText = "class" Or RichTextBox1.SelectedText = " class" Or RichTextBox1.SelectedText = "pass" Or RichTextBox1.SelectedText = " pass" Or RichTextBox1.SelectedText = "break" Or RichTextBox1.SelectedText = " break" Or RichTextBox1.SelectedText = "in" Or RichTextBox1.SelectedText = " in" Or RichTextBox1.SelectedText = " or" Or RichTextBox1.SelectedText = "or" Then
                    RichTextBox1.SelectionColor = Color.Orange
                ElseIf RichTextBox1.SelectedText = "False" Or RichTextBox1.SelectedText = " False" Or RichTextBox1.SelectedText = "True" Or RichTextBox1.SelectedText = " True" Or RichTextBox1.SelectedText = "slice" Or RichTextBox1.SelectedText = " slice" Or RichTextBox1.SelectedText = "id" Or RichTextBox1.SelectedText = " id" Or RichTextBox1.SelectedText = "None" Or RichTextBox1.SelectedText = " None" Or RichTextBox1.SelectedText = "list" Or RichTextBox1.SelectedText = " list" Or RichTextBox1.SelectedText = " open" Or RichTextBox1.SelectedText = "open" Or RichTextBox1.SelectedText = " file" Or RichTextBox1.SelectedText = "file" Or RichTextBox1.SelectedText = "object" Or RichTextBox1.SelectedText = " object" Or RichTextBox1.SelectedText = " raw_input" Or RichTextBox1.SelectedText = "raw_input" Or RichTextBox1.SelectedText = " input" Or RichTextBox1.SelectedText = "input" Or RichTextBox1.SelectedText = " str" Or RichTextBox1.SelectedText = "str" Or RichTextBox1.SelectedText = " int" Or RichTextBox1.SelectedText = "int" Then
                    RichTextBox1.SelectionColor = Color.Purple
                ElseIf RichTextBox1.SelectedText = "is" Or RichTextBox1.SelectedText = " is" Then
                    RichTextBox1.SelectionColor = Color.Orange
                ElseIf RichTextBox1.SelectedText = "and" Or RichTextBox1.SelectedText = " and" Then
                    RichTextBox1.SelectionColor = Color.Orange
                Else
                    'do nothing
                End If
                RichTextBox1.SelectionStart = selectionstart
                RichTextBox1.SelectionLength = 0
                RichTextBox1.SelectionColor = Color.Black
            End If
        End If
        If TextBox1.Text = "2" Then
            If e.KeyCode = Keys.Space Then
                Dim selectionlength As Integer = RichTextBox1.SelectionLength
                Dim selectionstart As Integer = RichTextBox1.SelectionStart
                Dim letter As String = String.Empty
                Do Until letter = " " Or RichTextBox1.SelectionStart = 0
                    RichTextBox1.SelectionStart -= 1
                    RichTextBox1.SelectionLength += 1
                    letter = RichTextBox1.Text.Substring(RichTextBox1.SelectionStart, 1)
                Loop
                If RichTextBox1.SelectedText = "print" Or RichTextBox1.SelectedText = " print" Or RichTextBox1.SelectedText = " if" Or RichTextBox1.SelectedText = "if" Or RichTextBox1.SelectedText = " for" Or RichTextBox1.SelectedText = "for" Or RichTextBox1.SelectedText = " while" Or RichTextBox1.SelectedText = "while" Or RichTextBox1.SelectedText = "else" Or RichTextBox1.SelectedText = " else" Or RichTextBox1.SelectedText = "elif" Or RichTextBox1.SelectedText = " elif" Then
                    RichTextBox1.SelectionColor = Color.Lime
                ElseIf RichTextBox1.SelectedText = "def" Or RichTextBox1.SelectedText = " def" Or RichTextBox1.SelectedText = "import" Or RichTextBox1.SelectedText = " import" Or RichTextBox1.SelectedText = "class" Or RichTextBox1.SelectedText = " class" Or RichTextBox1.SelectedText = "pass" Or RichTextBox1.SelectedText = " pass" Or RichTextBox1.SelectedText = "break" Or RichTextBox1.SelectedText = " break" Or RichTextBox1.SelectedText = "in" Or RichTextBox1.SelectedText = " in" Or RichTextBox1.SelectedText = " or" Or RichTextBox1.SelectedText = "or" Then
                    RichTextBox1.SelectionColor = Color.Lime
                ElseIf RichTextBox1.SelectedText = "False" Or RichTextBox1.SelectedText = " False" Or RichTextBox1.SelectedText = "True" Or RichTextBox1.SelectedText = " True" Or RichTextBox1.SelectedText = "slice" Or RichTextBox1.SelectedText = " slice" Or RichTextBox1.SelectedText = "id" Or RichTextBox1.SelectedText = " id" Or RichTextBox1.SelectedText = "None" Or RichTextBox1.SelectedText = " None" Or RichTextBox1.SelectedText = "list" Or RichTextBox1.SelectedText = " list" Or RichTextBox1.SelectedText = " open" Or RichTextBox1.SelectedText = "open" Or RichTextBox1.SelectedText = " file" Or RichTextBox1.SelectedText = "file" Or RichTextBox1.SelectedText = "object" Or RichTextBox1.SelectedText = " object" Or RichTextBox1.SelectedText = " raw_input" Or RichTextBox1.SelectedText = "raw_input" Or RichTextBox1.SelectedText = " input" Or RichTextBox1.SelectedText = "input" Or RichTextBox1.SelectedText = " str" Or RichTextBox1.SelectedText = "str" Or RichTextBox1.SelectedText = " int" Or RichTextBox1.SelectedText = "int" Then
                    RichTextBox1.SelectionColor = Color.Yellow
                ElseIf RichTextBox1.SelectedText = "is" Or RichTextBox1.SelectedText = " is" Then
                    RichTextBox1.SelectionColor = Color.Lime
                ElseIf RichTextBox1.SelectedText = "and" Or RichTextBox1.SelectedText = " and" Then
                    RichTextBox1.SelectionColor = Color.Lime
                Else
                    'do nothing
                End If
                RichTextBox1.SelectionStart = selectionstart
                RichTextBox1.SelectionLength = 0
                RichTextBox1.SelectionColor = Color.White
            End If
        End If
        If TextBox1.Text = "3" Then
            If e.KeyCode = Keys.Space Then
                Dim selectionlength As Integer = RichTextBox1.SelectionLength
                Dim selectionstart As Integer = RichTextBox1.SelectionStart
                Dim letter As String = String.Empty
                Do Until letter = " " Or RichTextBox1.SelectionStart = 0
                    RichTextBox1.SelectionStart -= 1
                    RichTextBox1.SelectionLength += 1
                    letter = RichTextBox1.Text.Substring(RichTextBox1.SelectionStart, 1)
                Loop
                If RichTextBox1.SelectedText = "print" Or RichTextBox1.SelectedText = " print" Or RichTextBox1.SelectedText = " if" Or RichTextBox1.SelectedText = "if" Or RichTextBox1.SelectedText = " for" Or RichTextBox1.SelectedText = "for" Or RichTextBox1.SelectedText = " while" Or RichTextBox1.SelectedText = "while" Or RichTextBox1.SelectedText = "else" Or RichTextBox1.SelectedText = " else" Or RichTextBox1.SelectedText = "elif" Or RichTextBox1.SelectedText = " elif" Then
                    RichTextBox1.SelectionColor = Color.Red
                ElseIf RichTextBox1.SelectedText = "def" Or RichTextBox1.SelectedText = " def" Or RichTextBox1.SelectedText = "import" Or RichTextBox1.SelectedText = " import" Or RichTextBox1.SelectedText = "class" Or RichTextBox1.SelectedText = " class" Or RichTextBox1.SelectedText = "pass" Or RichTextBox1.SelectedText = " pass" Or RichTextBox1.SelectedText = "break" Or RichTextBox1.SelectedText = " break" Or RichTextBox1.SelectedText = "in" Or RichTextBox1.SelectedText = " in" Or RichTextBox1.SelectedText = " or" Or RichTextBox1.SelectedText = "or" Then
                    RichTextBox1.SelectionColor = Color.Red
                ElseIf RichTextBox1.SelectedText = "False" Or RichTextBox1.SelectedText = " False" Or RichTextBox1.SelectedText = "True" Or RichTextBox1.SelectedText = " True" Or RichTextBox1.SelectedText = "slice" Or RichTextBox1.SelectedText = " slice" Or RichTextBox1.SelectedText = "id" Or RichTextBox1.SelectedText = " id" Or RichTextBox1.SelectedText = "None" Or RichTextBox1.SelectedText = " None" Or RichTextBox1.SelectedText = "list" Or RichTextBox1.SelectedText = " list" Or RichTextBox1.SelectedText = " open" Or RichTextBox1.SelectedText = "open" Or RichTextBox1.SelectedText = " file" Or RichTextBox1.SelectedText = "file" Or RichTextBox1.SelectedText = "object" Or RichTextBox1.SelectedText = " object" Or RichTextBox1.SelectedText = " raw_input" Or RichTextBox1.SelectedText = "raw_input" Or RichTextBox1.SelectedText = " input" Or RichTextBox1.SelectedText = "input" Or RichTextBox1.SelectedText = " str" Or RichTextBox1.SelectedText = "str" Or RichTextBox1.SelectedText = " int" Or RichTextBox1.SelectedText = "int" Then
                    RichTextBox1.SelectionColor = Color.Blue
                ElseIf RichTextBox1.SelectedText = "is" Or RichTextBox1.SelectedText = " is" Then
                    RichTextBox1.SelectionColor = Color.Red
                ElseIf RichTextBox1.SelectedText = "and" Or RichTextBox1.SelectedText = " and" Then
                    RichTextBox1.SelectionColor = Color.Red
                Else
                    'do nothing
                End If
                RichTextBox1.SelectionStart = selectionstart
                RichTextBox1.SelectionLength = 0
                RichTextBox1.SelectionColor = Color.Black
            End If
        End If
        If TextBox1.Text = "4" Then
            If e.KeyCode = Keys.Space Then
                Dim selectionlength As Integer = RichTextBox1.SelectionLength
                Dim selectionstart As Integer = RichTextBox1.SelectionStart
                Dim letter As String = String.Empty
                Do Until letter = " " Or RichTextBox1.SelectionStart = 0
                    RichTextBox1.SelectionStart -= 1
                    RichTextBox1.SelectionLength += 1
                    letter = RichTextBox1.Text.Substring(RichTextBox1.SelectionStart, 1)
                Loop
                If RichTextBox1.SelectedText = "print" Or RichTextBox1.SelectedText = " print" Or RichTextBox1.SelectedText = " if" Or RichTextBox1.SelectedText = "if" Or RichTextBox1.SelectedText = " for" Or RichTextBox1.SelectedText = "for" Or RichTextBox1.SelectedText = " while" Or RichTextBox1.SelectedText = "while" Or RichTextBox1.SelectedText = "else" Or RichTextBox1.SelectedText = " else" Or RichTextBox1.SelectedText = "elif" Or RichTextBox1.SelectedText = " elif" Then
                    RichTextBox1.SelectionColor = Color.Indigo
                ElseIf RichTextBox1.SelectedText = "def" Or RichTextBox1.SelectedText = " def" Or RichTextBox1.SelectedText = "import" Or RichTextBox1.SelectedText = " import" Or RichTextBox1.SelectedText = "class" Or RichTextBox1.SelectedText = " class" Or RichTextBox1.SelectedText = "pass" Or RichTextBox1.SelectedText = " pass" Or RichTextBox1.SelectedText = "break" Or RichTextBox1.SelectedText = " break" Or RichTextBox1.SelectedText = "in" Or RichTextBox1.SelectedText = " in" Or RichTextBox1.SelectedText = " or" Or RichTextBox1.SelectedText = "or" Then
                    RichTextBox1.SelectionColor = Color.Indigo
                ElseIf RichTextBox1.SelectedText = "False" Or RichTextBox1.SelectedText = " False" Or RichTextBox1.SelectedText = "True" Or RichTextBox1.SelectedText = " True" Or RichTextBox1.SelectedText = "slice" Or RichTextBox1.SelectedText = " slice" Or RichTextBox1.SelectedText = "id" Or RichTextBox1.SelectedText = " id" Or RichTextBox1.SelectedText = "None" Or RichTextBox1.SelectedText = " None" Or RichTextBox1.SelectedText = "list" Or RichTextBox1.SelectedText = " list" Or RichTextBox1.SelectedText = " open" Or RichTextBox1.SelectedText = "open" Or RichTextBox1.SelectedText = " file" Or RichTextBox1.SelectedText = "file" Or RichTextBox1.SelectedText = "object" Or RichTextBox1.SelectedText = " object" Or RichTextBox1.SelectedText = " raw_input" Or RichTextBox1.SelectedText = "raw_input" Or RichTextBox1.SelectedText = " input" Or RichTextBox1.SelectedText = "input" Or RichTextBox1.SelectedText = " str" Or RichTextBox1.SelectedText = "str" Or RichTextBox1.SelectedText = " int" Or RichTextBox1.SelectedText = "int" Then
                    RichTextBox1.SelectionColor = Color.Blue
                ElseIf RichTextBox1.SelectedText = "is" Or RichTextBox1.SelectedText = " is" Then
                    RichTextBox1.SelectionColor = Color.Indigo
                ElseIf RichTextBox1.SelectedText = "and" Or RichTextBox1.SelectedText = " and" Then
                    RichTextBox1.SelectionColor = Color.Indigo
                Else
                    'do nothing
                End If
                RichTextBox1.SelectionStart = selectionstart
                RichTextBox1.SelectionLength = 0
                RichTextBox1.SelectionColor = Color.Red
            End If
        End If
        If TextBox1.Text = "5" Then
            If e.KeyCode = Keys.Space Then
                Dim selectionlength As Integer = RichTextBox1.SelectionLength
                Dim selectionstart As Integer = RichTextBox1.SelectionStart
                Dim letter As String = String.Empty
                Do Until letter = " " Or RichTextBox1.SelectionStart = 0
                    RichTextBox1.SelectionStart -= 1
                    RichTextBox1.SelectionLength += 1
                    letter = RichTextBox1.Text.Substring(RichTextBox1.SelectionStart, 1)
                Loop
                If RichTextBox1.SelectedText = "print" Or RichTextBox1.SelectedText = " print" Or RichTextBox1.SelectedText = " if" Or RichTextBox1.SelectedText = "if" Or RichTextBox1.SelectedText = " for" Or RichTextBox1.SelectedText = "for" Or RichTextBox1.SelectedText = " while" Or RichTextBox1.SelectedText = "while" Or RichTextBox1.SelectedText = "else" Or RichTextBox1.SelectedText = " else" Or RichTextBox1.SelectedText = "elif" Or RichTextBox1.SelectedText = " elif" Then
                    RichTextBox1.SelectionColor = Color.DarkGreen
                ElseIf RichTextBox1.SelectedText = "def" Or RichTextBox1.SelectedText = " def" Or RichTextBox1.SelectedText = "import" Or RichTextBox1.SelectedText = " import" Or RichTextBox1.SelectedText = "class" Or RichTextBox1.SelectedText = " class" Or RichTextBox1.SelectedText = "pass" Or RichTextBox1.SelectedText = " pass" Or RichTextBox1.SelectedText = "break" Or RichTextBox1.SelectedText = " break" Or RichTextBox1.SelectedText = "in" Or RichTextBox1.SelectedText = " in" Or RichTextBox1.SelectedText = " or" Or RichTextBox1.SelectedText = "or" Then
                    RichTextBox1.SelectionColor = Color.DarkGreen
                ElseIf RichTextBox1.SelectedText = "False" Or RichTextBox1.SelectedText = " False" Or RichTextBox1.SelectedText = "True" Or RichTextBox1.SelectedText = " True" Or RichTextBox1.SelectedText = "slice" Or RichTextBox1.SelectedText = " slice" Or RichTextBox1.SelectedText = "id" Or RichTextBox1.SelectedText = " id" Or RichTextBox1.SelectedText = "None" Or RichTextBox1.SelectedText = " None" Or RichTextBox1.SelectedText = "list" Or RichTextBox1.SelectedText = " list" Or RichTextBox1.SelectedText = " open" Or RichTextBox1.SelectedText = "open" Or RichTextBox1.SelectedText = " file" Or RichTextBox1.SelectedText = "file" Or RichTextBox1.SelectedText = "object" Or RichTextBox1.SelectedText = " object" Or RichTextBox1.SelectedText = " raw_input" Or RichTextBox1.SelectedText = "raw_input" Or RichTextBox1.SelectedText = " input" Or RichTextBox1.SelectedText = "input" Or RichTextBox1.SelectedText = " str" Or RichTextBox1.SelectedText = "str" Or RichTextBox1.SelectedText = " int" Or RichTextBox1.SelectedText = "int" Then
                    RichTextBox1.SelectionColor = Color.Blue
                ElseIf RichTextBox1.SelectedText = "is" Or RichTextBox1.SelectedText = " is" Then
                    RichTextBox1.SelectionColor = Color.DarkGreen
                ElseIf RichTextBox1.SelectedText = "and" Or RichTextBox1.SelectedText = " and" Then
                    RichTextBox1.SelectionColor = Color.DarkGreen
                Else
                    'do nothing
                End If
                RichTextBox1.SelectionStart = selectionstart
                RichTextBox1.SelectionLength = 0
                RichTextBox1.SelectionColor = Color.White
            End If
        End If
        If e.KeyCode = Keys.F5 Then
            Dim objWriter As New System.IO.StreamWriter("C:\PyLightSource\bin-project.py", False)
            objWriter.WriteLine(RichTextBox1.Text)
            objWriter.Close()
            System.Diagnostics.Process.Start("C:\PyLightSource\bin-project.py")
        End If
        If e.KeyCode = Keys.F3 Then
            Try
                Dim dlg As SaveFileDialog = New SaveFileDialog
                dlg.Title = "Save"
                dlg.Filter = "PyLight Files  (*.pylf)|*.pylf"
                If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    RichTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText)
                End If
            Catch ex As Exception : End Try
        End If
        If e.KeyCode = Keys.F7 Then
            Form4.Show()
        End If
        If e.KeyCode = Keys.F2 Then
            Try
                Dim dlg As OpenFileDialog = New OpenFileDialog
                dlg.Title = "Open"
                dlg.Filter = "PyLight Files (*.pylf)|*.pylf"
                If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    RichTextBox1.LoadFile(dlg.FileName)
                End If
            Catch ex As Exception : End Try
        End If
        If e.KeyCode = Keys.F8 Then
            Form2.Show()
        End If
        If e.KeyCode = Keys.Escape Then
            If RichTextBox1.Text = "" Then
                End
            Else
                Dim result As Integer = MessageBox.Show("The last run file has been saved to filepath [c:/PyLightSource]", "PyLight", MessageBoxButtons.OK)
                End
            End If
        End If
        If e.KeyCode = Keys.F6 Then
            System.Diagnostics.Process.Start("C:\PyLightSource")
        End If
        If e.KeyCode = Keys.F9 Then
            If TextBox1.Text = "1" Then
                TextBox1.Text = "2"
            ElseIf TextBox1.Text = "2" Then
                TextBox1.Text = "3"
            ElseIf TextBox1.Text = "3" Then
                TextBox1.Text = "4"
            ElseIf TextBox1.Text = "4" Then
                TextBox1.Text = "5"
            ElseIf TextBox1.Text = "5" Then
                TextBox1.Text = "1"
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Form5.Show()
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        If TextBox1.Text = "1" Then
            Dim MyRegex As New Regex("(\x22[^\x22]+\x22)")

            Dim MC As MatchCollection = MyRegex.Matches(RichTextBox1.Text)

            Dim OldSel As Integer = RichTextBox1.SelectionStart '' Old Selection Start

            ''We Must Restor Everything To Black Before Coloring
            ''

            For Each M As Match In MC
                RichTextBox1.SelectionStart = M.Index
                RichTextBox1.SelectionLength = M.Value.Length
                RichTextBox1.SelectionColor = Color.Green '' The Color That You Want
                RichTextBox1.DeselectAll()
            Next

            RichTextBox1.SelectionStart = OldSel '' Restore Old Selection
        End If
        If TextBox1.Text = "2" Then
            Dim MyRegex As New Regex("(\x22[^\x22]+\x22)")

            Dim MC As MatchCollection = MyRegex.Matches(RichTextBox1.Text)

            Dim OldSel As Integer = RichTextBox1.SelectionStart '' Old Selection Start

            ''We Must Restor Everything To Black Before Coloring
            ''

            For Each M As Match In MC
                RichTextBox1.SelectionStart = M.Index
                RichTextBox1.SelectionLength = M.Value.Length
                RichTextBox1.SelectionColor = Color.Aquamarine '' The Color That You Want
                RichTextBox1.DeselectAll()
            Next

            RichTextBox1.SelectionStart = OldSel '' Restore Old Selection
        End If
        If TextBox1.Text = "3" Then
            Dim MyRegex As New Regex("(\x22[^\x22]+\x22)")

            Dim MC As MatchCollection = MyRegex.Matches(RichTextBox1.Text)

            Dim OldSel As Integer = RichTextBox1.SelectionStart '' Old Selection Start

            ''We Must Restor Everything To Black Before Coloring
            ''

            For Each M As Match In MC
                RichTextBox1.SelectionStart = M.Index
                RichTextBox1.SelectionLength = M.Value.Length
                RichTextBox1.SelectionColor = Color.DarkGreen '' The Color That You Want
                RichTextBox1.DeselectAll()
            Next

            RichTextBox1.SelectionStart = OldSel '' Restore Old Selection
        End If
        If TextBox1.Text = "4" Then
            Dim MyRegex As New Regex("(\x22[^\x22]+\x22)")

            Dim MC As MatchCollection = MyRegex.Matches(RichTextBox1.Text)

            Dim OldSel As Integer = RichTextBox1.SelectionStart '' Old Selection Start

            ''We Must Restor Everything To Black Before Coloring
            ''

            For Each M As Match In MC
                RichTextBox1.SelectionStart = M.Index
                RichTextBox1.SelectionLength = M.Value.Length
                RichTextBox1.SelectionColor = Color.Brown '' The Color That You Want
                RichTextBox1.DeselectAll()
            Next

            RichTextBox1.SelectionStart = OldSel '' Restore Old Selection
        End If
        If TextBox1.Text = "5" Then
            Dim MyRegex As New Regex("(\x22[^\x22]+\x22)")

            Dim MC As MatchCollection = MyRegex.Matches(RichTextBox1.Text)

            Dim OldSel As Integer = RichTextBox1.SelectionStart '' Old Selection Start

            ''We Must Restor Everything To Black Before Coloring
            ''

            For Each M As Match In MC
                RichTextBox1.SelectionStart = M.Index
                RichTextBox1.SelectionLength = M.Value.Length
                RichTextBox1.SelectionColor = Color.Black '' The Color That You Want
                RichTextBox1.DeselectAll()
            Next

            RichTextBox1.SelectionStart = OldSel '' Restore Old Selection
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        Form6.Show()
    End Sub

    Private Sub InformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformationToolStripMenuItem.Click
        Form7.Show()
    End Sub
End Class
