Imports System.IO
Imports System.IO.File
Public Class CapturaController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function saveTxt() As ActionResult
        Dim dataAlumno As New Alumno

        If Not Request.Form("txtNombre") Is Nothing Then
            dataAlumno.Nombres = Request.Form("txtNombre")
        End If
        If Not Request.Form("txtApPat") Is Nothing Then
            dataAlumno.ApellidoPaterno = Request.Form("txtApPat")
        End If
        If Not Request.Form("txtRFC") Is Nothing Then
            dataAlumno.RFC = Request.Form("txtRFC")
        End If
        If Not Request.Form("txtApMat") Is Nothing Then
            dataAlumno.ApellidoMaterno = Request.Form("txtApMat")
        End If
        If Not Request.Form("dtpFechaNac") Is Nothing Then
            dataAlumno.FechaNacimiento = Request.Form("dtpFechaNac")
        End If
        If Not Request.Form("dtpFechaIng") Is Nothing Then
            dataAlumno.FechaIngreso = Request.Form("dtpFechaIng")
        End If
        If Not Request.Form("chkAct") Is Nothing Then
            If Request.Form("chkAct") = "on" Then
                dataAlumno.Activo = True
            Else
                dataAlumno.Activo = False
            End If
        End If
        If Not Request.Form("genero") Is Nothing Then
            Select Case Request.Form("genero")
                Case "1"
                    dataAlumno.Genero = "Masculino"
                Case "2"
                    dataAlumno.Genero = "Femenino"
                Case Else
                    dataAlumno.Genero = "Sin especificar"
            End Select
        End If
        If createTxt(dataAlumno) Then
            Response.Write("Ruta del archivo: C:\temp\ALUMNOS\Alumno_" & dataAlumno.RFC & ".txt")
        End If
        Return View()
    End Function
    Protected Function createTxt(ByVal objAlumno As Alumno) As Boolean
        My.Computer.FileSystem.CreateDirectory("C:\temp\ALUMNOS")
        Dim filePath As String = String.Format("C:\temp\ALUMNOS\Alumno_{0}.txt", objAlumno.RFC)
        Dim fileExists As Boolean = System.IO.File.Exists(filePath)
        Dim writeSuccess As Boolean = False
        Using writer As New StreamWriter(filePath, True)
            If Not fileExists Then
                writer.WriteLine("###### ALUMNO ######")
                writer.WriteLine("Nombre: " & objAlumno.Nombres)
                writer.WriteLine("Apellido Paterno: " & objAlumno.ApellidoPaterno)
                writer.WriteLine("Apellido Materno: " & objAlumno.ApellidoMaterno)
                writer.WriteLine("Genero: " & objAlumno.Genero)
                writer.WriteLine("Fecha Nacimiento: " & objAlumno.FechaNacimiento)
                writer.WriteLine("Fecha Ingreso: " & objAlumno.FechaNacimiento)
                writer.WriteLine("Alumno Activo: " & If(objAlumno.Activo, "ACTIVO", "INACTIVO"))
                writer.WriteLine("RFC: " & objAlumno.RFC)
                writer.WriteLine("###### ALUMNO ######")
                writeSuccess = True
                writer.Close()
            End If
        End Using
        Return writeSuccess
    End Function
    Class Alumno
        Property Nombres As String = ""
        Property ApellidoPaterno As String = ""
        Property ApellidoMaterno As String = ""
        Property Genero As String = ""
        Property FechaNacimiento As String
        Property FechaIngreso As String
        Property Activo As Boolean
        Property RFC As String = ""
    End Class
End Class
