Imports System.Data.SqlClient
Public Class Datos

    Private Str As String = "Data Source=.;Initial Catalog=Ejercicio1;Integrated Security=True"

    Private Cnn As New SqlConnection(Str)
    Private Tranx As SqlTransaction
    Private Cmd As SqlCommand


    Public Function Leer(ByVal consulta As String, ByVal hdatos As Hashtable) As DataSet

        Dim Ds As New DataSet
        Cmd = New SqlCommand

        Cmd.Connection = Cnn
        Cmd.CommandText = consulta
        Cmd.CommandType = CommandType.StoredProcedure

        If Not hdatos Is Nothing Then

            'si la hashtable no esta vacia, y tiene el dato q busco 
            For Each dato As String In hdatos.Keys
                'cargo los parametros que le estoy pasando con la Hash
                Cmd.Parameters.AddWithValue(dato, hdatos(dato))
            Next
        End If

        Dim Adaptador As New SqlDataAdapter(Cmd)
        Adaptador.Fill(Ds)
        Return Ds

    End Function

    Public Function Escribir(ByVal consulta As String, ByVal hdatos As Hashtable) As Boolean

        If Cnn.State = ConnectionState.Closed Then
            Cnn.ConnectionString = Str
            Cnn.Open()
        End If

        Try
            Tranx = Cnn.BeginTransaction
            Cmd = New SqlCommand
            Cmd.Connection = Cnn
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Transaction = Tranx

            If Not hdatos Is Nothing Then

                For Each dato As String In hdatos.Keys
                    'cargo los parametros que le estoy pasando con la Hash
                    Cmd.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If

            Dim respuesta As Integer = Cmd.ExecuteNonQuery
            Tranx.Commit()
            Return True

        Catch ex As Exception
            Tranx.Rollback()
            Return False
        Finally
            Cnn.Close()
        End Try

    End Function

End Class
