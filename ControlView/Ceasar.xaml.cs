﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace MaHoa.ControlView
{
    /// <summary>
    /// Interaction logic for Ceasar.xaml
    /// </summary>
    public partial class Ceasar : UserControl
    {
        private string _encodeKey;
        public string EncodeKey 
        { 
            get 
            {
                _encodeKey = encodeKey.Text; 
                return _encodeKey; 
            } 
            set 
            { 
                _encodeKey = value;
                encodeKey.Text = _encodeKey;
            } 
        }

        private string _decodeKey;

        public string DecodeKey
        {
            get
            {
                _decodeKey = decodeKey.Text;
                return _decodeKey;
            }
            set
            {
                _decodeKey = value;
                decodeKey.Text = _decodeKey;
            }
        }

        private string _plainTextKeyFile;
        public string PlainTextKeyFile
        {
            get
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if(openFile.ShowDialog() == true)
                {
                    _plainTextKeyFile = File.ReadAllText(openFile.FileName);
                }
                
                return _plainTextKeyFile.ToString().Trim('\r', '\n', ' ');
            }
            set
            {
                _cipherTextKeyFile = value;
            }
        }

        private string _cipherTextKeyFile;
        public string CipherTextKeyFile
        {
            get
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == true)
                {
                    _cipherTextKeyFile = File.ReadAllText(openFile.FileName);
                }

                return _cipherTextKeyFile.ToString().Trim('\r', '\n', ' ');
            }
            set
            {
                _cipherTextKeyFile = value;
            }
        }

        private MainWindow _window;
        public MainWindow Window 
        { 
            get 
            {
                FrameworkElement p = GetWindowParent(this);
                _window = p as MainWindow;
                return _window; 
            } 
        }

        public Ceasar()
        {
            InitializeComponent();
        }

        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }

        private void ReadPlainTextKeyFile(object sender, RoutedEventArgs e)
        {
            EncodeKey = PlainTextKeyFile[0].ToString();
        }

        private void ReadCipherTextKeyFile(object sender, RoutedEventArgs e)
        {
            DecodeKey = CipherTextKeyFile[0].ToString();
        }
    }
}
