Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base


Imports DevExpress.ExpressApp.SystemModule

Public Class MyFilterController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 
      TargetObjectType = GetType(DevExpress.Persistent.BaseImpl.Person)
   End Sub


   Private Sub MyFilterController_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
      Dim standardFilterController As FilterController = Frame.GetController(Of FilterController)()
      If Not standardFilterController Is Nothing Then
         AddHandler standardFilterController.CustomGetFullTextSearchProperties, _
             AddressOf standardFilterController_CustomGetFullTextSearchProperties
      End If
   End Sub
   Private Sub standardFilterController_CustomGetFullTextSearchProperties(ByVal sender As Object, ByVal e As CustomGetFullTextSearchPropertiesEventArgs)
      For Each [property] As String In GetFullTextSearchProperties()
         e.Properties.Add([property])
      Next [property]
      e.Handled = True
   End Sub
   Private Function GetFullTextSearchProperties() As List(Of String)
      Dim searchProperties As List(Of String) = New List(Of String)()
      searchProperties.Add("LastName")
      Return searchProperties
   End Function


End Class
