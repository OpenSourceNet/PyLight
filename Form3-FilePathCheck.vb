Public Class Form3
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (Not System.IO.Directory.Exists(TextBox2.Text)) Then
            MsgBox("Specified FilePath for Python does not exist. Try again.", MsgBoxStyle.Exclamation)
        Else
            My.Settings.username = TextBox2.Text
            My.Settings.Save()
            My.Settings.Reload()
            MsgBox("The FilePath has been saved", MsgBoxStyle.Information)
            Me.Close()
            Form1.RichTextBox1.Enabled = True
            Form1.RichTextBox1.Text = ""
            Form1.MenuStrip2.Visible = False
            Form1.MenuStrip1.Visible = True
            Form1.Timer1.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        System.Diagnostics.Process.Start("https://www.python.org/download/")
    End Sub
End Class
