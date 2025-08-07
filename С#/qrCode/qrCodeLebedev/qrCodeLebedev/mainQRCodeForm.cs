using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Drawing;
using System. Drawing. Printing;
using System. Linq;
using System. Text;
using System. Threading. Tasks;
using System. Windows. Forms;
using MessagingToolkit. QRCode. Codec;
using MessagingToolkit. QRCode. Codec. Data;
namespace qrCodeLebedev
{
    public partial class mainQRCodeForm : Form
    {
      public static int defaultWidth=70;
      public static int defaultHeight=70;
        public static int lastPrintWidth= defaultWidth;
        public static int lastPrintHeight= defaultHeight;
        public mainQRCodeForm()
        {
            InitializeComponent ( );
        }

        private void mainQRCodeForm_Load( object sender, EventArgs e )
        {
            
            textBoxDefaultWidth. Text =Convert.ToString(defaultWidth);
            textBoxDefaultHeight. Text = Convert. ToString ( defaultHeight );
        }

       

        private void buttonCreate_Click( object sender, EventArgs e )
        {
            if ( textBoxOriginalText.TextLength>0 ) {
                string qrtext = textBoxOriginalText.Text; //считываем текст из TextBox'a
                QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
                Bitmap qrcode = encoder.Encode(qrtext); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
                pictureBoxQRCode. Image = qrcode as Image; // pictureBox выводит qrcode как изображение.
            }
            else
            {
                MessageBox. Show ( "Для генерации QR кода требуется ввести хотя-бы 1 символ!");
            }
        }

        private void buttonSave_Click( object sender, EventArgs e )
        {
            if ( pictureBoxQRCode. Image!=null )
            {
                MessageBox. Show ( Convert. ToString ( pictureBoxQRCode. Image. Height ) );
                SaveFileDialog save = new SaveFileDialog(); // save будет запрашивать у пользователя, место, в которое он захочет сохранить файл. 
                save. Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp"; //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
                if ( save. ShowDialog ( ) == System. Windows. Forms. DialogResult. OK ) //если пользователь нажимает в обозревателе кнопку "Сохранить".
                {
                    pictureBoxQRCode. Image. Save ( save. FileName ); //изображение из pictureBox'a сохраняется под именем, которое введёт пользователь
                }
            }
            else
            {
                MessageBox. Show ( "Перед сохранением сгенерируйте QR код!" );
            }
           
        }

        private void buttonLoad_Click( object sender, EventArgs e )
        {
            OpenFileDialog load = new OpenFileDialog(); //  load будет запрашивать у пользователя место, из которого он хочет загрузить файл.
            if ( load. ShowDialog ( ) == System. Windows. Forms. DialogResult. OK ) // //если пользователь нажимает в обозревателе кнопку "Открыть".
            {
                pictureBoxQRCode. ImageLocation = load. FileName; // в pictureBox'e открывается файл, который был по пути, запрошенном пользователем.
            }
        }

        private void buttonRecognize_Click( object sender, EventArgs e )
        {
            if ( pictureBoxQRCode. Image != null )
            {
                QRCodeDecoder decoder = new QRCodeDecoder(); // создаём "раскодирование изображения"
                textBoxOriginalText. Text = decoder. decode ( new QRCodeBitmapImage ( pictureBoxQRCode. Image as Bitmap ) );
               // MessageBox. Show ( decoder. decode ( new QRCodeBitmapImage ( pictureBoxQRCode. Image as Bitmap ) ) ); //в MessageBox'e программа запишет раскодированное сообщение с изображения, которое предоврительно будет переведено из pictureBox'a в класс Bitmap, чтобы мы смогли с этим изображением работать. 
            }
            else
            {
                MessageBox. Show ( "Отсутствует QR код для распознания!" );
            }
        }

        
        //  void printDocument_PrintPage( object sender, System. Drawing. Printing. PrintPageEventArgs e )
        //    {
        //    MakePaint ( e. Graphics );// Выводит на екран линии и текст (по сути мой рисунок)
        //      }

        private void pd_PrintPage( object sender, PrintPageEventArgs ev )
        {

            // Create image.
            Image newImage = pictureBoxQRCode. Image;
            Bitmap imageScale=new Bitmap(newImage,Convert.ToInt32(textBoxDefaultHeight.Text),Convert.ToInt32(textBoxDefaultWidth.Text) );
            
            // Create rectangle for displaying original image.
            Rectangle destRect1 = new Rectangle(0, 0, Convert.ToInt32(textBoxDefaultWidth.Text),Convert.ToInt32(textBoxDefaultHeight.Text) );

            // Create coordinates of rectangle for source image.
            int x = 0;
            int y = 0;
            int width = Convert.ToInt32(textBoxDefaultWidth.Text);
            int height = Convert.ToInt32(textBoxDefaultHeight.Text);
            GraphicsUnit units = GraphicsUnit.Pixel;

            // Draw original image to screen.
           // ev. Graphics. DrawImage ( newImage, destRect1, x, y, width, height, units );

            // Create rectangle for adjusted image.
            //Rectangle destRect2 = new Rectangle(100, 175, 450, 150);

          




            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
           // linesPerPage = ev. MarginBounds. Height /
             //  printFont. GetHeight ( ev. Graphics );

            // Print each line of the file.
            //  while ( count < linesPerPage &&
            //    ( ( line = streamToPrint. ReadLine ( ) ) != null ) )
            //   {
            //   yPos = topMargin + ( count *
            //   printFont. GetHeight ( ev. Graphics ) );
            // ev. Graphics.DrawImage ( line, printFont, Brushes. Black,
            //       leftMargin, yPos, new StringFormat ( ) );
            //   count++;
            //   }

            // If more lines exist, print another page.
            //  if ( line != null )
            //     ev. HasMorePages = true;
            // else
            // ev. HasMorePages = false;
            ev. Graphics. DrawImage ( imageScale, destRect1, x, y, width, height, units );
        }

        private void buttonPrint_Click( object sender, EventArgs e )
        {








            if ( pictureBoxQRCode.Image!=null)
            {
                PrintDocument TmpPrntPicDoc = new PrintDocument();
            TmpPrntPicDoc. PrintPage += pd_PrintPage;
            System.Windows.Forms.PrintPreviewDialog TempPPD = new PrintPreviewDialog();
            TempPPD. Document = TmpPrntPicDoc;
            TempPPD. ShowDialog ( );




            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument. PrintPage += new System. Drawing. Printing. PrintPageEventHandler ( pd_PrintPage );

            PrintDialog printDlg = new PrintDialog();

            if ( printDlg. ShowDialog ( ) == DialogResult. OK )
            {
                printDocument. PrinterSettings = printDlg. PrinterSettings;
                printDocument. Print ( );
                textBoxOriginalText. Text = "";
                pictureBoxQRCode. Image = null;
            }
        }
            else
            {
                MessageBox. Show ( "Отсутствует QR код для печати!" );
            }
        }

        private void textBoxDefaultWidth_Leave( object sender, EventArgs e )
        {
            try
            {
                lastPrintWidth= Convert. ToInt32 ( textBoxDefaultWidth.Text );
                


            }
            catch ( Exception eee )
            {
                MessageBox. Show ( "Некорректная ширина для печати! \n Возврат к предыдушему значению." );

                textBoxDefaultWidth. Text = Convert. ToString ( lastPrintWidth );
            }
        }
        private void textBoxDefaultHeight_Leave( object sender, EventArgs e )
        {
            try
            {
                lastPrintHeight= Convert. ToInt32 ( textBoxDefaultHeight.Text );



            }
            catch ( Exception eee )
            {
                MessageBox. Show ( "Некорректная высота для печати! \n Возврат к предыдушему значению." );

                textBoxDefaultHeight. Text = Convert. ToString ( lastPrintHeight );
            }
           
        }

        private void buttonClear_Click( object sender, EventArgs e )
        {
            textBoxOriginalText. Text = "";
            pictureBoxQRCode. Image = null;
        }
    }
    }
    

