Public Class Form2
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim objWriter As New System.IO.StreamWriter("C:\PyLightSource\" + TextBox1.Text + ".py", False)
            objWriter.WriteLine(Form1.RichTextBox1.Text)
            objWriter.Close()
            Me.Close()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objWriter As New System.IO.StreamWriter("C:\PyLightSource\" + TextBox1.Text + ".py", False)
        objWriter.WriteLine(Form1.RichTextBox1.Text)
        objWriter.Close()
        MsgBox("Saved to [c:\PyLightSource]", MsgBoxStyle.Information)
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "Cancel" Then
            Me.Close()
        ElseIf Button2.Text = "Save as .exe" Then
            Dim objWriter As New System.IO.StreamWriter("C:\Python27\" + TextBox1.Text + ".py", False)
            objWriter.WriteLine(Form1.RichTextBox1.Text)
            objWriter.Close()
            Dim objWriterx As New System.IO.StreamWriter("C:\Python27\pylightexesetup.txt", False)
            objWriterx.WriteLine("from distutils.core import setup" + vbCrLf + "import py2exe" + vbCrLf + "setup(console=['" + TextBox1.Text + ".py'])")
            objWriterx.Close()
            Process.Start("C:\PyLightX1\PyLightEXE.lnk")
            Me.Close()
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Not System.IO.Directory.Exists(Form3.TextBox2.Text + Form3.TextBox2.Text(2) + "Lib" + Form3.TextBox2.Text(2) + "site-packages" + Form3.TextBox2.Text(2) + "py2exe")) Then
            Button2.Text = "Cancel"
        Else
            Button2.Text = "Save as .exe"
        End If
    End Sub
End Class
