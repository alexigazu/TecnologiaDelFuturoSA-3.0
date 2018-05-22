Imports System.Data.SqlClient
Public Class Control_de_empleados
    Public Control As Base_de_datos
    Public Salarios As Contabilidad = New Contabilidad
    Public Fpago As Date
    Public salario As Double
    Public Pagados(), i, h As Integer

    Private Sub Control_de_empleados_FormClosing(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.PagosRealizados.EndInit()
        Me.PagosRealizados.Dispose()

        Me.Trabajadores.EndInit()
        Me.Trabajadores.Dispose()
    End Sub
    Private Sub Control_de_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'EmpleadosDataSet1.PagosRealizados' table. You can move, or remove it, as needed.
        PagosRealizados.EnforceConstraints = False
        Me.PagosRealizadosTableAdapter.Fill(Me.PagosRealizados.PagosRealizados)

        'TODO: This line of code loads data into the 'EmpleadosDataSet.Trabajadores' table. You can move, or remove it, as needed.
        Trabajadores.EnforceConstraints = False
        Me.TrabajadoresTableAdapter.Fill(Me.Trabajadores.Trabajadores)
        Control = New Base_de_datos(PagosRealizados) ', PagosRealizadosTableAdapter)
        Control.Conectar()

        ReDim Pagados(Me.Trabajadores.Tables("Trabajadores").Rows.Count() - 1)
    End Sub

    
    
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GenerarSueldoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarSueldoToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = True
        GroupBox3.Visible = False

        TextBox19.ReadOnly = False
        TextBox19.Clear()

        TextBox1.Focus()

        TextBox4.Clear()
        TextBox5.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()

        Label23.Text = ""

        Button3.Enabled = True
        Button4.Enabled = False

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cod As Integer = CInt(TextBox1.Text)
            Dim l As Boolean
            h = CInt(TextBox2.Text)
            Dim w As DataRow = Control.EncontrarEmpleado(cod)

            For k As Integer = 0 To i
                Pagados(k) = cod
                l = True
                Exit For
            Next

            If l Or Not IsNothing(w) Or h < 8 And Not (DateTimePicker1.Value.Day >= 1 And DateTimePicker1.Value.Day <= 8) Then

                Fpago = DateTimePicker1.Value

                TextBox1.ReadOnly = True
                TextBox2.ReadOnly = True

                TextBox3.Text = Convert.ToString(w("Salario"))
                TextBox7.Text = Convert.ToString(w("Nombre"))
                TextBox8.Text = Convert.ToString(w("Puesto"))

                salario = CDbl(TextBox3.Text)

                TextBox6.Text = CStr(Salarios.CalcularNeto(salario, Fpago, h))

                Pagados(i) = cod
                i += 1

                Button1.Enabled = False
                Button2.Enabled = True

                Control.NuevoPago(cod, Salarios.INSS(salario), Salarios.Medico(salario), Salarios.Renta(salario), Salarios.Vacaciones(salario), Salarios.CalcularExtras(h, salario), Salarios.Aguinaldo(salario, Fpago), Convert.ToDouble(TextBox6.Text), Fpago)

                TextBox18.Text = Convert.ToString(Control.EncontrarNombrePago(cod)("cod_pago"))

            Else
                MsgBox("Error: verifique que las horas extras sean menor a 8, que la fecha sea entre el 1° y el 8 del mes, que el usuario no haya cobrado o que el código esté correcto", MsgBoxStyle.Exclamation, Title:="Búsqueda terminada")

                TextBox1.Clear()
                TextBox2.Clear()

                TextBox1.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal.")
        End Try

    End Sub

   
   
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            TextBox1.ReadOnly = False
            TextBox2.ReadOnly = False

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()

            TextBox1.Focus()

            Button2.Enabled = False
            Button1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal")
        End Try
    End Sub

    Private Sub GenerarColillaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarColillaToolStripMenuItem.Click

        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = True

        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = False

        TextBox19.Focus()

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox18.Clear()

        TextBox1.Focus()

        Button1.Enabled = True
        Button2.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim cod As Integer = CInt(TextBox19.Text)
            Dim s As Double
            Dim w As DataRow
            Dim z As DataRow = Control.EncontrarPago(cod)

            If Not IsNothing(z) Then
                w = Control.EncontrarEmpleado(z("cod_empleado"))

                TextBox19.ReadOnly = True

                TextBox9.Text = Convert.ToString(w("Id"))
                TextBox10.Text = Convert.ToString(w("Puesto"))
                TextBox11.Text = Convert.ToString(w("Nombre"))
                TextBox13.Text = Convert.ToString(w("Salario"))

                s = Convert.ToDouble(TextBox13.Text)

                TextBox4.Text = Convert.ToString(z("inss_laboral"))
                TextBox5.Text = Convert.ToString(z("seguro_medico"))
                TextBox14.Text = Convert.ToString(z("Renta"))
                TextBox17.Text = Convert.ToString(z("Vacaciones"))
                TextBox16.Text = Convert.ToString(z("Horas_extras"))
                TextBox15.Text = Convert.ToString(z("Aguinaldo"))
                TextBox12.Text = Convert.ToString(z("Salario_neto"))

                Label23.Text = "Fecha de pago: " & Convert.ToString(z("Fecha"))

                Button3.Enabled = False
                Button4.Enabled = True

            Else
                MsgBox("El código no existe o no ha cobrado sueldo", MsgBoxStyle.Exclamation, Title:="Error")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Ups, algo salió mal")
        End Try

    End Sub

    
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        TextBox19.ReadOnly = False
        TextBox19.Focus()

        TextBox4.Clear()
        TextBox5.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox19.Clear()

        Label23.Text = ""

        Button3.Enabled = True
        Button4.Enabled = False
    End Sub

 
    Private Sub PorCódigoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorCódigoToolStripMenuItem.Click
        Vista_por_antigüedad.Show()
    End Sub

    Private Sub ManteminientoAEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManteminientoAEmpleadosToolStripMenuItem.Click
        Mantenimiento_empleados.Show()
    End Sub

    Private Sub MantenimientoPagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoPagoToolStripMenuItem.Click
        Mantenimiento_de_pagos.Show()
    End Sub

    Private Sub PorAntigüedadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorAntigüedadToolStripMenuItem.Click
        Vista_por_código.Show()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If Not (DateTimePicker1.Value.Day >= 1 And DateTimePicker1.Value.Day <= 8) Then
            MsgBox("Los días de pago son entre el 1° y el 5 de cada mes. Introduzca una fecha válida", MsgBoxStyle.Information, Title:="Advertencia")
            DateTimePicker1.Value = #11/1/2017#
        Else

        End If
    End Sub
End Class