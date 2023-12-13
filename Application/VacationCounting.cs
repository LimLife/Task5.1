using System.Text;

namespace VacationEmployee.Application
{
    public class VacationCounting
    {
        private readonly Random _random;
        private readonly int _vacationDay;
        private readonly int[] _randomStepVacationDay;
        private readonly List<DayOfWeek> _weekdays;
        private DateTime _beginningYear => new(DateTime.Now.Year, 1, 1);
        private DateTime _endYear => new(DateTime.Today.Year, 12, 31);
        private Dictionary<string, List<DateTime>> _employeeVacation;
        public VacationCounting(int vacationDay, Dictionary<string, List<DateTime>> employeeVacation, int[] randomStepVacationDay)
        {
            _random = new Random();
            _vacationDay = vacationDay;
            _randomStepVacationDay = randomStepVacationDay;
            _employeeVacation = employeeVacation;
            _weekdays =
            [
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday
            ];
        }

        public void ShowCalculatedVacationEmployee()
        {
            CalculatedVacations();
            var builder = new StringBuilder();
            builder.AppendLine("|     Сотрудник                  |     Дни отпуска |");
            builder.AppendLine("|--------------------------------|-----------------|");
            foreach (var employee in _employeeVacation)
            {
                builder.AppendLine($"|     {employee.Key}        |                   |");
                var vactions = employee.Value;
                for (var i = 0; i < vactions.Count; i++)
                {
                    builder.AppendLine($"|                |      {vactions[i].ToString()}       | ");
                }
            }
            Console.WriteLine(builder.ToString());
        }
        private void CalculatedVacations()
        {

            foreach (var employee in _employeeVacation)
            {
                var data = CalculatedVacationEmployee();
                for (int i = 0; i < data.Count; i++)
                    employee.Value.Add(data[i]);
            }
        }

        private List<DateTime> CalculatedVacationEmployee()
        {
            int yearDays = (_endYear - _beginningYear).Days;
            var dataVaasctions = new List<DateTime>();
            var vactionDays = _vacationDay;
            while (vactionDays > 0)
            {
                var startVacation = _beginningYear.AddDays(_random.Next(yearDays));
                if (_weekdays.Contains(startVacation.DayOfWeek))
                {
                    var randomVacationLength = _randomStepVacationDay[_random.Next(_randomStepVacationDay.Length)];
                    randomVacationLength = randomVacationLength > vactionDays ? randomVacationLength - vactionDays : randomVacationLength;
                    var temp = startVacation.AddDays(randomVacationLength);
                    if (!dataVaasctions.Any(vacation => vacation.AddDays(3) >= startVacation && vacation.AddDays(3) <= _endYear))//??
                    {
                        vactionDays -= randomVacationLength;
                        dataVaasctions.Add(temp);
                    }
                }
            }
            return dataVaasctions;
        }
    }
}
