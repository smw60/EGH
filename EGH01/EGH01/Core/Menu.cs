using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EGH01.Core
{
    
    public class Menu:List<Menu.MenuItem>
    {
        public class MenuItem
        {
            public string Text    {get; private set;}
            public string Value   {get; private set;}
            public string OnClick {get; private set;}
            public bool   Enabled {get; private set;}
            public Menu   SubMenu {get; private set; }

            public MenuItem(string text, string value, string onclick, bool enabled, Menu submenu)
            {
                this.Text = text;
                this.Value = value;
                this.OnClick = onclick;
                this.Enabled = enabled;
                this.SubMenu = submenu;
            }
            public MenuItem(string text, string value, bool enabled)
            {
                this.Text = text;
                this.Value = value;
                this.OnClick = "";
                this.Enabled = enabled;
                this.SubMenu = null;
            }
            public bool Enable() 
            {
                bool rc = this.Enabled;
                this.Enabled = true;
                return rc;
            }
            public bool Disable()
            {
                bool rc = this.Enabled;
                this.Enabled = false;
                return rc;
            }
            public Menu GetSubMenu()
            {
                return this.SubMenu;
            }  
        }

        public Menu(params MenuItem[] items):base() 
        {
            foreach(MenuItem item in items)
            {
                this.Add(item);
            }
        }
        
        public void Disable()
        {
            this.ForEach(m => m.Disable()); 
        }
        public void Enable()
        {
            this.ForEach(m => m.Enable());
        }
    
    }



}