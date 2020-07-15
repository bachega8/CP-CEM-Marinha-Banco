
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO

Public Class mainform

    ' variaveis para a comunicação com o banco de dados
    Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
    Dim dset As New DataSet()
    Dim olecon As New OleDbConnection(strcon)

    Dim tb_assuntos As New DataTable("assuntos")
    Dim tb_questoes As New DataTable("questoes")

    'bindingsources
    Dim bd_questoes As New BindingSource()


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



    End Sub

    Private Sub mainform_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim aux As New add_questao_form
            aux.Show()

        ElseIf e.KeyCode = Keys.F5 Then
            CarregarQuestoes()
            CarregaTemas()
            CarregarAssuntos()

        ElseIf e.KeyCode = Keys.F3 Then
            Dim aux As New Assunto_form
            aux.ShowDialog()

        ElseIf e.KeyCode = Keys.F2 Then
            Dim aux As New add_tema_form
            aux.ShowDialog()

        ElseIf e.KeyCode = Keys.Enter Then
            Filter()
        End If
    End Sub


    Private Sub mainform_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dset.Tables.Add(tb_assuntos)
        dset.Tables.Add(tb_questoes)


        Try


            olecon.Open()

            CarregaTemas()
            ' tema_cbox.SelectedIndex = 0
            CarregarQuestoes()

            olecon.Close()

        Catch ex As Exception
            MsgBox("Falha em conectar com o banco de dados :: " & ex.Message)
        End Try

        ano_cbox.SelectedIndex = 10

        CarregarAssuntos()

        ano_cbox.Focus()

        total_lbl.Text = dg_main.RowCount.ToString


    End Sub


    Private Sub CarregaTemas()
        Try

            Dim sql As String
            sql = "SELECT * FROM tbtemas ORDER BY descricao;"


            Dim ddset As DataSet = funcoes.comandoSQL(sql)

            ddset.Tables(0).Rows.Add(6666, "selecionar todos") 'teste

            Dim bindin As New BindingSource()
            bindin.DataSource = ddset
            bindin.DataMember = ddset.Tables(0).TableName


            tema_cbox.DataSource = bindin
            tema_cbox.DisplayMember = "descricao"
            tema_cbox.ValueMember = "ID"


            tema_cbox.Refresh()



        Catch ex As Exception
            MsgBox("Falha em atualizar temas :: " & ex.Message)
        End Try
    End Sub

    Private Sub CarregarAssuntos()

        tb_assuntos.Clear()

        Try


            Dim sql As String
            sql = "SELECT * FROM tbassuntos WHERE cod_tema = @p1 ORDER BY descricao;"

            Dim cmd As New OleDbCommand()
            Dim oleada As New OleDbDataAdapter()

            cmd.Parameters.AddWithValue("@p1", tema_cbox.SelectedValue)


            oleada.SelectCommand = cmd
            oleada.SelectCommand.CommandText = sql
            oleada.SelectCommand.Connection = olecon

            oleada.Fill(dset, tb_assuntos.TableName)

            dset.Tables(0).Rows.Add(6666, 1, "selecionar todos") 'teste



            Dim bindin As New BindingSource()
            bindin.DataSource = dset
            bindin.DataMember = tb_assuntos.TableName

            cbox_assuntos.DataSource = bindin
            cbox_assuntos.DisplayMember = "descricao"
            cbox_assuntos.ValueMember = "ID"


            cbox_assuntos.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try

    End Sub

    Private Sub CarregarQuestoes()

        tb_questoes.Clear()

        Try

            Dim sql As String
            sql = "SELECT tbquestoes.ID, tbquestoes.ano, tbquestoes.numero, tbcores.descricao, " _
                & "tbassuntos.descricao, tbtemas.descricao, tbassuntos.cod_tema, tbassuntos.ID, tbquestoes.gabarito FROM tbquestoes, tbcores, tbassuntos, tbtemas WHERE " _
                & "tbquestoes.cod_cor = tbcores.ID AND tbquestoes.cod_assunto = tbassuntos.ID AND tbassuntos.cod_tema = tbtemas.ID "

            Dim cmd As New OleDbCommand()
            Dim oleada As New OleDbDataAdapter()


            oleada.SelectCommand = cmd
            oleada.SelectCommand.CommandText = sql
            oleada.SelectCommand.Connection = olecon

            oleada.Fill(dset, tb_questoes.TableName)

            bd_questoes.DataSource = dset
            bd_questoes.DataMember = tb_questoes.TableName

            dg_main.DataSource = bd_questoes

            With dg_main
                .Columns(0).Width = 40
                .Columns(0).HeaderText = "ID"
                .Columns(1).Width = 50
                .Columns(1).HeaderText = "Ano"
                .Columns(2).Width = 40
                .Columns(2).HeaderText = "Num."
                .Columns(3).HeaderText = "Cor"
                .Columns(3).Width = 70
                .Columns(4).Width = 180
                .Columns(4).HeaderText = "Assunto"
                .Columns(5).Width = 120
                .Columns(5).HeaderText = "Tema"

                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False

            End With
          
        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try



    End Sub


    Private Sub CarregaImagem(ByVal ID_questao As Long)
        Try

            Dim sql As String
            sql = "SELECT file FROM tbquestoes WHERE ID = @cod;"

            Dim cmd As New OleDbCommand()
            cmd.Connection = olecon
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            ' MsgBox(codQ)
            cmd.Parameters.AddWithValue("@cod", ID_questao)

          

            Try
                olecon.Open()
                If cmd.ExecuteScalar() Is DBNull.Value Then
                    olecon.Close()
                Else

                    Dim imagem As Byte() = CType(cmd.ExecuteScalar(), Byte())

                    Dim imc As New ImageConverter()

                    ' carrega imagem no picture box
                    Dim img As Image
                    Dim img2 As Bitmap

                    img = imc.ConvertFrom(imagem)

                    'img = Image.FromFile(strarquivo)
                    img2 = New Bitmap(img)
                    ' img.Dispose()

                    PictureBox1.Image = img2

                    olecon.Close()

                End If


            Catch ex As Exception
                MsgBox("Erro na passagem da imagem :: " & ex.Message)
                olecon.Close()
            End Try

        Catch ex As Exception
            MsgBox("Falha em carregar Imagem :: " & ex.Message)
            olecon.Close()
        End Try
    End Sub


    Private Sub Filter()

        bd_questoes.RemoveFilter()


        Dim codtema, codassunto As Long
        Dim ano As String

        ano = ano_cbox.Text
        codtema = tema_cbox.SelectedValue
        codassunto = cbox_assuntos.SelectedValue

        If ano = "todos" Then

            If codtema = 6666 Then
                bd_questoes.RemoveFilter()

            Else

                If codassunto = 6666 Then
                    bd_questoes.Filter = "cod_tema = '" & codtema & "'"
                Else
                    bd_questoes.Filter = "cod_tema = '" & codtema & "' AND " & "tbassuntos.ID = '" & codassunto & "'"
                End If



            End If


        Else


            If codtema = 6666 Then
                bd_questoes.Filter = "ano = '" & ano & "'"

            Else

                If codassunto = 6666 Then
                    bd_questoes.Filter = "ano = '" & ano & "'" & " AND " & "cod_tema = '" & codtema & "'"
                Else
                    bd_questoes.Filter = "ano = '" & ano & "'" & " AND " & "cod_tema = '" & codtema & "' AND " & "tbassuntos.ID = '" & codassunto & "'"
                End If



            End If


        End If






    End Sub
    
   

    Private Sub tema_cbox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles tema_cbox.SelectionChangeCommitted

        cbox_assuntos.Enabled = True

        If tema_cbox.SelectedIndex <> -1 Then
            If tema_cbox.SelectedValue = 6666 Then
                cbox_assuntos.SelectedIndex = -1

                cbox_assuntos.Enabled = False
            Else

                CarregarAssuntos()
            End If

        End If
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Filter()


        total_lbl.Text = dg_main.RowCount.ToString

    End Sub

    Private Sub dg_main_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_main.Click
        Try

       
        CarregaImagem(dg_main.Item(0, dg_main.CurrentRow.Index).Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim sv As New SaveFileDialog() With {.Filter = "Bmp (*.bmp)|*.bmp"}
            If sv.ShowDialog() = DialogResult.OK Then

                PictureBox1.Image.Save(sv.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                MsgBox("Imagem salva com sucesso")

            End If


        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try
    End Sub

    Private Sub QuestãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestãoToolStripMenuItem.Click
        Dim aux As New add_questao_form
        aux.Show()

    End Sub

    Private Sub AtualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtualizarToolStripMenuItem.Click
        CarregarQuestoes()
        CarregaTemas()
        CarregarAssuntos()

        total_lbl.Text = dg_main.RowCount.ToString

    End Sub

    

    Private Sub AutoFitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoFitToolStripMenuItem.Click
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize

    End Sub

    Private Sub ZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem.Click
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub StrechtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrechtToolStripMenuItem.Click
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub CenterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterToolStripMenuItem.Click
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalToolStripMenuItem.Click
        PictureBox1.SizeMode = PictureBoxSizeMode.Normal

    End Sub

    Private Sub TemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TemaToolStripMenuItem.Click
        Dim aux As New add_tema_form
        aux.ShowDialog()

    End Sub

    Private Sub AssuntoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssuntoToolStripMenuItem.Click
        Dim aux As New Assunto_form
        aux.ShowDialog()

    End Sub

    Private Sub GeradorDeProvasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeradorDeProvasToolStripMenuItem.Click
        Dim aux As New Ger_Prova_form
        aux.Show()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click


        If dg_main.SelectedRows.Count = 0 Then
            MsgBox("Selecione a questão que deseja remover", MsgBoxStyle.Exclamation)
            Exit Sub

        End If

        If MsgBox("Tem certeza que deseja remover a questão selecionada?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try


                Dim sql As String
                sql = "DELETE FROM tbquestoes WHERE ID = @p1;"

                Dim cmd As New OleDbCommand()

                cmd.Connection = olecon
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@p1", dg_main.Item(0, dg_main.CurrentRow.Index).Value)

                olecon.Open()
                cmd.ExecuteNonQuery()
                olecon.Close()


            Catch ex As Exception
                MsgBox(ex.Message, 0 + 16)
            End Try

        End If



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim aux As New add_questao_form(dg_main.CurrentRow)
        aux.ShowDialog()


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("GABARITO: " & dg_main.Item(8, dg_main.CurrentRow.Index).Value.ToString)

    End Sub

    Private Sub SobreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SobreToolStripMenuItem.Click
        MsgBox("Esse software foi desenvolvido por Matheus Castro Bachega em agosto de 2018. O objetivo " _
               & "principal é ajudar na organização dos estudos. Embora utilizado para Marinha-CEM, " _
               & "pode também ser utilizado para outros concursos. Além disso, pode-se adicionar outros cursos " _
               & "como engenharia de produção, elétrica, etc. Contato: (22) 999461148. email: matheus.bachega@uol.com.br. Façam bom proveito!")

    End Sub

    
    Private Sub ano_cbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ano_cbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Filter()


            total_lbl.Text = dg_main.RowCount.ToString
        End If
    End Sub
End Class
