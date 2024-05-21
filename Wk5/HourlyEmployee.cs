using System

namespace employee_demo
{
    public class HourlyEmployee : Employee
    {
        private float _payRate = 0;
        private int _hoursWorked = 0;

        public float GetPayRate()
        {
            return _payRate;
        }

        public vouid SetPayRate(float payRate)
        {
            _payRate = payRate;
        }

        public int GetHoursWorked()
        {
            return _hoursWorked;
        }

        public void SetHoursWorked(int hoursWorked)
        {
            _hoursWorked = hoursWorked;
        }
    }
}