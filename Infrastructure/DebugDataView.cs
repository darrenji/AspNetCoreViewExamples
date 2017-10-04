using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace AspNetCoreViewsExamples.Infrastructure
{
    public class DebugDataView : IView
    {
        public string Path
        {
            get
            {
                return string.Empty;
            }
        }

        //ViewContext继承于ActionContext,都有一个HttpContext属性
        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------Routing Data------");
            foreach(var item in context.RouteData.Values)
            {
                sb.AppendLine($"key: {item.Key}, value: {item.Value}");
            }
            sb.AppendLine("------View Data------");
            foreach(var item in context.ViewData)
            {
                sb.AppendLine($"key: {item.Key}, value: {item.Value}");
            }
            await context.Writer.WriteLineAsync(sb.ToString());
        }
    }
}
