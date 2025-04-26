using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server.Model
{
    internal class Imagelist
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }
        public List<ImageElement> Images { get; set; }
        public OpenDays ActiveDays { get; set; }
        public int Starttime { get; set; }
        public int Endtime { get; set; }

        public void SetStarttime(int hours, int minutes)
        {
            Starttime = hours * 60 + minutes;
        }

        public void SetEndtime(int hours, int minutes)
        {
            Endtime = hours * 60 + minutes;
        }

        public TimeSpan GetStartTime()
        {
            return TimeSpan.FromMinutes(Starttime);
        }

        public TimeSpan GetEndTime()
        {
            return TimeSpan.FromMinutes(Endtime);
        }

        public bool IsInActiveTime(int hour, int minute)
        {
            int currentTime = hour * 60 + minute;
            return currentTime >= Starttime && currentTime <= Endtime;
        }

        public Imagelist()
        {
            IsActive = true;
            ActiveDays = OpenDays.Monday | OpenDays.Tuesday | OpenDays.Wednesday | OpenDays.Thursday | OpenDays.Friday | OpenDays.Saturday | OpenDays.Sunday;
            Images = new List<ImageElement>();
            Id = Guid.NewGuid();

            SetEndtime(23, 59);
        }
    }
}
