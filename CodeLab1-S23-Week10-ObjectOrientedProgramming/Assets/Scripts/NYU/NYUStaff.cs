using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUStaff : NYUPerson
{
    public float salary = 1000000000;

    public NYUStaff(string name, string netId, float salary) : 
        base(name, netId)
    {
        this.salary = salary;
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + "Salary: " + salary;
    }
}
