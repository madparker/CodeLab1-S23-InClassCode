using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUGradStudent : NYUStudent
{
    public string degreeType;
    
    public NYUGradStudent(string name, string netId, float gpa, int credits, string degreeType) : base(name, netId, gpa, credits)
    {
        type = "NYU Grad Student";
        this.degreeType = degreeType;
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + "\n"  + "Degree: " + degreeType;
    }
}
