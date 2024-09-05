using Domain.Entities.Base;

namespace Domain.Entities.OperatoreAggregate
{
    public class DaysOfWeekForWork : Entity
    {
        public string DayName { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<Employer> employers { get; private set; }
        private DaysOfWeekForWork(string dayName)
        {
            DayName = dayName;
            IsActive = true;
        }

        public static DaysOfWeekForWork Create(string dayName)
        {
             return new DaysOfWeekForWork(dayName);
        }

        public void RemoveDay()
        {
            this.IsActive = false;
        }
        public void RestoreDay()
        {
            this.IsActive = true;
        }


        //ctor for EfCore
        public DaysOfWeekForWork(){}

    }
}
