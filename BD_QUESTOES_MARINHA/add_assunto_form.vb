

Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO

Public Class add_assunto_form


    ' variaveis para a comunicação com o banco de dados
    Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
    Dim dset As New DataSet()
    Dim olecon As New OleDbConnection(strcon)

    Dim tb_temas As New DataTable("temas")

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CarregaTemas()
        ComboBox1.SelectedIndex = 0


    End Sub


    Private Sub add_assunto_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub CarregaTemas()
        Try

            Dim sql As String
            sql = "SELECT * FROM tbtemas ORDER BY descricao;"


            Dim ddset As DataSet = funcoes.comandoSQL(sql)

           
            Dim bindin As New BindingSource()
            bindin.DataSource = ddset
            bindin.DataMember = ddset.Tables(0).TableName


            ComboBox1.DataSource = bindin
            ComboBox1.DisplayMember = "descricao"
            ComboBox1.ValueMember = "ID"


            ComboBox1.Refresh()



        Catch ex As Exception
            MsgBox("Falha em atualizar temas :: " & ex.Message)
        End Try
    End Sub


    Private Sub InserirAssunto()

        Try

            Dim sql As String = "INSERT INTO tbassuntos(cod_tema, descricao) VALUES (@p1, @p2)"


        Dim cmd As New OleDbCommand()
        Dim oleada As New OleDbDataAdapter()

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = olecon

        With cmd.Parameters
                .AddWithValue("@p1", ComboBox1.SelectedValue)
                .AddWithValue("@p2", TextBox1.Text)
        End With

        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()



            MsgBox("Assunto Inserido com Sucesso")


        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        InserirAssunto()

    End Sub
End Class