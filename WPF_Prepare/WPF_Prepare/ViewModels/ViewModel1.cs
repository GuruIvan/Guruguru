using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Prepare.Models;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.IO;

namespace WPF_Prepare.ViewModels
{
    class ViewModel1 : INotifyPropertyChanged
    {
        public ObservableCollection<Dates> date { get; set; }
        public ViewModel1()
        {
            date = new ObservableCollection<Dates>();
        }
        //Написал метод для диалогового окна поиска необходимого файла .txt
        public void OpenFile()
        {
            
            OpenFileDialog find = new OpenFileDialog();
            find.Filter = "txt|*.txt";
            if (find.ShowDialog() == true)
            {
                //Формирую массив строк каждый эл-нт отдельная строка файла
                string[] filelines = File.ReadAllLines(find.FileName); 
                for (int i = 0; i < filelines.Length; i++)
                {
                    //Инициализирую коллекцую объектов типа Dates для хранения дат из файла
                    // с помощью split удаляю лишний знак препинания ;
                    // вывод даты происходит в след. формате месяц - день - год
                    date.Add(new Dates { Date = Convert.ToDateTime(filelines[i].Replace(';',' ')) });
                }
                //Вызов метода сортировки 
                date = Sort(date);
            }
        }
        public ObservableCollection<Dates> Sort(ObservableCollection<Dates> dates)
        {
            //Объявляем и нициализируем новую колекцию на основе уже существующей dates с помощью делегатов
            //сортировка происходит по дате и времени
            ObservableCollection<Dates> sorted = new ObservableCollection<Dates>(date.OrderBy(x => x.Date));
            //Очищаем коллекцию dates для последующего её заполнения отсортированным списком объектов класса Dates
            date.Clear();
            foreach (Dates d in sorted)
            {
                //Заполняет коллекцию dates из отсортированной коллекции sorted
                date.Add(d);
            }
            return date;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(prop));
        }
    }
}
