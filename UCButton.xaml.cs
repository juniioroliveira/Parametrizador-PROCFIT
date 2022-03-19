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
    /// Interação lógica para UCButton.xam
    /// </summary>
    public partial class UCButton : UserControl
    {
        #region VARIAVEIS

        protected Brush foreColor;
        #endregion

        #region INICIALIZAÇÃO
        public UCButton()
        {
            InitializeComponent();

            button.Click += new RoutedEventHandler(button_Click);
        }
        private void _this_Loaded(object sender, RoutedEventArgs e)
        {
            foreColor = this.TextColor;
        }

        #endregion

        #region PROPRIEDADES


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UCButton), new PropertyMetadata(default));



        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(UCButton), new PropertyMetadata(default));




        public Brush ProgressColor
        {
            get { return (Brush)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressColorProperty =
            DependencyProperty.Register("ProgressColor", typeof(Brush), typeof(UCButton), new PropertyMetadata(Brushes.Blue));



        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(Brush), typeof(UCButton), new PropertyMetadata(Brushes.Blue));



        public Brush ButtonColor
        {
            get { return (Brush)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonColorProperty =
            DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(UCButton), new PropertyMetadata(Brushes.Transparent));



        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(Brush), typeof(UCButton), new PropertyMetadata(Brushes.Gray));





        public Visibility IconVisibility
        {
            get { return (Visibility)GetValue(IconVisibilityProperty); }
            set { SetValue(IconVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconVisibilityProperty =
            DependencyProperty.Register("IconVisibility", typeof(Visibility), typeof(UCButton), new PropertyMetadata(Visibility.Collapsed));



        public Visibility ProgressVisibility
        {
            get { return (Visibility)GetValue(ProgressVisibilityProperty); }
            set { SetValue(ProgressVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressVisibilityProperty =
            DependencyProperty.Register("ProgressVisibility", typeof(Visibility), typeof(UCButton), new PropertyMetadata(Visibility.Collapsed));




        public FontWeight ButtonFontStyle
        {
            get { return (FontWeight)GetValue(ButtonFontStyleProperty); }
            set { SetValue(ButtonFontStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonFontStyleProperty =
            DependencyProperty.Register("ButtonFontStyle", typeof(FontWeight), typeof(UCButton), new PropertyMetadata(FontWeights.Light));



        public int ButtonFontSize
        {
            get { return (int)GetValue(ButtonFontSizeProperty); }
            set { SetValue(ButtonFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonFontSizeProperty =
            DependencyProperty.Register("ButtonFontSize", typeof(int), typeof(UCButton), new PropertyMetadata(13));




        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(UCButton), new PropertyMetadata(3));



        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(UCButton), new PropertyMetadata(true));



        public double OpacityEfects
        {
            get { return (double)GetValue(OpacityEfectsProperty); }
            set { SetValue(OpacityEfectsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpacityEfects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpacityEfectsProperty =
            DependencyProperty.Register("OpacityEfects", typeof(double), typeof(UCButton), new PropertyMetadata(0.5));


        public MaterialDesignThemes.Wpf.PackIconKind Icon
        {
            get { return (MaterialDesignThemes.Wpf.PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(MaterialDesignThemes.Wpf.PackIconKind), typeof(UCButton), new PropertyMetadata(MaterialDesignThemes.Wpf.PackIconKind.Grade));



        #endregion

        #region EVENTOS


        //Cria um evento para o botão do seu UserControl
        public delegate void ClickButtonEventHandler(object sender, RoutedEventArgs e);
        public event ClickButtonEventHandler Click;
        void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Click != null)
                {
                    //Quando o evento click for executado , você dispara o seu evento.
                    Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void button_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!button.IsEnabled)
            {
                this.TextColor = Brushes.Black;
            }
            else
            {
                this.TextColor = foreColor;
            }
        }

        #endregion
    }
}