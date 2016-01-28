using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ButtonColumn_DelegateCommand
{
	public class MyViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private ObservableCollection<Club> clubs;
		private ObservableCollection<Player> players;
		private object selectedItem;
		private ICommand myCommand;

		public ICommand MyCommand 
		{
			get
			{
				return myCommand;
			}
		}

		public MyViewModel()
		{
			myCommand = new DelegateCommand<object>(myCommand_Execute);
		}

		private void myCommand_Execute(object obj)
		{
			MessageBox.Show("The MyCommand has been executed");
		}

		public ObservableCollection<Club> Clubs
		{
			get
			{
				if (this.clubs == null)
				{
					this.clubs = Club.GetClubs();
				}

				return this.clubs;
			}
		}

		public ObservableCollection<Player> Players
		{
			get
			{
				if (this.players == null)
				{
					this.players = Player.GetPlayers();
				}

				return this.players;
			}
		}

		public object SelectedItem
		{
			get
			{
				return this.selectedItem;
			}
			set
			{
				if (value != this.selectedItem)
				{
					this.selectedItem = value;
					this.OnPropertyChanged("SelectedItem");
				}
			}
		}

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, args);
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
	}
}
