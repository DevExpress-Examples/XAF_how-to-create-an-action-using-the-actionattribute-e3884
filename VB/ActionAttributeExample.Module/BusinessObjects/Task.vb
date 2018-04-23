Imports DevExpress.ExpressApp.Model
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace ActionAttributeExample.Module.BusinessObjects
    <DefaultClassOptions, ImageName("BO_Task"), DefaultProperty("Subject")> _
    Public Class Task
        Inherits BaseObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _subject As String
        Public Property Subject() As String
            Get
                Return _subject
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Subject", _subject, value)
            End Set
        End Property
        Private _deadline? As DateTime
        Public Property Deadline() As DateTime?
            Get
                Return _deadline
            End Get
            Set(ByVal value? As DateTime)
                SetPropertyValue("Deadline", _deadline, value)
            End Set
        End Property
        Private _isCompleted As Boolean
        Public Property IsCompleted() As Boolean
            Get
                Return _isCompleted
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue("IsCompleted", _isCompleted, value)
            End Set
        End Property
        Private _comments As String
        <Size(SizeAttribute.Unlimited), ModelDefault("AllowEdit", "False")> _
        Public Property Comments() As String
            Get
                Return _comments
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Comments", _comments, value)
            End Set
        End Property
        <Action(Caption:="Complete", TargetObjectsCriteria := "Not [IsCompleted]")> _
        Public Sub Complete()
            IsCompleted = True
        End Sub
        <Action(Caption := "Postpone", TargetObjectsCriteria := "[Deadline] Is Not Null And Not [IsCompleted]")> _
        Public Sub Postpone(ByVal parameters As PostponeParametersObject)
            If Deadline.HasValue AndAlso (Not IsCompleted) AndAlso (parameters.PostponeForDays > 0) Then
                Deadline += TimeSpan.FromDays(parameters.PostponeForDays)
                Comments += String.Format("Postponed for {0} days, new deadline is {1:d}" & Constants.vbCrLf & "{2}" & Constants.vbCrLf, parameters.PostponeForDays, Deadline, parameters.Comment)
            End If
        End Sub
    End Class
    <NonPersistent, ModelDefault("Caption", "Postpone Parameters")> _
    Public Class PostponeParametersObject
        Public Sub New()
            PostponeForDays = 1
        End Sub
        Private privatePostponeForDays As UInteger
        Public Property PostponeForDays() As UInteger
            Get
                Return privatePostponeForDays
            End Get
            Set(ByVal value As UInteger)
                privatePostponeForDays = value
            End Set
        End Property
        Private privateComment As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comment() As String
            Get
                Return privateComment
            End Get
            Set(ByVal value As String)
                privateComment = value
            End Set
        End Property
    End Class
End Namespace
