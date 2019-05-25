using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace hw_105_WPF_ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> _usersInDB;
        List<task> _tasksBeforeEdit;
        List<task> _tasksAfterEdit;
        List<Category> _categoriesInDB;

        int _currentUserID;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Custom initializer
        /// </summary>
        public void Initialize()
        {
            using (var db = new ToDoDBModel())
            {
                // Get the users from the database and store as a list
                _usersInDB = db.Users.Include(u => u.tasks).ToList();

                // Set the obtained list as the ItemsSource for both the
                // dropdown and the corresponding datagrid.
                DGUsers.ItemsSource = _usersInDB;
                UserDropdown.ItemsSource = _usersInDB;

                // Set the source of the task datagrid
                TaskGridView.ItemsSource = _tasksAfterEdit;

                // Fetch categories from db and set ItemsSource for DGCategories
                _categoriesInDB = db.Categories.Include(c => c.tasks).ToList();
                DGCategories.ItemsSource = _categoriesInDB;

            }

            // Set the default selected users
            // ToDo: get the actual username of the first user in the dropdown
            // rather than hardcoding
            UserDropdown.SelectedIndex = 0;
            _currentUserID = 1;
        }

        /// <summary>
        /// Event handler that gets called when a user is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserSelected(object sender, SelectionChangedEventArgs e)
        {
            TaskGridView.ItemsSource = null;

            if (UserDropdown.SelectedValue == null) return;

            _currentUserID = (UserDropdown.SelectedValue as User).UserID;

            using (var db = new ToDoDBModel())
            {
                _tasksAfterEdit = db.tasks.Include(task => task.Category).Where(t => t.UserID == _currentUserID).ToList();

                TaskGridView.ItemsSource = _tasksAfterEdit;
            }
        }

        #region Click handlers

        /// <summary>
        /// Event handler that gets called when the checkbox in the Done colum is toggled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneToggled(object sender, RoutedEventArgs e)
        {
            if (TaskGridView.SelectedItem == null) return;

            if ((TaskGridView.SelectedItem as task).Done)
            {
                (TaskGridView.SelectedItem as task).Done = false;

                (TaskGridView.SelectedItem as task).DateCompleted = null;
            }
            else
            {
                (TaskGridView.SelectedItem as task).Done = true;

                var now = DateTime.Today;
                (TaskGridView.SelectedItem as task).DateCompleted = now;

                TaskGridView.ItemsSource = null;
                TaskGridView.ItemsSource = _tasksAfterEdit;
            }
        }


        /// <summary>
        /// Event handler that gets called when the save button gets clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            using (var db = new ToDoDBModel())
            {
                _tasksBeforeEdit = db.tasks.Where(t => t.UserID == _currentUserID).ToList();

                // Find the tasks that have been deleted and remove them from the database
                var deletedTasks = DeletedTasks();

                foreach (var item in deletedTasks)
                {
                    // Remove the task from the database
                    db.tasks.Remove(item);
                }

                // Find the tasks that have been added and add them to the database
                var addedTasks = AddedTasks();

                // Get the date of today
                var now = DateTime.Today;

                // For each task that is being added
                foreach (var item in addedTasks)
                {
                    // Set the userID and creation date
                    item.UserID = _currentUserID;
                    item.DateStarted = now;

                    // Add the task to the database
                    db.tasks.Add(item);
                }

                // Find the tasks that have been modified
                var modifiedTasks = ModifiedTasks();

                // For each task that has been modified
                foreach (var item in modifiedTasks)
                {
                    // Find the task in the database
                    var taskToEdit = db.tasks.Where(t => t.TaskID == item.TaskID).First();

                    // Set the values 
                    taskToEdit.CategoryID = item.CategoryID;
                    taskToEdit.DateCompleted = item.DateCompleted;
                    taskToEdit.DateStarted = item.DateStarted;
                    taskToEdit.Done = item.Done;
                    taskToEdit.TaskDescription = item.TaskDescription;
                }

                // Save changes to the database
                db.SaveChanges();
            }
        }
        #endregion

        #region Methods that detect changes to the task list

        /// <summary>
        /// Composes a list of all deleted tasks
        /// </summary>
        /// <returns></returns>
        List<task> DeletedTasks()
        {
            var deletedTasks = new List<task>();

            // Check for each task in the unaltered (original) list...
            foreach (var item in _tasksBeforeEdit)
            {
                // ...whether that task doesn't exist in the (possibly) edited list.
                if (!_tasksAfterEdit.Any(t => t.TaskID == item.TaskID))
                    deletedTasks.Add(item);
            }

            return deletedTasks;
        }

        /// <summary>
        /// Composes a list of newly added tasks
        /// </summary>
        /// <returns></returns>
        List<task> AddedTasks()
        {
            var addedTasks = new List<task>();

            // Check for each item in the (possibly) edited list...
            foreach (var item in _tasksAfterEdit)
            {
                // ...whether that task doesn't exist in the unaltered (original) list.
                if (!_tasksBeforeEdit.Any(t => t.TaskID == item.TaskID))
                    addedTasks.Add(item);
            }

            return addedTasks;
        }

        /// <summary>
        /// Composes a list of tasks that have been modified.
        /// </summary>
        /// <returns></returns>
        List<task> ModifiedTasks()
        {
            var modifiedTasks = new List<task>();

            // Check for each item in the (possibly) edited list...
            foreach (var item in _tasksAfterEdit)
            {
                // ...whether the task id is already in the unaltered (original) list,
                // but where at least one field has changed
                if (_tasksBeforeEdit.Any(t => t.TaskID == item.TaskID &&
                (t.TaskDescription != item.TaskDescription
                    || t.Done != item.Done
                    || t.CategoryID != item.CategoryID
                    || t.DateCompleted != item.DateCompleted)))
                {
                    modifiedTasks.Add(item);
                }
            }

            return modifiedTasks;
        }
        #endregion

        private void TaskGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
