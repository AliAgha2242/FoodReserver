using Domain.Entities.Base;
using Domain.Entities.ReciveAggregate;
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
        public Guid HourseOfWorkId { get; private set; }
        public DateOnly EmploymentDate { get; private set; }
        public byte TimeOfContract { get; private set; }
        public bool IsActive { get; private set; }
        public HourseOfWork HourseOfWork { get; private set; }
        public ICollection<DaysOfWeekForWork> DaysOfWeeksForWork { get; private set; }
        public ICollection<Recive> Recives { get; private set; }

        private Employer(string userName, string fullName, string employerCode, byte timeOfContract,
           Guid hoursOfWorkId )
        {
            UserName = userName;
            FullName = fullName;
            EmployerCode = employerCode;
            EmploymentDate = DateOnly.FromDateTime(DateTime.Now);
            TimeOfContract = timeOfContract;
            IsActive = true;
            HourseOfWorkId = hoursOfWorkId ;
        }

        public static Employer Create(string userName, string fullName, string employerCode,
            byte timeOfContract, Guid hourseOfWorkId)
        {
            return new Employer(userName,fullName,employerCode,timeOfContract,hourseOfWorkId);
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
