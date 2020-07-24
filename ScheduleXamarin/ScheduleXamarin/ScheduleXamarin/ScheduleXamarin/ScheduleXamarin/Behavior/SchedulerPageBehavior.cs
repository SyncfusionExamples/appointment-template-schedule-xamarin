using System;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulerPageBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        ContentPage ContentPage;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.ContentPage = bindable;
            this.schedule = bindable.Content.FindByName<SfSchedule>("Schedule");
            this.WireEvents();
        }
        
        private void WireEvents()
        {
            this.schedule.CellTapped += Schedule_CellTapped;
        }

        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            if (e.Appointment != null)
            {
                var appname = (e.Appointment as Meeting).EventName;
                var City = (e.Appointment as Meeting).City;
                var District = (e.Appointment as Meeting).District;
                var noOfStudents = (e.Appointment as Meeting).NumberOfStudents;

                this.ContentPage.DisplayAlert(appname, "City:" + " " + City + "\n" + "District:" + " " + District + "\n" + "NumberofStudents:" + " " + noOfStudents + "\n" , "ok");
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }

        private void UnWireEvents()
        {
            this.schedule.CellTapped -= Schedule_CellTapped;
        }
    }
}
