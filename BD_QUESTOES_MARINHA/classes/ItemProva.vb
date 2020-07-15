

<Serializable()> Public Class ItemProva

    Private numq As Long
    Private anoo As Long
    Private codassunto As Long
    Private codtema As Long

    'nome do assunto
    Private nme As String
    Private nmetema As String

    Sub New(ByVal _numquestoes As Long, ByVal _ano As Long, ByVal _codassunto As Long, _
            ByVal _codtema As Long, ByVal _nme As String, ByVal _nmetema As String)

        NUM_QUESTOES = _numquestoes
        ANO = _ano
        COD_ASSUNTO = _codassunto
        NOME_ASSUNTO = _nme
        COD_TEMA = _codtema
        NOME_TEMA = _nmetema

    End Sub


    Public Property NOME_TEMA() As String
        Get
            Return nmetema
        End Get
        Set(ByVal value As String)
            nmetema = value
        End Set
    End Property

    Public Property COD_TEMA() As Long
        Get
            Return codtema
        End Get
        Set(ByVal value As Long)
            codtema = value
        End Set
    End Property


    Public Property NOME_ASSUNTO() As String
        Get
            Return nme
        End Get
        Set(ByVal value As String)
            nme = value
        End Set
    End Property

    Public Property COD_ASSUNTO() As Long
        Get
            Return codassunto
        End Get
        Set(ByVal value As Long)
            codassunto = value
        End Set
    End Property

    Public Property ANO() As Long
        Get
            Return anoo
        End Get
        Set(ByVal value As Long)
            anoo = value
        End Set
    End Property

    Public Property NUM_QUESTOES() As Long
        Get
            Return numq
        End Get
        Set(ByVal value As Long)
            numq = value
        End Set
    End Property



End Class
