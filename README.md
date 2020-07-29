# How to customize appointment appearance and show details in popup on Xamarin.Forms Schedule (SfSchedule)

You can customize the default appearance of appointment using [AppointmentTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~AppointmentTemplate.html?) in Xamarin.Forms [SfSchedule](https://help.syncfusion.com/xamarin/scheduler/overview?).

You can also refer the following article.

https://www.syncfusion.com/kb/11791/how-to-customize-appointment-appearance-and-show-details-in-popup-on-xamarin-forms-schedule

**STEP 1:** Create a custom appointment detail.
``` c#
public class Meeting
    {
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color Color { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int NumberOfStudents { get; set; }
    }
``` 

**STEP 2:** Create a custom appointment collection for displaying the schedule appointments in **SfSchedule**, and bind it to [DataSource](http://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~DataSource.html?) of **SfSchedule**.
``` c#
public class SchedulerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// collecions for meetings.
        /// </summary>
        private ObservableCollection<Meeting> meetings;
 
        /// <summary>
        /// color collection.
        /// </summary>
        private List<Color> colorCollection;
 
        /// <summary>
        /// current day meeting.
        /// </summary>
        private List<string> currentDayMeetings;
 
        public SchedulerViewModel()
        {
            this.AppointmentDataTemplate = new DataTemplate(() => new AppointmentDataTemplate());
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }
 
        /// <summary>
        /// Gets or sets meetings.
        /// </summary>
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }
 
            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }
 
        /// <summary>
        /// Gets or sets the AppointmentDataTemplate.
        /// </summary>
        public DataTemplate AppointmentDataTemplate { get; set; }
 
        /// <summary>
        /// adding appointment details.
        /// </summary>
        private void AddAppointmentDetails()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Support");
            this.currentDayMeetings.Add("Development Meeting");
            this.currentDayMeetings.Add("Scrum");
            this.currentDayMeetings.Add("Project Completion");
            this.currentDayMeetings.Add("Release updates");
            this.currentDayMeetings.Add("Performance Check");
 
            this.colorCollection = new List<Color>();
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FFF09609"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }
 
        /// <summary>
        /// Adds the appointments.
        /// </summary>
        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month < 2; month++)
            {
                for (int day = -5; day < 5; day++)
                {
                    for (int count = 0; count < 2; count++)
                    {
                        var meeting = new Meeting();
                        meeting.From = today.AddMonths(month).AddDays(random.Next(1, 28)).AddHours(random.Next(9, 18));
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = this.currentDayMeetings[random.Next(7)];
                        meeting.Color = this.colorCollection[random.Next(14)];
                        meeting.City = "Qatif";
                        meeting.District = "Hellat Muhaysh";
                        meeting.NumberOfStudents = random.Next(1, 28);
                        this.Meetings.Add(meeting);
                    }
                }
            }
        }
 
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
 
        /// <summary>
        /// Invoke method when property changed.
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
```
**STEP 3:** Customize the appearance of appointment using the **AppointmentTemplate** property of schedule and  map the custom appointments to [StartTimeMapping](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.ScheduleAppointmentMapping~StartTimePropertyMapping.html?), [EndTimeMapping](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.ScheduleAppointmentMapping~EndTimePropertyMapping.html?), [ColorMapping](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.ScheduleAppointmentMapping~ColorMappingProperty.html?), [SubjectMapping](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.ScheduleAppointmentMapping~SubjectMappingProperty.html?) of [AppointmentMapping](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.ScheduleAppointmentMapping.html?) to display the custom appointments in schedule.
``` xml
<schedule:SfSchedule x:Name="Schedule"
                                     ScheduleView="WeekView"
                                     DataSource="{Binding Meetings}"
                                     AppointmentTemplate="{Binding AppointmentDataTemplate}">
                <schedule:SfSchedule.AppointmentMapping>
                   <schedule:ScheduleAppointmentMapping
                        ColorMapping="Color"
                        EndTimeMapping="To"
                        StartTimeMapping="From"
                        SubjectMapping="EventName"
                        />
                </schedule:SfSchedule.AppointmentMapping>
            <schedule:SfSchedule.BindingContext>
                <local:SchedulerViewModel/>
            </schedule:SfSchedule.BindingContext>
</schedule:SfSchedule>
```

**STEP 4:** Create a custom view for displaying the circle appointments in schedule.

``` xml
<?xml version="1.0" encoding="UTF-8"?>
<AbsoluteLayout xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="ScheduleXamarin.AppointmentDataTemplate"
             Margin="0" 
             Padding="0"
             BackgroundColor="White">
    <Frame
            BackgroundColor="{Binding Color}"
            AbsoluteLayout.LayoutBounds="0.5,0.5,30,30"
            AbsoluteLayout.LayoutFlags="PositionProportional"
            CornerRadius="15"
            HasShadow="False"
            VerticalOptions="Center" 
            HorizontalOptions="Center"
        >
    </Frame>
</AbsoluteLayout>
``` 

**STEP 5:** The appointment details can be obtained and displayed in popup by using the schedule [CellTapped](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~CellTapped_EV.html?) event.

``` c#
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
```
**Output**

![CircleAppointment](https://github.com/SyncfusionExamples/appointmenttemplate-schedule-xamarin/blob/master/ScreenShot/CircleAppointment.png)
