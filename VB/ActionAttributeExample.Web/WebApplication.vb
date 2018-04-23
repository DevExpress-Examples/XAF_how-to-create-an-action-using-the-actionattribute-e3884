Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace ActionAttributeExample.Web
    Partial Public Class ActionAttributeExampleAspNetApplication
        Inherits WebApplication
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As ActionAttributeExample.Module.ActionAttributeExampleModule
        'private ActionAttributeExample.Module.Web.ActionAttributeExampleAspNetModule module4;

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub ActionAttributeExampleAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & Constants.vbCrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & Constants.vbCrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & Constants.vbCrLf & "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
            End If
#End If
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New ActionAttributeExample.Module.ActionAttributeExampleModule()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' ActionAttributeExampleAspNetApplication
            ' 
            Me.ApplicationName = "ActionAttributeExample"
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
'            Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.ActionAttributeExampleAspNetApplication_DatabaseVersionMismatch);
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
