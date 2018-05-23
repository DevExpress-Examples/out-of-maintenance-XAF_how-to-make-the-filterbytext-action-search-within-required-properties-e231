Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Filtering
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.DC

Public Class MyFilterController
    Inherits FilterController

    Protected Overrides Sub FullTextSearch(ByVal args As ParametrizedActionExecuteEventArgs)
        Dim criteriaOperator As CriteriaOperator = FullTextSearchCriteriaBuilder.BuildSimpleSearchCriteria( _
           ObjectSpace.TypesInfo.FindTypeInfo(View.ObjectType), _
           GetProperties(), CStr(args.ParameterCurrentValue), GroupOperatorType.And)
        View.CollectionSource.Criteria(FullTextSearchCriteriaBuilder.CriteriaName) = criteriaOperator
    End Sub
    'Return the properties to be tested
    Private Function GetProperties() As ICollection(Of String)
        Dim result As List(Of String) = New List(Of String)()
        For Each column As ColumnInfoNodeWrapper In View.Model.Columns.Items
            For Each member As IMemberInfo In ObjectSpace.TypesInfo.FindTypeInfo(View.ObjectType).Members
                If (column.PropertyName = member.Name) AndAlso (member.IsPersistent) AndAlso (column.VisibleIndex <> -1) Then
                    result.Add(column.PropertyName)
                End If
            Next member
        Next column
        Return result
    End Function

End Class
