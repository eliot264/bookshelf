using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookshelf.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy ListingModificationBar.xaml
    /// </summary>
    public partial class ListingModificationBar : UserControl
    {
        public string AddEntityButtonContent
        {
            get { return (string)GetValue(AddEntityButtonContentProperty); }
            set { SetValue(AddEntityButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddEntityButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddEntityButtonContentProperty =
            DependencyProperty.Register("AddEntityButtonContent", typeof(string), typeof(ListingModificationBar), new PropertyMetadata("Add entity"));

        public ICommand AddEntityButtonCommand
        {
            get { return (ICommand)GetValue(AddEntityButtonCommandProperty); }
            set { SetValue(AddEntityButtonCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddEntityButtonCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddEntityButtonCommandProperty =
            DependencyProperty.Register("AddEntityButtonCommand", typeof(ICommand), typeof(ListingModificationBar), new PropertyMetadata(null));

        public string DeleteEntitiesButtonContent
        {
            get { return (string)GetValue(DeleteEntitiesButtonContentProperty); }
            set { SetValue(DeleteEntitiesButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteEntitiesButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteEntitiesButtonContentProperty =
            DependencyProperty.Register("DeleteEntitiesButtonContent", typeof(string), typeof(ListingModificationBar), new PropertyMetadata("Delete entities"));

        public ICommand DeleteEntitiesButtonCommand
        {
            get { return (ICommand)GetValue(DeleteEntitiesButtonCommandProperty); }
            set { SetValue(DeleteEntitiesButtonCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteEntitiesButtonCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteEntitiesButtonCommandProperty =
            DependencyProperty.Register("DeleteEntitiesButtonCommand", typeof(ICommand), typeof(ListingModificationBar), new PropertyMetadata(null));

        public ListingModificationBar()
        {
            InitializeComponent();
        }
    }
}
