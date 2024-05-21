using System

namespace employee_demo
{
    public class Employee
    {
        protected string _name;
        protected string _idNumber;

        public employee_demo()
        {
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetIdNumber(string idNumber)
        {
            _idNumber = idNumber;
        }
    }
}
