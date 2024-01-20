Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Drawing.Text
Imports System.Diagnostics
Public Class Window2
    Dim exe
    Dim kdtkyd As String = "swenlauncher.exe"
    Private Sub Window2_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        check()
    End Sub
    Private Async Sub check()
        Await Task.Delay(1000)
        Dim useRegistryView As RegistryView = If(Environment.Is64BitOperatingSystem, RegistryView.Registry64, RegistryView.Registry32)

        ' 打开注册表的基键
        Dim hklm As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, useRegistryView)

        ' 打开指定的子键
        Dim software As RegistryKey = hklm.OpenSubKey("SOFTWARE\\WOW6432Node\\Seewo\\EasiNote5", True)

        ' 读取指定的值
        Dim registData As String = software.GetValue("ActualExePath").ToString()





        ' 执行批处理文件
        Dim processInfo As New ProcessStartInfo()
        processInfo.FileName = "cmd.exe" ' 使用cmd.exe来执行批处理文件
        processInfo.WorkingDirectory = xzlj ' 设置工作目录
        processInfo.Arguments = "/c " + """" + Path.Combine(xzlj, "配置定制启动器.bat") + """" ' 使用/c参数执行批处理文件
        Console.WriteLine(processInfo.Arguments)
        'processInfo.WindowStyle = ProcessWindowStyle.Hidden ' 隐藏cmd窗口

        If IsNothing(registData) Then

            Dim one1 As RegistryView = If(Environment.Is64BitOperatingSystem, RegistryView.Registry64, RegistryView.Registry32)


            ' 打开注册表的基键
            Dim two2 As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, useRegistryView)

            ' 打开指定的子键
            Dim there3 As RegistryKey = hklm.OpenSubKey("SOFTWARE\\Seewo\\EasiNote5", True)

            ' 读取指定的值
            Dim four4 As String = software.GetValue("ActualExePath").ToString()

            If IsNothing(four4) Then

                Await Task.Delay(2000)
                w1.Text = "无法自动更新 希沃白板"
                Await Task.Delay(2000)
                Dim process As New Process()
                'Process.Start("" & xzlj & "\SeewoStart_Install.startsettings.exe" & "")
                'Process.Start("" & xzlj & "\swenlauncher.exe /settings" & "")
                Process.Start(processInfo)
                Await Task.Delay(2000)

                Hide()

                Close()
                Process.GetCurrentProcess().Kill()

            Else
                Dim filePath1 As String = "" & xzlj & "\settings.ini" & "" ' 设置文件路径
                Using writer As New StreamWriter(filePath1) ' 创建StreamWriter对象并打开文件
                    writer.WriteLine(kdtkyd)
                    writer.WriteLine(four4)
                    writer.WriteLine("10000")
                    writer.WriteLine("希沃 ")
                    writer.WriteLine("Pro")
                    writer.WriteLine("正在启动……")
                    writer.WriteLine("抵制扰乱秩序，坚持认真上课，注意自我提醒，谨防上课睡觉；适度教学益脑，拖堂教学伤身，合理安排时间，享受快乐教学。")
                    writer.WriteLine("Copyright © 2011-2024 Guangzhou Shirui. All Rights Reserved")
                    writer.WriteLine("True")
                    writer.WriteLine("False")


                End Using ' 关闭文件并释放资源


                Await Task.Delay(2000)
                w1.Text = "保存成功~"
                Await Task.Delay(2000)
                Dim process As New Process()
                'Process.Start("" & xzlj & "\SeewoStart_Install.startsettings.exe" & "")
                Process.Start(processInfo)
                'Process.Start("" & xzlj & "\swenlauncher.exe /settings" & "")
                Await Task.Delay(2000)

                Hide()

                Close()
                Process.GetCurrentProcess().Kill()
            End If


        Else
            Dim filePath As String = "" & xzlj & "\settings.ini" & "" ' 设置文件路径
            Using writer As New StreamWriter(filePath) ' 创建StreamWriter对象并打开文件
                writer.WriteLine(kdtkyd)
                writer.WriteLine(registData)
                writer.WriteLine("10000")
                writer.WriteLine("希沃 ")
                writer.WriteLine("Pro")
                writer.WriteLine("正在启动……")
                writer.WriteLine("抵制扰乱秩序，坚持认真上课，注意自我提醒，谨防上课睡觉；适度教学益脑，拖堂教学伤身，合理安排时间，享受快乐教学。")
                writer.WriteLine("Copyright © 2011-2024 Guangzhou Shirui. All Rights Reserved")
                writer.WriteLine("True")
                writer.WriteLine("False")



            End Using ' 关闭文件并释放资源


            Await Task.Delay(2000)
            w1.Text = "保存成功~"
            Await Task.Delay(2000)
            Dim process As New Process()
            ' MsgBox("" & xzlj & "\" & "" & "swenlauncher.exe")
            'Process.Start("" & xzlj & "\SeewoStart_Install.startsettings.exe" & "")
            'Process.Start("" & xzlj & "\swenlauncher.exe" & "", " /settings")
            Process.Start(processInfo)
            Await Task.Delay(2000)

            Hide()
            Process.GetCurrentProcess().Kill()
            Close()

        End If
    End Sub




End Class
