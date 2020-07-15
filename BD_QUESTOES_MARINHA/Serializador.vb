
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Collections

Module Serializador


    Public Class Serializador


        'funçao para salvar objetos como arquivos binários, serializa o objeto
        Public Shared Sub Serialize(ByVal path As String, ByVal file As Prova)

            Dim fs As New FileStream(path, FileMode.OpenOrCreate)
            Dim formatador As BinaryFormatter = New BinaryFormatter()

            formatador.Serialize(fs, file)
            fs.Close()




        End Sub


        'função para recuperar a lista de 'elements' salva como binario
        Public Shared Function Deserialize(ByVal path As String) As Prova

            Dim fs As New FileStream(path, FileMode.Open)
            Dim mfile As New Prova

            Dim formater As BinaryFormatter = New BinaryFormatter()


            mfile = formater.Deserialize(fs)
            fs.Close()

            Return mfile



        End Function

    End Class


End Module
