using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShortTermStudentModel : MonoBehaviour
{
    public List<string> _1;
    public List<string> _2;
    public List<string> _3;
    public List<string> _4;
    public List<string> _5;
    public List<string> _6;

    // Start is called before the first frame update
    public void Addtolist(string obj, string s)
    {
        if (obj == "_1")
        {
            _1.Add(s);
        }
        else if (obj == "_2")
        {
            _2.Add(s);
        }
        else if (obj == "_3")
        {
            _3.Add(s);
        }
        else if (obj == "_4")
        {
            _4.Add(s);
        }
        else if (obj == "_5")
        {
            _5.Add(s);
        }
        else if (obj == "_6")
        {
            _6.Add(s);
        }
    }
}
