
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO
Imports BD_QUESTOES_MARINHA.ItemProva


Public Class ItemProva_form

    Public Delegate Sub Params(ByVal itprovas As ItemProva)
    Public Event ENVIAR As Params


    ' variaveis para a comunicação com o banco de dados
    Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
    Dim dset As New DataSet()
    Dim olecon As New OleDbConnection(strcon)

    Dim tb_assuntos As New DataTable("assuntos")
    Dim tb_questoes As New DataTable("questoes")


    Private Sub ItemProva_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dset.Tables.Add(tb_assuntos)
        dset.Tables.Add(tb_questoes)


        Try

            olecon.Open()

            CarregaTemas()
            ' tema_cbox.SelectedIndex = 0

            olecon.Close()

        Catch ex As Exception
            MsgBox("Falha em conectar com o banco de dados :: " & ex.Message)
        End Try

        ano_cbox.SelectedIndex = 10

        CarregarAssuntos()

        ano_cbox.Focus()

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

        Dim codassunto, ano, numquestoes As Long

        codassunto = cbox_assuntos.SelectedValue

        If ano_cbox.Text = "todos" Then
            ano = -1
        Else
            ano = Convert.ToInt16(ano_cbox.Text)
        End If

        numquestoes = NumericUpDown1.Value

        Dim obj As New ItemProva(numquestoes, ano, codassunto, tema_cbox.SelectedValue, cbox_assuntos.Text, tema_cbox.Text)

        RaiseEvent ENVIAR(obj)
        ' Me.Close()


    End Sub
End Class