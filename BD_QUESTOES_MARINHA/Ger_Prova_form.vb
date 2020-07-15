

Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Text




Public Class Ger_Prova_form


    Private PROVAATUAL As New Prova()

    Dim pathatual As String = ""


    Dim caminho As String = AppDomain.CurrentDomain.BaseDirectory


    ' variaveis para a comunicação com o banco de dados
    Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
    Dim dset As New DataSet()
    Dim olecon As New OleDbConnection(strcon)

    Dim tb_questoes As New DataTable("questoes")


    Private Sub Ger_Prova_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dset.Tables.Add(tb_questoes)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aux As New ItemProva_form
        AddHandler aux.ENVIAR, AddressOf ATUALIZA
        aux.ShowDialog()
    End Sub

    Private Sub ATUALIZA(ByVal itprovas As ItemProva)

        PROVAATUAL.ITENS_PROVA.Add(itprovas)
        AtualizaLista()

    End Sub

    Private Sub AtualizaLista()

        ListBox1.Items.Clear()

        For Each it As ItemProva In PROVAATUAL.ITENS_PROVA

            Dim str As String = "Ano: " & it.ANO.ToString & " / " & "Assunto: " _
                                & it.NOME_ASSUNTO & " / " & "Tema: " & it.NOME_TEMA & " / " & it.NUM_QUESTOES.ToString & " Questões"
            ListBox1.Items.Add(str)

        Next


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If ListBox1.SelectedIndex = -1 Then
            MsgBox("Selecione um item para remoção", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim ind As Integer = ListBox1.SelectedIndex

        PROVAATUAL.ITENS_PROVA.RemoveAt(ind)

        AtualizaLista()


    End Sub

#Region "SALVAR E ABRIR ARQUIVOS"

    Private Sub SalvarComoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarComoToolStripMenuItem.Click


        Dim sv As New SaveFileDialog() With {.Filter = "PRVO (*.prvo)|*.prvo"}

        If sv.ShowDialog = DialogResult.OK Then


            PROVAATUAL.NOME_PROVA = TextBox1.Text
            Serializador.Serializador.Serialize(sv.FileName, PROVAATUAL)
            MsgBox("Arquivo salvo com sucesso!")

            lbl_path_atual.Text = sv.FileName
            pathatual = sv.FileName

        End If



    End Sub

    Private Sub AbrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem.Click

        Dim op As New OpenFileDialog() With {.Filter = "PRVO (*.prvo)|*.prvo"}

        If op.ShowDialog = DialogResult.OK Then

            PROVAATUAL = Serializador.Serializador.Deserialize(op.FileName)

            TextBox1.Text = PROVAATUAL.NOME_PROVA
            AtualizaLista()

            lbl_path_atual.Text = op.FileName
            pathatual = op.FileName


        End If


    End Sub

    Private Sub SalvarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarToolStripMenuItem.Click

        If pathatual = "" Then



            Dim sv As New SaveFileDialog() With {.Filter = "PRVO (*.prvo)|*.prvo"}

            If sv.ShowDialog = DialogResult.OK Then


                PROVAATUAL.NOME_PROVA = TextBox1.Text
                Serializador.Serializador.Serialize(sv.FileName, PROVAATUAL)
                MsgBox("Arquivo salvo com sucesso!")

                lbl_path_atual.Text = sv.FileName
                pathatual = sv.FileName

            End If

        Else

            PROVAATUAL.NOME_PROVA = TextBox1.Text
            Serializador.Serializador.Serialize(pathatual, PROVAATUAL)
            MsgBox("Arquivo Salvo!")

        End If


    End Sub

    Private Sub SalvarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarToolStripMenuItem1.Click


        If pathatual = "" Then



            Dim sv As New SaveFileDialog() With {.Filter = "PRVO (*.prvo)|*.prvo"}

            If sv.ShowDialog = DialogResult.OK Then


                PROVAATUAL.NOME_PROVA = TextBox1.Text
                Serializador.Serializador.Serialize(sv.FileName, PROVAATUAL)
                MsgBox("Arquivo salvo com sucesso!")

                lbl_path_atual.Text = sv.FileName
                pathatual = sv.FileName

            End If

        Else

            PROVAATUAL.NOME_PROVA = TextBox1.Text
            Serializador.Serializador.Serialize(pathatual, PROVAATUAL)
            MsgBox("Arquivo Salvo!")

        End If
    End Sub


#End Region


#Region "GERAÇÃO RANDOMICA DE PROVA"


    'Rotina para selecionar randomicamente as questões, com base nos itens da questão, CLASSE
    Private Sub SelecionaQuestoes(ByVal ano As Long, ByVal codassunto As Long, ByVal codtema As Long, ByVal numquestoes As Long)

        Dim sql1, sql2, sql3, sql4, sql5, sql6 As String

        sql1 = "SELECT TOP " & numquestoes & " * FROM tbquestoes WHERE " _
            & "ano = @p1 AND cod_assunto = @p2 ORDER BY RND(INT(NOW*ID)-NOW*ID);" 'ANO;TEMA;ASSUNTO


        sql2 = "SELECT TOP " & numquestoes & " * FROM tbquestoes WHERE " _
            & "cod_assunto = @p1 ORDER BY RND(INT(NOW*ID)-NOW*ID);"                '--;TEMA;ASSUNTO


        sql3 = "SELECT TOP " & numquestoes & " tbquestoes.ID, tbquestoes.ano, tbquestoes.numero, " _
            & " tbquestoes.cod_cor, tbquestoes.cod_assunto, tbquestoes.file FROM tbquestoes, tbassuntos " _
            & "WHERE tbquestoes.cod_assunto = tbassuntos.ID AND tbassuntos.cod_tema = @p1 " _
            & "ORDER BY RND(INT(NOW*tbquestoes.ID)-NOW*tbquestoes.ID);"           '--;TEMA;--

        sql4 = "SELECT TOP " & numquestoes & " tbquestoes.ID, tbquestoes.ano, tbquestoes.numero, " _
            & " tbquestoes.cod_cor, tbquestoes.cod_assunto, tbquestoes.file FROM tbquestoes, tbassuntos " _
            & "WHERE tbquestoes.ano = @p1 AND tbquestoes.cod_assunto = tbassuntos.ID AND tbassuntos.cod_tema = @p2 " _
            & "ORDER BY RND(INT(NOW*tbquestoes.ID)-NOW*tbquestoes.ID);"           'ANO;TEMA;--

        sql5 = "SELECT TOP " & numquestoes & " * FROM tbquestoes WHERE " _
            & "ano = @p1 ORDER BY RND(INT(NOW*ID)-NOW*ID);" 'ANO;--;---

        sql6 = "SELECT TOP " & numquestoes & " * FROM tbquestoes " _
           & "ORDER BY RND(INT(NOW*ID)-NOW*ID);" '--;--;---

        Dim cmd As New OleDbCommand()
        Dim oleada As New OleDbDataAdapter()

        oleada.SelectCommand = cmd
        oleada.SelectCommand.CommandType = CommandType.Text
        oleada.SelectCommand.Connection = olecon

        If ano = -1 Then

            If codtema = 6666 Then
                oleada.SelectCommand.CommandText = sql6
            Else

                If codassunto = 6666 Then
                    oleada.SelectCommand.CommandText = sql3
                    oleada.SelectCommand.Parameters.AddWithValue("@p1", codtema)

                Else
                    oleada.SelectCommand.CommandText = sql2
                    oleada.SelectCommand.Parameters.AddWithValue("@p1", codassunto)

                End If

            End If

        Else

            If codtema = 6666 Then
                oleada.SelectCommand.CommandText = sql5
                oleada.SelectCommand.Parameters.AddWithValue("@p1", ano)
            Else

                If codassunto = 6666 Then
                    oleada.SelectCommand.CommandText = sql4
                    oleada.SelectCommand.Parameters.AddWithValue("@p1", ano)
                    oleada.SelectCommand.Parameters.AddWithValue("@p2", codtema)

                Else
                    oleada.SelectCommand.CommandText = sql1
                    oleada.SelectCommand.Parameters.AddWithValue("@p1", ano)
                    oleada.SelectCommand.Parameters.AddWithValue("@p2", codassunto)

                End If

            End If

        End If



        ' oleada.SelectCommand.CommandText = sql1


        'oleada.SelectCommand.Parameters.AddWithValue("@p1", ano)
        ' oleada.SelectCommand.Parameters.AddWithValue("@p2", codassunto)

        ' oleada.SelectCommand.Connection = olecon

        oleada.Fill(dset, tb_questoes.TableName)


    End Sub


    'Geração da Prova Toda com base nos itens escolhidos
    Private Sub Gerar_Prova(ByVal PROVA As Prova)

        tb_questoes.Clear()


        For Each it As ItemProva In PROVA.ITENS_PROVA

            SelecionaQuestoes(it.ANO, it.COD_ASSUNTO, it.COD_TEMA, it.NUM_QUESTOES)


        Next

        'Dim bindin As New BindingSource()
        'bindin.DataSource = dset
        'bindin.DataMember = tb_questoes.TableName

        'dg_view.DataSource = bindin



    End Sub

    'Gera a Prova em PDF no diretório raiz da aplicação
    Private Sub ImprimirProva()

        Dim fs As New FileStream("modelA4Prova.pdf", FileMode.Create)

        Dim doc As New Document(PageSize.A4, 77, 71, 51, 70)
        Dim wri As PdfWriter = PdfWriter.GetInstance(doc, fs)

        Dim ft As New Font(iTextSharp.text.Font.FontFamily.COURIER, 11)
        Dim ft2 As New Font(iTextSharp.text.Font.FontFamily.COURIER, 14, 1)


        doc.Open()

        Dim p1 As New Paragraph(TextBox1.Text, ft2)
        p1.Alignment = Element.ALIGN_CENTER
        p1.SpacingAfter = 10
        doc.Add(p1)



        For j As Integer = 0 To dset.Tables(0).Rows.Count - 1

            With dset.Tables(0)

                Dim p As New Paragraph("ID: " & .Rows(j).Item(0).ToString & "- Ano: " & _
                                       .Rows(j).Item(1).ToString & "- Núm.: " & .Rows(j).Item(2).ToString, ft)
                p.SpacingAfter = 10

                doc.Add(p)

                Dim imc As New ImageConverter()
                Dim img2 As Bitmap
                img2 = imc.ConvertFrom(.Rows(j).Item(5))
                Dim ms2 As New MemoryStream
                img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

                Dim img As iTextSharp.text.Image
                img = iTextSharp.text.Image.GetInstance(ms2.ToArray())
                'img.Alignment = Element.ALIGN_CENTER
                'img.ScaleToFit(New iTextSharp.text.Rectangle(500, 200))
                'img.ScalePercent(70) 'Ótimo valor
                img.ScalePercent(62)


                doc.Add(img)


            End With

        Next

        doc.Close()

        ' MsgBox("Prova gerada com sucesso")
        Dim form As New TestVIEW(caminho & "modelA4Prova.pdf")
        form.Show()

    End Sub



#End Region


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Gerar_Prova(PROVAATUAL)
        ImprimirProva()


    End Sub

    Private Sub AjudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjudaToolStripMenuItem.Click
        Dim fm As New ajuda_form
        fm.Show()

    End Sub

    
End Class