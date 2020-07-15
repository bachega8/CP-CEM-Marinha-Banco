

Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO


Public Class add_tema_form

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

        CarregaTemas()

    End Sub

    Private Sub add_tema_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CarregaTemas()
        Try

            Dim sql As String
            sql = "SELECT * FROM tbtemas;"

            Dim ddset As DataSet = funcoes.comandoSQL(sql)

            Dim bindin As New BindingSource()
            bindin.DataSource = ddset
            bindin.DataMember = ddset.Tables(0).TableName

            dg_temas.DataSource = bindin

            With dg_temas
                .Columns(0).HeaderText = "ID"
                .Columns(0).Width = 30
                .Columns(1).HeaderText = "Descrição"
                .Columns(1).Width = 200
            End With


        Catch ex As Exception
            MsgBox("Falha em atualizar temas :: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim nome As String = InputBox("Título do Tema")

        Dim sql As String = "INSERT INTO tbtemas(descricao) VALUES (@p1)"


        Dim cmd As New OleDbCommand()
        Dim oleada As New OleDbDataAdapter()

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = olecon

        With cmd.Parameters
            .AddWithValue("@p1", nome)
        End With

        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()



        MsgBox("Tema Inserido com Sucesso")

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        If dg_temas.SelectedRows.Count = 0 Then

            MsgBox("selecione o tema desejado para remoção", MsgBoxStyle.Exclamation)
            Exit Sub
        End If




        If MsgBox("Tem certeza que deseja remover este TEMA?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim sql As String = "DELETE FROM tbtemas WHERE ID = @p1"
            Dim id As Long = dg_temas.Item(0, dg_temas.CurrentRow.Index).Value

            Dim cmd As New OleDbCommand()
            Dim oleada As New OleDbDataAdapter()

            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            cmd.Connection = olecon

            With cmd.Parameters
                .AddWithValue("@p1", id)
            End With

            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()


            MsgBox("Tema removido com Sucesso")
        End If

       


    End Sub
End Class