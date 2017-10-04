using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreViewsExamples.Infrastructure
{
    public class DebugDataViewEngine : IViewEngine
    {
        /// <summary>
        /// IViewEngine是产生ViewEngineResult
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewName"></param>
        /// <param name="isMainPage"></param>
        /// <returns></returns>
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            if (viewName == "DebugData")
            {
               return ViewEngineResult.Found(viewName, new DebugDataView());
            }
            else
            {
                return ViewEngineResult.NotFound(viewName, new string[] { "Debug View Engine - FindView" });
            }
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            return ViewEngineResult.NotFound(viewPath, new string[] { "Debug View Engine - GetView" });
        }
    }
}
