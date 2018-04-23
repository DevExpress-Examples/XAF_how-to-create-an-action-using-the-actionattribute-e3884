using DevExpress.ExpressApp.Model;
using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace ActionAttributeExample.Module.BusinessObjects {
    [DefaultClassOptions, ImageName("BO_Task"), DefaultProperty("Subject")]
    public class Task : BaseObject {
        public Task(Session session) : base(session) { }
        private string subject;
        public string Subject {
            get { return subject; }
            set { SetPropertyValue("Subject", ref subject, value); }
        }
        private DateTime? deadline;
        public DateTime? Deadline {
            get { return deadline; }
            set { SetPropertyValue("Deadline", ref deadline, value); }
        }
        private bool isCompleted;
        public bool IsCompleted {
            get { return isCompleted; }
            set { SetPropertyValue("IsCompleted", ref isCompleted, value); }
        }
        private string comments;
        [Size(SizeAttribute.Unlimited), ModelDefault("AllowEdit", "False")]
        public string Comments {
            get { return comments; }
            set { SetPropertyValue("Comments", ref comments, value); }
        }
        [Action(Caption="Complete", TargetObjectsCriteria = "Not [IsCompleted]")]
        public void Complete() {
            IsCompleted = true;
        }
        [Action(Caption = "Postpone",
            TargetObjectsCriteria = "[Deadline] Is Not Null And Not [IsCompleted]")]
        public void Postpone(PostponeParametersObject parameters) {
            if (Deadline.HasValue && !IsCompleted && (parameters.PostponeForDays > 0)) {
                Deadline += TimeSpan.FromDays(parameters.PostponeForDays);
                Comments += String.Format("Postponed for {0} days, new deadline is {1:d}\r\n{2}\r\n",
                    parameters.PostponeForDays, Deadline, parameters.Comment);
            }
        }
    }
    [NonPersistent]
    [ModelDefault("Caption", "Postpone Parameters")]
    public class PostponeParametersObject {
        public PostponeParametersObject() { PostponeForDays = 1; }
        public uint PostponeForDays { get; set; }
        [Size(SizeAttribute.Unlimited)]
        public string Comment { get; set; }
    }
}
