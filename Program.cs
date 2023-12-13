
using VacationEmployee.Application;

var vacationDictionary = new Dictionary<string, List<DateTime>>()
{
    ["Иванов Иван Иванович"] = new List<DateTime>(),
    ["Петров Петр Петрович"] = new List<DateTime>(),
    ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
    ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
    ["Павлов Павел Павлович"] = new List<DateTime>(),
    ["Георгиев Георг Георгиевич"] = new List<DateTime>()
};
var days = 28;
var step = new int[] { 7, 14 };
var app = new VacationCounting(days, vacationDictionary, step);

app.ShowCalculatedVacationEmployee();