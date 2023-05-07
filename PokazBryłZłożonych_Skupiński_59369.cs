using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Projekt3_Skupiński_59369.Bryły;

namespace Projekt3_Skupiński_59369
{
    public partial class PokazBryłZłożonych_Skupiński_59369 : Form
    {
        Graphics Rysownica;
        Graphics WziernikLinii;
        List<BryłaAbstrakcyjna> LBG = new List<BryłaAbstrakcyjna>();
        Pen Pióro;
        Pen PióroZmian;
        Color Wypełnienie;
        const int psMargines = 20;
        bool KierunekObrotu = false;
        Point PunktLokalizacji = new Point(-1, -1);
        const int RozmiarWskaźnika = 10;
        bool CzyPokaz = false;
        List<BryłaAbstrakcyjna> LPBG;
        int psIndeksFigury;

        public PokazBryłZłożonych_Skupiński_59369()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X
            + psMargines, Screen.PrimaryScreen.Bounds.Y + psMargines);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.8f);
            this.StartPosition = FormStartPosition.Manual;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            trbPromień.Maximum = pbRysownica.Width / 2;
            trbWysokość.Maximum = pbRysownica.Height / 2;
            //ustalenie lokalizacji i rozmiarów
            pbRysownica.BorderStyle = BorderStyle.FixedSingle;
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            pbWziernikLinii.Image = new Bitmap(pbWziernikLinii.Width, pbWziernikLinii.Height);
            //sformatowanie pióra
            Pióro = new Pen(Color.BurlyWood, 1f);
            Pióro.DashStyle = DashStyle.Solid;
            Wypełnienie = Color.Azure;
            pbRysownica.BackColor = Color.AliceBlue;
            //utworzenie egzemplarzy rysownicy
            Rysownica = Graphics.FromImage(pbRysownica.Image);
            WziernikLinii = Graphics.FromImage(pbWziernikLinii.Image);
            pbWziernikWypełnienia.BorderStyle = BorderStyle.Fixed3D;
            pbWziernikWypełnienia.BackColor = Color.Aquamarine;
            //wykreślenie domyślnej lini
            WykreślenieWziernikaLinii();

        }

        //Deklaracja metody pomocniczej
        void WykreślenieWziernikaLinii()
        {
            const int Odstęp = 5;
            //wyczyszczenie powierzchni
            WziernikLinii.Clear(pbWziernikLinii.BackColor);
            //wykreślenie linii wzorcowej
            WziernikLinii.DrawLine(Pióro, Odstęp, pbWziernikLinii.Height / 2,
                pbWziernikLinii.Width - Odstęp, pbWziernikLinii.Height / 2);
            pbWziernikLinii.Refresh();
        }

        private void zapiszBitmapęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog OknoZapisu = new SaveFileDialog();
            OknoZapisu.Filter = ".bmp files (*bmp)|*.bmp|All files (*.*)|*.*";
            OknoZapisu.FilterIndex = 1;
            OknoZapisu.RestoreDirectory = true;
            OknoZapisu.InitialDirectory = "C:\\";
            OknoZapisu.Title = "Zapisanie bitmapy z Rysownicy";
            if (OknoZapisu.ShowDialog() == DialogResult.OK)
            {
                pbRysownica.Image.Save(OknoZapisu.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void kolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorów = new ColorDialog();
            PaletaKolorów.Color = Pióro.Color;
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                Pióro.Color = PaletaKolorów.Color;
            }//uaktualnienie WziernikaLinii
            WykreślenieWziernikaLinii();
            //zwolnienie okna Dialogowego
            PaletaKolorów.Dispose();
        }

        private void kolorWypełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorów = new ColorDialog();
            PaletaKolorów.Color = Wypełnienie;
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                Wypełnienie = PaletaKolorów.Color;
            }
            //zwolnienie okna Dialogowego
            PaletaKolorów.Dispose();
        }

        private void kolorTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorów = new ColorDialog();
            PaletaKolorów.Color = pbRysownica.BackColor;
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                pbRysownica.BackColor = PaletaKolorów.Color;
            }//uaktualnienie Rysownicy
            pbRysownica.Refresh();
            //zwolnienie okna Dialogowego
            PaletaKolorów.Dispose();
        }

        private void ciągłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.Solid;
            WykreślenieWziernikaLinii();

        }

        private void kreskowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.Dash;
            WykreślenieWziernikaLinii();
        }

        private void kropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.Dot;
            WykreślenieWziernikaLinii();
        }

        private void kreskowoKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pióro.DashStyle = DashStyle.DashDot;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pióro.Width = 1f;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Pióro.Width = 2f;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Pióro.Width = 3f;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Pióro.Width = 4f;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Pióro.Width = 5f;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Pióro.Width = 6f;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Pióro.Width = 7f;
            WykreślenieWziernikaLinii();
        }

        private void nudKątNachylenia_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnWykreślBryłę_Click(object sender, EventArgs e)
        {
            btWłączPokaz.Enabled = true;
            //pobranie atrybutów dla bryły
            int WysokośćBryły = trbWysokość.Value;
            int PromieńBryły = trbPromień.Value;
            int StopieńWielokąta = (int)nudStopieńWielokąta.Value;
            int KątNachylenia = (int)nudKątNachylenia.Value;
            //odczytanie wartości z myszy
            int XsP = PunktLokalizacji.X;
            int YsP = PunktLokalizacji.Y;

            switch (cbTypBryły.SelectedItem)
            {
                case "Walec":
                    Walec walec = new Walec(PromieńBryły, WysokośćBryły,
                        StopieńWielokąta, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    //dodanie bryły do listy brył
                    walec.Wykreśl(Rysownica);
                    LBG.Add(walec);
                    break;//
                case "Walec Pochyły":
                    WalecPochyły walecPochyły = new WalecPochyły(PromieńBryły, WysokośćBryły,
                        StopieńWielokąta, XsP, YsP, KątNachylenia, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    walecPochyły.Wykreśl(Rysownica);
                    LBG.Add(walecPochyły);
                    break;
                case "Stożek":
                    Stożek stożek = new Stożek(PromieńBryły, WysokośćBryły
                        , StopieńWielokąta, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    stożek.Wykreśl(Rysownica);
                    LBG.Add(stożek);
                    break;
                case "Stożek Pochyły":
                    StożekPochyły stożekPochyły = new StożekPochyły(PromieńBryły, WysokośćBryły,
                        StopieńWielokąta, XsP, YsP, KątNachylenia, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    stożekPochyły.Wykreśl(Rysownica);
                    LBG.Add(stożekPochyły);
                    break;
                case "Kula":
                    Kula kula = new Kula(PromieńBryły, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    kula.Wykreśl(Rysownica);
                    LBG.Add(kula);
                    break;
                case "Graniastosłup":
                    Graniastosłup graniastosłup = new Graniastosłup(PromieńBryły, StopieńWielokąta,
                        WysokośćBryły, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    graniastosłup.Wykreśl(Rysownica);
                    LBG.Add(graniastosłup);
                    break;
                case "Polihedron":
                    Polihedron polihedron = new Polihedron(PromieńBryły, StopieńWielokąta,
                        WysokośćBryły, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    polihedron.Wykreśl(Rysownica);
                    LBG.Add(polihedron);
                    break;
                case "Polihedron Płaski":
                    PolihedronPłaski polihedronPłaski = new PolihedronPłaski(PromieńBryły, StopieńWielokąta,
                        WysokośćBryły, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    polihedronPłaski.Wykreśl(Rysownica);
                    LBG.Add(polihedronPłaski);
                    break;
                case "Graniastosłup Pochyły":
                    GraniastosłupPochyły graniastosłupPochyły = new GraniastosłupPochyły(PromieńBryły, StopieńWielokąta,
                        WysokośćBryły, XsP, YsP, KątNachylenia, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    graniastosłupPochyły.Wykreśl(Rysownica);
                    LBG.Add(graniastosłupPochyły);
                    break;
                case "Ostrosłup":
                    Ostrosłup ostrosłup = new Ostrosłup(PromieńBryły, StopieńWielokąta
                        , WysokośćBryły, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    ostrosłup.Wykreśl(Rysownica);
                    LBG.Add(ostrosłup);
                    break;
                case "Ostrosłup Pochyły":
                    OstrosłupPochyły ostrosłupPochyły = new OstrosłupPochyły(PromieńBryły, StopieńWielokąta,
                        WysokośćBryły, XsP, YsP, KątNachylenia, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    ostrosłupPochyły.Wykreśl(Rysownica);
                    LBG.Add(ostrosłupPochyły);
                    break;
                case "Stożek Dwustronny":
                    StożekDwustronny stożekDwustronny = new StożekDwustronny(PromieńBryły, WysokośćBryły
                        , StopieńWielokąta, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    stożekDwustronny.Wykreśl(Rysownica);
                    LBG.Add(stożekDwustronny);
                    break;
                case "Ostrosłup Dwustronny":
                    OstrosłupDwustronny ostrosłupDwustronny = new OstrosłupDwustronny(PromieńBryły, StopieńWielokąta
                        , WysokośćBryły, XsP, YsP, KierunekObrotu,
                        Pióro.Color, Pióro.DashStyle, Pióro.Width);
                    ostrosłupDwustronny.Wykreśl(Rysownica);
                    LBG.Add(ostrosłupDwustronny);
                    break;
                default:
                    MessageBox.Show("Wybrana bryła jescze nie istnieje");
                    break;

            }
            using (SolidBrush Pędzel = new SolidBrush(pbRysownica.BackColor))
            {
                Rysownica.FillEllipse(Pędzel, PunktLokalizacji.X - RozmiarWskaźnika,
                        PunktLokalizacji.Y - RozmiarWskaźnika,
                        RozmiarWskaźnika, RozmiarWskaźnika);

            }
            pbRysownica.Refresh();

            btnWykreślBryłę.Enabled = false;
        }

        private void trbPromień_ValueChanged(object sender, EventArgs e)
        {
            lbPromieńBryły.Text = trbPromień.Value.ToString();
        }

        private void trbWysokość_ValueChanged(object sender, EventArgs e)
        {
            lbWysokośćBryły.Text = trbWysokość.Value.ToString();
        }

        private void rbLewoNowa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLewoNowa.Checked)
                KierunekObrotu = true;
        }

        private void rbPrawoNowa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrawoNowa.Checked)
                KierunekObrotu = false;
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void powrótToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Initial = new PokazInitialForm();
            Initial.Location = this.Location;
            Initial.StartPosition = FormStartPosition.Manual;
            Initial.Show();
            this.Hide();
        }

        private void pbRysownica_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CzyPokaz)//Wykreślenie zaznaczonego punktu
            {
                using (SolidBrush Pędzel = new SolidBrush(Color.Coral))
                {
                    if (PunktLokalizacji.X != -1)
                    {
                        Pędzel.Color = pbRysownica.BackColor;
                        Rysownica.FillEllipse(Pędzel, PunktLokalizacji.X - RozmiarWskaźnika,
                            PunktLokalizacji.Y - RozmiarWskaźnika,
                            RozmiarWskaźnika, RozmiarWskaźnika);

                    }
                    //zapisanie lokacji
                    PunktLokalizacji = e.Location;
                    Pędzel.Color = Color.Coral;
                    Rysownica.FillEllipse(Pędzel, PunktLokalizacji.X - RozmiarWskaźnika,
                            PunktLokalizacji.Y - RozmiarWskaźnika,
                             RozmiarWskaźnika, RozmiarWskaźnika);
                    pbRysownica.Refresh();
                    btnWykreślBryłę.Enabled = true;


                }
            }
        }

        private void btPoprzednia_Click(object sender, EventArgs e)
        {
            int psXmax = pbRysownica.Width;
            int psYmax = pbRysownica.Height;
            int psIndeksFigury;
            errorProvider1.Dispose();
            if (!int.TryParse(tbNumerBryły.Text, out psIndeksFigury))
            {
                errorProvider1.SetError(tbNumerBryły, "ERROR: W zapisanym numerze indeksu figury wystąpił niedozwolony znak");
                return;
            }
            if (psIndeksFigury < 0 || psIndeksFigury >= LBG.Count)
            {
                errorProvider1.SetError(tbNumerBryły, "ERROR: Indeks podanej figury wykracza poza dozwolony zakres");
                return;
            }
            Rysownica.Clear(pbRysownica.BackColor);

            if (psIndeksFigury > 0)
            {

                LPBG[psIndeksFigury].Wymaż(pbRysownica, Rysownica);
                psIndeksFigury--;
                LPBG[psIndeksFigury].Wykreśl(Rysownica);
                LPBG[psIndeksFigury].PrzesuńDoNowegoXY(pbRysownica, Rysownica, psXmax / 2, psYmax / 2);
                pbRysownica.Refresh();


            }
            else
            {
                LPBG[psIndeksFigury].Wymaż(pbRysownica, Rysownica);
                psIndeksFigury = LBG.Count - 1;
                LPBG[psIndeksFigury].Wykreśl(Rysownica);
                LPBG[psIndeksFigury].PrzesuńDoNowegoXY(pbRysownica, Rysownica, psXmax / 2, psYmax / 2);
                pbRysownica.Refresh();
            }
            tbNumerBryły.Text = psIndeksFigury.ToString();
            pbRysownica.Refresh();
            if (rbPromień.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Promień_Bryły.ToString();
            if (rbWysokość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Wysokość_Bryły.ToString();
            if (rbObjętość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Objętość_Bryły.ToString();
            if (rbPole.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Powierzchnia_Bryły.ToString();
            txtDane.Text = LPBG[psIndeksFigury].Powierzchnia_Bryły.ToString();
            txtKolor.BackColor = LPBG[psIndeksFigury].KolorLini;
            trbPromieńStara.Value = LPBG[psIndeksFigury].Promień_Bryły;
            trbWysokośćStara.Value = LPBG[psIndeksFigury].Wysokość_Bryły;
        }

        private void btNastępna_Click(object sender, EventArgs e)
        {
            int psXmax = pbRysownica.Width;
            int psYmax = pbRysownica.Height;

            errorProvider1.Dispose();
            if (!int.TryParse(tbNumerBryły.Text, out psIndeksFigury))
            {
                errorProvider1.SetError(tbNumerBryły, "ERROR: W zapisie indeksu figury do prezentacji wystąpił niedozwolony znak");
                return;
            }
            if (psIndeksFigury < 0 || psIndeksFigury > LBG.Count)
            {
                errorProvider1.SetError(tbNumerBryły, "ERROR: Do pola TextBox został wpisany nieodpowiedni indeks figury do prezentacji");
                return;
            }

            if (psIndeksFigury < LBG.Count - 1)
            {


                Rysownica.Clear(pbRysownica.BackColor);
                LPBG[psIndeksFigury].Wymaż(pbRysownica, Rysownica);
                psIndeksFigury++;
                LPBG[psIndeksFigury].Wykreśl(Rysownica);
                LPBG[psIndeksFigury].PrzesuńDoNowegoXY(pbRysownica, Rysownica, psXmax / 2, psYmax / 2);



            }
            else
            {
                LPBG[psIndeksFigury].Wymaż(pbRysownica, Rysownica);
                psIndeksFigury = 0;
                Rysownica.Clear(pbRysownica.BackColor);
                LPBG[psIndeksFigury].Wykreśl(Rysownica);
                LPBG[psIndeksFigury].PrzesuńDoNowegoXY(pbRysownica, Rysownica, psXmax / 2, psYmax / 2);

            }
            tbNumerBryły.Text = psIndeksFigury.ToString();
            pbRysownica.Refresh();
            if (rbPromień.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Promień_Bryły.ToString();
            if (rbWysokość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Wysokość_Bryły.ToString();
            if (rbObjętość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Objętość_Bryły.ToString();
            if (rbPole.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Powierzchnia_Bryły.ToString();

        }

        private void btWłączPokaz_Click(object sender, EventArgs e)
        {
            if (LBG.Count == 0)
            {
                return;
            }
            if (!CzyPokaz)
            {
                rbManualny.Enabled = true;
                rbAutomatyczny.Enabled = true;
                btPoprzednia.Enabled = true;
                btNastępna.Enabled = true;
                gbKryterium.Enabled = true;
                btnWykreślBryłę.Enabled = false;
                tbNumerBryły.Enabled = true;
                btWyłączPokaz.Enabled = true;
                btWłączPokaz.Enabled = false;
                gbZmianaWyglądu.Enabled = true;
                CzyPokaz = true;
                int psIndeksFigury = 0;
                errorProvider1.Dispose();
                foreach (BryłaAbstrakcyjna bryła in LBG)
                    bryła.Wymaż(pbRysownica, Rysownica);
                LPBG = new List<BryłaAbstrakcyjna>(LBG);
                Rysownica.Clear(pbRysownica.BackColor);

                {
                    if (string.IsNullOrEmpty(tbNumerBryły.Text.Trim()))
                    {
                        tbNumerBryły.Text = psIndeksFigury.ToString();
                    }
                    else if (!int.TryParse(tbNumerBryły.Text, out psIndeksFigury))
                    {
                        errorProvider1.SetError(tbNumerBryły, "ERROR: W zapisie numeru figury do prezentacji wystąpił niedozwolony znak");
                        return;
                    }
                    if (psIndeksFigury < 0 || psIndeksFigury >= LBG.Count)
                    {
                        errorProvider1.SetError(tbNumerBryły, "ERROR: Nie ma figury geometrycznej o takim numerze");
                        return;
                    }
                    int psXmax = pbRysownica.Width;
                    int psYmax = pbRysownica.Height;
                    LPBG[psIndeksFigury].Wykreśl(Rysownica);
                    LPBG[psIndeksFigury].PrzesuńDoNowegoXY(pbRysownica, Rysownica, psXmax / 2, psYmax / 2);
                }
                pbRysownica.Refresh();

            }



        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            const float KątObrotu = 5f;//w rad
            //obracanie wszystkich brył w LBG
            if (!CzyPokaz)
            {
                foreach (BryłaAbstrakcyjna Bryła in LBG)
                {
                    Bryła.Obróć_i_Wykreśl(pbRysownica, Rysownica, KątObrotu);
                    pbRysownica.Refresh();
                }
            }
            if (CzyPokaz)
            {
                foreach (BryłaAbstrakcyjna Bryła in LPBG)
                {
                    Bryła.Obróć_i_Wykreśl(pbRysownica, Rysownica, KątObrotu);
                    pbRysownica.Refresh();
                }
            }
        }

        private void rbAutomatyczny_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAutomatyczny.Checked)
                timer1.Enabled = true;
            gbZmianaWyglądu.Enabled = false;
        }

        private void rbManualny_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManualny.Checked)
                timer1.Enabled = false;
        }

        private void btWyłączPokaz_Click(object sender, EventArgs e)
        {



            foreach (BryłaAbstrakcyjna bryła in LPBG)
                bryła.Wymaż(pbRysownica, Rysownica);

            pbRysownica.Refresh();
            LPBG.Clear();
            LBG.Clear();
            btWłączPokaz.Text = "Włącz Pokaz";
            CzyPokaz = false;
            rbManualny.Enabled = false;
            rbAutomatyczny.Enabled = false;
            gbZmianaWyglądu.Enabled = false;
            btPoprzednia.Enabled = false;
            btNastępna.Enabled = false;
            gbKryterium.Enabled = false;
            btnWykreślBryłę.Enabled = true;
            tbNumerBryły.Enabled = true;
            btWyłączPokaz.Enabled = false;
            btWłączPokaz.Enabled = true;
            timer1.Enabled = false;
            rbManualny.Checked = true;
            tbNumerBryły.Text = "0";
            pbRysownica.Refresh();

        }

        private void btKolorLinii_Click(object sender, EventArgs e)
        {
            LPBG[psIndeksFigury].Wymaż(pbRysownica, Rysownica);
            ColorDialog PaletaKolorów = new ColorDialog();
            PaletaKolorów.Color = LPBG[psIndeksFigury].KolorLini;
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                LPBG[psIndeksFigury].KolorLini = PaletaKolorów.Color;
            }//uaktualnienie WziernikaLinii
            txtKolor.BackColor = LPBG[psIndeksFigury].KolorLini;
            //zwolnienie okna Dialogowego
            PaletaKolorów.Dispose();

            LPBG[psIndeksFigury].Wykreśl(Rysownica);
            pbRysownica.Refresh();


        }

        private void cbStyl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DashStyle Styl;
            {
                switch (cbStyl.SelectedIndex)
                {
                    case 0:
                        {
                            Styl = DashStyle.Solid;
                            break;
                        }
                    case 1:
                        {
                            Styl = DashStyle.Dash;
                            break;
                        }
                    case 2:
                        {
                            Styl = DashStyle.Dot;
                            break;
                        }
                    case 3:
                        {
                            Styl = DashStyle.DashDot;
                            break;
                        }
                    default:
                        {
                            Styl = DashStyle.Solid;
                            break;
                        }
                }
            }
            LPBG[psIndeksFigury].StylLini = Styl;
        }

        private void trbGrubość_ValueChanged(object sender, EventArgs e)
        {
            LPBG[psIndeksFigury].GrubośćLini = trbGrubość.Value;
            lbGrubość.Text = trbGrubość.Value.ToString();
            pbRysownica.Refresh();
        }

        private void rbLewoStara_CheckedChanged(object sender, EventArgs e)
        {
            LPBG[psIndeksFigury].Kierunek_Obrotu = true;
            pbRysownica.Refresh();
        }

        private void rbPrawoStara_CheckedChanged(object sender, EventArgs e)
        {
            LPBG[psIndeksFigury].Kierunek_Obrotu = false;
            pbRysownica.Refresh();
        }

        private void trbPromieńStara_Scroll(object sender, EventArgs e)
        {


            LPBG[psIndeksFigury].Wymaż(pbRysownica, Rysownica);
            LPBG[psIndeksFigury].Promień_Bryły = trbPromieńStara.Value;
            LPBG[psIndeksFigury].Wykreśl(Rysownica);
            LPBG[psIndeksFigury].OdświeżAtrybuty();
            pbRysownica.Refresh();
            lbPromieńZmień.Text = trbPromieńStara.Value.ToString();
            if (rbPromień.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Promień_Bryły.ToString();
            if (rbWysokość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Wysokość_Bryły.ToString();
            if (rbObjętość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Objętość_Bryły.ToString();
            if (rbPole.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Powierzchnia_Bryły.ToString();

        }

        private void trbWysokośćStara_ValueChanged(object sender, EventArgs e)
        {
            LPBG[psIndeksFigury].Wymaż(pbRysownica, Rysownica);
            LPBG[psIndeksFigury].Wysokość_Bryły = trbWysokośćStara.Value;
            LPBG[psIndeksFigury].Wykreśl(Rysownica);
            LPBG[psIndeksFigury].OdświeżAtrybuty();
            if (rbPromień.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Promień_Bryły.ToString();
            if (rbWysokość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Wysokość_Bryły.ToString();
            if (rbObjętość.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Objętość_Bryły.ToString();
            if (rbPole.Checked)
                txtDane.Text = LPBG[psIndeksFigury].Powierzchnia_Bryły.ToString();
            pbRysownica.Refresh();
            lbWsokośćZmień.Text = trbWysokośćStara.Value.ToString();
        }

        private void trbWysokośćStara_Scroll(object sender, EventArgs e)
        {

        }

        private void rbWysokość_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWysokość.Checked)
            {
                lbDane.Text = "Wysokość";
                txtDane.Text = LPBG[psIndeksFigury].Wysokość_Bryły.ToString();
                LPBG = LPBG.OrderBy(o => o.Wysokość_Bryły).ToList();
            }


        }

        private void rbPromień_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPromień.Checked)
            {
                lbDane.Text = "Promień";
                txtDane.Text = LPBG[psIndeksFigury].Promień_Bryły.ToString();
                LPBG = LPBG.OrderBy(o => o.Promień_Bryły).ToList();
            }
        }

        private void rbPole_CheckedChanged(object sender, EventArgs e)
        {

            if (rbPole.Checked)
            {
                lbDane.Text = "Pole";
                txtDane.Text = LPBG[psIndeksFigury].Powierzchnia_Bryły.ToString();
                LPBG = LPBG.OrderBy(o => o.Powierzchnia_Bryły).ToList();
            }
        }

        private void rbObjętość_CheckedChanged(object sender, EventArgs e)
        {
            if (rbObjętość.Checked)
            {
                lbDane.Text = "Objętość";
                txtDane.Text = LPBG[psIndeksFigury].Objętość_Bryły.ToString();
                LPBG = LPBG.OrderBy(o => o.Objętość_Bryły).ToList();
            }

        }

        private void cbTypBryły_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
