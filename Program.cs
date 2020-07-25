using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Pemrograman_Interface
//{
public interface IMesinCuci
{
    void SetCuciTimer(Timer timer);
    void SetInput(params Baju[] bajus);
    void SetSabun(Sabun sabun);
    void Cuci();
    void SetKeringkanTimer(Timer timer);
    void Keringkan();
    Baju[] GetBaju();
}
public class Timer
{
    public Timer(int val)
    {
        _timer = val;
    }
    public int Value
    {
        get { return _timer; }
    }
    private int _timer;
}
public class Baju
{
    public Baju(string name)
    {
        _name = name;
    }
    public string Name
    {
        get { return _name; }
    }
    private string _name;
    public override string ToString()
    {
        return "Test" + _name;
    }
}

public class Sabun
{
    public Sabun(string name)
    {
        _name = name;
    }
    public string Name
    {
        get { return _name; }
    }
    private string _name;
}



public class MCMerekRahman : IMesinCuci
{
    private string _name;
    private Timer _cuciTimer;
    private Timer _keringkanTimer;
    private Baju[] _drum;
    private Sabun _sabun;
    public MCMerekRahman()
    {
        _name = "Rahman Washing Machine";
    }
    public string Name
    {
        get { return this._name; }
    }
    #region implementasi IMesinCuci
    public void SetCuciTimer(Timer timer)
    {
        if (timer.Value < 0 || timer.Value > 10) timer = new Timer(10);
        _cuciTimer = timer;
    }
    public void SetKeringkanTimer(Timer timer)
    {
        if (timer.Value < 0 || timer.Value > 5) timer = new Timer(5);
        _keringkanTimer = timer;
    }
    public void SetInput(params Baju[] bajus)
    {
        _drum = bajus;
    }
    public void SetSabun(Sabun sabun)
    {
        _sabun = sabun;
    }
    public void Cuci()
    {
        Console.WriteLine("Anda Sedang Menggunakan {0} ", this.Name);
        Console.WriteLine();
        Console.WriteLine("Sedot air..........");
        Console.WriteLine("Masukan sabun {0} ", _sabun.Name);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("MULAI MENCUCI");
        for (int i = 1; i <= _cuciTimer.Value; i++)
        {
            Console.WriteLine("Putar ke {0} ke kanan", i);
            Console.WriteLine("Putar ke {0} ke kiri", i);
            Console.WriteLine("Putar ke {0} sedot ke bawah", i);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Mencuci selesai");
        Console.WriteLine("Keluarkan Air");
        Console.WriteLine("Masukkan Air");
        Console.WriteLine("Putar Kembali");
        Console.WriteLine("Keluarkan Air");
    }
    public void Keringkan()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("MULAI MENGERINGKAN");
        for (int i = 1; i <= _keringkanTimer.Value; i++)
        {
            Console.WriteLine("Putar dengan kecepatan {0} ", i);
        }
        Console.WriteLine("Pengeringan selesai");
    }
    public Baju[] GetBaju()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Buka penutup");
        for (int i = 0; i < _drum.Length; i++)
        {
            //Baju b =_drum[i] as Baju;
            Console.WriteLine("Keluarkan {0}", _drum[i].Name);
        }
        Console.WriteLine("Kembalikan Penutup");
        Console.WriteLine();
        Console.WriteLine("Terima kasih anda telah menggunakan {0}", this.Name);
        return _drum;
    }
    #endregion
}

public class Pembantu
{
    private string _name;
    private object[] _keranjang;
    public Pembantu(string name)
    {
        _name = name;
    }
    public string Name
    {
        get { return _name; }
    }
    public void Mencuci(IMesinCuci mc, Sabun sabun, params Baju[] bajus)
    {
        mc.SetSabun(sabun);
        mc.SetInput(bajus);
        mc.SetCuciTimer(new Timer(20));
        mc.Cuci();
        mc.SetKeringkanTimer(new Timer(15));
        mc.Keringkan();
        _keranjang = mc.GetBaju();
    }
    public void Menjemur()
    {
        Console.WriteLine();
        Console.WriteLine("{0} menjemur baju sebanyak {1} buah.", this.Name, _keranjang.Length);
        foreach (Baju b in _keranjang)
        {
            Console.WriteLine("---Menjemur {0}...", b.Name);
        }
        Console.WriteLine("Selesai menjemur");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        MCMerekRahman mcr = new MCMerekRahman();
        Baju celana = new Baju("Celana");
        Baju kaos = new Baju("kaos");
        Baju hem = new Baju("hem");
        Baju celdam = new Baju("celdam");
        Baju kaoskaki = new Baju("Kaos Kaki");
        Baju kutang = new Baju("Kutang");
        Sabun rinso = new Sabun("Rinso");
        Pembantu inem = new Pembantu("Inem");        
        Sabun attack = new Sabun("Attack+B29");
        Console.WriteLine();
        inem.Mencuci(mcr, attack, celana, kaos, hem);
        Console.WriteLine();
        inem.Menjemur();
        Console.ReadKey();
    }

}

//}
