using _03_MVVM.Enums;
using _03_MVVM.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _03_MVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        #region Properties
        private string dataPath => $"{Environment.CurrentDirectory}\\..\\..\\Data\\Items.json";

        private string title = "03 WPF / MVVM Task";
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        private ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private ObservableCollection<ItemModel> categories = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        private ItemModel selectedCategory = new ItemModel();
        public ItemModel SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            Init();
        }


        private async void Init()
        {
            await LoadDataAsync();

            Categories = new ObservableCollection<ItemModel>()
            {
               new ItemModel() {Icon = "\uf51e", BackgroundColor = Brushes.LimeGreen, Category = Enums.CategoryType.Salary},
               new ItemModel() {Icon = "\uf1b9", BackgroundColor = Brushes.DarkBlue, Category = Enums.CategoryType.Car},
               new ItemModel() {Icon = "\uf290", BackgroundColor = Brushes.YellowGreen, Category = Enums.CategoryType.Clothing},
               new ItemModel() {Icon = "\uf805", BackgroundColor = Brushes.Purple, Category = Enums.CategoryType.Food},
               new ItemModel() {Icon = "\uf0f4", BackgroundColor = Brushes.Orange, Category = Enums.CategoryType.Leisure},
               new ItemModel() {Icon = "\ue065", BackgroundColor = Brushes.LightBlue, Category = Enums.CategoryType.Living}
            };

        }


        #endregion

        #region Methods & Tasks


        private Task SaveDataAsync()
        {

            try
            {
                File.WriteAllText(dataPath, JsonConvert.SerializeObject(Items));
                return Task.FromResult(true);
            }
            catch
            {
                MessageBox.Show("An error occurred when saving data", "Error");

                return Task.FromResult(false);
            }

        }

        private Task LoadDataAsync()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<List<ItemModel>>(File.ReadAllText(dataPath));

                Items = new ObservableCollection<ItemModel>(items);
                return Task.FromResult(true);

            }
            catch
            {
                MessageBox.Show("An error occurred when loading data", "Error");
                return Task.FromResult(false);
            }
        }

        private async Task ClearSelectedItemAndSaveAsync()
        {
            SelectedCategory = new ItemModel();
            RaisePropertyChanged(nameof(SelectedCategory));
            await SaveDataAsync();

        }


        #endregion

        #region Commands

        public DelegateCommand<ItemModel> DeleteItemCommand => new DelegateCommand<ItemModel>(async (o) =>
        {

            if (o != null)
            {

                var confirm = MessageBox.Show("Are you sure want to delete item?", "Confirm", MessageBoxButton.YesNo);

                if (confirm == MessageBoxResult.Yes)
                {
                    var isExists = Items.Where(w => w == o).FirstOrDefault();

                    if (isExists != null)
                    {
                        Items.Remove(isExists);

                        await SaveDataAsync();
                    }

                }


            }

        });

        public DelegateCommand<ComboBox> OpenComboBoxCommand => new DelegateCommand<ComboBox>((o) =>
        {
            if (o != null)
            {
                o.IsDropDownOpen = true;
            }

        });

        public DelegateCommand CloseWindowCommand => new DelegateCommand(async () =>
        {
            await SaveDataAsync();
        });

        public DelegateCommand AddItemCommand => new DelegateCommand(async () =>
        {
            double.TryParse(SelectedCategory.Cost.ToString(), out double cost);


            var isCategoryExits = Items.Where(w => w.Category == SelectedCategory.Category).FirstOrDefault();


            if (isCategoryExits == null)
            {
                if
                (
                    SelectedCategory.Category != CategoryType.None
                    && !string.IsNullOrEmpty(SelectedCategory.Icon)
                    && SelectedCategory.BackgroundColor != null
                    && cost != 0.0

                )
                {
                    Items.Add(new ItemModel()
                    {
                        BackgroundColor = SelectedCategory.BackgroundColor,
                        Category = SelectedCategory.Category,
                        Icon = SelectedCategory.Icon,
                        Cost = SelectedCategory.Cost
                    });

                    await ClearSelectedItemAndSaveAsync();

                }
                else
                {
                    MessageBox.Show("Please check cost value and fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (cost != 0.0)
                {

                    isCategoryExits.Cost = SelectedCategory.Cost;
                    await ClearSelectedItemAndSaveAsync();

                    MessageBox.Show("Exitst category's cost has updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("You must enter valid cost value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        });

        #endregion
    }
}
