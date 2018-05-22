Public Class Mantenimiento_de_pagos
    Public Con As Base_de_datos = New Base_de_datos(Control_de_empleados.PagosRealizados)
    Private Sub Mantenimiento_de_pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Con.ConectarT()
        Con.obTextbox(TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, DateTimePicker1)
        Con.camposPagos()
        Label11.Text = "Posición " & Con.Pos & " de " & Con.oDataSet.Tables("PagosRealizados").Rows.Count - 1
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Con.botonprimeropago()
        Label11.Text = "Posición " & Con.Pos & " de " & Con.oDataSet.Tables("PagosRealizados").Rows.Count - 1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Con.botonanteriorPagos()
        Label11.Text = "Posición " & Con.Pos & " de " & Con.oDataSet.Tables("PagosRealizados").Rows.Count - 1
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Con.SigPagos()
        Label11.Text = "Posición " & Con.Pos & " de " & Con.oDataSet.Tables("PagosRealizados").Rows.Count - 1
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Con.UltPagos()
        Label11.Text = "Posición " & Con.Pos & " de " & Con.oDataSet.Tables("PagosRealizados").Rows.Count - 1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Con.botoneliminarPago()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Con.ActualizarPago()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MsgBox("Campos listos para editar, modifique los que usted crea convenientes", MsgBoxStyle.Information, Title:="Aviso")

        Button1.Enabled = False

        TextBox2.ReadOnly = False
        DateTimePicker1.Enabled = True


        Button2.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fechaP As Date
        Dim cod As Integer
        fechaP = DateTimePicker1.Value
        cod = TextBox2.Text

    End Sub
End Class