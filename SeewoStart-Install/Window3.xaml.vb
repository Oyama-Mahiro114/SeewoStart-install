Imports System.ComponentModel
Imports System.Drawing

Public Class Window3
    Private Sub Window3_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        networkcheck()
    End Sub
    Private Async Sub networkcheck()

        Await Task.Delay(2000)

        Try
            If My.Computer.Network.Ping("disk.srinternet.top") = True Then
                w1.Text = "与服务器对接成功"
            Else
                w1.Text = "网络连通性测试失败，您可能无法连接到下载服务器！"
                ProgressBar1.Foreground = New SolidColorBrush(Media.Color.FromRgb(255, 0, 0))

            End If
        Catch ex As Exception
            w1.Text = "网络连通性测试失败，您可能无法连接到下载服务器！"
            ProgressBar1.Foreground = New SolidColorBrush(Media.Color.FromRgb(255, 0, 0))
        End Try
        Await Task.Delay(2000)
        Dim Mainwindow As New MainWindow
        Mainwindow.Show()
        Hide()
        Close()

    End Sub


End Class
