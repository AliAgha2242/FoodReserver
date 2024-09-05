using Domain.Entities.Base;

namespace Domain.Entities.OperatoreAggregate
{
    public class HistoryOfEmployerWork : Entity
    {


        public Guid EmployerId { get; private set; }
        public TimeOnly StartWorkHours { get; private set; }
        public DateOnly StartWorkDay { get; private set; }
        public TimeOnly? EndWorkHourse { get; private set; }
        public DateOnly? EndWorkDay { get; private set; }
        public Employer Employer { get; private set; }

        private HistoryOfEmployerWork(Guid employerId, TimeOnly startWorkHours,
           DateOnly startWorkDay, TimeOnly endWorkHourse, DateOnly endWorkDay)
        {
            EmployerId = employerId;
            StartWorkHours = TimeOnly.FromDateTime(DateTime.Now);
            StartWorkDay = DateOnly.FromDateTime(DateTime.Now);
        }

        public void SetEndWork()
        {
            this.EndWorkHourse = TimeOnly.FromDateTime(DateTime.Now);
            this.EndWorkDay = DateOnly.FromDateTime(DateTime.Now);
        }


        public static HistoryOfEmployerWork Create(Guid employerId, TimeOnly startWorkHours,
            DateOnly startWorkDay, TimeOnly endWorkHourse, DateOnly endWorkDay)
        {
            return new HistoryOfEmployerWork(employerId, startWorkHours, startWorkDay,
                endWorkHourse, endWorkDay);
        }

        //ctor for EfCore
        public HistoryOfEmployerWork() { }


    }
}
