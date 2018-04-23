using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Security;
using ActionAttributeExample.Module.BusinessObjects;

namespace ActionAttributeExample.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            for (byte index = 1; index < 10; index++)
                CreateTask(String.Format("Task {0}", index));
        }
        private void CreateTask(string subject) {
            Task task = ObjectSpace.FindObject<Task>(
                new BinaryOperator("Subject", subject));
            if (task == null) {
                task = ObjectSpace.CreateObject<Task>();
                task.Deadline = DateTime.Today;
                task.Subject = subject;
            }
        }
    }
}
