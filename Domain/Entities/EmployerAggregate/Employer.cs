using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OperatoreAggregate
{
    public class Employer : AggregateRoot
    {
        public string UserName { get; private set; }
        public string FullName { get; private set; }
        public string EmployerCode { get; private set; }
        public DateOnly EmploymentDate { get; private set; }
        public byte TimeOfContract { get; private set; }
        public bool IsActive { get; private set; }
        public HourseOfWork HourseOfWorks { get; private set; }
        public ICollection<DaysOfWeekForWork> DaysOfWeeksForWork { get; private set; }

        private Employer(string userName, string fullName, string employerCode, byte timeOfContract,
            TimeOnly StartWork, TimeOnly EndWork)
        {
            UserName = userName;
            FullName = fullName;
            EmployerCode = employerCode;
            EmploymentDate = DateOnly.FromDateTime(DateTime.Now);
            TimeOfContract = timeOfContract;
            HourseOfWorks = SetHourseOfWork(StartWork,EndWork); 
            IsActive = true;
        }

        public static Employer Create(string userName, string fullName, string employerCode,
            byte timeOfContract, TimeOnly StartWork, TimeOnly EndWork)
        {
            return new Employer(userName,fullName,employerCode,timeOfContract,StartWork,EndWork);
        }

        public HourseOfWork SetHourseOfWork(TimeOnly StartWork,TimeOnly EndWork)
        {
            return HourseOfWork.Create(StartWork,EndWork);
        }


        public void RemoveEmployer()
        {
            IsActive = false;
        }
        public void RestoreEmployer()
        {
            IsActive = true;
        }

        //ctor For EfCore
        public Employer()
        {
            
        }
    }
}
