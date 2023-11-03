using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Input;

namespace ZebraPrintCommandTool.Model
{
    public class List_BarcodeData : ViewModelBase
    {

        public string PrinterName = "ZDesigner ZT411-600dpi ZPL";

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
        private string _barcodePositionX = "70";
        public string BarcodePositionX
        {
            get { return _barcodePositionX; }
            set {
                _barcodePositionX = value;
                RaisePropertyChanged("BarcodePositionX");
            }
        }

        private string _barcodePositionY = "90";
        public string BarcodePositionY
        {
            get { return _barcodePositionY; }
            set {
                _barcodePositionY = value;
                RaisePropertyChanged("BarcodePositionY");
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

        private double _barcodeSizeView;
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
        private Thickness _barcodeViewPosition;
        public Thickness BarcodeViewPosition
        {
            get { return _barcodeViewPosition; }
            set {
                _barcodeViewPosition = value;
                RaisePropertyChanged("BarcodeViewPosition");
            }
        }
        private Thickness _PNViewPosition;
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

        private string _clickView;
        public string ClickView
        {
            get { return _clickView; }
            set {
                _clickView = value;
                RaisePropertyChanged("ClickView");
            }
        }


        public ICommand CommandPrintSend { get; set; }
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

    }
}
