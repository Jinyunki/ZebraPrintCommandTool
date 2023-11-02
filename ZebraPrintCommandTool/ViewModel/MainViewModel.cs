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
        private string _positionX = "70";
        public string PositionX
        {
            get { return _positionX; }
            set {
                _positionX = value;
                RaisePropertyChanged("PositionX");
            }
        }
        
        private string _positionY = "90";
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
                _setDataPosition = "\n\n^FO" + value;
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

        private string _image = "";
        public string Image
        {
            get { return _image; }
            set {
                _image = "\n^FR" + "\n^XGE:" + value + ",1,2^FS";
                RaisePropertyChanged("Image");
            }
        }

        private string _barcodeStyle = "";
        public string BarcodeStyle
        {
            get { return _barcodeStyle; }
            set {
                _barcodeStyle = value + "N," + BarcodeSize.ToString() + ",200;"; 
                RaisePropertyChanged("BarcodeStyle");
            }
        }

        private int _barcodeSize = 7;
        public int BarcodeSize
        {
            get { return _barcodeSize; }
            set {
                _barcodeSize = value;
                RaisePropertyChanged("BarcodeSize");
            }
        }
        
        private double _barcodeSizeView ;
        public double BarcodeSizeView
        {
            get { return _barcodeSizeView; }
            set {
                _barcodeSizeView = value * 45;
                RaisePropertyChanged("BarcodeSizeView");
            }
        }
        private double _fontsize;
        public double FontSize
        {
            get { return _fontsize; }
            set {
                _fontsize = value * 5;
                RaisePropertyChanged("FontSize");
            }
        }
        private Thickness _barcodeViewPosition ;
        public Thickness BarcodeViewPosition
        {
            get { return _barcodeViewPosition; }
            set {
                _barcodeViewPosition = value;
                RaisePropertyChanged("BarcodeViewPosition");
            }
        }
        private Thickness _PNViewPosition ;
        public Thickness PNViewPosition
        {
            get { return _PNViewPosition; }
            set {
                _PNViewPosition = value;
                RaisePropertyChanged("PNViewPosition");
            }
        }
        private Thickness _SNViewPosition;
        public Thickness SNViewPosition
        {
            get { return _SNViewPosition; }
            set {
                _SNViewPosition = value;
                RaisePropertyChanged("SNViewPosition");
            }
        }
        private Thickness _LogoViewPosition;
        public Thickness LogoViewPosition
        {
            get { return _LogoViewPosition; }
            set {
                _LogoViewPosition = value;
                RaisePropertyChanged("LogoViewPosition");
            }
        }

        public string PrinterName = "ZDesigner ZT411-600dpi ZPL";
        public ICommand Test { get; set; }
        public ICommand BarcodeSizeUp { get; set; }
        public ICommand BarcodeSizeDown { get; set; }
        public ICommand ClickBarcode { get; set; }
        public ICommand ClickPN { get; set; }
        public ICommand ClickSN { get; set; }
        public ICommand ClickLogo { get; set; }
        public ICommand PositionUp { get; set; }
        public ICommand PositionDown { get; set; }
        public ICommand PositionLeft { get; set; }
        public ICommand PositionRight { get; set; }


        public MainViewModel()
        {
            PN = "P11-G12100-03";
            SN = "2305900001";
            Barcode = PN + ":" + "S" +SN;
            FontSize = BarcodeSize;
            BarcodeSizeView = BarcodeSize;
            SetBarcodePosition();
            SetLogoPosition();
            SetPNPosition();
            SetSNPosition();

            Test = new Command(PrintTestSystem);
            BarcodeSizeUp = new Command(BarcodeSizeUpCommand);
            BarcodeSizeDown = new Command(BarcodeSizeDownCommand);

            ClickBarcode = new Command(ClickBarcodeCommand);
            ClickPN = new Command(ClickPNCommand);
            ClickSN = new Command(ClickSNCommand);
            ClickLogo = new Command(ClickLogoCommand);

            
            PositionUp = new Command(PositionUpCommand);
            PositionDown = new Command(PositionDownCommand);
            PositionLeft = new Command(PositionLeftCommand);
            PositionRight = new Command(PositionRightCommand);
            
        }
        private void SelectedViewControll()
        {
            switch (ClickView)
            {
                case "Barcode":
                    SetBarcodePosition();
                    break;
                case "PN":
                    SetPNPosition();
                    break;
                case "SN":
                    SetSNPosition();
                    break;
                case "Logo":
                    SetLogoPosition();
                    break;
                default:
                    Console.WriteLine("No Click");
                    break;
            }
        }


        private void PositionRightCommand(object obj)
        {
            PositionX = (int.Parse(PositionX) + 10).ToString();
            SelectedViewControll();
        }
        

        private void PositionLeftCommand(object obj)
        {
            PositionX = (int.Parse(PositionX) - 10).ToString();
            SelectedViewControll();
        }

        private void PositionDownCommand(object obj)
        {
            PositionY = (int.Parse(PositionY) + 10).ToString();
            SelectedViewControll();
        }

        private void PositionUpCommand(object obj)
        {
            PositionY = (int.Parse(PositionY) - 10).ToString();
            SelectedViewControll();
        }

        private void ClickLogoCommand(object obj)
        {
            Console.WriteLine("ClickLogo");
            ClickView = "Logo";
        }

        private void ClickSNCommand(object obj)
        {
            Console.WriteLine("ClickSN");
            ClickView = "SN";
        }

        private void ClickPNCommand(object obj)
        {
            Console.WriteLine("ClickPN");
            ClickView = "PN";
        }

        private void ClickBarcodeCommand(object obj)
        {
            Console.WriteLine("ClickBarcode");
            ClickView = "Barcode";
        }
        private string _clickView;
        public string ClickView
        {
            get { return _clickView; }
            set {
                _clickView = value;
                RaisePropertyChanged("ClickView");
            }
        }
        private void SetBarcodePosition()
        {
            BarcodeViewPosition = new Thickness(double.Parse(PositionX) - 40, double.Parse(PositionY) - 30 , 0, 0);
        }
        private void SetPNPosition()
        {
            //350 60 0 0
            PNViewPosition = new Thickness(double.Parse(PositionX) + 280, double.Parse(PositionY) -30 , 0, 0);
        }
        private void SetSNPosition()
        {
            //350 110 0 0
            SNViewPosition = new Thickness(double.Parse(PositionX) + 280, double.Parse(PositionY) + 20 , 0, 0);
        }
        private void SetLogoPosition()
        {
            //350 290 0 0
            LogoViewPosition = new Thickness(double.Parse(PositionX) + 280, double.Parse(PositionY) + 210 , 0, 0);
        }

        private void BarcodeSizeDownCommand(object obj)
        {
            if (BarcodeSize <= 1)
            {
                return;
            }
            --BarcodeSize;
            BarcodeSizeView = BarcodeSize;
            FontSize = BarcodeSize;
            SetBarcodePosition();
        }

        private void BarcodeSizeUpCommand(object obj)
        {
            
            if (BarcodeSize > 9)
            {
                return;
            }
            ++BarcodeSize;
            BarcodeSizeView = BarcodeSize;
            FontSize = BarcodeSize;
            SetBarcodePosition();
        }


        private void PrintTestSystem(object obj)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(SetBarcodeData());
            builder.Append(SetPNData());
            builder.Append(SetSNData());
            builder.Append(SetLogoData());

            InputText = builder.ToString();

            Console.WriteLine(InputText);
            //GetPrint(PrinterName);
        }

        private string SetBarcodeData()
        {
            StringBuilder builder = new StringBuilder();

            //Barcode
            SetDataPosition = PositionX + "," + PositionY; // 70,90
            BarcodeStyle = "\n^BX";
            CommandData = Barcode;
            builder.Append(SetDataPosition);//input Data Selected
            builder.Append(BarcodeStyle);//barcode
            builder.Append(CommandData);//input Data

            SetBarcodePosition();

            return builder.ToString();
        }
        private string SetPNData()
        {
            StringBuilder builder = new StringBuilder();

            //PN
            SetDataPosition = (int.Parse(PositionX) + 140).ToString() + "," + PositionY;
            CommandData = PN;
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,30,25"); // 앞에것이 높이, 뒤에것이 가로 넓이
            builder.Append(CommandData);

            SetPNPosition();

            return builder.ToString();
        }
        private string SetSNData()
        {
            StringBuilder builder = new StringBuilder();

            //SN
            SetDataPosition = (int.Parse(PositionX) + 140).ToString() + "," + (int.Parse(PositionY) + 30).ToString();
            CommandData = SN;
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,30,30");
            builder.Append(CommandData);

            SetSNPosition();

            return builder.ToString();
        }
        private string SetLogoData()
        {
            StringBuilder builder = new StringBuilder();

            //LOGO
            SetDataPosition = (int.Parse(PositionX) + 160).ToString() + "," + (int.Parse(PositionY) + 90).ToString();
            Image = "LucidS.PNG";
            builder.Append(SetDataPosition);
            builder.Append(Image);

            SetLogoPosition();

            return builder.ToString();
        }

        private string GetPrintSecondLabel()
        {
            StringBuilder builder = new StringBuilder();
            SetDataPosition = (int.Parse(PositionX) + 500).ToString() + "," + PositionY;
            BarcodeStyle = "^BX";
            CommandData = Barcode;

            builder.Append(SetDataPosition);//input Data Selected
            builder.Append(BarcodeStyle);//barcode
            builder.Append(CommandData);//input Data

            SetDataPosition = (int.Parse(PositionX) + 640).ToString() + "," + PositionY;
            CommandData = PN;
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,30,25"); // 앞에것이 높이, 뒤에것이 가로 넓이
            builder.Append(CommandData);


            SetDataPosition = (int.Parse(PositionX) + 640).ToString() + "," + (int.Parse(PositionY) + 30).ToString();
            CommandData = SN;
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,30,25");
            builder.Append(CommandData);


            SetDataPosition = (int.Parse(PositionX) + 640).ToString() + "," + (int.Parse(PositionY) + 100).ToString();
            CommandData = "LUCID";
            builder.Append(SetDataPosition);
            builder.Append("\n^A0N,35,65");
            builder.Append(CommandData);

            return builder.ToString();
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