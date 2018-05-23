Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports DevExpress.ExpressApp.SystemModule

Namespace HowToChangeFilterByTextAction.Module
	Partial Public Class MyFilterController
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
			Me.TargetObjectType = GetType(DevExpress.Persistent.BaseImpl.Person)
		End Sub

		Private Sub MyFilterController_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
			Dim standardFilterController As FilterController = Frame.GetController(Of FilterController)()
			If standardFilterController IsNot Nothing Then
				AddHandler standardFilterController.CustomGetFullTextSearchProperties, AddressOf standardFilterController_CustomGetFullTextSearchProperties
			End If
		End Sub

		Private Sub standardFilterController_CustomGetFullTextSearchProperties(ByVal sender As Object, ByVal e As CustomGetFullTextSearchPropertiesEventArgs)
			For Each [property] As String In GetFullTextSearchProperties()
				e.Properties.Add([property])
			Next [property]
			e.Handled = True
		End Sub
		Private Function GetFullTextSearchProperties() As List(Of String)
			Dim searchProperties As New List(Of String)()
			searchProperties.Add("LastName")
			Return searchProperties
		End Function
	End Class
End Namespace
