Imports Entidades

Public Class frmHolaMundo
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSaludo_Click(sender As Object, e As EventArgs) Handles btnSaludo.Click
        Dim objPersona As New clsPersona
        objPersona.Nombre = txtNombre.Text
        If String.IsNullOrWhiteSpace(objPersona.Nombre) Then
            MessageBox.Show("Debe introducir un nombre")
        Else
            MessageBox.Show("Hola " + objPersona.Nombre)
        End If


    End Sub
End Class
