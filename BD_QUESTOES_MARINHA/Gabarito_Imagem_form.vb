
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data

Imports System.IO



Public Class Gabarito_Imagem_form


    ' variaveis para a comunicação com o banco de dados
    Dim strcon As String = ConfigurationManager.ConnectionStrings("dbcon").ConnectionString
    Dim dset As New DataSet()
    Dim olecon As New OleDbConnection(strcon)

    Dim id As Long

    Dim strfile As String

    Sub New(ByVal ID_questao As Long)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        id = ID_questao


    End Sub

    Private Sub Gabarito_Imagem_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CarregaImagem(id)


    End Sub

    Private Sub CarregaImagem(ByVal ID_questao As Long)


        Try

            Dim sql As String
            sql = "SELECT gabarito2 FROM tbquestoes WHERE ID = @cod;"

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
                    Label1.Visible = True
                Else
                    Label1.Visible = False
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

    Private Sub AbrirImagemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirImagemToolStripMenuItem.Click
        Try

            Dim op As New OpenFileDialog() 'With {.Filter = "Bmp (*.bmp)|*.bmp"}

            If op.ShowDialog() = DialogResult.OK Then
                strfile = op.FileName

                Dim img As Bitmap
                img = Bitmap.FromFile(strfile)

                PictureBox1.Image = img
                Label1.Visible = False
            Else
                Exit Sub

            End If

        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try

    End Sub

    Private Sub SalvarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarToolStripMenuItem.Click

        If strfile = "" Then
            MsgBox("Não há imagem para inserir", 0 + 16)
            Exit Sub
        End If

        Dim sql As String
        sql = "UPDATE tbquestoes SET gabarito2 = @p1 WHERE ID = @p2"

        Dim cmd As New OleDbCommand()
        Dim oleada As New OleDbDataAdapter()

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = olecon

        With cmd.Parameters
            
            'adição da imagem
            Dim img As Bitmap
            img = Bitmap.FromFile(strfile)

            Dim ms As New IO.MemoryStream
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            Dim bytearray = ms.ToArray

            .AddWithValue("@p1", bytearray)

            .AddWithValue("@p2", id)

        End With

        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()



        MsgBox("Imagem Inserida com Sucesso")


    End Sub

    Private Sub RemoverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoverToolStripMenuItem.Click

        If PictureBox1.Image Is Nothing Then
            MsgBox("Não foi possível realizar esta operação", 0 + 16)
            Exit Sub
        End If

        If MsgBox("Tem certeza que deseja remover a imagem?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try


                Dim sql As String
                sql = "UPDATE tbquestoes SET gabarito2 = Null WHERE ID = @p1"

                Dim cmd As New OleDbCommand()

                cmd.Connection = olecon
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@p1", id)

                olecon.Open()
                cmd.ExecuteNonQuery()
                olecon.Close()

                MsgBox("Imagem removida!")
                strfile = ""

                PictureBox1.Image = Nothing

                Label1.Visible = True

            Catch ex As Exception
                MsgBox(ex.Message, 0 + 16)
            End Try

        End If

    End Sub
End Class