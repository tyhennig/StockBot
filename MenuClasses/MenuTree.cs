using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class MenuTree
    {

        protected string title;

        private MenuContent content;
        private MenuTree parentMenu;
        private List<MenuTree> childMenus;

        public MenuTree(string title)
        {
            this.title = title;
            //this.content = content;
            childMenus = new List<MenuTree>();
        }

        public string getTitle()
        {
            return title;
        }
        
        public MenuContent getContent()
        {
            return content;
        }
        public void setContent(MenuContent content)
        {
            this.content = content;
            //hasContent = true;
        }
        public MenuTree getParentMenu()
        {
            return parentMenu;
        }
        public List<MenuTree> getChildMenuList()
        {
            return childMenus;
        }
        public MenuTree createChildMenu(string title)
        {
            MenuTree newMenu = new MenuTree(title);
            newMenu.parentMenu = this;
            childMenus.Add(newMenu);

            return newMenu;
        }
        

        public void run()
        {
            content.run();
        }
    }

}
