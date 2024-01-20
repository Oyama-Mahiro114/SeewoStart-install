Imports System.Net
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class MainWindow





    Private Sub refreshh_Copy_Click(sender As Object, e As RoutedEventArgs) Handles refreshh_Copy.Click

        If Dir(textBox.Text, vbDirectory) <> "" Then
            If textBox.Text = "" Then
                MsgBox("您好像还没有选择希沃白板启动器文件夹目录呢！", vbCritical, "Error!")
            Else
                'MsgBox("" & textBox.Text & "\" & "swenlauncher.exe" & "")

                xzlj = "" & textBox.Text & ""
                    Dim window1 As New Window1
                    refreshh.IsEnabled = False
                    refreshh_Copy.IsEnabled = False
                    textBox.IsEnabled = False
                    refreshh.Foreground = New SolidColorBrush(Media.Color.FromRgb(6, 6, 6))
                    refreshh.Background = New SolidColorBrush(Media.Color.FromRgb(186, 186, 186))
                    refreshh_Copy.Foreground = New SolidColorBrush(Media.Color.FromRgb(6, 6, 6))
                    refreshh_Copy.Background = New SolidColorBrush(Media.Color.FromRgb(186, 186, 186))
                window1.ShowDialog()
            End If

                Else
            MsgBox("您选择的希沃白板启动器文件夹目录好像不存在哦", vbCritical, "Error!")
        End If


    End Sub

    Private Sub refreshh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refreshh.Click
        Dim folderBrowserDialog As New FolderBrowserDialog() ' 创建 FolderBrowserDialog 对象

        If folderBrowserDialog.ShowDialog() = Forms.DialogResult.OK Then ' 如果用户点击了“确定”按钮
            Dim selectedPath As String = folderBrowserDialog.SelectedPath ' 获取用户选择的文件夹路径
            textBox.Text = selectedPath ' 将选中的路径显示在文本框中
        End If

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Dim yon = MsgBox("确认退出安装程序吗" & "o((>ω< ))o", vbYesNo, "关闭？")
        If yon = 6 Then
            Process.GetCurrentProcess().Kill()
        End If
    End Sub

    Private Sub _666_Checked(sender As Object, e As RoutedEventArgs) Handles _666.Checked

        xzurl = "https://disk.srinternet.top/d/srdisk-files/seewostart/seewostart114.zip"
    End Sub

    'Private Sub beta1_Checked(sender As Object, e As RoutedEventArgs) Handles beta1.Checked
    'password1 = InputBox("请输入beta测试密码，可在交流群q群管家处获得！", "输入！！！！")
    'If password1 = "beta114514" Then
    'MsgBox("已成功切换至beta版！", vbInformation)
    '_666.IsChecked = False
    'beta1.IsChecked = True

    'xzurl = ""
    'Else
    'MsgBox("密码错误，请核对后重试！"， vbCritical)
    '_666.IsChecked = True
    'beta1.IsChecked = False

    'xzurl = ""
    'End If
    'End Sub
End Class
