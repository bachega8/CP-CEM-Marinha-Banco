

Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO

Public Class add_questao_form

    ' variaveis para a comunicação com o banco de dados
    Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
    Dim dset As New DataSet()
    Dim olecon As New OleDbConnection(strcon)

    Dim tb_assuntos As New DataTable("assuntos")
    Dim tb_questoes As New DataTable("questoes")
    Dim tb_cores As New DataTable("cores")

    Dim mode As Integer = 0
    Dim ID As Integer

    Sub New(Optional ByVal row As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        dset.Tables.Add(tb_assuntos)
        dset.Tables.Add(tb_questoes)
        dset.Tables.Add(tb_cores)


        Try


            olecon.Open()

            CarregaTemas()
            ' tema_cbox.SelectedIndex = 0


            olecon.Close()

        Catch ex As Exception
            MsgBox("Falha em conectar com o banco de dados :: " & ex.Message)
        End Try

        ano_cbox.SelectedIndex = 13

        CarregarAssuntos()

        CarregarCores()
        cores_cbox.SelectedIndex = 0

        img_button.Enabled = False

        If row IsNot Nothing Then

            mode = 1

            TextBox1.Enabled = False
            Button2.Enabled = False

            ID = row.Cells(0).Value

            ano_cbox.Text = row.Cells(1).Value.ToString
            NumericUpDown1.Value = row.Cells(2).Value
            tema_cbox.SelectedValue = row.Cells(6).Value
            CarregarAssuntos()
            cbox_assuntos.SelectedValue = row.Cells(7).Value
            TextBox2.Text = row.Cells(8).Value.ToString

            Button1.Text = "Atualizar"

            img_button.Enabled = True

        End If

    End Sub

    Private Sub add_questao_form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub

    Private Sub add_questao_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        
    End Sub


    Private Sub CarregaTemas()
        Try

            Dim sql As String
            sql = "SELECT * FROM tbtemas ORDER BY descricao;"


            Dim ddset As DataSet = funcoes.comandoSQL(sql)

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

    Private Sub CarregarCores()

        tb_cores.Clear()

        Try

            Dim sql As String
            sql = "SELECT * FROM tbcores"

            Dim cmd As New OleDbCommand()
            Dim oleada As New OleDbDataAdapter()


            oleada.SelectCommand = cmd
            oleada.SelectCommand.CommandText = sql
            oleada.SelectCommand.Connection = olecon

            oleada.Fill(dset, tb_cores.TableName)

            Dim bindin As New BindingSource()
            bindin.DataSource = dset
            bindin.DataMember = tb_cores.TableName

            cores_cbox.DataSource = bindin
            cores_cbox.DisplayMember = "descricao"
            cores_cbox.ValueMember = "ID"


            cores_cbox.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try


    End Sub

    Private Sub tema_cbox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles tema_cbox.SelectionChangeCommitted

       

                CarregarAssuntos()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

        Dim op As New OpenFileDialog() 'With {.Filter = "Bmp (*.bmp)|*.bmp"}

        If op.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = op.FileName

        Else
            Exit Sub

        End If

        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try

    End Sub

    Private Sub CadastrarQuestao()


        Dim sql As String
        sql = "INSERT INTO tbquestoes(ano, numero, cod_cor, cod_assunto, file, gabarito) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)"

        Dim cmd As New OleDbCommand()
        Dim oleada As New OleDbDataAdapter()

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = olecon

        With cmd.Parameters
            .AddWithValue("@p1", Convert.ToInt16(ano_cbox.Text))
            .AddWithValue("@p2", NumericUpDown1.Value)
            .AddWithValue("@p3", cores_cbox.SelectedValue)
            .AddWithValue("@p4", cbox_assuntos.SelectedValue)

            'adição da imagem
            Dim img As Bitmap
            img = Bitmap.FromFile(TextBox1.Text)

            Dim ms As New IO.MemoryStream
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            Dim bytearray = ms.ToArray

            .AddWithValue("@p5", bytearray)

            .AddWithValue("@p6", TextBox2.Text)

        End With

        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()



        MsgBox("Questão Inserida com Sucesso")



    End Sub

    Private Sub AtualizarQuestao()

        Dim sql As String
        sql = "UPDATE tbquestoes SET ano = @p1, numero = @p2, cod_cor = @p3, cod_assunto = @p4, gabarito = @p5 WHERE ID = @p6"

        Dim cmd As New OleDbCommand()
        Dim oleada As New OleDbDataAdapter()

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = olecon

        With cmd.Parameters
            .AddWithValue("@p1", Convert.ToInt16(ano_cbox.Text))
            .AddWithValue("@p2", NumericUpDown1.Value)
            .AddWithValue("@p3", cores_cbox.SelectedValue)
            .AddWithValue("@p4", cbox_assuntos.SelectedValue)
            .AddWithValue("@p5", TextBox2.Text)
            .AddWithValue("@p6", ID)

        End With

        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()



        MsgBox("Questão Atualizada com Sucesso")

    End Sub


   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If mode = 0 Then
            CadastrarQuestao()
        Else
            AtualizarQuestao()
        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles img_button.Click

        If img_button.Enabled = True Then
            Dim aux As New Gabarito_Imagem_form(ID)
            aux.ShowDialog()
        Else
            MsgBox("Para inserir o a gabarito-imagem é preciso cadastrar a questão", MsgBoxStyle.Exclamation)

        End If

       

    End Sub
End Class