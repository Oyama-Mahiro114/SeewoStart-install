Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Net

Public Class Window1
    Private WithEvents myWebClient As New WebClient()


    Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim url As New Uri(xzurl)

        Dim savePath As String = "" & xzlj & "\" & "" & "\seewostart.zip"


        ' 开始异步下载
        myWebClient.DownloadFileAsync(url, savePath)

    End Sub

    Private Sub myWebClient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles myWebClient.DownloadProgressChanged
        ' 更新进度条
        ProgressBar1.Value = e.ProgressPercentage
        textBlock_Copy.Text = e.ProgressPercentage & "%"
    End Sub

    Private Sub myWebClient_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles myWebClient.DownloadFileCompleted
        Dim zipPath As String = "" & xzlj & "\" & "seewostart.zip" & ""
        Try
            'MsgBox（"" & xzlj & "\" & "backup\" & ""）
            My.Computer.FileSystem.CreateDirectory("" & xzlj & "\" & "backup\" & "")



            If Dir（"" & xzlj & "\" & "swenlauncher.exe" & ""） <> “” Then
                FileCopy("" & xzlj & "\" & "" & "swenlauncher.exe", "" & xzlj & "\" & "" & "backup\swenlauncher-backup.exe")
            End If
            Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
                For Each entry As ZipArchiveEntry In archive.Entries
                    Console.WriteLine(entry.FullName)
                    If Dir("" & xzlj & "\" & entry.FullName & "") <> "" Then
                        File.Delete("" & xzlj & "\" & entry.FullName & "")
                    End If
                Next
            End Using


            Dim extractPath As String = xzlj
            ZipFile.ExtractToDirectory(zipPath, extractPath)
            File.Delete("" & xzlj & "\" & "seewostart.zip" & "")
        Catch ex As Exception
            MsgBox（“已引发异常:无法正常解压定制启动器文件，您可以尝试手动解压，这是个致命错误， 程序即将退出！！！”, vbCritical, "Error!"）
            Process.GetCurrentProcess().Kill()
        End Try


        Dim window2 As New Window2
        window2.Show()
        Hide()


        Close()













    End Sub

    Private Sub Window1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub
End Class
