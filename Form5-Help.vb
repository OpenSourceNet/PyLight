Public Class Form5

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        WebKitBrowser1.Visible = True
        WebKitBrowser1.Navigate("http://www.github.com/login")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WebKitBrowser1.Visible = True
        WebKitBrowser1.Navigate("http://www.stackoverflow.com")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        WebKitBrowser1.Visible = True
        WebKitBrowser1.Navigate("http://www.dropbox.com/login")
    End Sub
    
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            WebKitBrowser1.Visible = True
            WebKitBrowser1.Navigate("https://docs.python.org/2.7/search.html?q=" + TextBox1.Text + "&check_keywords=yes&area=default")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        WebKitBrowser1.Visible = True
        WebKitBrowser1.Navigate("http://www.dropbox.com/login")
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ComboBox1.Text = "Hello World" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = "print ('Hello World')"
        End If
        If ComboBox1.Text = "Simple frame" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = RichTextBox6.Text
        End If
        If ComboBox1.Text = "User defined Hello World" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = "name = raw_input ('What is your name? : ')" + vbCrLf + "print ('Hello ' + name)" + vbCrLf + "raw_input ('Press <enter> to exit ')"
        End If
        If ComboBox1.Text = "Random integers" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = "import random" + vbCrLf + "print random.randint(0, 100)" + vbCrLf + vbCrLf + "# Parameters (0, 100) suggest the range in which the random number is to be selected" + vbCrLf + vbCrLf + "raw_input ('Press <enter> to exit ')"
        End If
        If ComboBox1.Text = "User defined random integers" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = "import random" + vbCrLf + "start = input ('Input start number: ')" + vbCrLf + "end = input ('Input end number: ')" + vbCrLf + "print random.randint(start, end)" + vbCrLf + vbCrLf + "# Parameters (start, end) suggest the range in which the random number is to be selected" + vbCrLf + vbCrLf + "raw_input ('Press <enter> to exit ')"
        End If
        If ComboBox1.Text = "Webhack" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = "import urllib2" + vbCrLf + "import re" + vbCrLf + "website = raw_input ('Please input a website name including http:// : ')" + vbCrLf + "print ('Hacking')" + vbCrLf + "url = urllib2.urlopen(website).read()" + vbCrLf + "print (url)"
        End If
        If ComboBox1.Text = "Calculator" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = RichTextBox2.text
        End If
        If ComboBox1.Text = "Translator" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = RichTextBox3.Text
        End If
        If ComboBox1.Text = "User defined Facebook status" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = RichTextBox4.Text
        End If
        If ComboBox1.Text = "Facebook status" Then
            WebKitBrowser1.Visible = False
            RichTextBox1.Text = RichTextBox5.Text
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If WebKitBrowser1.Visible = False Then
            Button4.Visible = True
        Else
            Button4.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Form1.RichTextBox1.Text = "" Then
            Form1.RichTextBox1.Text = Form1.RichTextBox1.Text + RichTextBox1.Text
            MsgBox("Code has been embedded, you may want to close the help dialog to continue editing.", MsgBoxStyle.Information)
        Else
            Form1.RichTextBox1.Text = Form1.RichTextBox1.Text + vbCrLf + RichTextBox1.Text
            MsgBox("Code has been embedded, you may want to close the help dialog to continue editing.", MsgBoxStyle.Information)
        End If
    End Sub
End Class
