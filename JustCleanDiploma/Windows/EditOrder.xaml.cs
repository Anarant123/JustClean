﻿using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;
using WorkingLibrary;

namespace JustCleanDiploma.Windows
{
	public partial class EditOrder : Window
	{
		public Pages.AdminPages.Orders orders;

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private WorkingLibrary.Models.Deal _deal;

		private string _Name = "Наименование";
		private string _Cost = "Стоимость";
		private string _Street = "Улица";
		private string _House = "Дом";
		private string _Flat = "Квартира";
		private string _Description = "Описание";
		private const int _DefaultIdStatus = 1;

		private List<WorkingLibrary.Models.DealStatus> _dealStatus;
		private List<WorkingLibrary.Models.Client> _client;
		private List<WorkingLibrary.Models.Office> _office;
		private List<WorkingLibrary.Models.User> _user;
		private List<WorkingLibrary.Models.Service> _service;

		public EditOrder(object sender)
		{
			InitializeComponent();

			_dealStatus = _dataWorking.GetDealStatuses(WorkingLibrary.SqlScripts.SelectSripts.SelectDealStatuses()).ToList();
			_client = _dataWorking.GetClients(WorkingLibrary.SqlScripts.SelectSripts.SelectClients()).ToList();
			_office = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			_user = _dataWorking.GetUsers(WorkingLibrary.SqlScripts.SelectSripts.SelectUsers()).ToList();
			_service = _dataWorking.GetServices(WorkingLibrary.SqlScripts.SelectSripts.SelectServices()).ToList();

			_deal = (sender as Grid).DataContext as WorkingLibrary.Models.Deal;

			InitWindow();
		}

		private void InitWindow()
		{
			Status.ItemsSource = _dealStatus;
			Office.ItemsSource = _office;

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.SelectedItem = _office.Where(x => x.Id == CurrentUser.user.IdOffice).Last();
				Office.IsEnabled = false;
				Client.ItemsSource = _client.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
				User.ItemsSource = _user.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
				Service.ItemsSource = _service.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
			}
			else
			{
				Client.ItemsSource = _client;
				User.ItemsSource = _user;
				Service.ItemsSource = _service;
			}

			OrderName.Text = _deal.Name;
			Cost.Text = Convert.ToString(_deal.Cost);

			if (_deal.Street != null)
			{
				Street.Text = _deal.Street;
			}

			if (_deal.House != null)
			{
				House.Text = _deal.House.ToString();
			}

			if (_deal.Flat != null)
			{
				Flat.Text = _deal.Flat.ToString();
			}

			CreateDate.Text = Convert.ToString(_deal.CreateDate);

			if (_deal.ProvisionDate != null)
			{
				CreateDate.Text = Convert.ToString(_deal.ProvisionDate);
			}

			if (_deal.IdStatus != null)
			{
				Status.SelectedValue = _dealStatus.Where(x => x.Id == _deal.IdStatus).Last();
			}

			Client.SelectedItem = _client.Where(x => x.Id == _deal.IdClient).Last();
			Office.SelectedItem = _office.Where(x => x.Id == _deal.IdOffice).Last();

			if (_deal.IdUser != null)
			{
				User.SelectedValue = _user.Where(x => x.Id == _deal.IdUser).Last();
			}

			if (_deal.IdService != null)
			{
				Service.SelectedValue = _service.Where(x => x.Id == _deal.IdService).Last();
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			orders.editOrder = null;
			orders.InitWindow();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(OrderName.Text) || OrderName.Text == _Name)
			{
				System.Windows.MessageBox.Show("Ввведите значение в поле Наименование");
				return;
			}

			if (String.IsNullOrEmpty(Cost.Text) || Cost.Text == _Cost)
			{
				System.Windows.MessageBox.Show("Ввведите значение в поле Стоимость");
				return;
			}

			if (CreateDate.SelectedDate == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Дата создания");
				return;
			}

			if (Client.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Клиент");
				return;
			}

			if (Office.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Офис");
				return;
			}

			if (Status.SelectedIndex == 1 && (User.SelectedItem == null || Service.SelectedItem == null))
			{
				MessageBox.Show("Для изменения заявки на статус `В работе` заполните поля Сотрудник и Усулуга");
				return;
			}

			if (Status.SelectedIndex == 3 && (User.SelectedItem == null || Service.SelectedItem == null))
			{
				MessageBox.Show("Для изменения заявки на статус `Завершенный` заполните поля Сотрудник и Услуга");
				return;
			}

			if (Status.SelectedIndex == 3 && ProvisionDate.SelectedDate == null)
			{
				ProvisionDate.SelectedDate = DateTime.Now;
			}

			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `deal` " +
				"SET `name` = @name, " +
				"`cost` = @cost, " +
				"`street` = @street, " +
				"`house` = @house, " +
				"`flat` = @flat, " +
				"`create_date` = @create_date, " +
				"`provision_date` = @provision_date, " +
				"`description` = @description, " +
				"`id_status` = @id_status, " +
				"`id_client` = @id_client, " +
				"`id_office` = @id_office, " +
				"`id_user` = @id_user, " +
				"`id_service` = @id_service " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = OrderName.Text;
			mySqlCommand.Parameters.Add("@cost", MySqlDbType.Int32).Value = Cost.Text;
			mySqlCommand.Parameters.Add("@street", MySqlDbType.VarChar).Value = (Street.Text == _Street ? null : Street.Text);
			mySqlCommand.Parameters.Add("@house", MySqlDbType.Int32).Value = (House.Text == _House ? null : House.Text);
			mySqlCommand.Parameters.Add("@flat", MySqlDbType.Int32).Value = (Flat.Text == _Flat ? null : Flat.Text);
			mySqlCommand.Parameters.Add("@create_date", MySqlDbType.Date).Value = CreateDate.SelectedDate.Value.ToString("yyyy-MM-dd");

			mySqlCommand.Parameters.Add("@provision_date", MySqlDbType.Date).Value = ProvisionDate.SelectedDate == null ? null : ProvisionDate.SelectedDate.Value.ToString("yyyy-MM-dd");

			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == _Description ? null : Description.Text;

			if (Status.SelectedItem == null)
			{
				mySqlCommand.Parameters.Add("@id_status", MySqlDbType.Int32).Value = _DefaultIdStatus;
			}
			else
			{
				var status = (WorkingLibrary.Models.DealStatus)Status.SelectedValue;
				mySqlCommand.Parameters.Add("@id_status", MySqlDbType.Int32).Value = status.Id;
			}

			var client = (WorkingLibrary.Models.Client)Client.SelectedValue;
			mySqlCommand.Parameters.Add("@id_client", MySqlDbType.Int32).Value = client.Id;

			var office = (WorkingLibrary.Models.Office)Office.SelectedValue;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			if (User.SelectedItem == null)
			{
				mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = null;
			}
			else
			{
				var user = (WorkingLibrary.Models.User)User.SelectedValue;
				mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
			}

			if (Service.SelectedItem == null)
			{
				mySqlCommand.Parameters.Add("@id_service", MySqlDbType.Int32).Value = null;
			}
			else
			{
				var service = (WorkingLibrary.Models.Service)Service.SelectedValue;
				mySqlCommand.Parameters.Add("@id_service", MySqlDbType.Int32).Value = service.Id;
			}

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = _deal.Id;

			dataBase.OpenConnection();

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				System.Windows.MessageBox.Show("Заявка успешно изменена");
			}
			else
			{
				System.Windows.MessageBox.Show("Ошибка изменения заявки");
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[13], CurrentUser.user.Id, CurrentUser.user.IdOffice);

			this.Close();
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			InitWindow();
		}

		private void OrderName_GotFocus(object sender, RoutedEventArgs e)
		{
			OrderName.Text = OrderName.Text == _Name ? "" : OrderName.Text;
		}

		private void OrderName_LostFocus(object sender, RoutedEventArgs e)
		{
			OrderName.Text = OrderName.Text == String.Empty ? _Name : OrderName.Text;
		}

		private void Cost_GotFocus(object sender, RoutedEventArgs e)
		{
			Cost.Text = Cost.Text == _Cost ? "" : Cost.Text;
		}

		private void Cost_LostFocus(object sender, RoutedEventArgs e)
		{
			Cost.Text = Cost.Text == String.Empty ? _Cost : Cost.Text;
		}

		private void Cost_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Street_GotFocus(object sender, RoutedEventArgs e)
		{
			Street.Text = Street.Text == _Street ? "" : Street.Text;
		}

		private void Street_LostFocus(object sender, RoutedEventArgs e)
		{
			Street.Text = Street.Text == String.Empty ? _Street : Street.Text;
		}

		private void House_GotFocus(object sender, RoutedEventArgs e)
		{
			House.Text = House.Text == _House ? "" : House.Text;
		}

		private void House_LostFocus(object sender, RoutedEventArgs e)
		{
			House.Text = House.Text == String.Empty ? _House : House.Text;
		}

		private void House_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Flat_GotFocus(object sender, RoutedEventArgs e)
		{
			Flat.Text = Flat.Text == _Flat ? "" : Flat.Text;
		}

		private void Flat_LostFocus(object sender, RoutedEventArgs e)
		{
			Flat.Text = Flat.Text == String.Empty ? _Flat : Flat.Text;
		}

		private void Flat_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить заявку?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			if (WorkingLibrary.SqlScripts.DeleteScripts.DeleteDeal(_deal.Id))
			{
				System.Windows.MessageBox.Show("Заявка была успешно удалена");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[14], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				this.Close();
			}
		}
	}
}
