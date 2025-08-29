namespace LINQDataManipulation;

public class Person
{
    public string FirstName { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }

    public Person(string name, int age, int salary)
    {
        FirstName = name;
        Age = age;
        Salary = salary;
    }
}