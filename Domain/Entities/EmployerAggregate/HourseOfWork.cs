using Domain.Entities.Base;

namespace Domain.Entities.OperatoreAggregate
{
    public class HourseOfWork : Entity
    {
        public TimeOnly StartWork { get; private set; }
        public TimeOnly EndWork { get; private set; }
        public ICollection<Employer> Employers { get; private set; }
        private HourseOfWork(TimeOnly startWork, TimeOnly endWork)
        {
            StartWork = startWork;
            EndWork = endWork;
        }

        public static HourseOfWork Create(TimeOnly StartWork,TimeOnly EndWork)
        {
            return new HourseOfWork(StartWork,EndWork);
        }

        public void Edit(TimeOnly startWork, TimeOnly endWork)
        {
            this.StartWork = startWork;
            this.EndWork = endWork;
        }




        //Ctor For EfCore
        public HourseOfWork(){}
    }
}
