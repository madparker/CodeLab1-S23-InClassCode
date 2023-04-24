using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUUndergrad : NYUStudent
{
    public string major;
    
    public NYUUndergrad(string name, string netId, float gpa, int credits, string major) : base(name, netId, gpa, credits)
    {
        type = "NYU Grad Student";
        this.major = major;
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + "\n"  + "Major: " + major;
    }
}

