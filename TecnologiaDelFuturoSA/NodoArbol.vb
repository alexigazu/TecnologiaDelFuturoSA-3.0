Public Class Nodos
    Public datos As DataRow
    Public izq As Nodos
    Public der As Nodos

    Public Sub New(ByVal d As DataRow)

        Me.datos = d
        Me.izq = Nothing
        Me.der = Nothing

    End Sub
End Class
