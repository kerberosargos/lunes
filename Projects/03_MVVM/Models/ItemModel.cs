using _03_MVVM.Enums;
using Prism.Mvvm;
using System.Windows.Media;

namespace _03_MVVM.Models
{
    public class ItemModel : BindableBase
    {

        private string icon;
        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }

        private Brush backgroundColor;
        public Brush BackgroundColor
        {
            get => backgroundColor;
            set => SetProperty(ref backgroundColor, value);
        }

        private CategoryType category;
        public CategoryType Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }


        private double cost;
        public double Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }

    }
}
