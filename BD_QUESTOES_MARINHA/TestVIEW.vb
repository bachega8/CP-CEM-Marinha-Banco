
Imports System.IO


Public Class TestVIEW


    Private caminho As String

    Sub New(ByVal path As String)


        ' This call is required by the designer.
        InitializeComponent()
        caminho = path

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub TestVIEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WebBrowser1.Navigate(caminho)


    End Sub

    Private Sub SALVARCOMOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALVARCOMOToolStripMenuItem.Click


        Dim sv As New SaveFileDialog()
        sv.Title = "Salvar Prova PDF"
        sv.Filter = "PDF Files (*.pdf)|*.pdf"

        If sv.ShowDialog = Windows.Forms.DialogResult.OK Then

            Try

           
            File.Copy(caminho, sv.FileName, True)
                MsgBox("salvo com sucesso")

            Catch ex As Exception
                MsgBox(ex.Message, 0 + 16)
            End Try


        End If


    End Sub
End Class