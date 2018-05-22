Public Class Mantenimiento_empleados
    Public ctr As Base_de_datos = New Base_de_datos(Control_de_empleados.Trabajadores)
    Public modify As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim cod As Integer = CInt(TextBox1.Text)
        'Dim r As DataRow = ctr.EncontrarEmpleado(cod)
        'Try
        '    If Not IsNothing(r) Then

        '        TextBox1.ReadOnly = True

        '        TextBox2.Text = Convert.ToString(r("Nombre"))
        '        TextBox3.Text = Convert.ToString(r("Puesto"))
        '        TextBox4.Text = Convert.ToString(r("Edad"))
        '        TextBox5.Text = Convert.ToString(r("Sexo"))
        '        DateTimePicker1.Value = Convert.ToDateTime(r("Fecha_de_ingreso"))
        '        TextBox7.Text = Convert.ToString(r("Salario"))

        '        Panel1.Visible = True
        '    Else
        '        MsgBox("Código no existe", MsgBoxStyle.Exclamation, Title:="Vacío")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal")
        'End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        MsgBox("Campos listos para editar, modifique los que usted crea convenientes", MsgBoxStyle.Information, Title:="Aviso")
        modify = True
        Button1.Enabled = True

        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        TextBox4.ReadOnly = False
        TextBox5.ReadOnly = False
        DateTimePicker1.Enabled = True
        TextBox7.ReadOnly = False

        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False

    End Sub

    Private Sub Mantenimiento_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ctr.ConectarT()
        ctr.obTextbox(TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, DateTimePicker1, TextBox7)
        ctr.camposdatos()
        Label8.Text = "Posición " & ctr.Pos & " de " & ctr.oDataSet.Tables("Trabajadores").Rows.Count - 1

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        modify = False

        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        TextBox4.ReadOnly = False
        TextBox5.ReadOnly = False
        DateTimePicker1.Enabled = True
        TextBox7.ReadOnly = False

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        DateTimePicker1.Enabled = True
        TextBox7.Clear()

        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False

    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ctr.botonprimero()
        Label8.Text = "Posición " & ctr.Pos & " de " & ctr.oDataSet.Tables("Trabajadores").Rows.Count - 1

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ctr.botonanterior()
        Label8.Text = "Posición " & ctr.Pos & " de " & ctr.oDataSet.Tables("Trabajadores").Rows.Count - 1

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ctr.SigTrab()
        Label8.Text = "Posición " & ctr.Pos & " de " & ctr.oDataSet.Tables("Trabajadores").Rows.Count - 1

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ctr.UltTrabajadores()
        Label8.Text = "Posición " & ctr.Pos & " de " & ctr.oDataSet.Tables("Trabajadores").Rows.Count - 1

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ctr.ActualizarTrabajadores()
        MsgBox("Actualizado", MsgBoxStyle.Information, Title:="Bien hecho")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ctr.botoneliminar()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        DateTimePicker1.Enabled = False
        TextBox7.Clear()
        ctr.camposdatos()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Dim nombre, puesto, sexo As String
        Dim edad, codigo As Integer
        Dim salario As Double
        Dim fecha As Date

        codigo = CInt(TextBox1.Text)
        nombre = TextBox2.Text
        puesto = TextBox3.Text
        edad = CInt(TextBox4.Text)
        sexo = TextBox5.Text
        fecha = DateTimePicker1.Value
        salario = CDbl(TextBox7.Text)

        If modify Then

            ctr.ModificarTrabajadores(codigo, nombre, puesto, edad, sexo, fecha, salario)

            Button1.Enabled = False

            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            Button10.Enabled = True

        Else
            TextBox1.Text = Convert.ToString(ctr.NuevoEmpleado(nombre, puesto, edad, sexo, fecha, salario))

            Button1.Enabled = False

            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            Button10.Enabled = True

        End If
    End Sub
End Class