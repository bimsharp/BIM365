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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BIM365.Ribbon.Help
{
  /// <summary>
  /// Panel containing Help commands.
  /// </summary>
  internal static class Panel
  {
    internal static Autodesk.Revit.UI.RibbonPanel AddPanel(UIControlledApplication uiControlledApplication, RibbonTab ribbonTab, string panelName)
    {
      //Setup
      Autodesk.Revit.UI.RibbonPanel _panel = uiControlledApplication.CreateRibbonPanel(ribbonTab.Name, panelName);

      DirectoryInfo _thisAssemblyDirectoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);

      //About Button
      PushButtonData _aboutButtonData = new PushButtonData(
        "BIM365_About",
        "About",
        _thisAssemblyDirectoryInfo.FullName,
        typeof(AboutCommand).FullName);

      ImageSource _aboutImage = Helpers.GetPngImageSource(nameof(Properties.Resources.About_16x16));
      if (_aboutImage != null) _aboutButtonData.Image = _aboutImage;

      ImageSource _aboutLargeImage = Helpers.GetPngImageSource(nameof(Properties.Resources.About_32x32));
      if (_aboutLargeImage != null) _aboutButtonData.LargeImage = _aboutLargeImage;
      _aboutButtonData.ToolTip = "Visit BIM365.tech!";

      _panel.AddItem(_aboutButtonData);

      //Help button
      PushButtonData _helpButtonData = new PushButtonData(
        "BIM365_Help",
        "Help",
        _thisAssemblyDirectoryInfo.FullName,
        typeof(HelpCommand).FullName);

      ImageSource _helpImage = Helpers.GetPngImageSource(nameof(Properties.Resources.Help_16x16));
      if (_aboutImage != null) _helpButtonData.Image = _helpImage;

      ImageSource _helpLargeImage = Helpers.GetPngImageSource(nameof(Properties.Resources.Help_32x32));
      if (_aboutLargeImage != null) _helpButtonData.LargeImage = _helpLargeImage;
      _helpButtonData.ToolTip = "Learn more about this add-in!";

      _panel.AddItem(_helpButtonData);

      return _panel;
    }

  }
}