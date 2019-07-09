//MIT License
//
//Copyright(c) 2019 Zach Smith
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM365.Ribbon
{
  /// <summary>
  /// Main entry point for this plug-in.
  /// </summary>
  public class App : IExternalApplication
  {
    /// <summary>
    /// Setup tasks associated with this plug-in.
    /// </summary>
    /// <param name="application">Revit Controlled Application to associate this plug-in with.</param>
    /// <returns>Result of the actions performed OnStartup.</returns>
    public Result OnStartup(UIControlledApplication application)
    {
      try
      {
        RibbonControl _ribbon = ComponentManager.Ribbon;

        string _tabName = "BIM 365";
        RibbonTab _tab = Helpers.CreateTab(application, _ribbon, _tabName);

        string _helpPanelName = "Help";
        Help.Panel.AddPanel(application, _tab, _helpPanelName);

        return Result.Succeeded;
      }
      catch (Exception _ex)
      {
        Autodesk.Revit.UI.TaskDialog.Show(
          "Error", 
          _ex.Message + _ex.StackTrace);

        return Result.Failed;
      }
    }

    /// <summary>
    /// Shutdown tasks associated with this plug-in.
    /// </summary>
    /// <param name="application">Revit Controlled Application to associate this plug-in with.</param>
    /// <returns>Result of the actions performed OnShutdown.</returns>
    public Result OnShutdown(UIControlledApplication application)
    {
      return Result.Succeeded;
    }
  }
}