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
using System.Windows.Media.Imaging;

namespace BIM365.Ribbon
{
  internal static class Helpers
  {
    /// <summary>
    /// Create the RibbonTab.
    /// </summary>
    /// <param name="application">Appliction to create the RibbonTab in.</param>
    /// <param name="ribbon">RibbonTab to associate the RibbonTab with.</param>
    /// <param name="tabName">Name of the RibbonTab to create</param>
    /// <returns>The created RibbonTab.</returns>
    internal static RibbonTab CreateTab(UIControlledApplication application, RibbonControl ribbon, string tabName)
    {
      try
      {
        application.CreateRibbonTab(tabName);

        RibbonTab _tab = null;

        foreach (RibbonTab _existingTab in ribbon.Tabs)
        {
          if (_existingTab.Id == tabName)
          {
            _tab = _existingTab;

            break;
          }
        }

        if (_tab == null)
        {
          throw new Exception("Could not create tab: " + tabName);
        }

        return _tab;
      }
      catch (System.Exception _ex)
      {
        throw _ex;
      }
    }

    /// <summary>
    /// Get a Revit-usable ImageSource from an Embedded Resource PNG.
    /// Original code from: https://thebuildingcoder.typepad.com/blog/2009/11/ribbon-embed-image.html
    /// </summary>
    /// <param name="embeddedPath">Full Path to the Embedded Resource PNG.</param>
    /// <returns>ImageSource for the probided PNG full path.</returns>
    internal static ImageSource GetPngImageSource(string embeddedPath)
    {
      string _fullEmbeddedPath = embeddedPath;

      //If the path we have doesn't start with the right prefix, add it
      string _pathPrefix = "BIM365.Resources.";
      if (!embeddedPath.StartsWith(_pathPrefix, StringComparison.InvariantCultureIgnoreCase))
      {
        _fullEmbeddedPath = _pathPrefix + embeddedPath;
      }

      //If the path we have doesn't have the right suffix, add it
      string _extension = ".png";
      if (!_fullEmbeddedPath.EndsWith(_extension, StringComparison.InvariantCultureIgnoreCase))
      {
        _fullEmbeddedPath += _extension;
      }

      ImageSource _imageSource = null;
      try
      {
        Stream _stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_fullEmbeddedPath);
        PngBitmapDecoder _decoder = new PngBitmapDecoder(_stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);

        _imageSource = _decoder.Frames[0];
      }
      catch (Exception _ex)
      {
        Autodesk.Revit.UI.TaskDialog.Show("Error", _ex.Message + _ex.StackTrace);
      }

      return _imageSource;
    }
  }
}