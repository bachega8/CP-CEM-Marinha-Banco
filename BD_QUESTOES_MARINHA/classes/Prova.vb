
Imports BD_QUESTOES_MARINHA.ItemProva


<Serializable()> Public Class Prova


    Private itens As New List(Of ItemProva)
    Private nome As String


    Public Property NOME_PROVA() As String
        Get
            Return nome
        End Get
        Set(ByVal value As String)
            nome = value
        End Set
    End Property


    Public Property ITENS_PROVA() As List(Of ItemProva)
        Get
            Return itens
        End Get
        Set(ByVal value As List(Of ItemProva))
            itens = value
        End Set
    End Property



End Class
