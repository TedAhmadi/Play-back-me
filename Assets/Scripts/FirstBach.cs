using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBach : MonoBehaviour
{
    private List<string> ExpertFirstBach = new List<string> { "5", "2", "3", "1", "4", "6" };
    private List <string> ExpertSecondBach = new List<string> { "6", "3", "2", "1", "4", "5" };
    //{ "1", "2", "5" }{ "1", "2", "4", "3" } { "1", "4", "2", "6", "3" }{ "2", "6", "4", "3", "5", "1" }{ "1", "3", "1", "4", "6", "3", "1" }
    //{ "4", "6", "2" }{ "5", "4", "6", "1" } { "5", "1", "3", "4", "6" }{ "5", "6", "1", "4", "2", "3" }{ "4", "1", "6", "5", "1", "4", "2" }
    //{ "6", "1", "5" }{ "4", "6", "5", "1" } { "5", "4", "2", "1", "3" }{ "3", "5", "4", "1", "2", "6" }{ "5", "6", "4", "6", "1", "3", "2" }
    //{ "5", "2", "3" }{ "3", "4", "2", "6" } { "1", "6", "5", "3", "2" }{ "6", "3", "1", "2", "5", "4" }{ "2", "6", "2", "3", "1", "5", "3" }
    //{ "2", "4", "1" }{ "5", "6", "5", "4" } { "6", "2", "4", "5", "1" }{ "5", "1", "4", "6", "2", "3" }{ "1", "2", "6", "2", "6", "1", "6" }
    //{ "1", "4", "2" }{ "6", "5", "4", "5" } { "1", "2", "5", "6", "3" }{ "3", "5", "1", "4", "2", "6" }{ "2", "4", "2", "1", "5", "2", "5" }
    //{ "6", "3", "4" }{ "2", "1", "4", "5" } { "1", "4", "2", "5", "6" }{ "3", "5", "2", "6", "4", "1" }{ "2", "4", "6", "3", "6", "5", "6" }
    //{ "6", "3", "2" }{ "3", "2", "1", "8" } { "6", "2", "4", "5", "6" }{ "5", "1", "6", "4", "3", "2" }{ "2", "6", "2", "3", "2", "4", "3" }
    //{ "5", "6", "1" }{ "6", "2", "5", "1" } { "2", "6", "4", "3", "1" }{ "3", "4", "5", "2", "6", "1" }{ "6", "2", "3", "1", "3", "6", "5" }
    //{ "3", "5", "2" }{ "6", "4", "3", "1" } { "2", "5", "1", "6", "4" }{ "1", "3", "2", "5", "4", "6" }{ "4", "5", "6", "5", "3", "6", "2" }
    //{ "5", "2", "4" }{ "1", "2", "5", "2" } { "1", "3", "4", "2", "5" }{ "2", "6", "5", "1", "3", "4" }{ "5", "3", "2", "3", "4", "1", "3" }
    //{ "5", "3", "2" }{ "2", "3", "4", "5" } { "6", "5", "2", "3", "4" }{ "3", "6", "4", "5", "1", "2" }{ "6", "4", "2", "3", "4", "3", "5" }
    //{ "2", "6", "4" }{ "1", "4", "6", "3" } { "1", "2", "4", "3", "6" }{ "5", "6", "1", "3", "2", "4" }{ "1", "5", "2", "5", "4", "5", "1" }
    //{ "3", "1", "5" }{ "2", "6", "1", "2" } { "3", "1", "5", "6", "4" }{ "5", "6", "2", "4", "1", "3" }{ "2", "6", "1", "5", "1", "5", "6" }
    //{ "5", "3", "6" }{ "2", "4", "4", "2" } { "6", "1", "5", "4", "3" }{ "2", "1", "6", "3", "5", "4" }{ "3", "2", "5", "2", "6", "4", "1" }
    //{ "5", "1", "6" }{ "3", "5", "3", "2" } { "6", "3", "2", "1", "4" }{ "5", "6", "3", "1", "4", "2" }{ "2", "5", "6", "2", "3", "2", "4" }
    //{ "3", "2", "6" }{ "5", "1", "5", "4" } { "4", "3", "6", "1", "2" }{ "5", "1", "6", "2", "4", "3" }{ "4", "1", "3", "5", "3", "1", "3" }
    //{ "2", "6", "4" }{ "5", "2", "1", "2" } { "5", "2", "4", "6", "3" }{ "3", "1", "2", "6", "4", "5" }{ "3", "1", "5", "4", "2", "3", "4" }
    //{ "5", "3", "1" }{ "2", "4", "3", "5" } { "2", "3", "1", "4", "6" }{ "6", "1", "4", "5", "2", "3" }{ "3", "2", "4", "6", "5", "2", "6" }
    //{ "4", "6", "5" }{ "4", "3", "4", "2" } { "1", "4", "2", "5", "3" }{ "3", "6", "4", "1", "5", "2" }{ "5", "1", "3", "1", "5", "6", "4" }

    private List<string> _1 = new List<string> { "1", "2", "5" };
    private List<string> _2 = new List<string> { "1", "2", "4", "3" };
    private List<string> _3 = new List<string> { "4", "6", "2" };
    private List<string> _4 = new List<string> { "2", "6", "4", "3", "5", "1" }; 
    private List<string> _5 = new List<string> { "5", "6", "1", "4", "2", "3" };
    private List<string> _6 = new List<string> { "5", "1", "3", "4", "6" };
    private List<string> _7 = new List<string> { "5", "4", "2", "1", "3" };
    private List<string> _8 = new List<string> { "1", "6", "5", "3", "2" };
    private List<string> _9 = new List<string> { "3", "5", "4", "1", "2", "6" };
    private List<string> _10 = new List<string> { "6", "3", "1", "2", "5", "4" };
    private List<string> _11 = new List<string> { "6", "2", "4", "5", "1" };
    private List<string> _12 = new List<string> { "6", "1", "5" };
    private List<string> _13 = new List<string> { "5", "1", "4", "6", "2", "3" };
    private List<string> _14 = new List<string> { "5", "2", "3" };
    private List<string> _15 = new List<string> { "3", "5", "1", "4", "2", "6" };
    private List<string> _16 = new List<string> { "5", "6", "5", "4" };
    private List<string> _17 = new List<string> { "5", "1", "6", "4", "3", "2" };
    private List<string> _18 = new List<string> { "2", "4", "1" };
    private List<string> _19 = new List<string> { "1", "4", "2" };
    private List<string> _20 = new List<string> { "6", "3", "4" };

    private List<string> _21 = new List<string> { "3", "4", "5", "2", "6", "1" };
    private List<string> _22 = new List<string> { "1", "2", "5", "6", "3" };
    private List<string> _23 = new List<string> { "1", "3", "2", "5", "4", "6" };
    private List<string> _24 = new List<string> { "5", "4", "6", "1" };
    private List<string> _25 = new List<string> { "6", "3", "2" };
    private List<string> _26 = new List<string> { "5", "6", "1" };
    private List<string> _27 = new List<string> { "6", "5", "4", "5" };
    private List<string> _28 = new List<string> { "4", "6", "5", "1" };
    private List<string> _29 = new List<string> { "2", "1", "4", "5" };
    private List<string> _30 = new List<string> { "3", "2", "1", "5" };
    private List<string> _31 = new List<string> { "2", "6", "5", "1", "3", "4" };
    private List<string> _32 = new List<string> { "1", "4", "2", "6", "3" };
    private List<string> _33 = new List<string> { "1", "4", "2", "5", "6" };
    private List<string> _34 = new List<string> { "3", "6", "4", "5", "1", "2" };
    private List<string> _35 = new List<string> { "6", "2", "4", "5", "6" };
    private List<string> _36 = new List<string> { "3", "4", "2", "6" };
    private List<string> _37 = new List<string> { "3", "5", "2" };
    private List<string> _38 = new List<string> { "5", "6", "1", "3", "2", "4" };
    private List<string> _39 = new List<string> { "5", "6", "2", "4", "1", "3" };
    private List<string> _40 = new List<string> { "2", "6", "4", "3", "1" };
    private List<string> _41 = new List<string> { "2", "1", "6", "3", "5", "4" };
    private List<string> _42 = new List<string> { "2", "5", "1", "6", "4" };
    private List<string> _43 = new List<string> { "5", "2", "4" };
    private List<string> _44 = new List<string> { "6", "5", "2", "3", "4" };
    private List<string> _45 = new List<string> { "5", "6", "3", "1", "4", "2" };
    private List<string> _46 = new List<string> { "1", "3", "4", "2", "5" };
    private List<string> _47 = new List<string> { "6", "2", "5", "1" };
    private List<string> _48 = new List<string> { "6", "4", "3", "1" };
    private List<string> _49 = new List<string> { "1", "2", "4", "3", "6" };
    private List<string> _50 = new List<string> { "5", "3", "2" };
    private List<string> _51 = new List<string> { "5", "1", "6", "2", "4", "3" };
    private List<string> _52 = new List<string> { "1", "2", "5", "2" };
    private List<string> _53 = new List<string> { "3", "1", "2", "6", "4", "5" };
    private List<string> _54 = new List<string> { "2", "3", "4", "5" };
    private List<string> _55 = new List<string> { "2", "6", "4" };
    private List<string> _56 = new List<string> { "3", "1", "5" };
    private List<string> _57 = new List<string> { "6", "1", "4", "5", "2", "3" };
    private List<string> _58 = new List<string> { "1", "4", "6", "3" };
    private List<string> _59 = new List<string> { "3", "1", "5", "6", "4" };
    private List<string> _60 = new List<string> { "6", "1", "5", "4", "3" };
    private List<string> _61 = new List<string> { "3", "6", "4", "1", "5", "2" };
    private List<string> _62 = new List<string> { "2", "6", "1", "2" };
    private List<string> _63 = new List<string> { "2", "4", "4", "2" };
    private List<string> _64 = new List<string> { "6", "3", "2", "1", "4" };
    private List<string> _65 = new List<string> { "5", "3", "6" };
    private List<string> _66 = new List<string> { "4", "3", "6", "1", "2" };
    private List<string> _67 = new List<string> { "5", "1", "6" };
    private List<string> _68 = new List<string> { "3", "5", "3", "2" };
    private List<string> _69 = new List<string> { "3", "2", "6" };
    private List<string> _70 = new List<string> { "5", "1", "5", "4" };
    private List<string> _71 = new List<string> { "2", "6", "4" };
    private List<string> _72 = new List<string> { "5", "2", "1", "2" };
    private List<string> _73 = new List<string> { "5", "3", "1" };
    private List<string> _74 = new List<string> { "2", "4", "3", "5" };
    private List<string> _75 = new List<string> { "5", "2", "4", "6", "3" };
    private List<string> _76 = new List<string> { "1", "4", "2", "5", "3" };
    private List<string> _77 = new List<string> { "4", "6", "5" };
    private List<string> _78 = new List<string> { "2", "3", "1", "4", "6" };
    private List<string> _79 = new List<string> { "4", "3", "4", "2" };
    private List<string> _80 = new List<string> { "3", "5", "2", "6", "4", "1" };

    float clicked;
    float clicktime;
    float clickdelay = 0.1f;
    public AudioPlay playAudio;

    private float TimeIntervalBetweenHits = .8f;
    private float TimeInterval = 5.0f;
    private float lastEntryTime;
    //private bool doublepress = false;

    public GameObject Trial;
    string trialtex = "Trial";

    public static int count = 1;
    public Constrains constrains;
    private bool thriple;

    // Start is called before the first frame update
    //public void AddExpertBatch()
    //{
    //    //GameObject.Find("Constrains").GetComponent<Constrains>().ExpertBatch = ExpertFirstBach;
    //    constrains.ExpertModelBatch = ExpertFirstBach;
    //}

    public void AddExpertsecondBatch()
    {
        constrains.ExpertModelBatch = ExpertSecondBach;
    }
    void Start()
    {
        lastEntryTime = 0;
        thriple = false;
        clicked = 0;
        clicktime = 0;
    }

    public void doublepressflag()
    {
        constrains.doubleflag = true;
        playAudio.play("6");
    }
    //public void doublepressflag()
    //{

    //    clicked++;

    //    if (clicked == 1)
    //    {
    //        clicktime = Time.time;
    //    }

    //    if (clicked == 2  && Time.time - clicktime < clickdelay)
    //    {
    //        // Double click detected
    //        clicked = 0;
    //        clicktime = 0;
    //        constrains.doubleflag = true;
    //    }
    //    else if (clicked > 3 && Time.time - clicktime > 3)
    //    {
    //        clicked = 0;
    //    }
    //}

    //public void doublepressflag()
    //{
    //    if  (Time.time - lastEntryTime > TimeInterval)
    //    {
    //        constrains.doubleflag = false;
    //        lastEntryTime = Time.time;
    //        thriple = true;
    //    }
    //    else
    //    {
    //        thriple = false;
    //    }

    //    if (Time.time - lastEntryTime < TimeIntervalBetweenHits && thriple)
    //    {
    //        constrains.doubleflag = true;
    //        thriple = false;
    //    }
    //}

    public void AddExpertBatch()
    {
        if (constrains.doubleflag) {

            if (count == 1)
            {
                constrains.ExpertModelBatch = _1;
                constrains.NameOfBatch = "_1";
            }
            else if (count == 2)
            {
                constrains.ExpertModelBatch = _2;
                constrains.NameOfBatch = "_2";
            }
            else if (count == 3)
            {
                constrains.ExpertModelBatch = _3;
                constrains.NameOfBatch = "_3";
            }
            else if (count == 4)
            {
                constrains.ExpertModelBatch = _4;
                constrains.NameOfBatch = "_4";
            }
            else if (count == 5)
            {
                constrains.ExpertModelBatch = _5;
                constrains.NameOfBatch = "_5";
            }
            else if (count == 6)
            {
                constrains.ExpertModelBatch = _6;
                constrains.NameOfBatch = "_6";
            }
            else if (count == 7)
            {
                constrains.ExpertModelBatch = _7;
                constrains.NameOfBatch = "_7";
            }
            else if (count == 8)
            {
                constrains.ExpertModelBatch = _8;
                constrains.NameOfBatch = "_8";
            }
            else if (count == 9)
            {
                constrains.ExpertModelBatch = _9;
                constrains.NameOfBatch = "_9";
            }
            else if (count == 10)
            {
                constrains.ExpertModelBatch = _10;
                constrains.NameOfBatch = "_10";
            }
            else if (count == 11)
            {
                constrains.ExpertModelBatch = _11;
                constrains.NameOfBatch = "_11";
            }
            else if (count == 12)
            {
                constrains.ExpertModelBatch = _12;
                constrains.NameOfBatch = "_12";
            }
            else if (count == 13)
            {
                constrains.ExpertModelBatch = _13;
                constrains.NameOfBatch = "_13";
            }
            else if (count == 14)
            {
                constrains.ExpertModelBatch = _14;
                constrains.NameOfBatch = "_14";
            }
            else if (count == 15)
            {
                constrains.ExpertModelBatch = _15;
                constrains.NameOfBatch = "_15";
            }
            else if (count == 16)
            {
                constrains.ExpertModelBatch = _16;
                constrains.NameOfBatch = "_16";
            }
            else if (count == 17)
            {
                constrains.ExpertModelBatch = _17;
                constrains.NameOfBatch = "_17";
            }
            else if (count == 18)
            {
                constrains.ExpertModelBatch = _18;
                constrains.NameOfBatch = "_18";
            }
            else if (count == 19)
            {
                constrains.ExpertModelBatch = _19;
                constrains.NameOfBatch = "_19";
            }
            else if (count == 20)
            {
                constrains.ExpertModelBatch = _20;
                constrains.NameOfBatch = "_20";
            }

            else if (count == 21)
            {
                constrains.ExpertModelBatch = _21;
                constrains.NameOfBatch = "_21";
            }
            else if (count == 22)
            {
                constrains.ExpertModelBatch = _22;
                constrains.NameOfBatch = "_22";
            }
            else if (count == 23)
            {
                constrains.ExpertModelBatch = _23;
                constrains.NameOfBatch = "_23";
            }
            else if (count == 24)
            {
                constrains.ExpertModelBatch = _24;
                constrains.NameOfBatch = "_24";
            }
            else if (count == 25)
            {
                constrains.ExpertModelBatch = _25;
                constrains.NameOfBatch = "_25";
            }
            else if (count == 26)
            {
                constrains.ExpertModelBatch = _26;
                constrains.NameOfBatch = "_26";
            }
            else if (count == 27)
            {
                constrains.ExpertModelBatch = _27;
                constrains.NameOfBatch = "_27";
            }
            else if (count == 28)
            {
                constrains.ExpertModelBatch = _28;
                constrains.NameOfBatch = "_28";
            }
            else if (count == 29)
            {
                constrains.ExpertModelBatch = _29;
                constrains.NameOfBatch = "_29";
            }
            else if (count == 30)
            {
                constrains.ExpertModelBatch = _30;
                constrains.NameOfBatch = "_30";
            }

            else if (count == 31)
            {
                constrains.ExpertModelBatch = _31;
                constrains.NameOfBatch = "_31";
            }
            else if (count == 32)
            {
                constrains.ExpertModelBatch = _32;
                constrains.NameOfBatch = "_32";
            }
            else if (count == 33)
            {
                constrains.ExpertModelBatch = _33;
                constrains.NameOfBatch = "_33";
            }
            else if (count == 34)
            {
                constrains.ExpertModelBatch = _34;
                constrains.NameOfBatch = "_34";
            }
            else if (count == 35)
            {
                constrains.ExpertModelBatch = _35;
                constrains.NameOfBatch = "_35";
            }
            else if (count == 36)
            {
                constrains.ExpertModelBatch = _36;
                constrains.NameOfBatch = "_36";
            }
            else if (count == 37)
            {
                constrains.ExpertModelBatch = _37;
                constrains.NameOfBatch = "_37";
            }
            else if (count == 38)
            {
                constrains.ExpertModelBatch = _38;
                constrains.NameOfBatch = "_38";
            }
            else if (count == 39)
            {
                constrains.ExpertModelBatch = _39;
                constrains.NameOfBatch = "_39";
            }
            else if (count == 40)
            {
                constrains.ExpertModelBatch = _40;
                constrains.NameOfBatch = "_40";
            }

            else if (count == 41)
            {
                constrains.ExpertModelBatch = _41;
                constrains.NameOfBatch = "_41";
            }
            else if (count == 42)
            {
                constrains.ExpertModelBatch = _42;
                constrains.NameOfBatch = "_42";
            }
            else if (count == 43)
            {
                constrains.ExpertModelBatch = _43;
                constrains.NameOfBatch = "_43";
            }
            else if (count == 44)
            {
                constrains.ExpertModelBatch = _44;
                constrains.NameOfBatch = "_44";
            }
            else if (count == 45)
            {
                constrains.ExpertModelBatch = _45;
                constrains.NameOfBatch = "_45";
            }
            else if (count == 46)
            {
                constrains.ExpertModelBatch = _46;
                constrains.NameOfBatch = "_46";
            }
            else if (count == 47)
            {
                constrains.ExpertModelBatch = _47;
                constrains.NameOfBatch = "_47";
            }
            else if (count == 48)
            {
                constrains.ExpertModelBatch = _48;
                constrains.NameOfBatch = "_48";
            }
            else if (count == 49)
            {
                constrains.ExpertModelBatch = _49;
                constrains.NameOfBatch = "_49";
            }
            else if (count == 50)
            {
                constrains.ExpertModelBatch = _50;
                constrains.NameOfBatch = "_50";
            }

            else if (count == 51)
            {
                constrains.ExpertModelBatch = _51;
                constrains.NameOfBatch = "_51";
            }
            else if (count == 52)
            {
                constrains.ExpertModelBatch = _52;
                constrains.NameOfBatch = "_52";
            }
            else if (count == 53)
            {
                constrains.ExpertModelBatch = _53;
                constrains.NameOfBatch = "_53";
            }
            else if (count == 54)
            {
                constrains.ExpertModelBatch = _54;
                constrains.NameOfBatch = "_54";
            }
            else if (count == 55)
            {
                constrains.ExpertModelBatch = _55;
                constrains.NameOfBatch = "_55";
            }
            else if (count == 56)
            {
                constrains.ExpertModelBatch = _56;
                constrains.NameOfBatch = "_56";
            }
            else if (count == 57)
            {
                constrains.ExpertModelBatch = _57;
                constrains.NameOfBatch = "_57";
            }
            else if (count == 58)
            {
                constrains.ExpertModelBatch = _58;
                constrains.NameOfBatch = "_58";
            }
            else if (count == 59)
            {
                constrains.ExpertModelBatch = _59;
                constrains.NameOfBatch = "_59";
            }
            else if (count == 60)
            {
                constrains.ExpertModelBatch = _60;
                constrains.NameOfBatch = "_60";
            }

            else if (count == 61)
            {
                constrains.ExpertModelBatch = _61;
                constrains.NameOfBatch = "_61";
            }
            else if (count == 62)
            {
                constrains.ExpertModelBatch = _62;
                constrains.NameOfBatch = "_62";
            }
            else if (count == 63)
            {
                constrains.ExpertModelBatch = _63;
                constrains.NameOfBatch = "_63";
            }
            else if (count == 64)
            {
                constrains.ExpertModelBatch = _64;
                constrains.NameOfBatch = "_64";
            }
            else if (count == 65)
            {
                constrains.ExpertModelBatch = _65;
                constrains.NameOfBatch = "_65";
            }
            else if (count == 66)
            {
                constrains.ExpertModelBatch = _66;
                constrains.NameOfBatch = "_66";
            }
            else if (count == 67)
            {
                constrains.ExpertModelBatch = _67;
                constrains.NameOfBatch = "_67";
            }
            else if (count == 68)
            {
                constrains.ExpertModelBatch = _68;
                constrains.NameOfBatch = "_68";
            }
            else if (count == 69)
            {
                constrains.ExpertModelBatch = _69;
                constrains.NameOfBatch = "_69";
            }
            else if (count == 70)
            {
                constrains.ExpertModelBatch = _70;
                constrains.NameOfBatch = "_70";
            }

            else if (count == 71)
            {
                constrains.ExpertModelBatch = _71;
                constrains.NameOfBatch = "_71";
            }
            else if (count == 72)
            {
                constrains.ExpertModelBatch = _72;
                constrains.NameOfBatch = "_72";
            }
            else if (count == 73)
            {
                constrains.ExpertModelBatch = _73;
                constrains.NameOfBatch = "_73";
            }
            else if (count == 74)
            {
                constrains.ExpertModelBatch = _74;
                constrains.NameOfBatch = "_74";
            }
            else if (count == 75)
            {
                constrains.ExpertModelBatch = _75;
                constrains.NameOfBatch = "_75";
            }
            else if (count == 76)
            {
                constrains.ExpertModelBatch = _76;
                constrains.NameOfBatch = "_76";
            }
            else if (count == 77)
            {
                constrains.ExpertModelBatch = _77;
                constrains.NameOfBatch = "_77";
            }
            else if (count == 78)
            {
                constrains.ExpertModelBatch = _78;
                constrains.NameOfBatch = "_78";
            }
            else if (count == 79)
            {
                constrains.ExpertModelBatch = _79;
                constrains.NameOfBatch = "_79";
            }
            else if (count == 80)
            {
                constrains.ExpertModelBatch = _80;
                constrains.NameOfBatch = "_80";
            }
        }
    }

    public void CounterPlay()
    {
        if (constrains.doubleflag)
        {
            count++;
            Trial.GetComponent<TextMesh>().text = trialtex + count.ToString();
        }
    }
}
