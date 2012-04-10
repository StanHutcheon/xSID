Module cmds

    Public Sub simpack(ByVal sim As String, ByVal dir As String)
        ChDir(My.Application.Info.DirectoryPath)
        Dim args As String = " x " + Chr(34) + sim + Chr(34) + " " + Chr(34) + dir + Chr(34)
        Dim simpack As Process = New Process
        simpack.StartInfo.Arguments = args
        simpack.StartInfo.RedirectStandardOutput = True
        simpack.StartInfo.UseShellExecute = False
        simpack.StartInfo.FileName = My.Application.Info.DirectoryPath + "\simpack.exe"
        simpack.Start()
        Do Until simpack.HasExited
            For i = 0 To 5000000
            Next
        Loop
        simpack.WaitForExit()
    End Sub

    Public Function getSIMName(ByVal dir As String) As String
        For Each file In System.IO.Directory.GetFiles(dir)
            If file.EndsWith(".sim") Then
                getSIMName = file.ToString
            End If
        Next
    End Function

End Module
