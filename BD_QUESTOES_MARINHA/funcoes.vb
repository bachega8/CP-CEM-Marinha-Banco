Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data


Public Class funcoes

    Public Shared Function ReturnCONECTION() As OleDbConnection
        ' variaveis para a comunicação com o banco de dados
        Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
        Dim dset As New DataSet()
        Dim olecon As New OleDbConnection(strcon)

        Return olecon
    End Function

    

    Public Shared Function comandoSQL(ByVal sql As String) As DataSet


        Dim dta As New DataTable("res")
        Dim dset As New DataSet
        dset.Tables.Add(dta)

        Dim cmd As New OleDbCommand()
        Dim oleada As New OleDbDataAdapter()


        oleada.SelectCommand = cmd
        oleada.SelectCommand.CommandText = sql
        oleada.SelectCommand.Connection = ReturnCONECTION()

        oleada.Fill(dset, dta.TableName)
        Return dset



    End Function

End Class
