using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    struct infoKala
    {
        public string name;
        public string info;
        public int date;
        public int price;
        public int code;
        public int count;
        public int stotre;

    }
    struct SoldItem
    {

        public infoKala kala;
        public string TheBuyer;
        public int price;
        public int count;
        public int SaleDate;
        public int code;
    }
    struct ChekInfo
    {
        public string ChekOwner;
        public string PayTo;
        public int PriceChek;
        public int SerialNumber;
        public int date;

    }
    struct store1
    {
        public infoKala item;
    }
    struct store2
    {
        public infoKala part;
    }
    class Program
    {
        List<infoKala> ListKala = new List<infoKala>();
        List<SoldItem> SalesList = new List<SoldItem>();
        List<ChekInfo> chekList = new List<ChekInfo>();
        List<infoKala> store1 = new List<infoKala>();
        List<infoKala> store2 = new List<infoKala>();



        int SunPriceKala = 0;
        int SunCountKala = 0;

        static void Main(string[] args)
        {
            Program b = new Program();
            b.reader();
            bool flag = true;
            int readNum = 0;
            string pass = "";
            Console.WriteLine("enter password");
            pass = Console.ReadLine();

            bool xrp = true;

            while (xrp)
            {

                if (pass == "1234")
                {

                    b.c();
                    xrp = false;
                }
                else
                {
                    Console.WriteLine("enter the correct password");
                    pass = Console.ReadLine();


                }




            }
           
            Console.ReadKey();
        }
        public infoKala info()
        {


            infoKala ins = new infoKala();
            //نام کالا
            Console.WriteLine("enter name");
            ins.name = Console.ReadLine();
            //قیمت کالا
            Console.WriteLine("enter price");

            ins.price = getInt();
            //توضیحات کالا
            Console.WriteLine("enter info ");
            ins.info = Console.ReadLine();
            //سال تولید
            Console.WriteLine("enter date");

            ins.date = getInt();
            //کد کالا
            Console.WriteLine("enter code");

            ins.code = getInt();
            //تعداد کالا
            Console.WriteLine("enter count kala");
            ins.count = getInt();

            //برای جابجایی بین انبار



          
            return ins;
           
      
            


        }
        public void addKala()
        {
            infoKala kala = new infoKala();
            kala = info();
           ListKala.Add(kala);

            addStore(ref kala);
            fileInfo(kala);

        }

        public void sortKala()
        {
            for (int i = 1; i < ListKala.Count; i++)
            {
                for (int j = 0; j < ListKala.Count - i; j++)
                {
                    infoKala temp = new infoKala();
                    if (ListKala[j].price > ListKala[j + 1].price)
                    {
                        temp = ListKala[j];
                        ListKala[j] = ListKala[j + 1];
                        ListKala[j + 1] = temp;
                    }

                }
            }

        }
        public void ShowListKala()
        {
            if (store1 != null)
            {
                foreach (infoKala item in store1)
                {
                    Console.WriteLine("In store 1");



                    print(item);


                }
            }
            else if (store2 != null)
            {
                foreach (infoKala item in store2)
                {
                    Console.WriteLine("In store 2");


                    print(item);


                }
            }
        }
        public infoKala getKala()
        {
            bool loop = true;
            infoKala kala = new infoKala();
            while (loop)
            {
                int code1;
                Console.WriteLine("enter code kala");
                code1 = getInt();

                kala = ListKala.Where(p => p.code == code1).SingleOrDefault();

                if (kala.code == 0)
                {
                    Console.WriteLine("kala not found kala enter 1 for continiue");
                    if (getInt() != 1)
                    {
                        loop = false;
                    }
                }

                else
                    loop = false;

            }



            return kala;
        }


        public int getInt()
        {
            bool flag = false;
            int num = 0;
            while (true)
            {
                string str = Console.ReadLine();
                flag = tryPars(str, out num);
                if (flag == true)
                {
                    return num;
                }

                Console.WriteLine("enter corect number");
            }

        }
        public bool tryPars(string a, out int o)
        {

            foreach (char c in a.ToArray())
            {
                if ((c >= 48 && c <= 57) == false)
                {
                    o = 0;
                    return false;
                }


            }
            o = Convert.ToInt32(a);

            return true;

        }
        public void sortKala2()
        {
            for (int i = 1; i < ListKala.Count; i++)
            {
                for (int j = 0; j < ListKala.Count - i; j++)
                {
                    infoKala temp = new infoKala();
                    if (ListKala[j].price < ListKala[j + 1].price)
                    {
                        temp = ListKala[j];
                        ListKala[j] = ListKala[j + 1];
                        ListKala[j + 1] = temp;

                    }

                }
            }
        }

        public void Expensive()
        {

            if (ListKala.Count == 0)
                return;
            sortKala();

            infoKala fhd = ListKala[ListKala.Count - 1];
            print(fhd);


        }
        public void chepeer()
        {
            if (ListKala.Count == 0)
                return;
            sortKala();

            infoKala fhd = ListKala[0];
            print(fhd);

        }
        public string print(infoKala item)
        {

            string txt = "name: " + item.name + "  info Kala: " + item.info + "  price kala: " + item.price.ToString() + " count kala: " + item.count.ToString()+" store:  "+item.stotre+".";
            Console.WriteLine(txt);
            return txt;

        }
        public string printSold(SoldItem kala)
        {
            string txt = "code: " + kala.code + " count: " + kala.count + " price: " + kala.price;
            Console.WriteLine(txt);
            return txt;

        }
        public void sun()
        {
            SunCountKala = 0;
            SunPriceKala = 0;
            double avg = 0;
            foreach (infoKala hdh in ListKala)
            {
                SunCountKala = SunCountKala + hdh.count;
                SunPriceKala = SunPriceKala + hdh.price * hdh.count;

            }
            avg = SunPriceKala / SunCountKala;


            Console.WriteLine("sun price kala= " + SunPriceKala + " sun count kala= " + SunCountKala + " avg kala= " + avg);

        }
        public SoldItem sale(infoKala objIn)
        {
            SoldItem far = new SoldItem();
            //نام کالای برای فروش
            Console.WriteLine(" name  Kala : " + objIn.name);

            //تعداد کالا برای فروش
            Console.WriteLine("count Kala : " + objIn.count.ToString());


            far.kala = new infoKala();
            far.kala = objIn;
            //نام خریدار
            Console.WriteLine("enrer name buyer");
            far.TheBuyer = Console.ReadLine();
            //قیمت فروخته شده
            Console.WriteLine("enter price");
            far.price = getInt();
            //تعداد کالا
            Console.WriteLine("enter count Kala");
            far.count = getInt();
            //تاریخ فروش کالا
            Console.WriteLine("enter data");
            far.SaleDate = getInt();
            //کد ملی خریدار
            Console.WriteLine("enter code meli buyer");
            far.code = getInt();

            return far;
        }
        public void AddSoldKala()
        {
            SoldItem sold = new SoldItem();
            infoKala kala = new infoKala();
           
            infoKala kal = getKala();
            if (kal.code > 0)
            {
                sold = sale(kal);
            }
            if (sold.count > 0 && kal.count >= sold.count)
            {
                kala.count = kala.count - sold.count;


               // ListKala.Where(p => p.code == 11).;

                


                SalesList.Add(sold);
                fileSale(sold);
                Console.WriteLine("it is registered");
            }
            else
                Console.WriteLine("the information is incorrect");

          
        }
        public infoKala findKalaToSale()
        {
            Console.WriteLine("enter code for sale");

            infoKala obj = getKala();

            return obj;


        }

        public void ShowListSales()
        {
            foreach (SoldItem kala in SalesList)
            {
                Console.WriteLine("name kala = " + kala.kala.name + " name buyer= " + kala.TheBuyer +
                    " price kala=" + kala.price.ToString() + " date sale= " + kala.SaleDate.ToString() + "code meli buyer= " + kala.code.ToString());
            }
        }
        public void SellMenu()
        {
            bool erd = true;
            int num = 0;
            while (erd == true)
            {
                Console.WriteLine("enter 1 for add kala");
                Console.WriteLine("enter 2 for exit");

                num = Convert.ToInt32(Console.ReadLine());
                if (num == 1)
                {
                    AddSoldKala();
                }
                else if (num == 2)
                {
                    erd = false;
                }
            }
        }
        public ChekInfo chek()
        {
            ChekInfo frt = new ChekInfo();
            //مالک چک
            Console.WriteLine("Chek owner:  ");
            frt.ChekOwner = Console.ReadLine();
            //در وجه
            Console.WriteLine("pay to: ");
            frt.PayTo = Console.ReadLine();
            //قیمت چک
            Console.WriteLine("price Chek: ");
            frt.PriceChek = getInt();
            //شماره سریال چک
            Console.WriteLine("serial number chek: ");
            frt.SerialNumber = getInt();
            //تاریخ چک
            Console.WriteLine("date: ");
            frt.date = getInt();

            return frt;



        }
        public void AddChek()
        {
            chekList.Add(chek());
        }
        public void ChekMenu()
        {
            bool fsd = true;
            int num = 0;
            while (fsd == true)
            {


                Console.WriteLine("enter 1 for add chek");
                Console.WriteLine("enter 2 for exit");

                num = Convert.ToInt32(Console.ReadLine());

                if (num == 1)
                {
                    AddChek();
                }
                if (num == 2)
                {
                    fsd = false;
                }
            }

        }
        public void c()
        {
            int readNum = 0;
            bool flag = true;
            while (flag == true)
            {


                Console.WriteLine("enter 1 for insert kala");
                Console.WriteLine("enter 2  for sort kala");
                Console.WriteLine("enter 3  for Show list kala");
                Console.WriteLine("enrer 4 for sort kala2");
                Console.WriteLine("enter 5  for expensive kala");
                Console.WriteLine("enter 6 for Chepeer kala");
                Console.WriteLine("enter 7 for price kala & count kala");
                Console.WriteLine("enter 8 for add sold kala");
                Console.WriteLine("enter 9 for Show List sales");
                Console.WriteLine("enter 10 for add chek");
                Console.WriteLine("enter 11 for exit");

                readNum = Convert.ToInt32(Console.ReadLine());

                
                if (readNum == 1)
                {
                    addKala();
                }
                else if (readNum == 2)
                {
                    sortKala();
                }
                else if (readNum == 3)
                {
                    ShowListKala();
                }
                else if (readNum == 4)
                {
                    sortKala2();
                }
                else if (readNum == 5)
                {
                    Expensive();
                }
                else if (readNum == 6)
                {
                    chepeer();
                }
                else if (readNum == 7)
                {
                    sun();
                }
                else if (readNum == 8)
                {
                    SellMenu();
                }
                else if (readNum == 9)
                {
                    ShowListSales();
                }
                else if (readNum == 10)
                {
                    ChekMenu();
                }
                else if (readNum == 11)
                {
                    Income();
                }
            }

        }
        public void Income()
        {
            SoldItem sold = new SoldItem();
            infoKala kal = new infoKala();
            int Incom = 0;


            Incom = sold.price * sold.count;
            Console.WriteLine("in" + sold.SaleDate + "Income: " + Incom);

        }
        public void addStore( ref infoKala kala)
        {
           

            int readName = 0;
            int pass1 = 0;
            kala.stotre = 0;

            bool xrp = true;

            while (xrp)
            {
                Console.WriteLine("for add to store1 enter 1");
                Console.WriteLine("for add to store2 enter 2");
                readName = Convert.ToInt32(Console.ReadLine());

                pass1 = readName;



                if (pass1 == 1)
                {
                    store1.Add(kala);
                    xrp = false;
                    kala.stotre = 1;
                }
                else if (pass1 == 2)
                {
                    store2.Add(kala);
                    xrp = false;
                    kala.stotre = 2;

                }
                else
                {
                    Console.WriteLine("enrer the correct number");
                }


        }    
            }
            public void fileInfo(infoKala kala)
            {
            
            String fld = @"G:\listInfo";

            System.IO.Directory.CreateDirectory(fld);
            if(System.IO.Directory.Exists(fld))
            {
                
                TextWriter tw = new StreamWriter(@"G:\listInfo\info.Txt",true);
                    tw.WriteLine(print(kala));
                tw.Close();


            }

            }

        public void reader()
        {
            if (System.IO.File.Exists(@"G:\listInfo\info.Txt"))
            {
                System.IO.File.ReadAllLines(@"G:\listInfo\info.Txt");

                foreach (string s in System.IO.File.ReadAllLines(@"G:\listInfo\info.Txt"))
                {
                    s.IndexOf("name:");
                    s.IndexOf("info Kala:");
                    infoKala kala = new infoKala();

                    string a = s.Substring(s.IndexOf("name:") + "name:".Length, s.IndexOf("info Kala:") - (s.IndexOf("name:") + "name:".Length));
                    kala.name = a;
                    string b = s.Substring(s.IndexOf("info Kala:") + "info Kala:".Length, s.IndexOf("price kala:") - (s.IndexOf("info Kala:") + "info Kala:".Length));
                    kala.info = b;
                    string c = s.Substring(s.IndexOf("price kala:") + "price kala:".Length, s.IndexOf("count kala: ") - (s.IndexOf("price kala:") + "price kala:".Length));
                    int c2 = Convert.ToInt32(c);
                    kala.price = c2;
                   string d = s.Substring(s.IndexOf("count kala:") + "count kala:".Length, s.IndexOf("store:") - (s.IndexOf("count kala:") + "count kala:".Length));
                    int d2 = Convert.ToInt32(d);
                    
                    kala.count = d2;
                    Console.WriteLine("name:" + a + "  info:" + b+"  price:  "+c2+"  count:  "+d2+"   store: "+kala.stotre);


                    ListKala.Add(kala);


                }


             }
        }
        public void fileSale(SoldItem kala)
        {
            System.IO.Directory.CreateDirectory(@"G:\listSale");
            if(System.IO.Directory.Exists(@"G:\listSale"))
            {
                TextWriter tw = new StreamWriter(@"G:\listSale\sold.Txt", true);
                   tw.WriteLine(printSold(kala));
                tw.Close();

            }

        }
    
    }



}  


 

           
        


        


    
 

    
