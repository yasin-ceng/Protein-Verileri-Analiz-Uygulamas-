using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace gorsel_odev1
{
    public partial class Form1 : Form
    {
        private const char Separator = ' ';

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_getir_Click(object sender, EventArgs e)
        {

            for (int a = 0; a < listBox1.Items.Count; a++)
            {
                //if (txt_in_prtnm.Text != "")
             
                    pdbOkuBandirma(a);
            }
        }

        private void pdbOkuBandirma(int a)
        {
            try
            {
                //Dosya yolu tanımlama satırları:

                //string dosyaYoluCan = @"\\192.168.1.100\Portal\" + listBox1.Items[a].ToString();

                string dosyaYoluCan = @"C:\Users\Yasin\Desktop\Portal\" + listBox1.Items[a].ToString();


                //string dosyaYoluCan = @"\\192.168.1.100\Portal\" + txt_in_prtnm.Text + ".srt";



                //dosyadan okunan satırları satir[] dizisine atar
                string[] satir = System.IO.File.ReadAllLines(dosyaYoluCan);
                // string[] temizSatir = null;
                string temizSatir = null;
                char[] ayracSpace = new char[] { ' ' };



               
                int n = 0;
                int say = 0;


 {




                    for (int i = 0; i < satir.Length; i += 1)
                    {
                        // tekil += 3;
                        if (i + 1 < satir.Length)
                        {
                            /*
                            if( (!(satir[i].StartsWith("0"))) && (!(satir[i].StartsWith("1"))) && (!(satir[i].StartsWith("2")))
                                && (!(satir[i].StartsWith("3"))) && (!(satir[i].StartsWith("4"))) && (!(satir[i].StartsWith("5")))
                                && (!(satir[i].StartsWith("6"))) && (!(satir[i].StartsWith("7"))) && (!(satir[i].StartsWith("8")))
                                && (!(satir[i].StartsWith("9"))) && (!(satir[i].StartsWith((i-1).ToString()))))*/

                            if((!(satir[i].StartsWith((i+1).ToString())) &&  (!(satir[i].StartsWith((i - 1).ToString()))) && (!(satir[i].StartsWith((i).ToString()))) &&  (!(satir[i].StartsWith("0"))) && (!(satir[i].StartsWith(" "))) &&   (!(satir[i].StartsWith("1")))) && (!(satir[i].StartsWith("2")))
                                && (!(satir[i].StartsWith("3"))) && (!(satir[i].StartsWith("4"))) && (!(satir[i].StartsWith("5"))) && (!(satir[i].StartsWith("6")))
                                && (!(satir[i].StartsWith("9"))) && (!(satir[i].StartsWith("8"))) && (!(satir[i].StartsWith("7"))))
                                temizSatir = temizSatir + " " +satir[i]  ;
                            if (i > 150 && i < 155)
                                temizSatir = temizSatir + "\n";
                            n += 1;
                        }

                    }



                    /*


                    for (int i = 2; i < satir.Length; i += 4)
                        {
                            // tekil += 3;
                            if (i + 1 < satir.Length)
                            {

                                //listBox1.Items.Add(satir[i].Trim());
                                temizSatir = temizSatir + satir[i] + " " + satir[i + 1];
                                if (i > 150 && i < 155)
                                    temizSatir = temizSatir + "\n";
                                n += 1;
                            }

                        }


                    */




                    //mentindeki kelimeleri ayıklama
                    string[] kelimeler = temizSatir.Split(' ');

                    //başlık kelimelerini ayıklama
                    string[] baslik = listBox1.Items[a].ToString().Split(' ');



                    //kelime değişikliği
                    for (int i=0;i<kelimeler.Length;i++)
                    {

                        if (kelimeler[i].Equals("videolar", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "makaleler";

                        if (kelimeler[i].Equals("Videolarımız", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "makalelerimiz";

                        if (kelimeler[i].Equals("Konuştuk", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "yazdık";

                        if (kelimeler[i].Equals("izleyin", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "okuyun";

                        if (kelimeler[i].Equals("bakın", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "okuyun";

                        if (kelimeler[i].Equals("video", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "makale";

                        if (kelimeler[i].Equals("videoda", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "makalede";

                        if (kelimeler[i].Equals("canlı yayın", StringComparison.InvariantCultureIgnoreCase))
                            kelimeler[i] = "yazı";

                        if (kelimeler[i].Equals("hoşgeldiniz", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "Sevgili okurlar,";

                        if (kelimeler[i].Equals("ağabey", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "sevgili okurlar";

                        if (kelimeler[i].Equals("abi", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "sevgili okurlar";

                        if (kelimeler[i].Equals("kardeş", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "sevgili okurlar";

                        if (kelimeler[i].Equals("kardeşim", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "sevgili okurlar";

                        if (kelimeler[i].Equals("arkadaşlar", StringComparison.InvariantCultureIgnoreCase))
                        kelimeler[i] = "sevgili okurlar";

                    }

                    for (int i = 0; i < kelimeler.Length; i++)
                    {
                        for (int j = 0; j < baslik.Length; j++) {
                            if (kelimeler[i].Equals(baslik[j], StringComparison.InvariantCultureIgnoreCase))
                            kelimeler[i] = "<strong>" + kelimeler[i] + "</strong>";
                        }


                    }
















                        // çalışan paragraf for döngüsü ile tagler ve paragraflar ayrılır

                        for (say = 150; say < kelimeler.Length; say++)
                    {


                        if (kelimeler[say].Contains(".")) {
                            kelimeler[say] += "\n\n<h3>";
                            say++;
                            break; 
                        
                        }

                    }

                        for (; say < kelimeler.Length; say++)
                    {
                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "</h3>";
                            say++;
                            break;
                        }
                    }





                    if(kelimeler.Length>450)
                    for ( say = 450; say < kelimeler.Length; say++)
                    {


                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "\n\n<h2>";
                                say++;
                                break;
                        }

                    }

                    if (kelimeler.Length > 450)
                        for (; say < kelimeler.Length; say++)
                    {
                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "</h2>";
                            break;
                        }
                    }




                    if (kelimeler.Length > 650)
                        for ( say = 650; say < kelimeler.Length; say++)
                        {


                            if (kelimeler[say].Contains("."))
                            {
                                kelimeler[say] += "\n\n<h2>";
                                say++;
                                break;
                            }

                        }

                    if (kelimeler.Length > 650)

                        for (; say < kelimeler.Length; say++)
                    {
                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "</h2>";
                            break;
                        }
                    }



                    if (kelimeler.Length > 900)
                        for ( say = 900; say < kelimeler.Length; say++)
                        {


                            if (kelimeler[say].Contains("."))
                            {
                                kelimeler[say] += "\n\n<h2>";
                                say++;
                                break;
                            }

                        }

                    if (kelimeler.Length > 900)

                        for (; say < kelimeler.Length; say++)
                    {
                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "</h2>";
                            break;
                        }
                    }

                    if (kelimeler.Length > 1050)
                        for ( say = 1050; say < kelimeler.Length; say++)
                        {


                            if (kelimeler[say].Contains("."))
                            {
                                kelimeler[say] += "\n\n<h3>";
                                say++;
                                break;
                            }

                        }

                    if (kelimeler.Length > 1050)
                        for (; say < kelimeler.Length; say++)
                    {
                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "</h3>";
                            break;
                        }
                    }

                    if (kelimeler.Length > 1200)

                        if (kelimeler.Length > 1200)
                        for ( say = 1200; say < kelimeler.Length; say++)
                        {


                            if (kelimeler[say].Contains("."))
                            {
                                kelimeler[say] += "\n\n<h3>";
                                say++;
                                break;
                            }

                        }

                    if (kelimeler.Length > 1200)
                        for (; say < kelimeler.Length; say++)
                    {
                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "</h3>";
                            break;
                        }
                    }

                    if (kelimeler.Length > 1350)
                        for (say = 1350; say < kelimeler.Length; say++)
                        {


                            if (kelimeler[say].Contains("."))
                            {
                                kelimeler[say] += "\n\n<h3>";
                                say++;
                                
                                break;

                            }

                        }
                    if (kelimeler.Length > 1350)
                        for (; say < kelimeler.Length; say++)
                    {
                        if (kelimeler[say].Contains("."))
                        {
                            kelimeler[say] += "</h3>";
                            break;
                        }
                    }


                    /*
                    int say = 150;
                    do
                    {


                        if (kelimeler[say].Contains("."))
                            kelimeler[say] += "\n";
                        say++;
                    } while (kelimeler[say].Contains('.'));
                    */






                    string makale = null;
                    for (int i = 0; i < kelimeler.Length; i++)
                        makale = makale +" "+ kelimeler[i];


                    //FileStream fs = new FileStream(@"D:\pdb\Deneme.txt", FileMode.OpenOrCreate, FileAccess.Write);
                   //FileStream fs = new FileStream(@"\\192.168.1.100\Portal\MAKALELER\" + listBox1.Items[a].ToString() + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                    FileStream fs = new FileStream(@"C:\Users\Yasin\Desktop\Portal\MAKALELER\" + listBox1.Items[a].ToString() + ".txt", FileMode.OpenOrCreate, FileAccess.Write);


                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(makale);
                    sw.Flush();
                    sw.Close();
                    fs.Close();



                }
                }
            catch (System.IO.IOException) //oluşması muhtemel hatalı dosya adı yakalanır
            {
                MessageBox.Show(txt_in_prtnm.Text + " Adında Dosya Bulunamadı");
            }
            catch (System.ArgumentException)  //dosya adı olamayacak veri girildiğinde hata yakalanır
            {
                MessageBox.Show("Geçersiz Karakter Girildi");
            }
        }

        private void txt_in_prtnm_Validating(object sender, CancelEventArgs e)
        {
            if (txt_in_prtnm.Text.Trim() == "")
                errorProvider1.SetError(txt_in_prtnm, "Dosya adını giriniz");
            else
                errorProvider1.SetError(txt_in_prtnm, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sunucu\\ dizini altındaki dosyaları işleme alır.\n\n\"Girdi Örneği: 7buy\"  ");
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                    
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }


        }




        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

            //boşluk karakteri ayraç olarak tanımlandı:
            char[] ayrac = new char[] { '.' };


            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //label1.Text = filePaths[0];
            filePaths[0].Split(ayrac);
//            label1.Text = a.ToString();
            String dosyaSrt = filePaths[0].Substring(30);
            listBox1.Items.Add(dosyaSrt);
//           txt_in_prtnm.Text = dosyaSrt;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_in_prtnm.Text  =  listBox1.SelectedItem.ToString();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);

        }
    }
}