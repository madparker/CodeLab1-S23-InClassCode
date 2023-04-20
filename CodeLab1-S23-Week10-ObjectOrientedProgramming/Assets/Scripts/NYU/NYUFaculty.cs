using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUFaculty : NYUStaff
{
    public bool tenure = false;

    public NYUFaculty(string name, string netId, float salary, bool tenure) : base(name, netId, salary)
    {
        this.tenure = tenure;
        type = "NYU Faculty";
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + "\nTenured: " + tenure;
    }
}
