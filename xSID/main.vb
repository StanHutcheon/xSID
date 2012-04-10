Imports System.Windows.Forms
Module main

    Sub Main()
        If Not System.IO.File.Exists(My.Application.Info.DirectoryPath + "\setup.ini") Then
            MsgBox("Please make sure you are running this from the game install root, this contains SteamService.exe and splash.tga", MsgBoxStyle.Exclamation, "xSID - Error")
        End If
        Dim ini As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\setup.ini")
        Dim game = Split(ini, Chr(34))
        Dim finalgame = game(3).ToString
        Dim requiredSize = Val(game(11)) / 1000000

        Console.WriteLine("Game: " + finalgame)
        Console.WriteLine("required: " + requiredSize.ToString + "GB")
        Console.WriteLine("")

        Dim folder As FolderBrowserDialog = New FolderBrowserDialog
        folder.Description = "Please select an install directory for " + finalgame
        Do Until Not folder.SelectedPath = ""
            folder.ShowDialog()
            If folder.SelectedPath = "" Then
                MsgBox("Please select an install directory", MsgBoxStyle.Exclamation, "xSID - Error")
            End If
        Loop
        Console.WriteLine("Selected Path: " + folder.SelectedPath)
        Dim drive = System.IO.Directory.GetDirectoryRoot(folder.SelectedPath)
        Dim driveinfo = My.Computer.FileSystem.GetDriveInfo(drive.ToString)
        Dim drivefreespace = driveinfo.AvailableFreeSpace / 1000000000
        Console.WriteLine("Free space: " + drivefreespace.ToString + "GB")

        If drivefreespace < requiredSize Then
            MsgBox("The directory you selected is too small, please select another one, or free up some space", MsgBoxStyle.Exclamation, "xSID - Error")
            Exit Sub
        End If

        simpack(getSIMName(My.Application.Info.DirectoryPath), folder.SelectedPath)

    End Sub


End Module
