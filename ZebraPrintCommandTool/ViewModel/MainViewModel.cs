using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using ZebraPrintCommandTool.Utiles;

namespace ZebraPrintCommandTool.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _inputText = "";
        public string InputText
        {
            get { return _inputText; }
            set {
                _inputText = "^XA\n" + value + "^\nXZ";
                RaisePropertyChanged("InputText");
            }
        }
        private string _pn = "";
        public string PN
        {
            get { return _pn; }
            set {
                _pn = value;
                RaisePropertyChanged("PN");
            }
        }
        private string _sn = "";
        public string SN
        {
            get { return _sn; }
            set {
                _sn = value;
                RaisePropertyChanged("SN");
            }
        }
        private string _barcode = "";
        public string Barcode
        {
            get { return _barcode; }
            set {
                _barcode = value;
                RaisePropertyChanged("Barcode");
            }
        }
        private string _positionX = "100";
        public string PositionX
        {
            get { return _positionX; }
            set {
                _positionX = value;
                RaisePropertyChanged("PositionX");
            }
        }
        
        private string _positionY = "80";
        public string PositionY
        {
            get { return _positionY; }
            set {
                _positionY = value;
                RaisePropertyChanged("PositionY");
            }
        }

        private string _setDataPosition = "";
        public string SetDataPosition
        {
            get { return _setDataPosition; }
            set {
                _setDataPosition = "\n^FO" + value;
                RaisePropertyChanged("SetDataPosition");
            }
        }

        private string _commandData = "";
        public string CommandData
        {
            get { return _commandData; }
            set {
                _commandData = "\n^FD" + value + "^FS";
                RaisePropertyChanged("CommandData");
            }
        }

        private string _barcodeStyle = "";
        public string BarcodeStyle
        {
            get { return _barcodeStyle; }
            set {
                _barcodeStyle = value + "N," + "10,200;";//,,,,,1 + "BY^9,3.0,10"
                RaisePropertyChanged("BarcodeStyle");
            }
        }

        public string PrinterName = "ZDesigner ZT411-600dpi ZPL";
        public ICommand Test { get; set; }


        public MainViewModel()
        {
            PN = "P11-G12100-03";
            SN = "S2305900001";
            Barcode = PN + ":" + SN;
            Test = new Command(PrintTestSystem);
        }

        private void PrintTestSystem(object obj)
        {
            SetDataPosition = PositionX +","+ PositionY;
            BarcodeStyle = "^BX";
            CommandData = Barcode;
            StringBuilder builder = new StringBuilder();

            builder.Append(SetDataPosition);//input Data Selected
            builder.Append(BarcodeStyle);//barcode
            builder.Append(CommandData);//input Data

            SetDataPosition = "300," + PositionY;
            CommandData= PN;
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,35,25");
            builder.Append(CommandData);


            SetDataPosition = "300," + "120";
            CommandData = SN;
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,35,25");
            builder.Append(CommandData);


            SetDataPosition = "300," + "250";
            CommandData = "LUCID";
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,35,80");
            builder.Append(CommandData);



            InputText = builder.ToString();

            GetPrint(PrinterName);
        }

        private void GetPrint(string printerName)
        {
            Trace.WriteLine("Start::::::::::::" + (MethodBase.GetCurrentMethod().Name));
            try
            {
                RawPrinterHelper.SendStringToPrinter(printerName, InputText);
            } catch (Exception e)
            {
                Trace.WriteLine("Catch::::::::::" + (MethodBase.GetCurrentMethod().Name) + e);
                MessageBox.Show("연결 실패");
            }
        }
    }
}