using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCap_nte_framework_
{
    class Alekseev
    {
        public string OpenBrov = "";
        public string Open = "";
        public string Close = "";
        public void quest(string str, Alekseev alex)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            string output = "";
            this.initOpen();
            this.initClose();
            this.initOpenBrov();
            int i = 0;
            while (output.Length != str.Length)
            {
                System.Threading.Thread.Sleep(70);
                this.paintAlekseev();
                Console.SetCursorPosition(0, 0);
                if (i % 6 == 0) //моргнул
                {
                    this.paintAleksZakroiBrov();
                    Console.SetCursorPosition(0, 0);
                    System.Threading.Thread.Sleep(70);
                }
                if (i % 8 == 0) //моргнул
                {
                    this.paintAleksZakroiBrov();
                    Console.SetCursorPosition(0, 0);
                    System.Threading.Thread.Sleep(90);
                }
                if (i % 4 == 0 || i % 7 == 0)
                    System.Threading.Thread.Sleep(200);
                this.paintAlekseev();
                Console.SetCursorPosition(5, 45);
                output += str[i];
                Console.WriteLine("\n");
                Console.WriteLine(output);
                Console.SetCursorPosition(0, 0);
                ++i;
            }
            Menu menu = new Menu();
            while (true)
            {
                alex.paintAlekseev();
                Console.WriteLine();
                Console.SetCursorPosition(0, 47);
                Console.WriteLine(str + " \n"); //pashuk
                string str0 = menu.drawMenu("suka", "suka", "suka", 49);
            }
        }
        public void initOpenBrov()
        {
            OpenBrov += "@@@@@#@@@@@@@@@@#@@@@@#%===@#=++++++++@###==++++++*=%+**%%=========%%%%%===%%++++++";
            OpenBrov += "#@@#####@@@@@######@#@@@@@#@%%*++++++@###==++++++++%++*%%%@%======%%========+*++++*";
            OpenBrov += "####@#@@########@#######@@@@@=+*+++++=+====++++++++=*+*%%@#@@=====%%%%%=====++++++*";
            OpenBrov += "############@@#@@#######@##@@@@%=++===@%%%==%%=+++%@+**%%##@@=====%=%%======++++++*";
            OpenBrov += "################@######@@@%=+=@@%%==%%%@=====%@========%%%%%=%%%%%=====++=@=+++++++";
            OpenBrov += "######################@====%%%%=%@@%%======%%%%%@%%@%==%%==%=*=%%========++%%*=%=*+";
            OpenBrov += "##################@#@%=%%%%%==%@@%===%%%@@%%%%%%%%%%@@%%%=%@@%%@%%==%%%%%@#####@@@=";
            OpenBrov += "###############@#@===%%=%==%%@@%%@@@%%%%==%%@@@@@@%%@@%%@@%%@@@@@%@@%%%@@%%%@@@@@@=";
            OpenBrov += "################=%%%%%=%%=%@@%%%=%@%%@@#@@@@%@@@@%%%@%%%%@@@@@@#%%%%%%%%%@%%@@@@@@=";
            OpenBrov += "###########@##==%%%%===%%@%%%=%@@@@@@@@@@@@@@@@%%%@@@@%%%%%%%%%%%%%%%%%%%%%%==@@@@=";
            OpenBrov += "########@@##==%%%===%%%%%%%@@@@@@@@#@@@@@@@@@@@@@%%%%%======%%%%@%%%%======%%%%%@@=";
            OpenBrov += "@@@@#@@@@#==%%@%==%@%%@@@%%@@@@@@@@@@%%@@@%%%%%%%%====+++++++===%%%@@@@%====%@@@@@%";
            OpenBrov += "@@@@@@@#%%%%%%==+=%@%%%%%%@@%@%%%%%%%%%%%%%%%%%===++++++++++++++=%%@%%%%%%==+=====+";
            OpenBrov += "######===%%%%=====%%%%%%%@%%%========%%==========+++++++++**++++++==%@%%=%%=%===%%+";
            OpenBrov += "#@##%%%%%%%%+++++==%%===%%===++============+++++=++*****++***+*+++++=%%%%%%%==%===+";
            OpenBrov += "@%==%%%%%@% +****+++= ++++== +++++==== ++++++++++++++= +********+*****+++==%%%%%%%%";
            OpenBrov += "===%%%%%%% ++******++++****++*+++++++++++++++*++++++*+**+******+***++==%%@@%%%%%===";
            OpenBrov += "=%%%%%%@%= ++******+++*****++*+*++++++++++**+++++++++++++++++++****++==%%%@@%%%%%%=";
            OpenBrov += "+=%%%@@%== ++++++++++++++++++++++++++++++*++++++++++++++++++++*++++++==%%%@@@%%%%=@";
            OpenBrov += ":*+%%@%%== ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++==%%@@@@%%%%%%";
            OpenBrov += "::%%%%%%%== +++++++++++++++++++++++++++++++++++++++++++++++++++++++++===%@@@@%%%%@@";
            OpenBrov += "*+%%%%%%%== +++++++++++++++++++++++++++++++++++++++++++++++++++++++++==%%@@@@%%%=%#";
            OpenBrov += "@%%%%%%%%%== ++++++++++++++++++++++++++++++++++++++++++++++++++++= ++===%%@@@@%%%%@";
            OpenBrov += "@@%%%%%%%%== +++++++++++++**********+***********+**+++++++++++++++++===%%@@@@@@%%%@";
            OpenBrov += "@@%%%%@@%== ++++++++++++++++*++******************++++++++++++++++++====%%@@@@@@%%=@";
            OpenBrov += "=%%%%%@@%== +++++++++++++++++++++++******+++++++++%%%%%%%%%*+++++++++===%%@@@@@@@@@";
            OpenBrov += "+%%%%%@@%== ++++++++***+++++++++++++++++++++++++===+++++++++%%**++++=====%%@@@@@@##";
            OpenBrov += "=+=%%%@@=== +++++++++=+=========== +++++=+==================== +++++++====%%@@@@@@#";
            OpenBrov += "@%=%%%%%=== +++++===%%@@@@@@@%%%============%%%%@@@@@@@@%%%%%%===========%@@@@@@##%";
            OpenBrov += "%%%%@%%@== ++++===%%%%%%%%@@@%%%%%=========%%%@@@@@@%%====%%%%%%=========%@@@@@=+==";
            OpenBrov += "= +*%@@@%= +++===%%=====%@%%%%%%%%%%===+====%%@@@%%%%%%%%%%%%%%%%%========%@@@@@==@";
            OpenBrov += "+++=%@@%= +++==%%%%%= ++++==%%@@@@%%= +++++==%@@@@@%%%%%%@%=+==%%%%========%@@@%%%+";
            OpenBrov += "=@==%%@%=+=+===%%==%@@#####@@@@@@%=+++*++=%@@@@@@@######@@@%%%%====+++==%@@%%===%@=";
            OpenBrov += "%%%==%@@= ++++===%%@%%=@####%%@@%=%%+****+=%%=%@%%%=####%%%=========++++=%@%=+==%%@";
            OpenBrov += "@@%===%@= +++++============%%%%%=%== +****++=%%%%%%@%%%%%%%======== +++++++=@@@@%=@";
            OpenBrov += "@@@==%%%= ++++++++++==%%%%%%%%%===== +****++====%=====%%%%%===== +++++++++==%@@@%==";
            OpenBrov += "@@#=%%%%=++++++++++=========%====+++****++========%=======++++++++++++====%%%%=%@@=";
            OpenBrov += "=%%==%%%= ++++++++++==+======= +++++++****+++++++++++======== +++++++++++=====@%==%";
            OpenBrov += "%%%%==%%== ++++++++++++++++++++++++++*****++++++++++++++++++++++++++++====== ++==%%";
            OpenBrov += "@@%@% +*=== +++++++++++++++++++++++++*******++++++++++++++++++++++++======== +++*%@";
            OpenBrov += "@@@@% ++++=== +++++++++++++++++++++++*****+**+==== ++++++++++++++++++======%%%===@@";
            OpenBrov += "#@@#=+++====++++++++++++++++++++++++++++++++++======+++++++++++++======%%===%@##@#%";
            OpenBrov += "#@##@========+++++++++++++++===++============+=%%=========++++++=======%@@@@#@@@@@=";
            OpenBrov += "######@%%@=======================%%%%%%%%%%@%%=%===%%=================%%@##@@####@=";
            OpenBrov += "##########%=====================%@##@%@@@@@@@@%=====%%%%====%========%%%%@#@@@####=";
            OpenBrov += "##########@================++++==%@%@@@@@@%%%========%%%%%%%%%%%%=====@#@@#@%%%@@@=";
            OpenBrov += "###########=%=============++++++===%%%@@%%%==========%%%@%%%=%%%%%%==%@@@@@@##@#@#%";
            OpenBrov += "###########%==========%%==++++++=====%%%%%===========%%%@@@%%%%%%%%%%%@###@%#####@%";
            OpenBrov += "#########@##=========%%%%====================+++=====%%@@@@%%%%%%%%%%@###@##@####@%";
            OpenBrov += "@###########=%=======%@@%====++++===%%===%%@@%%@@@@@##@%%%%%%%%%%%%%%@@@@#########%";
            OpenBrov += "############%=========%%%@##@@@@@@@@@@@@@@@@@##@@%%%=%%%%%%%%%%%%%%%@##########@@#%";
            OpenBrov += "#############%%========%=====%%=======%%%%=====%%%%%%%%%%%%%%%%%%%%%##############%";
            OpenBrov += "##############%%%===%%============================%=====%%%%%%%%%%%@##############%";
            OpenBrov += "##############@%%%%%%%===============================%%%%%%%%%%%%%%###############%";
            OpenBrov += "@@%@@@@@##@@#@@@%%%%%%===============================%%%%%%%%%%%%%@########@######%";
            OpenBrov += "#@@%%%==@%%#####%%%%%%%=======%%%%%%%%%%%%%%%%%%%===%%%%%%%%%%%%%%################%";
            OpenBrov += "#@#@@%==######@#===%%%%%%=======%%%%@@@@@@@@%%%%%==%%%%%@@%%%%%%==+%##############%";
            OpenBrov += "#####@%%####@=+:+==%%@%%%%===+=====%%%%%%%%%=======%%%%@@@@@@@%%==+**=@###########%";
            OpenBrov += "###########@+@%@%+=%%%@@@%%%%====================%%%%@@@@@@@@%%%=%##@=:-+#########=";
            OpenBrov += "#########%*=+--==+==%%%@@@@@%%%%=====%%%%%%%%%%%%%%%@@@@@@@@%%%%%==@@@##%*:=#####@=";
            OpenBrov += "######@++:%:%=%#=====%%@@@@@@@@@%%%%@%%@@@@%%@@@@@@@@@@@@@@%%%%%==##@==@##%++#####=";
            OpenBrov += "##@==:*=%%*=*-+#%====%%%%@@@@###@@@@@@@@@@@@@@@@@@@##@@@@@@%%%%%%=@####@++#@:.@##@=";
            OpenBrov += "+%% *+@@%:-+= ++##@=====%%%%@@@@@@####################@@@@@@%@%%%%==+=####%@%@#=*#@";
            OpenBrov += "#*=@=+@%+=#*=+##@%====%%%%%%%@@@@@@#############@@@@@@@@@%%%%%%%%===@##@##%%#%*=#@=";
        }
        public void initOpen()
        {
            Open += "@@@@@#@@@@@@@@@@#@@@@@#%===@#=++++++++@###==++++++*=%+**%%=========%%%%%===%%++++++";
            Open += "#@@#####@@@@@######@#@@@@@#@%%*++++++@###==++++++++%++*%%%@%======%%========+*++++*";
            Open += "####@#@@########@#######@@@@@=+*+++++=+====++++++++=*+*%%@#@@=====%%%%%=====++++++*";
            Open += "############@@#@@#######@##@@@@%=++===@%%%==%%=+++%@+**%%##@@=====%=%%======++++++*";
            Open += "################@######@@@%=+=@@%%==%%%@=====%@========%%%%%=%%%%%=====++=@=+++++++";
            Open += "######################@====%%%%=%@@%%======%%%%%@%%@%==%%==%=*=%%========++%%*=%=*+";
            Open += "##################@#@%=%%%%%==%@@%===%%%@@%%%%%%%%%%@@%%%=%@@%%@%%==%%%%%@#####@@@=";
            Open += "###############@#@===%%=%==%%@@%%@@@%%%%==%%@@@@@@%%@@%%@@%%@@@@@%@@%%%@@%%%@@@@@@=";
            Open += "################=%%%%%=%%=%@@%%%=%@%%@@#@@@@%@@@@%%%@%%%%@@@@@@#%%%%%%%%%@%%@@@@@@=";
            Open += "###########@##==%%%%===%%@%%%=%@@@@@@@@@@@@@@@@%%%@@@@%%%%%%%%%%%%%%%%%%%%%%==@@@@=";
            Open += "########@@##==%%%===%%%%%%%@@@@@@@@#@@@@@@@@@@@@@%%%%%======%%%%@%%%%======%%%%%@@=";
            Open += "@@@@#@@@@#==%%@%==%@%%@@@%%@@@@@@@@@@%%@@@%%%%%%%%====+++++++===%%%@@@@%====%@@@@@%";
            Open += "@@@@@@@#%%%%%%==+=%@%%%%%%@@%@%%%%%%%%%%%%%%%%%===++++++++++++++=%%@%%%%%%==+=====+";
            Open += "######===%%%%=====%%%%%%%@%%%========%%==========+++++++++**++++++==%@%%=%%=%===%%+";
            Open += "#@##%%%%%%%%+++++==%%===%%===++============+++++=++*****++***+*+++++=%%%%%%%==%===+";
            Open += "@%==%%%%%@% +****+++= ++++== +++++==== ++++++++++++++= +********+*****+++==%%%%%%%%";
            Open += "===%%%%%%% ++******++++****++*+++++++++++++++*++++++*+**+******+***++==%%@@%%%%%===";
            Open += "=%%%%%%@%= ++******+++*****++*+*++++++++++**+++++++++++++++++++****++==%%%@@%%%%%%=";
            Open += "+=%%%@@%== ++++++++++++++++++++++++++++++*++++++++++++++++++++*++++++==%%%@@@%%%%=@";
            Open += ":*+%%@%%== ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++==%%@@@@%%%%%%";
            Open += "::%%%%%%%== +++++++++++++++++++++++++++++++++++++++++++++++++++++++++===%@@@@%%%%@@";
            Open += "*+%%%%%%%== +++++++++++++++++++++++++++++++++++++++++++++++++++++++++==%%@@@@%%%=%#";
            Open += "@%%%%%%%%%== ++++++++++++++++++++++++++++++++++++++++++++++++++++= ++===%%@@@@%%%%@";
            Open += "@@%%%%%%%%== +++++++++++++**********+***********+**+++++++++++++++++===%%@@@@@@%%%@";
            Open += "@@%%%%@@%== ++++++++++++++++*++******************++++++++++++++++++====%%@@@@@@%%=@";
            Open += "=%%%%%@@%== +++++++++++++++++++++++******+++++++++++++++****+++++++++===%%@@@@@@@@@";
            Open += "+%%%%%@@%== ++++++++***+++++++++++++++++++++++++=== ++++++++++**++++=====%%@@@@@@##";
            Open += "=+=%%%@@=== +++++++++=+=========== +++++=+========%%%%%%%===== +++++++====%%@@@@@@#";
            Open += "@%=%%%%%=== +++++===%%@@@@@@@%%%============%%%%@@@@@@@@%%%%%%===========%@@@@@@##%";
            Open += "%%%%@%%@== ++++===%%%%%%%%@@@%%%%%=========%%%@@@@@@%%====%%%%%%=========%@@@@@=+==";
            Open += "= +*%@@@%= +++===%%=====%@%%%%%%%%%%===+====%%@@@%%%%%%%%%%%%%%%%%========%@@@@@==@";
            Open += "+++=%@@%= +++==%%%%%= ++++==%%@@@@%%= +++++==%@@@@@%%%%%%@%=+==%%%%========%@@@%%%+";
            Open += "=@==%%@%=+=+===%%==%@@#####@@@@@@%=+++*++=%@@@@@@@######@@@%%%%====+++==%@@%%===%@=";
            Open += "%%%==%@@= ++++===%%@%%=@####%%@@%=%%+****+=%%=%@%%%=####%%%=========++++=%@%=+==%%@";
            Open += "@@%===%@= +++++============%%%%%=%== +****++=%%%%%%@%%%%%%%======== +++++++=@@@@%=@";
            Open += "@@@==%%%= ++++++++++==%%%%%%%%%===== +****++====%=====%%%%%===== +++++++++==%@@@%==";
            Open += "@@#=%%%%=++++++++++=========%====+++****++========%=======++++++++++++====%%%%=%@@=";
            Open += "=%%==%%%= ++++++++++==+======= +++++++****+++++++++++======== +++++++++++=====@%==%";
            Open += "%%%%==%%== ++++++++++++++++++++++++++*****++++++++++++++++++++++++++++====== ++==%%";
            Open += "@@%@% +*=== +++++++++++++++++++++++++*******++++++++++++++++++++++++======== +++*%@";
            Open += "@@@@% ++++=== +++++++++++++++++++++++*****+**+==== ++++++++++++++++++======%%%===@@";
            Open += "#@@#=+++====++++++++++++++++++++++++++++++++++======+++++++++++++======%%===%@##@#%";
            Open += "#@##@========+++++++++++++++===++============+=%%=========++++++=======%@@@@#@@@@@=";
            Open += "######@%%@=======================%%%%%%%%%%@%%=%===%%=================%%@##@@####@=";
            Open += "##########%=====================%@##@%@@@@@@@@%=====%%%%====%========%%%%@#@@@####=";
            Open += "##########@================++++==%@%@@@@@@%%%========%%%%%%%%%%%%=====@#@@#@%%%@@@=";
            Open += "###########=%=============++++++===%%%@@%%%==========%%%@%%%=%%%%%%==%@@@@@@##@#@#%";
            Open += "###########%==========%%==++++++=====%%%%%===========%%%@@@%%%%%%%%%%%@###@%#####@%";
            Open += "#########@##=========%%%%====================+++=====%%@@@@%%%%%%%%%%@###@##@####@%";
            Open += "@###########=%=======%@@%====++++===%%===%%@@%%@@@@@##@%%%%%%%%%%%%%%@@@@#########%";
            Open += "############%=========%%%@##@@@@@@@@@@@@@@@@@##@@%%%=%%%%%%%%%%%%%%%@##########@@#%";
            Open += "#############%%========%=====%%=======%%%%=====%%%%%%%%%%%%%%%%%%%%%##############%";
            Open += "##############%%%===%%============================%=====%%%%%%%%%%%@##############%";
            Open += "##############@%%%%%%%===============================%%%%%%%%%%%%%%###############%";
            Open += "@@%@@@@@##@@#@@@%%%%%%===============================%%%%%%%%%%%%%@########@######%";
            Open += "#@@%%%==@%%#####%%%%%%%=======%%%%%%%%%%%%%%%%%%%===%%%%%%%%%%%%%%################%";
            Open += "#@#@@%==######@#===%%%%%%=======%%%%@@@@@@@@%%%%%==%%%%%@@%%%%%%==+%##############%";
            Open += "#####@%%####@=+:+==%%@%%%%===+=====%%%%%%%%%=======%%%%@@@@@@@%%==+**=@###########%";
            Open += "###########@+@%@%+=%%%@@@%%%%====================%%%%@@@@@@@@%%%=%##@=:-+#########=";
            Open += "#########%*=+--==+==%%%@@@@@%%%%=====%%%%%%%%%%%%%%%@@@@@@@@%%%%%==@@@##%*:=#####@=";
            Open += "######@++:%:%=%#=====%%@@@@@@@@@%%%%@%%@@@@%%@@@@@@@@@@@@@@%%%%%==##@==@##%++#####=";
            Open += "##@==:*=%%*=*-+#%====%%%%@@@@###@@@@@@@@@@@@@@@@@@@##@@@@@@%%%%%%=@####@++#@:.@##@=";
            Open += "+%% *+@@%:-+= ++##@=====%%%%@@@@@@####################@@@@@@%@%%%%==+=####%@%@#=*#@";
            Open += "#*=@=+@%+=#*=+##@%====%%%%%%%@@@@@@#############@@@@@@@@@%%%%%%%%===@##@##%%#%*=#@=";
        }

        public void initClose()
        {
            Close += "@@@@@#@@@@@@@@@@#@@@@@#%===@#=++++++++@###==++++++*=%+**%%=========%%%%%===%%++++++";
            Close += "#@@#####@@@@@######@#@@@@@#@%%*++++++@###==++++++++%++*%%%@%======%%========+*++++*";
            Close += "####@#@@########@#######@@@@@=+*+++++=+====++++++++=*+*%%@#@@=====%%%%%=====++++++*";
            Close += "############@@#@@#######@##@@@@%=++===@%%%==%%=+++%@+**%%##@@=====%=%%======++++++*";
            Close += "################@######@@@%=+=@@%%==%%%@=====%@========%%%%%=%%%%%=====++=@=+++++++";
            Close += "######################@====%%%%=%@@%%======%%%%%@%%@%==%%==%=*=%%========++%%*=%=*+";
            Close += "##################@#@%=%%%%%==%@@%===%%%@@%%%%%%%%%%@@%%%=%@@%%@%%==%%%%%@#####@@@=";
            Close += "###############@#@===%%=%==%%@@%%@@@%%%%==%%@@@@@@%%@@%%@@%%@@@@@%@@%%%@@%%%@@@@@@=";
            Close += "################=%%%%%=%%=%@@%%%=%@%%@@#@@@@%@@@@%%%@%%%%@@@@@@#%%%%%%%%%@%%@@@@@@=";
            Close += "###########@##==%%%%===%%@%%%=%@@@@@@@@@@@@@@@@%%%@@@@%%%%%%%%%%%%%%%%%%%%%%==@@@@=";
            Close += "########@@##==%%%===%%%%%%%@@@@@@@@#@@@@@@@@@@@@@%%%%%======%%%%@%%%%======%%%%%@@=";
            Close += "@@@@#@@@@#==%%@%==%@%%@@@%%@@@@@@@@@@%%@@@%%%%%%%%====+++++++===%%%@@@@%====%@@@@@%";
            Close += "@@@@@@@#%%%%%%==+=%@%%%%%%@@%@%%%%%%%%%%%%%%%%%===++++++++++++++=%%@%%%%%%==+=====+";
            Close += "######===%%%%=====%%%%%%%@%%%========%%==========+++++++++**++++++==%@%%=%%=%===%%+";
            Close += "#@##%%%%%%%%+++++==%%===%%===++============+++++=++*****++***+*+++++=%%%%%%%==%===+";
            Close += "@%==%%%%%@% +****+++= ++++== +++++==== ++++++++++++++= +********+*****+++==%%%%%%%%";
            Close += "===%%%%%%% ++******++++****++*+++++++++++++++*++++++*+**+******+***++==%%@@%%%%%===";
            Close += "=%%%%%%@%= ++******+++*****++*+*++++++++++**+++++++++++++++++++****++==%%%@@%%%%%%=";
            Close += "+=%%%@@%== ++++++++++++++++++++++++++++++*++++++++++++++++++++*++++++==%%%@@@%%%%=@";
            Close += ":*+%%@%%== ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++==%%@@@@%%%%%%";
            Close += "::%%%%%%%== +++++++++++++++++++++++++++++++++++++++++++++++++++++++++===%@@@@%%%%@@";
            Close += "*+%%%%%%%== +++++++++++++++++++++++++++++++++++++++++++++++++++++++++==%%@@@@%%%=%#";
            Close += "@%%%%%%%%%== ++++++++++++++++++++++++++++++++++++++++++++++++++++= ++===%%@@@@%%%%@";
            Close += "@@%%%%%%%%== +++++++++++++**********+***********+**+++++++++++++++++===%%@@@@@@%%%@";
            Close += "@@%%%%@@%== ++++++++++++++++*++******************++++++++++++++++++====%%@@@@@@%%=@";
            Close += "=%%%%%@@%== +++++++++++++++++++++++******+++++++++++++++****+++++++++===%%@@@@@@@@@";
            Close += "+%%%%%@@%== ++++++++***+++++++++++++++++++++++++=== ++++++++++**++++=====%%@@@@@@##";
            Close += "=+=%%%@@=== +++++++++=+=========== +++++=+========%%%%%%%===== +++++++====%%@@@@@@#";
            Close += "@%=%%%%%=== +++++===%%@@@@@@@%%%============%%%%@@@@@@@@%%%%%%===========%@@@@@@##%";
            Close += "%%%%@%%@== ++++===%%%%%%%%@@@%%%%%=========%%%@@@@@@%%====%%%%%%=========%@@@@@=+==";
            Close += "= +*%@@@%= +++===%%=====%@%%%%%%%%%%===+====%%@@@%%%%%%%%%%%%%%%%%========%@@@@@==@";
            Close += "+++=%@@%= +++==%%%%%= ++++==%%@@@@%%= +++++==%@@@@@%%%%%%@%=+==%%%%========%@@@%%%+";
            Close += "=@==%%@%=+=+===%%==%@@#####@@@@@@%=+++*++=%@@@@@@@######@@@%%%%====+++==%@@%%===%@=";
            Close += "%%%==%@@= ++++===%%@%%=@####%%@@%=%%+****+=%%=%@%%%=####%%%=========++++=%@%=+==%%@";
            Close += "@@%===%@= +++++============%%%%%=%== +****++=%%%%%%@%%%%%%%======== +++++++=@@@@%=@";
            Close += "@@@==%%%= ++++++++++==%%%%%%%%%===== +****++====%=====%%%%%===== +++++++++==%@@@%==";
            Close += "@@#=%%%%=++++++++++=========%====+++****++========%=======++++++++++++====%%%%=%@@=";
            Close += "=%%==%%%= ++++++++++==+======= +++++++****+++++++++++======== +++++++++++=====@%==%";
            Close += "%%%%==%%== ++++++++++++++++++++++++++*****++++++++++++++++++++++++++++====== ++==%%";
            Close += "@@%@% +*=== +++++++++++++++++++++++++*******++++++++++++++++++++++++======== +++*%@";
            Close += "@@@@% ++++=== +++++++++++++++++++++++*****+**+==== ++++++++++++++++++======%%%===@@";
            Close += "#@@#=+++====++++++++++++++++++++++++++++++++++======+++++++++++++======%%===%@##@#%";
            Close += "#@##@========+++++++++++++++===++============+=%%=========++++++=======%@@@@#@@@@@=";
            Close += "######@%%@=======================%%%%%%%%%%@%%=%===%%=================%%@##@@####@=";
            Close += "##########%=====================%@##@%@@@@@@@@%=====%%%%====%========%%%%@#@@@####=";
            Close += "##########@================++++==%@%@@@@@@%%%========%%%%%%%%%%%%=====@#@@#@%%%@@@=";
            Close += "###########=%=============++++++===%%%@@%%%==========%%%@%%%=%%%%%%==%@@@@@@##@#@#%";
            Close += "###########%==========%%==++++++=====%%%%%===========%%%@@@%%%%%%%%%%%@###@%#####@%";
            Close += "#########@##=========%%%%====================+++=====%%@@@@%%%%%%%%%%@###@##@####@%";
            Close += "@###########=%=======%@@%====++++===%%===%%@@%%@@@@@##@%%%%%%%%%%%%%%@@@@#########%";
            Close += "############%=========%%%@##@@@@@@@@@@@@@@@@@##@@%%%=%%%%%%%%%%%%%%%@##########@@#%";
            Close += "#############%%========%=====%%=======%%%%=====%%%%%%%%%%%%%%%%%%%%%##############%";
            Close += "##############%%%===%%==========%%%%%%%%%%%%%@@%%%%=====%%%%%%%%%%%@##############%";
            Close += "##############@%%%%%%%========%%%%%%%%%%%%%%%%%%%%===%%%%%%%%%%%%%%###############%";
            Close += "@@%@@@@@##@@#@@@%%%%%%==========%%%%@@@@@@@@%%%%%%===%%%%%%%%%%%%%@########@######%";
            Close += "#@@%%%==@%%#####%%%%%%%============%%%%%%%%%%=======%%%%%%%%%%%%%%################%";
            Close += "#@#@@%==######@#===%%%%%%=====++++++++=============%%%%%@@%%%%%%==+%##############%";
            Close += "#####@%%####@=+:+==%%@%%%%===++++++++=======++=====%%%%@@@@@@@%%==+**=@###########%";
            Close += "###########@+@%@%+=%%%@@@%%%%====================%%%%@@@@@@@@%%%=%##@=:-+#########=";
            Close += "#########%*=+--==+==%%%@@@@@%%%%=====%%%%%%%%%%%%%%%@@@@@@@@%%%%%==@@@##%*:=#####@=";
            Close += "######@++:%:%=%#=====%%@@@@@@@@@%%%%@%%@@@@%%@@@@@@@@@@@@@@%%%%%==##@==@##%++#####=";
            Close += "##@==:*=%%*=*-+#%====%%%%@@@@###@@@@@@@@@@@@@@@@@@@##@@@@@@%%%%%%=@####@++#@:.@##@=";
            Close += "+%% *+@@%:-+= ++##@=====%%%%@@@@@@####################@@@@@@%@%%%%==+=####%@%@#=*#@";
            Close += "#*=@=+@%+=#*=+##@%====%%%%%%%@@@@@@#############@@@@@@@@@%%%%%%%%===@##@##%%#%*=#@=";
        }


        public void paintAlekseev()
        {
            //  Console.Clear();
            int i = 0;
            while (Close.Length != i)
            {
                Console.Write(Close[i]);
                if (i % 83 == 0 && i != 0)
                    Console.WriteLine();
                i++;
            }
        }

        public void paintAleksZakroiRot()
        {
            int i = 0;
            while (Open.Length != i)
            {
                Console.Write(Open[i]);
                if (i % 83 == 0 && i != 0)
                    Console.WriteLine();
                i++;
            }
        }

        public void paintAleksZakroiBrov()
        {
            int i = 0;
            while (OpenBrov.Length != i)
            {
                Console.Write(OpenBrov[i]);
                if (i % 83 == 0 && i != 0)
                    Console.WriteLine();
                i++;
            }
        }
    }
}
