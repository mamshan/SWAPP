using Microsoft.EntityFrameworkCore;

namespace SWAPP.Entities
{  
public class DepositMaster
{
    public int id { get; set; }

    public DateOnly? sdate { get; set; }  
    public string refno { get; set; } = string.Empty;

    public string? flag { get; set;}

    public double? bankCharge { get; set;}
    public double? bankChargeAmt { get; set;}
    public double? amount { get; set;}

    public string? department { get; set; }

    public string? dep_bank { get; set; }

public string? dele_no { get; set; }


    public List<DepositTran> DepositTrans { get;set; }  
}

// Dependent (child)
public class DepositTran
{
    public int id { get; set; }

    public string pdno { get; set; }
public string refno { get; set; }

    public double amount { get; set; }
public string? department { get; set; }
    public int depositid { get; set; } // Required foreign key property

     public DateOnly? st_date { get; set; } // Required foreign key property
    public string? dele_no { get; set; } // Required foreign key property

    public DepositMaster DepositMaster { get; set; } = null; // Required reference navigation to principal
}



public class Settlment
{
    public int id { get; set; }

    public DateOnly? ca_date { get; set; }  
    public string ca_refno { get; set; } = string.Empty;

    public string pay_type { get; set; } = string.Empty;
 
    public string company { get; set; } 

    public List<SettlmentTran> SettlmentTrans { get;set; }  
}

// Dependent (child)
public class SettlmentTran
{
    public int id { get; set; }

    public string st_refno { get; set; }

    public double st_paid { get; set; }
    public DateOnly st_date { get; set; }

    
    public  string? settled_no { get; set; }
    public  string? st_chno { get; set; }

 public  string? company { get; set; }

    public int? settlmentid { get; set; } // Required foreign key property
    public Settlment Settlment { get; set; } = null; // Required reference navigation to principal
}



public class CardTran
{
    public int? id { get; set; }

    public int? selected { get; set; }
    public string? pdno { get; set; }
public string? invno { get; set; }

    
    public double? amount { get; set; }
    public DateOnly? st_date { get; set; }

    
    public  string? settled_no { get; set; }
    public  string? st_chno { get; set; }

 public  string? company { get; set; }
public  string? ord_no { get; set; }

  public  string? dele_no { get; set; }

}



public class CardTranDt
{
 public string? st_date { get; set; }
}
 
 



}