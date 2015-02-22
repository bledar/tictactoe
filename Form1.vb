Imports System.IO
Imports System.Reflection


Public Class Form1
    Dim T(3, 3) As Short
    Dim consol As String = "/*"
    Dim numriLevizjeve = 0
    Dim random As New Random
    Dim ranX = random.Next(0, 3)
    Dim ranY = random.Next(0, 3)
    Dim backgraundO As Drawing.Image = My.Resources.TicTacO
    Dim backgraundX As Drawing.Image = My.Resources.TicTacX
    Dim rrallaJote As Boolean = True
    Dim ZeroNjish = 0

    Private Sub Buton_Click(sender As Object, e As EventArgs) Handles Button0.Click, Button2.Click, Button1.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click
        Dim b As Button = sender
        luaj(b)
        b.Enabled = False
        debug()
    End Sub
   
    Sub ZeroLojen()
        T(0, 0) = 2
        T(0, 1) = 3
        T(0, 2) = 4
        T(1, 0) = 5
        T(1, 1) = 6
        T(1, 2) = 7
        T(2, 0) = 8
        T(2, 1) = 9
        T(2, 2) = 10
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ZeroLojen()
    End Sub

    Sub debug()
        consol = ""
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                consol = consol + T(i, j).ToString + " , "
            Next
            consol = consol + Environment.NewLine
        Next
        consol = consol + "X: " + ranX.ToString + Environment.NewLine
        consol = consol + "Y: " + ranY.ToString + Environment.NewLine
        consol = consol + "levizjet: " + numriLevizjeve.ToString + Environment.NewLine
        consol = consol + "rrallaJote: " + rrallaJote.ToString + Environment.NewLine

        dbg.Text = consol

    End Sub


    Sub luaj(b As Button)
        If rrallaJote Then
            numriLevizjeve += 1
            rrallaJote = Not rrallaJote
            b.BackgroundImage = backgraundO
            b.Text = "0"
            kontrollPerFitues(b.Name.ToString)
            nrLev.Text = numriLevizjeve.ToString
            ZeroNjish = 1
        Else
            numriLevizjeve += 1
            b.BackgroundImage = backgraundX
            rrallaJote = Not rrallaJote
            b.Text = "X"
            nrLev.Text = numriLevizjeve.ToString
            kontrollPerFitues(b.Name.ToString)
            ZeroNjish = 0
        End If

    End Sub


    Sub kontrollPerFitues(buton As String)

        Select Case buton
            Case "Button0"
                T(0, 0) = ZeroNjish
            Case "Button1"
                T(0, 1) = ZeroNjish
            Case "Button2"
                T(0, 2) = ZeroNjish
            Case "Button3"
                T(1, 0) = ZeroNjish
            Case "Button4"
                T(1, 1) = ZeroNjish
            Case "Button5"
                T(1, 2) = ZeroNjish
            Case "Button6"
                T(2, 0) = ZeroNjish
            Case "Button7"
                T(2, 1) = ZeroNjish
            Case "Button8"
                T(2, 2) = ZeroNjish
        End Select
        If kontrollH() Or kontrollV() Or kontrollD() Then
            If (rrallaJote) Then
                MsgBox("Fiton lojtari X me " + numriLevizjeve.ToString + " levizje", MsgBoxStyle.Information)
            Else
                MsgBox("Fiton lojtari O me " + numriLevizjeve.ToString + " levizje", MsgBoxStyle.Information)
            End If
        ElseIf (numriLevizjeve = 9) Then

            MsgBox("Loja Ka mbaruar barazim. Ju mund te filloni nje loje te re!", MsgBoxStyle.Information)

        End If

    End Sub

    Function kontrollH() As Boolean

        Dim a As Boolean = False
        If ((T(0, 0) = T(0, 1)) And (T(0, 0) = T(0, 2))) Then
            Return True
        ElseIf ((T(1, 0) = T(1, 1)) And (T(1, 0) = T(1, 2))) Then
            Return True
        ElseIf ((T(2, 0) = T(2, 1)) And (T(2, 0) = T(2, 2))) Then
            Return True
        End If
        Return False
    End Function

    Function kontrollV() As Boolean

        Dim a As Boolean = False
        If ((T(0, 0) = T(1, 0)) And (T(0, 0) = T(2, 0))) Then
            Return True
        ElseIf ((T(0, 1) = T(1, 1)) And (T(0, 1) = T(2, 1))) Then
            Return True
        ElseIf ((T(0, 2) = T(1, 2)) And (T(0, 2) = T(2, 2))) Then
            Return True
        End If
        Return False
    End Function


    Function kontrollD() As Boolean

        Dim a As Boolean = False
        If ((T(0, 0) = T(1, 1)) And (T(0, 0) = T(2, 2))) Then
            Return True
        ElseIf ((T(2, 0) = T(1, 1)) And (T(2, 0) = T(0, 2))) Then
            Return True
        End If
        Return False
    End Function

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Application.Restart()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Info.Show()

    End Sub
End Class
