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
using WorkingLibrary.SqlScripts;

namespace JustCleanDiploma.Windows
{
	public partial class RegistrationWindow : Window
	{
		private const string _LoginText = "Логин";
		private const string _PasswordText = "Пароль более 4 символов";
		private const string _SecondPasswordText = "Повторите пароль";
		private const string _Mail = "Почта";
		private const string _UserName = "Имя";
		private int _ban = 0;

		private AuthorizationWindow _authWindow;
		public PasswordDialogWindow passwordDialogWindow;
		private DataWorking _dataWorking = new DataWorking();

		public RegistrationWindow()
		{
			InitializeComponent();
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			var width = this.ActualWidth;
			var height = this.ActualHeight;

			if (width <= 900)
			{
				Advertisement.Visibility = Visibility.Collapsed;
				Grid.SetColumnSpan(ContentBox, 2);
			}
			else
			{
				Advertisement.Visibility = Visibility.Visible;
				Grid.SetColumnSpan(ContentBox, 1);
				Grid.SetColumn(ContentBox, 0);
			}
		}

		private void Login_GotFocus(object sender, RoutedEventArgs e)
		{
			Login.Text = Login.Text == _LoginText ? "" : Login.Text;
		}

		private void Login_LostFocus(object sender, RoutedEventArgs e)
		{
			Login.Text = Login.Text == String.Empty ? _LoginText : Login.Text;
		}

		private void Password_GotFocus(object sender, RoutedEventArgs e)
		{
			Password.Text = Password.Text == _PasswordText ? "" : Password.Text;
		}

		private void Password_LostFocus(object sender, RoutedEventArgs e)
		{
			Password.Text = Password.Text == String.Empty ? _PasswordText : Password.Text;
		}

		private void SecondPassword_GotFocus(object sender, RoutedEventArgs e)
		{
			SecondPassword.Text = SecondPassword.Text == _SecondPasswordText ? "" : SecondPassword.Text;
		}

		private void SecondPassword_LostFocus(object sender, RoutedEventArgs e)
		{
			SecondPassword.Text = SecondPassword.Text == String.Empty ? _SecondPasswordText : SecondPassword.Text;
		}

		private void Mail_GotFocus(object sender, RoutedEventArgs e)
		{
			Mail.Text = Mail.Text == _Mail ? "" : Mail.Text;
		}

		private void Mail_LostFocus(object sender, RoutedEventArgs e)
		{
			Mail.Text = Mail.Text == String.Empty ? _Mail : Mail.Text;
		}

		private void UserName_GotFocus(object sender, RoutedEventArgs e)
		{
			UserName.Text = UserName.Text == _UserName ? "" : UserName.Text;
		}

		private void UserName_LostFocus(object sender, RoutedEventArgs e)
		{
			UserName.Text = UserName.Text == String.Empty ? _UserName : UserName.Text;
		}

		private void Registration_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(Login.Text) || Login.Text == _LoginText)
			{
				MessageBox.Show("Введите значение в поле Логин");
				return;
			}

			if (String.IsNullOrEmpty(Password.Text) || Password.Text == _PasswordText)
			{
				MessageBox.Show("Ввведите значение в поле Пароль");
				return;
			}

			if (String.IsNullOrEmpty(SecondPassword.Text) || SecondPassword.Text == _SecondPasswordText)
			{
				MessageBox.Show("Ввведите значение в поле Повторите пароль");
				return;
			}

			if (Password.Text.Length < 5)
			{
				MessageBox.Show("Пароль должен иметь более 4 символов");
				return;
			}

			if (Password.Text != SecondPassword.Text)
			{
				MessageBox.Show("Пароли не совпадают");
				return;
			}

			if (String.IsNullOrEmpty(Mail.Text) || Mail.Text == _Mail)
			{
				MessageBox.Show("Ввведите значение в поле Почта");
				return;
			}

			if (!MailWorking.CheckMail(Mail.Text))
			{
				MessageBox.Show("Введите корректный почтовый адрес");
				return;
			}

			if (String.IsNullOrEmpty(UserName.Text) || UserName.Text == _UserName)
			{
				MessageBox.Show("Ввведите значение в поле Имя");
				return;
			}

			if (SelectSripts.CheckUser(Login.Text))
			{
				MessageBox.Show("Пользователь с таким логином уже существует");
				return;
			}

			if (InsertScripts.RegUser(UserName.Text, Login.Text, Password.Text, Mail.Text, _ban, _dataWorking.GetInvitationCode()))
			{
				MessageBox.Show("Регистрация прошла успешно");
			}
			else
			{
				MessageBox.Show("Произошла ошибка. Пользователь не зарегистрирован");
			}

			if (_authWindow == null)
			{
				_authWindow = new AuthorizationWindow();
				_authWindow.Show();
				this.Close();
			}
		}

		private void Enter_Click(object sender, RoutedEventArgs e)
		{
			if (_authWindow == null)
			{
				_authWindow = new AuthorizationWindow();
				_authWindow.Show();
				this.Close();
			}
		}

		private void GetPassword_Click(object sender, RoutedEventArgs e)
		{
			if (passwordDialogWindow == null)
			{
				passwordDialogWindow = new PasswordDialogWindow();
				passwordDialogWindow.registrationWindow = this;
				passwordDialogWindow.Show();
			}
		}
	}
}
