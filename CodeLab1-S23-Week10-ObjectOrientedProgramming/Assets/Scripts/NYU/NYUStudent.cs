using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class NYUStudent : NYUPerson
{
    public float gpa = 4.0f;
    public int credits = 0;

    public NYUStudent(
        string name, string netId,
        float gpa, int credits) :
        base (name, netId)
    {
        this.gpa = gpa;
        this.credits = credits;

        type = "NYU Student";
    }

    public override string ShowRecord()
    {
        //return "lol, i overrode your class you've been powned";
        return base.ShowRecord() + "GPA: " + gpa;
    }
}
