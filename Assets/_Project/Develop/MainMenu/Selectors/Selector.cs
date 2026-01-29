using System;

namespace Assets._Project.Develop.MainMenu.Selectors
{
    public class Selector<SelectItems> where SelectItems : Enum
    {
        public SelectItems Selected { get; private set; }

        public void Select(SelectItems behavior)
        {
            Selected = behavior;
        }
    }
}
