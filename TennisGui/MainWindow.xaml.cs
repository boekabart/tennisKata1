using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TennisScore;

namespace TennisGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Controller m_Context = new Controller();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = m_Context;
        }

        public void Player1ScoresEventHandler(object sender, RoutedEventArgs e)
        {
            m_Context.Player1Scores();
            e.Handled = true;
        }

        public void Player2ScoresEventHandler(object sender, RoutedEventArgs e)
        {
            m_Context.Player2Scores();
            e.Handled = true;
        }
    }

    internal class Controller : INotifyPropertyChanged
    {
        public Controller()
        {
            Game = new Game();
            Player1Name = "Bart";
            Player2Name = "Stefan";
            CreateScoreBoard();
        }

        public string Player2Name
        {
            get { return m_Player2Name; }
            set
            {
                if (m_GameStarted)
                    throw new InvalidOperationException();
                m_Player2Name = value;
                CreateScoreBoard();
                OnPropertyChanged();
            }
        }

        private void CreateScoreBoard()
        {
            ScoreBoard = new ScoreBoard(Game, Player1Name, Player2Name);
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
            set
            {
                if (m_GameStarted)
                    throw new InvalidOperationException();
                m_Player1Name = value;
                CreateScoreBoard();
                OnPropertyChanged();
            }
        }

        private bool m_GameStarted;
        private string m_Player1Name;
        private string m_Player2Name;
        private Game Game { get; set; }
        private ScoreBoard ScoreBoard { get; set; }

        public string ScoreText
        {
            get { return ScoreBoard.DisplayString; }
        }

        public void Player1Scores()
        {
            if (!GameStarted)
                GameStarted = true;
            Game.Player1Scores();
            Notify();
        }

        public void Player2Scores()
        {
            if (!GameStarted)
                GameStarted = true;
            Game.Player2Scores();
            Notify();
        }

        public bool GameStarted
        {
            get { return m_GameStarted; }
            set
            {
                m_GameStarted = value;
                OnPropertyChanged();
                OnPropertyChanged("GameNotStarted");
            }
        }

        public bool GameNotStarted
        {
            get { return !m_GameStarted; }
        }

        private void Notify()
        {
            OnPropertyChanged("ScoreText");
            OnPropertyChanged("ScoringAllowed");
        }

        public bool ScoringAllowed
        {
            get { return !Game.HasWinner; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
