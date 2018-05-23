using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Filtering;
using DevExpress.ExpressApp.NodeWrappers;
using DevExpress.ExpressApp.DC;


namespace HowToChangeFilterByTextAction.Module {
   public partial class MyFilterController : FilterController{
      protected override void FullTextSearch(ParametrizedActionExecuteEventArgs args) {
         CriteriaOperator criteriaOperator = FullTextSearchCriteriaBuilder.BuildSimpleSearchCriteria(
            ObjectSpace.TypesInfo.FindTypeInfo(View.ObjectType),
            GetProperties(), (string)args.ParameterCurrentValue, GroupOperatorType.And);
         View.CollectionSource.Criteria[FullTextSearchCriteriaBuilder.CriteriaName] = criteriaOperator;
      }
      //Return the properties to be tested
      private ICollection<string> GetProperties() {
         List<string> result = new List<string>();
         foreach (ColumnInfoNodeWrapper column in View.Model.Columns.Items) {
            foreach (IMemberInfo member in ObjectSpace.TypesInfo.FindTypeInfo(View.ObjectType).Members) {
               if ((column.PropertyName == member.Name) && (member.IsPersistent) && (column.VisibleIndex != -1)) {
                  result.Add(column.PropertyName);
               }
            }
         }
         return result;
      }
   }
}
