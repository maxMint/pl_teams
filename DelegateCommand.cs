using System;
using System.Windows.Input;

namespace ButtonColumn_DelegateCommand
{
	class DelegateCommand<T> : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly Action<T> executeMethod = null;
		private readonly Func<T, bool> canExecuteMethod = null;


		public DelegateCommand(Action<T> executeMethod)
			: this(executeMethod, null)
		{
		}

		public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
		{
			if (executeMethod == null && canExecuteMethod == null)
				throw new ArgumentNullException("executeMethod");

			this.executeMethod = executeMethod;
			this.canExecuteMethod = canExecuteMethod;
		}

		public void Execute(T customer)
		{
			if (executeMethod == null) return;
			executeMethod(customer);
		}

		public bool CanExecute(T customer)
		{
			if (canExecuteMethod == null) return true;
			return canExecuteMethod(customer);
		}


		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute((T)parameter);
		}

		void ICommand.Execute(object parameter)
		{
			Execute((T)parameter);
		}

	}



	class DelegateCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly Action executeMethod = null;
		private readonly Func<bool> canExecuteMethod = null;


		public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
		{
			if (executeMethod == null && canExecuteMethod == null)
				throw new ArgumentNullException("executeMethod");

			this.executeMethod = executeMethod;
			this.canExecuteMethod = canExecuteMethod;
		}

		public void Execute()
		{
			if (executeMethod == null) return;
			executeMethod();
		}

		public bool CanExecute()
		{
			if (canExecuteMethod == null) return true;
			return canExecuteMethod();
		}


		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute();
		}

		void ICommand.Execute(object parameter)
		{
			Execute();
		}

	}
}
