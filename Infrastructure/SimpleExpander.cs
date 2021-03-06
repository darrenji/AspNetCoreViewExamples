﻿using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreViewsExamples.Infrastructure
{
    public class SimpleExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach(string location in viewLocations)
            {
                yield return location.Replace("Shared", "Common");
            }
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //do nothing
        }
    }
}
