Imports System.Data.SqlClient
Public Class Base_de_datos

    Public conexion As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Empleados.mdf;Integrated Security=True;Connect Timeout=30"
    Public adaptadordedatos As SqlDataAdapter = New SqlDataAdapter
    Public TA As New EmpleadosDataSet1TableAdapters.PagosRealizadosTableAdapter
    Public tabladedatos As New DataTable
    Public tablas, monto, operador, vendedor As String
    Public tabla As DataGridView ', tablaventas, tablapagos
    Public transaccion As New BindingSource
    Public Pos, patron, newcode As Integer
    Public oDataSet As DataSet
    Public oCommBuild As SqlCommandBuilder
    Public oconexion As SqlConnection = New SqlConnection
    Private t1, t2, t3, t4, t5, t6, t7, t8, t9 As TextBox
    Private d As DateTimePicker
    Public Sub New(ByVal ds As DataSet)
        Dim k As SqlCommand = New SqlCommand("SELECT * FROM PagosRealizados")
        Dim i As SqlCommand = New SqlCommand("INSERT INTO PagosRealizados(cod_empleado, inss_laboral, seguro_medico, Renta, Vacaciones, Horas_extras, Aguinaldo, Salario_neto, Fecha) VALUES (@cod_empleado,@inss_laboral,@seguro_medico,@Renta,@Vacaciones,@Horas_extras,@Aguinaldo,@Salario_neto,@Fecha)")
        Dim borr As SqlCommand = New SqlCommand("DELETE * FROM Trabajadores")
        oDataSet = ds

        adaptadordedatos.InsertCommand() = i
        adaptadordedatos.SelectCommand() = k
        adaptadordedatos.DeleteCommand = borr
    End Sub
    Public Sub Conectar() 'Procedimiento que establece la conexion de una base de datos, tabla de pagos realizados"
        Dim seleccion As String = "SELECT * FROM PagosRealizados"
        oconexion.ConnectionString = conexion
        Try
            adaptadordedatos = New SqlDataAdapter(seleccion, conexion)
            oDataSet.Clear()
            oconexion.Open()
            adaptadordedatos.Fill(oDataSet)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal")
        End Try

    End Sub
    Public Sub ConectarT() 'Procedimiento que establece la conexion de una base de datos, tabla trabajadores"
        Dim seleccion As String = "SELECT * FROM Trabajadores"
        oconexion.ConnectionString = conexion
        Try

            adaptadordedatos = New SqlDataAdapter(seleccion, conexion)
            oDataSet.Clear()
            oconexion.Open()
            adaptadordedatos.Fill(oDataSet)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal")
        End Try

    End Sub
    Public Sub primero()
        transaccion.MoveFirst()
    End Sub

    Public Sub siguiente()
        transaccion.MoveNext()
    End Sub
    Public Sub anterior()
        transaccion.MovePrevious()
    End Sub
    Public Sub ultimo()
        transaccion.MoveLast()
    End Sub

    Public Function EncontrarEmpleado(id As Integer) As DataRow

        If (String.IsNullOrEmpty(id)) Then
            Throw New ArgumentNullException("id")
            Exit Function
        End If

        ' Declaramos la variable que devolverá la función, que
        ' en principio indica que no existe ningún registro
        ' que coincida con el ID especificado.
        '
        Dim returnValue As DataRow = Nothing

        ' Creamos la conexión con la base de SQL Server.
        Using cnn As New SqlConnection(conexion)

            ' Creamos un objeto Command.
            Dim cmd As SqlCommand = cnn.CreateCommand()

            ' Indicamos la consulta SQL de selección que deseamos ejecutar
            cmd.CommandText = "SELECT * FROM Trabajadores WHERE Id=@id"

            ' Añadimos el único parámetro de entrada existente en la consulta
            cmd.Parameters.AddWithValue("@id", id)

            ' Creamos el adaptador de datos al que le pasamos el objeto Command.
            Dim da As New SqlDataAdapter(cmd)

            ' Intentamos rellenar un objeto DataTable como resultado
            ' de ejecutar la consulta SQL de selección especificada.
            '
            Using dt As New DataTable()

                da.Fill(dt)

                If (dt.Rows.Count > 0) Then
                    ' Nos quedamos con la primera fila u objeto DataRow.
                    '
                    returnValue = dt.Rows(0)
                End If

            End Using

        End Using

        ' Devolvemos el objeto DataRow obtenido.
        '
        Return returnValue

    End Function

    Public Function EncontrarNombrePago(id As Integer) As DataRow

        If (String.IsNullOrEmpty(id)) Then
            Throw New ArgumentNullException("cod_empleado")
            Exit Function
        End If

        ' Declaramos la variable que devolverá la función, que
        ' en principio indica que no existe ningún registro
        ' que coincida con el ID especificado.
        '
        Dim returnValue As DataRow = Nothing

        ' Creamos la conexión con la base de SQL Server.
        Using cnn As New SqlConnection(conexion)

            ' Creamos un objeto Command.
            Dim cmd As SqlCommand = cnn.CreateCommand()

            ' Indicamos la consulta SQL de selección que deseamos ejecutar
            cmd.CommandText = "SELECT * FROM PagosRealizados WHERE cod_empleado=@cod_empleado"

            ' Añadimos el único parámetro de entrada existente en la consulta
            cmd.Parameters.AddWithValue("@cod_empleado", id)

            ' Creamos el adaptador de datos al que le pasamos el objeto Command.
            Dim da As New SqlDataAdapter(cmd)

            ' Intentamos rellenar un objeto DataTable como resultado
            ' de ejecutar la consulta SQL de selección especificada.
            '
            Using dt As New DataTable()

                da.Fill(dt)

                If (dt.Rows.Count > 0) Then
                    ' Nos quedamos con la primera fila u objeto DataRow.
                    '
                    returnValue = dt.Rows(0)
                End If

            End Using

        End Using

        ' Devolvemos el objeto DataRow obtenido.
        '
        Return returnValue

    End Function
    Public Function EncontrarPago(id As Integer) As DataRow

        If (String.IsNullOrEmpty(id)) Then
            Throw New ArgumentNullException("cod_pago")
            Exit Function
        End If

        ' Declaramos la variable que devolverá la función, que
        ' en principio indica que no existe ningún registro
        ' que coincida con el ID especificado.
        '
        Dim returnValue As DataRow = Nothing

        ' Creamos la conexión con la base de SQL Server.
        Using cnn As New SqlConnection(conexion)

            ' Creamos un objeto Command.
            Dim cmd As SqlCommand = cnn.CreateCommand()

            ' Indicamos la consulta SQL de selección que deseamos ejecutar
            cmd.CommandText = "SELECT * FROM PagosRealizados WHERE cod_pago=@cod_pago"

            ' Añadimos el único parámetro de entrada existente en la consulta
            cmd.Parameters.AddWithValue("@cod_pago", id)

            ' Creamos el adaptador de datos al que le pasamos el objeto Command.
            Dim da As New SqlDataAdapter(cmd)

            ' Intentamos rellenar un objeto DataTable como resultado
            ' de ejecutar la consulta SQL de selección especificada.
            '
            Using dt As New DataTable()

                da.Fill(dt)

                If (dt.Rows.Count > 0) Then
                    ' Nos quedamos con la primera fila u objeto DataRow.
                    '
                    returnValue = dt.Rows(0)
                End If

            End Using

        End Using

        ' Devolvemos el objeto DataRow obtenido.
        '
        Return returnValue

    End Function
    
    Public Sub camposdatos()

        'crear adaptador
        adaptadordedatos = New SqlDataAdapter("SELECT * FROM Trabajadores", oconexion)

        'llenar con el adaptador el dataset
        adaptadordedatos.Fill(oDataSet, "Trabajadores")
        oconexion.Close()
        'establecer el indicador del registro a mostrar de la tabla
        Pos = 0
        'cargar columnas delregistro en los controles del formulario
        CargarTrabajadores()

    End Sub
    Public Sub camposPagos()

        'crear adaptador
        adaptadordedatos = New SqlDataAdapter("SELECT * FROM PagosRealizados", oconexion)


        'llenar con el adaptador el dataset
        adaptadordedatos.Fill(oDataSet, "PagosRealizados")
        oconexion.Close()
        'establecer el indicador del registro a mostrar de la tabla
        Pos = 0
        'cargar columnas delregistro en los controles del formulario
        CargarPagos()

    End Sub
    Public Sub CargarPagos()
        'obtener un objeto con la fila actual
        Dim oDataRows As DataRow
        oDataRows = Me.oDataSet.Tables("PagosRealizados").Rows(Pos)

        'cargar los controles del formulario con los valores de los campos del registro

        t1.Text = oDataRows("cod_pago")
        t2.Text = oDataRows("cod_empleado")
        t3.Text = oDataRows("inss_laboral")
        t4.Text = oDataRows("seguro_medico")
        t5.Text = oDataRows("Renta")

        t6.Text = oDataRows("Vacaciones")
        t7.Text = oDataRows("Horas_extras")
        t8.Text = oDataRows("Aguinaldo")
        t9.Text = oDataRows("Salario_neto")
        d.Value = oDataRows("Fecha")

        'mostrar la posicion actual del registro y el numero total de registro
    End Sub
    Public Sub CargarTrabajadores()
        'obtener un objeto con la fila actual
        Dim oDataRows As DataRow
        oDataRows = Me.oDataSet.Tables("Trabajadores").Rows(Pos)

        'cargar los controles del formulario con los valores de los campos del registro

        t1.Text = oDataRows("Id")
        t2.Text = oDataRows("Nombre")
        t3.Text = oDataRows("Puesto")
        t4.Text = oDataRows("Edad")
        t5.Text = oDataRows("Sexo")
        d.Value = oDataRows("Fecha_de_ingreso")
        t7.Text = oDataRows("Salario")
        'mostrar la posicion actual del registro y el numero total de registro
    End Sub

    Public Sub botonprimero()
        Pos = 0
        CargarTrabajadores()
    End Sub

    Public Sub SigTrab()
        If Pos = (oDataSet.Tables("trabajadores").Rows.Count - 1) Then
            MessageBox.Show("Ultimo registro")
        Else
            'incrementar el marcador de registros y actualizar los controles con los datos del registro actual
            Pos += 1
            CargarTrabajadores()
        End If

    End Sub

    Public Sub botonanterior()
        If Pos = 0 Then
            MessageBox.Show("Primer registro")
        Else
            'disminuir el marcador de registro y actualizar los controles con los datos del registro actual
            Pos -= 1
            CargarTrabajadores()

        End If
    End Sub
    Public Sub UltTrabajadores()
        Pos = (oDataSet.Tables("Trabajadores").Rows.Count - 1)
        CargarTrabajadores()
    End Sub

    Public Sub NuevoPago(ByVal cod_empleado As Integer, inss As Double, medico As Double, renta As Double, vacaciones As Double, horas As Double, aguinaldo As Double, salario As Double, fecha As Date)
        'AQUI GUARDO :V
        Try
            Dim oDataRow As DataRow
            'obtener un nuevo objeto fila de la tabla del dataset
            oDataRow = oDataSet.Tables("PagosRealizados").NewRow()
            'asignar valor a los campos de la nueva fila

            oDataRow("cod_empleado") = cod_empleado
            oDataRow("inss_laboral") = inss
            oDataRow("seguro_medico") = medico
            oDataRow("Renta") = renta
            oDataRow("Vacaciones") = vacaciones
            oDataRow("Horas_extras") = horas
            oDataRow("Aguinaldo") = aguinaldo
            oDataRow("Salario_neto") = salario
            oDataRow("Fecha") = fecha
            oDataRow("cod_pago") = generarcodigoPago()

            oDataSet.Tables("PagosRealizados").Rows.Add(oDataRow)

            Me.ActualizarPago()

            MsgBox("Pago guardado", MsgBoxStyle.Information, Title:="Operación exitosa")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal")
        End Try
    End Sub


    Public Sub ActualizarPago()
        'AQUI ACTUALIZO UWU
        Dim b As New SqlCommandBuilder(adaptadordedatos)

        adaptadordedatos.Update(oDataSet, "PagosRealizados")

    End Sub

    Public Sub ActualizarTrabajadores()
        'AQUI ACTUALIZO UWU
        oCommBuild = New SqlCommandBuilder(adaptadordedatos)
        adaptadordedatos.UpdateCommand = oCommBuild.GetUpdateCommand
        adaptadordedatos.Update(oDataSet, "Trabajadores")

    End Sub

    Public Sub botoneliminar()
        oCommBuild = New SqlCommandBuilder(adaptadordedatos)
        Dim oDataRow As DataRow
        Dim borrar As MsgBoxResult
        borrar = MsgBox("¿Desea eliminar registro?", MsgBoxStyle.YesNo, Title:="¿Está seguro?")
        If borrar = MsgBoxResult.Yes Then
            'obtener el objeto fila, de la tabla del dataset en el que estamos posicionados
            oDataRow = oDataSet.Tables("Trabajadores").Rows(Pos)
            oDataRow.Delete() 'borrar fila
            'mediante el metodo getchanges(), obtenemos una tabla con las filas borradas
            Dim oTablaBorrados As DataTable
            oTablaBorrados = oDataSet.Tables("Trabajadores").GetChanges(DataRowState.Deleted)
            'actualizar en el almacen de datos las filas borradas
            adaptadordedatos.Update(oTablaBorrados)
            'confirmar los cambios realizados
            oDataSet.Tables("Trabajadores").AcceptChanges()
            'reposicionar en la primera fila
            Pos -= 1
            MsgBox("Eliminado!", MsgBoxStyle.Exclamation, Title:="Éxito")
            SigTrab()
        End If
    End Sub

    Public Function generarcodigoEmpleado()

        Randomize()
        Dim num As Integer = CInt(Int((8000 * Rnd() + 1)) + 1000)
        Dim D As DataRow = EncontrarEmpleado(num)
        If Not IsNothing(D) Then
            generarcodigoEmpleado()
        End If

        Return num

    End Function

    Public Function generarcodigoPago()

        Randomize()
        Dim num As Integer = CInt(Int((8000 * Rnd() + 1)) + 1000)
        Dim D As DataRow = EncontrarPago(num)
        While Not IsNothing(D)
            generarcodigoPago()
        End While

        Return num

    End Function


    Public Sub ModificarTrabajadores(ByVal cod As Integer, name As String, puesto As String, edad As Integer, sexo As Char, fecha As Date, salario As Double)
        Try
            Dim DR As DataRow = oDataSet.Tables("Trabajadores").Rows(Pos)
            DR("Id") = cod
            DR("Nombre") = name
            DR("Puesto") = puesto
            DR("Edad") = edad
            DR("Sexo") = sexo
            DR("Fecha_de_ingreso") = fecha
            DR("Salario") = salario

            Me.ActualizarTrabajadores()

            MsgBox("Modificado correctamente", MsgBoxStyle.Information, Title:="Correcto")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal")
        End Try
    End Sub

    Public Sub obTextbox(ByVal caja1 As TextBox, caja2 As TextBox, caja3 As TextBox, caja4 As TextBox, caja5 As TextBox, caja6 As TextBox, caja7 As TextBox, caja8 As TextBox, caja9 As TextBox, caja10 As DateTimePicker)
        t1 = caja1
        t2 = caja2
        t3 = caja3
        t4 = caja4
        t5 = caja5
        t6 = caja6
        t7 = caja7
        t8 = caja8
        t9 = caja9
        d = caja10
    End Sub

    Public Function NuevoEmpleado(ByVal nombre As String, puesto As String, edad As Integer, sexo As String, fecha As Date, salario As Double)
        'AQUI GUARDO :V
        Try
            Dim oDataRow As DataRow
            'obtener un nuevo objeto fila de la tabla del dataset
            oDataRow = oDataSet.Tables("Trabajadores").NewRow()
            'asignar valor a los campos de la nueva fila

            oDataRow("Id") = generarcodigoEmpleado()
            oDataRow("Nombre") = nombre
            oDataRow("Puesto") = puesto
            oDataRow("Edad") = edad
            oDataRow("Sexo") = sexo
            oDataRow("Fecha_de_ingreso") = fecha
            oDataRow("Salario") = salario

            oDataSet.Tables("Trabajadores").Rows.Add(oDataRow)

            Me.ActualizarTrabajadores()

            Return oDataRow("Id")

            MsgBox("Pago guardado", MsgBoxStyle.Information, Title:="Operación exitosa")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Ups, algo salió mal")
            Return 0
        End Try
    End Function


    Public Sub obTextbox(ByVal caja1 As TextBox, caja2 As TextBox, caja3 As TextBox, caja4 As TextBox, caja5 As TextBox, caja6 As DateTimePicker, caja7 As TextBox)
        t1 = caja1
        t2 = caja2
        t3 = caja3
        t4 = caja4
        t5 = caja5
        d = caja6
        t7 = caja7
    End Sub
    Public Sub botonprimeropago()
        Pos = 0
        CargarPagos()
    End Sub

    Public Sub SigPagos()
        If Pos = (oDataSet.Tables("PagosRealizados").Rows.Count - 1) Then
            MessageBox.Show("Ultimo registro")
        Else
            'incrementar el marcador de registros y actualizar los controles con los datos del registro actual
            Pos += 1
            CargarPagos()
        End If

    End Sub

    Public Sub botonanteriorPagos()
        If Pos = 0 Then
            MessageBox.Show("Primer registro")
        Else
            'disminuir el marcador de registro y actualizar los controles con los datos del registro actual
            Pos -= 1
            CargarPagos()

        End If
    End Sub
    Public Sub UltPagos()
        Pos = (oDataSet.Tables("PagosRealizados").Rows.Count - 1)
        CargarPagos()
    End Sub
    Public Sub botoneliminarPago()
        oCommBuild = New SqlCommandBuilder(adaptadordedatos)
        Dim oDataRow As DataRow
        Dim borrar As MsgBoxResult
        borrar = MsgBox("¿Desea eliminar registro?", MsgBoxStyle.YesNo, Title:="¿Está seguro?")
        If borrar = MsgBoxResult.Yes Then
            'obtener el objeto fila, de la tabla del dataset en el que estamos posicionados
            oDataRow = oDataSet.Tables("PagosRealizados").Rows(Pos)
            oDataRow.Delete() 'borrar fila
            'mediante el metodo getchanges(), obtenemos una tabla con las filas borradas
            Dim oTablaBorrados As DataTable
            oTablaBorrados = oDataSet.Tables("PagosRealizados").GetChanges(DataRowState.Deleted)
            'actualizar en el almacen de datos las filas borradas
            adaptadordedatos.Update(oTablaBorrados)
            'confirmar los cambios realizados
            oDataSet.Tables("PagosRealizados").AcceptChanges()
            'reposicionar en la primera fila
            Pos -= 1
            MsgBox("Eliminado!", MsgBoxStyle.Exclamation, Title:="Éxito")
            SigPagos()
        End If
    End Sub
End Class