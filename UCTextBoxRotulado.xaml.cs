using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parametrizador_PROCFIT
{
    /// <summary>
    /// Interação lógica para UCTextBoxRotulado.xam
    /// </summary>
    public partial class UCTextBoxRotulado : UserControl
    {
        #region VARIAVEIS
        string? valueMark;

        #endregion

        #region INICIALIZAÇÃO
        public UCTextBoxRotulado()
        {
            InitializeComponent();

            TextBox.TextChanged += new TextChangedEventHandler(TextBoxChanged);
            TextBox.GotFocus += new RoutedEventHandler(TextBox_GotFocus);
            TextBox.LostFocus += new RoutedEventHandler(TextBox_LostFocus);
            TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox.TextChanged += new TextChangedEventHandler(TextBoxChanged);
        }
        private void _this_Loaded(object sender, RoutedEventArgs e)
        {
            valueMark = WaterMark;

            this.LabelRotulo.Content = Rotulo;
            this.LabelRotulo.FontSize = FontSizeRotulo;
            this.LabelRotulo.FontFamily = FontFamilyRotulo;
            this.LabelRotulo.Foreground = ForeGroundRotulo;

            this.TextBox.Text = Text;
            this.TextBox.Tag = (this.TextBox.Text.Length > 0) ? string.Empty : WaterMark;
            this.TextBox.FontSize = 12;
            this.TextBox.FontFamily = FontFamily;
            this.TextBox.Foreground = Foreground;
            this.TextBox.Width = Width;
            this.TextBox.Height = Height;
            this.TextBox.AcceptsTab = MultiLine ? true : false;
            this.TextBox.AcceptsReturn = MultiLine ? true : false;
            this.TextBox.TextWrapping = MultiLine ? TextWrapping.Wrap : TextWrapping.NoWrap;

            this.myProgress.Visibility = (VisibilityProgress == VisibleProgressBar.visible) ? Visibility.Visible : Visibility.Collapsed;

            this.LabelRotulo.Visibility = (VisibilityRotulo == VisibleRotulo.visible) ? Visibility.Visible : Visibility.Collapsed;

            this.button_clear.Visibility = (visibleButtonClean == VisibleButtonClean.Visible) ? Visibility.Visible : Visibility.Collapsed;

        }

        #endregion

        #region PROPRIEDADES

        #region ROTULO

        public VisibleRotulo VisibilityRotulo
        {
            get { return (VisibleRotulo)GetValue(VisibilityRotuloProperty); }
            set { SetValue(VisibilityRotuloProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisibilityRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilityRotuloProperty =
            DependencyProperty.Register("VisibilityRotulo", typeof(VisibleRotulo), typeof(UCTextBoxRotulado), new PropertyMetadata(VisibleRotulo.hidden));

        public enum VisibleRotulo
        {
            visible,
            hidden
        }


        public String Rotulo
        {
            get { return (String)GetValue(RotuloProperty); }
            set { SetValue(RotuloProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RotuloProperty =
            DependencyProperty.Register("Rotulo", typeof(String), typeof(UCTextBoxRotulado), new PropertyMetadata("Descrição"));



        public int FontSizeRotulo
        {
            get { return (int)GetValue(FontSizeRotuloProperty); }
            set { SetValue(FontSizeRotuloProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSizeRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontSizeRotuloProperty =
            DependencyProperty.Register("FontSizeRotulo", typeof(int), typeof(UCTextBoxRotulado), new PropertyMetadata(12));



        public FontFamily FontFamilyRotulo
        {
            get { return (FontFamily)GetValue(FontFamilyRotuloProperty); }
            set { SetValue(FontFamilyRotuloProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontFamilyRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontFamilyRotuloProperty =
            DependencyProperty.Register("FontFamilyRotulo", typeof(FontFamily), typeof(UCTextBoxRotulado), new PropertyMetadata(new FontFamily("Arial")));



        public SolidColorBrush ForeGroundRotulo
        {
            get { return (SolidColorBrush)GetValue(ForeGroundRotuloProperty); }
            set { SetValue(ForeGroundRotuloProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForeGroundRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForeGroundRotuloProperty =
            DependencyProperty.Register("ForeGroundRotulo", typeof(SolidColorBrush), typeof(UCTextBoxRotulado), new PropertyMetadata(Brushes.Black));
        #endregion

        #region TEXTBOX
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(String), typeof(UCTextBoxRotulado), new PropertyMetadata(""));


        public int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(int), typeof(UCTextBoxRotulado), new PropertyMetadata(50));



        public int Height
        {
            get { return (int)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(UCTextBoxRotulado), new PropertyMetadata(24));






        public bool Validation
        {
            get { return (bool)GetValue(ValidationProperty); }
            set { SetValue(ValidationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Validation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationProperty =
            DependencyProperty.Register("Validation", typeof(bool), typeof(UCTextBoxRotulado), new PropertyMetadata(false));



        public bool MultiLine
        {
            get { return (bool)GetValue(MultLineProperty); }
            set { SetValue(MultLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MultLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MultLineProperty =
            DependencyProperty.Register("MultLine", typeof(bool), typeof(UCTextBoxRotulado), new PropertyMetadata(false));


        #endregion

        #region WATERMARK 
        public String WaterMark
        {
            get { return (String)GetValue(WaterMarkProperty); }
            set { SetValue(WaterMarkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextMark.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterMarkProperty =
            DependencyProperty.Register("WaterMark", typeof(String), typeof(UCTextBoxRotulado), new PropertyMetadata(""));



        public int FontSizeWaterMark
        {
            get { return (int)GetValue(FontSizeWaterMarkProperty); }
            set { SetValue(FontSizeWaterMarkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSizeRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontSizeWaterMarkProperty =
            DependencyProperty.Register("FontSizeWaterMark", typeof(int), typeof(UCTextBoxRotulado), new PropertyMetadata(12));



        public FontFamily FontFamilyWaterMark
        {
            get { return (FontFamily)GetValue(FontFamilyWaterMarkProperty); }
            set { SetValue(FontFamilyWaterMarkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontFamilyRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontFamilyWaterMarkProperty =
            DependencyProperty.Register("FontFamilyWaterMark", typeof(FontFamily), typeof(UCTextBoxRotulado), new PropertyMetadata(new FontFamily("Arial")));



        public SolidColorBrush ForeGroundWaterMark
        {
            get { return (SolidColorBrush)GetValue(ForeGroundWaterMarkProperty); }
            set { SetValue(ForeGroundWaterMarkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForeGroundRotulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForeGroundWaterMarkProperty =
            DependencyProperty.Register("ForeGroundWaterMark", typeof(SolidColorBrush), typeof(UCTextBoxRotulado), new PropertyMetadata(Brushes.LightGray));

        #endregion

        #region TEXTMASK
        public Mask TextMask
        {
            get { return (Mask)GetValue(TextMaskProperty); }
            set { SetValue(TextMaskProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextMask.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextMaskProperty =
            DependencyProperty.Register("TextMask", typeof(Mask), typeof(UCTextBoxRotulado), new PropertyMetadata(Mask.None));


        public enum Mask
        {
            None,
            Cpf,
            Cnpj,
            Cep,
            Celular,
            Data
        }

        #endregion

        #region PROGRESSBAR

        public VisibleProgressBar VisibilityProgress
        {
            get { return (VisibleProgressBar)GetValue(ProgressBarProperty); }
            set { SetValue(ProgressBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressBarProperty =
            DependencyProperty.Register("ProgressBar", typeof(VisibleProgressBar), typeof(UCTextBoxRotulado), new PropertyMetadata(VisibleProgressBar.Collapsed));




        public enum VisibleProgressBar
        {
            visible,
            Collapsed
        }
        #endregion

        #region LIMPAR CAIXA DE TEXTO


        public VisibleButtonClean visibleButtonClean
        {
            get { return (VisibleButtonClean)GetValue(visibleButtonCleanProperty); }
            set { SetValue(visibleButtonCleanProperty, value); }
        }

        // Using a DependencyProperty as the backing store for visibleButtonClean.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty visibleButtonCleanProperty =
            DependencyProperty.Register("visibleButtonClean", typeof(VisibleButtonClean), typeof(UCTextBoxRotulado), new PropertyMetadata(VisibleButtonClean.Collapsed));



        public enum VisibleButtonClean
        {
            Visible,
            Collapsed
        }


        #endregion

        #region TEXTCHANGE



        #endregion

        #endregion

        #region EVENTOS

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Length > 0)
            {
                TextBox.Tag = null;
            }
            else
            {
                TextBox.Tag = valueMark;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }
        public void TextBoxChanged(Object sender, EventArgs e)
        {
            if (TextBox.Text.Length > 0)
            {
                TextBox.Tag = null;
            }
            else
            {
                TextBox.Tag = valueMark;
            }
        }

        private void button_close_MouseEnter(object sender, MouseEventArgs e)
        {
            this.btnClose.Foreground = Brushes.Red;
        }

        private void button_close_MouseLeave(object sender, MouseEventArgs e)
        {
            this.btnClose.Foreground = Brushes.Transparent;
        }
        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            this.TextBox.Clear();
        }

        public delegate void TextChangedUCTextBoxRotuladoEventArgs(object sender, TextChangedEventArgs e);
        public event TextChangedUCTextBoxRotuladoEventArgs TextChanged;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged(sender, e);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Back)
            {
                //MaskText maskText = new MaskText();
                //switch (TextMask)
                //{
                //    case Mask.None:
                //        break;
                //    case Mask.Cpf:
                //        maskText.MaskCpf(TextBox);
                //        break;
                //    case Mask.Cnpj:
                //        maskText.MaskCnpj(TextBox);
                //        break;
                //    case Mask.Cep:
                //        maskText.MaskCep(TextBox);
                //        break;
                //    case Mask.Data:
                //        maskText.MaskData(TextBox);
                //        break;
                //    case Mask.Celular:
                //        maskText.MaskCelular(TextBox);
                //        break;
                //}
            }
        }

        //public delegate void ClickBotaoUserControlEventHandler(object sender, RoutedEventArgs e);
        //public event ClickBotaoUserControlEventHandler ClickBotaoUserControlEventHandlerEvent;
        //void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    //Quando o evento click for executado , você dispara o seu evento.
        //    ClickBotaoUserControlEventHandlerEvent(sender, e);
        //}
        #endregion

        private void _this_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsEnabled)
            {
                //TextBox.Foreground = Foreground;
                TextBox.Background = Background;
            }
            else
            {
                //TextBox.Foreground = Brushes.Black;
                TextBox.Background = Brushes.WhiteSmoke;
            }
        }
    }
}
