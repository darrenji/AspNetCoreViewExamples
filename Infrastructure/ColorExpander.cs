using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreViewsExamples.Infrastructure
{
    public class ColorExpander : IViewLocationExpander
    {
        private static Dictionary<string, string> Colors = new Dictionary<string, string> {
            ["red"] = "Red",
            ["green"]="Green",
            ["blue"]="Blue"
        };
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            string color;
            context.Values.TryGetValue("color", out color);
            foreach(string location in viewLocations)
            {
                if(!string.IsNullOrEmpty(color))
                {
                    yield return location.Replace("{0}", color);
                } else
                {
                    yield return location;
                }
            }
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //获取路由数据
            var routeValues = context.ActionContext.RouteData.Values;
            string color;

            //id从路由中来，而且id的值就是red, green或blue
            if (routeValues.ContainsKey("id")
                && Colors.TryGetValue(routeValues["id"] as string, out color)
                && !string.IsNullOrEmpty(color))
            {
                context.Values["color"] = color;
            }
        }
    }
}
