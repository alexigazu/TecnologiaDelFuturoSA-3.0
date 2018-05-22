Public Class Vista_por_código
    Public C As Base_de_datos = New Base_de_datos(Control_de_empleados.Trabajadores)
    Public A As Arbolbinario
    Private Sub Vista_por_código_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        i = Control_de_empleados.Trabajadores.Tables("Trabajadores").Rows.Count() - 1
        For m As Integer = 0 To i
            A.AgregarNodo(C.oDataSet.Tables("Trabajadores").Rows(i))
        Next
        Dim x As Integer = 70 * Math.Pow(2, A.Alt(A.raiz) - 1)
        A.dibujarLista(A.raiz, 2048, 10, 1024)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Label1.Text = "" & L.
    End Sub

End Class