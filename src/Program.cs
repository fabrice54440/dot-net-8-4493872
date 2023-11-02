using System;
using System.IO;

namespace TypeDyn;

class Program
{
    static void Main(string[] args)
    {
        Csv csv = new(new StringReader(EXEMPLE));

        foreach (dynamic ligne in csv.Lignes)
        {
            Console.WriteLine($"{ligne.Id} {ligne.Prénom} {ligne.Nom} ({ligne.Courriel})");
        }
    }

    const string EXEMPLE = """ 
    Id;Prénom;Nom;Courriel;Newsletter
    1;Thomasine;Arkill;tarkill0@europa.eu;0
    2;Ruggiero;Sodory;rsodory1@printfriendly.com;1
    3;Joseph;Gunter;jgunter2@auda.org.au;1
    4;Kora;Peedell;kpeedell3@state.gov;0
    5;Brittany;Eatttok;beatttok4@cnbc.com;0
    6;Lucine;Brownlie;lbrownlie5@webs.com;1
    7;Bendicty;Amort;bamort6@simplemachines.org;0
    8;Eilis;Truss;etruss7@networkadvertising.org;1
    9;Roda;Hogbin;rhogbin8@acquirethisname.com;1
    10;Deni;Neary;dneary9@senate.gov;1
    11;Stephanus;Keune;skeunea@newyorker.com;0
    12;Ferdinande;Kraft;fkraftb@slate.com;0
    13;Amalea;Borwick;aborwickc@nature.com;0
    14;Bryanty;Plan;bpland@loc.gov;0
    15;Susi;Battleson;sbattlesone@japanpost.jp;1
    16;Nickolaus;Doeg;ndoegf@smh.com.au;0
    17;Erinn;Janusz;ejanuszg@vinaora.com;1
    18;Noam;Christin;nchristinh@xrea.com;1
    19;Wain;Hannent;whannenti@illinois.edu;0
    20;Orville;Jefford;ojeffordj@desdev.cn;0
    21;Ginelle;Edgeler;gedgelerk@blinklist.com;0
    22;Floyd;Disman;fdismanl@acquirethisname.com;1
    23;Consuela;Richardes;crichardesm@nsw.gov.au;1
    24;Dalt;Upstell;dupstelln@microsoft.com;1
    25;Jasun;Simmgen;jsimmgeno@walmart.com;0
    26;Amble;MacAlpyne;amacalpynep@prweb.com;1
    27;Andrew;Yosifov;ayosifovq@homestead.com;0
    28;Arri;Beston;abestonr@utexas.edu;0
    29;Hildagarde;Gook;hgooks@boston.com;1
    30;Dalia;Sherington;dsheringtont@bizjournals.com;0
    31;Thaine;Wooffitt;twooffittu@ameblo.jp;1
    32;Genevra;Valentin;gvalentinv@hud.gov;1
    33;Brinna;Belward;bbelwardw@princeton.edu;1
    34;Ulrica;Tumioto;utumiotox@phpbb.com;0
    35;Bobbe;Burke;bburkey@hubpages.com;1
    36;Bartolomeo;Alexandrou;balexandrouz@ask.com;1
    37;Hanson;Londer;hlonder10@cbc.ca;0
    39;Reeva;Gerdes;rgerdes12@admin.ch;0
    40;Dinny;Adan;dadan13@rediff.com;0
    41;Bonnie;Hamshaw;bhamshaw14@youtube.com;0
    42;Troy;Stachini;tstachini15@chronoengine.com;1
    43;Lynn;Lennox;llennox16@state.tx.us;1
    44;Ethan;Foro;eforo17@cam.ac.uk;1
    45;Evonne;Stoppe;estoppe18@redcross.org;0
    46;Vivie;Moodie;vmoodie19@networksolutions.com;0
    47;Enrique;Strangward;estrangward1a@irs.gov;0
    48;Phylis;Wakenshaw;pwakenshaw1b@google.com.au;1
    49;Doralin;Bridgstock;dbridgstock1c@howstuffworks.com;1
    50;Reuben;Seeking;rseeking1d@china.com.cn;1
    """;
}
