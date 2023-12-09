using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD;

public class MockRepo : IEmployeeRepository
{
    public static List<Employee> _employeeList = new List<Employee>();
    public MockRepo()
    {
        _employeeList.Add(new Employee() { Id = 0, Name = "Rahul", Salary = 89990, Gender = "Male", Address = "Juhu, Mumbai" });
    }
    public Employee GetEmployee(int Id)
    {
        return _employeeList.FirstOrDefault(e => Id == e.Id);
    }
    public IEnumerable<Employee> GetAllEmployee()
    {
        return _employeeList;

    }
    public Employee Add(Employee employee)
    {
        employee.Id = _employeeList.Max(e => e.Id) + 1;
        _employeeList.Add(employee);
        return employee;
    }
    public Employee Update(Employee employeeChanges)
    {
        Employee employee = _employeeList.FirstOrDefault(emp => emp.Id == employeeChanges.Id);
        if (employee != null)
        {
            employee.Name = employeeChanges.Name;
            employee.Salary = employeeChanges.Salary;
            employee.Gender = employeeChanges.Gender;
            employee.Address = employeeChanges.Address;
        }
        return employee;
    }
    public Employee Delete(int Id)
    {
        Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
        if (employee != null)
        {
            _employeeList.Remove(employee);
        }
        return employee;
    }
    public Employee SearchByName(string name)
    {
        Employee employee = _employeeList.FirstOrDefault(e => e.Name == name);
        if (employee != null)
        {
            Console.WriteLine("\nName Found");
            Console.WriteLine(employee);

        }
        return employee;
    }
    public List<Employee> SearchLetter(char ch)
    {
        List<Employee> list = new List<Employee>();
        foreach (Employee emp in _employeeList)
        {
            if (emp.Name.StartsWith(ch))
                list.Add(emp);
        }
        return list;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        MockRepo db = new MockRepo();
        Display(db);
        Console.WriteLine();
        db.Add(new Employee() { Name = "Nayasa", Salary = 8000, Gender = "Male", Address = "Kandiwali, Mumbai" });
        Display(db);
        Console.WriteLine();
        Update(db);
        db.Add(new Employee() { Name = "Rahul", Salary = 89000, Gender = "Male", Address = "Kandiwali, Mumbai" });
        db.Add(new Employee() { Name = "Priyansh", Salary = 89000, Gender = "Male", Address = "Kandiwali, Mumbai" });
        db.Add(new Employee() { Name = "Pooja", Salary = 89000, Gender = "Male", Address = "Kandiwali, Mumbai" });
        Display(db);
        Console.WriteLine();
        db.Delete(1);
        Display(db);
        db.SearchByName("Pooja");
        Display(db);
        Console.WriteLine("///////");
        foreach (Employee e in db.SearchLetter('P'))
        {
            Console.WriteLine(e.Name);
        }
        //db.Update(new Employee() { Id = 3, Name = "Nebieee", Salary = 78000, Gender = "Male", Address = "Santa Cruz, Mumbai" })
    }
    static void Display(MockRepo db)
    {
        foreach (Employee e in db.GetAllEmployee())
            Console.WriteLine($"{e.Id} {e.Name} {e.Salary} {e.Gender} {e.Address}");
    }
    static void Update(MockRepo db)
    {
        Employee e = db.Update(new Employee() { Id = 1, Name = "Nebieee", Salary = 78000, Gender = "Male", Address = "Santa Cruz, Mumbai" });
    }
}
public interface IEmployeeRepository
{
    Employee GetEmployee(int Id);
    IEnumerable<Employee> GetAllEmployee();
    Employee Add(Employee employee);
    Employee Update(Employee employeeChanges);
    Employee Delete(int Id);
    /*        public String ToString()
            {
                return Id + " " + this.Name + " ";
            }*/
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
}
