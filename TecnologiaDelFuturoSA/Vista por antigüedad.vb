Public Class Vista_por_antigüedad
    Public planta As Arbolbinario = New Arbolbinario(Me)
    Private Sub Vista_por_antigüedad_Load(sender As Object, e As EventArgs)
        Dim i As Integer = 0
        i = Control_de_empleados.Trabajadores.Tables("Trabajadores").Rows.Count()
        For j As Integer = 0 To i - 1
            planta.AgregarNodo(Control_de_empleados.Trabajadores.Tables("Trabajadores").Rows(j))
        Next
        Dim x As Integer = 70 * Math.Pow(2, planta.Alt(planta.raiz) - 1)
        planta.dibujar(planta.raiz, 2048, 10, 1024)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Vista_por_antigüedad
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Name = "Vista_por_antigüedad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
End Class