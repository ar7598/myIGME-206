using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLib
{
    // Class: Schedule
    // Author: Ajay Ramnarine
    // Purpose: Creates schedules that will be used in the Course class
    // Restrictions: None
    public class Schedule 
    {
        public DateTime startTime;
        public DateTime endTime;
        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();
    }

    // Class: Courses
    // Author: Ajay Ramnarine
    // Purpose: Creates a list of courses, references course codes, and removes courses
    // Restrictions: None
    public class Courses
    {
        // sorted list indexed on courseCode (string) and storing Course objects
        public SortedList<string, Course> sortedList = new SortedList<string, Course>();
        public Course this[string courseCode]
        {
            get 
            {
                Course returnVal;
                try
                {
                    returnVal = sortedList[courseCode];
                }
                catch 
                {
                    returnVal = null;
                }

                return returnVal;
            }

            set
            {
                try
                {
                    sortedList[courseCode] = value;
                }
                catch 
                {
                    // checks for duplicates
                }
            }
        }

        // Method: Remove
        // Purpose: Removes a course code
        // Restrictions: None
        public void Remove(string courseCode) 
        {
            if (courseCode != null) 
            {
                sortedList.Remove(courseCode);
            }
        }

        // default constructor
        public Courses() 
        {
            Course thisCourse;
            Schedule thisSchedule;

            Random rand = new Random();

            //generate courses IGME-200 through IGME-299
            for(int i = 200; i <300; i++) 
            {
                // use constructor to create new course object with code and description
                thisCourse = new Course(($"IGME-{i}"), ($"Description for IGME-{i}"));

                // create new schedule object
                thisSchedule = new Schedule();
                for(int dow = 0; dow < 7; ++dow) 
                { 
                    // 50% chance of the class being on this day of week
                    if(rand.Next(0,2) == 1) 
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow);

                        // select random hour of day
                        int nHour = rand.Next(0, 24);

                        // set start and end times of minute duration
                        // select fixed date to tallow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0);
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0);

                    }
                }

                // set the schedule for this course
                thisCourse.schedule = thisSchedule;

                // add this course to the SortedList
                this[thisCourse.courseCode] = thisCourse;
            }
        }
    }

    // Class: Course
    // Author: Ajay Ramnarine
    // Purpose: Creates a course
    // Restrictions: None
    public class Course 
    {
        public string courseCode;
        public string description;
        public string teacherEmail;
        public Schedule schedule;

        public Course() { }

        public Course(string courseCode, string description) { }
    }
}
