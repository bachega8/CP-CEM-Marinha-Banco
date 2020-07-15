

Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO

Public Class Assunto_form

    ' variaveis para a comunicação com o banco de dados
    Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
    Dim dset As New DataSet()
    Dim olecon As New OleDbConnection(strcon)

    Dim tb_assuntos As New DataTable("assuntos")


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CarregaAssuntos()

    End Sub

  
    Private Sub Assunto_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub

    Private Sub CarregaAssuntos()
        Try

            Dim sql As String
            sql = "SELECT tbassuntos.ID, tbtemas.descricao, tbassuntos.descricao FROM " _
                & "tbassuntos, tbtemas WHERE tbassuntos.cod_tema = tbtemas.ID"

            Dim ddset As DataSet = funcoes.comandoSQL(sql)

            Dim bindin As New BindingSource()
            bindin.DataSource = ddset
            bindin.DataMember = ddset.Tables(0).TableName

            dg_assuntos.DataSource = bindin

            With dg_assuntos
                .Columns(0).HeaderText = "ID"
                .Columns(0).Width = 40
                .Columns(1).HeaderText = "Tema"
                .Columns(1).Width = 150

                .Columns(2).HeaderText = "Assunto"
                .Columns(2).Width = 270
            End With


        Catch ex As Exception
            MsgBox("Falha em atualizar assuntos :: " & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dg_assuntos.SelectedRows.Count = 0 Then

            MsgBox("selecione o assunto desejado para remoção", MsgBoxStyle.Exclamation)
            Exit Sub
        End If




        If MsgBox("Tem certeza que deseja remover este ASSUNTO?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try

            

            Dim sql As String = "DELETE FROM tbassuntos WHERE ID = @p1"
            Dim id As Long = dg_assuntos.Item(0, dg_assuntos.CurrentRow.Index).Value

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


                MsgBox("Assunto removido com Sucesso")

            Catch ex As Exception
                MsgBox(ex.Message, 0 + 16)
            End Try
        End If



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aux As New add_assunto_form
        aux.ShowDialog()

    End Sub
End Class