using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace animate
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Rect_flash(object sender, RoutedEventArgs e)
        {
            myStory.Begin();
        }

        private void Rect_tapped(object sender, TappedRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;

            if (null != rect)
            {
                rect.Width += 25;
            }
        }
        public void Create_Run_Anim(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = new Ellipse(); //crée ellipse blanche
            Color color = Color.FromArgb(255, 255, 255, 255);
            SolidColorBrush brush = new SolidColorBrush();
            TranslateTransform transform = new TranslateTransform(); //crée la transformation => ce qui va faire bouger l'ellipse
            Duration last = new Duration(TimeSpan.FromSeconds(5)); //anim dure 5 secondes
            DoubleAnimation animX = new DoubleAnimation(); //crée 1 double animation
            Storyboard story = new Storyboard(); //crée le storyboard

            //crée ellipse blanche
            ellipse.Width = 200;
            ellipse.Height = 200;
            brush.Color = color;
            ellipse.Fill = brush;

            LayoutRoot.Children.Add(ellipse); //ajoute ellipse à la vue

            //crée la transformation, fait bouger l'ellipse
            transform.X = -850; //fait démarrer la balle depuis le bord gauche
            transform.Y = 100; //décale de 100 vers le bas
            ellipse.RenderTransform = transform;

            //crée le storyboard
            story.Duration = last;
            story.Children.Add(animX);
            Storyboard.SetTarget(animX, transform);
            Storyboard.SetTargetProperty(animX, "X"); //spéficie les propriétés de l'animation
            animX.To = 850; //pr aller jusqu'au bort du cadre
            animX.RepeatBehavior = new RepeatBehavior(2); //le nombre de fois où ca se répète
            animX.AutoReverse = true; //pr faire des aller-retour de l'ellipse

            //ajoute la storyboard aux ressources
            LayoutRoot.Resources.Add("story", story);

            //démarre l'anim
            story.Begin();
        }
    }
}
