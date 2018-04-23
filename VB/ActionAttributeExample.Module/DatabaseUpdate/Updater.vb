Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Security
Imports ActionAttributeExample.Module.BusinessObjects

Namespace ActionAttributeExample.Module.DatabaseUpdate
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			For index As Byte = 1 To 9
				CreateTask(String.Format("Task {0}", index))
			Next index
		End Sub
		Private Sub CreateTask(ByVal subject As String)
			Dim task As Task = ObjectSpace.FindObject(Of Task)(New BinaryOperator("Subject", subject))
			If task Is Nothing Then
				task = ObjectSpace.CreateObject(Of Task)()
				task.Deadline = DateTime.Today
				task.Subject = subject
			End If
		End Sub
	End Class
End Namespace
