using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02EndToEndWebApp_done
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["test"] = _ => { return "HELLO"; };

        }
    }
}