using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//dodatkowe namespace
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Projekt3_Skupiński_59369
{
    public class Bryły
    {
        const float KątProsty = 90.0f;
        //deklaracja klasy abstrakcyjnej
        public abstract class BryłaAbstrakcyjna
        {//deklaracja typy wyliczeniowego do określania typu bryły
            public enum TypyBryły
            { BG_Walec, BG_Stożek, BG_Kula,
                BG_Ostrosłup, BG_Graniastosłup, BG_Sześcian,
                BG_StożekPochyły, BG_WalecPochyły, BG_GraniastosłupPochyły
                    , BG_OstrosłupPochyły, BG_StożekDwustronny, BG_OstrosłupDwustronny,
                BG_Polihedron,BG_PoilhedronPłaski
            };
            //deklracja zmiennych dla wspólnych atrybótów geometrycznych
            protected int XsP, YsP;//środek podstawy
            protected int WysokośćBryły;
            public int Wysokość_Bryły
            {
                get { return WysokośćBryły; }
                set { WysokośćBryły = value; }
            }
            protected int PromieńBryły;//promień
            public int Promień_Bryły
            {
                get { return PromieńBryły; }
                set { PromieńBryły = value; }
            }
            public float KątNachylenia;
            protected Color Kolor_Linii;
            public Color KolorLini
            {
                get { return Kolor_Linii; }
                set { Kolor_Linii = value; }
            }
            protected DashStyle Styl_Linii;
            public DashStyle StylLini
            {
                get { return Styl_Linii; }
                set { Styl_Linii = value; }
            }
            protected float Grubość_Linii;
            public float GrubośćLini
            {
                get { return Grubość_Linii; }
                set { Grubość_Linii = value; }
            }
            protected bool Widoczny;
            //deklaracje zmiennych dla implementacji przyszłych funkcjonalności
            public TypyBryły RodzajBryły;
            protected bool KierunekObrotu;//false w prawo,true lewo
            public bool Kierunek_Obrotu
            {
                get { return KierunekObrotu; }
                set { KierunekObrotu = value; }
            }
            protected double PowierzchniaBryły;
            public double Powierzchnia_Bryły
            {
                get { return PowierzchniaBryły; }
                set { PowierzchniaBryły = value; }
            }
            protected double ObjętośćBryły;
            public double Objętość_Bryły
            {
                get { return ObjętośćBryły; }
                set { ObjętośćBryły = value; }
            }
            //deklaracja konstruktora
            public BryłaAbstrakcyjna(Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
            {
                Kolor_Linii = KolorLinii;
                Styl_Linii = StylLinii;
                Grubość_Linii = GrubośćLinii;
                KątNachylenia = KątProsty;
            }
            //deklaracja metod aabstrakcyjnych 
            //dla kturych nie możemy zapisać implementacji
            public abstract void Wykreśl(Graphics Rysownica);
            public abstract void Wymaż(Control Kontrolka, Graphics Rysownica);
            public abstract void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu);
            public abstract void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y);
            //deklaracje metod publicznych z pełną implementacją
            public void UstalAtrybutyGraficzne(Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
            {
                Kolor_Linii = KolorLinii;
                Styl_Linii = StylLinii;
                Grubość_Linii = GrubośćLinii;
            }
            public abstract void OdświeżAtrybuty();


        } //od klasy bryła abstrakcyjna
        public class BryłyObrotowe : BryłaAbstrakcyjna
        {

            protected float Oś_Duża, Oś_Mała;
            public BryłyObrotowe(int PromieńBryły, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) :
                base(KolorLinii, StylLinii, GrubośćLinii)
            {
                //zapisanie parametru promienia
                this.PromieńBryły = PromieńBryły;
            }
            //nadpisanie wszystkich metod abstrakcynych
            public override void Wykreśl(Graphics Rysownica)
            {

            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {

            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {

            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {

            }
            public override void OdświeżAtrybuty()
            {
                throw new NotImplementedException();
            }

        }//BryłyObrotowe
        //deklaracja klasy potomnej walec
        public class Walec : BryłyObrotowe
        {
            protected Point[] WielokątPodłogi;
            protected Point[] WielokątSufitu;
            protected int XsS, YsS;//stopień wielokąta podstawy
            public int StopieńWielokąta;
            //kąt środkowy między wierzchołkami wielokąta podstawy
            protected float KątMiędzyWierzchołkami;
            //kąt położenia pierwszego wierzzchołka wielokąta podstawy
            protected float KątPołożenia;
            //deklaracja konstruktora
            public Walec(int PromieńBryły, int WysokośćBryły, int StopieńWielokąta,
                int XsP, int YsP, bool KierunekObrotu, Color KolorLinii,
                DashStyle StylLinii, float GrubośćLinii) : base(PromieńBryły, KolorLinii, StylLinii, GrubośćLinii)
            {// ustawienie rodzaju bryły
                RodzajBryły = TypyBryły.BG_Walec;
                this.WysokośćBryły = WysokośćBryły;
                this.PromieńBryły = PromieńBryły;
                this.XsP = XsP;
                this.YsP = YsP;
                this.KierunekObrotu = KierunekObrotu;
                Widoczny = false;
                this.StopieńWielokąta = StopieńWielokąta;
                //wyznaczenie Kątów położenia
                KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                KątPołożenia = 0f;
                //wyznaczenie współrzędnych punktów w podłodze
                //i suficie walca dla wykerślania prążków
                WielokątPodłogi = new Point[StopieńWielokąta];
                WielokątSufitu = new Point[StopieńWielokąta];
                //utworzenie egzemplarzy punktów w podłodze i suficie
                for (int i = 0; i < StopieńWielokąta; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();
                    //Równanie parametryczne okręgu
                    //Xi=Xs+R*cos(fi);Yi=Ys+R*sin(fi)
                    //Równanie parametryczne elipsy
                    //Xi=Xs+OśDuża/2*cos(fi);Yi=OśMała*sin(fi)
                    //podłoga 
                    WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 *
                        Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    //Przejście z Rad na Degree!!!
                    WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    //sufit
                    WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 *
                        Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                }
                //obliczenie powieżchni i objętości walca
                //...ObjętośćBryły
                this.ObjętośćBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły * WysokośćBryły);
                this.PowierzchniaBryły = (float)(2 * Math.PI * PromieńBryły *
                    PromieńBryły + 2 * Math.PI * PromieńBryły * WysokośćBryły);
            }
            //Nadpisanie metod abstarkcyjnych
            public override void Wykreśl(Graphics Rysownica)
            {

                //wyznaczenie pozostałych współrzędnych środka sufitu Walca
                YsS = YsP - WysokośćBryły;
                XsS = XsP;
                Oś_Duża = PromieńBryły * 2;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    //wykreślenie podłogi i sufitu Walca
                    Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża,
                        Oś_Mała);
                    Rysownica.DrawEllipse(Pióro, XsS - Oś_Duża / 2, YsS - Oś_Mała / 2, Oś_Duża,
                        Oś_Mała);
                    //wykreślenie prążków na ścianie bocznej
                    using (Pen PióroPrążków = new Pen(Kolor_Linii, 0.5f * Grubość_Linii))
                    {
                        for (int i = 0; i < StopieńWielokąta; i++)
                        {
                            Rysownica.DrawLine(PióroPrążków,
                                WielokątPodłogi[i], WielokątSufitu[i]);
                        }
                    }
                    //wykreślenie krawędzi bocznych walca
                    //lewa
                    Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS - Oś_Duża / 2, YsS);
                    //prawa
                    Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS + Oś_Duża / 2, YsS);
                    Widoczny = true;
                }

            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                if (Widoczny) {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                    {
                        Pióro.DashStyle = Styl_Linii;
                        //wykreślenie podłogi i sufitu Walca
                        Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża,
                            Oś_Mała);
                        Rysownica.DrawEllipse(Pióro, XsS - Oś_Duża / 2, YsS - Oś_Mała / 2, Oś_Duża,
                            Oś_Mała);
                        //wykreślenie prążków na ścianie bocznej
                        using (Pen PióroPrążków = new Pen(Kontrolka.BackColor, 0.5f * Grubość_Linii))
                        {
                            for (int i = 0; i < StopieńWielokąta; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków,
                                    WielokątPodłogi[i], WielokątSufitu[i]);
                            }
                        }
                        //wykreślenie krawędzi bocznych walca
                        //lewa
                        Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS - Oś_Duża / 2, YsS);
                        //prawa
                        Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS + Oś_Duża / 2, YsS);
                        Widoczny = false;
                    }

                }

                //Kolor_Linii = Kontrolka.BackColor;
                //Wykreśl(Rysownica);

            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                //obracamy bryłę walec gdy jest widoczna
                if (Widoczny)
                {
                    Wymaż(Kontrolka, Rysownica);
                    //ustalenie nowego kąta pierwszego wierzchołka
                    if (KierunekObrotu)
                        KątPołożenia -= KątObrotu;
                    else
                        KątPołożenia += KątObrotu;
                    //wyznaczenie nowego położenia wierzchołków wielokątów
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        //Przejście z Rad na Degree!!!
                        WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        //sufit
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    }
                    //wykreślenie walca po obrocie
                    Wykreśl(Rysownica);
                }
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                //deklaracja zmiannych pomocniczych
                int dX, dY;
                if (Widoczny)
                {
                    Wymaż(Kontrolka, Rysownica);
                    //Wyznaczenie wektora przesunięcia
                    dX = XsP < X ? X - XsP : -(XsP - X);
                    dY = YsP < Y ? Y - YsP : -(YsP - Y);
                    //Wyznaczenie nowej lokalizacji walca
                    XsP += dX;
                    YsP += dY;
                    XsS += dX;
                    YsS += dY;
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        //Przejście z Rad na Degree!!!
                        WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        //sufit
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    }
                    //wykreślenie walca po obrocie
                    Wykreśl(Rysownica);

                }
            }
            public override void OdświeżAtrybuty()
            {
                ObjętośćBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły * WysokośćBryły);
                PowierzchniaBryły = (float)(2 * Math.PI * PromieńBryły *
                    PromieńBryły + 2 * Math.PI * PromieńBryły * WysokośćBryły);
            }





        }
        public class WalecPochyły : Walec
        {
            public WalecPochyły(int PromieńBryły, int WysokośćBryły, int StopieńWielokąta,
                int XsP, int YsP, float KątNachylenia, bool KierunekObrotu, Color KolorLinii,
                DashStyle StylLinii, float GrubośćLinii) : base(PromieńBryły, WysokośćBryły, StopieńWielokąta, XsP, YsP, KierunekObrotu, KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_WalecPochyły;
                this.KątNachylenia = KątNachylenia;
                //wyznaczenie przesunięcia wierzchołka stożka
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                //wyznaczenie pozostałych współrzędnych środka sufitu Walca
                YsS = YsP - WysokośćBryły;
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
                Oś_Duża = PromieńBryły * 2;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    //wykreślenie podłogi i sufitu Walca
                    Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża,
                        Oś_Mała);
                    Rysownica.DrawEllipse(Pióro, XsS - Oś_Duża / 2, YsS - Oś_Mała / 2, Oś_Duża,
                        Oś_Mała);
                    //wykreślenie prążków na ścianie bocznej
                    using (Pen PióroPrążków = new Pen(Kolor_Linii, 0.5f * Grubość_Linii))
                    {
                        for (int i = 0; i < StopieńWielokąta; i++)
                        {
                            Rysownica.DrawLine(PióroPrążków,
                                WielokątPodłogi[i], WielokątSufitu[i]);
                        }
                    }
                    //wykreślenie krawędzi bocznych walca
                    //lewa
                    Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS - Oś_Duża / 2, YsS);
                    //prawa
                    Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS + Oś_Duża / 2, YsS);
                    Widoczny = true;
                }

            }

        }
        public class Stożek : BryłyObrotowe
        {
            protected int XsS, YsS;//współżędne wierzchołka
            public int StopieńWielokąta;//ilość prążków
            //kąt między wierzchołkami podłogi dla prążków
            protected float KątMiędzyWierzchołkami;
            protected float KątPołożenia;//pierwszego wierzchołka wielokąta podstawy
            protected Point[] WielokątPodłogi;
            //deklaracja konstruktora
            public Stożek(int PromieńBryły, int WysokośćBryły, int StopieńWielokąta
                , int XsP, int YsP, bool KierunekObrotu, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                : base(PromieńBryły, KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_Stożek;
                Widoczny = false;
                this.KierunekObrotu = KierunekObrotu;
                this.XsP = XsP;
                this.YsP = YsP;
                this.WysokośćBryły = WysokośćBryły;
                this.PromieńBryły = PromieńBryły;
                this.StopieńWielokąta = StopieńWielokąta;
                this.
                KątPołożenia = 0f;
                KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                WielokątPodłogi = new Point[StopieńWielokąta];
                //Wyznaczenie współżędnych wierzchołków wielokąta wpisanego
                //w elipsę podłogi
                for (int i = 0; i < StopieńWielokąta; i++)
                {
                    //utworzenie egzemplarza klasy point 
                    //do którego będą wpisane wsp wierzchołka i
                    WielokątPodłogi[i] = new Point();
                    //wyznaczenie wartości wsp punktów
                    WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));




                }
                //objętość stożka i powierzchnia stożkaObjętośćBryły
                this.ObjętośćBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły * WysokośćBryły / 3);
                this.PowierzchniaBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły + Math.PI * PromieńBryły *
                    Math.Sqrt(WysokośćBryły * WysokośćBryły + PromieńBryły * PromieńBryły));


            }//od konstruktora
            //nadpisanie metod abstrakcyjnych
            public override void Wykreśl(Graphics Rysownica)
            {
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    //wykreślenie Podłogi
                    Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                    //wykreślenie prążków
                    using (Pen PióroPrążków = new Pen(Kolor_Linii, Grubość_Linii / 4))
                    {
                        for (int i = 0; i < StopieńWielokąta; i++)
                            Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                    }
                    //wykreślenie krawędzi
                    Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS, YsS);
                    Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS, YsS);
                    Widoczny = true;

                }
            }//wykreśl
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                if (Widoczny)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                    {
                        Pióro.DashStyle = Styl_Linii;
                        //wykreślenie Podłogi
                        Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        //wykreślenie prążków
                        using (Pen PióroPrążków = new Pen(Kontrolka.BackColor, Grubość_Linii / 4))
                        {
                            for (int i = 0; i < StopieńWielokąta; i++)
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                        }
                        //wykreślenie krawędzi
                        Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS, YsS);
                        Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS, YsS);
                        Widoczny = false;

                    }

                }
            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                if (Widoczny)
                {
                    //wywołanie wymaż
                    Wymaż(Kontrolka, Rysownica);
                    //wyznaczenie nowego kąta położenia wierzchołka wielokąta
                    if (KierunekObrotu)
                        KątPołożenia -= KątObrotu;
                    else
                        KątPołożenia += KątObrotu;
                    //wyznaczenie nowego położenia wszystkich wierzchołków wielokąta podłogi
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    }
                    Wykreśl(Rysownica);
                }
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                if (Widoczny)
                {

                    Wymaż(Kontrolka, Rysownica);
                    //wyznaczenie przyrostu współrzędnych
                    XsP = X; YsP = Y;
                    //wyznaczenie nowego środka podłogi Stożka
                    XsS = XsP;
                    YsS = YsP - WysokośćBryły;
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180f));
                    }
                    Wykreśl(Rysownica);
                }
            }//przesuń
            public override void OdświeżAtrybuty()
            {
                ObjętośćBryły = (float)(Math.PI * PromieńBryły *
    PromieńBryły * WysokośćBryły / 3);
                PowierzchniaBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły + Math.PI * PromieńBryły *
                    Math.Sqrt(WysokośćBryły * WysokośćBryły + PromieńBryły * PromieńBryły));
            }
        }//Stożek
        public class StożekPochyły : Stożek
        {
            //deklaracja konstruktora
            public StożekPochyły(int PromieńBryły, int WysokośćBryły, int StopieńWielokąta
                , int XsP, int YsP, float KątNachylenia, bool KierunekObrotu
                , Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                : base(PromieńBryły, WysokośćBryły, StopieńWielokąta,
                      XsP, YsP, KierunekObrotu, KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_StożekPochyły;
                this.KątNachylenia = KątNachylenia;
                //wyznaczenie przesunięcia wierzchołka stożka
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
            }//od konstruktora
            public override void Wykreśl(Graphics Rysownica)
            {
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
                YsS = YsP - WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    //wykreślenie Podłogi
                    Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                    //wykreślenie prążków
                    using (Pen PióroPrążków = new Pen(Kolor_Linii, Grubość_Linii / 4))
                    {
                        for (int i = 0; i < StopieńWielokąta; i++)
                            Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                    }
                    //wykreślenie krawędzi
                    Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS, YsS);
                    Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS, YsS);
                    Widoczny = true;

                }
            }//wykreśl
        }//StożekPochyły
        public class StożekDwustronny : Stożek
        {
            int XsD, YsD;
            public StożekDwustronny(int PromieńBryły, int WysokośćBryły, int StopieńWielokąta
                , int XsP, int YsP, bool KierunekObrotu
                , Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                : base(PromieńBryły, WysokośćBryły, StopieńWielokąta,
                      XsP, YsP, KierunekObrotu, KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_StożekDwustronny;
                XsD = XsP;
                YsD = YsP + WysokośćBryły;
                this.ObjętośćBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły * WysokośćBryły / 3)*2;
                this.PowierzchniaBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły + Math.PI * PromieńBryły *
                    Math.Sqrt(WysokośćBryły * WysokośćBryły + PromieńBryły * PromieńBryły)*2);
            }//od konstruktora
            public override void Wykreśl(Graphics Rysownica)
            {
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                XsD = XsP;
                YsD = YsP + WysokośćBryły;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    //wykreślenie Podłogi
                    Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                    //wykreślenie prążków
                    using (Pen PióroPrążków = new Pen(Kolor_Linii, Grubość_Linii / 4))
                    {
                        for (int i = 0; i < StopieńWielokąta; i++)
                        {
                            Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                            Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsD, YsD));

                        }
                    }
                    //wykreślenie krawędzi
                    Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS, YsS);
                    Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS, YsS);
                    Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsD, YsD);
                    Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsD, YsD);
                    Widoczny = true;

                }
            }//wykreśl
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                if (Widoczny)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                    {
                        Pióro.DashStyle = Styl_Linii;
                        //wykreślenie Podłogi
                        Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        //wykreślenie prążków
                        using (Pen PióroPrążków = new Pen(Kontrolka.BackColor, Grubość_Linii / 4))
                        {
                            for (int i = 0; i < StopieńWielokąta; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsD, YsD));
                            }
                        }
                        //wykreślenie krawędzi
                        Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsS, YsS);
                        Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsS, YsS);
                        Rysownica.DrawLine(Pióro, XsP - Oś_Duża / 2, YsP, XsD, YsD);
                        Rysownica.DrawLine(Pióro, XsP + Oś_Duża / 2, YsP, XsD, YsD);
                        Widoczny = false;

                    }

                }
            }
            public override void OdświeżAtrybuty()
            {
                ObjętośćBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły * WysokośćBryły / 3) * 2;
                PowierzchniaBryły = (float)(Math.PI * PromieńBryły *
                    PromieńBryły + Math.PI * PromieńBryły *
                    Math.Sqrt(WysokośćBryły * WysokośćBryły + PromieńBryły * PromieńBryły) * 2);
            }
        }
        public class Kula : BryłyObrotowe
        {
            int PrzesunięcieObręczy;
            float KątPołożeniaObręczy;
            public Kula(int PromieńBryły, int XsP, int YsP, bool KierunekObrotu,
                 Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) :
                base(PromieńBryły, KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_Kula;
                this.PromieńBryły = PromieńBryły;
                Widoczny = false;
                this.KierunekObrotu = KierunekObrotu;
                this.XsP = XsP;
                this.YsP = YsP;
                this.ObjętośćBryły = 4 / 3 * (float)Math.PI * ((Oś_Duża / 2) * (Oś_Duża / 2) * (Oś_Duża / 2));
                this.PowierzchniaBryły = 4 * (float)Math.PI * (Oś_Duża / 2) * (Oś_Duża / 2);
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                Oś_Duża = PromieńBryły * 2;
                Oś_Mała = PromieńBryły / 2;
                Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii);
                Pen PióroPrążków = new Pen(Pióro.Color, Grubość_Linii / 4);
                Pióro.DashStyle = Styl_Linii;
                //wykreślenie okręgu
                Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2,
                    Oś_Duża, Oś_Duża);
                //wykreślenie elipsy w poziomie kuli
                Rysownica.DrawEllipse(PióroPrążków, XsP - Oś_Duża / 2, YsP + Oś_Mała,
                    Oś_Duża, Oś_Mała);
                //wykreślenie prążków
                Rysownica.DrawEllipse(PióroPrążków, PrzesunięcieObręczy / 2 + XsP - Oś_Duża / 2,
                    YsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                Widoczny = true;
                Pióro.Dispose();
                PióroPrążków.Dispose();

            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii);
                Pen PióroPrążków = new Pen(Pióro.Color, Grubość_Linii / 4);
                Pióro.DashStyle = Styl_Linii;
                //wykreślenie okręgu
                Rysownica.DrawEllipse(Pióro, XsP - Oś_Duża / 2, YsP - Oś_Mała / 2,
                Oś_Duża, Oś_Duża);
                //wykreślenie elipsy w poziomie kuli
                Rysownica.DrawEllipse(PióroPrążków, XsP - Oś_Duża / 2, YsP + Oś_Mała,
                    Oś_Duża, Oś_Mała);
                //wykreślenie prążków
                Rysownica.DrawEllipse(PióroPrążków, PrzesunięcieObręczy / 2 + XsP - Oś_Duża / 2,
                    YsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                Widoczny = false;
                Pióro.Dispose();
                PióroPrążków.Dispose();
            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                if (Widoczny)
                {
                    KątPołożeniaObręczy = (KątPołożeniaObręczy + KątObrotu) % 360;
                    Wymaż(Kontrolka, Rysownica);
                    PrzesunięcieObręczy = (int)(KątPołożeniaObręczy % (int)(Oś_Duża)) * 2;
                    Wykreśl(Rysownica);
                }
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                if (Widoczny)
                {
                    Wymaż(Kontrolka, Rysownica);
                    XsP = X;
                    YsP = Y;
                    Wykreśl(Rysownica);
                }
            }
            public override void OdświeżAtrybuty()
            {
                this.ObjętośćBryły = 4 / 3 * (float)Math.PI * ((Oś_Duża / 2) * (Oś_Duża / 2) * (Oś_Duża / 2));
                this.PowierzchniaBryły = 4 * (float)Math.PI * (Oś_Duża / 2) * (Oś_Duża / 2);
            }
        }//Kula
        public class Wielościany : BryłaAbstrakcyjna
        {
            //deklaracja tablicy referencji wierzchołków podłogi i sufitu
            protected Point[] WielokątPodłogi;

            //stopień wielokąta podstawy i sufitu
            public int StopieńWielokąta;
            protected int XsS, YsS;
            protected int Oś_Duża, Oś_Mała;
            //kąt między wierzchołkami
            protected float KątMiędzyWierzchołkami;
            //Kąt położenia pierwszego wierzchołka
            protected float KątPołożeniaWierzchołka;
            public Wielościany(int PromieńBryły, int StopieńWielokąta, bool KierunekObrotu
                , Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                : base(KolorLinii, StylLinii, GrubośćLinii)
            {
                this.PromieńBryły = PromieńBryły;
                this.StopieńWielokąta = StopieńWielokąta;
                Widoczny = false;
                this.KierunekObrotu = KierunekObrotu;
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                throw new NotImplementedException();
            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                throw new NotImplementedException();
            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                throw new NotImplementedException();
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                throw new NotImplementedException();
            }
            public override void OdświeżAtrybuty()
            {
                throw new NotImplementedException();
            }

        }//Wielościany
        public class Graniastosłup : Wielościany
        {

            protected Point[] WielokątSufitu;
            public Graniastosłup(int PromieńBryły, int StopieńWielokąta,
                int WysokośćBryły, int XsP, int YsP, bool KierunekObrotu,
                Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                : base(PromieńBryły, StopieńWielokąta, KierunekObrotu,
                      KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_Graniastosłup;
                this.WysokośćBryły = WysokośćBryły;
                this.StopieńWielokąta = StopieńWielokąta;
                //przepisanie lokacji
                this.XsP = XsP;
                this.YsP = YsP;
                //Wyznaczenie Kątów położenia
                KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                KątPołożeniaWierzchołka = 0f;
                //wyznaczenie punktów do wykreślenia graniastosłupa
                WielokątPodłogi = new Point[StopieńWielokąta + 1];
                WielokątSufitu = new Point[StopieńWielokąta + 1];
                for (int i = 0; i <= StopieńWielokąta; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();
                    //Równanie parametryczne okręgu
                    //Xi=Xs+R*cos(fi);Yi=Ys+R*sin(fi)
                    //Równanie parametryczne elipsy
                    //Xi=Xs+OśDuża/2*cos(fi);Yi=OśMała*sin(fi)
                    WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 *
                       Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    //Przejście z Rad na Degree!!!
                    WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    //sufit
                    WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 *
                        Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                }
                //Obliczenie Powierzchni i Objętości
                double A = PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta));
                double PowierzchniaWielokątu = PromieńBryły * StopieńWielokąta
                    * PromieńBryły * (Math.Sin(Math.PI * 2 / StopieńWielokąta));
                double Bok = (Math.Sin(Math.PI / 2 * StopieńWielokąta)) * 2 * PromieńBryły;
                double Obwód = Bok * StopieńWielokąta;
                ObjętośćBryły = (float)(PromieńBryły * StopieńWielokąta
                    * PromieńBryły * (Math.Sin(Math.PI * 2 / StopieńWielokąta)) * WysokośćBryły / 3);
                this.PowierzchniaBryły = (float)(PowierzchniaWielokątu * 2 + WysokośćBryły * Obwód); ;


            }

            //nadpisania metod abstrakcyjnych
            public override void Wykreśl(Graphics Rysownica)
            {
                //wyznaczenie środka sufitu
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                //Wyznaczenie osi elipsy w którą wpisane będzie podłoga i sufit
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    Rysownica.DrawLines(Pióro, WielokątSufitu);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    Widoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    Rysownica.DrawLines(Pióro, WielokątSufitu);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    Widoczny = false;
                }

            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                if (Widoczny)
                {
                    Wymaż(Kontrolka, Rysownica);
                    if (KierunekObrotu)
                        KątPołożeniaWierzchołka -= KątObrotu;
                    else
                        KątPołożeniaWierzchołka += KątObrotu;
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    }
                    Wykreśl(Rysownica);
                }
            }//obróć
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                if (Widoczny)
                {
                    XsP = X;
                    YsP = Y;
                    Wymaż(Kontrolka, Rysownica);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 * Math.Cos
                            (Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 * Math.Sin
                            (Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątSufitu[i].X = WielokątPodłogi[i].X;
                        WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćBryły;
                    }
                    Wykreśl(Rysownica);
                }
            }
            public override void OdświeżAtrybuty()
            {
                double A = PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta));
                double PowierzchniaWielokątu = PromieńBryły * StopieńWielokąta
                    * PromieńBryły * (Math.Sin(Math.PI * 2 / StopieńWielokąta));
                double Bok = (Math.Sin(Math.PI / 2 * StopieńWielokąta)) * 2 * PromieńBryły;
                double Obwód = Bok * StopieńWielokąta;
                ObjętośćBryły = (float)(PromieńBryły * StopieńWielokąta
                    * PromieńBryły * (Math.Sin(Math.PI * 2 / StopieńWielokąta)) * WysokośćBryły / 3);
                this.PowierzchniaBryły = (float)(PowierzchniaWielokątu * 2 + WysokośćBryły * Obwód); ;
            }

        }//Graniastosłup
        public class GraniastosłupPochyły : Graniastosłup
        {
            public GraniastosłupPochyły(int PromieńBryły, int StopieńWielokąta,
               int WysokośćBryły, int XsP, int YsP, float KątNachylenia, bool KierunekObrotu,
               Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
               : base(PromieńBryły, StopieńWielokąta, WysokośćBryły, XsP, YsP, KierunekObrotu,
                     KolorLinii, StylLinii, GrubośćLinii)
            {
                this.KątNachylenia = KątNachylenia;

                RodzajBryły = TypyBryły.BG_GraniastosłupPochyły;
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
                YsS = YsP - WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                //wyznaczenie punktów do wykreślenia graniastosłupa
                WielokątPodłogi = new Point[StopieńWielokąta + 1];
                WielokątSufitu = new Point[StopieńWielokąta + 1];
                for (int i = 0; i <= StopieńWielokąta; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();
                    WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 *
                       Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    //Przejście z Rad na Degree!!!
                    WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    //sufit
                    WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 *
                        Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                }
            }
            public override void Wykreśl(Graphics Rysownica)
            {

                //wyznaczenie środka sufitu
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
                YsS = YsP - WysokośćBryły;
                //Wyznaczenie osi elipsy w którą wpisane będzie podłoga i sufit
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    Rysownica.DrawLines(Pióro, WielokątSufitu);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    Widoczny = true;
                }



            }
            
        }
        public class PolihedronPłaski : Graniastosłup
        {
            public PolihedronPłaski(int PromieńBryły, int StopieńWielokąta,
                 int WysokośćBryły, int XsP, int YsP, bool KierunekObrotu,
                 Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                 : base(PromieńBryły, StopieńWielokąta, WysokośćBryły, XsP, YsP, KierunekObrotu,
                       KolorLinii, StylLinii, GrubośćLinii)
            {


                RodzajBryły = TypyBryły.BG_PoilhedronPłaski;
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                //wyznaczenie punktów do wykreślenia graniastosłupa
                WielokątPodłogi = new Point[StopieńWielokąta + 1];
                WielokątSufitu = new Point[StopieńWielokąta + 1];
                for (int i = 0; i <= StopieńWielokąta; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();
                    WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 *
                       Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    //sufit
                    WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 *
                        Math.Cos(Math.PI * (KątPołożeniaWierzchołka + KątMiędzyWierzchołkami / 2 + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka + KątMiędzyWierzchołkami / 2 + i * KątMiędzyWierzchołkami) / 180f));
                }
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    Rysownica.DrawLines(Pióro, WielokątSufitu);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    }
                    for (int i = 1; i <= StopieńWielokąta; i++)
                    {  

                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i-1]);
                    }
                    Rysownica.DrawLine(Pióro, WielokątPodłogi[0], WielokątSufitu[StopieńWielokąta]);
                    Widoczny = true;
                }



            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    Rysownica.DrawLines(Pióro, WielokątSufitu);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    }
                    for (int i = 1; i <= StopieńWielokąta; i++)
                    {

                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i - 1]);
                    }
                    Rysownica.DrawLine(Pióro, WielokątPodłogi[0], WielokątSufitu[StopieńWielokąta]);
                    Widoczny = false;
                }

            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                if (Widoczny)
                {
                    Wymaż(Kontrolka, Rysownica);
                    if (KierunekObrotu)
                        KątPołożeniaWierzchołka -= KątObrotu;
                    else
                        KątPołożeniaWierzchołka += KątObrotu;
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaWierzchołka + KątMiędzyWierzchołkami / 2 + i * KątMiędzyWierzchołkami) / 180f));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaWierzchołka + KątMiędzyWierzchołkami / 2 + i * KątMiędzyWierzchołkami) / 180f));
                    }
                    Wykreśl(Rysownica);
                }
            }
        }
        public class Polihedron: PolihedronPłaski
    {
            int XsD, YsD;
            int XsT, YsT;
            public Polihedron(int PromieńBryły, int StopieńWielokąta,
               int WysokośćBryły, int XsP, int YsP, bool KierunekObrotu,
               Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
               : base(PromieńBryły, StopieńWielokąta, WysokośćBryły, XsP, YsP, KierunekObrotu,
                     KolorLinii, StylLinii, GrubośćLinii)
            {

                XsT = XsP;
                YsT = YsP - WysokośćBryły * 2;
                RodzajBryły = TypyBryły.BG_Polihedron;
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                XsD = XsP;
                YsD = YsP + WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                //wyznaczenie punktów do wykreślenia graniastosłupa
                WielokątPodłogi = new Point[StopieńWielokąta + 1];
                WielokątSufitu = new Point[StopieńWielokąta + 1];
                for (int i = 0; i <= StopieńWielokąta; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();
                    WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 *
                       Math.Cos(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    //Przejście z Rad na Degree!!!
                    WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    //sufit
                    WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 *
                        Math.Cos(Math.PI * (KątPołożeniaWierzchołka+ KątMiędzyWierzchołkami/2 + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                        Math.Sin(Math.PI * (KątPołożeniaWierzchołka+ KątMiędzyWierzchołkami/2 + i * KątMiędzyWierzchołkami) / 180f));
                }
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                XsT = XsP;
                YsT = YsP - WysokośćBryły * 2;
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                XsD = XsP;
                YsD = YsP + WysokośćBryły;
                Oś_Duża = 2 * PromieńBryły;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    Rysownica.DrawLines(Pióro, WielokątSufitu);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                        Rysownica.DrawLine(Pióro, WielokątSufitu[i], new Point(XsT, YsT));
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsD, YsD));
                    }
                    for (int i = 1; i <= StopieńWielokąta; i++)
                    {

                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i - 1]);
                    }
                    Rysownica.DrawLine(Pióro, WielokątPodłogi[0], WielokątSufitu[StopieńWielokąta]);
                    Widoczny = true;
                }



            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    Rysownica.DrawLines(Pióro, WielokątSufitu);

                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                    Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    Rysownica.DrawLine(Pióro, WielokątSufitu[i], new Point(XsT, YsT));
                    Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsD, YsD));
                }
                    for (int i = 1; i <= StopieńWielokąta; i++)
                    {

                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i - 1]);
                    }
                    Rysownica.DrawLine(Pióro, WielokątPodłogi[0], WielokątSufitu[StopieńWielokąta]);
                    Widoczny = false;
                }

            }
        }
        public class Ostrosłup:Wielościany
        {
            public virtual Point[] KalkulujWierzchołkiPodłogi()
            {
                for (int i = 0; i <= StopieńWielokąta; i++)
                {
                    WielokątPodłogi[i].X = (int)(XsP + Oś_Duża / 2 * Math.Cos
                        (Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));
                    WielokątPodłogi[i].Y = (int)(YsP + Oś_Mała / 2 * Math.Sin
                        (Math.PI * (KątPołożeniaWierzchołka + i * KątMiędzyWierzchołkami) / 180f));                    
                }
                return WielokątPodłogi;
            }
            public Ostrosłup(int PromieńBryły, int StopieńWielokąta,
                int WysokośćBryły, int XsP, int YsP, bool KierunekObrotu,
                Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                : base(PromieńBryły, StopieńWielokąta, KierunekObrotu,
                      KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_Ostrosłup;
                this.WysokośćBryły = WysokośćBryły;
                this.XsP = XsP;
                this.YsP = YsP;
                KątPołożeniaWierzchołka = 0f;
                KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                WielokątPodłogi = new Point[StopieńWielokąta + 1];
                WielokątPodłogi = KalkulujWierzchołkiPodłogi();
                //oblicz pole i objętość
                double A= PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta));
                double BocznaWysokość= Math.Sqrt((PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) *
                    (PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) + WysokośćBryły * WysokośćBryły);
                double Bok= (Math.Sin(Math.PI / 2 * StopieńWielokąta)) * 2 * PromieńBryły;
                double Obwód = Bok * StopieńWielokąta;
                this.ObjętośćBryły = (float)( PromieńBryły*StopieńWielokąta
                    *PromieńBryły*(Math.Sin(Math.PI*2/StopieńWielokąta)) * WysokośćBryły / 3);
                this.PowierzchniaBryły = (float)((Bok*A/2)+(Obwód*BocznaWysokość)/2);

            }//konstruktor
            public override void Wykreśl(Graphics Rysownica)
            {
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                Oś_Duża = PromieńBryły * 2;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii,Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsS, YsS));
                    Widoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsS, YsS));
                    Widoczny = false;
                }
            }
            public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                if(Widoczny)
                {
                    Wymaż(Kontrolka, Rysownica);
                    if (KierunekObrotu)
                        KątPołożeniaWierzchołka -= KątObrotu;
                    else
                        KątPołożeniaWierzchołka += KątObrotu;
                    WielokątPodłogi = KalkulujWierzchołkiPodłogi();
                    Wykreśl(Rysownica);
                }
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                if(Widoczny)
                {
                    Wymaż(Kontrolka, Rysownica);
                    XsP = X;YsP = Y;
                    XsS = XsP;YsS = YsP - WysokośćBryły;
                    WielokątPodłogi = KalkulujWierzchołkiPodłogi();
                    Wykreśl(Rysownica);
                }
            }
            public override void OdświeżAtrybuty()
            {
                double A = PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta));
                double BocznaWysokość = Math.Sqrt((PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) *
                    (PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) + WysokośćBryły * WysokośćBryły);
                double Bok = (Math.Sin(Math.PI / 2 * StopieńWielokąta)) * 2 * PromieńBryły;
                double Obwód = Bok * StopieńWielokąta;
                this.ObjętośćBryły = (float)(PromieńBryły * StopieńWielokąta
                    * PromieńBryły * (Math.Sin(Math.PI * 2 / StopieńWielokąta)) * WysokośćBryły / 3);
                this.PowierzchniaBryły = (float)((Bok * A / 2) + (Obwód * BocznaWysokość) / 2);
            }
        }
        public class OstrosłupPochyły:Ostrosłup
        {
            public OstrosłupPochyły(int PromieńBryły, int StopieńWielokąta,
               int WysokośćBryły, int XsP, int YsP,float KątNachylenia, bool KierunekObrotu,
               Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
               : base(PromieńBryły, StopieńWielokąta,WysokośćBryły,XsP,YsP, KierunekObrotu,
                     KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_OstrosłupPochyły;
                this.KątNachylenia = KątNachylenia;
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
                YsS = YsP - WysokośćBryły;
            }//konstruktor
            public override void Wykreśl(Graphics Rysownica)
            {
                XsS = (int)(XsP + (WysokośćBryły / Math.Tan(Math.PI * KątNachylenia / 180)));
                RodzajBryły = TypyBryły.BG_GraniastosłupPochyły;
                YsS = YsP - WysokośćBryły;
                Oś_Duża = PromieńBryły * 2;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsS, YsS));
                    Widoczny = true;
                }
            }
        }
        public class OstrosłupDwustronny:Ostrosłup
        {
            int XsD, YsD;
            public OstrosłupDwustronny(int PromieńBryły, int StopieńWielokąta,
             int WysokośćBryły, int XsP, int YsP, bool KierunekObrotu,
             Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
             : base(PromieńBryły, StopieńWielokąta, WysokośćBryły, XsP, YsP, KierunekObrotu,
                   KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypyBryły.BG_OstrosłupDwustronny;
                XsD = XsP;
                YsD = YsP + WysokośćBryły;
                YsS = YsP - WysokośćBryły;
                double A = PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta));
                double BocznaWysokość = Math.Sqrt((PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) *
                    (PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) + WysokośćBryły * WysokośćBryły);
                double Bok = (Math.Sin(Math.PI / 2 * StopieńWielokąta)) * 2 * PromieńBryły;
                double Obwód = Bok * StopieńWielokąta;
                this.ObjętośćBryły = (float)(PromieńBryły * StopieńWielokąta
                    * PromieńBryły * (Math.Sin(Math.PI * 2 / StopieńWielokąta)) * WysokośćBryły / 3)*2;
                this.PowierzchniaBryły = (float)((Bok * A / 2) + (Obwód * BocznaWysokość) / 2)*2;
            }//konstruktor
            public override void Wykreśl(Graphics Rysownica)
            {
                YsD = YsP + WysokośćBryły;
                YsS = YsP - WysokośćBryły;
                XsS = XsP;
                YsS = YsP - WysokośćBryły;
                Oś_Duża = PromieńBryły * 2;
                Oś_Mała = PromieńBryły / 2;
                using (Pen Pióro = new Pen(Kolor_Linii, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsS, YsS));
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsD, YsD));
                    }
                    Widoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, Grubość_Linii))
                {
                    Pióro.DashStyle = Styl_Linii;
                    Rysownica.DrawLines(Pióro, WielokątPodłogi);
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsS, YsS));
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], new Point(XsD, YsD));
                    }
                    Widoczny = false;
                }
            }
            public override void OdświeżAtrybuty()
            {
                double A = PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta));
                double BocznaWysokość = Math.Sqrt((PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) *
                    (PromieńBryły * (Math.Cos(Math.PI / 2 * StopieńWielokąta))) + WysokośćBryły * WysokośćBryły);
                double Bok = (Math.Sin(Math.PI / 2 * StopieńWielokąta)) * 2 * PromieńBryły;
                double Obwód = Bok * StopieńWielokąta;
                this.ObjętośćBryły = (float)(PromieńBryły * StopieńWielokąta
                    * PromieńBryły * (Math.Sin(Math.PI * 2 / StopieńWielokąta)) * WysokośćBryły / 3) * 2;
                this.PowierzchniaBryły = (float)((Bok * A / 2) + (Obwód * BocznaWysokość) / 2) * 2;
            }
        }


    }//Bryły
}//namespace
