﻿using System;
using System.Windows.Input;

namespace StateMachineNodeEditorNerCore.Helpers.Commands
{
    public class SimpleCommand : ICommand
    {
        /// <summary>
        /// Функция с параметром, которая будет вызвана при выполнении команды
        /// </summary>
        private Action _execute;

        /// <summary>
        /// Объкт, которому принадлежит команда
        /// </summary>
        public object Owner { get; protected set; }

        /// <summary>
        /// Требуется  интерфейсом ICloneable, не используется
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Требуется  интерфейсом ICloneable, не используется
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Всегда возвращает true</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <param name="parameter"> Параметр команды </param>
        public void Execute(object parameter = null)
        {
            this._execute();
        }

        /// <summary>
        /// Создать команду
        /// </summary>
        /// <param name="owner">Объкт, которому принадлежит команда</param>
        /// <param name="execute">Функция, которая будет вызвана при выполнении команды</param>
        public SimpleCommand(object owner, Action execute)
        {
            Owner = owner;
            _execute = execute;
        }
    }
}
