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

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM365.Ribbon.Help
{
  [Transaction(TransactionMode.Manual)]
  [Regeneration(RegenerationOption.Manual)]
  internal class AboutCommand : IExternalCommand
  {
    /// <summary>
    /// Main method containing reference to code-behind the About command.
    /// </summary>
    /// <param name="commandData">Revit CommandData for the command.</param>
    /// <param name="message">Message stored for the command.</param>
    /// <param name="elements">Elements stored for the command.</param>
    /// <returns>Result of running the command.</returns>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      return execute(commandData.Application.ActiveUIDocument);
    }

    private Result execute(UIDocument uiDoc)
    {
      try
      {
        System.Diagnostics.Process.Start(@"https://www.bim365.tech/");
        return Result.Succeeded;
      }
      catch (Exception _ex)
      {
        TaskDialog.Show("Error", _ex.Message + _ex.StackTrace);
        return Result.Failed;
      }
    }
  }
}