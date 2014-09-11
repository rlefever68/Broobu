using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.Fx.UI.Interfaces;
using DevExpress.Data.Selection;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;


namespace Broobu.Desktop.UI
{
    internal class RibbonBuilder
    {



        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentTab"></param>
        /// <param name="page"></param>
        private static void BuildPage(RibbonPage currentPage, Page page)
        {
            if(page==null) return;
            foreach (var pg in page.Parts.OfType<PageGroup>())
            {
                var currentGroup = new RibbonPageGroup() 
                {
                    Caption = pg.DisplayName

                    
                    //ToolTip = menuInfo.ToolTip
                };
                currentPage.Groups.Add(currentGroup);
                BuildGroup(currentGroup,pg);
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        private static BarButtonItem CreateButton(MenuButton menuInfo)
        {
            if (menuInfo == null) return null;
            var b = new BarButtonItem()
            {
                Content = menuInfo.Caption,
                Tag = menuInfo.LaunchUrl,
                ToolTip = menuInfo.ToolTip,
                LargeGlyph = menuInfo.Glyph
            };
            b.ItemClick += (s, e) => _appletClickedAction(b.Tag, RunMode.Normal);
            return b;
        }



        /// <summary>
        /// Creates the image source.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static ImageSource CreateImageSource(byte[] p)
        {
            // return ((p!=null) && (p.Length==0)) ? ResourceUtil.ByteArrayToImageSource(p) : GetDefaultIcon();
            return GetDefaultIcon();
        }

        /// <summary>
        /// Gets the default icon.
        /// </summary>
        /// <returns></returns>
        private static ImageSource GetDefaultIcon()
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource =
                new Uri("pack://application:,,,/Iris.Fx;component/Resources/applet.png");
            img.EndInit();
            return img;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentGroup"></param>
        /// <param name="items"></param>
        private static void BuildGroup(RibbonPageGroup currentGroup, PageGroup items)
        {
            if (items == null) return;
            foreach (var item in items.Parts.OfType<MenuButton>())
            {
                currentGroup.Items.Add(CreateButton(item));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static Action<object, RunMode> _appletClickedAction;

        /// <summary>
        /// Builds the specified ribbon.
        /// </summary>
        /// <param name="ribbon">The ribbon.</param>
        /// <param name="items">The items.</param>
        /// <param name="doAppletItemClicked">The do applet item clicked.</param>
        public static void Build(RibbonControl control, MenuContainer items, Action<object, RunMode> doAppletItemClicked)
        {
            ClearDynamicPages(control);
            _appletClickedAction = doAppletItemClicked;
            if (items == null) return;
            var c = items.Parts.OfType<PageCategory>().Count();
            var s = String.Format(c.ToString());
            foreach (var cat in items.Parts.OfType<PageCategory>())
            {
                var currentCategory = new RibbonPageCategory()
                {
                    Tag = "CanDelete",
                    ToolTip = cat.ToolTip,
                    Caption = cat.DisplayName
                };
                control.Categories.Add(currentCategory);
                BuildCategory(currentCategory, cat);
            }
        }

        private static void BuildCategory(RibbonPageCategory currentCategory, PageCategory cat)
        {
            if(cat==null) return;
            foreach (var page in cat.Parts.OfType<Page>())
            {
                var currentPage = new RibbonPage()
                {
                    Caption = page.DisplayName
                };
                currentCategory.Pages.Add(currentPage);
                BuildPage(currentPage, page);
            }
        }


        public static void ClearDynamicPages(RibbonControl control)
        {
            var c = control.Categories.Count(x => Convert.ToString(x.Tag) == "CanDelete");
            var s = String.Format(c.ToString());
            var lst = control.Categories.Where(x => Convert.ToString(x.Tag) == "CanDelete").ToList();
            foreach (var category in lst)
            {
                control.Categories.Remove(category);
            }
        }
    }
}
