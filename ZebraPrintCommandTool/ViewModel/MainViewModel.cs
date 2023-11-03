using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;
using ZebraPrintCommandTool.Model;
using ZebraPrintCommandTool.Utiles;

namespace ZebraPrintCommandTool.ViewModel
{
    public class MainViewModel : List_BarcodeData
    {
        private List_BarcodeData BarcodeData = new List_BarcodeData();
        private List_BarcodeData SerialNumberData = new List_BarcodeData();
        private List_BarcodeData PartNumberData = new List_BarcodeData();
        private List_BarcodeData ImageLogoData = new List_BarcodeData();
        public MainViewModel()
        {
            PN = "P11-G12100-03";
            SN = "2305900001";
            Barcode = PN + ":" + "S" + SN;
            FontSize = BarcodeSize;
            BarcodeSizeView = BarcodeSize;

            SetBarcodePosition();
            SetLogoPosition();
            SetPNPosition();
            SetSNPosition();

            CommandPrintSend = new Command(PrintTestSystem);

            BarcodeSizeUp = new Command(BarcodeSizeUpCommand);
            BarcodeSizeDown = new Command(BarcodeSizeDownCommand);

            ClickViewCatchButtonList();

            PositionUp = new Command(PositionUpCommand);
            PositionDown = new Command(PositionDownCommand);
            PositionLeft = new Command(PositionLeftCommand);
            PositionRight = new Command(PositionRightCommand);

        }
        #region Click View Catch

        private void ClickViewCatchButtonList()
        {
            ClickBarcode = new Command(ClickBarcodeCommand);
            ClickPN = new Command(ClickPNCommand);
            ClickSN = new Command(ClickSNCommand);
            ClickLogo = new Command(ClickLogoCommand);
        }
        
        private void ClickLogoCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                ClickView = "Logo";
                BarcodePositionX = ImageLogoData.BarcodePositionX;
                BarcodePositionY = ImageLogoData.BarcodePositionY;


            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private void ClickSNCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                ClickView = "SN";
                BarcodePositionX = SerialNumberData.BarcodePositionX;
                BarcodePositionY = SerialNumberData.BarcodePositionY;

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private void ClickPNCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                ClickView = "PN";
                BarcodePositionX = PartNumberData.BarcodePositionX;
                BarcodePositionY = PartNumberData.BarcodePositionY;

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private void ClickBarcodeCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                ClickView = "Barcode";
                BarcodePositionX = BarcodeData.BarcodePositionX;
                BarcodePositionY = BarcodeData.BarcodePositionY;

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }
        #endregion

        private void SelectedViewControll()
        {

            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
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
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }


        private void PositionRightCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                switch (ClickView)
                {
                    case "Barcode":
                        BarcodeData.BarcodePositionX = (int.Parse(BarcodeData.BarcodePositionX) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = BarcodeData.BarcodePositionX;
                        break;
                    case "PN":
                        PartNumberData.BarcodePositionX = (int.Parse(PartNumberData.BarcodePositionX) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = PartNumberData.BarcodePositionX;
                        break;
                    case "SN":
                        SerialNumberData.BarcodePositionX = (int.Parse(SerialNumberData.BarcodePositionX) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = SerialNumberData.BarcodePositionX;
                        break;
                    case "Logo":
                        ImageLogoData.BarcodePositionX = (int.Parse(ImageLogoData.BarcodePositionX) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = ImageLogoData.BarcodePositionX;
                        break;
                    default:
                        Console.WriteLine("No Click");
                        break;
                }
                

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }


        private void PositionLeftCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                switch (ClickView)
                {
                    case "Barcode":
                        BarcodeData.BarcodePositionX = (int.Parse(BarcodeData.BarcodePositionX) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = BarcodeData.BarcodePositionX;
                        break;
                    case "PN":
                        PartNumberData.BarcodePositionX = (int.Parse(PartNumberData.BarcodePositionX) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = PartNumberData.BarcodePositionX;
                        break;
                    case "SN":
                        SerialNumberData.BarcodePositionX = (int.Parse(SerialNumberData.BarcodePositionX) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = SerialNumberData.BarcodePositionX;
                        break;
                    case "Logo":
                        ImageLogoData.BarcodePositionX = (int.Parse(ImageLogoData.BarcodePositionX) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionX = ImageLogoData.BarcodePositionX;
                        break;
                    default:
                        Console.WriteLine("No Click");
                        break;
                }

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private void PositionDownCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                switch (ClickView)
                {
                    case "Barcode":
                        BarcodeData.BarcodePositionY = (int.Parse(BarcodeData.BarcodePositionY) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = BarcodeData.BarcodePositionY;
                        break;
                    case "PN":
                        PartNumberData.BarcodePositionY = (int.Parse(PartNumberData.BarcodePositionY) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = PartNumberData.BarcodePositionY;
                        break;
                    case "SN":
                        SerialNumberData.BarcodePositionY = (int.Parse(SerialNumberData.BarcodePositionY) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = SerialNumberData.BarcodePositionY;
                        break;
                    case "Logo":
                        ImageLogoData.BarcodePositionY = (int.Parse(ImageLogoData.BarcodePositionY) + 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = ImageLogoData.BarcodePositionY;
                        break;
                    default:
                        Console.WriteLine("No Click");
                        break;
                }
                
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private void PositionUpCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                switch (ClickView)
                {
                    case "Barcode":
                        BarcodeData.BarcodePositionY = (int.Parse(BarcodeData.BarcodePositionY) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = BarcodeData.BarcodePositionY;
                        break;
                    case "PN":
                        PartNumberData.BarcodePositionY = (int.Parse(PartNumberData.BarcodePositionY) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = PartNumberData.BarcodePositionY;
                        break;
                    case "SN":
                        SerialNumberData.BarcodePositionY = (int.Parse(SerialNumberData.BarcodePositionY) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = SerialNumberData.BarcodePositionY;
                        break;
                    case "Logo":
                        ImageLogoData.BarcodePositionY = (int.Parse(ImageLogoData.BarcodePositionY) - 10).ToString();
                        SelectedViewControll();
                        BarcodePositionY = ImageLogoData.BarcodePositionY;
                        break;
                    default:
                        Console.WriteLine("No Click");
                        break;
                }
                
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }


        private void SetBarcodePosition()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                BarcodeViewPosition = new Thickness(double.Parse(BarcodeData.BarcodePositionX) - 40, double.Parse(BarcodeData.BarcodePositionY) - 30, 0, 0);

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }
        private void SetPNPosition()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                PNViewPosition = new Thickness(double.Parse(PartNumberData.BarcodePositionX) + 280, double.Parse(PartNumberData.BarcodePositionY) - 30, 0, 0);

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }
        private void SetSNPosition()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                SNViewPosition = new Thickness(double.Parse(SerialNumberData.BarcodePositionX) + 280, double.Parse(SerialNumberData.BarcodePositionY) + 20, 0, 0);
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }
        private void SetLogoPosition()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                LogoViewPosition = new Thickness(double.Parse(ImageLogoData.BarcodePositionX) + 280, double.Parse(ImageLogoData.BarcodePositionY) + 210, 0, 0);

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private void BarcodeSizeDownCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                if (BarcodeSize <= 1)
                {
                    return;
                }
                --BarcodeSize;
                BarcodeSizeView = BarcodeSize;
                FontSize = BarcodeSize;
                SetBarcodePosition();
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private void BarcodeSizeUpCommand(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                if (BarcodeSize > 9)
                {
                    return;
                }
                ++BarcodeSize;
                BarcodeSizeView = BarcodeSize;
                FontSize = BarcodeSize;
                SetBarcodePosition();

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }
            
        }


        private void PrintTestSystem(object obj)
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {

                StringBuilder builder = new StringBuilder();
                builder.Append(SetBarcodeData());
                builder.Append(SetPNData());
                builder.Append(SetSNData());
                builder.Append(SetLogoData());

                InputText = builder.ToString();

                Console.WriteLine(InputText);
                GetPrint(PrinterName);

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private string SetBarcodeData()
        {

            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {

                StringBuilder builder = new StringBuilder();

                SetDataPosition = BarcodeData.BarcodePositionX + "," + BarcodeData.BarcodePositionY; // 70,90
                BarcodeStyle = "\n^BX";
                CommandData = Barcode;
                builder.Append(SetDataPosition);//input Data Selected
                builder.Append(BarcodeStyle);//barcode
                builder.Append(CommandData);//input Data

                SetBarcodePosition();

                return builder.ToString();
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }
        private string SetPNData()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                StringBuilder builder = new StringBuilder();

                SetDataPosition = (int.Parse(PartNumberData.BarcodePositionX) + 140).ToString() + "," + PartNumberData.BarcodePositionY;
                CommandData = PN;
                builder.Append(SetDataPosition);
                builder.Append("\n^A0N,30,25"); // 앞에것이 높이, 뒤에것이 가로 넓이
                builder.Append(CommandData);

                SetPNPosition();

                return builder.ToString();

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }
        private string SetSNData()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                StringBuilder builder = new StringBuilder();

                //SN
                SetDataPosition = (int.Parse(SerialNumberData.BarcodePositionX) + 140).ToString() + "," + (int.Parse(SerialNumberData.BarcodePositionY) + 30).ToString();
                CommandData = SN;
                builder.Append(SetDataPosition);
                builder.Append("\n^A0N,30,30");
                builder.Append(CommandData);

                SetSNPosition();

                return builder.ToString();
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }
        private string SetLogoData()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {
                StringBuilder builder = new StringBuilder();

                //LOGO
                SetDataPosition = (int.Parse(ImageLogoData.BarcodePositionX) + 160).ToString() + "," + (int.Parse(ImageLogoData.BarcodePositionY) + 90).ToString();
                Image = "LucidS.PNG";
                builder.Append(SetDataPosition);
                builder.Append(Image);

                SetLogoPosition();

                return builder.ToString();
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

        }

        private string GetPrintSecondLabel()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\n");
            try
            {

                StringBuilder builder = new StringBuilder();
                SetDataPosition = (int.Parse(BarcodePositionX) + 500).ToString() + "," + BarcodePositionY;
                BarcodeStyle = "^BX";
                CommandData = Barcode;

                builder.Append(SetDataPosition);//input Data Selected
                builder.Append(BarcodeStyle);//barcode
                builder.Append(CommandData);//input Data

                SetDataPosition = (int.Parse(BarcodePositionX) + 640).ToString() + "," + BarcodePositionY;
                CommandData = PN;
                builder.Append(SetDataPosition);
                builder.Append("\n^A0N,30,25"); // 앞에것이 높이, 뒤에것이 가로 넓이
                builder.Append(CommandData);


                SetDataPosition = (int.Parse(BarcodePositionX) + 640).ToString() + "," + (int.Parse(BarcodePositionY) + 30).ToString();
                CommandData = SN;
                builder.Append(SetDataPosition);
                builder.Append("\n^A0N,30,25");
                builder.Append(CommandData);


                SetDataPosition = (int.Parse(BarcodePositionX) + 640).ToString() + "," + (int.Parse(BarcodePositionY) + 100).ToString();
                CommandData = "LUCID";
                builder.Append(SetDataPosition);
                builder.Append("\n^A0N,35,65");
                builder.Append(CommandData);

                return builder.ToString();
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + (MethodBase.GetCurrentMethod().Name) + "\nException : " + ex);
                throw;
            }

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