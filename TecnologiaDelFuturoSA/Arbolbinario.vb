Imports System.IO
Public Class Arbolbinario
    Public raiz As Nodos
    Public form1 As Form
    Dim l As Label
    Dim p As PictureBox
    Public Sub New(ByVal f As Form)
        form1 = f
    End Sub

    Public Sub Binario()
        raiz = Nothing
    End Sub
    Public Function Vacio() As Boolean
        If IsNothing(raiz) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub AgregarNodo(ByVal info As DataRow)
        Dim n As Nodos = New Nodos(info)

        If IsNothing(raiz) Then
            raiz = n
        Else
            Dim aux As Nodos = raiz
            Dim padre As Nodos
            While True
                padre = aux
                If info("Fecha_de_ingreso") < aux.datos("Fecha_de_ingreso") Then
                    aux = aux.izq
                    If IsNothing(aux) Then
                        padre.izq = n
                        Exit Sub
                    End If
                ElseIf info("Fecha_de_ingreso") >= aux.datos("Fecha_de_ingreso") Then
                    aux = aux.der

                    If IsNothing(aux) Then
                        padre.der = n
                        Exit Sub
                    End If
                End If
            End While
        End If

    End Sub
    Public Sub Preorden(ByVal r As Nodos, l As Label)

        If Not IsNothing(r) Then
            l.Text = l.Text & " " & r.datos("Fecha_de_ingreso")
            Preorden(r.izq, l)
            Preorden(r.der, l)
        End If
    End Sub
    Public Sub Inorden(ByVal r As Nodos, l As Label)
        If Not IsNothing(r) Then
            Preorden(r.izq, l)
            l.Text = l.Text & " " & r.datos("Fecha_de_ingreso")
            Preorden(r.der, l)
        End If
    End Sub
    Public Sub Postorden(ByVal r As Nodos, l As Label)
        If Not IsNothing(r) Then
            Preorden(r.izq, l)
            Preorden(r.der, l)
            l.Text = l.Text & " " & r.datos("Id")
        End If
    End Sub

    Public Function Busqueda(ByVal d As Integer) As DataRow
        Dim aux As Nodos = raiz
        While aux.datos("Fecha_de_ingreso") <> d
            If d < aux.datos("Fecha_de_ingreso") Then
                aux = aux.izq
            ElseIf aux.datos("Fecha_de_ingreso") > d Then
                aux = aux.der
            Else
                Return Nothing
            End If
        End While
        Return aux.datos
    End Function

  
    Public Function Alt(ByVal k As Nodos) As Integer
        Dim p As Integer = 0
        Dim i As Integer = 0
        Dim d As Integer = 0
        If IsNothing(k) Then
            Return 0
        Else
            d = Alt(k.der) + 1
            i = Alt(k.izq) + 1
            If d > i Then
                Return d
            Else
                Return i
            End If
        End If
    End Function
    Public Function dibujar(ByVal arbol As Nodos, x As Integer, y As Integer, ByVal int As Integer) As Boolean

        If arbol Is Nothing Then
            Return True
        Else
            l = New Label
            p = New PictureBox
            Dim rectF1 As New RectangleF(x, y, 100, 50)
            Dim text1 As String = "" & arbol.datos("Fecha_de_ingreso") & vbCrLf & arbol.datos("Id") & vbCrLf & arbol.datos("Nombre")
            Dim font1 As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
            With l
                .Text = text1
                .Location = New System.Drawing.Point(x, y)
                .BackColor = Color.DarkBlue

                .AutoSize = False
                .Size = New Size(100, 50)
            End With

            form1.Controls.Add(l)
            Try
              
                If Not IsNothing(arbol.der) Then
                    With p
                        .Size = New Size(int, 120)
                        .Location = New Point(x + 100, y)
                        .BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Resources\der.jpg"))
                        .BackgroundImageLayout = ImageLayout.Stretch
                    End With
                    form1.Controls.Add(p)
                    Me.dibujar(arbol.der, x + int, y + 120, int / 2)
                End If

                If Not IsNothing(arbol.izq) Then
                    With p
                        .Size = New Size(int, 120)
                        .Location = New Point(x - int, y)
                        .BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Resources\izq.jpg"))
                        .BackgroundImageLayout = ImageLayout.Stretch
                    End With

                    form1.Controls.Add(p)
                    Me.dibujar(arbol.izq, x - int, y + 120, int / 2)

                End If

            Finally
                font1.Dispose()
            End Try

            Return False
        End If


    End Function

    Public Function dibujarLista(ByVal arbol As Nodos, x As Integer, y As Integer, ByVal int As Integer) As Boolean

        If arbol Is Nothing Then
            Return True
        Else
            l = New Label
            '   p = New PictureBox
            Dim rectF1 As New RectangleF(x, y, 100, 50)
            Dim text1 As String = "" & arbol.datos("Fecha_de_ingreso") & vbCrLf & arbol.datos("Id") & vbCrLf & arbol.datos("Nombre")
            Dim font1 As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
            With l
                .Text = text1
                .Location = New System.Drawing.Point(x, y)
                .BackColor = Color.DarkBlue

                .AutoSize = False
                .Size = New Size(100, 50)
            End With

            form1.Controls.Add(l)
            Try

                If Not IsNothing(arbol.der) Then
                    'With p
                    '    .Size = New Size(int, 120)
                    '    .Location = New Point(x + 100, y)
                    '    .BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Resources\der.jpg"))
                    '    .BackgroundImageLayout = ImageLayout.Stretch
                    'End With
                    'form1.Controls.Add(p)
                    Me.dibujar(arbol.der, x, y + 120, int / 2)
                End If

                If Not IsNothing(arbol.izq) Then
                    'With p
                    '    .Size = New Size(int, 120)
                    '    .Location = New Point(x - int, y)
                    '    .BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Resources\izq.jpg"))
                    '    .BackgroundImageLayout = ImageLayout.Stretch
                    'End With

                    'form1.Controls.Add(p)
                    Me.dibujar(arbol.izq, x, y + 120, int / 2)

                End If

            Finally
                font1.Dispose()
            End Try

            Return False
        End If
    End Function

End Class