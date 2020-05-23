using Alert.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Alert
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GetAllList();
        }

        private void btnGetAllList_Click(object sender, RoutedEventArgs e)
        {
            GetAllList();
        }
        private void GetAllList()
        {
            RoutineList.ItemsSource = Controllers.RoutineDetailController.GetRoutines();
        }
        private void btnViewDetail(object sender, RoutedEventArgs e)
        {
            var toViewId = ((Button)sender).Tag;
            var selectedItemModel = Controllers.RoutineDetailController.GetSelectedRoutine((int)toViewId);
            var dialog = new MessageDialog(selectedItemModel.RoutineTitle);
            dialog.ShowAsync();
            //MessageBox.Show(selectedItemModel.RoutineTitle);
        }
        private void btnDeleteDetail(object sender, RoutedEventArgs e)
        {
            //var toViewId = ((Button)sender).Tag;
            //var selectedItemModel = Controllers.RoutineDetailController.DeleteSelectedRoutine((int)toViewId);
            GetAllList();
        }

        private void btnAddNewRoutine_Add(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewRoutine), null);
        }
    }
}
