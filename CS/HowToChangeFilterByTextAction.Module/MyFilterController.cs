using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.SystemModule;

namespace HowToChangeFilterByTextAction.Module {
    public partial class MyFilterController : ViewController {
        public MyFilterController() {
            InitializeComponent();
            RegisterActions(components);
            this.TargetObjectType = typeof(DevExpress.Persistent.BaseImpl.Person);
        }

        private void MyFilterController_Activated(object sender, EventArgs e) {
            FilterController standardFilterController = Frame.GetController<FilterController>();
            if(standardFilterController != null) {
                standardFilterController.CustomGetFullTextSearchProperties += new EventHandler<CustomGetFullTextSearchPropertiesEventArgs>(standardFilterController_CustomGetFullTextSearchProperties);
            }
        }

        void standardFilterController_CustomGetFullTextSearchProperties(object sender, CustomGetFullTextSearchPropertiesEventArgs e) {
            foreach(string property in GetFullTextSearchProperties()) {
                e.Properties.Add(property);
            }
            e.Handled = true;
        }
        private List<string> GetFullTextSearchProperties() {
            List<string> searchProperties = new List<string>();
            searchProperties.Add("LastName");
            return searchProperties;
        }
    }
}
