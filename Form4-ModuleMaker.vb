Imports System.Text.RegularExpressions
Public Class Form4
    Private Sub RichTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
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
            ElseIf RichTextBox1.SelectedText = "list" Or RichTextBox1.SelectedText = " list" Or RichTextBox1.SelectedText = " open" Or RichTextBox1.SelectedText = "open" Or RichTextBox1.SelectedText = " file" Or RichTextBox1.SelectedText = "file" Or RichTextBox1.SelectedText = "object" Or RichTextBox1.SelectedText = " object" Or RichTextBox1.SelectedText = " raw_input" Or RichTextBox1.SelectedText = "raw_input" Or RichTextBox1.SelectedText = " input" Or RichTextBox1.SelectedText = "input" Or RichTextBox1.SelectedText = " str" Or RichTextBox1.SelectedText = "str" Or RichTextBox1.SelectedText = " int" Or RichTextBox1.SelectedText = "int" Then
                RichTextBox1.SelectionColor = Color.Purple
            ElseIf RichTextBox1.SelectedText = "is" Or RichTextBox1.SelectedText = " is" Then
                RichTextBox1.SelectionColor = Color.Orange
            Else
                'do nothing
            End If
            RichTextBox1.SelectionStart = selectionstart
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionColor = Color.Black
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RichTextBox2.Text = "def " + (TextBox1.Text) + "():" + vbCrLf + RichTextBox1.Text
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Then
            MsgBox("Please select number of parameters to continue.", MsgBoxStyle.Information)
        ElseIf ComboBox1.Text = "1" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "2" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "," + (TextBox5.Text) + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "3" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "," + (TextBox5.Text) + "," + (TextBox7.Text) + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "4" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "," + (TextBox5.Text) + "," + (TextBox7.Text) + "," + (TextBox9.Text) + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "5" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "," + (TextBox5.Text) + "," + (TextBox7.Text) + "," + (TextBox9.Text) + "," + (TextBox11.Text) + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "6" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "," + (TextBox5.Text) + "," + (TextBox7.Text) + "," + (TextBox9.Text) + "," + (TextBox11.Text) + "," + (TextBox13.Text) + "):" + vbCrLf + RichTextBox1.Text
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            MsgBox("Please select number of parameters to continue.", MsgBoxStyle.Information)
        ElseIf ComboBox1.Text = "1" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "='" + TextBox3.Text + "'" + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "2" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "='" + TextBox3.Text + "'" + "," + (TextBox5.Text) + "='" + TextBox4.Text + "'" + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "3" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "='" + TextBox3.Text + "'" + "," + (TextBox5.Text) + "='" + TextBox4.Text + "'" + "," + (TextBox7.Text) + "='" + TextBox6.Text + "'" + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "4" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "='" + TextBox3.Text + "'" + "," + (TextBox5.Text) + "='" + TextBox4.Text + "'" + "," + (TextBox7.Text) + "='" + TextBox6.Text + "'" + "," + (TextBox9.Text) + "='" + TextBox8.Text + "'" + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "5" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "='" + TextBox3.Text + "'" + "," + (TextBox5.Text) + "='" + TextBox4.Text + "'" + "," + (TextBox7.Text) + "='" + TextBox6.Text + "'" + "," + (TextBox9.Text) + "='" + TextBox8.Text + "'" + "," + (TextBox11.Text) + "='" + TextBox10.Text + "'" + "):" + vbCrLf + RichTextBox1.Text
        ElseIf ComboBox1.Text = "6" Then
            RichTextBox2.Text = "def " + (TextBox1.Text) + "(" + (TextBox2.Text) + "='" + TextBox3.Text + "'" + "," + (TextBox5.Text) + "='" + TextBox4.Text + "'" + "," + (TextBox7.Text) + "='" + TextBox6.Text + "'" + "," + (TextBox9.Text) + "='" + TextBox8.Text + "'" + "," + (TextBox11.Text) + "='" + TextBox10.Text + "'" + "," + (TextBox13.Text) + "='" + TextBox12.Text + "'" + "):" + vbCrLf + RichTextBox1.Text
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox14.Text = "" Then
            MsgBox("Please input a file name to save.", MsgBoxStyle.Information)
        Else
            Dim objWriter As New System.IO.StreamWriter(Form3.TextBox2.Text + Form3.TextBox2.Text(2) + TextBox14.Text + ".py", False)
            objWriter.WriteLine(RichTextBox2.Text)
            objWriter.Close()
            MsgBox("Saved to [" + Form3.TextBox2.Text + "]", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Form1.RichTextBox1.Text = "" Then
            Form1.RichTextBox1.Text = Form1.RichTextBox1.Text + RichTextBox2.Text
            Me.Hide()
        Else
            Form1.RichTextBox1.Text = Form1.RichTextBox1.Text + vbCrLf + RichTextBox2.Text
            Me.Hide()
        End If
        
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        Dim MyRegex As New Regex("(\x22[^\x22]+\x22)")

        Dim MC As MatchCollection = MyRegex.Matches(RichTextBox1.Text)

        Dim OldSel As Integer = RichTextBox1.SelectionStart '' Old Selection Start

        For Each M As Match In MC
            RichTextBox1.SelectionStart = M.Index
            RichTextBox1.SelectionLength = M.Value.Length
            RichTextBox1.SelectionColor = Color.Green '' The Color That You Want
            RichTextBox1.DeselectAll()
        Next

        RichTextBox1.SelectionStart = OldSel '' Restore Old Selection
    End Sub
End Class
